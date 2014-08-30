using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegateMethodGroupConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car();

            //register a simple method name
            c1.RegisterWithCarEngine(CallMeHere);

            Console.WriteLine("Vroom vroom");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            //unregister the method
            c1.UnrgeisterWithCarEngine(CallMeHere);
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            Console.ReadLine();
        }

        private static void CallMeHere(string msgForCaller)
        {
            Console.WriteLine("Message from car: {0}", msgForCaller);
        }
    }
}
