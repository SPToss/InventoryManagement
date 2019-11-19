using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class InventoryManagementApiBase : ControllerBase
    {
        protected InventoryManagementApiBase()
        {
            InitializeController();
        }

        protected abstract void InitializeController();
    }
}
