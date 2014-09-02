namespace SimpleIndexer
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PersonCollection : IEnumerable
    {
        private ArrayList arrayPeople = new ArrayList();

        public int Count
        {
            get { return this.arrayPeople.Count; }
        }

        // custom indexer
        public Person this[int index]
        {
            get { return (Person)this.arrayPeople[index]; }
            set { this.arrayPeople.Insert(index, value); }
        }

        public IEnumerator GetEnumerator()
        {
            return this.arrayPeople.GetEnumerator();
        }
    }
}
