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

        public Product GetProductById(int id)
        {
            ProductDto productDto = _productDao.GetProductById(id);

            return Product.FromDto(productDto);
        }
    }
}
