namespace IdealizedLambdaEventHandling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Car
    {
        // engine health
        private bool carIsDead;

        // ctors
        public Car()
        {
            this.MaxSpeed = 100;
        }

        public Car(string name, int maxSp, int currSp)
        {
            this.CurrentSpeed = currSp;
            this.PetName = name;
            this.MaxSpeed = maxSp;
        }

        // Events related to 'the engine'
        public event EventHandler<CarEventArgs> Exploded;

        public event EventHandler<CarEventArgs> AboutToBlow;

        // internal state properties
        public int CurrentSpeed { get; set; }

        public int MaxSpeed { get; set; }

        public string PetName { get; set; }

        public void Accelerate(int delta)
        {
            // if car is dead...
            if (this.carIsDead)
            {
                if (this.Exploded != null)
                {
                    this.Exploded(this, new CarEventArgs("Sorry, this car is dead already."));
                }
            }
            else
            {
                this.CurrentSpeed += delta;

                // are we close to going boom?
                if (this.MaxSpeed * .95 <= this.CurrentSpeed && this.AboutToBlow != null)
                {
                    this.AboutToBlow(this, new CarEventArgs("Captain, she cannae take much more of this!"));
                }

                if (this.CurrentSpeed >= this.MaxSpeed)
                {
                    // should really call listofhandlers here...
                    this.carIsDead = true;
                }
                else
                {
                    Console.WriteLine("CurrentSpeed = {0}", this.CurrentSpeed);
                }
            }
        }

        public string CallAAA()
        {
            this.CurrentSpeed = 0;
            this.carIsDead = false;
            return "AAA got us fixed right up!";
        }

        // event arg class
        public class CarEventArgs : EventArgs
        {
            public readonly string Msg;

            public CarEventArgs(string message)
            {
                this.Msg = message;
            }
        }
    }
}
