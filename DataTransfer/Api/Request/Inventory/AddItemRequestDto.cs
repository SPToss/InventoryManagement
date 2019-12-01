namespace DataTransfer.Api.Request.Inventory
{
    public class AddItemRequestDto
    {
        public int ProductId { get; set; }

        public int ZoneId { get; set; }

        public int InventoryId { get; set; }
    }
}