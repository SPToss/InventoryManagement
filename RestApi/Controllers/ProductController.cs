using DataAccess.Implementation;
using Domain;
using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using Service;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController()
        {
            InitateObjects();
        }

        [HttpGet("{id}")]
        public ActionResult<ProductModel> GetProductById(int id)
        {
            Product product = _productService.GetProductById(id);

            return ProductModel.FormDomain(product);
        }

        private void InitateObjects()
        {
            _productService = new ProductService(new ProductDao());
        }
    }
}