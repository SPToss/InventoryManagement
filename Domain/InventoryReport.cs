using System.Collections.Generic;

namespace Domain
{
    public class InventoryReport
    {
        public List<Product> CorrectlyScannedProducts { get; set; }

        public List<Product> MissingProducts { get; set; }

        public List<Product> MovedProducts { get; set; }

    }
}