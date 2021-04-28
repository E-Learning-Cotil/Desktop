using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningDesktop
{
    class Colors
    {
        public static Color lightGray = Color.FromArgb(80, 80, 80);
        public static Color darkGray = Color.FromArgb(61, 61, 61);
        public static Color backgroundColor = Color.FromArgb(20, 20, 20);
        public static Color white = Color.FromArgb(255, 255, 255);
        public static Size formSize;

        public static void setSize(int width, int height)
        {
            formSize = new Size(width,height);
        }
    }
}
