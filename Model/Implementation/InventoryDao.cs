using System.Collections.Generic;
using DataAccess.Base;
using DataAccess.Interfaces.Inventory;
using DataAccess.Sql.Inventory;
using DataTransfer.Inventory;

namespace DataAccess.Implementation
{
    public class InventoryDao : BaseConnection, IInventoryDao
    {
        public IEnumerable<InventoryDto> GetActiveInventories()
        {
            return QuerryForList<InventoryDto>(InventorySql.GetAllActiveInventories());
        }

        public InventoryDto GetInventoryById(int inventoryId)
        {
            return QueryForObject<InventoryDto>(InventorySql.GetInventoryById(inventoryId));
        }

        public IEnumerable<InventoryEventDto> GetInventoryEventsByInventoryId(int invenoryId)
        {
            return QuerryForList<InventoryEventDto>(InventorySql.GetInventoryEventsByInventoryId(invenoryId));
        }
    }
}