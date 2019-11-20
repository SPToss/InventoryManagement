using RestApi.Client.Dto.Request.Product;
using RestApi.Client.Dto.Response.Product;
using RestApi.Client.Dto.Response.User;
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

        #endregion Public fields

        #region Public methods

        public void FillProductList()
        {
            ProductViewModels.Clear();
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

            ProductViewModels.Remove(productToRemove);

            SelectedProduct = null;

            // Remove product;
        }

        public void NewProduct()
        {
            SelectedProduct = null;
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

        private void SelectedItemChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedProduct"));
            }
        }

        private void Initialize()
        {
            ProductSearchTypes = _restApiClient.GetAllProductSearchTypes();
        }

        #endregion Private methods
    }
}
