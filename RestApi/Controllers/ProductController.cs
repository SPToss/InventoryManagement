﻿using DataTransfer.Api.Request.Product;
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
            var t = results.Select(ProductModel.FormDomain);
            return Ok(t);
        }

        protected override void InitializeController()
        {
            _productService = NinjectContainer.Container.Get<IProductService>();
        }
    }
}