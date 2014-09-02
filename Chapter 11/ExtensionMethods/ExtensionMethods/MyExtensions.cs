namespace MyToyExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public static class MyExtensions
    {
        // allows any object to display it's defining assembly
        public static void DisplayDefiningAssembly(this object obj)
        {
            Console.WriteLine(
                "{0} lives in: {1}\n", 
                obj.GetType().Name, 
                Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }

        // allows any int to reverse its digits
        public static int ReverseDigits(this int i)
        {
            // translate int to char[] to get access to individual digits as chars
            char[] digits = i.ToString().ToCharArray();

            // reverse them
            Array.Reverse(digits);

            // back to string then return parsed to int
            string newDigits = new string(digits);
            return int.Parse(newDigits);
        }
    }
}
