using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConsoleIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====Basic IO=====");
            GetUserData();
            FomratNumericalData();
            Console.ReadLine();
        }

        private static void FomratNumericalData()
        {
            int i = 99999;
            Console.WriteLine("The value {0} in various formats...", i);
            Console.WriteLine("c format: {0:c}", i);
            Console.WriteLine("d9 format: {0:d9}", i);
            Console.WriteLine("f3 format: {0:f3}", i);
            Console.WriteLine("n format {0:n}", i);
            Console.WriteLine("E format {0:E}", i);
            Console.WriteLine("e format {0:e}", i);
            Console.WriteLine("X format {0:X}", i);
            Console.WriteLine("x format {0:x}", i);

        }

        private static void GetUserData()
        {
            //get name/age
            Console.Write("Please enter your name:");
            string userName = Console.ReadLine();
            Console.Write("Please enter your age:");
            string userAge = Console.ReadLine();

            //colors for kicks
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            //spit it back at them
            Console.WriteLine("Hello {0}! You are {1} years old.", userName,userAge);

            //fix the damned colors
            Console.ForegroundColor = prevColor;

        }


    }
}
