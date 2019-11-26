using DataTransfer.User;

namespace DataAccess.Sql.User
{
    public class UserSql
    {

        public static string InserUserHistoryEventSql(UserHistoryDto userHistortyDto)
        {
            return $@"INSERT INTO USER_HISTORY (
                      USER_ID,
                      EVENT_DATE,
                      DESCRIPTION,
                      USER_HISTORY_TYPE_ID
                        )
                      VALUES (
                        {userHistortyDto.UserId},
                        '{userHistortyDto.EventDate.ToString("yyyy-MM-dd hh:mm:ss")}',
                        '{userHistortyDto.Description}',
                        {userHistortyDto.UserHistoryTypeId}
                        )";
        }

        public static string GetUserInformation(UserCredential userCredential) 
        {
            return $@"SELECT  ID as UserId,
                              NAME as Name,
                              LAST_NAME as LastName,
                              ZONE_ID as ZoneId,
                              LOGIN as Login,
                              IS_ADMIN as IsAdmin,
                              ACTIVE as Active
                     FROM USER
                     WHERE LOGIN = '{userCredential.Login}'
                     AND HASH = '{userCredential.Hash}'
                     AND ACTIVE =  1";
        }

        public static string GetAllActiveUsers()
        {
            return $@"SELECT  ID as UserId,
                              NAME as Name,
                              LAST_NAME as LastName,
                              ZONE_ID as ZoneId,
                              LOGIN as Login,
                              IS_ADMIN as IsAdmin,
                              ACTIVE as Active
                     FROM USER WHERE ACTIVE = 1";
        }

        public static string UpdateUser(UserDto user)
        {
            var userString = $@"UPDATE USER SET NAME = '{user.Name}', LAST_NAME = '{user.LastName}' , ZONE_ID = {user.ZoneId}, LOGIN = '{user.Login}', IS_ADMIN = {user.IsAdmin}, ACTIVE = {user.Active}";

            if (user.Hash != null)
            {
                userString += $@" ,HASH = '{user.Hash}', SALT = '{user.Salt}'";
            }

            userString += $@" WHERE ID = {user.UserId};";

            return userString;
        }

        public static string InsertUser(UserDto user)
        {
            return $@"INSERT INTO USER (ID, NAME, LAST_NAME, ZONE_ID, LOGIN, HASH, SALT, IS_ADMIN, ACTIVE) VALUES (NULL, '{user.Name}', '{user.LastName}', {user.ZoneId}, '{user.Login}', '{user.Hash}', '{user.Salt}', '{user.IsAdmin}', '{user.Active}')";
        }

        public static string GetUserHistoryEvents()
        {
            return "SELECT ID as Id, DESCRIPTION as Description, ACTIVE AS Active FROM USER_HISTORY_TYPE WHERE ACTIVE = 1";
        }

        public static string GetSaltForUser(string userLogin)
        {
            return $@"SELECT SALT AS Salt FROM USER WHERE LOGIN = '{userLogin}'";
        }
    }
}