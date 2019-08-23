using DataTransfer.InventoryEventType;
using System.Collections.Generic;

namespace DataAccess.Interfaces.InventoryEventType
{
    public interface IInventoryEventTypeDao
    {
        IEnumerable<InventoryEventTypeDto> GetAllInventoryEventTypes();
    }
}
