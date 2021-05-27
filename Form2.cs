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

        string[] courses = { "EDIFICACOES", "ENFERMAGEM", "GEODESIA", "INFORMATICA", "MECANICA", "QUALIDADE" };
        string[] coursesName = { "Edificações", "Enfermagem", "Geodésia", "Informática", "Mecânica", "Qualidade" };

        string[] type = { "TECNICO", "MEDIOTECNICO" };
        string[] typeName = { "Curso Técnico", "Médio + Técnico" };

        string[] serie = { "1", "2", "3" };
        string[] serieName = { "1º ano", "2º ano", "3º ano" };

        string[] period = { "DIURNO", "NOTURNO" };
        string[] periodName = { "Diurno", "Noturno" };

        ApiResponse[] series;

        Form1 parentForm = null;

        public Form2(Form1 parentForm)
        {
            InitializeComponent();
            this.ControlBox = false; //Ocultar barra superior
            this.BackColor = Styles.darkGray;
            this.ForeColor = Styles.white; //cor da classe de estilos criada
            this.parentForm = parentForm;
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
            if (selectedSeries != null)
            {
                if (sourceButton == selectedSeries)
                {
                    ano = null;
                    selectedSeries.BackgroundImage = Properties.Resources.Rectangle_247;
                    selectedSeries = null;
                    return;
                }
            }

            selectedSeries = sourceButton;
            selectedSeries.ImageAlign = ContentAlignment.MiddleCenter;
            selectedSeries.BackgroundImageLayout = ImageLayout.Stretch;
            selectedSeries.BackgroundImage = Properties.Resources.Group_21;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ano = serie[0];
            activeSerieFilter(button02);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ano = serie[1];
            activeSerieFilter(button03);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ano = serie[2];
            activeSerieFilter(button04);
        }
        #endregion

        #region Filtro dos Turnos
        private void activeShiftFilter(Button sourceButton)
        {
            if (selectedShift != null)
            {
                selectedShift.BackgroundImage = Properties.Resources.Rectangle_247;
                if (sourceButton == selectedShift)
                {
                    periodo = null;
                    selectedShift.BackgroundImage = Properties.Resources.Rectangle_247;
                    selectedShift = null;
                    return;
                }
            }

            selectedShift = sourceButton;
            selectedShift.ImageAlign = ContentAlignment.MiddleCenter;
            selectedShift.BackgroundImageLayout = ImageLayout.Stretch;
            selectedShift.BackgroundImage = Properties.Resources.Group_21;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            periodo = period[0];
            activeShiftFilter(button05);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            periodo = period[1];
            activeShiftFilter(button06);
        }

        #endregion

        #region Filtro dos Cursos
        private void activeCourseFilter(Button sourceButton)
        {
            if (selectedCourse != null)
            {
                selectedCourse.BackgroundImage = Properties.Resources.Rectangle_247;
                if (sourceButton == selectedCourse)
                {
                    curso = null;
                    selectedCourse.BackgroundImage = Properties.Resources.Rectangle_247;
                    selectedCourse = null;
                    return;
                }
            }

            selectedCourse = sourceButton;
            selectedCourse.ImageAlign = ContentAlignment.MiddleCenter;
            selectedCourse.BackgroundImageLayout = ImageLayout.Stretch;
            selectedCourse.BackgroundImage = Properties.Resources.Group_21;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            curso = courses[0];
            activeCourseFilter(button07);
        }

        private void button08_Click(object sender, EventArgs e)
        {
            curso = courses[1];
            activeCourseFilter(button08);
        }

        private void button09_Click(object sender, EventArgs e)
        {
            curso = courses[2];
            activeCourseFilter(button09);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            curso = courses[3];
            activeCourseFilter(button10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            curso = courses[4];
            activeCourseFilter(button11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            curso = courses[5];
            activeCourseFilter(button12);
        }
        #endregion

        #region Filtro dos Tipo

        private void activeTypeFilter(Button sourceButton)
        {
            if (selectedType != null)
            {
                selectedType.BackgroundImage = Properties.Resources.Rectangle_247;
                if (sourceButton == selectedType)
                {
                    tipo = null;
                    selectedType.BackgroundImage = Properties.Resources.Rectangle_247;
                    selectedType = null;
                    return;
                }
            } 
            
            selectedType = sourceButton;
            selectedType.ImageAlign = ContentAlignment.MiddleCenter;
            selectedType.BackgroundImageLayout = ImageLayout.Stretch;
            selectedType.BackgroundImage = Properties.Resources.Group_21;
        }


        private void button13_Click(object sender, EventArgs e)
        {
            tipo = type[0];
            activeTypeFilter(button13);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tipo = type[1];
            activeTypeFilter(button14);
        }
        #endregion

        #region Botão Criar Série

        private Panel styleCreationPanel()
        {
            Panel panel = new Panel();

            panel.Size = Styles.creationPanelSize;
            panel.Location = new Point(Convert.ToInt32(parentForm.Width / 2 - panel.Width / 2), Convert.ToInt32(parentForm.Height / 2 - panel.Height / 2));
            panel.BackColor = Styles.secondaryColor;

            Rectangle rectangle = new Rectangle(0, 0, panel.Width, panel.Height);
            GraphicsPath roundedPanel = Transform.BorderRadius(rectangle, 25, true, true, true, true);
            panel.Region = new Region(roundedPanel);

            return panel;
        }

        private void finishSerieCreation_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < parentForm.Controls.Count;i++)
            {
                if (parentForm.Controls[i].Name == "creationSeriePanel")
                {
                    parentForm.Controls.Remove(parentForm.Controls[i]);
                    break;
                }
            }
        }



        private void plusButtonPictureBox_Click(object sender, EventArgs e)
        {

            Panel creationSeriePanel = styleCreationPanel();
            creationSeriePanel.Name = "creationSeriePanel";
            parentForm.Controls.Add(creationSeriePanel);
            creationSeriePanel.BringToFront();
            //fim do panel

            Button finishSerieCreation = new Button();

            finishSerieCreation.Font = Styles.customFont;
            finishSerieCreation.Text = "Finalizar";
            finishSerieCreation.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.117), Convert.ToInt32(Styles.formSize.Height * 0.042));

            Rectangle rectangle = new Rectangle(0, 0, finishSerieCreation.Width, finishSerieCreation.Height);
            GraphicsPath roundedButton = Transform.BorderRadius(rectangle, 25, true, true, true, true);
            finishSerieCreation.Region = new Region(roundedButton);

            finishSerieCreation.Location = new Point(creationSeriePanel.Width - finishSerieCreation.Width - 20, creationSeriePanel.Height - finishSerieCreation.Height - 20);
            finishSerieCreation.FlatStyle = FlatStyle.Flat;

            finishSerieCreation.ForeColor = Color.Black;
            finishSerieCreation.BackColor = Styles.white;
;
            finishSerieCreation.Click += new EventHandler(this.finishSerieCreation_Click);

            creationSeriePanel.Controls.Add(finishSerieCreation);
            //fim do botão

            Label labelTitle = new Label();
            labelTitle.Text = "Adicionar nova série:";
            labelTitle.Location = new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), Convert.ToInt32(Styles.formSize.Height * 0.065));
            labelTitle.Font = Styles.defaultFont;
            labelTitle.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.217), Convert.ToInt32(Styles.formSize.Height * 0.039)) ;
            creationSeriePanel.Controls.Add(labelTitle);
            //fim do titulo

            Label labelAno = new Label();
            labelAno.Name = "labelAno";
            labelAno.Text = "Ano: ";
            labelAno.Font = Styles.customFont;
            labelAno.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.034), Convert.ToInt32(Styles.formSize.Height * 0.029)) ;
            labelAno.Location = new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), Convert.ToInt32(Styles.formSize.Height * 0.129));
            creationSeriePanel.Controls.Add(labelAno);

            ComboBox comboBoxAno = new ComboBox();

            comboBoxAno.Name = "comboBoxAno";

            comboBoxAno.Font = new Font(Styles.customFont.FontFamily, Convert.ToInt32((Styles.formSize.Height * 0.039) / 3));
            comboBoxAno.FlatStyle = FlatStyle.Flat;
            comboBoxAno.BackColor = Styles.backgroundColor;
            comboBoxAno.ForeColor = Styles.white;

            comboBoxAno.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.55),Convert.ToInt32(Styles.formSize.Height * 0.039));
            comboBoxAno.Location = new Point(labelAno.Location.X, labelAno.Location.Y + labelAno.Height + 10);

            comboBoxAno.Items.AddRange(serieName);

            rectangle = new Rectangle(2, 2, comboBoxAno.Width - 20, comboBoxAno.Height - 3);
            GraphicsPath roundedCheckBox = Transform.BorderRadius(rectangle, 2, true, false, false, true);
            comboBoxAno.Region = new Region(roundedCheckBox);

            creationSeriePanel.Controls.Add(comboBoxAno);

            Button checkBoxAnoButton = new Button();
            checkBoxAnoButton.FlatStyle = FlatStyle.Flat;
            checkBoxAnoButton.FlatAppearance.BorderSize = 0;
            checkBoxAnoButton.BackgroundImage = Properties.Resources.seta;
            checkBoxAnoButton.ImageAlign = ContentAlignment.MiddleCenter;
            checkBoxAnoButton.BackgroundImageLayout = ImageLayout.Center;
            checkBoxAnoButton.BackColor = Styles.backgroundColor;
            checkBoxAnoButton.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.018), comboBoxAno.Height - 1);

            rectangle = new Rectangle(0, 2, checkBoxAnoButton.Width - 1, checkBoxAnoButton.Height - 1);
            roundedButton = Transform.BorderRadius(rectangle, 5, false, true, true, false);
            checkBoxAnoButton.Region = new Region(roundedButton);

            checkBoxAnoButton.Location = new Point(comboBoxAno.Location.X + comboBoxAno.Width - 21, comboBoxAno.Location.Y);

            checkBoxAnoButton.Click += new EventHandler(showAnoComboBox_Click);

            creationSeriePanel.Controls.Add(checkBoxAnoButton);
            //fim do ano

            Label labelCurso = new Label();
            labelCurso.Text = "Curso: ";
            labelCurso.Font = Styles.customFont;
            labelCurso.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.048), Convert.ToInt32(Styles.formSize.Height * 0.029)) ;
            labelCurso.Location = new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), Convert.ToInt32(Styles.formSize.Height * 0.209));
            creationSeriePanel.Controls.Add(labelCurso);

            ComboBox comboBoxCurso = new ComboBox();

            comboBoxCurso.Name = "comboBoxCurso";

            comboBoxCurso.Font = new Font(Styles.customFont.FontFamily, Convert.ToInt32((Styles.formSize.Height * 0.039) / 3));
            comboBoxCurso.FlatStyle = FlatStyle.Flat;
            comboBoxCurso.BackColor = Styles.backgroundColor;
            comboBoxCurso.ForeColor = Styles.white;

            comboBoxCurso.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.55), Convert.ToInt32(Styles.formSize.Height * 0.039));
            comboBoxCurso.Location = new Point(labelCurso.Location.X, labelCurso.Location.Y + labelCurso.Height + 10);

            comboBoxCurso.Items.AddRange(coursesName);

            rectangle = new Rectangle(2, 2, comboBoxCurso.Width - 20, comboBoxCurso.Height - 3);
            roundedCheckBox = Transform.BorderRadius(rectangle, 2, true, false, false, true);
            comboBoxCurso.Region = new Region(roundedCheckBox);

            creationSeriePanel.Controls.Add(comboBoxCurso);

            Button checkBoxCursoButton = new Button();
            checkBoxCursoButton.FlatStyle = FlatStyle.Flat;
            checkBoxCursoButton.FlatAppearance.BorderSize = 0;
            checkBoxCursoButton.BackgroundImage = Properties.Resources.seta;
            checkBoxCursoButton.ImageAlign = ContentAlignment.MiddleCenter;
            checkBoxCursoButton.BackgroundImageLayout = ImageLayout.Center;
            checkBoxCursoButton.BackColor = Styles.backgroundColor;
            checkBoxCursoButton.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.018), comboBoxCurso.Height - 1);

            rectangle = new Rectangle(0, 2, checkBoxCursoButton.Width - 1, checkBoxCursoButton.Height - 1);
            roundedButton = Transform.BorderRadius(rectangle, 5, false, true, true, false);
            checkBoxCursoButton.Region = new Region(roundedButton);

            checkBoxCursoButton.Location = new Point(comboBoxCurso.Location.X + comboBoxCurso.Width - 21, comboBoxCurso.Location.Y);

            checkBoxCursoButton.Click += new EventHandler(showCursoComboBox_Click);

            creationSeriePanel.Controls.Add(checkBoxCursoButton);
            //fim do curso

            Label labelPeriodo = new Label();
            labelPeriodo.Text = "Periodo: ";
            labelPeriodo.Font = Styles.customFont;
            labelPeriodo.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.063), Convert.ToInt32(Styles.formSize.Height * 0.029)) ;
            labelPeriodo.Location = new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), Convert.ToInt32(Styles.formSize.Height * 0.285));
            creationSeriePanel.Controls.Add(labelPeriodo);

            ComboBox comboBoxPeriodo = new ComboBox();
            //fim do tipo

            Label labelTipo = new Label();
            labelTipo.Text = "Tipo: ";
            labelTipo.Font = Styles.customFont;
            labelTipo.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.037), Convert.ToInt32(Styles.formSize.Height * 0.029));
            labelTipo.Location = new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), Convert.ToInt32(Styles.formSize.Height * 0.359));
            creationSeriePanel.Controls.Add(labelTipo);

            ComboBox comboBoxTipo = new ComboBox();

        }

        #endregion

        private void showCursoComboBox_Click(object sender, EventArgs e)
        {
            int itemsCount = parentForm.Controls.Count;
            Panel creationPanel = new Panel();
            for (int i = itemsCount - 1; i >= 0; i--)
            {
                if (parentForm.Controls[i].Name == "creationSeriePanel")
                {
                    creationPanel = (Panel)parentForm.Controls[i];
                    break;
                }
            }
            for (int i = creationPanel.Controls.Count - 1; i > 0; i--)
            {
                if (creationPanel.Controls[i].Name == "comboBoxCurso")
                {
                    ((ComboBox)creationPanel.Controls[i]).Focus();
                    ((ComboBox)creationPanel.Controls[i]).DroppedDown = true;
                    break;
                }
            }
        }
        private void showAnoComboBox_Click(object sender, EventArgs e)
        {

            int itemsCount = parentForm.Controls.Count;
            Panel creationPanel = new Panel();
            for (int i = itemsCount - 1; i >= 0; i--)
            {
                if (parentForm.Controls[i].Name == "creationSeriePanel")
                {
                    creationPanel = (Panel)parentForm.Controls[i];
                    break;
                }
            }
            for (int i = creationPanel.Controls.Count - 1; i > 0; i--)
            {
                if (creationPanel.Controls[i].Name == "comboBoxAno")
                {
                    ((ComboBox)creationPanel.Controls[i]).Focus();
                    ((ComboBox)creationPanel.Controls[i]).DroppedDown = true;
                    break;
                }
            }
        }

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