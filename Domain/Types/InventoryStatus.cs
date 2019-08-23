using DataAccess.Implementation;
using DataTransfer.InventoryStatus;
using Domain.Types.Base;

namespace Domain.Types
{
    public class InventoryStatus : TypeCacheValue<InventoryStatusDto>
    {
        public InventoryStatus() : base(new InventoryStatusDao().GetAllInventoryStatuses)
        {
        }
    }
}