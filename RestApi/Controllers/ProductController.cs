using DataAccess.Implementation;
using Domain;
using InventoryManagement;
using Microsoft.AspNetCore.Mvc;
using Ninject;
using RestApi.Models;
using RestApi.Models.Product;
using Service;
using Service.Interface;
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

        protected override void InitializeController()
        {
            _productService = NinjectContainer.Container.Get<IProductService>();
        }
    }
}