using DataAccess.Implementation;
using DataTransfer.InventoryEventType;
using Domain.Types.Base;

namespace Domain.Types
{
    public class InventoryEventType : TypeCacheValue<InventoryEventTypeDto>
    {
        const int REFRESH_INTERVAL = 5;
        public InventoryEventType() : base(new InventoryEventTypeDao().GetAllInventoryEventTypes, REFRESH_INTERVAL)
        {

        }
    }
}