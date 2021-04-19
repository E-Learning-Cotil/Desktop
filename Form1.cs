using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            // this.ControlBox = false; //Ocultar barra superior
        }

        public void changeActiveButtonColor(Button newActiveButton)
        {
            oldActiveButton.BackColor = lightGray;
            newActiveButton.BackColor = darkGray;

            oldActiveButton = newActiveButton;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changeActiveButtonColor((Button)sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            changeActiveButtonColor((Button)sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changeActiveButtonColor((Button)sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            changeActiveButtonColor((Button)sender);
        }
    }
}
