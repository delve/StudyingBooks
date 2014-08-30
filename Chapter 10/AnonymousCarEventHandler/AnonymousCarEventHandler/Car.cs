using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousCarEventHandler
{
    class Car
    {
        //internal state
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }

        //engine health
        private bool carIsDead;

        //ctors
        public Car() { MaxSpeed = 100; }
        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            PetName = name;
            MaxSpeed = maxSp;
        }

        //Events related to 'the engine'
        public event EventHandler<CarEventArgs> Exploded;
        public event EventHandler<CarEventArgs> AboutToBlow;

        //event arg class
        public class CarEventArgs : EventArgs
        {
            public readonly string msg;
            public CarEventArgs(string message)
            { 
                msg = message; 
            }
        }

        public void Accelerate(int delta)
        {
            //if car is dead...
            if (carIsDead)
            {
                if (Exploded != null)
                    Exploded(this, new CarEventArgs("Sorry, this car is dead already."));
            }
            else
            {
                CurrentSpeed += delta;
                //are we close to going boom?
                if (MaxSpeed*.9 <= CurrentSpeed && AboutToBlow!=null)
                {
                    AboutToBlow(this, new CarEventArgs("Captain, she cannae take much more of this!"));
                }

                if(CurrentSpeed>=MaxSpeed)
                {
                    //should really call listofhandlers here...
                    carIsDead = true;
                }
                else
                {
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
                }
            }

        }

        public string CallAAA()
        {
            CurrentSpeed = 0;
            carIsDead = false;
            return "AAA got us fixed right up!";
        }


    }
}
