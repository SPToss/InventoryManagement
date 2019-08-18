using DataAccess.Implementation;
using DataTransfer.ProductStatus;
using Domain.Types.Base;


namespace Domain.Types
{
    public class ProductStatus : TypeCacheValue<ProductStatusDto>
    {
        const int REFRESH_INTERVAL = 5;
        public ProductStatus() : base(new ProductStatusDao().GetAllProductStatuses, REFRESH_INTERVAL)
        {
        }
    }
}