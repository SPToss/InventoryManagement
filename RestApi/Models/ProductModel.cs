using Domain;

namespace RestApi.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public ProductStatusModel Status { get; set; }

        public ProductTypeModel Type { get; set; }

        public static ProductModel FormDomain(Product product)
        {
            return new ProductModel
            {
                Id = product.Id,
                Status = ProductStatusModel.FormDto(product.Status),
                Type = ProductTypeModel.FormDto(product.Type)
            };
        }
    }
}