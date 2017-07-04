using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FluentAssertions;
using GameOfLife;
using NUnit.Framework;

namespace GameOfLifeTests
{
    public class IsBornTest
    {
        public static Point[] randomPoints =
        {
            new Point(-100, -100),
            new Point(-100, 0),
            new Point(-100, 100),
            new Point(0, -100),
            new Point(0, 0),
            new Point(0, 100),
            new Point(100, -100),
            new Point(100, 0),
            new Point(100, 100)
        };

        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodIsBornShouldReturnFalseThanNeighborsOfNumber1(Point point)
        {
            var points = new List<Point>(new[]
            {
                point.Move(0, -1)
            });
            points.Add(point);
            points.AddRange(new[] { point.Move(-2, 0), point.Move(0, 2), point.Move(2, 0), point.Move(2, 2) });
            points.All(s => CellularAutomat.IsAlive(s, points.ToArray())).Should().BeFalse();
        }

        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodIsBornShouldReturnTrueThanNeighborsOfNumber2(Point point)
        {
            var points = new List<Point>(new[]
            {
                point.Move(0, 1), point.Move(1, 0)
            });
            points.AddRange(new[] { point.Move(-2, 0), point.Move(0, 2), point.Move(2, 0), point.Move(2, 2) });
            CellularAutomat.IsAlive(point, points.ToArray()).Should().BeFalse();
        }

        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodIsBornShouldReturnTrueThanNeighborsOfNumber3(Point point)
        {
            var points = new List<Point>(new[]
            {
                point.Move(0, 1), point.Move(1, 0), point.Move(1, 1)
            });
            points.Add(point);
            points.AddRange(new[] { point.Move(-2, 0), point.Move(0, 2), point.Move(2, 0), point.Move(2, 2) });
            CellularAutomat.IsAlive(point, points.ToArray()).Should().BeTrue();
        }

        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodIsBornShouldReturnFalseThanNeighborsOfNumber4(Point point)
        {
            var points = new List<Point>(new[]
            {
                point.Move(0, -1), point.Move(0, 1), point.Move(1, 0), point.Move(1, 1)
            });
            points.Add(point);
            points.AddRange(new[] { point.Move(-2, 0), point.Move(0, 2), point.Move(2, 0), point.Move(2, 2) });
            CellularAutomat.IsAlive(point, points.ToArray()).Should().BeFalse();
        }


        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodIsBornShouldReturnFalseThanNeighborsOfNumber5(Point point)
        {
            var points = new List<Point>(new[]
            {
                point.Move(0, -1), point.Move(-1, -1), point.Move(0, 1), point.Move(1, 0), point.Move(1, 1)
            });
            points.Add(point);
            points.AddRange(new[] { point.Move(-2, 0), point.Move(0, 2), point.Move(2, 0), point.Move(2, 2) });
            CellularAutomat.IsAlive(point, points.ToArray()).Should().BeFalse();
        }

        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodIsBornShouldReturnFalseThanNeighborsOfNumber6(Point point)
        {
            var points = new List<Point>(new[]
            {
                point.Move(0, -1), point.Move(-1, 0), point.Move(-1, -1), point.Move(0, 1),
                point.Move(1, 0),point.Move(1, 1)
            });
            points.Add(point);
            points.AddRange(new[] { point.Move(-2, 0), point.Move(0, 2), point.Move(2, 0), point.Move(2, 2) });
            CellularAutomat.IsAlive(point, points.ToArray()).Should().BeFalse();
        }

        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodIsBornShouldReturnFalseThanNeighborsOfNumber7(Point point)
        {
            var points = new List<Point>(new[]
            {
                point.Move(0, -1), point.Move(-1, 0), point.Move(-1, -1), point.Move(-1, 1),
                point.Move(0, 1),point.Move(1, 0), point.Move(1, 1)
            });
            points.Add(point);
            points.AddRange(new[] { point.Move(-2, 0), point.Move(0, 2), point.Move(2, 0), point.Move(2, 2) });
            CellularAutomat.IsAlive(point, points.ToArray()).Should().BeFalse();
        }

        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodIsBornShouldReturnFalseThanNeighborsOfNumber8(Point point)
        {
            var points = new List<Point>(new[]
            {
                point.Move(0, -1), point.Move(-1, 0), point.Move(-1, -1), point.Move(-1, 1),
                point.Move(1, -1),point.Move(0, 1), point.Move(1, 0), point.Move(1, 1)
            });
            points.Add(point);
            points.AddRange(new[] { point.Move(-2, 0), point.Move(0, 2), point.Move(2, 0), point.Move(2, 2) });
            CellularAutomat.IsAlive(point, points.ToArray()).Should().BeFalse();
        }
    }
}
