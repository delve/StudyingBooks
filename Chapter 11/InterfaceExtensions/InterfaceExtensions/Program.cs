namespace InterfaceExtensions
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
            Console.WriteLine("Extending Interface Compatible types");

            // System.Array implements IEnumerable
            string[] data = { "just", "some", "random", "strings" };
            data.PrintDataAndBeep();

            Console.WriteLine();

            // List<T> implements IEnumerable
            List<int> myInts = new List<int>() { 10, 15, 20 };
            myInts.PrintDataAndBeep();

            Console.ReadLine();
        }
    }
}
