using DataTransfer.Product;
using DataTransfer.ProductStatus;
using DataTransfer.ProductType;
using Domain.Types;

namespace Domain
{
    public class Product
    {
        public int Id { get; set; }

        public ProductStatusDto Status { get; set; }

        public ProductTypeDto Type { get; set; }

        public static Product FromDto(ProductDto dto)
        {
            return new Product
            {
                Id = dto.Id,
                Status = new ProductStatus().GetById(dto.ProductStatusId),
                Type = new ProductType().GetById(dto.ProductTypeId)
            };
        }

        public ProductDto ToDto()
        {
            return new ProductDto
            {
                Id = this.Id,
                ProductStatusId = this.Status.Id,
                ProductTypeId = this.Type.Id
            };
        }
    }
}
