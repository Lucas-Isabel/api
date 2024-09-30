using Microsoft.AspNetCore.Mvc;

namespace api.Models
{
    public class CreateExtrasModel
    {
        public int ProductId { get; set; }
        public int ExtraId { get; set; }
        public string receita { get; set; }
        public string conserva { get; set; }
        public string alergia { get; set; }
        public string fornecedor { get; set; }
        public string fracionador { get; set; }
        public string extra1 { get; set; }
        public string extra2 { get; set; }
        public string extra3 { get; set; }
    }
}
