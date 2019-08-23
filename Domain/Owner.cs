using DataTransfer.Owner;
using Domain.Extensions;

namespace Domain
{
    public class Owner
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public bool Active { get; set; }

        public static Owner ToDomain(OwnerDto dto)
        {
            return new Owner
            {
                Active = dto.Active.ActiveToBool(), 
                Id = dto.Id,
                Location = dto.Location,
                Name = dto.Location
            };
        }

        public OwnerDto ToDto()
        {
            return new OwnerDto
            {
                Location = Location,
                Name = Name,
                Id = Id,
                Active = Active.ActiveToInt()
            };
        }
    }
}