using DataTransfer.Api.Request.User;
using InventoryManagement;
using Microsoft.AspNetCore.Mvc;
using Ninject;
using RestApi.Models.User;
using UserService.Interface;

namespace RestApi.Controllers
{
    public class UserController : InventoryManagementApiBase
    {
        private IUserService _userService;

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(UserModel))]
        public ActionResult<UserModel> Authorize([FromBody] UserAuthorizeRequestDto userRequest)
        {
            var user = _userService.Authorize(userRequest.Login, userRequest.Password);

            return Ok(user);
        }

        protected override void InitializeController()
        {
            _userService = NinjectContainer.Container.Get<IUserService>();
        }
    }
}