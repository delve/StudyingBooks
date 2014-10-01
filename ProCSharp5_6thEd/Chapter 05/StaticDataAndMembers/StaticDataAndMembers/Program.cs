using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDataAndMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("generic header line");
            Console.WriteLine("Interest Rate: {0}", SavingsAccount.InterestRate);

            SavingsAccount s1 = new SavingsAccount(50);
            Console.WriteLine("s1 will recieve interest of: {0}",s1.CalcInterest());
            SavingsAccount s2 = new SavingsAccount(100);
            Console.WriteLine("s2 will recieve interest of: {0}", s2.CalcInterest());
            SavingsAccount.InterestRate = .01;
            Console.WriteLine("New Interest Rate: {0}", SavingsAccount.InterestRate);
            Console.WriteLine("s1 will now recieve interest of: {0}", s1.CalcInterest());
            Console.WriteLine("s2 will now recieve interest of: {0}", s2.CalcInterest());

            SavingsAccount s3 = new SavingsAccount(1000.98);
            Console.WriteLine("Interest Rate: {0}", SavingsAccount.InterestRate);
            Console.WriteLine("s3 will recieve interest of: {0}", s3.CalcInterest());
            
            
            Console.ReadLine();
        }
    }

    class SavingsAccount
    {
        //instance level data
        public double currBalance;

        //static (class level) data
        public static double currInterestRate;
        //and its static property
        public static double InterestRate {
            get { return currInterestRate; }
            set { currInterestRate = value; }
        }

        static SavingsAccount()
        {
            Console.WriteLine("In static ctor");
            InterestRate = .04;
        }

        public SavingsAccount(double balance)
        {
            currBalance = balance;
        }

         public double CalcInterest()
        {
            return currBalance * InterestRate;
        }

        //This is really a bad idea. Doesn't seeem like a single instance should be able to adjust the interest rate for all instances.
        //   for something like a world-wide state this might be valid? but at that point there are probably still better ways
        //public double AdjustInterestRate(double delta)
        // {
        //     InterestRate = InterestRate + delta;
        //     return InterestRate;
        // }
    }
}
