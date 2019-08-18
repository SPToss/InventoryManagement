using DataTransfer.Product;

namespace DataAccess.Interfaces.Product
{
    public interface IProductDao
    {
        ProductDto GetProductById(int productId);
    }
}