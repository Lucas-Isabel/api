using api.DB;
using api.Entities;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PluController : ControllerBase
    {
        private readonly ApiDBContext _db;

        public PluController(ApiDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projection = Builders<Product>.Projection.Include(p => p.ProductId)
                                                        .Include(p => p.ProductName)
                                                        .Include(p => p.ProductPrice)
                                                        .Include(p => p.ProductType)
                                                        .Include(p => p.ProductValidade);

            var models = await _db.Products
                .Find(Builders<Product>.Filter.Empty)
                .Project<Product>(projection)  // Aplica a projeção
                .ToListAsync();

            var result = models.Select(p => new
            {
                p.ProductId,
                p.ProductName,
                p.ProductPrice,
                p.ProductType,
                p.ProductValidade
                // Inclua outros campos necessários aqui
            });

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            
            var product = await _db.Products.Find(p => p.ProductId == id).SingleOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        [HttpPost("{id}/product")]
        public async Task<IActionResult> Post(string id, CreateProductModel model)
        {
            var product = model.ToEntity();
            product.Id = id; // Defina o ID, se necessário

            await _db.Products.InsertOneAsync(product);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> PostAll(CreateProductModel[] models)
        {
            var tasks = models.Select(async model =>
            {
                var existingProduct = await _db.Products.Find(p => p.ProductId == model.ProductId).SingleOrDefaultAsync();
                if (existingProduct == null)
                {
                    var product = model.ToEntity();
                    await _db.Products.InsertOneAsync(product);
                }
            });

            await Task.WhenAll(tasks);
            return Ok(models);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var updateDefinition = Builders<Product>.Update.Set(p => p.IsDeleted, true);
            var result = await _db.Products.UpdateOneAsync(p => p.Id == id && !p.IsDeleted, updateDefinition);

            if (result.ModifiedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
