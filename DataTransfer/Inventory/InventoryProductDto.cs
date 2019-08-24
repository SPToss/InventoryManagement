using System;

namespace DataTransfer.Inventory
{
    public class InventoryProductDto
    {
        public int Id { get; set; }

        public int InventoryId { get; set; }

        public int ZoneId { get; set; }

        public DateTime ScannedDate { get; set; }

        public int ProductId { get; set; }
    }
}