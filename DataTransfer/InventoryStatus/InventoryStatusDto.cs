using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransfer.InventoryStatus
{
    public class InventoryStatusDto : ICacheType
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Active { get; set; }
    }
}
