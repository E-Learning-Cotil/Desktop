using System;
using System.Activities;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ElearningDesktop
{
    static class Styles
    {
        public static Color lightGray = Color.FromArgb(80, 80, 80);
        public static Color darkGray = Color.FromArgb(61, 61, 61);
        public static Color secondaryColor = Color.FromArgb(40, 40, 40);
        public static Color backgroundColor = Color.FromArgb(20, 20, 20);
        public static Color white = Color.FromArgb(255, 255, 255);
        public static Color filterTitleColor = Color.FromArgb(187, 187, 187);

        public static Size formSize;
        public static Size buttonSize;
        public static Size mainPanelSize;
        public static Size logoPanelSize;
        public static Size seriesSize;
        public static Size creationPanelSize;

        public static Point mainPanelLocation;

        public static Font defaultFont;
        public static float defaultFontLetterSize;

        public static Font customFont;
        public static float customFontLetterSize;

        public static PrivateFontCollection usedFonts;

        public static void setFormSize(int FormWidth, int FormHeight)
        {
            formSize = new Size(FormWidth, FormHeight);
        }

        public static void setCreationPanelSize()
        {
            creationPanelSize = new Size(Convert.ToInt32(formSize.Width*0.688), Convert.ToInt32(formSize.Height * 0.558));
        }

        public static void setSeriesSize()
        {
            seriesSize = new Size(Convert.ToInt32(formSize.Width * 0.419),Convert.ToInt32(formSize.Height * 0.0625));
        }

        public static void setButtonSize()
        {
            int buttonWidth = Convert.ToInt32(formSize.Width * 0.1834);
            int buttonHeight = Convert.ToInt32(formSize.Height * 0.102);

            buttonSize = new Size(buttonWidth, buttonHeight);
        }

        public static void setDefaultFont()
        {
            defaultFontLetterSize = Convert.ToInt32(formSize.Width / 72) ;
            defaultFont = new Font(usedFonts.Families[1], defaultFontLetterSize);
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

        public static void setMainPanelLocation(int x, int y)
        {
            mainPanelLocation = new Point(x, y);
        }

        public static void setCustomFont()
        {
            customFontLetterSize = Convert.ToInt32(formSize.Width / 120);
            customFont = new Font(usedFonts.Families[0], customFontLetterSize);
        }

        public static void setProjectFonts()
        {
            usedFonts = new PrivateFontCollection();

            try
            {
                usedFonts.AddFontFile(Path.Combine(System.Windows.Forms.Application.StartupPath, "Quicksand-Regular.ttf"));
                usedFonts.AddFontFile(Path.Combine(System.Windows.Forms.Application.StartupPath, "Righteous-Regular.ttf"));
            }
            catch
            {
                MessageBox.Show("Fontes necessárias não instaladas: \"Righteous\" e \"Quicksand\"!!");
            }
        }
    }
} //END NAMESPACE
