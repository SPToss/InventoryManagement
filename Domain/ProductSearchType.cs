using DataTransfer.Product;

namespace Domain
{
    public class ProductSearchType
    {
        public int SearchTypeId { get; set; }

        public string SearchTypeDescription { get; set; }

        public static ProductSearchType FromDto(ProductSearchTypeDto dto)
        {
            return new ProductSearchType
            {
                SearchTypeDescription = dto.SearchTypeDescription,
                SearchTypeId = dto.SearchTypeId
            };
        }
    }
}