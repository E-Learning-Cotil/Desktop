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

            this.ForeColor = Styles.white; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            changeItemsSize();

            oldActiveButton = button1; // declara o botão ativo anteriormente como button1, o primeiro a ser aberto

            button1.PerformClick(); // simula um clique via código
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            changeItemsSize();
        }

        private void configureButtonLayout()
        {
            button1.Size = button2.Size = button3.Size = button4.Size = Styles.buttonSize;
            label1.Font = button1.Font = button2.Font = button3.Font = button4.Font = Styles.buttonFont;
            
            changeButtonFormat(button1); // chama a função que muda o formato do botão 1
            changeButtonFormat(button2); // chama a função que muda o formato do botão 2
            changeButtonFormat(button3); // chama a função que muda o formato do botão 3
            changeButtonFormat(button4); // chama a função que muda o formato do botão 4

            changeMarginSize(); 
        }

        private void changeMarginSize()
        {
            button1.Location = new Point(Convert.ToInt32(this.Width * 0.0743), button1.Height);
            changeButtonLocation(button2, button1);
            changeButtonLocation(button3, button2);
            changeButtonLocation(button4, button3);
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


        private void changeButtonFormat(Button button)
        {
            Rectangle rectangle = new Rectangle(0, 0, button.Width, button.Height);
            GraphicsPath roundedButton = Transform.BorderRadius(rectangle, 18, true, false, false, true);
            button.Region = new Region(roundedButton);
        }

        private void changeButtonLocation(Button button, Button sourceButton)
        {
            button.Location = new Point(sourceButton.Location.X, Convert.ToInt32(sourceButton.Location.Y + sourceButton.Size.Height + this.Height * 0.0254));
        }

        private void changePanelFormat(Panel panel)
        {
            Rectangle rectangle = new Rectangle(0, 0, panel.Width, panel.Height);
            GraphicsPath roundedPanel = Transform.BorderRadius(rectangle, 25, false, true, true, true);
            panel.Region = new Region(roundedPanel);
        }


        private void changeActiveButtonColor(Button newActiveButton)
        {
            oldActiveButton.BackColor = Styles.lightGray;
            newActiveButton.BackColor = Styles.darkGray;
            oldActiveButton = newActiveButton;
        }

        private void closeOpenedForms() // verifica se tem formulários dessas clases abertos, se tiver fecha
        {
            if (System.Windows.Forms.Application.OpenForms.OfType<Form2>().Count() != 0) form2.Close();
            if (System.Windows.Forms.Application.OpenForms.OfType<Form3>().Count() != 0) form3.Close();
            if (System.Windows.Forms.Application.OpenForms.OfType<Form4>().Count() != 0) form4.Close();
            if (System.Windows.Forms.Application.OpenForms.OfType<Form5>().Count() != 0) form5.Close();
        }

        private void resizeOpenedForms() // verifica se tem formulários dessas clases abertos, se tiver redimensiona
        {
            if (System.Windows.Forms.Application.OpenForms.OfType<Form2>().Count() != 0)
            {
                form2.Size = new System.Drawing.Size(panel2.Width, panel2.Height);
            }
            if (System.Windows.Forms.Application.OpenForms.OfType<Form3>().Count() != 0)
            {
                form3.Size = new System.Drawing.Size(panel2.Width, panel2.Height);
            }
            if (System.Windows.Forms.Application.OpenForms.OfType<Form4>().Count() != 0)
            {
                form4.Size = new System.Drawing.Size(panel2.Width, panel2.Height);
            }
            if (System.Windows.Forms.Application.OpenForms.OfType<Form5>().Count() != 0)
            {
                form5.Size = new System.Drawing.Size(panel2.Width, panel2.Height);
            }
            changePanelFormat(panel2);
        }


        private void changeItemsSize()
        {
            button1.Location = new Point(Convert.ToInt32(this.Width * 0.078),Convert.ToInt32(this.Height*0.213));
            Styles.setFormSize(this.Width, this.Height);
            Styles.setButtonSize();
            Styles.setButtonFont();
            Styles.setMainPanelSize();
            Styles.changeLogoPanelSize();

            configureButtonLayout();

            panel1.Size = new Size(this.Width, this.Height - Styles.logoPanelSize.Height);
            panel1.Location = new Point(0, Styles.logoPanelSize.Height);

            panel3.Size = Styles.logoPanelSize;
            pictureBox1.Size = new Size(Convert.ToInt32(this.Width * 0.0465), Convert.ToInt32(panel3.Size.Height*0.612));
            pictureBox1.Location = new Point(Convert.ToInt32(Styles.logoPanelSize.Width*0.078),Convert.ToInt32( (Styles.logoPanelSize.Height/2) - (pictureBox1.Size.Height/2) ));
            label1.Location = new Point(Convert.ToInt32(this.Width * 0.0465 + pictureBox1.Location.X + this.Width*0.01),Convert.ToInt32((Styles.logoPanelSize.Height / 2) - (label1.Size.Height / 2)));
            
            panel2.Location = new Point(button1.Location.X + button1.Width, button1.Location.Y);
            panel2.Size = Styles.mainPanelSize;
           
            resizeOpenedForms();
        }
    }
}