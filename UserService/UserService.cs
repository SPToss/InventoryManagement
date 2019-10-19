using DataAccess.Interfaces.User;
using DataTransfer.User;
using System;
using UserService.Interface;

namespace UserService
{
    public sealed class UserService : IUserService
    {
        private readonly IHashService _hashService;

        private readonly IUserDao _userDao;

        public UserService(IHashService hashService, IUserDao userDao)
        {
            _hashService = hashService;
            _userDao = userDao;
        }

        public bool Authorize(string login, string password)
        {
            UserHistoryDto historyItem = null;
            bool isSucces = false;


            try // TODO Introduce custom exception 
            {
                if (UserContext.IsUserLoggedIn())
                {
                    throw new Exception("User is already logged");
                }

                if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                {
                    throw new Exception("Empty login atempt");
                }

                var salt = _userDao.GetSaltForUser(login);

                if (string.IsNullOrWhiteSpace(salt))
                {
                    throw new Exception("Invalid user"); 
                }

                var hash = _hashService.HashString(password, salt);

                 var user = _userDao.Authorize(new UserCredential
                {

                    Hash = hash.hash,
                    Login = login
                });

                if(user == null)
                {
                    throw new Exception("Invalid user");
                }

                UserContext.SetUser(User.FromDto(user));

                historyItem = new UserHistoryDto
                {
                    UserId = user.UserId,
                    EventDate = DateTime.Now,
                    Description = "User Authorized",
                    UserHistoryTypeId = 1
                };

                isSucces = true;
            }
            catch (Exception e)
            {
                historyItem = new UserHistoryDto
                {
                    UserId = 0,
                    EventDate = DateTime.Now,
                    Description = e.Message,
                    UserHistoryTypeId = 2
                };

                isSucces = false;
            }
            finally
            {
                _userDao.SaveUserHistoryEvent(historyItem);
            }

            return isSucces;
        }
    }
}
