using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage carLot = new Garage();

            foreach (Car c in carLot)
            {
                Console.WriteLine("{0} is going {1}", c.PetName, c.CurrentSpeed);
            }

            IEnumerator i = carLot.GetEnumerator();
            i.MoveNext();
            Car curCar = (Car)i.Current;
            Console.WriteLine("{0} is going {1}", curCar.PetName, curCar.CurrentSpeed);


            Console.ReadLine();
        }
    }
}
