using api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutriValuesController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            CreateNutriModel model = new CreateNutriModel
            {
                ProductId = id,
                Values = new int[] { 1, 2, 3 }
            };
            return Ok(model);
        }

        [HttpPost("{id}")]
        public IActionResult Post(int id)
        {
            CreateNutriModel model = new CreateNutriModel
            {
                ProductId = id,
                Values = new int[] { 1, 2, 3 }
            };
            return Ok(model);
        }

        [HttpPost]
        public IActionResult PostAll(CreateNutriModel[] values)
        {
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
