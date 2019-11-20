﻿namespace DataAccess.Sql.Owner
{
    public static class OwnerSql
    {
        public static string GetOwnerById(int ownerId)
        {
            return $"SELECT ID as Id, " +
                    $"NAME as Name," +
                    $"LOCATION as Location, " +
                    $"ACTIVE as Active " +
                    $"FROM OWNER WHERE ID = {ownerId}";
        }
    }
}