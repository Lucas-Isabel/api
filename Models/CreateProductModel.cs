using api.Entities;

namespace api.Models
{
    public class CreateProductModel
    {
        // Construtor padrão
        public CreateProductModel() { }

        // Propriedades
        public int ProductId { get; set; }
        public int ProductDepartmentId { get; set; }
        public string ProductName { get; set; }
        public int ProductType { get; set; }
        public int ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int ProductValidade { get; set; }
        public string ProductLote { get; set; }

        // Mapeamento de Product para CreateProductModel
        public static CreateProductModel FromEntity(Product entity)
            => new CreateProductModel
            {
                ProductId = entity.ProductId,
                ProductDepartmentId = entity.ProductDepartmentId,
                ProductName = entity.ProductName,
                ProductType = entity.ProductType,
                ProductPrice = entity.ProductPrice,
                ProductDescription = entity.ProductDescription,
                ProductValidade = entity.ProductValidade,
                ProductLote = entity.ProductLote
            };

        // Mapeamento de CreateProductModel para Product
        public Product ToEntity()
            => new Product
            {
                ProductId = ProductId,
                ProductDepartmentId = ProductDepartmentId,
                ProductName = ProductName,
                ProductType = ProductType,
                ProductPrice = ProductPrice,
                ProductValidade = ProductValidade,
                ProductDescription = ProductDescription,
                ProductLote = ProductLote
            };
    }
}
