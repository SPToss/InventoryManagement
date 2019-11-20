using System.Runtime.Serialization;

namespace RestApi.Client.Dto.Response.Zone
{
    public class ZoneDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int? ParentZoneId { get; set; }

        public bool Active { get; set; }
    }
}