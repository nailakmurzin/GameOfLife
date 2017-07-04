using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GameOfLife
{
    public static class CellularAutomat
    {
        private static int[] steps = {-1, 0, 1};

        public static IEnumerable<Point> GetNeighbors(Point p)
        {
            return steps.SelectMany(i => steps.Select(j => p.Move(i, j)))
                .Where(pp => pp != p);
        }

        public static bool IsAlive(Point p, IEnumerable<Point> points)
        {
            int count = GetNeighbors(p)
                .Count(points.Contains);
            return count > 1 && count < 4;
        }

        public static bool IsBorn(Point p, IEnumerable<Point> points)
        {
            return GetNeighbors(p).Count(points.Contains) == 3;
        }

        public static IEnumerable<Point> GetLiveNeighborsFromCurrentLivePoints(Point[] points)
        {
            return points.Where(p => IsAlive(p, points));
        }

        public static IEnumerable<Point> GetLiveNeighborsFromCurrentNeighborsPoints(Point[] points)
        {
            return points.SelectMany(GetNeighbors).Distinct()
                .Where(point => !points.Contains(point) && IsBorn(point, points));
        }

        public static IEnumerable<Point> NextStep(Point[] points)
        {
            return GetLiveNeighborsFromCurrentLivePoints(points)
                .Concat(GetLiveNeighborsFromCurrentNeighborsPoints(points));
        }
    }
}