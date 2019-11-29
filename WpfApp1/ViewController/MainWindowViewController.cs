using RestApi.Client.Dto.Owner;
using RestApi.Client.Dto.Product;
using RestApi.Client.Dto.Request.Product;
using RestApi.Client.Dto.Response.Inventory;
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
            AllActiveUsers.CollectionChanged += UsersCollectionChanged;
            InventoryViewModels.CollectionChanged += InventoryCollectionChanged;
            InventoryProductViewModels.CollectionChanged += InventoryProductCollectionChanged;
        }

        #region Event declaration

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Event declaration

        #region Public fields

        public bool CanModifyUserData => true;
        public ObservableCollection<ProductViewModel> ProductViewModels { get; set; } = new ObservableCollection<ProductViewModel>();

        public ObservableCollection<UserResponseDto> AllActiveUsers { get; set; } = new ObservableCollection<UserResponseDto>();

        public ObservableCollection<InventoryViewModel> InventoryViewModels { get; set; } = new ObservableCollection<InventoryViewModel>();

        public ObservableCollection<InventoryProductViewModel> InventoryProductViewModels { get; set; } = new ObservableCollection<InventoryProductViewModel>();

        public List<InventoryProductDto> AllProducts { get; set; } = new List<InventoryProductDto>();

        public List<InventorySearchTypeDto> InventorySearchTypeDtos { get; set; } = new List<InventorySearchTypeDto>(); 

        public int SelectedInventorySearchId { get; set; }

        public InventoryViewModel SelectedInventory { get; set; }

        public UserResponseDto SelectedUser { get; set; }

        public List<ProductSearchTypeDto> ProductSearchTypes { get; set; } = new List<ProductSearchTypeDto>();
        public int SelectedSearchId { get; set; }

        public List<ProductDto> Products = new List<ProductDto>();

        public ProductViewModel SelectedProduct { get; set; }

        public List<OwnerDto> AvailableOwners { get; set; } = new List<OwnerDto>();

        public List<ZoneDto> AvailableZones { get; set; } = new List<ZoneDto>();

        public List<ProductTypeDto> AvailableProductTypes { get; set; } = new List<ProductTypeDto>();

        public List<ProductStatusDto> AvailableProductStatuses { get; set; } = new List<ProductStatusDto>();

        public bool ShouldAllowToFinishInvenory() => SelectedInventory.InventoryStatus == "ACTIVE";

        public bool ShouldAllowToActivateInventory() => SelectedInventory.InventoryStatus == "NEW";

        public bool ShouldAllowToAbandonInventory() => SelectedInventory.InventoryStatus == "NEW" || SelectedInventory.InventoryStatus == "ACTIVE";

        public bool ShouldAllowToViewRaport() => SelectedInventory.InventoryStatus == "COMPLETE";

        #endregion Public fields

        #region Public methods

        public void FillProductList()
        {
            if (SelectedSearchId == 0)
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

            Products = _restApiClient.GetProductBySearchId(requestDto);
            var porductsModels = Products.Select(ProductViewModel.FromRest);

            foreach (var model in porductsModels)
            {
                ProductViewModels.Add(model);
            }
        }

        public void FillInventoryList()
        {
            InventoryViewModels.Clear();
            AllProducts = new List<InventoryProductDto>();
            var inventorys = _restApiClient.GetInventorysBySearchId(new RestApi.Client.Dto.Request.Inventory.GetInventoryBySearch{
                SearchId = SelectedInventorySearchId
            });

            foreach(var inventory in inventorys)
            {
                InventoryViewModels.Add(new InventoryViewModel
                {
                    Description = inventory.Description,
                    EndDate = inventory.EndDate,
                    Id = inventory.Id,
                    InventoryStatus = inventory.InventorySatus.Description,
                    StartDate = inventory.StartDate,
                    ZoneName = AvailableZones.First(x => x.Id == inventory.Id).Description
                });
            }

            AllProducts = inventorys.SelectMany(x => x.Products).ToList();
        }
        
        public void FillInventoryProductList()
        {
            var products = AllProducts.Where(x => x.InventoryId == SelectedInventory.Id);
            InventoryProductViewModels.Clear();
            foreach (var product in products)
            {
                InventoryProductViewModels.Add(new InventoryProductViewModel
                {
                    Id = product.Id,
                    ScannedDate = product.ScannedDate,
                    ScannedZone = AvailableZones.First(x => x.Id == product.ZoneId).Description
                });
            }
        }

        public void RemoveSelectedProduct()
        {
            var productToRemove = ProductViewModels.First(x => x.ProductId == SelectedProduct.ProductId);

            if (productToRemove == null)
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

        public void AddNewProduct(ProductTypeDto type, OwnerDto owner, ProductStatusDto status, ZoneDto zone, string description)
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

        public void DeactivateCurrentUser()
        {
            SelectedUser.Active = false;

            _restApiClient.UpdateUser(new RestApi.Client.Dto.Request.User.UserUpdateRequest
            {
                User = SelectedUser
            });

            RefreshUsers();
        }

        public void SaveUser(string name, string lastName, string login, string passwd, int zoneId, bool isActive, bool isAdmin)
        {
            _restApiClient.UpdateUser(new RestApi.Client.Dto.Request.User.UserUpdateRequest
            {
                User = new UserResponseDto
                {
                    Active = isActive,
                    IsAdmin = isAdmin,
                    LastName = lastName,
                    Login = login,
                    Name = name,
                    UserId = SelectedUser?.UserId ?? 0,
                    ZoneId = zoneId
                },
                Param = passwd
            });

            RefreshUsers();
        }

        public void ChangeInventoryStatus(int statusId)
        {
            _restApiClient.ChangeInventoryStatus(statusId, SelectedInventory.Id);
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

        private void UsersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("AllActiveUsers"));
            }
        }

        private void InventoryCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("InventoryViewModels"));
            }
        }

        private void InventoryProductCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("InventoryProductViewModels"));
            }
        }

        private void Initialize()
        {
            ProductSearchTypes = _restApiClient.GetAllProductSearchTypes();
            AvailableOwners = _restApiClient.GetAllOwners();
            AvailableProductStatuses = _restApiClient.GetAllProductStatuses();
            AvailableProductTypes = _restApiClient.GetAllProductTypes();
            AvailableZones = _restApiClient.GetAllZones();
            if (UserContext.CanAddUser())
            {
                var allActiveUsers = _restApiClient.GetAllActiveUsers();

                foreach (var user in allActiveUsers)
                {
                    AllActiveUsers.Add(user);
                }
            }
            InventorySearchTypeDtos = _restApiClient.GetAllInvenotoyrSearches();
        }

        private void SaveOrUpdateProduct(ProductDto product)
        {
            if (product == null)
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

        private void RefreshUsers()
        {
            AllActiveUsers.Clear();
            var allActiveUsers = _restApiClient.GetAllActiveUsers();

            foreach (var user in allActiveUsers)
            {
                AllActiveUsers.Add(user);
            }

            SelectedUser = null;
        }

        #endregion Private methods
    }
}
