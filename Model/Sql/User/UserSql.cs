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
                              LOGIN as Login
                     FROM USER
                     WHERE LOGIN = '{userCredential.Login}'
                     AND HASH = '{userCredential.Hash}'";
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