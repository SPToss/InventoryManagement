using System.Runtime.Serialization;

namespace RestApi.Client.Dto.Owner
{
    public class OwnerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public bool Active { get; set; }
    }
}