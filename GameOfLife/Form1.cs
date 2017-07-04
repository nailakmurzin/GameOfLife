using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        private StateManager<Point> StateManager;

        public Form1()
        {
            InitializeComponent();
            var points = new HashSet<Point>(GenerateBeginStep()).ToArray();
            StateManager = new StateManager<Point>(points);
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
        
        private void button2_Click(object sender, EventArgs e)
        {
            // next
            var points = CellularAutomat.NextStep(StateManager.CurrentState).ToArray();
            if (StateManager.AddState(points.ToArray()))
            {
                paintBox1.SetPoints(points);
            }
            else
            {
                MessageBox.Show("The End!");
            }
            GC.Collect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // prev
            var points = StateManager.GetPreviewState();
            if (points != null)
            {
                paintBox1.SetPoints(points);
            }
        }
    }
}