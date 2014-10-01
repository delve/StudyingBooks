using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFunctionDelegation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fiddling with Action<> and Func<>\n\n");

            //use Action<> to point to the display method
            Action<string, ConsoleColor, int> actionTarget = new Action<string, ConsoleColor, int>(DisplayMessage);

            actionTarget("Whoop! Things happening!", ConsoleColor.Yellow, 5);

            //setup Func<> vars
            Func<int, int, int> intFuncTarget = new Func<int, int, int>(Add);
            Func<int, int, string> strFuncTarget = new Func<int, int, string>(SumToString);
            //confirm return type for intFuncTarget
            int result = intFuncTarget(40, 40);
            Console.WriteLine("Type: {0};Val: {1}", result.GetType().ToString(), result);
            //confirm return type for StrFuncTarget (type safety of actionTarget)
            actionTarget(strFuncTarget(40, 45), ConsoleColor.Magenta, 2);

            Console.ReadLine();
        }

        //Action target
        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            //set text color
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;

            for (int i = 0; i < printCount; i++)
            {
                Console.WriteLine(msg);
            }

            //restore the color
            Console.ForegroundColor = prevColor;
        }

        //Func target
        static int Add(int x, int y)
        {
            return x + y;
        }

        //Another func target
        static string SumToString(int x, int y)
        {
            return (x + y).ToString();
        }
    }
}
