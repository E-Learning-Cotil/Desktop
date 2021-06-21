using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElearningDesktop
{
    class Turmas
    {
        private int turmaID;
        private string turmaName;
        private string turmaIcon;
        private string nomeSerie;
        private string nomeProfessor;

        private string turmaPrimaryColor;
        private string turmaSecondaryColor;
        private string turmaRGTeacher;


        private Panel turmaPanel;
        private Thread getImageThread;
        private PictureBox turmaPicture = new PictureBox();

        public Turmas(int id, string nome, string icone, string corPrim, string corSec, string nomeSerie, string nomeProfessor, int position)
        {
            #region Atributos

            string[] words = nome.Trim().Split(' ');
            if (words.Length > 1) nome = words[0] + " " + words[words.Length - 1];
            turmaID = id;
            turmaName = nome;
            turmaIcon = icone;
            turmaPrimaryColor = corPrim;
            turmaSecondaryColor = corSec;
            this.nomeSerie = nomeSerie;
            this.nomeProfessor = nomeProfessor;

            #endregion

            #region Div Principal

            turmaPanel = new Panel(); //cria uma div
            turmaPanel.Size = Styles.seriesSize; //define o tamanho da div
            turmaPanel.Location = new Point(20, 20 + (20 + Styles.seriesSize.Height) * (position)); // define a posição da div
            turmaPanel.BackColor = Styles.backgroundColor; //define a cor preta para fundo da div

            #endregion

            #region Imagem

            getImageThread = new Thread(new ThreadStart(getImage));
            getImageThread.Start();

            turmaPicture.Size = new Size(Convert.ToInt32(Styles.seriesSize.Width * 0.05), Convert.ToInt32(Styles.seriesSize.Height * 0.6));
            turmaPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            turmaPicture.Location = new Point(Convert.ToInt32(turmaPanel.Location.X + 2), Convert.ToInt32((turmaPanel.Size.Height / 2) - (turmaPicture.Size.Height / 2)));

            Rectangle rectangle = new Rectangle(0, 0, turmaPicture.Width, turmaPicture.Height);
            GraphicsPath roundedImage = Transform.BorderRadius(rectangle, 20, true, true, true, true);
            turmaPicture.Region = new Region(roundedImage);

            turmaPanel.Controls.Add(turmaPicture);//adiciona o pictureBox na div

            #endregion

            #region Nome

            Label classNameLabel = new Label(); //cria a serie
            classNameLabel.Text = turmaName + " - " + this.nomeSerie; //define o nome da serie
            classNameLabel.Font = Styles.defaultFont;//define a estilização do texto
            classNameLabel.AutoSize = true;
            classNameLabel.TextAlign = ContentAlignment.MiddleLeft; //alinha o texto ao centro(x) centro(y)
            classNameLabel.Location = new Point(Convert.ToInt32(turmaPicture.Location.X + turmaPicture.Size.Width + 10), Convert.ToInt32((turmaPanel.Size.Height / 2) - (classNameLabel.Font.Height / 2)));


            turmaPanel.Controls.Add(classNameLabel);//adiciona o label na div

            #endregion

            #region ID Série

            Label nameTeacherLabel = new Label();
            nameTeacherLabel.Text = nomeProfessor;
            nameTeacherLabel.Font = Styles.customFont;//define a estilização do texto

            nameTeacherLabel.Size = new Size(255, nameTeacherLabel.Font.Height);

            nameTeacherLabel.TextAlign = ContentAlignment.TopRight;

            nameTeacherLabel.Location = new Point(turmaPanel.Width - nameTeacherLabel.Width, Convert.ToInt32(turmaPanel.Size.Height / 2 - nameTeacherLabel.Font.SizeInPoints));

            turmaPanel.Controls.Add(nameTeacherLabel);

            #endregion


            changePanelFormat(turmaPanel);//arredonda a div
        }

        private void getImage()
        {
            try
            {
                WebResponse imageResponse = null;
                Stream responseStream;
                HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(turmaIcon);
                imageResponse = imageRequest.GetResponse();
                responseStream = imageResponse.GetResponseStream();
                turmaPicture.Image = Image.FromStream(responseStream);
                responseStream.Close();
                imageResponse.Close();
            }
            catch
            {
                turmaPicture.Image = Properties.Resources.user;
            }
        }

        public Panel getTurmaPanel()
        {
            return turmaPanel;
        }

        private void changePanelFormat(Panel panel)
        {
            Rectangle rectangle = new Rectangle(0, 0, panel.Width, panel.Height);
            GraphicsPath roundedPanel = Transform.BorderRadius(rectangle, 13, true, true, true, true);
            panel.Region = new Region(roundedPanel);
        }
    }
}
