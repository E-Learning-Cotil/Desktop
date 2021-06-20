using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElearningDesktop
{
    public partial class Form5 : Form
    {

        #region Declaração de Variáveis
        StudentsApiResponse[] students;

        protected bool validData;
        protected string imageUrl = "";
        protected Image image;
        protected Thread getImageThread;
        protected PictureBox studentPicture;
        string path;

        string[] serieId;
        string[] serieName;

        Form1 parentForm = null;
        #endregion

        public Form5(Form1 parentForm)
        {
            InitializeComponent();

            this.ControlBox = false; //Ocultar barra superior
            this.BackColor = Styles.darkGray;
            this.ForeColor = Styles.white;
            this.parentForm = parentForm;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            filterPanelsPositions();
            filterButtonStyle();
            Filter.orderFilterElements(filterPanel);

            stylePlusButton();

            loadingMessageStyle();
        }
        
        private void filterButtonStyle()
        {
            filterButton.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints * 0.7));
            filterButton.Size = new Size(Convert.ToInt32(filterButtonPanel.Width * 0.830), Convert.ToInt32(filterButtonPanel.Height * 0.574));
            filterButton.Location = new Point(Convert.ToInt32(filterButtonPanel.Width / 2 - filterButton.Width / 2), Convert.ToInt32(filterButtonPanel.Height / 2 - filterButton.Height / 2));
            Rectangle rectangle = new Rectangle(0, 0, filterButton.Width, filterButton.Height);
            GraphicsPath roundedButton = Transform.BorderRadius(rectangle, 20, true, true, true, true);
            filterButton.Region = new Region(roundedButton);
        }

        private void filterPanelsPositions()
        {
            //Arruma posição e formato do panel com os filtros
            filterPanel.Size = new Size(Convert.ToInt32(this.Width * 0.263), Convert.ToInt32(this.Height * 0.825));
            filterPanel.Location = new Point(Convert.ToInt32(this.Width * 0.712), Convert.ToInt32(this.Height * 0.043));
            Rectangle rectangle = new Rectangle(0, 0, filterPanel.Width, filterPanel.Height);
            GraphicsPath roundedPanel = Transform.BorderRadius(rectangle, 20, true, true, false, false);
            filterPanel.Region = new Region(roundedPanel);

            //Arruma posição e formato do panel com o botão de filtrar
            filterButtonPanel.Location = new Point(filterPanel.Location.X, Convert.ToInt32(filterPanel.Height + filterPanel.Location.Y));
            filterButtonPanel.Size = new Size(Convert.ToInt32(this.Width * 0.263), Convert.ToInt32(this.Height * 0.103));
            rectangle = new Rectangle(0, 0, filterButtonPanel.Width, filterButtonPanel.Height);
            roundedPanel = Transform.BorderRadius(rectangle, 20, false, false, true, true);
            filterButtonPanel.Region = new Region(roundedPanel);

            //arruma posição da linha que separa os dois panels
            linePanel.Location = new Point(filterButtonPanel.Location.X, filterButtonPanel.Location.Y);
            linePanel.Size = new Size(filterButtonPanel.Width, 2);

            //POSIÇÃO DOS BOTOES DO FILTRO
            studentsPanel.Location = new Point(0, 2);
            studentsPanel.Size = new Size(Convert.ToInt32(this.Width * 0.673), this.Height - 4);
        }

        private void loadingMessageStyle()
        {
            loadingText.Font = Styles.defaultFont;

            loadingCircle1.Location = new Point(Convert.ToInt32((studentsPanel.Width / 2) - (loadingCircle1.Width / 2)), Convert.ToInt32(this.Height / 2 - loadingCircle1.Height / 2));

            loadingText.Location = new Point(Convert.ToInt32((studentsPanel.Width / 2) - (loadingText.Width / 2)) + 10, loadingCircle1.Location.Y - loadingText.Height - 10);
        }

        private void stylePlusButton()
        {
            plusButtonPictureBox.Size = new Size(Convert.ToInt32(this.Height * 0.083), Convert.ToInt32(this.Height * 0.083));

            plusButtonPictureBox.Location = new Point(Styles.seriesSize.Width + 20 - plusButtonPictureBox.Width, studentsPanel.Height - plusButtonPictureBox.Height - 7);

            Rectangle rectangle = new Rectangle(0, 0, plusButtonPictureBox.Width, plusButtonPictureBox.Height);

            GraphicsPath roundedButton = new GraphicsPath();
            roundedButton.StartFigure();
            roundedButton.AddArc(rectangle, 0, 360);
            roundedButton.CloseFigure();
            plusButtonPictureBox.Region = new Region(roundedButton);
        }

    }
}
