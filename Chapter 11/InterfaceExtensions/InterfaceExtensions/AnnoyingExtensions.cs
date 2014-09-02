namespace InterfaceExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

     public static class AnnoyingExtensions
    {
         public static void PrintDataAndBeep(this System.Collections.IEnumerable iterator)
         {
             foreach (var item in iterator)
             {
                 Console.WriteLine(item);
                 Console.Beep();
             }
         }
    }
}
