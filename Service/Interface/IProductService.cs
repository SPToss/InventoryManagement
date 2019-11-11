using Domain;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IProductService
    {
        Product GetProductById(int id);
    }
}
