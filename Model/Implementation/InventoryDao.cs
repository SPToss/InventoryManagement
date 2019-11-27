using System.Collections.Generic;
using DataAccess.Base;
using DataAccess.Interfaces.Inventory;
using DataAccess.Sql.Inventory;
using DataTransfer.Inventory;

namespace DataAccess.Implementation
{
    public class InventoryDao : BaseConnection, IInventoryDao
    {
        public void AddInventoryEvent(InventoryEventDto inventoryEvent)
        {
            NonResultQuerry(InventorySql.AddInventoryEvent(inventoryEvent));
        }

        public void AddInventoryProduct(InventoryProductDto inventoryProduct)
        {
            NonResultQuerry(InventorySql.AddInventoryProduct(inventoryProduct));
        }

        public IEnumerable<InventorySearchDto> GetAllActiveInventorySearch()
        {
            return QuerryForList<InventorySearchDto>(InventorySql.GetAllActiveInventorySearches());
        }

        public IEnumerable<InventoryDto> GetAllInventoriesByStatus(int? statusId)
        {
            return QuerryForList<InventoryDto>(InventorySql.GetAllInventoriesByStatus(statusId));
        }

        public IEnumerable<InventoryProductDto> GetAllInventoryProductsByInventoryId(int inventoryId)
        {
            return QuerryForList<InventoryProductDto>(InventorySql.GetInventoryProductsByInventoryId(inventoryId));
        }

        public InventoryDto GetInventoryById(int inventoryId)
        {
            return QueryForObject<InventoryDto>(InventorySql.GetInventoryById(inventoryId));
        }

        public IEnumerable<InventoryEventDto> GetInventoryEventsByInventoryId(int invenoryId)
        {
            return QuerryForList<InventoryEventDto>(InventorySql.GetInventoryEventsByInventoryId(invenoryId));
        }

        public InventoryProductDto GetInventoryProductByProductId(int productId)
        {
            return QueryForObject<InventoryProductDto>(InventorySql.GetInventoryProductByProductId(productId));
        }
    }
}