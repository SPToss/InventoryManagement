using System.Runtime.Serialization;

namespace RestApi.Client.Dto.Product
{
    public class ProductTypeDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }
    }
}