using RestApi.Models.Owner;
using RestApi.Models.Zone;

namespace RestApi.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public ProductStatusModel Status { get; set; }

        public ProductTypeModel Type { get; set; }

        public OwnerModel Owner { get; set; }

        public ZoneModel Zone { get; set; }

        public string Description { get; set; }

        public static ProductModel FormDomain(Domain.Product product)
        {
            return new ProductModel
            {
                Id = product.Id,
                Status = ProductStatusModel.FormDto(product.Status),
                Type = ProductTypeModel.FormDto(product.Type),
                Description = product.Description,
                Owner = OwnerModel.FromDomain(product.Owner),
                Zone = ZoneModel.FormDomain(product.Zone)
            };
        }
    }
}