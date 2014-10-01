namespace ExtensionMethods
{
    using MyToyExtensionMethods;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Fun with extensions");

            // the int has new superpowers
            int myI = 123456789;
            myI.DisplayDefiningAssembly();
            Console.WriteLine("Int only powers: I = {0}; Reversed = {1}", myI.ReverseDigits(), myI.ToString());

            // new DataSet powers...
            System.Data.DataSet d = new System.Data.DataSet();
            d.DisplayDefiningAssembly();

            // and SoubdPlayer...
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            sp.DisplayDefiningAssembly();

            Console.ReadLine();
        }
    }
}
