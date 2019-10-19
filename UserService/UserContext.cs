using System;
using System.Collections.Generic;
using System.Text;

namespace UserService
{
    public sealed class UserContext
    {
        private static  UserContext _userContext;
        private static  User _user;

        private UserContext() { }

        private UserContext(User user)
        {
            _user = user;
        }

        internal static void SetUser(User user)// TODO Introduce custom exception 
        {
            if(_userContext != null)
            {
                throw new Exception( "User is already set" );
            }

            _userContext = new UserContext(user);
        }

        public string GetLoggedUserName() => _user.Name;

        public string GetLoggedUserLastName() => _user.LastName;

        public string GetLoggedUserNameAndLastName() => $"{_user.Name} {_user.LastName}";

        public static bool IsUserLoggedIn() => _user != null;
    }
}
