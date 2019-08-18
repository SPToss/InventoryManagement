using DataAccess.Base;
using DataAccess.Interfaces.ProductStatus;
using DataAccess.Sql.ProductStatus;
using DataTransfer.ProductStatus;
using System.Collections.Generic;

namespace DataAccess.Implementation
{
    public class ProductStatusDao : BaseConnection, IProductStatusDao
    {
        public IEnumerable<ProductStatusDto> GetAllProductStatuses()
        {
            return QuerryForList<ProductStatusDto>(ProductStatusSql.GetAllProductStatuses());
        }
    }
}