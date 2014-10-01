namespace SimpleLambdaExpressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Main program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point
        /// </summary>
        /// <param name="args">from command line</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Fun with Lambda");
            TraditionalDelegateSyntax();
            AnonymousMethodSyntax();
            LambdaExpressionSyntax();

            Console.ReadLine();
        }

        private static void Helper(List<int> evens)
        {
            Console.WriteLine("Evens as follows:");
            foreach (int i in evens)
            {
                Console.Write("{0}\t", i.ToString());
            }

            Console.WriteLine();
        }

        #region Traditional Delegate Syntax
        private static void TraditionalDelegateSyntax()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            Predicate<int> callback = new Predicate<int>(IsEven);
            List<int> evens = list.FindAll(callback);

            Helper(evens);
        }

        private static bool IsEven(int i)
        {
            return (i % 2) == 0;
        }
        #endregion

        #region Anonymous Method Syntax
        private static void AnonymousMethodSyntax()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            List<int> evens = list.FindAll(delegate(int i)
            { 
                return (i % 2) == 0; 
            });

            Helper(evens);
        }
        #endregion

        #region Lambda llama
        private static void LambdaExpressionSyntax()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            List<int> evens = list.FindAll((i) =>
            {
                Console.WriteLine("Testing {0}", i);
                if ((i % 2) == 0)
                {
                    Console.WriteLine("Woot!");
                    return true;
                }
                else
                {
                    return false;
                }
            });

            Helper(evens);
        }
        #endregion
    }
}
