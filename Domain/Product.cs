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

        public int OwnerId { get; set; }

        public static Product FromDto(ProductDto dto)
        {
            return new Product
            {
                Id = dto.Id,
                Status = new ProductStatus().GetById(dto.ProductStatusId),
                Type = new ProductType().GetById(dto.ProductTypeId),
                OwnerId = dto.OwnerId
            };
        }

        public ProductDto ToDto()
        {
            return new ProductDto
            {
                Id = Id,
                ProductStatusId = Status.Id,
                ProductTypeId = Type.Id,
                OwnerId = OwnerId
            };
        }
    }
}