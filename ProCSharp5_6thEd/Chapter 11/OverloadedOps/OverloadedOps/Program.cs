namespace OverloadedOps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            Point point1 = new Point(100, 100);
            Point point2 = new Point(40, 40);

            Console.WriteLine("P1: {0}", point1);
            Console.WriteLine("P2: {0}", point2);
            Console.WriteLine();

            // add the points
            Console.WriteLine("P1 + P2 = {0}", point1 + point2);

            // subtract the points
            Console.WriteLine("P1 - P2 = {0}", point1 - point2);

            // a 'bigger' point
            Console.WriteLine("P1 + 9 = {0}", point1 + 9);

            // a 'smaller' point
            Console.WriteLine("9 - P1 (!?) = {0}", 9 - point1);

            Point point3 = point1;

            point3 += point2;
            Console.WriteLine("shorthand adding p3 += p2: {0}", point3);

            Console.ReadLine();
        }
    }
}
