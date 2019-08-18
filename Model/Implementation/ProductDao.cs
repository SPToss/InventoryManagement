using DataAccess.Base;
using DataAccess.Interfaces.Product;
using DataAccess.Sql.Product;
using DataTransfer.Product;

namespace DataAccess.Implementation
{
    public class ProductDao : BaseConnection, IProductDao
    {
        public ProductDto GetProductById(int productId)
        {
            return QueryForObject<ProductDto>(ProductSql.GetProductById(productId));
        }
    }
}
