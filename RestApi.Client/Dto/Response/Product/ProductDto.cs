using RestApi.Client.Dto.Owner;
using RestApi.Client.Dto.Product;
using RestApi.Client.Dto.Response.Zone;

namespace RestApi.Client.Dto.Response.Product
{
    public class ProductDto
    {
        public int Id { get; set; }

        public ProductStatusDto Status { get; set; }

        public ProductTypeDto Type { get; set; }

        public OwnerDto Owner { get; set; }

        public ZoneDto Zone { get; set; }

        public string Description { get; set; }
    }
}