
using DataTransfer.Product;

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

        public static string DeleteProduct(int id)
        {
            return $"DELETE FROM PRODUCT WHERE ID = {id}";
        }

        public static string UpdateProduct(ProductDto productDto)
        {
            return $@"UPDATE PRODUCT SET OWNER_ID = {productDto.OwnerId} , PRODUCT_TYPE_ID = {productDto.ProductTypeId} , PRODUCT_STATUS_ID = {productDto.ProductStatusId}, DESCRIPTION = '{productDto.Description}', ZONE_ID = {productDto.ZoneId} WHERE ID = {productDto.Id}";
        }

        public static string InsertProduct(ProductDto productDto)
        {
            return $@"INSERT INTO PRODUCT (ID, OWNER_ID, PRODUCT_TYPE_ID, PRODUCT_STATUS_ID, DESCRIPTION, ZONE_ID) VALUES (NULL,{productDto.OwnerId},{productDto.ProductTypeId},{productDto.ProductStatusId},'{productDto.Description}',{productDto.ZoneId})";
        }

        public static string GetAllActiveProductSearches()
        {
            return "SELECT ID as SearchTypeId, DESCRIPTION as SearchTypeDescription FROM PRODUCT_SEARCH_TYPE";
        }
    }
}