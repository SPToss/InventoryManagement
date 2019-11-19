using Domain;

namespace RestApi.Models.Product
{
    public class ProductSearchTypeModel
    {
        public int SearchTypeId { get; set; }

        public string SearchTypeDescription { get; set; }

        public static ProductSearchTypeModel FromDomain(ProductSearchType domain)
        {
            return new ProductSearchTypeModel
            {
                SearchTypeDescription = domain.SearchTypeDescription,
                SearchTypeId = domain.SearchTypeId
            };
        }
    }
}