using DataAccess.Interfaces.ProductType;
using DataTransfer.ProductType;
using Domain.Types.Base;

namespace Domain.Types
{
    public class ProductType : TypeCacheValue<ProductTypeDto>
    {
        const int REFRESH_INTERVAL = 5;
        public ProductType(IProductTypeDao productTypeDao) : base(productTypeDao.GetAllProductTypes, REFRESH_INTERVAL)
        {
        }
    }
}