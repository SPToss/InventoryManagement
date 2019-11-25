using System.Collections.Generic;
using System.Linq;
using InventoryManagement;
using Microsoft.AspNetCore.Mvc;
using Ninject;
using RestApi.Models.Zone;
using Service.Interface;

namespace RestApi.Controllers
{
    public class ZoneController : InventoryManagementApiBase
    {
        private IZoneService _zoneService;

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(List<ZoneModel>))]
        public ActionResult<List<ZoneModel>> GetAllZones()
        {
            var results = _zoneService.GetAllActiveZones();
            return Ok(results.Select(ZoneModel.FromDomain));
        }

        protected override void InitializeController()
        {
            _zoneService = NinjectContainer.Container.Get<IZoneService>();
        }
    }
}