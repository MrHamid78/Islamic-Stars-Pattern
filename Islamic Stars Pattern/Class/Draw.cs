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
        protected static Draw draw;

        protected Canvas canvas;

        private int zIndex = 0;
        private SolidColorBrush color = null; 

        public Draw(Canvas canvas)
        {
            this.canvas = canvas;
        }
        public Draw()
        {
        }

        public static void DrawXAndYAxis(Canvas canvas)
        {
            if(draw == null)
            {
                draw = new Draw(canvas);
            }
            draw.DrawLine(draw.setX(-(canvas.ActualWidth / 2)), draw.setY(0), draw.setX(canvas.ActualWidth / 2), draw.setY(0), Brushes.Black);
            draw.DrawLine(draw.setX(0), draw.setY(-(canvas.ActualHeight / 2)), draw.setX(0), draw.setY(canvas.ActualHeight / 2), Brushes.Black);
        }

        public void DrawLine(double X1, double Y1, double X2, double Y2)
        {
            if (color == null)
            {
                color = Brushes.Black;
            }
            Line line = new Line
            {
                X1 = X1,    // Start point X coordinate
                Y1 = Y1,    // Start point Y coordinate
                X2 = X2,   // End point X coordinate
                Y2 = Y2,   // End point Y coordinate
                Stroke = color,
                StrokeThickness = 2
            };

            if (zIndex != 0)
            {
                Canvas.SetZIndex(line, zIndex);
            }

            canvas.Children.Add(line);

            this.zIndex = 0;
            color = null;

        }

        public void DrawLine(double X1, double Y1, double X2, double Y2, SolidColorBrush color)
        {
            this.color = color;
            DrawLine(X1, Y1, X2, Y2);
        }
        public void DrawLine(double X1, double Y1, double X2, double Y2,int zIndex, SolidColorBrush color)
        {
            this.color = color;
            this.zIndex += zIndex;
            DrawLine(X1, Y1, X2, Y2);

        }
        

        public void DrawLine(double X1, double Y1, double X2, double Y2, int zIndex)
        {
            this.zIndex = zIndex;
            DrawLine(X1, Y1, X2, Y2);
        }

        public double setX(double x)
        {
            double middleOfXAxis = canvas.ActualWidth / 2;

            if (x == 0)
                return middleOfXAxis;
            else
                return middleOfXAxis + x;
        }

        public double setY(double x)
        {
            double middleOfYAxis = canvas.ActualHeight / 2;

            if (x == 0)
                return middleOfYAxis;
            else
                return middleOfYAxis - x;
        }
    }
}
