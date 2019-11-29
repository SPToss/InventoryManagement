using DataTransfer.Inventory;

namespace RestApi.Models.Inventory
{
    public class InventorySearchTypeModel
    {
        public int SearchTypeId { get; set; }

        public string SearchTypeDescription { get; set; }

        public static InventorySearchTypeModel FromDomain(InventorySearchDto domain)
        {
            return new InventorySearchTypeModel
            {
                SearchTypeDescription = domain.SearchTypeDescription,
                SearchTypeId = domain.SearchTypeId
            };
        }
    }
}