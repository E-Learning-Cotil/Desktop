﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElearningDesktop
{
    public partial class Form2 : Form
    {
        int seriesCounter;

        public Form2()
        {
            InitializeComponent();
            this.ControlBox = false; //Ocultar barra superior
            this.BackColor = Styles.darkGray;
            this.ForeColor = Styles.white; //cor da classe de estilos criada
            seriesCounter = 0;
        }

        private void filterButtonStyle()
        {
            button1.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints * 0.7));
            button1.Size = new Size(Convert.ToInt32(filterButtonPanel.Width * 0.830), Convert.ToInt32(filterButtonPanel.Height * 0.574));
            button1.Location = new Point(Convert.ToInt32(filterButtonPanel.Width/2 - button1.Width/2), Convert.ToInt32(filterButtonPanel.Height / 2 - button1.Height / 2));
            Rectangle rectangle = new Rectangle(0, 0, button1.Width, button1.Height);
            GraphicsPath roundedButton = Transform.BorderRadius(rectangle, 18, true, true, true, true);
            button1.Region = new Region(roundedButton);
        }

        private void filterPosition()
        {
            filterPanel.Size = new Size(Convert.ToInt32(this.Width * 0.263), Convert.ToInt32(this.Height * 0.825));
            filterPanel.Location = new Point(Convert.ToInt32(this.Width * 0.712), Convert.ToInt32(this.Height * 0.043));
            Rectangle rectangle = new Rectangle(0, 0, filterPanel.Width, filterPanel.Height);
            GraphicsPath roundedPanel = Transform.BorderRadius(rectangle, 20, true, true, false, false);
            filterPanel.Region = new Region(roundedPanel);

            filterButtonPanel.Location = new Point(filterPanel.Location.X, Convert.ToInt32(filterPanel.Height + filterPanel.Location.Y));
            filterButtonPanel.Size = new Size(Convert.ToInt32(this.Width*0.263),Convert.ToInt32(this.Height*0.103));
            rectangle = new Rectangle(0, 0, filterButtonPanel.Width, filterButtonPanel.Height);
            roundedPanel = Transform.BorderRadius(rectangle, 20, false, false, true, true);
            filterButtonPanel.Region = new Region(roundedPanel);

            linePanel.Location = new Point(filterButtonPanel.Location.X,filterButtonPanel.Location.Y);
            linePanel.Size = new Size(filterButtonPanel.Width, 2);

            seriesPanel.Location = new Point(0, 0);
            seriesPanel.Size = new Size(Convert.ToInt32(this.Width * 0.673),this.Height);
        }

        private void checkboxStyle()
        {
            int checkBoxCount = filterPanel.Controls.OfType<CheckBox>().ToArray().Count();
            CheckBox[] checkBoxArray = filterPanel.Controls.OfType<CheckBox>().ToArray();
            Array.Reverse(checkBoxArray, 0, checkBoxCount); // inverte os elementos do array
            //Label[] labelArray = filterPanel.Controls.OfType<Label>().ToArray();
            //int labelCount = filterPanel.Controls.OfType<Label>().ToArray().Count();
            int heightNeeded = filterPanel.Location.Y;
            for (int i = 0; i <= checkBoxCount - 1; i++)
            {
                switch (i)
                {
                    case 0:
                        label1.Location = new Point(10, heightNeeded);
                        heightNeeded += label1.Height;
                        break;
                    case 3:
                        label2.Location = new Point(10, heightNeeded);
                        heightNeeded += label2.Height;
                        break;
                    case 6:
                        label3.Location = new Point(10, heightNeeded);
                        heightNeeded += label3.Height;
                        break;
                }
                checkBoxArray[i].Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints * 0.625));
                checkBoxArray[i].Location = new Point(10, heightNeeded);
                heightNeeded += checkBoxArray[i].Height;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Font = label2.Font = label3.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints * 0.875));
            label1.ForeColor = label2.ForeColor = label3.ForeColor = Styles.filterTitle;
            filterPosition();
            checkboxStyle();
            filterButtonStyle();

            #region Criando Series
            createSerie();
            createSerie();
            createSerie();
            createSerie();
            createSerie();
            createSerie();
            createSerie();
            createSerie();
            createSerie();
            createSerie();
            createSerie();
            createSerie();
            createSerie();
            createSerie();
            #endregion
        }

        private void createSerie()
        {
            int gradeNumber = 3;
            int serieQuantity = seriesCounter;

            Panel seriePanel = new Panel(); //cria uma div
            seriePanel.Size = Styles.seriesSize; //define o tamanho da div

            seriePanel.Location = new Point(20, 20 + (20 + Styles.seriesSize.Height) * seriesCounter); // define a posição da div

            seriePanel.BackColor = Styles.backgroundColor; //define a cor preta para fundo da div

            PictureBox gradePicture = new PictureBox();

            switch (gradeNumber)
            {
                case 1:
                    gradePicture.Image = Properties.Resources.num1;
                    break;

                case 2:
                    gradePicture.Image = Properties.Resources.num2;
                    break;

                case 3:
                    gradePicture.Image = Properties.Resources.num3;
                    break;
            }

            gradePicture.Size = new Size(Convert.ToInt32(Styles.seriesSize.Width * 0.05), Convert.ToInt32(Styles.seriesSize.Height * 0.6));
            gradePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            gradePicture.Location = new Point(Convert.ToInt32(seriePanel.Location.X + 2), Convert.ToInt32((seriePanel.Size.Height / 2) - (gradePicture.Size.Height / 2)));


            seriePanel.Controls.Add(gradePicture);//adiciona o pictureBox na div

            Label serieName = new Label(); //cria a serie
            serieName.Text = "INF Diurno"; //define o nome da serie
            serieName.Font = Styles.defaultFont;//define a estilização do texto
            serieName.AutoSize = true;
            serieName.TextAlign = ContentAlignment.MiddleLeft; //alinha o texto ao centro(x) centro(y)
            serieName.Location = new Point(Convert.ToInt32(gradePicture.Location.X + gradePicture.Size.Width + 10), Convert.ToInt32((seriePanel.Size.Height / 2) - (serieName.Font.Height / 2)));

            seriePanel.Controls.Add(serieName);//adiciona o label na div

            Label assignedClass = new Label();
            assignedClass.Text = serieQuantity + " turmas atribuídas";
            assignedClass.Font = Styles.customFont;//define a estilização do texto

            assignedClass.AutoSize = true;
            assignedClass.TextAlign = ContentAlignment.MiddleLeft;

            assignedClass.Location = new Point(seriePanel.Width - Convert.ToInt32(Styles.formSize.Width * 0.115), Convert.ToInt32((seriePanel.Size.Height / 2) - (assignedClass.Font.Height / 2)));
            seriePanel.Controls.Add(assignedClass);
             
            changePanelFormat(seriePanel);//arredonda cada div

            seriesPanel.Controls.Add(seriePanel);
            seriesPanel.Size = new Size(seriesPanel.Width, seriesPanel.Height - 1);

            seriesCounter++; //aumenta em 1 a quantidade 
        }

        private void changePanelFormat(Panel panel)
        {
            Rectangle rectangle = new Rectangle(0, 0, panel.Width, panel.Height);
            GraphicsPath roundedPanel = Transform.BorderRadius(rectangle, 13, true, true, true, true);
            panel.Region = new Region(roundedPanel);
        }
    }
}
