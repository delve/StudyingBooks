namespace AnonymousTypes
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
            // make an anon type representing a car
            var myCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };
            Console.WriteLine("I'm driving a {0} {1} going {2} MPH", myCar.Color, myCar.Make, myCar.CurrentSpeed.ToString());
            Console.WriteLine("ToString(): {0}", myCar.ToString());
            Console.WriteLine("car.Equals(car)? {0}", myCar.Equals(myCar));
            Console.WriteLine("GetHashCode(): {0}", myCar.GetHashCode());
            Console.WriteLine("GetType(): {0}", myCar.GetType().ToString());

            ReflectOverAnonymousType(myCar);
            
            // and also through a method
            BuildAnonType("Audi", "Mercury", 75);

            // test equality function
            var my2ndCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };
            Console.WriteLine("Cars equal? -> {0}", myCar.Equals(my2ndCar));
            Console.WriteLine(" 1st == 2nd? : {0}", myCar == my2ndCar);
            Console.WriteLine("Types the same? {0}\n{1}\n{2}", myCar.GetType().Name == my2ndCar.GetType().Name, myCar.GetType(), my2ndCar.GetType());

            // and they can be nested, woo
            var purchaseItem = new
            {
                TimeBought = DateTime.Now,
                ItemBought = new 
                { 
                    Color = "Red", 
                    Make = "Saab", 
                    CurrentSpeed = 55 
                },
                Price = 34.00
            };

            ReflectOverAnonymousType(purchaseItem);
            Console.Read();
        }

        public static void BuildAnonType(string make, string color, int currSp)
        {
            // build the anon type from the incoming params
            var car = new { Make = make, Color = color, Speed = currSp };

            // now 'car' is an unnamed type (type only exists at runtime)
            Console.WriteLine("You have a {0} {1} going {2} MPH", car.Color, car.Make, car.Speed.ToString());

            ReflectOverAnonymousType(car);
        }

        public static void ReflectOverAnonymousType(object obj)
        {
            Console.WriteLine("\n\n=====Anonymous Type Fundamentals====================\n");
            Console.WriteLine(
                "Object is a - {0}", 
                obj.GetType().Name);
            Console.WriteLine();
            Console.WriteLine(
                "Base class of {0} is: {1}", 
                obj.GetType().Name, 
                obj.GetType().BaseType.Name);
            Console.WriteLine();

            // auto-generated custom implementations of System.Object virtuals
            Console.WriteLine("GetType(): {0}", obj.GetType().ToString());
            Console.WriteLine("ToString(): {0}", obj.ToString());
            Console.WriteLine("obj.Equals(obj)? {0}", obj.Equals(obj));
            Console.WriteLine("GetHashCode(): {0}", obj.GetHashCode());
            Console.WriteLine("\n====================================================\n\n");
        }
    }
}
