namespace DataAccess.Sql.Inventory
{
    public static class InventorySql
    {
        public static string GetAllActiveInventories()
        {
            return $"{InventorySelectSql()} WHERE STATUS_ID IN (1, 2) ";
        }

        public static string GetInventoryById(int inventoryId)
        {
            return $"{InventorySelectSql()} WHERE ID = {inventoryId}";
        }

        public static string GetInventoryEventsByInventoryId(int inventoryId)
        {
            return $"SELECT ID as Id" +
                    $"INVENTORY_ID as InventoryId" +
                    $"EVENT_DATE as Event " +
                    $"DESCRIPTION as Description" +
                    $"EVENT_TYPE_ID as EventTypeId" +
                    $"FROM INVENTORY_EVENT WHERE INVENTORY_ID = {inventoryId}";
        }

        private static string InventorySelectSql()
        {
            return "SELECT ID AS ID" +
                    "START_DATE as StartDate" +
                    "END_DATE as EndDate" +
                    "DESCRIPTION as Description" +
                    "STATUS_ID as StatusId " +
                    "FROM INVENTORY ";
        }
    }
}