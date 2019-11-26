namespace RestApi.Models.User
{
    public class UserModel
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public int ZoneId { get; set; }

        public string Salt { get; set; }

        public bool IsAdmin { get; set; }

        public bool Active { get; set; }

        public static UserModel FromDomain(UserService.User user)
        {
            return new UserModel
            {
                LastName = user.LastName,
                Login = user.Login,
                Name = user.Name,
                Salt = user.Salt,
                UserId = user.UserId,
                ZoneId = user.ZoneId,
                Active = user.Active,
                IsAdmin = user.IsAdmin
            };
        }

        public UserService.User ToDomain()
        {
            return new UserService.User
            {
                LastName = LastName,
                Login = Login,
                Name = Name,
                Salt = Salt,
                UserId = UserId,
                ZoneId = ZoneId,
                Active = Active,
                IsAdmin = IsAdmin
            };
        }
    }
}