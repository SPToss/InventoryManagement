using DataTransfer.ProductType;
using System.Runtime.Serialization;

namespace RestApi.Models
{
    public class ProductTypeModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public static ProductTypeModel FormDto(ProductTypeDto dto)
        {
            return new ProductTypeModel
            {
                Active = dto.Active == 1,
                Description = dto.Description,
                Id = dto.Id
            };
        }
    }
}