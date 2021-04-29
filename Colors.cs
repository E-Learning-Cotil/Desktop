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
        public static Size buttonSize;
        public static float buttonFontSize;
        public static Font buttonFont;
        public static Size panelSize;

        public static void setFormSize(int FormWidth, int FormHeight)
        {
            formSize = new Size(FormWidth, FormHeight);
        }


        public static void setButtonSize()
        {
            int buttonWidth = Convert.ToInt32(formSize.Width * 0.1);
            int buttonHeight = Convert.ToInt32(formSize.Height * 0.09);


            buttonSize = new Size(buttonWidth, buttonHeight);
        }

        public static void setButtonFont()
        {
            buttonFontSize = ((formSize.Width - formSize.Height) / 30) - 8;
            buttonFont = new Font("Righteous", buttonFontSize);
        }

        public static void setPanelSize()
        {
            int panelWidth = Convert.ToInt32(formSize.Width);
            int panelHeight = Convert.ToInt32(formSize.Height);


            panelSize = new Size(panelWidth, panelHeight);
        }
    }
}
