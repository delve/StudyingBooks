namespace CustomConversions
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
            // playing with custom type conversion
            Rectangle rect = new Rectangle(15, 4);
            Console.WriteLine(rect.ToString());
            rect.Draw();

            Console.WriteLine();

            // convert rect to Square... no idea why >.>
            Square s = (Square)rect;
            Console.WriteLine(s.ToString());
            s.Draw();

            Rectangle rect2 = new Rectangle(10, 5);
            DrawSquare((Square)rect2);

            // casting squares and ints
            Square sq2 = (Square)90;
            Console.WriteLine("sq2: {0}", sq2);

            int side = (int)sq2;
            Console.WriteLine("Side length of sq2 is: {0}", side);

            // playing with implicit conversion
            Square s3 = new Square(7);
            s3.Draw();

            Rectangle rect3 = s3;
            rect3.Draw();

            Console.ReadLine();
        }

        public static void DrawSquare(Square sq)
        {
            Console.WriteLine(sq.ToString());
            sq.Draw();
        }

        public struct Rectangle
        {
            #region CTORs and PROPs
            public Rectangle(int w, int h)
                : this()
            {
                this.Width = w;
                this.Height = h;
            }

            public int Width { get; set; }

            public int Height { get; set; }
            #endregion

            #region explicit conversion
            // commented to make room for the implicit conversion further in the book
            // Squares can definitely be converted to rectangles... because they are rectangles.
            /*public static explicit operator Rectangle(Square s)
            //{
            //    Rectangle r = new Rectangle();
            //    r.Width = s.Length;
            //    r.Height = s.Length;
            //    return r;
            }
            */
            #endregion

            #region implicit conversion
            // a square is already a rectangle, allow implied conversion
            public static implicit operator Rectangle(Square s)
            {
                return new Rectangle(s.Length, s.Length);
            }
            #endregion

            #region methods
            public void Draw()
            {
                for (int i = 0; i < this.Height; i++)
                {
                    for (int j = 0; j < this.Width; j++)
                    {
                        Console.Write("*");
                    }

                    Console.WriteLine();
                }
            }

            public override string ToString()
            {
                return string.Format("[Width = {0}; Height = {1}]", this.Width, this.Height);
            }
            #endregion
        }

        public struct Square
        {
            #region CTORs and PROPs
            public Square(int l)
                : this()
            {
                this.Length = l;
            }

            public int Length { get; set; }
            #endregion

            #region explicit conversions
            // rectangles can be converted to squares... wha??
            public static explicit operator Square(Rectangle r)
            {
                Square s = new Square();
                s.Length = r.Height;
                return s;
            }

            // Square to int
            public static explicit operator int(Square s)
            {
                return s.Length;
            }

            // int to square
            public static explicit operator Square(int i)
            {
                return new Square(i);
            }
            #endregion

            #region methods
            public void Draw()
            {
                for (int i = 0; i < this.Length; i++)
                {
                    for (int j = 0; j < this.Length; j++)
                    {
                        Console.Write("*");
                    }

                    Console.WriteLine(" ");
                }
            }

            public override string ToString()
            {
                return string.Format("[Length = {0}]", this.Length);
            }
            #endregion
        }
    }
}
