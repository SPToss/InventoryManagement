using DataTransfer.Api.Request.Product;
using DataTransfer.Product;
using Domain;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IProductService
    {
        Product GetProductById(int id);

        List<ProductSearchType> GetAllActiveProductSearches();

        List<Product> GetProductsByCriteria(GetProductBySearchTypeDto getProductBySearchTypeDto);
    }
}