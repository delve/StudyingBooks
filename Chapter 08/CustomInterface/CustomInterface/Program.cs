using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            //naive interface calls
            Triangle myTriangle = new Triangle("Threeways");
            myTriangle.Draw();
            Console.WriteLine("{0} has {1} points\n\n", myTriangle.PetName, myTriangle.Points);

            //checking for interface implementation using casting
            Circle c = new Circle("Perfect");
            IPointy itfPt = null;
            try
            {
                itfPt = (IPointy)c;
                Console.WriteLine("Shape has {0} points", itfPt.GetNumberOfPoints());
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Whoopsy, not a pointy object: {0}\n", e.Message);
            }

            //better interface testing
            Hexagon hex = new Hexagon("Hexxen");
            itfPt = hex as IPointy;
            if (itfPt!=null)
            {
                Console.WriteLine("{0} has {1} points", hex.PetName,itfPt.GetNumberOfPoints());
            }
            else
            {
                Console.WriteLine("Whoops, not a pointy object");
            }

            //testing interface with is
            Shape[] myShapes = { new Hexagon(), new Circle(), new Triangle("Joey"), new Circle("PIZZA") };
            for (int i = 0; i < myShapes.Length; i++)
            {
                //all shapes inherit 'Draw' from Shape
                myShapes[i].Draw();
                //check pointy-ness
                if (myShapes[i] is IPointy)
                {
                    Console.WriteLine("-> {0} points", ((IPointy)myShapes[i]).GetNumberOfPoints());
                }
                else
                {
                    Console.WriteLine("-> {0} isn't a pointy object", myShapes[i].PetName);
                }
                if (myShapes[i] is IDraw3D)
                {
                    ((IDraw3D)myShapes[i]).Draw3D();
                }
                else
                {
                    Console.WriteLine("-> {0} can't be drawn in 3D :(((((", myShapes[i].PetName);
                }
                Console.WriteLine();
            }

            IPointy firstPointy = FirstPoint(myShapes);
            if (firstPointy != null)
            {
                Console.WriteLine("First pointy object was {0} with {1} points", firstPointy.GetType(), firstPointy.Points);
            }

            Console.ReadLine();
        }

        static void DrawIn3D(IDraw3D itf3d)
        {
            Console.WriteLine("Drawing IDraw3D compatible type");
            itf3d.Draw3D();
        }

        static IPointy FirstPoint(Shape[] shapes)
        {
            foreach (Shape item in shapes)
            {
                if (item is IPointy)
                {
                    return item as IPointy;
                }
            }

            return null;
        }
    }
}
