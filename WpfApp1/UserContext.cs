using RestApi.Client.Dto.Response.User;
using System;

namespace InventoryManagement
{
    internal sealed class UserContext
    {
        private static UserResponseDto _user;

        private UserContext()
        {

        }

        public static void SetUser(UserResponseDto user)
        {
            if(_user != null)
            {
                throw new Exception("User already set");
            }

            _user = user;
        }

        public static int GetUserZoneId() => _user.ZoneId;

        public static bool CanAddUser() => _user.IsAdmin;
    }
}
