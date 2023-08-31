﻿using Islamic_Stars_Pattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Islamic_Stars_Pattern.Class
{
    public class Rossets : Draw,FactoryInterface
    {
        int scale = 1;

        private int N; // N > 2
        private double G; // G = 1 , 2 , 3
        private int K; // K = 0 , 1 , 2

        private double a;
        private double b;
        private double n;

        public Rossets(Canvas canvas , int N , double G , int K, double a , double b)
        {
            this.canvas = canvas;
            this.N = N;
            this.G = G;
            this.K = K;
            this.a = a;
            this.b = b;
            this.n = b; //TODO:: CORRECT THIS
        }
        
        public void draw()
        {

        }

        public Coordinates rotate(int i, double x, double y)
        {
            Coordinates coordinates = new Coordinates();

            double phi = 2 * Math.PI / N * i;
            double newX = (x * Math.Cos(phi)) + y * Math.Sin(phi);
            double newY = (-x * Math.Sin(phi)) + y * Math.Cos(phi);
            coordinates.X = newX;
            coordinates.Y = newY;

            return coordinates;
        }

        public void drawPrimitivePattern()
        {
            double alpha2 = (90 - (180 / this.N));
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

            this.DrawLine(setX(m * this.scale), setY(this.n * this.scale), setX(this.a * this.scale), setY(this.b * this.scale));
            this.DrawLine(setX(this.a * this.scale), setY(this.b * this.scale), setX(x * this.scale), setY(y * this.scale));

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
    }
}