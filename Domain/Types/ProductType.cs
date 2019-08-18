using DataAccess.Implementation;
using DataTransfer.ProductType;
using Domain.Types.Base;

namespace Domain.Types
{
    public class ProductType : TypeCacheValue<ProductTypeDto>
    {
        const int REFRESH_INTERVAL = 5;
        public ProductType() : base(new ProductTypeDao().GetAllProductTypes, REFRESH_INTERVAL)
        {
        }
    }
}