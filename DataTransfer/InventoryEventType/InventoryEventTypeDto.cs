namespace DataTransfer.InventoryEventType
{
    public class InventoryEventTypeDto : ICacheType
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Active { get; set; }
    }
}