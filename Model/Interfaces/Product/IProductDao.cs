using DataTransfer.Product;
using System.Collections.Generic;

namespace DataAccess.Interfaces.Product
{
    public interface IProductDao
    {
        ProductDto GetProductById(int productId);

        IEnumerable<ProductSearchTypeDto> GetAllActiveProductSearches();
    }
}