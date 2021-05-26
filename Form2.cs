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
        Button selectedSeries = null;
        Button selectedShift = null;
        Button selectedCourse = null;
        Button selectedType = null;
        string curso = null, tipo = null, ano = null, periodo = null;
        ApiResponse[] series;

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

        private void loadingMessageStyle()
        {
            loadingText.Font = Styles.defaultFont;
            
            loadingCircle1.Location = new Point(Convert.ToInt32((seriesPanel.Width/2) - (loadingCircle1.Width/2)), Convert.ToInt32(this.Height / 2 - loadingCircle1.Height / 2));
            
            loadingText.Location = new Point(Convert.ToInt32((seriesPanel.Width / 2) - (loadingText.Width / 2)) + 10, loadingCircle1.Location.Y - loadingText.Height - 10);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            serieTitle.Font = turnoTitle.Font = cursoTitle.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints * 0.875));
            serieTitle.ForeColor = turnoTitle.ForeColor = cursoTitle.ForeColor = tipoTitle.ForeColor = Styles.filterTitle;


            filterPosition();
            checkboxStyle();
            filterButtonStyle();

            stylePlusButton();

            loadingMessageStyle();

            listSeries(null);

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
            int heightNeeded = filterPanel.Location.Y - 20;

            Button[] buttonArray = filterPanel.Controls.OfType<Button>().Reverse().ToArray();
            Label[] labelArray = filterPanel.Controls.OfType<Label>().Reverse().ToArray();

            int buttonCount = buttonArray.Count();
            int labelCount = labelArray.Count();

            #region Carregando Button Array
            string[] buttonNameArray = new string[buttonCount];

            for (int i = 0; i < buttonCount; i++)
            {
                 buttonNameArray[i] = buttonArray[i].Name;
            }
            
            Array.Sort(buttonNameArray);

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
                if (labelArray[i].Name.ToUpper().Contains("TITLE"))
                {
                    labelArray[i].Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints * 0.650));
                }
            }

            for (int i = 0; i < buttonCount; i++)
            {

                switch (i)
                {
                    case 0:
                        labelArray[0].Location = new Point(10, heightNeeded);
                        heightNeeded += labelArray[0].Height + 10;
                        break;
                    case 3:
                        labelArray[1].Location = new Point(10, heightNeeded);
                        heightNeeded += labelArray[1].Height + 10;
                        break;
                    case 5:
                        labelArray[2].Location = new Point(10, heightNeeded);
                        heightNeeded += labelArray[2].Height + 10;
                        break;
                    case 11:
                        labelArray[16].Location = new Point(10, heightNeeded);
                        heightNeeded += labelArray[3].Height + 10;
                        break;
                }

                buttonArray[i].BackColor = Styles.white;
                buttonArray[i].Text = "";

                buttonArray[i].Size = new Size(25, 27);

                Rectangle rectangle = new Rectangle(0, 0, buttonArray[i].Width, buttonArray[i].Height);
                GraphicsPath roundedButton = Transform.BorderRadius(rectangle, 12, true, true, true, true);
                buttonArray[i].Region = new Region(roundedButton);

                buttonArray[i].Location = new Point(10, heightNeeded);
                
                if ((i+3 <= labelCount)) labelArray[i + 3].Location = new Point(10 + buttonArray[i].Width + 5, heightNeeded);

                heightNeeded += buttonArray[i].Height + 5;
            } //FIM DO FOR
        }

        private async void listSeries(QueryParameters filters)
        {
            try
            {
                var apiPath = RestService.For<ApiService>(Routes.baseUrl);
                if(filters == null)
                {
                    var dataResponse = await apiPath.GetSeriesAsync();
                    series = JsonConvert.DeserializeObject<ApiResponse[]>(dataResponse.ToString());
                }
                else
                {
                    var dataResponse = await apiPath.GetSeriesFilteredAsync(filters);
                    series = JsonConvert.DeserializeObject<ApiResponse[]>(dataResponse.ToString());
                }

                loadingText.Visible = false;
                loadingCircle1.Visible = false;
                

                if(series.Length == 0)
                {
                    Label noSeries = new Label();
                    noSeries.Name = "noSeries";
                    noSeries.Text = "Não há séries cadastradas!";
                    noSeries.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints));
                    noSeries.AutoSize = true;
                    noSeries.Location = new Point(20,20);
                    seriesPanel.Controls.Add(noSeries);
                }
                else
                {
                    for (int i = 0; i < series.Length; i++)
                    {
                        ApiResponse serieData = series[i];

                        Series serie = new Series(serieData.Id, serieData.Curso, serieData.Tipo, serieData.Ano, serieData.Periodo, serieData.Sigla, serieData._count.Turmas,i);
                        seriesPanel.Controls.Add(serie.getSeriePanel());
                        seriesPanel.Size = new Size(seriesPanel.Width, seriesPanel.Height - 1);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro durante a conexão com a base de dados. " + ex.Message);
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
            ano = "1";
            activeSerieFilter(button02);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ano = "2";
            activeSerieFilter(button03);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ano = "3";
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
            periodo = "DIURNO";
            activeShiftFilter(button05);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            periodo = "NOTURNO";
            activeShiftFilter(button06);
        }

        #endregion

        #region Filtro dos Cursos

        private void activeCourseFilter(Button sourceButton)
        {
            if (selectedCourse != null) selectedCourse.BackgroundImage = Properties.Resources.Rectangle_247;
            selectedCourse = sourceButton;
            selectedCourse.ImageAlign = ContentAlignment.MiddleCenter;
            selectedCourse.BackgroundImage = Properties.Resources.Group_21;
            selectedCourse.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            curso = "EDIFICACOES";
            activeCourseFilter(button07);
        }

        private void button08_Click(object sender, EventArgs e)
        {
            curso = "ENFERMAGEM";
            activeCourseFilter(button08);
        }

        private void button09_Click(object sender, EventArgs e)
        {
            curso = "INFORMATICA";
            activeCourseFilter(button09);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            curso = "GEODESIA";
            activeCourseFilter(button10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            curso = "MECANICA";
            activeCourseFilter(button11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            curso = "QUALIDADE";
            activeCourseFilter(button12);
        }
        #endregion

        #region Filtro dos Tipo

        private void activeTypeFilter(Button sourceButton)
        {
            if (selectedType != null) selectedType.BackgroundImage = Properties.Resources.Rectangle_247;
            selectedType = sourceButton;
            selectedType.ImageAlign = ContentAlignment.MiddleCenter;
            selectedType.BackgroundImage = Properties.Resources.Group_21;
            selectedType.BackgroundImageLayout = ImageLayout.Stretch;
        }


        private void button13_Click(object sender, EventArgs e)
        {
            tipo = "TECNICO";
            activeTypeFilter(button13);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tipo = "MEDIOTECNICO";
            activeTypeFilter(button14);
        }
        #endregion

        private void filterButton_Click(object sender, EventArgs e)
        {
            int itemsCount = seriesPanel.Controls.Count;
            for (int i = itemsCount - 1; i > 0; i--)
            {
                if (seriesPanel.Controls[i].Name == "noSeries")
                {
                    seriesPanel.Controls.Remove(seriesPanel.Controls[i]);
                    continue;
                }

                Type objectType = seriesPanel.Controls[i].GetType();

                if (objectType == typeof(Panel))
                {
                    seriesPanel.Controls.Remove(seriesPanel.Controls[i]);
                    itemsCount--;
                }
            }

            loadingText.Visible = true;
            loadingCircle1.Visible = true;

            QueryParameters filters = new QueryParameters();
            filters.curso = curso;
            filters.ano = ano;
            filters.periodo = periodo;
            filters.tipo = tipo;
            
            listSeries(filters);
        }

    }
}
