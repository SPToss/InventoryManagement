using DataAccess.Base;
using DataAccess.Interfaces.InventoryEventType;
using DataAccess.Sql.InventoryEventType;
using DataTransfer.InventoryEventType;
using System;
using System.Collections.Generic;

namespace DataAccess.Implementation
{
    public class InventoryEventTypeDao : BaseConnection, IInventoryEventTypeDao
    {
        public IEnumerable<InventoryEventTypeDto> GetAllInventoryEventTypes()
        {
            return QuerryForList<InventoryEventTypeDto>(InventoryEventTypeSql.GetAllInventoryEventTypes());
        }
    }
}