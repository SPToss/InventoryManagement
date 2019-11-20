using DataTransfer.Product;
using DataTransfer.Zone;
using System.Collections.Generic;

namespace DataAccess.Interfaces.Product
{
    public interface IProductDao
    {
        ProductDto GetProductById(int productId);

        IEnumerable<ProductSearchTypeDto> GetAllActiveProductSearches();

        IEnumerable<ProductDto> GetAllActiveProductsWithStatus(int statusId);

        IEnumerable<ProductDto> GetAllActiveProductsForZones(List<ZoneDto> zones);

        IEnumerable<ProductDto> GetAllProducts();
    }
}