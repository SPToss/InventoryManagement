using Ninject;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Domain
{
    public class NinjectContainer
    {
        public static IKernel Container = new StandardKernel();

        static NinjectContainer()
        {
            Container.Bind<HashAlgorithm>().To<SHA384Managed>();
            
        }
    }
}
