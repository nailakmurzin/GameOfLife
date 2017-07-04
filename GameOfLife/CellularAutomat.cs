using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GameOfLife
{
    public static class CellularAutomat
    {
        private static int[] steps = {-1, 0, 1};

        /// <summary>
        /// All 8 neighbors belonging to this point include this point.
        /// </summary>
        /// <param name="p">Point for which you need to find neighbors</param>
        /// <returns></returns>
        public static IEnumerable<Point> GetAllPointsInRegion(Point p)
        {
            return steps.SelectMany(i => steps.Select(j => p.Move(i, j)));
        }

        /// <summary>
        /// All 8 neighbors belonging to this point.
        /// </summary>
        /// <param name="p">Point for which you need to find neighbors</param>
        /// <returns></returns>
        public static IEnumerable<Point> GetNeighbors(Point p)
        {
            return GetAllPointsInRegion(p).Where(pp => pp != p);
        }

        /// <summary>
        /// Determine whether the point is alive or not alive fo Next Step
        /// </summary>
        /// <param name="p">Live point for the current moment.</param>
        /// <param name="points">Set of living points.</param>
        /// <returns></returns>
        public static bool IsAlive(Point p, Point[] points)
        {
            int count = GetNeighbors(p)
                .Count(points.Contains);
            return count == 3 || points.Contains(p) && count == 2;
        }


        /// <summary>
        /// Generate new live points.
        /// </summary>
        /// <param name="points">Set of living points.</param>
        /// <returns></returns>
        public static IEnumerable<Point> NextStep(Point[] points)
        {
            return points.SelectMany(GetAllPointsInRegion)
                .Distinct().Where(p => IsAlive(p, points));
        }
    }
}