using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car("Rusty", 90);

            try
            {
                //trip exception(s)
                myCar.Accelerate(-1);
            }
            catch (CarIsDeadException e)
            {
                Console.WriteLine(e.Message);
            }
            //catch (ArgumentOutOfRangeException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            Console.ReadLine();
        }
    }
}
