using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class PaintBox : UserControl
    {
        private Graphics grafic;

        private Pen pen = new Pen(Color.Gainsboro, 0.01f);

        private Brush brush = new SolidBrush(Color.Green);

        private HashSet<Point> pointsOnPicturesBox = new HashSet<Point>();


        public bool CanPaint { get; set; } = true;

        public int CellSize { get; protected set; } = 10;

        public PaintBox()
        {
            InitializeComponent();
            pictureBox1.MouseWheel += PictureBox1_MouseWheel;
        }

        public void SetPoints(Point[] points)
        {
            pointsOnPicturesBox = new HashSet<Point>(points);
            Draw();
        }

        public Point[] GetPoints()
        {
            return pointsOnPicturesBox.ToArray();
        }


        public bool isMouseDown;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (CanPaint)
            {
                isMouseDown = true;
                pointsOnPicturesBox.Add(new Point(e.X / CellSize, e.Y / CellSize));
                Draw();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                pointsOnPicturesBox.Add(new Point(e.X / CellSize, e.Y / CellSize));
                Draw();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            Draw();
        }

        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            CellSize += e.Delta / Math.Abs(e.Delta);
            Refresh();
        }


        public void Draw()
        {
            grafic.Clear(Color.Transparent);
            if (CanPaint)
            {
                grafic.DrawString("Can mouse draw", new Font(Font.FontFamily, 10), new SolidBrush(Color.Gainsboro), 0, 0);
            }
            foreach (var point in pointsOnPicturesBox)
            {
                grafic.FillRectangle(brush, point.X * CellSize, point.Y * CellSize, CellSize, CellSize);
                grafic.DrawRectangle(pen, point.X * CellSize, point.Y * CellSize, CellSize, CellSize);
            }
            pictureBox1.Refresh();
        }

        private void DrawMesh(Graphics g)
        {
            g.Clear(Color.White);
            for (int i = 0, m = pictureBox1.Width / CellSize, n = pictureBox1.Height / CellSize; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    g.DrawRectangle(pen, i * CellSize, j * CellSize, CellSize, CellSize);
                }
            }
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Width > 0 && pictureBox1.Height > 0)
            {
                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                grafic = Graphics.FromImage(pictureBox1.Image);

                pictureBox1.BackgroundImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                DrawMesh(Graphics.FromImage(pictureBox1.BackgroundImage));

                Draw();
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            pictureBox1_SizeChanged(this, null);
        }
    }
}