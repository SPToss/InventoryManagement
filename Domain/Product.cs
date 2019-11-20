using DataAccess.Interfaces.Owner;
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

        public Owner Owner { get; set; }

        public Zone Zone { get; set; }

        public string Description { get; set; }

        public static Product FromDto(ProductDto dto)
        {
            return new Product
            {
                Id = dto.Id,
                Status = new ProductStatus().GetById(dto.ProductStatusId),
                Type = new ProductType().GetById(dto.ProductTypeId),
                Description = dto.Description
            };
        }

        public ProductDto ToDto()
        {
            return new ProductDto
            {
                Id = Id,
                ProductStatusId = Status.Id,
                ProductTypeId = Type.Id,
                OwnerId = Owner.Id,
                ZoneId = Zone.Id,
                Description = Description
            };
        }
    }
}