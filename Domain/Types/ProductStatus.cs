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

        public ProductStatusDto Active => GetById(1);

        public ProductStatusDto Missing => GetById(2);

        public ProductStatusDto Damaged => GetById(3);

    }
}