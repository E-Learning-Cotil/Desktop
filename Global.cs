using MRG.Controls.UI;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

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
        public static Size mainPanelSize;
        public static Size seriesSize;
        public static Size creationPanelSize;

        public static Font defaultFont;
        public static Font customFont;

        public static float defaultFontLetterSize;
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

        public static void setDefaultFont()
        {
            defaultFontLetterSize = Convert.ToInt32(formSize.Width / 72) ;
            defaultFont = new Font(usedFonts.Families[1], defaultFontLetterSize);
        }

        public static void setMainPanelSize()
        {
            mainPanelSize = new Size(Convert.ToInt32(formSize.Width * 0.668), Convert.ToInt32(formSize.Height * 0.663));
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
                System.Windows.MessageBox.Show("Fontes necessárias não instaladas: \"Righteous\" e \"Quicksand\"!!");
            }
        }
    }

    static class Filter
    {
        public static void orderFilterElements(Panel filterPanel)
        {
            int heightNeeded = 20;

            Button[] buttonArray = filterPanel.Controls.OfType<Button>().ToArray();
            Label[] labelArray = filterPanel.Controls.OfType<Label>().ToArray();
            TextBox[] textBoxArray = filterPanel.Controls.OfType<TextBox>().ToArray();
            ComboBox[] comboBoxArray = filterPanel.Controls.OfType<ComboBox>().ToArray();

            Array.Sort(buttonArray, (x, y) => String.Compare(x.Name, y.Name));
            Array.Sort(labelArray, (x, y) => String.Compare(x.Name, y.Name));
            Array.Sort(textBoxArray, (x, y) => String.Compare(x.Name, y.Name));
            Array.Sort(comboBoxArray, (x, y) => String.Compare(x.Name, y.Name));

            int numberOfButtons = buttonArray.Count();
            int numberOfLabels = labelArray.Count();
            int numberOfTextBoxes = textBoxArray.Count();
            int numberOfComboBoxes = comboBoxArray.Count();

            int buttonCounter = 0;
            int labelCounter = 0;
            int textBoxCounter = 0;
            int comboBoxCounter = 0;

            while (labelCounter != numberOfLabels)
            {
                if (labelArray[labelCounter].Name.ToUpper().Contains("TITLE"))
                {
                    labelArray[labelCounter].Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints * 0.875));
                    labelArray[labelCounter].Location = new Point(10, heightNeeded);
                    labelArray[labelCounter].ForeColor = Styles.filterTitleColor;
                    heightNeeded += labelArray[labelCounter].Height + 10;
                    labelCounter++;

                    if (numberOfTextBoxes != textBoxCounter)
                    {
                        textBoxArray[textBoxCounter].Font = new Font(Styles.customFont.FontFamily, Convert.ToInt32(Styles.customFont.SizeInPoints * 0.75));
                        textBoxArray[textBoxCounter].Size = new Size(filterPanel.Width - 20, Convert.ToInt32(Styles.customFont.SizeInPoints * 0.75));
                        textBoxArray[textBoxCounter].Location = new Point(10, heightNeeded);
                        heightNeeded += textBoxArray[textBoxCounter].Height + 10;
                        textBoxCounter++;
                    }
                    else if (numberOfComboBoxes != comboBoxCounter)
                    {
                        comboBoxArray[comboBoxCounter].Font = new Font(Styles.customFont.FontFamily, Convert.ToInt32(Styles.customFont.SizeInPoints * 0.66));
                        comboBoxArray[comboBoxCounter].FlatStyle = FlatStyle.Flat;
                        comboBoxArray[comboBoxCounter].DropDownStyle = ComboBoxStyle.DropDownList;
                        comboBoxArray[comboBoxCounter].Size = new Size(filterPanel.Width - 20, Convert.ToInt32(Styles.customFont.SizeInPoints * 0.75));
                        comboBoxArray[comboBoxCounter].Location = new Point(10, heightNeeded);
                        heightNeeded += comboBoxArray[comboBoxCounter].Height + 10;
                        comboBoxCounter++;
                    }
                }
                else
                {
                    if (numberOfButtons != buttonCounter)
                    {
                        buttonArray[buttonCounter].BackColor = Styles.white;
                        buttonArray[buttonCounter].Text = "";

                        buttonArray[buttonCounter].Size = new Size(25, 27);

                        Rectangle rectangle = new Rectangle(0, 0, buttonArray[buttonCounter].Width, buttonArray[buttonCounter].Height);
                        GraphicsPath roundedButton = Transform.BorderRadius(rectangle, 12, true, true, true, true);
                        buttonArray[buttonCounter].Region = new Region(roundedButton);

                        buttonArray[buttonCounter].Location = new Point(10, heightNeeded);

                        labelArray[labelCounter].Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints * 0.5));
                        labelArray[labelCounter].Location = new Point(10 + buttonArray[buttonCounter].Width + 5, heightNeeded);

                        heightNeeded += buttonArray[buttonCounter].Height + 5;

                        labelCounter++;
                        buttonCounter++;
                    }
                }
            }
            Panel panel = new Panel();
            panel.Size = new Size(1, 20);
            panel.Location = new Point(20,heightNeeded);
            filterPanel.Controls.Add(panel);
        }

        public static void arrangeFilterPanelsPosition(Form formPai)
        {
            //pega os objetos que vão ser alterados
            Panel filterPanel = formPai.Controls.Find("filterPanel", true).FirstOrDefault() as Panel;
            Panel filterButtonPanel = formPai.Controls.Find("filterButtonPanel", true).FirstOrDefault() as Panel;
            Panel linePanel = formPai.Controls.Find("linePanel", true).FirstOrDefault() as Panel;
            GraphicsPath roundedPanel;

            //Arruma posição e formato do panel com os filtros
            filterPanel.Size = new Size(Convert.ToInt32(formPai.Width * 0.263), Convert.ToInt32(formPai.Height * 0.825));
            filterPanel.Location = new Point(Convert.ToInt32(formPai.Width * 0.712), Convert.ToInt32(formPai.Height * 0.043));
            Rectangle rectangle = new Rectangle(0, 0, filterPanel.Width, filterPanel.Height);
            roundedPanel = Transform.BorderRadius(rectangle, 20, true, true, false, false);
            filterPanel.Region = new Region(roundedPanel);

            //Arruma posição e formato do panel com o botão de filtrar
            filterButtonPanel.Location = new Point(filterPanel.Location.X, Convert.ToInt32(filterPanel.Height + filterPanel.Location.Y));
            filterButtonPanel.Size = new Size(Convert.ToInt32(formPai.Width * 0.263), Convert.ToInt32(formPai.Height * 0.103));
            rectangle = new Rectangle(0, 0, filterButtonPanel.Width, filterButtonPanel.Height);
            roundedPanel = Transform.BorderRadius(rectangle, 20, false, false, true, true);
            filterButtonPanel.Region = new Region(roundedPanel);

            //arruma posição da linha que separa os dois panels
            linePanel.Location = new Point(filterButtonPanel.Location.X, filterButtonPanel.Location.Y);
            linePanel.Size = new Size(filterButtonPanel.Width, 2);
        }

        public static void filterButtonStyle(Panel filterButtonPanel)
        {
            //Pega o botão que vai ser estilizado
            Button filterButton = filterButtonPanel.Controls.Find("filterButton", true).FirstOrDefault() as Button;

            filterButton.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints * 0.7));
            filterButton.Size = new Size(Convert.ToInt32(filterButtonPanel.Width * 0.830), Convert.ToInt32(filterButtonPanel.Height * 0.574));
            filterButton.Location = new Point(Convert.ToInt32(filterButtonPanel.Width / 2 - filterButton.Width / 2), Convert.ToInt32(filterButtonPanel.Height / 2 - filterButton.Height / 2));
            Rectangle rectangle = new Rectangle(0, 0, filterButton.Width, filterButton.Height);
            GraphicsPath roundedButton = Transform.BorderRadius(rectangle, 20, true, true, true, true);
            filterButton.Region = new Region(roundedButton);
        }

    }

    static class ScreenElements
    {
        public static void stylizeLoadingMessage(Form formPai)
        {
            LoadingCircle loadingCircle1 = formPai.Controls.Find("loadingCircle1", true).FirstOrDefault() as LoadingCircle;
            Label loadingText = formPai.Controls.Find("loadingText", true).FirstOrDefault() as Label;
            Panel centralPanel = formPai.Controls.Find("centralPanel", true).FirstOrDefault() as Panel;


            loadingText.Font = Styles.defaultFont;
            loadingCircle1.Location = new Point(Convert.ToInt32((centralPanel.Width / 2) - (loadingCircle1.Width / 2)), Convert.ToInt32(formPai.Height / 2 - loadingCircle1.Height / 2));
            loadingText.Location = new Point(Convert.ToInt32((centralPanel.Width / 2) - (loadingText.Width / 2)) + 10, loadingCircle1.Location.Y - loadingText.Height - 10);
        }

        public static void stylizePlusButton(Form formPai)
        {
            PictureBox plusButtonPictureBox = formPai.Controls.Find("plusButtonPictureBox", true).FirstOrDefault() as PictureBox;
            Panel centralPanel = formPai.Controls.Find("centralPanel", true).FirstOrDefault() as Panel;

            plusButtonPictureBox.Size = new Size(Convert.ToInt32(formPai.Height * 0.083), Convert.ToInt32(formPai.Height * 0.083));

            plusButtonPictureBox.Location = new Point(Styles.seriesSize.Width + 20 - plusButtonPictureBox.Width, centralPanel.Height - plusButtonPictureBox.Height - 7);

            plusButtonPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            plusButtonPictureBox.Padding = new Padding(Convert.ToInt32(formPai.Height * 0.012));

            Rectangle rectangle = new Rectangle(0, 0, plusButtonPictureBox.Width, plusButtonPictureBox.Height);

            GraphicsPath roundedButton = new GraphicsPath();
            roundedButton.StartFigure();
            roundedButton.AddArc(rectangle, 0, 360);
            roundedButton.CloseFigure();
            plusButtonPictureBox.Region = new Region(roundedButton);
        }

        public static void arrangeCentralPanelLocation(Form formPai)
        {
            Panel centralPanel = formPai.Controls.Find("centralPanel", true).FirstOrDefault() as Panel;

            centralPanel.Location = new Point(0, 2);
            centralPanel.Size = new Size(Convert.ToInt32(formPai.Width * 0.673), formPai.Height - 4);
        }
    }

} //END NAMESPACE
