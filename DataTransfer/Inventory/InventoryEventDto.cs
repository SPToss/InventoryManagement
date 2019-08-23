using System;

namespace DataTransfer.Inventory
{
    public class InventoryEventDto
    {
        public int Id { get; set; }

        public int InventoryId { get; set; }

        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        public int EventType { get; set; }
    }
}