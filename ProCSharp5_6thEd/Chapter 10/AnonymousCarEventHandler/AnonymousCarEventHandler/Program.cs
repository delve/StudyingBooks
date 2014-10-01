using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousCarEventHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Anonymous methods");

            int aboutToBlowCounter = 0;
            
            Car c1 = new Car("Mystery Machine", 100, 10);

            //register event handlers as anon methods
            c1.AboutToBlow += delegate
            {
                Console.WriteLine("Approaching ludicrous speed!");
                ++aboutToBlowCounter;
            };
            
            c1.AboutToBlow += delegate(object sender, Car.CarEventArgs e)
            {
                Console.WriteLine("Message from car: {0}", e.msg);
            };

            c1.Exploded += delegate(object sender, Car.CarEventArgs e)
            {
                Console.WriteLine("Better call a tow truck: {0}", e.msg);
            };

            for (int i = 0; i < 12; i++)
            {
                c1.Accelerate(10);
            }

            Console.WriteLine("Nearly blew up {0} times.", aboutToBlowCounter);
            Console.ReadLine();
        }
    }
}
