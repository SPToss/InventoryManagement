namespace DataAccess.Sql.ProductStatus
{
    public static class ProductStatusSql
    {
        public static string GetAllProductStatuses()
        {
            return "SELECT ID as Id, DESCRIPTION as Description, ACTIVE AS Active FROM PRODUCT_STATUS";
        }
    }
}