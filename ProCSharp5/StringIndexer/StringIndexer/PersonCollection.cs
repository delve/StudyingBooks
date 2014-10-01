namespace StringIndexer
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PersonCollection : IEnumerable
    {
        private Dictionary<string, Person> listPeople = new Dictionary<string, Person>();

        public int Count 
        { 
            get { return this.listPeople.Count; } 
        }

        // indexer, returns a person based on string index
        public Person this[string name]
        {
            get { return (Person)this.listPeople[name]; }
            set { this.listPeople[name] = value; }
        }

        public IEnumerator GetEnumerator()
        {
            return this.listPeople.GetEnumerator();
        }

        public void ClearPeople()
        {
            this.listPeople.Clear();
        }
    }
}
