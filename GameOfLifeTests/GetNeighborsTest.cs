using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FluentAssertions;
using GameOfLife;
using NUnit.Framework;

namespace GameOfLifeTests
{
    [TestFixture]
    public class GetNeighborsTest
    {
        public static Point[] randomPoints = {
            new Point(-100,-100),
            new Point(-100,0),
            new Point(-100,100),
            new Point(0,-100),
            new Point(0,0),
            new Point(0,100),
            new Point(100,-100),
            new Point(100,0),
            new Point(100,100)
        };

        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodGetNeighborsShouldReturnNeighborsOfPointThatEquivalentToMethodGenerateNeighbors(Point point)
        {
            int x = point.X;
            int y = point.Y;
            var neighbors = new[]
            {
                new Point(x - 1, y - 1), new Point(x - 1, y + 0), new Point(x - 1, y + 1),
                new Point(x + 0, y - 1),                          new Point(x + 0, y + 1),
                new Point(x + 1, y - 1), new Point(x + 1, y + 0), new Point(x + 1, y + 1)
            };
            CellularAutomat.GetNeighbors(point)
                .ShouldAllBeEquivalentTo(neighbors);
        }

        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodGetNeighborsShouldReturnNeighborsOfPointThatAlwaysNumberOf8(Point point)
        {
            CellularAutomat.GetNeighbors(point).Count()
                .ShouldBeEquivalentTo(8);
        }

        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodGetNeighborsShouldReturnNeighborsOfPointThatDoNotConstainSourcePoint(Point point)
        {
            CellularAutomat.GetNeighbors(point)
                .Should().NotContain(point);
        }

        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodGetNeighborsShouldReturnLiveNeighborsOfPointThatAlwaysNumberOf4(Point point)
        {
            var points = new List<Point>(new[] { point.Move(0, -1), point.Move(0, 1), point.Move(1, 0), point.Move(1, 1) });
            points.Add(point);
            points.AddRange(new[] { point.Move(-2, 0), point.Move(0, 2), point.Move(2, 0), point.Move(2, 2) });
            CellularAutomat.GetNeighbors(point).Count(p => p != point && points.Contains(p))
                .ShouldBeEquivalentTo(4);
        }


        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodGetNeighborsShouldReturnLiveNeighborsOfPointThatAlwaysNumberOf3(Point point)
        {
            var points = new List<Point>(new[] {  point.Move(0, 1), point.Move(1, 0), point.Move(1, 1) });
            points.Add(point);
            points.AddRange(new[] { point.Move(-2, 0), point.Move(0, 2), point.Move(2, 0), point.Move(2, 2) });
            CellularAutomat.GetNeighbors(point).Count(p => p != point && points.Contains(p))
                .ShouldBeEquivalentTo(3);
        }

        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodGetNeighborsShouldReturnLiveNeighborsOfPointThatAlwaysNumberOf2(Point point)
        {
            var points = new List<Point>(new[] { point.Move(0, -1), point.Move(1, 0) });
            points.Add(point);
            points.AddRange(new[] { point.Move(-2, 0), point.Move(0, 2), point.Move(2, 0), point.Move(2, 2) });
            CellularAutomat.GetNeighbors(point).Count(p => p != point && points.Contains(p))
                .ShouldBeEquivalentTo(2);
        }

        [Test, TestCaseSource(nameof(randomPoints))]
        public void MethodGetNeighborsShouldReturnLiveNeighborsOfPointThatAlwaysNumberOf1(Point point)
        {
            var points = new List<Point>(new[] { point.Move(0, -1) });
            points.Add(point);
            points.AddRange(new[] { point.Move(-2, 0), point.Move(0, 2), point.Move(2, 0), point.Move(2, 2) });
            CellularAutomat.GetNeighbors(point).Count(p => p != point && points.Contains(p))
                .ShouldBeEquivalentTo(1);
        }

        
    }
}