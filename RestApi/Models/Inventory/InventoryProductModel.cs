using Domain;
using System;

namespace RestApi.Models.Inventory
{
    public class InventoryProductModel
    {
        public int Id { get; set; }

        public int InventoryId { get; set; }

        public int ZoneId { get; set; }

        public DateTime ScannedDate { get; set; }

        public static InventoryProductModel FormDomain(InventoryProduct inventoryProduct)
        {
            return new InventoryProductModel
            {
                Id = inventoryProduct.Id,
                InventoryId = inventoryProduct.InventoryId,
                ScannedDate = inventoryProduct.ScannedDate,
                ZoneId = inventoryProduct.ZoneId
            };
        }
    }
}