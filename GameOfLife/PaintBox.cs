using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class PaintBox : UserControl
    {
        private Graphics grafic;

        private int size = 500;

        private Pen pen = new Pen(Color.Gainsboro, 0.01f);

        private Brush brush = new SolidBrush(Color.Green);

        public PaintBox()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(size, size);
            grafic = Graphics.FromImage(pictureBox1.Image);
        }

        public int CellSize { get; set; } = 10;

        public void SetPoints(Point[] points)
        {
            grafic.Clear(Color.White);
            int m = size / CellSize;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    grafic.DrawRectangle(pen, i * 10, j * 10, CellSize, CellSize);
                }
            }
            foreach (var point in points)
            {
                grafic.FillRectangle(brush, point.X * CellSize, point.Y * CellSize, CellSize, CellSize);
                grafic.DrawRectangle(pen, point.X * CellSize, point.Y * CellSize, CellSize, CellSize);
            }
            pictureBox1.Refresh();
        }
    }
}
