namespace DataAccess.Sql.InventoryEventType
{
    public static class InventoryEventTypeSql
    {
        public static string GetAllInventoryEventTypes()
        {
            return "SELECT ID as Id, DESCRIPTION as Description, ACTIVE AS Active FROM INVENTORY_EVENT_TYPE";
        }
    }
}