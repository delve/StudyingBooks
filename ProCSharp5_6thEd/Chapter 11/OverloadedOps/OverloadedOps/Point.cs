namespace OverloadedOps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Point : IComparable<Point>
    {
        #region CTORs and PROPs
        public Point(int xpos, int ypos)
        {
            this.X = xpos;
            this.Y = ypos;
        }

        public int X { get; set; }

        public int Y { get; set; }
        #endregion

        #region Operators
        // overload operator +
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        // overload operator +
        public static Point operator +(Point p1, int delta)
        {
            return new Point(p1.X + delta, p1.Y + delta);
        }

        // overload operator +
        public static Point operator +(int delta, Point p1)
        {
            return new Point(p1.X + delta, p1.Y + delta);
        }

        // overload operator -
        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }

        // overload operator -
        public static Point operator -(Point p1, int delta)
        {
            return new Point(p1.X - delta, p1.Y - delta);
        }

        // overload operator - (this is a bit nonsensical due to the non-commutative nature of subtraction, but someone might try it?)
        public static Point operator -(int delta, Point p1)
        {
            return new Point(delta - p1.X, delta - p1.Y);
        }

        // comparison operators
        public static bool operator <(Point p1, Point p2)
        {
            return (p1.CompareTo(p2) < 0);
        }

        public static bool operator >(Point p1, Point p2)
        {
            return (p1.CompareTo(p2) > 0);
        }

        public static bool operator <=(Point p1, Point p2)
        {
            return (p1.CompareTo(p2) <= 0);
        }

        public static bool operator >=(Point p1, Point p2)
        {
            return (p1.CompareTo(p2) <= 0);
        }

        #endregion

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", this.X, this.Y);
        }

        public int CompareTo(Point other)
        {
            if (this.X > other.X && this.Y > other.Y)
            {
                return 1;
            }
            if (this.X < other.X && this.Y < other.Y)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
