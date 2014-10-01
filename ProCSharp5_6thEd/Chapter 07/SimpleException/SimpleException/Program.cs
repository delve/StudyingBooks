using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleException
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("let's drive a car!!!");
            Console.WriteLine("To the exception, jeeves. And step on it!");
            Car myCar = new Car("Zippy", 20);
            myCar.CrankTunes(true);

            try
            {
                for (int i = 0; i < 10; i++)
                    myCar.Accelerate(10);
            }
            catch (Exception e)
            {
                Console.WriteLine("\n******ERROR*******");
                Console.WriteLine("Method: {0}", e.TargetSite);
                Console.WriteLine("\tClass defining member: {0}", e.TargetSite.DeclaringType);
                Console.WriteLine("\tMember type: {0}", e.TargetSite.MemberType);
                Console.WriteLine("Message: {0}", e.Message);
                Console.WriteLine("Source: {0}", e.Source);
                Console.WriteLine("Stack (of !pancakes): {0}", e.StackTrace);
                Console.WriteLine("For assistance contact {0}", e.HelpLink);

                //some stuff in custom data for detail
                if (e.Data != null)
                {
                    Console.WriteLine("\nAdditional details:");
                    foreach (System.Collections.DictionaryEntry de in e.Data)
                    {
                        Console.WriteLine("-> {0}: {1}", de.Key, de.Value);
                    }
                }
            }

            //exception handled. processing returns to next statement
            Console.WriteLine("\n\nError processing (such as it is) complete");
            Console.ReadLine();
        }
    }
}
