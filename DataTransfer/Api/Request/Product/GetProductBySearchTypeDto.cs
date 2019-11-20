using System.Collections.Generic;

namespace DataTransfer.Api.Request.Product
{
    public class GetProductBySearchTypeDto
    {
        public int ProductSearchTypeId { get; set; }

        public Dictionary<string,string> ExtraParams { get; set; } = new Dictionary<string, string>();
    }
}