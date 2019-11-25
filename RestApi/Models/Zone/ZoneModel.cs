using System.Runtime.Serialization;

namespace RestApi.Models.Zone
{
    public class ZoneModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int? ParentZoneId { get; set; }

        public bool Active { get; set; }

        public static ZoneModel FromDomain(Domain.Zone zone)
        {
            return new ZoneModel
            {
                Active = zone.Active,
                Description = zone.Description,
                Id = zone.Id,
                ParentZoneId = zone.ParentZoneId
            };
        }

        public Domain.Zone ToDomain()
        {
            return new Domain.Zone
            {
                Id = Id,
                Description = Description,
                Active = Active,
                ParentZoneId = ParentZoneId
            };
        }
    }
}
