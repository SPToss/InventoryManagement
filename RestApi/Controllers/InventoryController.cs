using DataTransfer.Api.Request.Inventory;
using DataTransfer.Inventory;
using InventoryManagement;
using Microsoft.AspNetCore.Mvc;
using Ninject;
using RestApi.Models.Inventory;
using Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace RestApi.Controllers
{
    public class InventoryController : InventoryManagementApiBase
    {
        private IInventoryService _inventoryService;

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(List<InventoryModel>))]
        public ActionResult<List<InventoryModel>> GetProductBySearchId([FromBody] GetInventoryBySearch getInventoryBySearch)
        {
            var results = _inventoryService.GetInventoryBySearch(getInventoryBySearch);
            return Ok(results.Select(InventoryModel.FromDomain));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(List<InventorySearchTypeModel>))]
        public ActionResult<List<InventorySearchTypeModel>> GetAllActiveInventoryStatuses()
        {
            var results = _inventoryService.GetAllInventorySerarches();
            return Ok(results.Select(InventorySearchTypeModel.FromDomain));
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public ActionResult ChangeInventoryStatus([FromBody] UpdateInventoryDto dto)
        {
            _inventoryService.UpdateInventory(dto);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public ActionResult AddNewInventory([FromBody] NewInventoryRequestDto dto)
        {
            _inventoryService.CreateNewInventory(dto);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(List<InventorySearchTypeModel>))]
        public ActionResult<InventoryReportDto> GetReport([FromBody] GetReportDto report)
        {
            var results = _inventoryService.GetReport(report.InventoryId);
            return Ok(results);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(AssingUserToInventoryDto))]
        public ActionResult AddUserToInventory([FromBody] AssingUserToInventoryDto request)
        {
            _inventoryService.SaveUserToInventory(request.UserId, request.InventoryId);
            return Ok(new AssingUserToInventoryDto { InventoryId = request.InventoryId, UserId = request.UserId });
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(List<InventoryWithUser>))]
        public ActionResult<InventoryWithUser> GetAllActiveInventorysWithUserTag([FromBody] InventoryAssignedToUser request)
        {
            var inventorys = _inventoryService.GetInventoryBySearch(new GetInventoryBySearch
            {
                SearchId = 2
            }).Select(InventoryWithUser.FromDomain).ToList();

            var inventoryToUser = _inventoryService.GetInventoryAssignedToUser(request.UserId);

            foreach (var inventory in inventorys)
            {
                if (inventory.Id == inventoryToUser)
                {
                    inventory.IsAssigned = true;
                }
            }
            return Ok(inventorys);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(AddItemRequestDto))]
        public ActionResult AddInventoryProduct([FromBody] AddItemRequestDto request)
        {
            _inventoryService.AddInventoryProduct(request);
            return Ok(request);
        }


        protected override void InitializeController()
        {
            _inventoryService = NinjectContainer.Container.Get<IInventoryService>();
        }
    }
}