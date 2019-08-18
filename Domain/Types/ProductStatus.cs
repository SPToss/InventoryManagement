using DataAccess.Interfaces.ProductStatus;
using DataTransfer.ProductStatus;
using Domain.Types.Base;


namespace Domain.Types
{
    public class ProductStatus : TypeCacheValue<ProductStatusDto>
    {
        const int REFRESH_INTERVAL = 5;
        public ProductStatus(IProductStatusDao productStatusDao) : base(productStatusDao.GetAllProductStatuses, REFRESH_INTERVAL)
        {
        }
    }
}