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
    class Students
    {
        private string studentName;
        private string studentTelephone;
        private string studentEmail;
        private int studentRA;
        private string studentFoto;
        private int studentIdSerie;
        private Panel studentPanel;
        private Thread getImageThread;
        private PictureBox studentPicture = new PictureBox();

        public Students(string nome, string telefone, string email, int RA, string foto, int idSerie, int position)
        {
            #region Atributos

            string[] words = nome.Trim().Split(' ');
            if(words.Length > 1) nome = words[0] + " " + words[words.Length - 1];
            studentName = nome;
            studentTelephone = telefone;
            studentEmail = email;
            studentRA = RA;
            studentFoto = foto;
            studentIdSerie = idSerie;

            #endregion

            #region Div Principal

            studentPanel = new Panel(); //cria uma div
            studentPanel.Size = Styles.seriesSize; //define o tamanho da div
            studentPanel.Location = new Point(20, 20 + (20 + Styles.seriesSize.Height) * (position)); // define a posição da div
            studentPanel.BackColor = Styles.backgroundColor; //define a cor preta para fundo da div

            #endregion

            #region Imagem

            getImageThread = new Thread(new ThreadStart(getImage));
            getImageThread.Start();

            studentPicture.Size = new Size(Convert.ToInt32(Styles.seriesSize.Width * 0.05), Convert.ToInt32(Styles.seriesSize.Height * 0.6));
            studentPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            studentPicture.Location = new Point(Convert.ToInt32(studentPanel.Location.X + 2), Convert.ToInt32((studentPanel.Size.Height / 2) - (studentPicture.Size.Height / 2)));

            Rectangle rectangle = new Rectangle(0, 0, studentPicture.Width, studentPicture.Height);
            GraphicsPath roundedImage = Transform.BorderRadius(rectangle, 20, true, true, true, true);
            studentPicture.Region = new Region(roundedImage);

            studentPanel.Controls.Add(studentPicture);//adiciona o pictureBox na div

            #endregion

            #region Nome

            Label studentNameLabel = new Label(); //cria a serie
            studentNameLabel.Text = studentName; //define o nome da serie
            studentNameLabel.Font = Styles.defaultFont;//define a estilização do texto
            studentNameLabel.AutoSize = true;
            studentNameLabel.TextAlign = ContentAlignment.MiddleLeft; //alinha o texto ao centro(x) centro(y)
            studentNameLabel.Location = new Point(Convert.ToInt32(studentPicture.Location.X + studentPicture.Size.Width + 10), Convert.ToInt32((studentPanel.Size.Height / 2) - (studentNameLabel.Font.Height / 2)));


            studentPanel.Controls.Add(studentNameLabel);//adiciona o label na div

            #endregion

            #region Telefone

            Label telephoneNumber = new Label();
            telephoneNumber.Text = studentTelephone;
            telephoneNumber.Font = Styles.customFont;//define a estilização do texto

            telephoneNumber.Size = new Size(255, telephoneNumber.Font.Height);

            telephoneNumber.TextAlign = ContentAlignment.TopRight;

            telephoneNumber.Location = new Point(studentPanel.Width - telephoneNumber.Width, Convert.ToInt32((studentPanel.Size.Height / 2) - 15 - (telephoneNumber.Font.Height / 2)));
            
            studentPanel.Controls.Add(telephoneNumber);

            #endregion

            #region Email

            Label emailAddress = new Label();
            emailAddress.Text = studentEmail;
            emailAddress.Font = Styles.customFont;//define a estilização do texto

            emailAddress.TextAlign = ContentAlignment.BottomRight;

            emailAddress.Size = new Size(510, emailAddress.Font.Height + 5);

            emailAddress.Location = new Point(studentPanel.Width - emailAddress.Width, Convert.ToInt32(studentPanel.Size.Height / 2) - 5);
            studentPanel.Controls.Add(emailAddress);

            #endregion



            changePanelFormat(studentPanel);//arredonda a div
        }
        
        private void getImage()
        {
            try
            {
                WebResponse imageResponse = null;
                Stream responseStream;
                HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(studentFoto);
                imageResponse = imageRequest.GetResponse();
                responseStream = imageResponse.GetResponseStream();
                studentPicture.Image =  Image.FromStream(responseStream);
                responseStream.Close();
                imageResponse.Close();
            }
            catch
            {
                studentPicture.Image = Properties.Resources.user;
            }
        }

        public Panel getSeriePanel()
        {
            return studentPanel;
        }

        private void changePanelFormat(Panel panel)
        {
            Rectangle rectangle = new Rectangle(0, 0, panel.Width, panel.Height);
            GraphicsPath roundedPanel = Transform.BorderRadius(rectangle, 13, true, true, true, true);
            panel.Region = new Region(roundedPanel);
        }
    }
} 