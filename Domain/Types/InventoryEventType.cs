using DataAccess.Implementation;
using DataTransfer.InventoryEventType;
using Domain.Types.Base;

namespace Domain.Types
{
    public class InventoryEventType : TypeCacheValue<InventoryEventTypeDto>
    {
        public InventoryEventType() : base(new InventoryEventTypeDao().GetAllInventoryEventTypes)
        {
        }
    }
}