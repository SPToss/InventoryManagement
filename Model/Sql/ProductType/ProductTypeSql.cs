namespace DataAccess.Sql.ProductType
{
    public static class ProductTypeSql
    {
        public static string GetAllProductTypes()
        {
            return "SELECT ID as Id, DESCRIPTION as Description, ACTIVE AS Active FROM PRODUCT_TYPE";
        }
    }
}