using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElearningDesktop
{
    public partial class Form1 : Form
    {
        Button oldActiveButton;

        public Form1()
        {
            InitializeComponent();

            this.ForeColor = Colors.white; //cor da classe de cores criadas  

            changeButtonFormat(button1);
            changeButtonFormat(button2);
            changeButtonFormat(button3);
            changeButtonFormat(button4);

            oldActiveButton = button1;

            button1.PerformClick();
        }

        private void changeButtonFormat(Button button)
        {
            Rectangle rectangle = new Rectangle(0, 0, button.Width, button.Height);
            GraphicsPath roundedButton = Transform.BorderRadius(rectangle, 18, true, true);
            button.Region = new Region(roundedButton);
        }

        private void changeActiveButtonColor(Button newActiveButton)
        {
            oldActiveButton.BackColor = Colors.lightGray;
            newActiveButton.BackColor = Colors.darkGray;
            oldActiveButton = newActiveButton;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changeActiveButtonColor( (Button)sender);

            Form2 form2 = new Form2();
            form2.TopLevel = false;

            panel2.Controls.Add(form2);

            form2.Size = new System.Drawing.Size(panel2.Width, panel2.Height);
            Rectangle rectangle = new Rectangle(0, 0, panel2.Width, panel2.Height);
            GraphicsPath roundedForm = Transform.BorderRadius(rectangle, 22, true, true);
            form2.Region = new Region(roundedForm);

            form2.Show();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Size = new System.Drawing.Size(this.Width,80);
            panel1.Size = new System.Drawing.Size(this.Width, this.Height);
        }
    }
}