
using DataAccess.Implementation;
using Domain.Types;
using Service;
using System;
using System.Security.Cryptography;
using UserService;
using UserService.Interface;

namespace DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserService sevice = new UserService.UserService(new HashService(new SHA384Managed(), new RNGCryptoServiceProvider()), new UserDao());


            var t = sevice.Authorize("tesUser", "TestS9tring");
        }
    }
}