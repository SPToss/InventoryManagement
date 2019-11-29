using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransfer.Api.Request.Inventory
{
    public class NewInventoryRequestDto
    {
        public int ZoneId { get; set; }

        public string Description { get; set; }
    }
}
