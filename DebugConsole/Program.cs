
using DataAccess.Implementation;
using Domain.Types;
using Service;
using System;
using UserService;

namespace DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HashService serice = new HashService();

            var testString = "ThisISSomeVerytImportanmtS2RiN!!G";


            var result1 = serice.HashString(testString);

            var result2 = serice.HashString(testString, result1.Item2);


            for(int i = 0; i< result1.Item1.Length; i++)
            {
                if(result1.Item1[i] != result2.Item1[i])
                {
                    var stop = "stop";
                }
            }

            var tt = result1.Equals(result2);
        }
    }
}