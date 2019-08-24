
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
                $"ZONE_ID as ZoneId FROM PRODUCT WHERE ID = {id}";
        }
    }
}