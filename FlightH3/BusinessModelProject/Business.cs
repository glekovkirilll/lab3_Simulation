using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModelProject
{
    class Business
    {
        const double dt = 0.1;
        const double g = 9.81;
        const double C = 0.15;
        const double rho = 1.29;

        public double a;
        public double v0;
        public double y0;
        public double S;
        public double m;
        public double k;

        public double t;
        public double x;
        public double y;
        public double vx;
        public double vy;
        public double MaxHeight = 0;

        public Business(double a, double v0, double y0, double S, double m)
        {
            this.a = a;
            this.v0 = v0;
            this.y0 = y0;
            this.S = S;
            this.m = m;
            
        }

        public Tuple<double, double, double> GetCoords()
        {
            k = 0.5 * C * S * rho / m;
            vx = v0 * Math.Cos(a * Math.PI / 180);
            vy = v0 * Math.Sin(a * Math.PI / 180);

            t = 0;
            x = 0;
            y = y0;

            return Tuple.Create(t, x, y);
        }

        public Tuple<double, double, double, double> GetParameters()
        {
            t += dt;
            vx = vx - k * vx * Math.Sqrt(vx * vx + vy * vy) * dt;
            vx = vy - (g + k * vy * Math.Sqrt(vx * vx + vy * vy)) * dt;

            x = x + vx * dt;
            y = y + vy * dt;

            if (y > MaxHeight)
                MaxHeight = y;

            return Tuple.Create(x, y, t, MaxHeight);
        }
    }
}
