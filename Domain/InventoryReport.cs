using DataTransfer.Inventory;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Domain
{
    public class InventoryReport
    {
        public Inventory Inventory { get; set; }

        public string Info { get; set; }

        public List<string> ScannedItems { get; set; } = new List<string>();

        public List<string> MissingItems { get; set; } = new List<string>();

        public List<string> MovedItems { get; set; } = new List<string>();

        public InventoryReportDto ToDto()
        {
            return new InventoryReportDto
            {
                InventoryId = Inventory.Id,
                Raport = JsonConvert.SerializeObject(this)
            };
        }
    }
}