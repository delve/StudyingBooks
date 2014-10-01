using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Whoop, generic stucts");
            //int points
            Point<int> p = new Point<int>(10, 10);
            Console.WriteLine(p);
            p.ResetPoint();
            Console.WriteLine("After reset: {0}", p);
            Console.WriteLine();

            //double points
            Point<double> p2 = new Point<double>(5.2, 3.6);
            Console.WriteLine(p2);
            p2.ResetPoint();
            Console.WriteLine("After reset: {0}", p2);

            Console.ReadLine();
        }
    }
}
