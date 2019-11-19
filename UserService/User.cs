using DataTransfer.User;

namespace UserService
{
    public sealed class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public int ZoneId { get; set; }

        public string Salt { get; set; }

        internal static User FromDto(UserDto userDto)
        {
            return new User
            {
                LastName = userDto.LastName,
                Login = userDto.Login,
                Name = userDto.Name,
                Salt = userDto.Salt,
                UserId = userDto.UserId,
                ZoneId = userDto.ZoneId
            };
        }
    }
}