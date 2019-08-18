
namespace DataAccess.Sql.Product
{
    public static class ProductSql
    {
        public static string GetProductById(int id)
        {
            return $"SELECT " +
                $"ID AS Id," +
                $"OWNER_ID AS OwnerId," +
                $"PRODTUCT_TYPE_ID as ProductTypeId," +
                $"PRODUCT_STATUS_ID as ProductStatusID FROM PRODUCT WHERE ID = {id}";
        }
    }
}