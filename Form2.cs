using Newtonsoft.Json;
using Refit;
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

        public Form2()
        {
            InitializeComponent();
            this.ControlBox = false; //Ocultar barra superior
            this.BackColor = Styles.darkGray;
            this.ForeColor = Styles.white; //cor da classe de estilos criada
        }

        private void filterButtonStyle()
        {
            button1.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints * 0.7));
            button1.Size = new Size(Convert.ToInt32(filterButtonPanel.Width * 0.830), Convert.ToInt32(filterButtonPanel.Height * 0.574));
            button1.Location = new Point(Convert.ToInt32(filterButtonPanel.Width/2 - button1.Width/2), Convert.ToInt32(filterButtonPanel.Height / 2 - button1.Height / 2));
            Rectangle rectangle = new Rectangle(0, 0, button1.Width, button1.Height);
            GraphicsPath roundedButton = Transform.BorderRadius(rectangle, 20, true, true, true, true);
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

            seriesPanel.Location = new Point(0, 7);
            seriesPanel.Size = new Size(Convert.ToInt32(this.Width * 0.673),this.Height);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Font = label2.Font = label3.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints * 0.875));
            label1.ForeColor = label2.ForeColor = label3.ForeColor = Styles.filterTitle;


            filterPosition();
            checkboxStyle();
            filterButtonStyle();
            
            createSerie();

        }

        private void checkboxStyle()
        {
            int checkBoxCount = filterPanel.Controls.OfType<CheckBox>().ToArray().Count();

            CheckBox[] checkBoxArray = filterPanel.Controls.OfType<CheckBox>().ToArray();

            Array.Reverse(checkBoxArray, 0, checkBoxCount); // inverte os elementos do array

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

        private async void createSerie()
        {
            try
            {
                var apiPath = RestService.For<ApiService>("https://elearning-tcc.herokuapp.com");
                var dataResponse = await apiPath.GetSeriesAsync();

                ApiResponse[] series = JsonConvert.DeserializeObject<ApiResponse[]>(dataResponse.ToString());

                if(series.Length == 0)
                {
                    Label noSeries = new Label();
                    noSeries.Text = "Não há turmas cadastradas!";
                    noSeries.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints));
                    noSeries.AutoSize = true;
                    noSeries.Location = new Point(20, 20);
                    seriesPanel.Controls.Add(noSeries);
                }
                else
                {
                    for (int i = 0; i < series.Length; i++)
                    {
                        ApiResponse serieData = series[i];
                        Series serie = new Series(serieData.Id, serieData.Curso, serieData.Tipo, serieData.Ano, serieData.Periodo);
                        seriesPanel.Controls.Add(serie.getSeriePanel());
                        seriesPanel.Size = new Size(seriesPanel.Width, seriesPanel.Height - 1);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na Consulta: " + ex.Message);
            }
        }

    }
}
