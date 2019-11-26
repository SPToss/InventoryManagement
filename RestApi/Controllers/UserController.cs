using DataTransfer.Api.Request.User;
using InventoryManagement;
using Microsoft.AspNetCore.Mvc;
using Ninject;
using RestApi.Models.User;
using System.Collections.Generic;
using System.Linq;
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

            return Ok(UserModel.FromDomain(user));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(List<UserModel>))]
        public ActionResult<UserModel> GetAllActiveUsers()
        {
            var users = _userService.GetAllActiveUsers();

            return Ok(users.Select(UserModel.FromDomain));
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public ActionResult UpdateUser([FromBody] UserUpdateModel request)
        {
            var user = new UserService.User
            {
                Active = request.User.Active,
                IsAdmin = request.User.IsAdmin,
                LastName = request.User.LastName,
                Login = request.User.Login,
                Name = request.User.LastName,
                NewPaswd = request.Param,
                UserId = request.User.UserId,
                ZoneId = request.User.ZoneId
            };
            _userService.UpdateUser(user);

            return Ok();
        }

        protected override void InitializeController()
        {
            _userService = NinjectContainer.Container.Get<IUserService>();
        }
    }
}