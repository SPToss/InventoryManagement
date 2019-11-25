using DataTransfer.Api.Request.Product;
using InventoryManagement;
using Microsoft.AspNetCore.Mvc;
using Ninject;
using RestApi.Models;
using RestApi.Models.Product;
using Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace RestApi.Controllers
{
    public class ProductController : InventoryManagementApiBase
    {
        private IProductService _productService;

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ProductSearchTypeModel))]
        public ActionResult<ProductSearchTypeModel> GetAllActiveProductSearches()
        {
            var productSearches = _productService.GetAllActiveProductSearches();

            return Ok(productSearches.Select(ProductSearchTypeModel.FromDomain));

        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(List<ProductModel>))]
        public ActionResult<List<ProductModel>> GetProductBySearchId([FromBody] GetProductBySearchTypeDto getProductBySearchTypeDto)
        {
            var results = _productService.GetProductsByCriteria(getProductBySearchTypeDto);
            return Ok(results.Select(ProductModel.FormDomain));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(List<ProductStatusModel>))]
        public ActionResult<List<ProductStatusModel>> GetAllActiveProductStatuses()
        {
            var results = _productService.GetAllProductStatus();
            return Ok(results.Select(ProductStatusModel.FormDto));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(List<ProductTypeModel>))]
        public ActionResult<List<ProductTypeModel>> GetAllActiveProductTypes()
        {
            var results = _productService.GetAllProductTypes();
            return Ok(results.Select(ProductTypeModel.FormDto));
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public ActionResult InserOrUpdateModel([FromBody] ProductModel model)
        {
            _productService.InserOrUpdateProduct(model.ToDomain());
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public ActionResult DeleteProduct([FromBody] DeleteProductRequestDto request)
        {
            _productService.DeleteProduct(request.ProductId);
            return Ok();
        }

        protected override void InitializeController()
        {
            _productService = NinjectContainer.Container.Get<IProductService>();
        }
    }
} 