using DataAccess.Base;
using DataAccess.Interfaces.User;
using DataAccess.Sql.User;
using DataTransfer.User;
using System.Collections.Generic;

namespace DataAccess.Implementation
{
    public class UserDao : BaseConnection, IUserDao
    {
        public UserDto Authorize(UserCredential credentials)
        {
            return QueryForObject<UserDto>(UserSql.GetUserInformation(credentials));
        }

        public IEnumerable<UserHistoryTypeDto> GetAllActiveUserHistoryTypes()
        {
            return QuerryForList<UserHistoryTypeDto>(UserSql.GetUserHistoryEvents());
        }

        public IEnumerable<UserDto> GetAllActiveUsers()
        {
            return QuerryForList<UserDto>(UserSql.GetAllActiveUsers());
        }

        public string GetSaltForUser(string login)
        {
            return QueryForObject<string>(UserSql.GetSaltForUser(login));
        }

        public void InsertUser(UserDto user)
        {
            NonResultQuerry(UserSql.InsertUser(user));
        }

        public void SaveUserHistoryEvent(UserHistoryDto userHistoryDto)
        {
            NonResultQuerry(UserSql.InserUserHistoryEventSql(userHistoryDto));
        }

        public void UpdateUser(UserDto user)
        {
            NonResultQuerry(UserSql.UpdateUser(user));
        }
    }
}