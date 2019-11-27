using DataAccess.Interfaces.Inventory;
using DataAccess.Interfaces.Product;
using DataTransfer.Api.Request.Inventory;
using DataTransfer.Inventory;
using Domain;
using Domain.Types;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryDao _inventoryDao;
        private readonly IProductDao _productDao;

        public InventoryService(
            IInventoryDao inventoryDao,
            IProductDao productDao)
        {
            _inventoryDao = inventoryDao;
            _productDao = productDao;
        }

        public void AddInventoryProduct(InventoryProduct inventoryProduct)
        {
            InventoryEventDto eventDto = null;
            try
            {
                var productDto = _productDao.GetProductById(inventoryProduct.ProductId);

                if (productDto == null)
                {
                    eventDto = new InventoryEventDto
                    {
                        Description = $"Product {inventoryProduct.ProductId} does not exist in Product table",
                        EventDate = DateTime.Now,
                        InventoryId = inventoryProduct.InventoryId,
                        EventType = (int)InventoryEventTypeEnum.NotExisitingProductScanned
                    };

                    return;
                }

                var inventoryProductDto = _inventoryDao.GetInventoryProductByProductId(inventoryProduct.ProductId);

                if(inventoryProductDto != null)
                {
                    eventDto = new InventoryEventDto
                    {
                        Description = $"Product {inventoryProduct.ProductId} was already scanned",
                        EventDate = DateTime.Now,
                        InventoryId = inventoryProduct.InventoryId,
                        EventType = (int)InventoryEventTypeEnum.DuplicateScanned
                    };
                }

                _inventoryDao.AddInventoryProduct(inventoryProduct.ToDto());

                eventDto = new InventoryEventDto
                {
                    Description = $"Product {inventoryProduct.ProductId} was added into inventory {inventoryProduct.InventoryId}",
                    EventDate = DateTime.Now,
                    InventoryId = inventoryProduct.InventoryId,
                    EventType = (int)InventoryEventTypeEnum.ProductAdded
                };

            }
            catch(Exception e)
            {
                eventDto = new InventoryEventDto
                {
                    Description = e.Message,
                    EventDate = DateTime.Now,
                    InventoryId = inventoryProduct.InventoryId,
                    EventType = (int)InventoryEventTypeEnum.UnknownError
                };
            }
            finally
            {
                _inventoryDao.AddInventoryEvent(eventDto);
            }
        }

        public IEnumerable<InventorySearchDto> GetAllInventorySerarches()
        {
            return _inventoryDao.GetAllActiveInventorySearch();
        }

        public IEnumerable<Inventory> GetInventoryBySearch(GetInventoryBySearch getInventoryBySearch)
        {
            int? statusId = null;

            switch (getInventoryBySearch.SearchId)
            {
                case 1:
                    statusId = null;
                    break;
                case 2:
                    statusId = 2;
                    break;
                case 3:
                    statusId = 3;
                    break;
                case 4:
                    statusId = 1;
                    break;
                case 5:
                    statusId = 4;
                    break;
                default:
                    statusId = null;
                    break;
            }

            var inventorysDto = _inventoryDao.GetAllInventoriesByStatus(statusId);

            var inventorys = inventorysDto.Select(Inventory.FromDto);

            foreach(var inventory in inventorys)
            {
                var products = _inventoryDao.GetAllInventoryProductsByInventoryId(inventory.Id).Select(InventoryProduct.FormDto);

                inventory.Products = products.ToList() ;
            }

            return inventorys;
        }
    }
}