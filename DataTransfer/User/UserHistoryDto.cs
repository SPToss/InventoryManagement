using System;

namespace DataTransfer.User
{
    public class UserHistoryDto
    {
        public int ID { get; set; }

        public int? UserId { get; set; }

        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        public int UserHistoryTypeId { get; set; }
    }
}