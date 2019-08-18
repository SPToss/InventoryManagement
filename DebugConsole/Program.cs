
using DataAccess.Implementation;
using System;

namespace DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var t = new ProductDao().GetProductById(1);
            Console.WriteLine("Hello World!");
        }
    }
}