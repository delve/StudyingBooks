using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNameClash
{
    class Program
    {
        static void Main(string[] args)
        {
            Octogon octo = new Octogon();
            octo.Draw();
            ((IDrawToForm)octo).Draw();
            ((IDrawToMemory)octo).Draw();
//            ((IDrawToPrinter)octo).Draw();

            IDrawToPrinter itfPrinter = octo as IDrawToPrinter;
            if (octo != null)
            {
                ((IDrawToPrinter)octo).Draw();
            }

            Console.ReadLine();
        }
    }
}
