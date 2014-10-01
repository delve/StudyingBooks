using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCSharpProgram
{
    class Program
    {
        static int Main(string[] args)
        {
            //display something to the user
            Console.WriteLine("Yay. A program.");
            Console.WriteLine("Helloooo Program.");
            Console.WriteLine();

            //process command arguments
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Arg{0}: {1}", i, args[i]);
            }

            //and to look at this function...
            foreach (string arg in System.Environment.GetCommandLineArgs())
            {
                Console.WriteLine("Arg: {0}", arg);
            }

            //playing with a Environment information methods
            ShowEnvironmentDetails();

            //wait for the 'enter' key before dying
            Console.ReadLine();

            //return some int value
            return 65535;
        }

        private static void ShowEnvironmentDetails()
        {
            //display the drives on the processing machine and other interesting details
            Console.WriteLine("OS: {0}", Environment.OSVersion);
            Console.WriteLine("Number of processors: {0}", Environment.ProcessorCount);
            Console.WriteLine(".NET version: {0}", Environment.Version);
            foreach (string drive in Environment.GetLogicalDrives())
            {
                Console.WriteLine("Drive: {0}", drive);
            }
            Console.WriteLine("You are: {0}/{1}", Environment.UserDomainName, Environment.UserName);
        }

        
    }
}
