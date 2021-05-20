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
        Button selectedSeries;
        Button selectedShift;
        Button selectedCourse;

        public Form2()
        {
            InitializeComponent();
            this.ControlBox = false; //Ocultar barra superior
            this.BackColor = Styles.darkGray;
            this.ForeColor = Styles.white; //cor da classe de estilos criada
        }

        private void filterButtonStyle()
        {
            filterButton.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints * 0.7));
            filterButton.Size = new Size(Convert.ToInt32(filterButtonPanel.Width * 0.830), Convert.ToInt32(filterButtonPanel.Height * 0.574));
            filterButton.Location = new Point(Convert.ToInt32(filterButtonPanel.Width/2 - filterButton.Width/2), Convert.ToInt32(filterButtonPanel.Height / 2 - filterButton.Height / 2));
            Rectangle rectangle = new Rectangle(0, 0, filterButton.Width, filterButton.Height);
            GraphicsPath roundedButton = Transform.BorderRadius(rectangle, 20, true, true, true, true);
            filterButton.Region = new Region(roundedButton);
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

            stylePlusButton();

            createSerie();

        }

        private void stylePlusButton()
        {
            plusButtonPictureBox.Size = new Size(Convert.ToInt32(this.Height * 0.083), Convert.ToInt32(this.Height * 0.083));

            plusButtonPictureBox.Location = new Point(Convert.ToInt32(seriesPanel.Width - plusButtonPictureBox.Width), Convert.ToInt32(seriesPanel.Height - (plusButtonPictureBox.Height + 20)));

            Rectangle rectangle = new Rectangle(0, 0, plusButtonPictureBox.Width, plusButtonPictureBox.Height);
            GraphicsPath roundedButton = Transform.BorderRadius(rectangle, 60, true, true, true, true);
            plusButtonPictureBox.Region = new Region(roundedButton);
        }

        private void checkboxStyle()
        {
            int heightNeeded = filterPanel.Location.Y;

            Button[] buttonArray = filterPanel.Controls.OfType<Button>().Reverse().ToArray();
            Label[] labelArray = filterPanel.Controls.OfType<Label>().Reverse().ToArray();

            int buttonCount = buttonArray.Count();
            int labelCount = labelArray.Count();

            string[] buttonNameArray = new string[buttonCount];

            for (int i = 0; i < buttonCount; i++)
            {
                 buttonNameArray[i] = buttonArray[i].Name;
            }
            
            Array.Sort(buttonNameArray);

            #region Carregando Button Array
            for (int i = 0; i < buttonCount; i++)
            {
                if (buttonArray[i].Name != buttonNameArray[i])
                    for(int j = 0;j < buttonCount; j++)
                    {
                        if(buttonArray[j].Name == buttonNameArray[i])
                        {
                            Button x = buttonArray[i];
                            buttonArray[i] = buttonArray[j];
                            buttonArray[j] = x;
                        }
                    }
            }
            #endregion


            for (int i = 0; i < labelCount; i++)
            {
                labelArray[i].Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints * 0.5));
            }

            for (int i = 0; i < buttonCount; i++)
            {
                switch (i)
                {
                    case 0:
                        labelArray[0].Location = new Point(10, heightNeeded);
                        labelArray[0].Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints * 0.650));
                        heightNeeded += labelArray[0].Height + 10;
                        break;
                    case 3:
                        labelArray[1].Location = new Point(10, heightNeeded);
                        labelArray[1].Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints * 0.650));
                        heightNeeded += labelArray[1].Height + 10;
                        break;
                    case 6:
                        labelArray[2].Location = new Point(10, heightNeeded);
                        labelArray[2].Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints * 0.650));
                        heightNeeded += labelArray[2].Height + 10;
                        break;
                }


                buttonArray[i].BackColor = Styles.white;
                buttonArray[i].Text = "";

                buttonArray[i].Size = new Size(25, 27);

                Rectangle rectangle = new Rectangle(0, 0, buttonArray[i].Width, buttonArray[i].Height);
                GraphicsPath roundedButton = Transform.BorderRadius(rectangle, 12, true, true, true, true);
                buttonArray[i].Region = new Region(roundedButton);

                buttonArray[i].Location = new Point(10, heightNeeded);

                if(i+3 <= labelCount)
                    labelArray[i +3].Location = new Point(10 + buttonArray[i].Width + 5, heightNeeded); 

                heightNeeded += buttonArray[i].Height + 5;
                MessageBox.Show(buttonArray[i].Name);
            } //FIM DO FOR
        }

        private async void createSerie()
        {
            try
            {
                var apiPath = RestService.For<ApiService>("https://elearning-tcc.herokuapp.com");
                //var apiPath = RestService.For<ApiService>("http://50f46cb72afc.ngrok.io"); // rota de teste
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
                        //Count count = JsonConvert.DeserializeObject<Count>(serieData._count.ToString());

                        Series serie = new Series(serieData.Id, serieData.Curso, serieData.Tipo, serieData.Ano, serieData.Periodo, serieData.Sigla, serieData._count.Turmas);
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

        #region Filtro das Series
        private void activeSerieFilter(Button sourceButton)
        {
            if(selectedSeries != null) selectedSeries.BackgroundImage = Properties.Resources.Rectangle_247;
            selectedSeries = sourceButton;
            selectedSeries.ImageAlign = ContentAlignment.MiddleCenter;
            selectedSeries.BackgroundImage = Properties.Resources.Group_21;
            selectedSeries.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            activeSerieFilter(button02);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            activeSerieFilter(button03);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            activeSerieFilter(button04);
        }
        #endregion

        #region Filtro dos Turnos
        private void activeShiftFilter(Button sourceButton)
        {
            if (selectedShift != null) selectedShift.BackgroundImage = Properties.Resources.Rectangle_247;
            selectedShift = sourceButton;
            selectedShift.ImageAlign = ContentAlignment.MiddleCenter;
            selectedShift.BackgroundImage = Properties.Resources.Group_21;
            selectedShift.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            activeShiftFilter(button05);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            activeShiftFilter(button06);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            activeShiftFilter(button07);
        }
        #endregion
    }
}
