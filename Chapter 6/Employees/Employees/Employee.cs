using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    partial class Employee
    {
        //properties
        public string Name {
            get { return empName; }
            set
            {
                if (value.Length > 15)
                    Console.WriteLine("Error, name too long");
                else
                    empName = value;
            }
        }

        public int ID {
            get { return empID; }
            set { empID = value; }
        }

        public float Pay {
            get { return currPay; }
            set { currPay = value; }
        }

        public int Age {
            get { return empAge; }
            set { empAge = value; }
        }

        public string SocialSecurityNumber{
            get { return empSSN; }
        }

        private string SetSSN {
            set { empSSN = value; }
        }

        public BenefitPackage Benefits {
            get { return empBenefits; }
            set { empBenefits = value; }
        }

        //methods
        public double GetBenefitCost()
        { return empBenefits.ComputePayDeduction(); }
        
        public void GiveBonus(float amount)
        {
            currPay += amount;
        }

        public void DisplayStatus()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("ID: {0}", ID);
            Console.WriteLine("age: {0}", Age);
            Console.WriteLine("Pay: {0}", Pay);
            Console.WriteLine("SSN: <redacted>");
        }
    }
}
