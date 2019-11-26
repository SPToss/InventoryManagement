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

        public bool IsAdmin { get; set; }

        public bool Active { get; set; }

        public string NewPaswd { get; set; }

        internal static User FromDto(UserDto userDto)
        {
            return new User
            {
                LastName = userDto.LastName,
                Login = userDto.Login,
                Name = userDto.Name,
                Salt = userDto.Salt,
                UserId = userDto.UserId,
                ZoneId = userDto.ZoneId,
                Active = userDto.Active == 1,
                IsAdmin = userDto.IsAdmin == 1
            };
        }

        public UserDto ToDto()
        {
            return new UserDto
            {
                IsAdmin = IsAdmin ? 1 : 0,
                Active = Active ? 1 : 0,
                LastName = LastName,
                Login = Login,
                Name = Name,
                Salt = Salt,
                UserId = UserId,
                ZoneId = ZoneId
            };
        }
    }
}