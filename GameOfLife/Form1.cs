using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        private StateManager<Point> StateManager = new StateManager<Point>();

        public Form1()
        {
            InitializeComponent();
            //var points = new HashSet<Point>(GenerateBeginStep()).ToArray();           
            //paintBox1.SetPoints(points);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            // next
            var pointOnPaintBox = paintBox1.GetPoints();
            if (StateManager.IsEmplty)
            {
                StateManager.AddState(pointOnPaintBox);
                paintBox1.CanPaint = false;
            }
            var points = CellularAutomat.NextStep(pointOnPaintBox).ToArray();
            if (StateManager.AddState(points))
            {
                paintBox1.SetPoints(points);
                paintBox1.CanPaint = false;
            }
            else
            {
                MessageBox.Show("The End!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // prev
            var points = StateManager.GetPreviewState();

            if (points != null)
            {
                paintBox1.SetPoints(points);
            }

            if (StateManager.IsEmplty)
            {
                paintBox1.CanPaint = true;
            }
        }
    }
}