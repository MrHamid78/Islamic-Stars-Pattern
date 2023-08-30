using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Islamic_Stars_Pattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int scale = 10;
        private int N; // N > 2
        private double a;
        private double b;
        private double G; // G = 1 , 2 , 3
        private double n;
        private int K; // K = 0 , 1 , 2
        public MainWindow()
        {
            InitializeComponent();

            DrawLine(setX(-(canvas.Width / 2)), setY(0), setX(canvas.Width / 2), setY(0), Brushes.Red);
            DrawLine(setX(0), setY(-(canvas.Height / 2)), setX(0), setY(canvas.Height / 2), Brushes.Red);


            this.N = 12;
            this.a = 10;
            this.b = -8;
            this.G = 4;
            this.n = 1;
            this.K = 0;
            primitivePattern();
        }


        public Coordinates rotate(int i , double x , double y)
        {
            Coordinates coordinates = new Coordinates();

            double phi = 2 * Math.PI / N * i;
            double newX = (x * Math.Cos(phi)) + y * Math.Sin(phi);
            double newY = (- x * Math.Sin(phi)) + y * Math.Cos(phi);
            coordinates.X = newX;
            coordinates.Y = newY;

            return coordinates;
        }

        public void primitivePattern()
        {
            double alpha2 = (90 - (180 / this.N) );
            alpha2 = alpha2 * Math.PI / 180;

            double alpha1 = K * (180 / this.N);
            alpha1 = alpha1 * Math.PI / 180;

            double x =
                    ((this.a * Math.Tan(alpha2)) - this.b)
                    /
                    (Math.Tan(alpha2) - Math.Tan(alpha1));

            double y = (Math.Tan(alpha2) * (x - this.a)) + this.b;

            double omega = (180 / this.N) * this.G; // Omega != 90
            omega = omega * Math.PI / 180;

            double m = (this.n / Math.Tan(omega));

            DrawLine(setX(m * this.scale), setY(this.n * this.scale), setX(this.a * this.scale), setY(this.b * this.scale));
            DrawLine(setX(this.a * this.scale), setY(this.b * this.scale), setX(x * this.scale), setY(y * this.scale));

            Coordinates newAB = null;
            Coordinates newMN = null;
            Coordinates newXY = null;

            newXY = new Coordinates();
            newXY.X = setX(x * this.scale);
            newXY.Y = setY(y * this.scale);


            /*for (int i = 1; i < this.N - 1; i++)
            {
                newAB = this.rotate(i, setX(this.a * this.scale), setY(this.b * this.scale));
                newMN = this.rotate(i, setX(m * this.scale), setY(this.n * this.scale));

                DrawLine(newAB.X, newAB.Y, newXY.X, newXY.Y);

                newXY = this.rotate(i, setX(x * this.scale), setY(y * this.scale));

                DrawLine(newMN.X, newMN.Y, newAB.X, newAB.Y);

                DrawLine(newAB.X, newAB.Y, newXY.X, newXY.Y);
            }*/

        }



        private void DrawLine(double X1, double Y1, double X2, double Y2, SolidColorBrush color)
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

        private void DrawLine(double X1, double Y1, double X2, double Y2)
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



        private double setX(double x)
        {
            double middleOfXAxis = canvas.Width / 2;

            if (x == 0)
                return middleOfXAxis;
            else
                return middleOfXAxis + x;
        }

        private double setY(double x)
        {
            double middleOfYAxis = canvas.Height / 2;

            if (x == 0)
                return middleOfYAxis;
            else
                return middleOfYAxis - x;
        }
    }
}
