using DataTransfer.InventoryStatus;
using System.Collections.Generic;

namespace DataAccess.Interfaces.InventoryStaus
{
    public interface IInventoryStatusDao
    {
        IEnumerable<InventoryStatusDto> GetAllInventoryStatuses();
    }
}
