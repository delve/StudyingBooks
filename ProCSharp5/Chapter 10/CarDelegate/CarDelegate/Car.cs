using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegate
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

        //delegate type
        public delegate void CarEngineHandler(string msgForCaller);
        //member variable container
        private CarEngineHandler listOfHandlers;
        //function for registering delegates
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers += methodToCall;

            ////ridiculously obnoxious non-operator implementation
            //if (null == listOfHandlers)
            //{
            //    listOfHandlers = methodToCall;
            //}
            //else
            //{   
            //    //must treat handler variable as variable, Combine() is static and takes a delegate type so methodToCall must be boxed into appropriate type, 
            //    //    then the result of Combine() must be cast to correct derived delegate type.
            //    listOfHandlers = (CarEngineHandler)Delegate.Combine(listOfHandlers, new CarEngineHandler(methodToCall));
            //}
        }

        public void UnrgeisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers -= methodToCall;
        }
        
        public void Accelerate(int delta)
        {
            //if car is dead...
            if (carIsDead)
            {
                if (listOfHandlers != null)
                    listOfHandlers("Sorry, this car is dead already.");
            }
            else
            {
                CurrentSpeed += delta;
                //are we close to going boom?
                if (MaxSpeed*.95 <= CurrentSpeed && listOfHandlers!=null)
                {
                    listOfHandlers("Captain, she cannae take much more of this!");
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


    }
}
