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
using System.Windows;
using System.Windows.Forms;

namespace ElearningDesktop
{
    public partial class Form1 : Form
    {
        Button oldActiveButton; // armazena o botão que estava ativo antes de solicitar a abertura de outro form

        // Declara cada instância de formulário para verificar dentro de diversos métodos quem está aberto
        Form2 form2;
        Form3 form3;
        Form4 form4;
        Form5 form5;

        public Form1()
        {
            InitializeComponent();

            this.ForeColor = Colors.white; //cor da classe de cores criadas  
        }

        private void configureButton()
        {
            button1.Size = button2.Size = button3.Size = button4.Size = Colors.buttonSize;
            button1.Font = button2.Font = button3.Font = button4.Font = Colors.buttonFont;
            changeButtonFormat(button1); // chama a função que muda o formato do botão 1
            changeButtonFormat(button2); // chama a função que muda o formato do botão 2
            changeButtonFormat(button3); // chama a função que muda o formato do botão 3
            changeButtonFormat(button4); // chama a função que muda o formato do botão 4

            changeButtonLocation(button2, button1);
            changeButtonLocation(button3, button2);
            changeButtonLocation(button4, button3);
        }

        private void changeButtonLocation(Button button, Button sourceButton)
        {
            button.Location = new Point(sourceButton.Location.X, sourceButton.Location.Y + sourceButton.Size.Height + 30);

        }

        private void changePanelFormat(Panel panel)
        {
            Rectangle rectangle = new Rectangle(0, 0, panel.Width, panel.Height);
            GraphicsPath roundedPanel = Transform.BorderRadius(rectangle, 25, false, true, true, true);
            panel.Region = new Region(roundedPanel);
        }

        private void changeButtonFormat(Button button)
        {
            Rectangle rectangle = new Rectangle(0, 0, button.Width, button.Height);
            GraphicsPath roundedButton = Transform.BorderRadius(rectangle, 18, true, false,false,true);
            button.Region = new Region(roundedButton);
        }

        private void changeActiveButtonColor(Button newActiveButton)
        {
            oldActiveButton.BackColor = Colors.lightGray;
            newActiveButton.BackColor = Colors.darkGray;
            oldActiveButton = newActiveButton;
        }

        private void closeOpenedForms() // verifica se tem formulários dessas clases abertos, se tiver fecha
        {
            if (System.Windows.Forms.Application.OpenForms.OfType<Form2>().Count() != 0) form2.Close();
            if (System.Windows.Forms.Application.OpenForms.OfType<Form3>().Count() != 0) form3.Close();
            if (System.Windows.Forms.Application.OpenForms.OfType<Form4>().Count() != 0) form4.Close();
            if (System.Windows.Forms.Application.OpenForms.OfType<Form5>().Count() != 0) form5.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changeActiveButtonColor( (Button)sender);
            closeOpenedForms();

            form2 = new Form2();
            form2.TopLevel = false;

            panel2.Controls.Add(form2);

            form2.Size = new System.Drawing.Size(panel2.Width, panel2.Height);
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            changeActiveButtonColor( (Button)sender);
            closeOpenedForms();

            form3 = new Form3();
            form3.TopLevel = false;

            panel2.Controls.Add(form3);

            form3.Size = new System.Drawing.Size(panel2.Width, panel2.Height);
            form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changeActiveButtonColor( (Button)sender);
            closeOpenedForms();
            form4 = new Form4();
            form4.TopLevel = false;

            panel2.Controls.Add(form4);

            form4.Size = new System.Drawing.Size(panel2.Width, panel2.Height);
            form4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            changeActiveButtonColor( (Button)sender);
            closeOpenedForms();

            form5 = new Form5();
            form5.TopLevel = false;

            panel2.Controls.Add(form5);

            form5.Size = new System.Drawing.Size(panel2.Width, panel2.Height);
            form5.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Size = new System.Drawing.Size(this.Width, this.Height);
            panel3.Size = new System.Drawing.Size(this.Width, 90);


            Colors.setFormSize(this.Width, this.Height);
            Colors.setButtonSize();
            Colors.setButtonFont();
            Colors.setPanelSize();


            configureButton();

            changePanelFormat(panel2); // chama a função que muda o formato do painel de formulários

            panel2.Location = new Point(button1.Location.X + button1.Width, button1.Location.Y); // muda a posição do painel de formulários
            panel2.Size = Colors.panelSize;

            oldActiveButton = button1; // declara o botão ativo anteriormente como button1, o primeiro a ser aberto

            button1.PerformClick(); // simula um clique via código
        }
    }
}