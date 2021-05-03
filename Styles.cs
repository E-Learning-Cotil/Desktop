﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningDesktop
{
    abstract class Styles
    {
        public static Color lightGray = Color.FromArgb(80, 80, 80);
        public static Color darkGray = Color.FromArgb(61, 61, 61);
        public static Color backgroundColor = Color.FromArgb(20, 20, 20);
        public static Color white = Color.FromArgb(255, 255, 255);
        public static Size formSize;
        public static Size buttonSize;
        public static float buttonFontSize;
        public static Font buttonFont;
        public static Size mainPanelSize;
        public static Size logoPanelSize;

        public static void setFormSize(int FormWidth, int FormHeight)
        {
            formSize = new Size(FormWidth, FormHeight);
        }


        public static void setButtonSize()
        {
            int buttonWidth = Convert.ToInt32(formSize.Width * 0.183);
            int buttonHeight = Convert.ToInt32(formSize.Height * 0.102);


            buttonSize = new Size(buttonWidth, buttonHeight);
        }

        public static void setButtonFont()
        {
            buttonFontSize = 32;
            buttonFont = new Font("Righteous", buttonFontSize);
        }

        public static void setMainPanelSize()
        {
            int panelWidth = Convert.ToInt32(formSize.Width * 0.668);
            int panelHeight = Convert.ToInt32(formSize.Height * 0.663);

            mainPanelSize = new Size(panelWidth, panelHeight);
        }
        
        public static void changeLogoPanelSize()
        {
            int panelHeight = Convert.ToInt32(formSize.Height * 0.082);
            logoPanelSize = new Size(formSize.Width, panelHeight);
        }
    }
}