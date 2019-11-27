using DataTransfer.Inventory;

namespace DataAccess.Sql.Inventory
{
    public static class InventorySql
    {
        public static string GetAllInventoriesByStatus(int? stausId)
        {
            var sql =  $"{InventorySelectSql()}";

            if (stausId.HasValue)
            {
                sql += $" WHERE STATUS_ID = {stausId.Value} ";
            }

            return sql;
        }

        public static string GetInventoryById(int inventoryId)
        {
            return $"{InventorySelectSql()} WHERE ID = {inventoryId}";
        }

        public static string GetInventoryEventsByInventoryId(int inventoryId)
        {
            return $"SELECT ID as Id," +
                    $"INVENTORY_ID as InventoryId," +
                    $"EVENT_DATE as Event, " +
                    $"DESCRIPTION as Description," +
                    $"EVENT_TYPE_ID as EventTypeId," +
                    $"FROM INVENTORY_EVENT WHERE INVENTORY_ID = {inventoryId}";
        }

        public static string GetInventoryProductByProductId(int productId)
        {
            return $"{GetInventoryProductSql()}" +
                $"WHERE PRODUCT_ID = {productId}";
        }

        public static string GetInventoryProductsByInventoryId(int inventoryId)
        {
            return $"{GetInventoryProductSql()}" +
                     $"WHERE INVENTORY_ID = {inventoryId}";
        }

        public static string AddInventoryProduct(InventoryProductDto inventoryProduct)
        {
            return $"INSERT INTO INVENTORY_PRODUCT(" +
                $"ID," +
                $"INVENTORY_ID," +
                $"ZONE_ID," +
                $"SACANNED_DATE," +
                $"PRODUCT_ID)" +
                $"VALUES(" +
                $"NULL," +
                $"{inventoryProduct.InventoryId}," +
                $"{inventoryProduct.ZoneId}," +
                $"{inventoryProduct.ScannedDate.ToString("yyyy-MM-dd hh:mm:ss")}," +
                $"{inventoryProduct.ProductId})";
        }

        public static string AddInventoryEvent(InventoryEventDto inventoryEvent)
        {
            return $"INSERT INTO INVENTORY_EVENT(" +
                 $"ID," +
                 $"INVENTORY_ID," +
                 $"EVENT_DATE," +
                 $"DESCRIPTION," +
                 $"EVENT_TYPE_ID)" +
                 $"VALUES(" +
                 $"null," +
                 $"{inventoryEvent.InventoryId}," +
                 $"'{inventoryEvent.EventDate.ToString("yyyy-MM-dd hh:mm:ss")}'," +
                 $"'{inventoryEvent.Description}'," +
                 $"{inventoryEvent.EventType})";
        }

        public static string GetAllActiveInventorySearches()
        {
            return "SELECT ID as SearchTypeId, DESCRIPTION as SearchTypeDescription FROM INVENTORY_SEARCH_TYPE WHERE ACTIVE = 1";
        }

        private static string GetInventoryProductSql()
        {
            return "SELECT ID as Id," +
                "INVENTORY_ID as InventoryId," +
                "ZONE_ID as ZoneId," +
                "SACANNED_DATE as ScannedDate, " +
                "PRODUCT_ID as ProductId FORM INVENTORY_PRODUCT";
        }

        private static string InventorySelectSql()
        {
            return "SELECT ID AS ID," +
                    "START_DATE as StartDate," +
                    "END_DATE as EndDate," +
                    "DESCRIPTION as Description," +
                    "STATUS_ID as StatusId, " +
                    "ZONE_ID as ZoneId "+
                    "FROM INVENTORY ";
        }
    }
}