using DataAccess.Implementation;
using DataTransfer.ProductType;
using Domain.Types.Base;

namespace Domain.Types
{
    public class ProductType : TypeCacheValue<ProductTypeDto>
    {
        public ProductType() : base(new ProductTypeDao().GetAllProductTypes)
        {
        }
    }
}