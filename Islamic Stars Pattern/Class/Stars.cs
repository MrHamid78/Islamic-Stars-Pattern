using Islamic_Stars_Pattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Islamic_Stars_Pattern.Class
{
    internal class Stars : Draw, FactoryInterface
    {
        int scale = 3;
        private int N; // N > 2
        private int K; // K = 0 , 1 , 2

        private double a;
        private double b;

        private double alpha2;
        private double alpha1;
        private double x;
        private double y;

        public Stars(Canvas canvas, int N,int K, double a, double b)
        {
            this.canvas = canvas;
            this.N = N;
            this.K = K;
            this.a = a;
            this.b = b;
        }
        public void drawPrimitivePattern()
        {
            alpha2 = 90 - 180 / N;
            alpha2 = (alpha2 * Math.PI) / 180;

            alpha1 = K * 180 / N;
            alpha1 = (alpha1 * Math.PI) / 180;



            x = (a * Math.Tan(alpha2) - b) / (Math.Tan(alpha2) - Math.Tan(alpha1));
            y = Math.Tan(alpha2) * (x - a) + b;

            this.DrawLine(setX(this.a * this.scale), setY(this.b * this.scale), setX(x * this.scale), setY(y * this.scale), 100, Brushes.Cyan);
            this.DrawLine(setX(this.a * this.scale), setY(-this.b * this.scale), setX(x * this.scale), setY(-y * this.scale), 100, Brushes.Cyan);

        }

        public void drawRestOfDiagram()
        {

            Coordinates newAB = null;
            Coordinates newXY = null;

            for (int i = 1; i <= this.N - 1; i++)
            {
                newAB = Calculation.rotate(N, i, this.a * this.scale, this.b * this.scale);
                newXY = Calculation.rotate(N, i, x * this.scale, y * this.scale);

                DrawLine(setX(newAB.X), setY(newAB.Y), setX(newXY.X), setY(newXY.Y), Brushes.Blue);
                DrawLine(setX(newAB.X), setY(-newAB.Y), setX(newXY.X), setY(-newXY.Y), Brushes.Blue);

            }

        }

        public void draw()
        {
            drawPrimitivePattern();
            drawRestOfDiagram();
        }
    }
}
