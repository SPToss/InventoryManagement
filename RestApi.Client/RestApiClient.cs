using Newtonsoft.Json;
using RestApi.Client.Dto.Request.Product;
using RestApi.Client.Dto.Request.User;
using RestApi.Client.Dto.Response.Product;
using RestApi.Client.Dto.Response.User;
using RestApi.Client.Interface;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApi.Client
{
    public class RestApiClient : IRestApiClient
    {
        private readonly string _baseUrl = RestApi.Client.Properties.Resources.RestApiAddress;

        #region User

        public UserResponseDto Authorize(UserAuthorizeRequestDto userAuthorizeRequestDto)
        {
            return CallRestApiWithPost<UserResponseDto, UserAuthorizeRequestDto>("/User/Authorize/", userAuthorizeRequestDto);
        }

        #endregion User

        #region Product

        public List<ProductSearchTypeDto> GetAllProductSearchTypes()
        {
            return CallRestApiWithPost<List<ProductSearchTypeDto>, object>("/Product/GetAllActiveProductSearches/", null);
        }

        public List<ProductDto> GetProductBySearchId(GetProductBySearchTypeDto getProductBySearchTypeDto)
        {
            return CallRestApiWithPost<List<ProductDto>, GetProductBySearchTypeDto>("/Product/GetProductBySearchId/", getProductBySearchTypeDto);
        }

        #endregion Product

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
    }
}
