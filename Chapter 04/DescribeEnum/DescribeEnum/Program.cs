using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescribeEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            //fiddling
            EmpType emp = EmpType.Contractor;
            Console.WriteLine("EmpType uses {0} for storage (typeof on class)", Enum.GetUnderlyingType(typeof(EmpType)));
            Console.WriteLine("EmpType uses {0} for storage (.GetType on instance)" ,Enum.GetUnderlyingType(emp.GetType()));

            Console.WriteLine("Enum vital statistics");
            EvaluateEnum(emp);
            EvaluateEnum(DayOfWeek.Monday);
            EvaluateEnum(ConsoleColor.Black);

            Console.ReadLine();
        }

        private static void EvaluateEnum(System.Enum e)
        {
            Console.WriteLine("=> Information about {0}", e.GetType().Name);

            Console.WriteLine("Underlying storage type: {0}", Enum.GetUnderlyingType(e.GetType()));
            //Print name=value pairs
            Array enumData = Enum.GetValues(e.GetType());
            Console.WriteLine("{0} members", enumData.Length);
            foreach (System.Enum item in enumData)
            {
                Console.WriteLine("{0} = {0:D}", item);
            }
            Console.WriteLine();
        }

        //custom enum type for experimenting with
        enum EmpType : byte
        {
            Manager = 10,
            Grunt = 1,
            Contractor = 100,
            VicePresident = 9
        }
    }
}
