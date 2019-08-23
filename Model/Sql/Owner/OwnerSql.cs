namespace DataAccess.Sql.Owner
{
    public static class OwnerSql
    {
        public static string GetOwnerById(int ownerId)
        {
            return $"SLECT ID as Id " +
                    $"NAME as Name" +
                    $"LOCATION as Location " +
                    $"ACTIVE as Actice " +
                    $"FORM OWNER WHERE ID = {ownerId}";
        }
    }
}