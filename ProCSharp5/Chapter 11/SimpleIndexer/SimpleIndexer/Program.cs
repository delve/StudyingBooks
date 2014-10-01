namespace SimpleIndexer
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Indexer fiddling");

            UseCustomCollection();
            UseGenericList();

            Console.ReadLine();
        }

        private static void UseGenericList()
        {
            List<Person> myPeople = new List<Person>();

            myPeople.Add(new Person("Lisa", "Simpson", 9));
            myPeople.Add(new Person("Bart", "Simpson", 7));

            myPeople[0] = new Person("Maggie", "Simpson", 2);

            for (int i = 0; i < myPeople.Count; i++)
            {
                Console.WriteLine("[{0}] - {1} {2}, age {3}", i, myPeople[i].FirstName, myPeople[i].LastName, myPeople[i].Age);
                Console.WriteLine();
            }
        }

        private static void UseCustomCollection()
        {
            PersonCollection myPeople = new PersonCollection();

            myPeople[0] = new Person("Homer", "Simpson", 40);
            myPeople[1] = new Person("Marge", "Simpson", 38);
            myPeople[2] = new Person("Lisa", "Simpson", 9);
            myPeople[3] = new Person("Bart", "Simpson", 7);
            myPeople[4] = new Person("Maggie", "Simpson", 2);

            for (int i = 0; i < myPeople.Count; i++)
            {
                Console.WriteLine("Person #{0}", i);
                Console.WriteLine("Name: {0} {1}", myPeople[i].FirstName, myPeople[i].LastName);
                Console.WriteLine("Age: {0}", myPeople[i].Age);
                Console.WriteLine();
            }
        }
    }
}
