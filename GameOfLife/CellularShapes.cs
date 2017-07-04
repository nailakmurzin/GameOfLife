using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GameOfLife
{
    public class CellularShapes
    {
        public static IEnumerable<Point> GetPairPoints(Point point)
        {
            return new[]
            {
                point.Move(0, 1), point.Move(1, 0)
            };
        }

        public static IEnumerable<Point> GetFigureSquare(Point point)
        {
            int[] steps = { -1, 0, 1 };
            return steps.SelectMany(i => steps.Select(j => point.Move(i, j)));
        }

        public static IEnumerable<Point> GetFigureTriade(Point point)
        {
            return new[]
            {
                point.Move(0, 1), point.Move(1, 0), point.Move(1, 1)
            };
        }
        public static IEnumerable<Point> GetFigurePlus(Point point)
        {
            return new[]
            {
                point.Move(0, -1), point.Move(-1, 0), point.Move(0, 1), point.Move(1, 0)
            };
        }

        public static IEnumerable<Point> GetFigureGlaider(Point point)
        {
            return new[]
            {
                point.Move(0, -1), point.Move(1, 0), point.Move(-1, 1), point.Move(0, 1), point.Move(1, 1)
            };
        }
    }
}
