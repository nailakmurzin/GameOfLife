using System.Drawing;

namespace GameOfLife
{
    public static class HelpMethods
    {
        public static Point Move(this Point p, int x, int y) => new Point(p.X + x, p.Y + y);
    }
}
