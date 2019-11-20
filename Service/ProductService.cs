using System.Collections.Generic;
using System.Linq;
using DataAccess.Interfaces.Product;
using DataTransfer.Api.Request.Product;
using DataTransfer.Product;
using Domain;
using Domain.Types;
using Service.Interface;

namespace Service
{
    public class ProductService : IProductService
    {

        private readonly IProductDao _productDao;
        private readonly IZoneService _zoneService;
        private readonly IOwnerService _ownerService;

        public ProductService(IProductDao productDao, IZoneService zoneService, IOwnerService ownerService)
        {
            _productDao = productDao;
            _zoneService = zoneService;
            _ownerService = ownerService;
        }

        public List<ProductSearchType> GetAllActiveProductSearches()
        {
            IEnumerable<ProductSearchTypeDto> productSearchTypeDtos = _productDao.GetAllActiveProductSearches();

            return productSearchTypeDtos.Select(ProductSearchType.FromDto).ToList();
        }

        public Product GetProductById(int id)
        {
            ProductDto productDto = _productDao.GetProductById(id);

            return Product.FromDto(productDto);
        }

        public List<Product> GetProductsByCriteria(GetProductBySearchTypeDto getProductBySearchTypeDto)
        {
            IEnumerable<ProductDto> productDtos = new List<ProductDto>();

            if(getProductBySearchTypeDto == null)
            {
                return new List<Product>();
            }

            switch (getProductBySearchTypeDto.ProductSearchTypeId)
            {
                case 1:
                    productDtos = _productDao.GetAllProducts();
                    break;
                case 2:
                    productDtos = _productDao.GetAllActiveProductsWithStatus(new ProductStatus().Active.Id);
                    break;
                case 3:
                    if(getProductBySearchTypeDto.ExtraParams == null || !getProductBySearchTypeDto.ExtraParams.ContainsKey("ZoneId"))
                    {
                        productDtos = new List<ProductDto>();
                        break;
                    }

                    var zones = _zoneService.GetAllChildZones(int.Parse(getProductBySearchTypeDto.ExtraParams["ZoneId"]));

                    productDtos = _productDao.GetAllActiveProductsForZones(zones.Select(x => x.ToDto()).ToList());
                    break;
                case 4:
                    productDtos = _productDao.GetAllActiveProductsWithStatus(new ProductStatus().Missing.Id);
                    break;
                default:
                    productDtos = new List<ProductDto>();
                    break;
            }

            List<Product> products = new List<Product>();

            foreach(var productDto in productDtos)
            {
                Product product = Product.FromDto(productDto);

                product.Zone = _zoneService.GetZoneById(productDto.ZoneId);
                product.Owner = _ownerService.GetOwnerById(productDto.OwnerId);

                products.Add(product);
            }

            return products;
        }
    }
}