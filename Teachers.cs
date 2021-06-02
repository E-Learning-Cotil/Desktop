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
    class Teachers
    {
        private string teacherName;
        private string teacherTelephone;
        private string teacherEmail;
        private string teacherRG;
        private string teacherFoto;
        private Panel teacherPanel;

        public Teachers(string nome, string telefone, string email, string RG, string foto, int position)
        {
            teacherName = nome;
            teacherTelephone = telefone;
            teacherEmail = email;
            teacherRG = RG;
            teacherFoto = foto;

            teacherPanel = new Panel(); //cria uma div
            teacherPanel.Size = Styles.seriesSize; //define o tamanho da div
            teacherPanel.Location = new Point(20, 20 + (20 + Styles.seriesSize.Height) * (position)); // define a posição da div
            teacherPanel.BackColor = Styles.backgroundColor; //define a cor preta para fundo da div

            PictureBox teacherPicture = new PictureBox();

            teacherPicture.Image = Properties.Resources.logo;

            teacherPicture.Size = new Size(Convert.ToInt32(Styles.seriesSize.Width * 0.05), Convert.ToInt32(Styles.seriesSize.Height * 0.6));
            teacherPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            teacherPicture.Location = new Point(Convert.ToInt32(teacherPanel.Location.X + 2), Convert.ToInt32((teacherPanel.Size.Height / 2) - (teacherPicture.Size.Height / 2)));

            teacherPanel.Controls.Add(teacherPicture);//adiciona o pictureBox na div

            Label teacherNameLabel = new Label(); //cria a serie
            teacherNameLabel.Text = teacherName; //define o nome da serie
            teacherNameLabel.Font = Styles.defaultFont;//define a estilização do texto
            teacherNameLabel.AutoSize = true;
            teacherNameLabel.TextAlign = ContentAlignment.MiddleLeft; //alinha o texto ao centro(x) centro(y)
            teacherNameLabel.Location = new Point(Convert.ToInt32(teacherPicture.Location.X + teacherPicture.Size.Width + 10), Convert.ToInt32((teacherPanel.Size.Height / 2) - (teacherNameLabel.Font.Height / 2)));

            teacherPanel.Controls.Add(teacherNameLabel);//adiciona o label na div

            Label telephoneNumber = new Label();
            telephoneNumber.Text = teacherTelephone;
            telephoneNumber.Font = Styles.customFont;//define a estilização do texto

            telephoneNumber.AutoSize = true;
            telephoneNumber.TextAlign = ContentAlignment.MiddleLeft;

            telephoneNumber.Location = new Point(teacherPanel.Width - Convert.ToInt32(telephoneNumber.Text.Length * 20) - 10, Convert.ToInt32((teacherPanel.Size.Height / 2) - 15 - (telephoneNumber.Font.Height / 2)));
            teacherPanel.Controls.Add(telephoneNumber);

            Label emailAddress = new Label();
            emailAddress.Text = teacherEmail;
            emailAddress.Font = Styles.customFont;//define a estilização do texto

            emailAddress.AutoSize = true;
            emailAddress.TextAlign = ContentAlignment.MiddleLeft;

            emailAddress.Location = new Point(teacherPanel.Width + emailAddress.Width - Convert.ToInt32(emailAddress.Text.Length * 20) - 10, Convert.ToInt32(teacherPanel.Size.Height / 2) - 5);
            teacherPanel.Controls.Add(emailAddress);

            changePanelFormat(teacherPanel);//arredonda cada div
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
