using DataTransfer.Api.Request.Product;
 using DataTransfer.ProductStatus;
using DataTransfer.ProductType;
using Domain;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IProductService
    {
        Product GetProductById(int id);

        List<ProductSearchType> GetAllActiveProductSearches();

        List<Product> GetProductsByCriteria(GetProductBySearchTypeDto getProductBySearchTypeDto);

        IEnumerable<ProductStatusDto> GetAllProductStatus();

        IEnumerable<ProductTypeDto> GetAllProductTypes();

        void DeleteProduct(int id);

        void InserOrUpdateProduct(Product product);
    }
}