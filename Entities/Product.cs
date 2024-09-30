using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api.Entities
{
    public class Product : BaseEntity
    {
        public Product() { }

        public Product(int productId, int productDepartmentId, string productName, int productType, int productPrice, int productValidade, string productDescription = "", string productLote = "")
            : base()
        {
            ProductId = productId;
            ProductDepartmentId = productDepartmentId;
            ProductName = productName;
            ProductType = productType;
            ProductPrice = productPrice;
            ProductValidade = productValidade;
            ProductDescription = productDescription;
            ProductLote = productLote;
        }

        public int ProductId { get; set; }
        public int ProductDepartmentId { get; set; }
        public string ProductName { get; set; }
        public int ProductType { get; set; }
        public int ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int ProductValidade { get; set; }
        public string ProductLote { get; set; }
    }
}
