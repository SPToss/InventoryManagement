namespace DataAccess.Sql.Zone
{
    public static class ZoneSql
    {
        public static string GetZoneByIdSql(int zoneId)
        {
            return $"{ZoneSelectSql()}" +
                $"WHERE ID = {zoneId}";
        }

        public static string GetAllChildZonesForZoneIds(string zoneIds)
        {
            return $"{ZoneSelectSql()}" +
                $"WHERE PARENT_ZONE_ID IN ({zoneIds})";
        }

        public static string GetAllActiveZones()
        {
            return $"SELECT DISTINCT " +
                     "ID as Id," +
                     "DESCRIPTION as Description," +
                     "PARENT_ZONE_ID as ParentZoneId," +
                     "ACTIVE as Active FROM ZONE WHERE ACTIVE = 1";
        }

        private static string ZoneSelectSql()
        {
            return $"SELECT " +
                 "ID as Id," +
                 "DESCRIPTION as Description," +
                 "PARENT_ZONE_ID as ParentZoneId," +
                 "ACTIVE as Active FROM ZONE ";
        }
    }
}