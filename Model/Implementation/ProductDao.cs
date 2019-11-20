using System.Collections.Generic;
using System.Linq;
using DataAccess.Base;
using DataAccess.Interfaces.Product;
using DataAccess.Sql.Product;
using DataTransfer.Product;
using DataTransfer.Zone;

namespace DataAccess.Implementation
{
    public class ProductDao : BaseConnection, IProductDao
    {
        public IEnumerable<ProductSearchTypeDto> GetAllActiveProductSearches()
        {
            return QuerryForList<ProductSearchTypeDto>(ProductSql.GetAllActiveProductSearches());
        }

        public IEnumerable<ProductDto> GetAllActiveProductsForZones(List<ZoneDto> zones)
        {
            return QuerryForList<ProductDto>(ProductSql.GetProductByZones(string.Join(",", zones.Select(x => x.Id.ToString()))));
        }

        public IEnumerable<ProductDto> GetAllActiveProductsWithStatus(int statusId)
        {
            return QuerryForList<ProductDto>(ProductSql.GetProductByStatus(statusId));
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            return QuerryForList<ProductDto>(ProductSql.GetAllProducts());
        }

        public ProductDto GetProductById(int productId)
        {
            return QueryForObject<ProductDto>(ProductSql.GetProductById(productId));
        }
    }
}