using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleException
{
    class Car
    {
        //max speed constant
        public const int MaxSpeed = 100;

        //properties
        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }

        //does the car still work?
        private bool carIsDead;

        //a car has-a radio
        private Radio theMusicBox = new Radio();

        //constructors
        public Car(){}
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }

        //methods
        public void CrankTunes(bool state)
        {
            theMusicBox.TurnOn(state);
        }

        //gogogogo
        public void Accelerate(int delta)
        {
            if(carIsDead)
                Console.WriteLine("No stupid. I can't go any faster. You already killed {0}", PetName);
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    Console.WriteLine("{0} has overheated and blown up, you sorry excuse for a driver", PetName);
                    CurrentSpeed = 0;
                    carIsDead = true;

                    //throw an exception
                    Exception ex = new Exception(string.Format("{0} just blew up!", PetName));
                    ex.HelpLink = "www.CarTalk.com";
                    //some stuff in custom data for detail
                    ex.Data.Add("Timestamp", string.Format("The car exploded at {0}", DateTime.Now));
                    ex.Data.Add("Cause", "You have a lead foot.");
                    throw ex;
                }
                else
                    Console.WriteLine("Current speed => {0}", CurrentSpeed);
            }
        }
    }
}
