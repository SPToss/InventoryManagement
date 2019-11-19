using System.Collections.Generic;
using System.Linq;
using DataAccess.Interfaces.Product;
using DataTransfer.Product;
using Domain;
using Service.Interface;

namespace Service
{
    public class ProductService : IProductService
    {

        private readonly IProductDao _productDao;

        public ProductService(IProductDao productDao)
        {
            _productDao = productDao;
        }

        public List<ProductSearchType> GetAllActiveProductSearches()
        {
            IEnumerable<ProductSearchTypeDto> productSearchTypeDtos = _productDao.GetAllActiveProductSearches();

            return productSearchTypeDtos.Select(ProductSearchType.FromDto).ToList();
        }

        public Product GetProductById(int id)
        {
            ProductDto productDto = _productDao.GetProductById(id);

            return Product.FromDto(productDto);
        }
    }
}