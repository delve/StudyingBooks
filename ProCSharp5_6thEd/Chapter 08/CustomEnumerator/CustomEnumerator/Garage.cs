using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator
{
    class Garage : System.Collections.IEnumerable
    {
        private Car[] carArray = new Car[4];

        //put something in to test with via CTOR
        public Garage()
        {
            carArray[0] = new Car("Rusty", 30);
            carArray[1] = new Car("Clunker", 55);
            carArray[2] = new Car("Zippy", 40);
            carArray[3] = new Car("Fred", 59);
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return carArray.GetEnumerator();
        }
    }
}
