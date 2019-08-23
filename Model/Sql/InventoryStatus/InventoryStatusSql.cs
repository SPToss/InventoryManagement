namespace DataAccess.Sql.InventoryStatus
{
    public static class InventoryStatusSql
    {
        public static string GetAllInventoryStatuses()
        {
            return "SELECT ID as Id, DESCRIPTION as Description, ACTIVE AS Active FROM INVENTORY_STATUS";
        }
    }
}
