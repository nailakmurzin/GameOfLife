using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FluentAssertions;
using GameOfLife;
using NUnit.Framework;

namespace GameOfLifeTests
{
    public class IsAliveTest
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
        public void MethodIsAliveShouldReturnFalseThanNeighborsOfNumber1(Point point)
        {
            var points = new List<Point>(new[]
            {
                point.Move(0, -1)
            });
            points.Add(point);
            points.AddRange(new[] { point.Move(-2, 0), point.Move(0, 2), point.Move(2, 0), point.Move(2, 2) });
            points.All(s => CellularAutomat.IsAlive(s,points.ToArray())).Should().BeFalse();
        }

        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodIsAliveShouldReturnTrueThanNeighborsOfNumber2(Point point)
        {
            var points = new List<Point>(new[]
            {
               point.Move(0, 1), point.Move(1, 0)
            });
            points.Add(point);
            points.AddRange(new[] { point.Move(-2, 0), point.Move(0, 2), point.Move(2, 0), point.Move(2, 2) });
            CellularAutomat.IsAlive(point,points.ToArray()).Should().BeTrue();
        }

        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodIsAliveShouldReturnTrueThanNeighborsOfNumber3(Point point)
        {
            var points = new List<Point>(new[]
            {
                point.Move(0, 1), point.Move(1, 0), point.Move(1, 1)
            });
            points.Add(point);
            points.AddRange(new[] { point.Move(-2, 0), point.Move(0, 2), point.Move(2, 0), point.Move(2, 2) });
            CellularAutomat.IsAlive(point,points.ToArray()).Should().BeTrue();
        }

        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodIsAliveShouldReturnFalseThanNeighborsOfNumber4(Point point)
        {
            var points = new List<Point>(new[]
            {
                point.Move(0, -1), point.Move(0, 1), point.Move(1, 0), point.Move(1, 1)
            });
            points.Add(point);
            points.AddRange(new[] { point.Move(-2, 0), point.Move(0, 2), point.Move(2, 0), point.Move(2, 2) });
            CellularAutomat.IsAlive(point,points.ToArray()).Should().BeFalse();
        }


        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodIsAliveShouldReturnFalseThanNeighborsOfNumber5(Point point)
        {
            var points = new List<Point>(new[]
            {
                point.Move(0, -1), point.Move(-1, -1), point.Move(0, 1), point.Move(1, 0), point.Move(1, 1)
            });
            points.Add(point);
            points.AddRange(new[] { point.Move(-2, 0), point.Move(0, 2), point.Move(2, 0), point.Move(2, 2) });
            CellularAutomat.IsAlive(point,points.ToArray()).Should().BeFalse();
        }

        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodIsAliveShouldReturnFalseThanNeighborsOfNumber6(Point point)
        {
            var points = new List<Point>(new[]
            {
                point.Move(0, -1), point.Move(-1, 0), point.Move(-1, -1), point.Move(0, 1),
                point.Move(1, 0),point.Move(1, 1)
            });
            points.Add(point);
            points.AddRange(new[] { point.Move(-2, 0), point.Move(0, 2), point.Move(2, 0), point.Move(2, 2) });
            CellularAutomat.IsAlive(point,points.ToArray()).Should().BeFalse();
        }

        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodIsAliveShouldReturnFalseThanNeighborsOfNumber7(Point point)
        {
            var points = new List<Point>(new[]
            {
                point.Move(0, -1), point.Move(-1, 0), point.Move(-1, -1), point.Move(-1, 1),
                point.Move(0, 1),point.Move(1, 0), point.Move(1, 1)
            });
            points.Add(point);
            points.AddRange(new[] { point.Move(-2, 0), point.Move(0, 2), point.Move(2, 0), point.Move(2, 2) });
            CellularAutomat.IsAlive(point,points.ToArray()).Should().BeFalse();
        }

        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodIsAliveShouldReturnFalseThanNeighborsOfNumber8(Point point)
        {
            var points = new List<Point>(new[]
            {
                point.Move(0, -1), point.Move(-1, 0), point.Move(-1, -1), point.Move(-1, 1),
                point.Move(1, -1),point.Move(0, 1), point.Move(1, 0), point.Move(1, 1)
            });
            points.Add(point);
            points.AddRange(new[] { point.Move(-2, 0), point.Move(0, 2), point.Move(2, 0), point.Move(2, 2) });
            CellularAutomat.IsAlive(point,points.ToArray()).Should().BeFalse();
        }
    }
}