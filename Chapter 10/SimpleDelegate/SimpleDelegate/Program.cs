using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple delegate example");
            //create BinaryOp delegate pointing to Add
            BinaryOp b = new BinaryOp(SimpleMath.Add);

            //invoke the method via delegate
            Console.WriteLine("10 + 10 = {0}", b(10, 10));

            Console.WriteLine(b.ToString());
            Console.WriteLine(b.Method);
            Console.WriteLine(b.Target);

            SimpleMath math = new SimpleMath();

            b += math.Subtract;
            Console.WriteLine(b.ToString());
            Console.WriteLine(b.Method);
            Console.WriteLine(b.Target);
            Console.WriteLine("10 + 10 = {0}", b(10, 10));

            DisplayDelegateInfo(b);

            Console.ReadLine();
        }
        static void DisplayDelegateInfo(Delegate delobject)
        {
            //list the invocation list
            foreach (Delegate d in delobject.GetInvocationList())
            {
                Console.WriteLine("Method: {0}", d.Method);
                Console.WriteLine("Type Name: {0}", d.Target);

            }
        }
    }

    //delegate type that can point to any method signature int <meth> int int
    public delegate int BinaryOp(int x, int y);

    public class SimpleMath
    {
        public static int Add(int x, int y)
        { return x + y; }
        public int Subtract(int x, int y)
        { return x - y; }
        public static int SquareNumber(int x)
        { return x * x; }
    }

}
