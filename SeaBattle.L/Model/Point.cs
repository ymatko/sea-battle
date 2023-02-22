using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.L.Model
{
    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
            { 
                this.X = x; 
                this.Y = y; 
            }

        public string GetPoint()
        {
            return $"{this.X}{this.Y}";
        }
        public override string ToString()
        {
            return $"{this.X}{this.Y}";
        }
    }
}
