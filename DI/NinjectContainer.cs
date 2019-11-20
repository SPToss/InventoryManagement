using DataAccess.Implementation;
using DataAccess.Interfaces.Inventory;
using DataAccess.Interfaces.InventoryEventType;
using DataAccess.Interfaces.InventoryStaus;
using DataAccess.Interfaces.Owner;
using DataAccess.Interfaces.Product;
using DataAccess.Interfaces.ProductStatus;
using DataAccess.Interfaces.ProductType;
using DataAccess.Interfaces.User;
using DataAccess.Interfaces.Zone;
using Ninject;
using Service;
using Service.Interface;
using System.Security.Cryptography;
using UserService;
using UserService.Interface;

namespace InventoryManagement
{
    public class NinjectContainer
    {
        public static IKernel Container = new StandardKernel();

        static NinjectContainer()
        {

            #region ServiceBind

            Container.Bind<IInventoryService>().To<InventoryService>();
            Container.Bind<IProductService>().To<ProductService>();
            Container.Bind<IZoneService>().To<ZoneService>();
            Container.Bind<IOwnerService>().To<OwnerService>();
            
            #endregion ServiceBind

            #region DataAccessBind

            Container.Bind<IUserDao>().To<UserDao>();
            Container.Bind<IInventoryDao>().To<InventoryDao>();
            Container.Bind<IInventoryEventTypeDao>().To<InventoryEventTypeDao>();
            Container.Bind<IInventoryStatusDao>().To<InventoryStatusDao>();
            Container.Bind<IOwnerDao>().To<OwnerDao>();
            Container.Bind<IProductDao>().To<ProductDao>();
            Container.Bind<IProductStatusDao>().To<ProductStatusDao>();
            Container.Bind<IProductTypeDao>().To<ProductTypeDao>();
            Container.Bind<IZoneDao>().To<ZoneDao>();

            #endregion DataAccessBind

            #region UserServiceBind

            Container.Bind<IUserService>().To<UserService.UserService>();
            Container.Bind<IHashService>().To<HashService>();
            Container.Bind<HashAlgorithm>().To<SHA384Managed>();
            Container.Bind<RandomNumberGenerator>().To<RNGCryptoServiceProvider>();

            #endregion UserServiceBind
        }
    }
}
