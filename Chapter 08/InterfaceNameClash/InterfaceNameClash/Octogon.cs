using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNameClash
{
    class Octogon : IDrawToForm, IDrawToMemory, IDrawToPrinter
    {
        public void Draw()
        {
            Console.WriteLine("Generically drawing shape");
        }

        void IDrawToForm.Draw()
        {
            Console.WriteLine("Drawing shape to FORM");
        }

        void IDrawToMemory.Draw()
        {
            Console.WriteLine("Drawing shape to MEMORY");
        }

        void IDrawToPrinter.Draw()
        {
            Console.WriteLine("Drawing shape to PRINTER");
        }
    }
}
