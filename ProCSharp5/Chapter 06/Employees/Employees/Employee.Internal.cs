using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    partial class Employee
    {
        //field data
        private string empName;
        private int empID;
        private float currPay;
        private int empAge;
        private string empSSN;

        protected BenefitPackage empBenefits = new BenefitPackage();
        
        //CTORs
        public Employee() { }
        public Employee(string name, int id, float pay)
            : this(name, 0, id, pay, "unknown") { Console.WriteLine("Age defaulted to zero, SSN defaulted to unknown"); }

        public Employee(string name, int age, int id, float pay, string SSN)
        {
            Name = name;
            ID = id;
            Age = age;
            Pay = pay;
            SetSSN = SSN;
        }

    }
}
