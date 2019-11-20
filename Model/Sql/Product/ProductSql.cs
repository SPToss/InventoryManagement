
namespace DataAccess.Sql.Product
{
    public static class ProductSql
    { 
        public static string GetProductById(int id)
        {
            return $"SELECT " +
                $"ID AS Id," +
                $"OWNER_ID AS OwnerId," +
                $"PRODUCT_TYPE_ID as ProductTypeId," +
                $"PRODUCT_STATUS_ID as ProductStatusId, " +
                $"DESCRIPTION as Description," +
                $"ZONE_ID as ZoneId FROM PRODUCT WHERE ID = {id}";
        }

        public static string GetProductByStatus(int statusId)
        {
            return $"SELECT " +
                    $"ID AS Id," +
                    $"OWNER_ID AS OwnerId," +
                    $"PRODUCT_TYPE_ID as ProductTypeId," +
                    $"PRODUCT_STATUS_ID as ProductStatusId, " +
                    $"DESCRIPTION as Description," +
                    $"ZONE_ID as ZoneId FROM PRODUCT WHERE PRODUCT_STATUS_ID = {statusId}";
        }

        public static string GetProductByZones(string zonesWithComaSeparatedList)
        {
            return $"SELECT " +
                    $"ID AS Id," +
                    $"OWNER_ID AS OwnerId," +
                    $"PRODUCT_TYPE_ID as ProductTypeId," +
                    $"PRODUCT_STATUS_ID as ProductStatusId, " +
                    $"DESCRIPTION as Description," +
                    $"ZONE_ID as ZoneId FROM PRODUCT WHERE ZONE_ID in ({zonesWithComaSeparatedList})";
        }

        public static string GetAllProducts()
        {
            return $"SELECT " +
                    $"ID AS Id," +
                    $"OWNER_ID AS OwnerId," +
                    $"PRODUCT_TYPE_ID as ProductTypeId," +
                    $"PRODUCT_STATUS_ID as ProductStatusId, " +
                    $"DESCRIPTION as Description," +
                    $"ZONE_ID as ZoneId FROM PRODUCT";
        }

        public static string GetAllActiveProductSearches()
        {
            return "SELECT ID as SearchTypeId, DESCRIPTION as SearchTypeDescription FROM PRODUCT_SEARCH_TYPE";
        }
    }
}