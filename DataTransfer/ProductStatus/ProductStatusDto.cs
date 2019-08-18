namespace DataTransfer.ProductStatus
{
    public class ProductStatusDto : ICacheType
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Active { get; set; }
    }
}