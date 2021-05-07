using System;
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

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Controls.Add( createSerie() );// adiciona ao form, o panel criado 
            this.Controls.Add( createSerie() );
            this.Controls.Add( createSerie() );
            this.Controls.Add( createSerie() );
            this.Controls.Add( createSerie() );
            this.Controls.Add( createSerie() );
            this.Controls.Add( createSerie() );
            this.Controls.Add( createSerie() );
            this.Controls.Add( createSerie() );
            this.Controls.Add( createSerie() );
            this.Controls.Add( createSerie() );
            this.Controls.Add( createSerie() );
            this.Controls.Add( createSerie() );
            this.Controls.Add( createSerie() );
            this.Controls.Add( createSerie() );
            this.Controls.Add( createSerie() );
            this.Controls.Add(createSerie());
            this.Controls.Add(createSerie());
            this.Controls.Add(createSerie());
            this.Controls.Add(createSerie());
        }

        private Panel createSerie()
        {
            int gradeNumber = 1;

            Panel serie = new Panel(); //cria uma div
            serie.Size = Styles.seriesSize; //define o tamanho da div

            serie.Location = new Point(20, 20 + (20 + Styles.seriesSize.Height) * seriesCounter); // define a posição da div

            serie.BackColor = Styles.backgroundColor; //define a cor preta para fundo da div

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
            gradePicture.Location = new Point(Convert.ToInt32(serie.Location.X + 2), Convert.ToInt32((serie.Size.Height / 2) - (gradePicture.Size.Height / 2)));


            serie.Controls.Add(gradePicture);//adiciona o pictureBox na div

            Label classroom = new Label(); //cria a serie
            classroom.Text = "INF Diurno"; //define o nome da serie
            classroom.Font = Styles.defaultFont;//define a estilização do texto
            classroom.Size = new Size(Convert.ToInt32(classroom.Text.Length * Styles.buttonFontSize),Convert.ToInt32(Styles.buttonFontSize * 2));//define o tamanho que o texto ocupa na div
            classroom.TextAlign = ContentAlignment.MiddleLeft; //alinha o texto ao centro(x) centro(y)
            classroom.Location = new Point(Convert.ToInt32(gradePicture.Location.X + gradePicture.Size.Width + 10), Convert.ToInt32((serie.Size.Height / 2) - (serie.Size.Height / 2)));

            serie.Controls.Add(classroom);//adiciona o label na div

            changePanelFormat(serie);//arredonda cada div

            seriesCounter++; //aumenta em 1 a quantidade 
            return serie;
        }

        private void changePanelFormat(Panel panel)
        {
            Rectangle rectangle = new Rectangle(0, 0, panel.Width, panel.Height);
            GraphicsPath roundedPanel = Transform.BorderRadius(rectangle, 13, true, true, true, true);
            panel.Region = new Region(roundedPanel);
        }
    }
}
