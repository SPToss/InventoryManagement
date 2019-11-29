using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApi.Models.Inventory
{
    public class InventoryModel
    {
        public int Id { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Description { get; set; }

        public int ZoneId { get; set; }

        public List<InventoryProductModel> Products { get; set; }

        public InvenotryStatusModel InventorySatus { get; set; }

        public static InventoryModel FromDomain(Domain.Inventory domain)
        {
            return new InventoryModel
            {
                Description = domain.Description,
                EndDate = domain.EndDate == DateTime.MinValue ? null as DateTime? : domain.EndDate,
                Id = domain.Id,
                InventorySatus = InvenotryStatusModel.FormDto(domain.InventorySatus),
                StartDate = domain.StartDate == DateTime.MinValue ? null as DateTime? : domain.StartDate,
                Products = domain.Products?.Select(InventoryProductModel.FormDomain).ToList() ?? new List<InventoryProductModel>(),
                ZoneId = domain.ZoneId
            };
        }
    }
}