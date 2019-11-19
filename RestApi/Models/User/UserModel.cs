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

        public static UserModel FromDomain(UserService.User user)
        {
            return new UserModel
            {
                LastName = user.LastName,
                Login = user.Login,
                Name = user.Name,
                Salt = user.Salt,
                UserId = user.UserId,
                ZoneId = user.ZoneId
            };
        }
    }
}