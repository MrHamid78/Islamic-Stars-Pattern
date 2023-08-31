using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Islamic_Stars_Pattern.Class
{
    public class Draw
    {
        protected Canvas canvas;

        public Draw(Canvas canvas)
        {
            this.canvas = canvas;
        }
        public Draw()
        {

        }

        public void DrawLine(double X1, double Y1, double X2, double Y2, SolidColorBrush color)
        {
            Line line = new Line
            {
                X1 = X1,    // Start point X coordinate
                Y1 = Y1,    // Start point Y coordinate
                X2 = X2,   // End point X coordinate
                Y2 = Y2,   // End point Y coordinate
                Stroke = color,
                StrokeThickness = 2
            };

            canvas.Children.Add(line);
        }
        public void DrawLine(double X1, double Y1, double X2, double Y2)
        {
            Line line = new Line
            {
                X1 = X1,    // Start point X coordinate
                Y1 = Y1,    // Start point Y coordinate
                X2 = X2,   // End point X coordinate
                Y2 = Y2,   // End point Y coordinate
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            canvas.Children.Add(line);
        }

        public double setX(double x)
        {
            double middleOfXAxis = canvas.Width / 2;

            if (x == 0)
                return middleOfXAxis;
            else
                return middleOfXAxis + x;
        }

        public double setY(double x)
        {
            double middleOfYAxis = canvas.Height / 2;

            if (x == 0)
                return middleOfYAxis;
            else
                return middleOfYAxis - x;
        }
    }
}
