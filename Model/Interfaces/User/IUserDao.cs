using DataTransfer.User;
using System.Collections.Generic;

namespace DataAccess.Interfaces.User
{
    public interface IUserDao
    {
        UserDto Authorize(UserCredential credentials);

        void SaveUserHistoryEvent(UserHistoryDto userHistoryDto);

        IEnumerable<UserHistoryTypeDto> GetAllActiveUserHistoryTypes();

        string GetSaltForUser(string login);

        IEnumerable<UserDto> GetAllActiveUsers();

        void UpdateUser(UserDto user);

        void InsertUser(UserDto user);
    }
}
