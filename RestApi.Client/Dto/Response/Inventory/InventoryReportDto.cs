using System.Collections.Generic;

namespace RestApi.Client.Dto.Response.Inventory
{
    public class InventoryReportDto
    {
        public string Info { get; set; }

        public List<string> ScannedItems { get; set; } = new List<string>();

        public List<string> MissingItems { get; set; } = new List<string>();

        public List<string> MovedItems { get; set; } = new List<string>();
    }
}