using RestApi.Client.Dto.Response.User;

namespace RestApi.Client.Dto.Request.User
{
    public class UserUpdateRequest
    {
        public UserResponseDto User { get; set; }

        public string Param { get; set; }
    }
}
