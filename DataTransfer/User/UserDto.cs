namespace DataTransfer.User
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public int ZoneId { get; set; }

        public string Salt { get; set; }

        public string Hash { get; set; }

        public int IsAdmin { get; set; }

        public int Active { get; set; }
    }
}
