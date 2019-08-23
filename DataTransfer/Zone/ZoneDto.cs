namespace DataTransfer.Zone
{
    public class ZoneDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int? ParentZoneId { get; set; }

        public int Active { get; set; }
    }
}