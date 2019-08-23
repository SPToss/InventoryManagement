using DataAccess.Implementation;
using DataTransfer.ProductStatus;
using Domain.Types.Base;


namespace Domain.Types
{
    public class ProductStatus : TypeCacheValue<ProductStatusDto>
    {
        public ProductStatus() : base(new ProductStatusDao().GetAllProductStatuses)
        {
        }
    }
}