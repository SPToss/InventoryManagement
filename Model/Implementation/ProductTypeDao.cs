using DataAccess.Base;
using DataAccess.Interfaces.ProductType;
using DataAccess.Sql.ProductType;
using DataTransfer.ProductType;
using System.Collections.Generic;

namespace DataAccess.Implementation
{
    public class ProductTypeDao : BaseConnection, IProductTypeDao
    {
        public IEnumerable<ProductTypeDto> GetAllProductTypes()
        {
            return QuerryForList<ProductTypeDto>(ProductTypeSql.GetAllProductTypes());
        }
    }
}