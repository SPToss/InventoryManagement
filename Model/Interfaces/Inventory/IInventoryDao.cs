using DataTransfer.Inventory;
using System.Collections.Generic;

namespace DataAccess.Interfaces.Inventory
{
    public interface IInventoryDao
    {
        IEnumerable<InventoryDto> GetActiveInventories();

        InventoryDto GetInventoryById(int inventoryId);

        IEnumerable<InventoryEventDto> GetInventoryEventsByInventoryId(int invenoryId);
    }
}