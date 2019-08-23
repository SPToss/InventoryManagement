using DataAccess.Base;
using DataAccess.Interfaces.InventoryStaus;
using DataAccess.Sql.InventoryStatus;
using DataTransfer.InventoryStatus;
using System.Collections.Generic;

namespace DataAccess.Implementation
{
    public class InventoryStatusDao : BaseConnection, IInventoryStatusDao
    {
        public IEnumerable<InventoryStatusDto> GetAllInventoryStatuses()
        {
            return QuerryForList<InventoryStatusDto>(InventoryStatusSql.GetAllInventoryStatuses());
        }
    }
}