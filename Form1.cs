using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElearningDesktop
{
    public partial class Form1 : Form
    {
        Color lightGray = Color.FromArgb(80, 80, 80);
        Color darkGray = Color.FromArgb(61, 61, 61);
        Button oldActiveButton;

        public Form1()
        {
            InitializeComponent();
            oldActiveButton = button1;
            changeActiveButtonColor(button1);
            changeButtonFormat(button1);
            changeButtonFormat(button2);
            changeButtonFormat(button3);
            changeButtonFormat(button4);
            // this.ControlBox = false; //Ocultar barra superior
        }

        private void changeButtonFormat(Button button)
        {
            Rectangle rectangle = new Rectangle(0, 0, button.Width, button.Height);
            GraphicsPath roundedButton = Transform.BorderRadius(rectangle, 15, true, true);
            button.Region = new Region(roundedButton);
        }

        private void changeActiveButtonColor(Button newActiveButton)
        {
            oldActiveButton.BackColor = lightGray;
            newActiveButton.BackColor = darkGray;

            oldActiveButton = newActiveButton;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changeActiveButtonColor( (Button)sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            changeActiveButtonColor( (Button)sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changeActiveButtonColor( (Button)sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            changeActiveButtonColor( (Button)sender);
        }
    }
}