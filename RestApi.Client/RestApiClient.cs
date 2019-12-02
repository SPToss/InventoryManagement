using Newtonsoft.Json;
using RestApi.Client.Dto.Owner;
using RestApi.Client.Dto.Product;
using RestApi.Client.Dto.Request.Inventory;
using RestApi.Client.Dto.Request.Product;
using RestApi.Client.Dto.Request.User;
using RestApi.Client.Dto.Response.Inventory;
using RestApi.Client.Dto.Response.Product;
using RestApi.Client.Dto.Response.User;
using RestApi.Client.Dto.Response.Zone;
using RestApi.Client.Interface;
using RestSharp;
using System.Collections.Generic;

namespace RestApi.Client
{
    public class RestApiClient : IRestApiClient
    {
        private string _baseUrl = RestApi.Client.Properties.Resources.RestApiAddress;

        #region User

        public UserResponseDto Authorize(UserAuthorizeRequestDto userAuthorizeRequestDto)
        {
            return CallRestApiWithPost<UserResponseDto, UserAuthorizeRequestDto>("/User/Authorize/", userAuthorizeRequestDto);
        }

        public List<UserResponseDto> GetAllActiveUsers()
        {
            return CallRestApiWithPost<List<UserResponseDto>>("/User/GetAllActiveUsers/");
        }
        public void UpdateUser(UserUpdateRequest request)
        {
            CallRestApiWithPost("/User/UpdateUser/", request);
        }

        #endregion User

        #region Product

        public List<ProductSearchTypeDto> GetAllProductSearchTypes()
        {
            return CallRestApiWithPost<List<ProductSearchTypeDto>>("/Product/GetAllActiveProductSearches/");
        }

        public List<ProductDto> GetProductBySearchId(GetProductBySearchTypeDto getProductBySearchTypeDto)
        {
            return CallRestApiWithPost<List<ProductDto>, GetProductBySearchTypeDto>("/Product/GetProductBySearchId/", getProductBySearchTypeDto);
        }

        public List<ProductTypeDto> GetAllProductTypes()
        {
            return CallRestApiWithPost<List<ProductTypeDto>>("/Product/GetAllActiveProductTypes/");
        }

        public List<ProductStatusDto> GetAllProductStatuses()
        {
            return CallRestApiWithPost<List<ProductStatusDto>>("/Product/GetAllActiveProductStatuses/");
        }

        public void SaveOrUpdateProduct(ProductDto product)
        {
            CallRestApiWithPost("/Product/InserOrUpdateModel/", product);
        }

        public void RemoveProduct(int productId)
        {
            CallRestApiWithPost("/Product/DeleteProduct/", new DeleteProductRequestDto { ProductId = productId } );
        }

        #endregion Product

        #region Owner 

        public List<OwnerDto> GetAllOwners()
        {
            return CallRestApiWithPost<List<OwnerDto>>("/Owner/GetAllOwners/");
        }

        #endregion Owner

        #region Zone

        public List<ZoneDto> GetAllZones()
        {
            return CallRestApiWithPost<List<ZoneDto>>("/Zone/GetAllZones/");
        }

        #endregion Zone

        #region Inventory

        public List<InventorySearchTypeDto> GetAllInvenotoyrSearches()
        {
            return CallRestApiWithPost<List<InventorySearchTypeDto>>("/Inventory/GetAllActiveInventoryStatuses/");
        }

        public List<InventoryDto> GetInventorysBySearchId(GetInventoryBySearch getInventoryBySearch)
        {
            return CallRestApiWithPost<List<InventoryDto>, GetInventoryBySearch>("/Inventory/GetProductBySearchId/", getInventoryBySearch);
        }

        public void AddNewInventory(string description, int zoneId)
        {
            CallRestApiWithPost("/Inventory/AddNewInventory/", new NewInventoryRequestDto
            {
                Description = description,
                ZoneId = zoneId
            });
        }

        public void ChangeInventoryStatus(int statusId, int inventoryId)
        {
            CallRestApiWithPost("/Inventory/ChangeInventoryStatus/", new UpdateInventoryDto
            {
                InventoryId = inventoryId,
                NewStatusId = statusId
            });
        }

        public InventoryReportDto GetReport(GetReportDto report)
        {
            var result =  CallRestApiWithPost<ParsedInventoryReport, GetReportDto>("/Inventory/GetReport/", report);

            return JsonConvert.DeserializeObject<InventoryReportDto>(result.Raport);
        }

        #endregion Inventory


        public void SetDefaultUrl(string url)
        {
            _baseUrl = url;
        }

        private T CallRestApiWithPost<T,Tu>(string address, Tu param)
        {
            var client = new RestClient(_baseUrl);

            var request = new RestRequest(address, Method.POST);

            var json = JsonConvert.SerializeObject(param);

            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        private void CallRestApiWithPost<Tu>(string address, Tu param)
        {
            var client = new RestClient(_baseUrl);

            var request = new RestRequest(address, Method.POST);

            var json = JsonConvert.SerializeObject(param);

            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            client.Execute(request);

        }

        private T CallRestApiWithPost<T>(string address)
        {
            var client = new RestClient(_baseUrl);

            var request = new RestRequest(address, Method.POST);
            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        private void CallRestApiWithPost(string address)
        {
            var client = new RestClient(_baseUrl);

            var request = new RestRequest(address, Method.POST);
            client.Execute(request);
        }


    }
}
