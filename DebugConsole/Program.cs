
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
            var t = new ZoneService(new ZoneDao()).GetAllChildZones(3);
            Console.WriteLine("Hello World!");
        }
    }
}