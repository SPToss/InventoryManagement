using System.Collections.Generic;
using System.Linq;
using InventoryManagement;
using Microsoft.AspNetCore.Mvc;
using Ninject;
using RestApi.Models.Owner;
using Service.Interface;

namespace RestApi.Controllers
{
    public class OwnerController : InventoryManagementApiBase
    {
        private  IOwnerService _ownerService;

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(List<OwnerModel>))]
        public ActionResult<List<OwnerModel>> GetAllOwners()
        {
            var results = _ownerService.GetAllActiveOwners();
            return Ok(results.Select(OwnerModel.FromDomain));
        }

        protected override void InitializeController()
        {
            _ownerService = NinjectContainer.Container.Get<IOwnerService>();
        }
    }
}