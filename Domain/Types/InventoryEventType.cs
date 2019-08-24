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

    public enum InventoryEventTypeEnum
    {
        InventoryCreated = 1,
        InventoryStarted = 2,
        InventoryEnded = 3,
        InventoryCancelled = 4,
        ProductAdded = 5,
        DuplicateScanned = 6,
        NotExisitingProductScanned = 7,
        InventoryPersonAssigned = 8,
        InventoryPersonRemoved = 9,
        ReportCreated = 10,
        UnknownError = 11
    }
}