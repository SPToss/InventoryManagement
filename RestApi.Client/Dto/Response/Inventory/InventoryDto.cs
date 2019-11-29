using System;
using System.Collections.Generic;

namespace RestApi.Client.Dto.Response.Inventory
{
    public class InventoryDto
    {
        public int Id { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Description { get; set; }

        public int ZoneId { get; set; }

        public List<InventoryProductDto> Products { get; set; }

        public InvenotryStatusDto InventorySatus { get; set; }

    }
}