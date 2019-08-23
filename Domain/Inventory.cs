using DataTransfer.Inventory;
using DataTransfer.InventoryStatus;
using Domain.Types;
using System;

namespace Domain
{
    public  class Inventory
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public InventoryStatusDto InventorySatus { get; set; }

        public static Inventory FromDto(InventoryDto dto)
        {
            return new Inventory
            {
                Description = dto.Description,
                EndDate = dto.EndDate,
                StartDate = dto.StartDate,
                Id = dto.Id,
                InventorySatus = new InventoryStatus().GetById(dto.StatusId)
            };
        }

        public InventoryDto ToDto()
        {
            return new InventoryDto
            {
                Description = Description,
                EndDate = EndDate,
                StartDate = StartDate,
                Id = Id,
                StatusId = InventorySatus.Id
            };
        }
    }
}