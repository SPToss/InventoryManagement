using DataTransfer.ProductStatus;
using System.Runtime.Serialization;

namespace RestApi.Models
{
    public class ProductStatusModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public static ProductStatusModel FormDto(ProductStatusDto dto)
        {
            return new ProductStatusModel
            {
                Active = dto.Active == 1,
                Description = dto.Description,
                Id = dto.Id
            };
        }

        public ProductStatusDto ToDto()
        {
            return new ProductStatusDto
            {
                Active = Active ? 1 : 0,
                Description = Description,
                Id = Id
            };
        }
    }
}