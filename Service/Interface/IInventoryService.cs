using DataTransfer.Api.Request.Inventory;
using DataTransfer.Inventory;
using Domain;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IInventoryService
    {
        void AddInventoryProduct(InventoryProduct inventoryProduct);

        IEnumerable<Inventory> GetInventoryBySearch(GetInventoryBySearch getInventoryBySearch);

        IEnumerable<InventorySearchDto> GetAllInventorySerarches();

        void CreateNewInventory(NewInventoryRequestDto newInventoryRequestDto);

        void UpdateInventory(UpdateInventoryDto updateInventoryDto);

        InventoryReportDto GetReport(int inventoryId);
    }
}
