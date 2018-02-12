using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace Lab1
{
    public class Area
    {
        static List<Point> _points = new List<Point>();
        public static Point NewCore;


        public static Point GetPoint(int i)
        {
            return _points[i];
        }

        public static List<Point> GetPts()
        {
            return _points;
        }

        public static void AddPoints(int count)
        {
            var p = new Point();
            var rand = new Random();
            for (var i = 0; i < count; i++)
            {
                p.X = rand.Next(1, 637);
                p.Y = rand.Next(1, 477);
                _points.Add(p);
                p = new Point();
            }
        }

        public static void LoadPts(List<Point> p)
        {
            _points = p;
        }

        private readonly List<Point> _area = new List<Point>();
        Color _color;
        public Point Core;
        private Point _oldcore;

        public void AddPointtoArea(Point p)
        {
            _area.Add(p);
        }

        public void AreaClear()
        {
            _area.Clear();
        }

        public void SetCore(Point p)
        {
            Core = p;
        }

        public void SetColor(int r, int g, int b)
        {
            _color = Color.FromArgb(r, g, b);
        }

        public void SetNewCore()
        {
            var sum = new Point();
            foreach (var point in _area)
            {
                sum.X += point.X;
                sum.Y += point.Y;
            }
            _oldcore.X = Core.X;
            _oldcore.Y = Core.Y;
            Core.X = sum.X / _area.Count;
            Core.Y = sum.Y / _area.Count;
            var index = 0;
            double min, range;
            min = Math.Sqrt(Math.Pow(_area[0].X - Core.X, 2) + Math.Pow(_area[0].Y - Core.Y, 2));

            Parallel.For(0, _area.Count, i =>
            {
                range = Math.Sqrt(Math.Pow(_area[i].X - Core.X, 2) + Math.Pow(_area[i].Y - Core.Y, 2));
                if (range < min)
                {
                    min = range;
                    index = i;
                }
            });
            Core = _area[index];
        }

        public double GetMax(ref Point newCore)
        {
            double max = 0;
            foreach (var point in _area)
            {
                var range = Math.Sqrt(Math.Pow(point.X - Core.X, 2) + Math.Pow(point.Y - Core.Y, 2));
                if (range > max)
                {
                    newCore = point;
                    max = range;
                }
            }
            return max;
        }

        public void Draw(Graphics graph)
        {
            graph.FillRectangle(Brushes.White, _oldcore.X, _oldcore.Y, 5, 5);
            var brush = new SolidBrush(_color);
            foreach (var point in _area)
            {
                graph.FillRectangle(brush, point.X, point.Y, 2, 2);
            }
            graph.FillRectangle(Brushes.Black, Core.X, Core.Y, 5, 5);
        }

        public bool Equal()
        {
            return _oldcore.X == Core.X && _oldcore.Y == Core.Y;
        }
    }
}