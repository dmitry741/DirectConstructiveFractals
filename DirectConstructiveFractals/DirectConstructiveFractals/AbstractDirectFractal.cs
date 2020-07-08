using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DirectConstructiveFractals
{
    abstract class AbstractDirectFractal : IConstructiveFractal
    {
        protected double[] _angles = null;
        protected float _lenght = 0;
        protected int _fragmentsPerStep = 0;

        private IEnumerable<int> ConvertNumericSystem(int v)
        {
            if (v == 0)
                return new List<int>() { 0 };

            List<int> list = new List<int>();
            int b = v;

            while (b > 0)
            {
                list.Add(b % _fragmentsPerStep);
                b /= _fragmentsPerStep;
            }

            return list;
        }

        private double GetAngle(int step)
        {
            IEnumerable<int> numbers = ConvertNumericSystem(step);
            return numbers.Select(n => _angles[n]).Sum();
        }

        private PointF Rotate(PointF point, PointF center, double angle)
        {
            double co = Math.Cos(angle);
            double si = Math.Sin(angle);

            double x = co * (point.X - center.X) + si * (point.Y - center.Y) + center.X;
            double y = -si * (point.X - center.X) + co * (point.Y - center.Y) + center.Y;

            return new PointF { X = Convert.ToSingle(x), Y = Convert.ToSingle(y) };
        }

        public IEnumerable<PointF> Build(int N, PointF startPoint, PointF endPoint)
        {
            int numberOfSegments = 1;
            float len = 1.0f;

            for (int i = 0; i < N; i++)
            {
                numberOfSegments *= _fragmentsPerStep;
                len *= _lenght;
            }

            List<PointF> points = new List<PointF> { startPoint };
            PointF vector = new PointF(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);

            for (int i = 0; i < numberOfSegments; i++)
            {
                PointF preparePoint = new PointF(points[i].X + vector.X * len, points[i].Y + vector.Y * len);
                PointF p = Rotate(preparePoint, points[i], GetAngle(i));
                points.Add(p);
            }

            return points;
        }
    }
}
