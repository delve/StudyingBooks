using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICloneablePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Interfaces");

            //these all implement the ICloneable interface
            string myStr = "Hello";
            OperatingSystem unixOS = new OperatingSystem(PlatformID.Unix, new Version());
            System.Data.SqlClient.SqlConnection sqlCnn = new System.Data.SqlClient.SqlConnection();

            //So can all be cloned
            CloneMe(myStr);
            CloneMe(unixOS);
            CloneMe(sqlCnn);

            Console.ReadLine();
        }

        private static void CloneMe(ICloneable c)
        {
            object theClone = c.Clone();
            Console.WriteLine("The clone is a {0}", theClone.GetType().Name);
        }
    }
}
