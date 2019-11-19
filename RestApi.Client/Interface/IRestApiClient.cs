using RestApi.Client.Dto.Request.User;
using RestApi.Client.Dto.Response.User;

namespace RestApi.Client.Interface
{
    public interface IRestApiClient
    {
        #region User

        UserResponseDto Authorize(UserAuthorizeRequestDto userAuthorizeRequestDto);

        #endregion User


        #region Product
        #endregion Product
    }
}