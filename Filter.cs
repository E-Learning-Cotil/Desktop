using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace ElearningDesktop
{
    static class Filter
    {
        public static void orderFilterElements(Panel filterPanel)
        {
            int heightNeeded = 20;

            Button[] buttonArray = filterPanel.Controls.OfType<Button>().ToArray();
            Label[] labelArray = filterPanel.Controls.OfType<Label>().ToArray();
            TextBox[] textBoxArray = filterPanel.Controls.OfType<TextBox>().ToArray();

            Array.Sort(buttonArray, (x, y) => String.Compare(x.Name, y.Name));
            Array.Sort(labelArray, (x, y) => String.Compare(x.Name, y.Name));
            Array.Sort(textBoxArray, (x, y) => String.Compare(x.Name, y.Name));

            int numberOfButtons = buttonArray.Count();
            int numberOfLabels = labelArray.Count();
            int numberOfTextBoxes = textBoxArray.Count();

            int buttonCounter = 0;
            int labelCounter = 0;
            int textBoxCounter = 0;

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
                        textBoxArray[textBoxCounter].Size = new Size(filterPanel.Width - 40, Convert.ToInt32(Styles.customFont.SizeInPoints * 0.75));
                        textBoxArray[textBoxCounter].Location = new Point(10, heightNeeded);
                        heightNeeded += textBoxArray[textBoxCounter].Height + 10;
                        textBoxCounter++;
                    }
                }
                else 
                {
                    if (numberOfButtons != 0)
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
        }

}
}
