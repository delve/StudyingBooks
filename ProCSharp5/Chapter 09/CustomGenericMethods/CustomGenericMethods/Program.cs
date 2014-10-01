using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenericMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            //swapping ints
            int a = 10, b = 30;
            Console.WriteLine("Preswap: a = {0}; b = {1}", a, b);
            Swap<int>(ref a, ref b);
            Console.WriteLine("Postswap: a = {0}; b = {1}", a, b);
            Console.WriteLine();

            //swapping strings
            string c = "Hello", d = "World";
            Console.WriteLine("Preswap: c = {0}; d = {1}", c, d);
            Swap<string>(ref c, ref d);
            Console.WriteLine("Postswap: c = {0}; d = {1}", c, d);
            Console.WriteLine();

            //swapping bools with compiler inferred type
            bool e = true, f = false;
            Console.WriteLine("Preswap: e = {0}; f = {1}", e, f);
            Swap(ref e, ref f);
            Console.WriteLine("Postswap: e = {0}; f = {1}", e, f);
            Console.WriteLine();

            Console.ReadLine();
        }

        static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine("You sent the Swap() method a {0}", typeof(T));
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
