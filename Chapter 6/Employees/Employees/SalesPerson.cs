using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class SalesPerson : Employee
    {
        public int SalesNumber { get; set; }

        public SalesPerson() { }

        public SalesPerson(string fullName, int age, int empID, float currPay, string ssn, int numOfSales)
            : base(fullName, age, empID, currPay, ssn)
        {
            SalesNumber = numOfSales;
        }

    }

    sealed class PTSalesPerson : SalesPerson
    {
        public PTSalesPerson(string fullName, int age, int empID, float currPay, string ssn, int numOfSales)
            : base(fullName, age, empID, currPay, ssn, numOfSales)
        {
            //additional initialization
        }
    }
}
