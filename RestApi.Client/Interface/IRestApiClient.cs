using RestApi.Client.Dto.Owner;
using RestApi.Client.Dto.Product;
using RestApi.Client.Dto.Request.Product;
using RestApi.Client.Dto.Request.User;
using RestApi.Client.Dto.Response.Product;
using RestApi.Client.Dto.Response.User;
using RestApi.Client.Dto.Response.Zone;
using System.Collections.Generic;

namespace RestApi.Client.Interface
{
    public interface IRestApiClient
    {
        #region User

        UserResponseDto Authorize(UserAuthorizeRequestDto userAuthorizeRequestDto);

        List<UserResponseDto> GetAllActiveUsers();

        void UpdateUser(UserUpdateRequest request);
        #endregion User

        #region Product

        List<ProductSearchTypeDto> GetAllProductSearchTypes();

        List<ProductDto> GetProductBySearchId(GetProductBySearchTypeDto getProductBySearchTypeDto);

        List<ProductTypeDto> GetAllProductTypes();

        List<ProductStatusDto> GetAllProductStatuses();

        void SaveOrUpdateProduct(ProductDto product);

        void RemoveProduct(int productId);

        #endregion Product

        #region Owner 

        List<OwnerDto> GetAllOwners();

        #endregion Owner

        #region Zone

        List<ZoneDto> GetAllZones();

        #endregion Zone
    }
}