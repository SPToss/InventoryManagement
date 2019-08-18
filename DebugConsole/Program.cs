
using DataAccess.Implementation;
using Domain.Types;
using System;

namespace DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var t = new ProductType(new ProductTypeDao()).GetById(4);
            Console.WriteLine("Hello World!");
        }
    }
}