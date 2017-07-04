using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GameOfLife
{
    public static class CellularAutomat
    {
        private static int[] steps = {-1, 0, 1};

        /// <summary>
        /// All 8 neighbors belonging to this point.
        /// </summary>
        /// <param name="p">Point for which you need to find neighbors</param>
        /// <returns></returns>
        public static IEnumerable<Point> GetNeighbors(Point p)
        {
            return steps.SelectMany(i => steps.Select(j => p.Move(i, j)))
                .Where(pp => pp != p);
        }

        /// <summary>
        /// Determine whether the point is alive or not alive
        /// </summary>
        /// <param name="p">Live point for the current moment.</param>
        /// <param name="points">Set of living points.</param>
        /// <returns></returns>
        public static bool IsAlive(Point p, IEnumerable<Point> points)
        {
            int count = GetNeighbors(p)
                .Count(points.Contains);
            return count > 1 && count < 4;
        }

        /// <summary>
        /// Get alive or are still dead for a dead point.
        /// </summary>
        /// <param name="p">Dead point.</param>
        /// <param name="points">Set of living points.</param>
        /// <returns></returns>
        public static bool IsBorn(Point p, IEnumerable<Point> points)
        {
            return GetNeighbors(p).Count(points.Contains) == 3;
        }

        /// <summary>
        /// Get live points among the set of living points. 
        /// </summary>
        /// <param name="points">Set of living points.</param>
        /// <returns></returns>
        public static IEnumerable<Point> GetLivePointsFromCurrentLivePoints(Point[] points)
        {
            return points.Where(p => IsAlive(p, points));
        }

        /// <summary>
        /// Get live points among the set of neighbors of living points.
        /// </summary>
        /// <param name="points">Set of living points.</param>
        /// <returns></returns>
        public static IEnumerable<Point> GetLiveNeighborsFromCurrentNeighborsPoints(Point[] points)
        {
            return points.SelectMany(GetNeighbors).Distinct()
                .Where(point => !points.Contains(point) && IsBorn(point, points));
        }

        /// <summary>
        /// Generate new live points.
        /// </summary>
        /// <param name="points">Set of living points.</param>
        /// <returns></returns>
        public static IEnumerable<Point> NextStep(Point[] points)
        {
            return GetLivePointsFromCurrentLivePoints(points)
                .Concat(GetLiveNeighborsFromCurrentNeighborsPoints(points));
        }
    }
}