namespace RestApi.Client.Dto.Request.Inventory
{
    public class UpdateInventoryDto
    {
        public int InventoryId { get; set; }

        public int NewStatusId { get; set; }
    }
}