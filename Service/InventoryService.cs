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
        private readonly IProductService _productService;
        private readonly IZoneService _zoneService;

        public InventoryService(
            IInventoryDao inventoryDao,
            IProductDao productDao,
            IProductService productService,
            IZoneService zoneService)
        {
            _inventoryDao = inventoryDao;
            _productDao = productDao;
            _productService = productService;
            _zoneService = zoneService;
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

        public void CreateNewInventory(NewInventoryRequestDto newInventoryRequestDto)
        {
            InventoryEventDto eventDto = null;
            try
            {
                _inventoryDao.InsertInventory(new InventoryDto
                {
                    Description = newInventoryRequestDto.Description,
                    StartDate = DateTime.Now,
                    StatusId = 1,
                    ZoneId = newInventoryRequestDto.ZoneId
                });

                eventDto = new InventoryEventDto
                {
                    Description = "New inventory created",
                    EventDate = DateTime.Now,
                    EventType = (int)InventoryEventTypeEnum.InventoryCreated,
                    InventoryId = 0
                };
            }
            catch(Exception e)
            {
                eventDto = new InventoryEventDto
                {
                    Description = e.Message,
                    EventDate = DateTime.Now,
                    InventoryId = 0,
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

            var inventorys = inventorysDto.Select(Inventory.FromDto).ToList();

            foreach(var inventory in inventorys)
            {
                var products = _inventoryDao.GetAllInventoryProductsByInventoryId(inventory.Id).Select(InventoryProduct.FormDto).ToList();

                inventory.Products = products;
            }

            return inventorys;
        }

        public InventoryReportDto GetReport(int inventoryId)
        {
            return _inventoryDao.GetReportForInventory(inventoryId);
        }

        public void UpdateInventory(UpdateInventoryDto updateInventoryDto)
        {
            InventoryEventDto eventDto = null;
            try
            {
                var inventoryDto = _inventoryDao.GetInventoryById(updateInventoryDto.InventoryId);

                inventoryDto.StatusId = updateInventoryDto.NewStatusId;

                eventDto = new InventoryEventDto
                {
                    Description = "New inventory created",
                    EventDate = DateTime.Now,
                    EventType = (int)InventoryEventTypeEnum.InventoryStarted,
                    InventoryId = updateInventoryDto.InventoryId
                };

                if (updateInventoryDto.NewStatusId == 3)
                {
                    eventDto.EventType = (int)InventoryEventTypeEnum.InventoryEnded;
                    CreateReport(updateInventoryDto.InventoryId);
                }
                else if(updateInventoryDto.NewStatusId == 4)
                {
                    eventDto.EventType = (int)InventoryEventTypeEnum.InventoryCancelled;
                }

                _inventoryDao.UpdateInventory(inventoryDto);

                eventDto = new InventoryEventDto
                {
                    Description = "New inventory created",
                    EventDate = DateTime.Now,
                    EventType = (int)InventoryEventTypeEnum.InventoryStarted,
                    InventoryId = 0
                };
            }
            catch (Exception e)
            {
                eventDto = new InventoryEventDto
                {
                    Description = e.Message,
                    EventDate = DateTime.Now,
                    InventoryId = 0,
                    EventType = (int)InventoryEventTypeEnum.UnknownError
                };
            }
            finally
            {
                _inventoryDao.AddInventoryEvent(eventDto);
            }
        }

        private void CreateReport(int inventoryId)
        {
            var report = new InventoryReport();

            var inventory = Inventory.FromDto(_inventoryDao.GetInventoryById(inventoryId));

            report.Inventory = inventory;

            var inventoryProducts = _inventoryDao.GetAllInventoryProductsByInventoryId(inventoryId);

            var zones = _zoneService.GetAllChildZones(inventory.ZoneId);

            var productsTiedToZone = _productDao.GetAllActiveProductsForZones(zones.Select(x => x.ToDto()).ToList());


            foreach(var product in productsTiedToZone)
            {
                if(inventoryProducts.Any(x => x.ZoneId == product.ZoneId && x.ProductId == product.Id)){
                    report.ScannedItems.Add($"Product with id {product.Id} and description {product.Description} scanned correctly");
                }
                else if(inventoryProducts.Any(x => x.ZoneId != product.ZoneId && x.ProductId == product.Id))
                {
                    report.MovedItems.Add($"Product with id {product.Id} and description {product.Description} scanned in wrong zone. Scanned zone id {inventoryProducts.Where(x => x.ProductId == product.Id).First().ZoneId} but should be {product.ZoneId}");
                }
                else
                {
                    report.MissingItems.Add($"Product with id {product.Id} and description {product.Description} is missing");
                }
            }

            report.Info = $"Raport creaded : {DateTime.Now}, Inventory started {inventory.StartDate} ended {DateTime.Now},\n Items scanned: {report.ScannedItems.Count}, \n Items missing: {report.MissingItems.Count}, \n Items moved {report.MovedItems.Count}";

            _inventoryDao.InsertReport(report.ToDto());
        }
    }
}