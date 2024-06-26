﻿using System.Collections;

namespace Geometry
{
    public class Point : IMoveable, IEnumerable<double>
    {
        private double _x;
        private double _y;

        public double X => _x;
        public double Y => _y;

        public Point() { }

        public Point(double v) : this(v, v) { }

        public Point(double x, double y) => (_x, _y) = (x, y);

        public void Move(double x, double y)
        {
            _x += x;
            _y += y;
        }

        public virtual double Distance() => Math.Sqrt(X * X + Y * Y);

        public override string ToString() => $"({X},{Y})";

        public IEnumerator<double> GetEnumerator()
        {
            yield return _x;
            yield return _y;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}