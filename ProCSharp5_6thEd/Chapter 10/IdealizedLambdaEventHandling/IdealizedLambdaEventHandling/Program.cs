namespace IdealizedLambdaEventHandling
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
            Car c1 = new Car("Buggy", 100, 10);

            c1.AboutToBlow += (sender, e) =>
                {
                    Console.WriteLine(e.Msg);
                };
            c1.Exploded += (sender, e) => { Console.WriteLine(e.Msg); };

            Console.WriteLine("Vroom vroom");
            for (int i = 0; i < 10; i++)
            {
                c1.Accelerate(10);
            }

            Console.ReadLine();
        }
    }
}
