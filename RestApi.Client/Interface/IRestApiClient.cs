using RestApi.Client.Dto.Request.Product;
using RestApi.Client.Dto.Request.User;
using RestApi.Client.Dto.Response.Product;
using RestApi.Client.Dto.Response.User;
using System.Collections.Generic;

namespace RestApi.Client.Interface
{
    public interface IRestApiClient
    {
        #region User

        UserResponseDto Authorize(UserAuthorizeRequestDto userAuthorizeRequestDto);

        #endregion User


        #region Product

        List<ProductSearchTypeDto> GetAllProductSearchTypes();

        List<ProductDto> GetProductBySearchId(GetProductBySearchTypeDto getProductBySearchTypeDto);
        #endregion Product
    }
}