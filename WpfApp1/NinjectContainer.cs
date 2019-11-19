using Ninject;
using RestApi.Client;
using RestApi.Client.Interface;

namespace InventoryManagement
{
    public class NinjectContainer
    {
        public static IKernel Container = new StandardKernel();

        static NinjectContainer()
        {

            #region RestApi.Client Bind

            Container.Bind<IRestApiClient>().To<RestApiClient>();

            #endregion RestApi.Client Bind
        }
    }
}