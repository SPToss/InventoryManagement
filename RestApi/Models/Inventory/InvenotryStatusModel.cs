using DataTransfer.InventoryStatus;

namespace RestApi.Models.Inventory
{
    public class InvenotryStatusModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public static InvenotryStatusModel FormDto(InventoryStatusDto dto)
        {
            return new InvenotryStatusModel
            {
                Active = dto.Active == 1,
                Description = dto.Description,
                Id = dto.Id
            };
        }

        public InventoryStatusDto ToDto()
        {
            return new InventoryStatusDto
            {
                Active = Active ? 1 : 0,
                Description = Description,
                Id = Id
            };
        }
    }
}