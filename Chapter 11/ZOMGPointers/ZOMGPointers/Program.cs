namespace ZOMGPointers
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
            /*
            PrintValueAndAddress();

            Swapping();

            UsePointerToPoint();

             UnsafeStackAlloc();

            PinnedPointer();
            */

            SizeOfOperator();

            Console.ReadLine();
        }

        public static unsafe void SizeOfOperator()
        {
            Console.WriteLine("-------------Sizes-------------");
            Console.WriteLine("short: {0}", sizeof(short));
            Console.WriteLine("int: {0}",sizeof(int));
            Console.WriteLine("long: {0}",sizeof(long));
            Console.WriteLine("bool: {0}",sizeof(bool));
            Console.WriteLine("char: {0}", sizeof(char));
            Console.WriteLine("Point: {0}", sizeof(Point));
        }

        public static unsafe void PinnedPointer()
        {
            // pin a ref (managed) variable in order to point at it
            PointRef pt = new PointRef();
            pt.X = 5;
            pt.Y = 6;

            // fix pt to avoid moving or garbage collection
            fixed (int* pX=&pt.X)
            {
                *pX = 8;
            }

            // outside of fixed scope, pt is now unpinned and can be moved or collected
            Console.WriteLine("Point is: {0}", pt);
        }

        public static unsafe void UnsafeStackAlloc()
        {
            char* p = stackalloc char[256];
            for (int k = 0; k < 256; k++)
            {
                p[k] = (char)k;
            }

            Console.WriteLine("Array address: {0:X}", (int)p);
        }

        public static unsafe void UsePointerToPoint()
        {
            // Access members via pointer
            Point point;
            Point* p = &point;
            p->X = 100;
            p->Y = 200;
            Console.WriteLine(p->ToString());

            // Access members via pointer indirection
            Point point2;
            Point* p2 = &point2;
            (*p2).X = 100;
            (*p2).Y = 200;
            Console.WriteLine((*p2).ToString());
        }

        public static void Swapping()
        {
            // swapping
            int i = 10, j = 20;
            Console.WriteLine("Safe Swap: {0}|{1}", i, j);
            SafeSwap(ref i, ref j);
            Console.WriteLine("Safe Swap: {0}|{1}", i, j);

            Console.WriteLine("Unsafeswap: {0}|{1}", i, j);
            unsafe
            {
                UnsafeSwap(&i, &j);
            }

            Console.WriteLine("Unsafeswap: {0}|{1}", i, j);
        }

        public static unsafe void PrintValueAndAddress()
        {
            int myInt;

            // define a pointer to an int and assign it the address of myInt
            int* iptrMyInt = &myInt;

            // assign a value via pointer indirection
            *iptrMyInt = 123;

            // print some info
            Console.WriteLine("Value of myInt {0}", myInt);
            Console.WriteLine("Addressof iptrMyInt         : {0:X}", (int)&iptrMyInt);
            Console.WriteLine("Addressof myInt from pointer: {0:X}", (int)iptrMyInt);
            Console.WriteLine("Addressof myInt from &      : {0:X}", (int)&myInt);
        }

        public static unsafe void UnsafeSwap(int* i, int* j)
        {
            int temp = *i;
            *i = *j;
            *j = temp;
        }

        public static void SafeSwap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }

        public struct Point
        {
            public int X;
            public int Y;

            public override string ToString()
            {
                return string.Format("[{0}, {1}]", this.X, this.Y);
            }
        }
    }
}
