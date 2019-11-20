namespace DataTransfer.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductStatusId { get; set; }

        public string Description { get; set; }

        public int ZoneId { get; set; }
    }
}