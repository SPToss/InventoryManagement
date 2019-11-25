
namespace RestApi.Models.Owner
{
    public class OwnerModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public bool Active { get; set; }

        public static OwnerModel FromDomain(Domain.Owner owner)
        {
            return new OwnerModel
            {
                Active = owner.Active,
                Id = owner.Id,
                Location = owner.Location,
                Name = owner.Name
            };
        }

        public Domain.Owner ToDomain()
        {
            return new Domain.Owner
            {
                Active = Active,
                Id = Id,
                Location = Location,
                Name = Name
            };
        }
    }
}