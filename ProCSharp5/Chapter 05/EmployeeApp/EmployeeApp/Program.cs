using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee joe = new Employee("Joe", 32, 0, (float)33.5, "123456789");
            joe.DisplayStatus();
            joe.Age++;
            joe.DisplayStatus();

            Console.ReadLine();
        }
    }
}
