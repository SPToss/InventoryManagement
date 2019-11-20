using System.Collections.Generic;

namespace RestApi.Client.Dto.Request.Product
{
    public class GetProductBySearchTypeDto
    {
        public int ProductSearchTypeId { get; set; }

        public Dictionary<string, string> ExtraParams { get; set; } = new Dictionary<string, string>();
    }
}