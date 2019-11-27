using DataTransfer.Inventory;
using System.Collections.Generic;

namespace DataAccess.Interfaces.Inventory
{
    public interface IInventoryDao
    {
        IEnumerable<InventoryDto> GetAllInventoriesByStatus(int? statusId);

        InventoryDto GetInventoryById(int inventoryId);

        IEnumerable<InventoryEventDto> GetInventoryEventsByInventoryId(int invenoryId);

        IEnumerable<InventoryProductDto> GetAllInventoryProductsByInventoryId(int inventoryId);

        InventoryProductDto GetInventoryProductByProductId(int productId);

        void AddInventoryProduct(InventoryProductDto inventoryProduct);

        void AddInventoryEvent(InventoryEventDto inventoryEvent);

        IEnumerable<InventorySearchDto> GetAllActiveInventorySearch();
    }
}