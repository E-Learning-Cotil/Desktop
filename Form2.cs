using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            this.ForeColor = Styles.white; //cor da classe de cores criada
            seriesCounter = 0;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
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
            this.Controls.Add( createSerie() );
            this.Controls.Add(createSerie());
            this.Controls.Add(createSerie());
            this.Controls.Add(createSerie());
            this.Controls.Add(createSerie());
        }

        private Panel createSerie()
        {
            Panel serie = new Panel();
            serie.Size = Styles.seriesSize;

            serie.Location = new Point(20, 20 + (20 + Styles.seriesSize.Height) * seriesCounter);

            serie.BackColor = Styles.backgroundColor;

            Label classroom = new Label();
            classroom.Text = "INF Diurno";
            classroom.Font = Styles.buttonFont;
            classroom.Size = new Size(Convert.ToInt32(classroom.Text.Length * Styles.buttonFontSize),Convert.ToInt32(Styles.buttonFontSize * 2));
            classroom.TextAlign = ContentAlignment.MiddleLeft;

            changePanelFormat(serie);

            serie.Controls.Add(classroom);

            seriesCounter++;
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
