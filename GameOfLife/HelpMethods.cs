using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GameOfLife
{
    public static class HelpMethods
    {
        public static Point Move(this Point p, int x, int y) => new Point(p.X + x, p.Y + y);

        public static bool SetEqual<T>(this T[] source, T[] array)
        {
            if (source.Length != array.Length)
                return false;
            var hashSet = new HashSet<T>(source);
            var a = array.All(hashSet.Remove);
            ;
            return a;
        }
    }
}
