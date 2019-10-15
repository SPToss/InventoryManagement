namespace DataTransfer.User
{
    public class UserHistoryTypeDto : ICacheType
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Active { get; set; }
    }
}