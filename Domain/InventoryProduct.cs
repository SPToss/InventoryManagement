using DataTransfer.Inventory;
using System;

namespace Domain
{
    public class InventoryProduct
    {
        public int Id { get; set; }

        public int InventoryId { get; set; }

        public int ZoneId { get; set; }

        public DateTime ScannedDate { get; set; }

        public int ProductId { get; set; }

        public static InventoryProduct FormDto(InventoryProductDto dto)
        {
            return new InventoryProduct
            {
                Id = dto.Id,
                InventoryId = dto.InventoryId,
                ProductId = dto.ProductId,
                ScannedDate = dto.ScannedDate,
                ZoneId = dto.ZoneId
            };
        }

        public InventoryProductDto ToDto()
        {
            return new InventoryProductDto
            {
                Id = Id,
                InventoryId = InventoryId,
                ProductId = ProductId,
                ScannedDate = ScannedDate,
                ZoneId = ZoneId
            };
        }
    }
}