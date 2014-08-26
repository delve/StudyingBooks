using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FunWithObservableCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            //make a collection to 'observe' and add some peoples
            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
                new Person{FirstName="Peter", LastName="Murphy", Age=52},
                new Person{FirstName="Kevin", LastName="Key", Age=48}
            };
            //wire up the event listener
            people.CollectionChanged += people_CollectionChanged;

            Console.WriteLine("Here's the collection of people");
            foreach (Person p in people)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("\n");
            people.Add(new Person { FirstName = "Peter", LastName = "Parker", Age = 25 });
            people.RemoveAt(0);

            Console.ReadLine();
        }

        static void people_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Handling {0} action", e.Action);

            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    Console.WriteLine("Something was added, here's the newest entry:");
                    foreach (Person p in e.NewItems)
                    {
                        Console.WriteLine(p.ToString());
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Allow me to redundantly list the data that has been deleted...");
                    foreach (Person p in e.OldItems)
                    {
                        Console.WriteLine(p.ToString());
                    }
                    Console.WriteLine();
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }
    }
}
