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
    class Teachers
    {
        private string teacherName;
        private string teacherTelephone;
        private string teacherEmail;
        private string teacherRG;
        private string teacherFoto;
        private Panel teacherPanel;
        private Thread getImageThread;
        private PictureBox teacherPicture = new PictureBox();

        public Teachers(string nome, string telefone, string email, string RG, string foto, int position)
        {
            #region Atributos

            string[] words = nome.Trim().Split(' ');
            if(words.Length > 1) nome = words[0] + " " + words[words.Length - 1];
            teacherName = nome;
            teacherTelephone = telefone;
            teacherEmail = email;
            teacherRG = RG;
            teacherFoto = foto;

            #endregion

            #region Div Principal

            teacherPanel = new Panel(); //cria uma div
            teacherPanel.Size = Styles.seriesSize; //define o tamanho da div
            teacherPanel.Location = new Point(20, 20 + (20 + Styles.seriesSize.Height) * (position)); // define a posição da div
            teacherPanel.BackColor = Styles.backgroundColor; //define a cor preta para fundo da div

            #endregion

            #region Nome

            Label teacherNameLabel = new Label(); //cria a serie
            teacherNameLabel.Text = teacherName; //define o nome da serie
            teacherNameLabel.Font = Styles.defaultFont;//define a estilização do texto
            teacherNameLabel.AutoSize = true;
            teacherNameLabel.TextAlign = ContentAlignment.MiddleLeft; //alinha o texto ao centro(x) centro(y)
            teacherNameLabel.Location = new Point(Convert.ToInt32(teacherPicture.Location.X + teacherPicture.Size.Width + 10), Convert.ToInt32((teacherPanel.Size.Height / 2) - (teacherNameLabel.Font.Height / 2)));


            teacherPanel.Controls.Add(teacherNameLabel);//adiciona o label na div

            #endregion

            #region Telefone

            Label telephoneNumber = new Label();
            telephoneNumber.Text = teacherTelephone;
            telephoneNumber.Font = Styles.customFont;//define a estilização do texto

            telephoneNumber.Size = new Size(255, telephoneNumber.Font.Height);

            telephoneNumber.TextAlign = ContentAlignment.TopRight;

            telephoneNumber.Location = new Point(teacherPanel.Width - telephoneNumber.Width, Convert.ToInt32((teacherPanel.Size.Height / 2) - 15 - (telephoneNumber.Font.Height / 2)));
            
            teacherPanel.Controls.Add(telephoneNumber);

            #endregion

            #region Email

            Label emailAddress = new Label();
            emailAddress.Text = teacherEmail;
            emailAddress.Font = Styles.customFont;//define a estilização do texto

            emailAddress.TextAlign = ContentAlignment.BottomRight;

            emailAddress.Size = new Size(510, emailAddress.Font.Height + 5);

            emailAddress.Location = new Point(teacherPanel.Width - emailAddress.Width, Convert.ToInt32(teacherPanel.Size.Height / 2) - 5);
            teacherPanel.Controls.Add(emailAddress);

            #endregion

            #region Imagem

            getImageThread = new Thread(new ThreadStart(getImage));
            getImageThread.Start();

            teacherPicture.Size = new Size(Convert.ToInt32(Styles.seriesSize.Width * 0.05), Convert.ToInt32(Styles.seriesSize.Height * 0.6));
            teacherPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            teacherPicture.Location = new Point(Convert.ToInt32(teacherPanel.Location.X + 2), Convert.ToInt32((teacherPanel.Size.Height / 2) - (teacherPicture.Size.Height / 2)));

            Rectangle rectangle = new Rectangle(0, 0, teacherPicture.Width, teacherPicture.Height);
            GraphicsPath roundedImage = Transform.BorderRadius(rectangle, 20, true, true, true, true);
            teacherPicture.Region = new Region(roundedImage);

            teacherPanel.Controls.Add(teacherPicture);//adiciona o pictureBox na div

            #endregion

            changePanelFormat(teacherPanel);//arredonda a div
        }
        
        private void getImage()
        {
            try
            {
                WebResponse imageResponse = null;
                Stream responseStream;
                HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(teacherFoto);
                imageResponse = imageRequest.GetResponse();
                responseStream = imageResponse.GetResponseStream();
                teacherPicture.Image =  Image.FromStream(responseStream);
                responseStream.Close();
                imageResponse.Close();
            }
            catch
            {
                teacherPicture.Image = Properties.Resources.user;
            }
        }

        public Panel getSeriePanel()
        {
            return teacherPanel;
        }

        private void changePanelFormat(Panel panel)
        {
            Rectangle rectangle = new Rectangle(0, 0, panel.Width, panel.Height);
            GraphicsPath roundedPanel = Transform.BorderRadius(rectangle, 13, true, true, true, true);
            panel.Region = new Region(roundedPanel);
        }
    }
} 