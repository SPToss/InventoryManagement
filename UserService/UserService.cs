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

        public User Authorize(string login, string password)
        {
            UserHistoryDto historyItem = null;
            User user = null;

            try // TODO Introduce custom exception 
            {

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

                var userDto = _userDao.Authorize(new UserCredential
                {

                    Hash = hash.hash,
                    Login = login
                });

                if (userDto == null)
                {
                    throw new Exception("Invalid user");
                }


                historyItem = new UserHistoryDto
                {
                    UserId = userDto.UserId,
                    EventDate = DateTime.Now,
                    Description = "User Authorized",
                    UserHistoryTypeId = 1
                };

                user = User.FromDto(userDto);
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

                user = null;
            }
            finally
            {
                _userDao.SaveUserHistoryEvent(historyItem);
            }

            return user;
        }
    }
}