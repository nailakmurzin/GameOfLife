using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            points = new HashSet<Point>(GenerateBeginStep());
            beginState = points;
            paintBox1.SetPoints(points);
        }

        public IEnumerable<Point> GenerateBeginStep()
        {
            var rnd = new Random();
            int min = 5;
            int max = 50;
            var totalPoints = new List<Point>();

            totalPoints.AddRange(CellularShapes.GetFigureSquare(new Point(rnd.Next(min, max), rnd.Next(min, max))));
            totalPoints.AddRange(CellularShapes.GetFigureTriade(new Point(rnd.Next(min, max), rnd.Next(min, max))));
            totalPoints.AddRange(CellularShapes.GetFigurePlus(new Point(rnd.Next(min, max), rnd.Next(min, max))));
            totalPoints.AddRange(CellularShapes.GetPairPoints(new Point(rnd.Next(min, max), rnd.Next(min, max))));
            totalPoints.AddRange(CellularShapes.GetFigureGlaider(new Point(rnd.Next(min, max), rnd.Next(min, max))));

            return totalPoints;
        }

        private int currentStep = 0;
        private HashSet<Point> points = new HashSet<Point>();
        private HashSet<Point> beginState = new HashSet<Point>();


        private void button2_Click(object sender, EventArgs e)
        {
            currentStep++;
            points = new HashSet<Point>(CellularAutomat.NextStep(points.ToArray()));
            paintBox1.SetPoints(points);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentStep--;
            points = beginState;
            for (int i = 0; i < currentStep; i++)
            {
                points = new HashSet<Point>(CellularAutomat.NextStep(points.ToArray()));
            }
            paintBox1.SetPoints(points);
        }
    }
}