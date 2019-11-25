using RestApi.Client.Dto.Owner;
using RestApi.Client.Dto.Product;
using RestApi.Client.Dto.Request.Product;
using RestApi.Client.Dto.Response.Product;
using RestApi.Client.Dto.Response.User;
using RestApi.Client.Dto.Response.Zone;
using RestApi.Client.Interface;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace InventoryManagement.ViewController
{
    public class MainWindowViewController
    {
        private readonly IRestApiClient _restApiClient;
        public MainWindowViewController(IRestApiClient restApiClient)
        {
            _restApiClient = restApiClient;
            Initialize();
            ProductViewModels.CollectionChanged += ProductsCollectionChanged;

        }

        #region Event declaration

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Event declaration

        #region Public fields

        public bool CanModifyUserData => true;
        public ObservableCollection<ProductViewModel> ProductViewModels { get; set; } = new ObservableCollection<ProductViewModel>();
        public List<ProductSearchTypeDto> ProductSearchTypes { get; set; } = new List<ProductSearchTypeDto>();
        public int SelectedSearchId { get; set; }

        public List<ProductDto> Products = new List<ProductDto>();

        public ProductViewModel SelectedProduct { get; set; }

        public List<OwnerDto> AvailableOwners { get; set; } = new List<OwnerDto>();

        public List<ZoneDto> AvailableZones { get; set; } = new List<ZoneDto>();

        public List<ProductTypeDto> AvailableProductTypes { get; set; } = new List<ProductTypeDto>();

        public List<ProductStatusDto> AvailableProductStatuses { get; set; } = new List<ProductStatusDto>();

        #endregion Public fields

        #region Public methods

        public void FillProductList()
        {
            if(SelectedSearchId == 0)
            {
                return;
            }
            ProductViewModels.Clear();
            Products = new List<ProductDto>();
            GetProductBySearchTypeDto requestDto = new GetProductBySearchTypeDto
            {
                ProductSearchTypeId = SelectedSearchId
            };

            switch (SelectedSearchId)
            {
                case 3:
                    requestDto.ExtraParams = new Dictionary<string, string>
                    {
                        {"ZoneId",UserContext.GetUserZoneId().ToString() }
                    };
                    break;
                default:
                    requestDto.ExtraParams = null;
                    break;
            }

            Products =  _restApiClient.GetProductBySearchId(requestDto);
            var porductsModels = Products.Select(ProductViewModel.FromRest);

            foreach(var model in porductsModels)
            {
                ProductViewModels.Add(model);
            }

        }

        public void RemoveSelectedProduct()
        {
            var productToRemove = ProductViewModels.First(x => x.ProductId == SelectedProduct.ProductId);

            if(productToRemove == null)
            {
                return;
            }

            _restApiClient.RemoveProduct(productToRemove.ProductId);

            RefreshProducts();
        }

        public void NewProduct()
        {
            SelectedProduct = null;
        }

        public void AddNewProduct(ProductTypeDto type, OwnerDto owner, ProductStatusDto status, ZoneDto zone, string description )
        {
            ProductDto productDto = new ProductDto
            {
                Description = description,
                Id = SelectedProduct.ProductId,
                Owner = owner,
                Status = status,
                Type = type,
                Zone = zone
            };

            SaveOrUpdateProduct(productDto);
        }

        #endregion Public methods

        #region Private methods

        private void ProductsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("ProductViewModels"));
            }
        }

        private void Initialize()
        {
            ProductSearchTypes = _restApiClient.GetAllProductSearchTypes();
            AvailableOwners = _restApiClient.GetAllOwners();
            AvailableProductStatuses = _restApiClient.GetAllProductStatuses();
            AvailableProductTypes = _restApiClient.GetAllProductTypes();
            AvailableZones = _restApiClient.GetAllZones();
        }

        private void SaveOrUpdateProduct(ProductDto product)
        {
            if(product == null)
            {
                return;
            }

            _restApiClient.SaveOrUpdateProduct(product);

            RefreshProducts();
        }

        private void RefreshProducts()
        {
            ProductViewModels.Clear();

            FillProductList();

            SelectedProduct = null;
        }

        #endregion Private methods
    }
}
