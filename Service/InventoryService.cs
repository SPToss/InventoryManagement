using DataAccess.Interfaces.Inventory;
using DataAccess.Interfaces.Product;
using DataTransfer.Inventory;
using Domain;
using Service.Interface;
using System;

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
                        EventType = 7 // TODO Add this into static type object
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
                        EventType = 6 // TODO Add this into static type object
                    };
                }

                _inventoryDao.AddInventoryProduct(inventoryProduct.ToDto());

                eventDto = new InventoryEventDto
                {
                    Description = $"Product {inventoryProduct.ProductId} was added into inventory {inventoryProduct.InventoryId}",
                    EventDate = DateTime.Now,
                    InventoryId = inventoryProduct.InventoryId,
                    EventType = 5 // TODO Add this into static type object
                };

            }
            catch(Exception e)
            {
                eventDto = new InventoryEventDto
                {
                    Description = e.Message,
                    EventDate = DateTime.Now,
                    InventoryId = inventoryProduct.InventoryId,
                    EventType = 11 // TODO Add this into static type object
                };
            }
            finally
            {
                _inventoryDao.AddInventoryEvent(eventDto);
            }
        }

        
    }
}