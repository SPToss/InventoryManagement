using DataAccess.Interfaces.User;
using DataTransfer.User;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<User> GetAllActiveUsers()
        {
            var usersDto = _userDao.GetAllActiveUsers();

            return usersDto.Select(User.FromDto);
        }

        public void UpdateUser(User user)
        {
            if(user.UserId == 0)
            {
                InsertNewUser(user);
            }
            else
            {
                UpdateExistingUser(user);
            }
        }

        private void UpdateExistingUser(User user)
        {
            var userDto = user.ToDto();

            if (!string.IsNullOrWhiteSpace(user.NewPaswd))
            {
                (string hash, string salt) hash = _hashService.HashString(user.NewPaswd);
                userDto.Hash = hash.hash;
                userDto.Salt = hash.salt;
            }

            _userDao.UpdateUser(userDto);

            _userDao.SaveUserHistoryEvent(new UserHistoryDto
            {
                Description = "User was updated",
                EventDate = DateTime.Now,
                UserHistoryTypeId = 4,
                UserId = userDto.UserId
            });
        }

        private void InsertNewUser(User user)
        {
            var userDto = user.ToDto();
            (string hash, string salt) hash = _hashService.HashString(user.NewPaswd);
            userDto.Hash = hash.hash;
            userDto.Salt = hash.salt;

            _userDao.InsertUser(userDto);

            _userDao.SaveUserHistoryEvent(new UserHistoryDto
            {
                Description = $"User {userDto.Login} was added",
                EventDate = DateTime.Now,
                UserHistoryTypeId = 5,
                UserId = null
            });
        }
    }
}