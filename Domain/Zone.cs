using DataTransfer.Zone;
using Domain.Extensions;

namespace Domain
{
    public class Zone
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int? ParentZoneId { get; set; }

        public bool Active { get; set; }

        public static Zone FromDto(ZoneDto dto)
        {
            return new Zone
            {
                Active = dto.Active.ActiveToBool(),
                Description = dto.Description,
                Id = dto.Id,
                ParentZoneId = dto.ParentZoneId
            };
        }

        public ZoneDto ToDto()
        {
            return new ZoneDto
            {
                Active = Active.ActiveToInt(),
                Description = Description,
                Id = Id,
                ParentZoneId = ParentZoneId
            };
        }
    }
}