﻿using Islamic_Stars_Pattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Islamic_Stars_Pattern.Class
{
    public class Rossets : Draw,FactoryInterface
    {
        int scale = 3;

        private int N; // N > 2
        private double G; // G = 1 , 2 , 3
        private int K; // K = 0 , 1 , 2

        private double a;
        private double b;
        private double n;

        private double alpha2;
        private double alpha1;
        private double x;
        private double y;
        private double m;

        public Rossets(Canvas canvas , int N , double G , int K, double a , double b , int scale)
        {
            this.canvas = canvas;
            this.N = N;
            this.G = G;
            this.K = K;
            this.a = a;
            this.b = b;
            this.n = b;
            this.scale = scale;
        }
        public void drawPrimitivePattern()
        {
            alpha2 = (90 - (180 / this.N));
            alpha2 = alpha2 * Math.PI / 180;

            alpha1 = K * (180 / this.N);
            alpha1 = alpha1 * Math.PI / 180;

            x =
                    ((this.a * Math.Tan(alpha2)) - this.b)
                    /
                    (Math.Tan(alpha2) - Math.Tan(alpha1));

            y = (Math.Tan(alpha2) * (x - this.a)) + this.b;

            double omega = (180 / this.N) * this.G; // Omega != 90
            omega = omega * Math.PI / 180;

            m = (this.n / Math.Tan(omega));

            this.DrawLine(setX(m * this.scale), setY(this.n * this.scale), setX(this.a * this.scale), setY(this.b * this.scale), 100, Brushes.Cyan);
            this.DrawLine(setX(this.a * this.scale), setY(this.b * this.scale), setX(x * this.scale), setY(y * this.scale), 100, Brushes.Cyan);

            this.DrawLine(setX(m * this.scale), setY(-this.n * this.scale), setX(this.a * this.scale), setY(-this.b * this.scale), 100, Brushes.Cyan);
            this.DrawLine(setX(this.a * this.scale), setY(-this.b * this.scale), setX(x * this.scale), setY(-y * this.scale), 100, Brushes.Cyan);

        }

        private void drawRestOfDiagram()
        {
            Coordinates newAB = null;
            Coordinates newMN = null;
            Coordinates newXY = null;


            for (int i = 1; i <= this.N - 1; i++)
            {
                newAB = Calculation.rotate(N , i, this.a * this.scale, this.b * this.scale);
                newMN = Calculation.rotate(N , i, m * this.scale, this.n * this.scale);
                newXY = Calculation.rotate(N, i, x * this.scale, y * this.scale);

                DrawLine(setX(newAB.X), setY(newAB.Y), setX(newXY.X), setY(newXY.Y), Brushes.Blue);

                DrawLine(setX(newMN.X), setY(newMN.Y), setX(newAB.X), setY(newAB.Y), Brushes.Blue);

                DrawLine(setX(newAB.X), setY(-newAB.Y), setX(newXY.X), setY(-newXY.Y), Brushes.Blue);

                DrawLine(setX(newMN.X), setY(-newMN.Y), setX(newAB.X), setY(-newAB.Y), Brushes.Blue);

            }
        }

        public void draw()
        {
            drawPrimitivePattern();
            drawRestOfDiagram();
        }
    }
}
