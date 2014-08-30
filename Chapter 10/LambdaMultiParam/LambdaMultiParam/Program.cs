namespace LambdaMultiParam
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
            // skipping delegate registration entirely, built it on event handling
            SimpleMath m = new SimpleMath();
            m.MathMessage += (sender, e) =>
                {
                    Console.WriteLine("Message: {0}\nResult: {1}", e.Msg, e.Result.ToString());
                };
            m.AddCheezBurgr(() => 
            { 
                return "I can haz?";
            });

            m.Add(1, 10);

            Console.ReadLine();
        }
    }
}
