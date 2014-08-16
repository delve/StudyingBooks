using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUtilityPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generic Header");

            TimeUtilClass.PrintDate();
            TimeUtilClass.PrintTime();

            Console.ReadLine();
        }
    }
    static class TimeUtilClass
    {
        public static void PrintTime()
        { Console.WriteLine(DateTime.Now.ToShortTimeString()); }

        public static void PrintDate()
        { Console.WriteLine(DateTime.Today.ToShortDateString()); }


    }
}
