using System.Collections.Generic;

namespace UserService.Interface
{
    public interface IUserService
    {
        User Authorize(string login, string password);

        IEnumerable<User> GetAllActiveUsers();

        void UpdateUser(User user);
    }
}