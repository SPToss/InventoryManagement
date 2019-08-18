namespace DataTransfer.ProductType
{
    public class ProductTypeDto : ICacheType
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Active { get; set; }
    }
}