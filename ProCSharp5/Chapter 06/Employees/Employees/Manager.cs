using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Manager : Employee
    {
        public int StockOptions { get; set; }

        public Manager() { }

        public Manager(string fullName, int age, int empID, float currPay, string ssn, int numOfOpts)
            :base(fullName,age,empID,currPay,ssn)
        {
            StockOptions = numOfOpts;
        }

    }
}
