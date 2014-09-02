namespace StringIndexer
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Person
    {
        public Person()
        {
        }

        public Person(string firstName, string lastName, int age)
        {
            this.Age = age;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Age { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0} {1}, Age: {2}", this.FirstName, this.LastName, this.Age);
        }
    }
}
