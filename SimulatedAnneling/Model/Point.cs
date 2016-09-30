using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedAnneling.Model
{
    /// <summary>
    /// Representa un punto de coordenadas (x,y)
    /// </summary>
    public class Point
    {

        private double x;

        private double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double getX()
        {
            return x;
        }
        public double getY()
        {
            return y;
        }
        public override string ToString()
        {
            return x+" "+y;
        }
    }
}
