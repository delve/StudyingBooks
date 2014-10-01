// <author>Grady Brandt</author>
// <copyright company="None" file="DerivedShapes.Circle.cs">None</copyright>

namespace CustomInterface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Circle DOES NOT override Draw().
    /// If we did not implement the abstract Draw() method, Circle would also be
    /// considered abstract, and would have to be marked abstract!
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle" /> class.
        /// </summary>
        public Circle() 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle" /> class.
        /// </summary>
        /// <param name="name">A name</param>
        public Circle(string name) : base(name) 
        { 
        }

        /// <summary>
        /// Just a Drawing method
        /// </summary>
        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Circle", PetName);
        }
    }

    /// <summary>
    /// Hexagon DOES override Draw().
    /// </summary>
    public class Hexagon : Shape, IPointy, IDraw3D
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Hexagon" /> class.
        /// </summary>
        public Hexagon() 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Hexagon" /> class.
        /// </summary>
        /// <param name="name">A name</param>
        public Hexagon( string name ) : base(name) 
        { 
        }

        /// <summary>
        /// Just a Drawing method
        /// </summary>
        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Hexagon", PetName);
        }

        /// <summary>
        /// Gets value of read only property Points
        /// </summary>
        public byte Points
        {
            get { return 6; }
        }

        /// <summary>
        /// Gets points
        /// </summary>
        /// <returns>how many points</returns>
        public byte GetNumberOfPoints() 
        { 
            return Points; 
        }

        public void Draw3D()
        {
            Console.WriteLine("{0} drawn in 3 dimensions!", PetName);
        }
    }

    /// <summary>
    /// This class extends Circle and hides the inherited Draw() method.
    /// </summary>
    public class ThreeDCircle : Circle, IDraw3D
    {
        /// <summary>
        /// Gets or sets: Hides the PetName property above me.
        /// </summary>
        public new string PetName { get; set; }

        /// <summary>
        /// Hide any Draw() implementation above me.
        /// </summary>
        public new void Draw()
        {
            Console.WriteLine("Drawing a 3D Circle");
        }

        public void Draw3D()
        {
            Console.WriteLine("3D circle drawn in stunning 3D");
        }
    }

    /// <summary>
    /// Triangles, yeah!
    /// </summary>
    public class Triangle : Shape, IPointy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle" /> class.
        /// </summary>
        public Triangle() 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle" /> class.
        /// </summary>
        /// <param name="name">A name</param>
        public Triangle(string name) : base(name) 
        { 
        }

        /// <summary>
        /// Just a Drawing method
        /// </summary>
        public override void Draw()
        { 
            Console.WriteLine("Drawing {0} the Triangle", PetName); 
        }
        
        /// <summary> 
        /// Gets value of read only property Points
        /// IPointy imp
        /// </summary>
        public byte Points 
        { 
            get { return 3; } 
        }

        /// <summary>
        /// Gets the point count
        /// </summary>
        /// <returns>How many points</returns>
        public byte GetNumberOfPoints() 
        { 
            return Points; 
        }
    }
}
