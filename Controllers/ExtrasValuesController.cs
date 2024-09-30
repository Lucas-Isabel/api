using api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtrasValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult PostAll(CreateExtrasModel[] models)
        {
            return Ok(models);
        }

        [HttpPost("{id}")]
        public IActionResult Post(int id)
        {
            CreateExtrasModel model = new CreateExtrasModel {
            ExtraId = id,
            ProductId = 0,
            extra1 = "",
            extra2 = "",
            extra3 = "",
            fornecedor = "",
            conserva = "",
            fracionador = "",
            alergia = "",
            };
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
