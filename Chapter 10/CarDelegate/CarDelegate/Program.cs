using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Delegates as event enablers");

            Car c1 = new Car("NCC-1701", 10, 6);

            //register an extra handler
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
            //register a handler for events generated in the car's engine
            //store the delegate type instance as a variable for later de-registration
            Car.CarEngineHandler handler2 = new Car.CarEngineHandler(OnCarEngineEvent2);
            c1.RegisterWithCarEngine(handler2);

            //engage
            Console.WriteLine("Engaging warp 11");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(1);
                if(c1.CurrentSpeed>=c1.MaxSpeed)
                {
                    //Scotty gives up in despair
                    c1.UnrgeisterWithCarEngine(handler2);
                }
            }

            Console.ReadLine();
        }

        private static void OnCarEngineEvent2(string msgForCaller)
        {
            Console.WriteLine("Message repeats...");
            Console.WriteLine("~~ {0} ~~", msgForCaller.ToUpper());
        }

        private static void OnCarEngineEvent(string msgForCaller)
        {
            Console.WriteLine("Message from the engine room");
            Console.WriteLine("{0}", msgForCaller);
            Console.WriteLine("****************************");
        }
    }
}
