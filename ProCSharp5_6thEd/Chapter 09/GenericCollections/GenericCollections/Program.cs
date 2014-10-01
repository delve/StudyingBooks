using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            //UseGenericList();
            //UseGenericStack();
            //UseGenericQueue();
            UseGenericSortedSet();



            Console.ReadLine();
        }

        static void UseGenericList()
        {
            List<Person> people = new List<Person>()
            {
                new Person{FirstName="Homer", LastName="Simpson", Age=47},
                new Person{FirstName="Marge", LastName="Simpson", Age=45},
                new Person{FirstName="Lisa", LastName="Simpson", Age=9},
                new Person{FirstName="Bart", LastName="Simpson", Age=8}
            };
            //display count
            Console.WriteLine("Items in 'people': {0}", people.Count);
            //enumerate over list
            foreach (Person p in people)
            {
                Console.WriteLine(p);
            }

            //insert a person
            Console.WriteLine("-> Inserting Maggie");
            people.Insert(2, new Person { FirstName = "Maggie", LastName = "Simpson", Age = 2 });
            //display count
            Console.WriteLine("Items in 'people': {0}", people.Count);
            //enumerate over list
            foreach (Person p in people)
            {
                Console.WriteLine(p);
            }

            //copy to new array
            Person[] arrayOfPeople = people.ToArray();
            for (int i = 0; i < arrayOfPeople.Length; i++)
            {
                Console.WriteLine("First name: {0}",arrayOfPeople[i].FirstName);
            }
        }

        static void UseGenericStack()
        {
            Stack<Person> stackOfPeople = new Stack<Person>();
            stackOfPeople.Push(new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            stackOfPeople.Push(new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            stackOfPeople.Push(new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

            //play with the stack
            Console.WriteLine("Top of stack is {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped {0} off the stack", stackOfPeople.Pop());

            Console.WriteLine("Top of stack is {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped {0} off the stack", stackOfPeople.Pop());

            Console.WriteLine("Top of stack is {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped {0} off the stack", stackOfPeople.Pop());
            try
            {
                Console.WriteLine("Top of stack is {0}",stackOfPeople.Peek());
                Console.WriteLine("Popped {0} off the stack", stackOfPeople.Pop());
            }
            catch (InvalidOperationException e)
            {

                Console.WriteLine("Derp: {0}",e.Message);
            }
        }

        static void ServeCoffee(Person p)
        {
            Console.WriteLine("{0} got coffee", p.FirstName);
        }

        static void UseGenericQueue()
        {
            //make a queue
            Queue<Person> peopleQ = new Queue<Person>();
            peopleQ.Enqueue(new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            peopleQ.Enqueue(new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            peopleQ.Enqueue(new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

            //peek at the queue
            Console.WriteLine("{0} is first in line", peopleQ.Peek().FirstName);
            while (peopleQ.Count > 0)
            {
                ServeCoffee(peopleQ.Dequeue());
            }
            try
            {
                ServeCoffee(peopleQ.Dequeue());
            }
            catch (InvalidOperationException e)
            {

                Console.WriteLine("Derp: {0}", e.Message);
            }
        }

        static void UseGenericSortedSet()
        {
            //make some people with different ages
            SortedSet<Person> setOfPeople = new SortedSet<Person>(new SortPeopleByAge())
            {
                new Person{FirstName="Homer", LastName="Simpson", Age=47},
                new Person{FirstName="Marge", LastName="Simpson", Age=45},
                new Person{FirstName="Lisa", LastName="Simpson", Age=9},
                new Person{FirstName="Bart", LastName="Simpson", Age=8}
            };
            foreach (Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();
            setOfPeople.Add(new Person { FirstName = "Maggie", LastName = "Simpson", Age = 2 });
            setOfPeople.Add(new Person { FirstName = "Saku", LastName = "Jones", Age = 1 });
            setOfPeople.Add(new Person { FirstName = "Mikko", LastName = "Jones", Age = 32 });
            foreach (Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }
        }
    }
}
