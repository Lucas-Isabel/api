using Microsoft.AspNetCore.Mvc;

namespace api.Models
{
    public class CreateNutriModel
    {
        public int ProductId { get; set; }
        public int[] Values { get; set; }
    }
}
