using System;

namespace DataTransfer.Inventory
{
    public class InventoryDto
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; } 

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public int StatusId { get; set; }

        public int ZoneId { get; set; }
    }
}