using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Islamic_Stars_Pattern.Class
{
    public class Calculation
    {
        public static Coordinates rotate(int N ,int i, double x, double y)
        {
            Coordinates coordinates = new Coordinates();

            double phi = 2 * Math.PI / N * i;
            double newX = (x * Math.Cos(phi)) - y * Math.Sin(phi);
            double newY = (x * Math.Sin(phi)) + y * Math.Cos(phi);
            coordinates.X = newX;
            coordinates.Y = newY;

            return coordinates;
        }
    }
}
