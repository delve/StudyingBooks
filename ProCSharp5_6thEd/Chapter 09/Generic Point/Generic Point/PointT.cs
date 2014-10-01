using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Point
{
    public struct Point<T>
    {
        //Generic state data
        private T xPos;
        private T yPos;

        //Generic Constructor
        public Point(T xval, T yval)
        {
            xPos = xval;
            yPos = yval;
        }

        //generic props
        public T X
        {
            get { return xPos; }
            set { xPos = value; } 
        }

        public T Y
        {
            get { return yPos; }
            set { yPos = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", xPos, yPos);
        }

        //reset to type defaults
        public void ResetPoint()
        {
            xPos = default(T);
            yPos = default(T);
        }
    }
}
