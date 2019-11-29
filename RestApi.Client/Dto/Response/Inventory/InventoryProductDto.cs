using System;

namespace RestApi.Client.Dto.Response.Inventory
{
    public class InventoryProductDto
    {
        public int Id { get; set; }

        public int InventoryId { get; set; }

        public int ZoneId { get; set; }

        public DateTime ScannedDate { get; set; }
    }
}