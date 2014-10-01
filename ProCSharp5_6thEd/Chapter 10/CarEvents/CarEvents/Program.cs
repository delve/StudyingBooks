using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car("Mystery Machine", 100, 10);
            c1.Exploded += CarExplodedHandler;
            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;

            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            c1.Exploded -= CarExplodedHandler;

            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            Console.ReadLine();
        }

        private static void CarExplodedHandler(object sender, Car.CarEventArgs e)
        {
            Console.WriteLine(e.msg);
            Console.WriteLine("Panic! Call for help!");
            Car c = sender as Car;
            if (c != null)
                Console.WriteLine(c.CallAAA());
        }

        private static void CarIsAlmostDoomed(object sender, Car.CarEventArgs e)
        {
            Console.WriteLine("Critical message from Car: {0}", e.msg);
        }

        private static void CarAboutToBlow(object sender, Car.CarEventArgs e)
        {
            Console.WriteLine(e.msg);
        }
    }
}
