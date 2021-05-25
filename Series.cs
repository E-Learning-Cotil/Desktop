using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElearningDesktop
{
    class Series
    {
        private int gradeNumber;
        private int serieQuantity;
        private string courseName;
        private string classType;
        private string period;
        private Panel seriePanel;
        private string initials;

        public Series(int id, string curso, string tipo, int ano, string periodo,string sigla, int turmas, int position)
        {
            gradeNumber = ano;
            courseName = curso;
            classType = tipo;
            period = periodo;
            initials = sigla;
            serieQuantity = turmas;

            seriePanel = new Panel(); //cria uma div
            seriePanel.Size = Styles.seriesSize; //define o tamanho da div
            seriePanel.Location = new Point(20, 20 + (20 + Styles.seriesSize.Height) * (position)); // define a posição da div
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
            serieName.Text = initials; //define o nome da serie
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
        }

        public Panel getSeriePanel()
        {
            return seriePanel;
        }

        private void changePanelFormat(Panel panel)
        {
            Rectangle rectangle = new Rectangle(0, 0, panel.Width, panel.Height);
            GraphicsPath roundedPanel = Transform.BorderRadius(rectangle, 13, true, true, true, true);
            panel.Region = new Region(roundedPanel);
        }
    }
}
