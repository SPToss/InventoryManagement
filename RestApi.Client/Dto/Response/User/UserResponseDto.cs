namespace RestApi.Client.Dto.Response.User
{
    public class UserResponseDto
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public int ZoneId { get; set; }

        public bool IsAdmin { get; set; }

        public bool Active { get; set; }
    }
} 