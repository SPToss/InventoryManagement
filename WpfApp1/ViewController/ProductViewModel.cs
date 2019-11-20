using RestApi.Client.Dto.Response.Product;
using System.ComponentModel;

namespace InventoryManagement.ViewController
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public int ProductId { get; set; }

        public string ProductDescription { get; set; }

        public string ProductType { get; set; }

        public string StatusDescription { get; set; }

        public string ZoneDescription { get; set; }

        public string OwnerName { get; set; }

        public string OwnerDescription { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public static ProductViewModel FromRest(ProductDto product)
        {
            return new ProductViewModel
            {
                OwnerDescription = product.Owner.Location,
                OwnerName = product.Owner.Name,
                ProductDescription = product.Description,
                ProductId = product.Id,
                StatusDescription = product.Status.Description,
                ZoneDescription = product.Zone.Description,
                ProductType = product.Type.Description
            };
        }
    }
}