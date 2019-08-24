
using DataAccess.Implementation;
using Domain.Types;
using Service;
using System;

namespace DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            new InventoryService(new InventoryDao(), new ProductDao()).AddInventoryProduct(new Domain.InventoryProduct
            {
                InventoryId = 1,
                ProductId = 1,
                ScannedDate = DateTime.Now,
                ZoneId = 1
            });
            Console.WriteLine("Hello World!");
        }
    }
}