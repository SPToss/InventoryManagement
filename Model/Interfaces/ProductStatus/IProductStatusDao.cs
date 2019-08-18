using DataTransfer.ProductStatus;
using System.Collections.Generic;

namespace DataAccess.Interfaces.ProductStatus
{
    public interface IProductStatusDao
    {
        IEnumerable<ProductStatusDto> GetAllProductStatuses();
    }
}