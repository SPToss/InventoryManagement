using DataTransfer.ProductType;
using System.Collections.Generic;

namespace DataAccess.Interfaces.ProductType
{
    public interface IProductTypeDao
    {
        IEnumerable<ProductTypeDto> GetAllProductTypes();
    }
}