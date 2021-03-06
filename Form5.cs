using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElearningDesktop
{
    public partial class Form5 : Form
    {


        #region Declaração de Variáveis
        TurmasApiResponse[] turmas;

        SeriesApiResponse[] series;
        SeriesApiResponse filterSelectedSerie;
        List<string> siglaSerieList;
        List<int> idSerieList;
        List<IconsFormat> iconsList = new List<IconsFormat>();

        TeachersApiResponse[] teachers;
        TeachersApiResponse filterSelectedTeacher;
        List<string> siglaTeacherList;
        List<string> rgTeacherList;
        Panel selectedColorIcon;
        Panel iconSelectionPanel;
        Panel colorSelectionPanel;

        protected bool validData;
        protected int? selectedIcon;
        protected int currentIcon = 0;
        protected int currentColor = 0;
        protected int? selectedColor;
        protected Image iconResponse;
        protected Image image;
        protected Thread getImageThread;
        protected PictureBox turmaPicture1 = new PictureBox();
        protected PictureBox turmaPicture2 = new PictureBox();
        protected PictureBox iconPanelPictureBox = new PictureBox();
        protected PictureBox colorPanelPictureBox = new PictureBox();
        protected Panel primaryColor;
        protected Panel secondaryColor;
        protected PictureBox userSelectIcon = new PictureBox();
        protected Panel colorPanel;


        string path;

        ColorsApiResponse[] colors;
        IconsApiResponse[] icons;

        Form1 parentForm = null;
        #endregion

        public Form5(Form1 parentForm)
        {
            InitializeComponent();

            this.ControlBox = false; //Ocultar barra superior
            this.BackColor = Styles.darkGray;
            this.ForeColor = Styles.white;
            this.parentForm = parentForm;

            filterSelectedSerie = null;
            filterSelectedTeacher = null;

            siglaSerieList = new List<string>();
            idSerieList = new List<int>();

            siglaTeacherList = new List<string>();
            rgTeacherList = new List<string>();
        }

        private async void Form5_Load(object sender, EventArgs e)
        {
            //FILTRO
            Filter.arrangeFilterPanelsPosition(this);
            Filter.filterButtonStyle(filterButtonPanel);
            Filter.orderFilterElements(filterPanel);

            //Localização e estilos
            ScreenElements.arrangeCentralPanelLocation(this);
            ScreenElements.stylizePlusButton(this);
            ScreenElements.stylizeLoadingMessage(this);

            try
            {
                await loadSeriesAsync();
                await loadTeachersAsync();
                await loadIcons();
                await loadColors();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            arrangeIconsColors();

            listTurmas(null);
        }

        private void arrangeIconsColors()
        {
            Array.Sort(colors, (x, y) => String.Compare(x.ID.ToString(), y.ID.ToString()));
            Array.Sort(icons, (x, y) => String.Compare(x.ID.ToString(), y.ID.ToString()));
        }

        private async Task loadSeriesAsync()
        {
            try
            {
                var apiPath = RestService.For<ApiService>(Routes.baseUrl);
                var dataResponse = await apiPath.GetSeriesAsync();

                series = JsonConvert.DeserializeObject<SeriesApiResponse[]>(dataResponse.ToString());
                foreach (SeriesApiResponse serie in series)
                {
                    siglaSerieList.Add(serie.Sigla);
                    idSerieList.Add(serie.Id);
                }
                comboBox01_Serie.Items.Clear();
                comboBox01_Serie.Items.Add("");
                comboBox01_Serie.Items.AddRange(siglaSerieList.ToArray());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private async Task loadIcons()
        {
            var apiPath = RestService.For<ApiService>(Routes.baseUrl);
            var dataResponse = await apiPath.GetIconsAsync();
            icons = JsonConvert.DeserializeObject<IconsApiResponse[]>(dataResponse.ToString());
        }

        private async Task loadColors()
        {
            var apiPath = RestService.For<ApiService>(Routes.baseUrl);
            var dataResponse = await apiPath.GetColorsAsync();
            colors = JsonConvert.DeserializeObject<ColorsApiResponse[]>(dataResponse.ToString());
        }

        private async Task loadTeachersAsync()
        {
            try
            {
                var apiPath = RestService.For<ApiService>(Routes.baseUrl);
                var dataResponse = await apiPath.GetTeachersAsync();

                teachers = JsonConvert.DeserializeObject<TeachersApiResponse[]>(dataResponse.ToString());
                foreach (TeachersApiResponse teacher in teachers)
                {
                    rgTeacherList.Add(teacher.RG);
                    siglaTeacherList.Add(teacher.Nome);
                }
                comboBox02_Professor.Items.Clear();
                comboBox02_Professor.Items.Add("");
                comboBox02_Professor.Items.AddRange(siglaTeacherList.ToArray());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private async void listTurmas(ClassQueryGet filters)
        {
            try
            {
                var apiPath = RestService.For<ApiService>(Routes.baseUrl);
                if ((filters == null) || ((filters.Nome == null) && (filters.IdSerie == null) && (filters.RgProfessor == null)))
                {
                    var dataResponse = await apiPath.GetTurmasAsync();
                    turmas = JsonConvert.DeserializeObject<TurmasApiResponse[]>(dataResponse.ToString());
                }
                else
                {
                    var dataResponse = await apiPath.GetTurmasFilteredAsync(filters);
                    turmas = JsonConvert.DeserializeObject<TurmasApiResponse[]>(dataResponse.ToString());
                }

                loadingText.Visible = false;
                loadingCircle1.Visible = false;

                if (turmas.Length == 0)
                {
                    Label noTurmas = new Label();
                    noTurmas.Name = "noTurmas";
                    noTurmas.Text = "Não há turmas cadastradas!";
                    noTurmas.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints));
                    noTurmas.AutoSize = true;
                    noTurmas.Location = new Point(20, 20);
                    centralPanel.Controls.Add(noTurmas);
                }
                else
                {
                    int i;
                    int indexSerie = 0;
                    int indexTeacher = 0;
                    for (i = 0; i < turmas.Length; i++)
                    {
                        TurmasApiResponse turmasData = turmas[i];

                        for (indexSerie = 0; indexSerie < idSerieList.Count; indexSerie++)
                        {
                            if (idSerieList[indexSerie] == turmasData.IdSerie) break;
                        }

                        for (indexTeacher = 0; indexTeacher < siglaTeacherList.Count; indexTeacher++)
                        {
                            if (rgTeacherList[indexTeacher] == turmasData.RgProfessor) break;
                        }

                        Turmas turma = new Turmas(turmasData.ID, turmasData.Nome, turmasData.IdCores, turmasData.IdIcone, turmasData.IdSerie, turmasData.RgProfessor, turmasData.Icone, turmasData.Colors, siglaSerieList[indexSerie], siglaTeacherList[indexTeacher], i);
                        centralPanel.Controls.Add(turma.getTurmaPanel());
                    }
                    Panel panel = new Panel();
                    panel.Size = new Size(1, 20);
                    panel.Location = new Point(20, (20 + Styles.seriesSize.Height) * (i));
                    centralPanel.Controls.Add(panel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro occoreu: " + ex.ToString());
            }
        }

        #region Botão Criar Turma

        public Panel styleCreationPanel()
        {
            Panel panel = new Panel();

            panel.Name = "creationTurmasPanel";
            panel.Size = Styles.creationPanelSize;
            panel.Location = new Point(Convert.ToInt32(parentForm.Width / 2 - panel.Width / 2), Convert.ToInt32(parentForm.Height / 2 - panel.Height / 2));
            panel.BackColor = Styles.secondaryColor;

            Rectangle rectangle = new Rectangle(0, 0, panel.Width, panel.Height);
            GraphicsPath roundedPanel = Transform.BorderRadius(rectangle, 25, true, true, true, true);
            panel.Region = new Region(roundedPanel);

            parentForm.Controls.Add(panel);
            panel.BringToFront();

            return panel;
        }

        private async void finishTurmasCreation_Click(object sender, EventArgs e)
        {
            ClassQueryParameters data = new ClassQueryParameters();

            int itemsCount = parentForm.Controls.Count;
            Panel creationPanel = new Panel();

            for (int i = itemsCount - 1; i >= 0; i--)
            {
                if (parentForm.Controls[i].Name == "creationTurmaPanel")
                {
                    creationPanel = (Panel)parentForm.Controls[i];
                    break;
                }
            }

            int selectedSerie = -1, selectedTeacher = -1;

            for (int i = 0; i < creationPanel.Controls.Count; i++)
            {
                if (creationPanel.Controls[i].Name.Contains("textBox"))
                {
                    if (creationPanel.Controls[i].Name.Contains("Nome"))
                    {
                        if (creationPanel.Controls[i].Text.Trim() == "")
                        {
                            MessageBox.Show("O nome é obrigatório!");
                            return;
                        }
                        else data.Nome = creationPanel.Controls[i].Text.Trim();
                    }
                }
                if (creationPanel.Controls[i].Name.Contains("comboBox"))
                {
                    if (creationPanel.Controls[i].Name.Contains("Serie"))
                    {
                        selectedSerie = ((ComboBox)creationPanel.Controls[i]).SelectedIndex;
                        if (selectedSerie == -1)
                        {
                            MessageBox.Show("A série é obrigatório!");
                            return;
                        }
                        else data.IdSerie = selectedSerie + 1;
                    }
                    if (creationPanel.Controls[i].Name.Contains("Professor"))
                    {
                        selectedTeacher = ((ComboBox)creationPanel.Controls[i]).SelectedIndex;
                        if (selectedTeacher == -1)
                        {
                            MessageBox.Show("Um professor é obrigatório!");
                            return;
                        }
                        else
                        {
                            data.RgProfessor = teachers[selectedTeacher].RG;
                        }
                    }
                }
            }
            if (selectedIcon != null)
            {
                foreach (IconsApiResponse icon in icons) {
                    if (icon.ID == selectedIcon)
                    {
                        data.IdIcone = icon.ID;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Escolha um ícone!");
                return;
            }

            if (selectedColor != null)
            {
                foreach (ColorsApiResponse color in colors)
                {
                    if (color.ID == selectedColor)
                    {
                        data.IdCores = color.ID;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Escolha uma cor!");
                return;
            }

            var apiPath = RestService.For<ApiService>(Routes.baseUrl);
            Panel p = new Panel();
            Button b = new Button();
            try
            {
                for (int i = 0; i < parentForm.Controls.Count; i++)
                {
                    if (parentForm.Controls[i].Name == "creationTurmaPanel")
                    {
                        p = (Panel)parentForm.Controls[i];
                        break;
                    }
                }
                for (int i = 0; i < p.Controls.Count; i++)
                {
                    if (p.Controls[i].Name == "finishTurmaCreation")
                    {
                        b = (Button)p.Controls[i];
                        break;
                    }
                }

                b.Text = "Aguarde...";
                b.Enabled = false;

                var dataResponse = await apiPath.InsertTurmasAsync(data);
                var response = JsonConvert.DeserializeObject<ApiMessageResponse>(dataResponse.ToString());
                b.Text = "Sucesso!";
                b.Enabled = true;
                MessageBox.Show(response.Message);
                for (int i = 0; i < parentForm.Controls.Count; i++)
                {
                    if (parentForm.Controls[i].Name == "creationTurmaPanel")
                    {
                        parentForm.Controls.Remove(parentForm.Controls[i]);
                        filterButton.PerformClick();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                b.Text = "Erro!";
                b.Enabled = false;
            }
        }

        private void cancelTurmaCreation_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < parentForm.Controls.Count; i++)
            {
                if (parentForm.Controls[i].Name == "creationTurmaPanel")
                {
                    parentForm.Controls.Remove(parentForm.Controls[i]);
                    break;
                }
            }
        }

        private Button cancelTurmaCreationButton()
        {
            Button cancelTurmaCreation = new Button();
            cancelTurmaCreation.FlatStyle = FlatStyle.Flat;
            cancelTurmaCreation.FlatAppearance.BorderSize = 0;
            cancelTurmaCreation.ForeColor = Styles.white;
            cancelTurmaCreation.Text = "X";
            cancelTurmaCreation.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.Size * 0.75));
            cancelTurmaCreation.BackColor = Color.Transparent;
            cancelTurmaCreation.Size = new Size(Convert.ToInt32(Styles.defaultFont.Size * 1.5), Convert.ToInt32(Styles.defaultFont.Size * 1.5));
            cancelTurmaCreation.Location = new Point(Styles.creationPanelSize.Width - cancelTurmaCreation.Width, 0);
            cancelTurmaCreation.Click += new EventHandler(cancelTurmaCreation_Click);

            return cancelTurmaCreation;
        }

        private Button finishTurmaCreationButton()
        {
            Button finishTurmaCreation = new Button();

            finishTurmaCreation.Font = Styles.customFont;
            finishTurmaCreation.Name = "finishTurmaCreation";
            finishTurmaCreation.Text = "Finalizar";
            finishTurmaCreation.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.117), Convert.ToInt32(Styles.formSize.Height * 0.042));

            Rectangle rectangle = new Rectangle(0, 0, finishTurmaCreation.Width, finishTurmaCreation.Height);
            GraphicsPath roundedButton = Transform.BorderRadius(rectangle, 25, true, true, true, true);
            finishTurmaCreation.Region = new Region(roundedButton);

            finishTurmaCreation.FlatStyle = FlatStyle.Flat;
            finishTurmaCreation.Location = new Point(Convert.ToInt32(Styles.formSize.Width * 0.624) - finishTurmaCreation.Width, Styles.creationPanelSize.Height - finishTurmaCreation.Height - Convert.ToInt32(Styles.formSize.Width * 0.02));

            finishTurmaCreation.ForeColor = Color.Black;
            finishTurmaCreation.BackColor = Styles.white;
            finishTurmaCreation.Click += new EventHandler(this.finishTurmasCreation_Click);

            return finishTurmaCreation;
        }

        private Label createTurmaPanelLabel(string name, string text, Point location, Font font, Size size)
        {
            Label label = new Label();
            label.Name = name;
            label.Text = text;
            label.Location = location;
            label.Font = font;
            label.Size = size;

            return label;
        }

        private void showStudentComboBox_Click(object sender, EventArgs e)
        {
            int itemsCount = parentForm.Controls.Count;
            Panel creationPanel = new Panel();
            for (int i = itemsCount - 1; i >= 0; i--)
            {
                if (parentForm.Controls[i].Name == "creationTurmaPanel")
                {
                    creationPanel = (Panel)parentForm.Controls[i];
                    break;
                }
            }
            for (int i = creationPanel.Controls.Count - 1; i > 0; i--)
            {
                if (creationPanel.Controls[i].Name == "comboBoxSerie")
                {
                    ((ComboBox)creationPanel.Controls[i]).Focus();
                    ((ComboBox)creationPanel.Controls[i]).DroppedDown = true;
                    break;
                }
            }
        }

        private TextBox createTurmaPanelTextBox(string name, Point location, Panel parentPanel)
        {
            TextBox textBox = new TextBox();

            textBox.Name = name;
            textBox.Font = new Font(Styles.customFont.FontFamily, Convert.ToInt32((Styles.formSize.Height * 0.039) / 2));
            textBox.BackColor = Styles.backgroundColor;
            textBox.ForeColor = Styles.white;
            textBox.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.405), textBox.Height);
            textBox.Location = location;
            textBox.BorderStyle = BorderStyle.None;

            Rectangle rectangle = new Rectangle(0, 0, textBox.Width, textBox.Height + 1);
            GraphicsPath roundedTextBox = Transform.BorderRadius(rectangle, 5, true, true, true, true);
            textBox.Region = new Region(roundedTextBox);

            return textBox;
        }

        private ComboBox createTurmaPanelComboBox(string name, Point location, Panel parentPanel, List<string> comboBoxData)
        {
            ComboBox comboBox = new ComboBox();

            comboBox.Name = name;
            comboBox.Font = new Font(Styles.customFont.FontFamily, Convert.ToInt32((Styles.formSize.Height * 0.039) / 2.8));
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.BackColor = Styles.backgroundColor;
            comboBox.ForeColor = Styles.white;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.405), comboBox.Height);
            comboBox.Location = location;
            comboBox.Items.AddRange(comboBoxData.ToArray());

            Rectangle rectangle = new Rectangle(2, 2, comboBox.Width - 20, comboBox.Height - 3);
            GraphicsPath roundedComboBox = Transform.BorderRadius(rectangle, 2, true, false, false, true);
            comboBox.Region = new Region(roundedComboBox);

            parentPanel.Controls.Add(comboBox);

            Button comboBoxButton = new Button();
            comboBoxButton.FlatStyle = FlatStyle.Flat;
            comboBoxButton.FlatAppearance.BorderSize = 0;
            comboBoxButton.BackgroundImage = Properties.Resources.seta;
            comboBoxButton.ImageAlign = ContentAlignment.MiddleCenter;
            comboBoxButton.BackgroundImageLayout = ImageLayout.Center;
            comboBoxButton.BackColor = Styles.backgroundColor;
            comboBoxButton.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.018), Convert.ToInt32(comboBox.Height - 1.5));

            rectangle = new Rectangle(0, 0, comboBoxButton.Width, comboBoxButton.Height);
            GraphicsPath roundedButton = Transform.BorderRadius(rectangle, 10, false, true, true, false);
            comboBoxButton.Region = new Region(roundedButton);

            comboBoxButton.Location = new Point(comboBox.Location.X + comboBox.Width - comboBoxButton.Width, comboBox.Location.Y + 1);

            switch (name)
            {
                case "comboBoxSerie":
                    comboBoxButton.Click += new EventHandler(showStudentComboBox_Click);
                    break;
                case "comboBoxProfessor":
                    comboBoxButton.Click += new EventHandler(showProfessorComboBox_Click);
                    break;
            }

            parentPanel.Controls.Add(comboBoxButton);

            return comboBox;
        }

        private byte[] ImageToByteArray(Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        protected void LoadImage()
        {
            image = new Bitmap(path);
        }

        private void turmaPicture_DragEnter(object sender, DragEventArgs e)
        {
            string filename;
            validData = GetFilename(out filename, e);
            if (validData)
            {
                path = filename;
                getImageThread = new Thread(new ThreadStart(LoadImage));
                getImageThread.Start();
                e.Effect = DragDropEffects.Copy;
            }
            else e.Effect = DragDropEffects.None;
        }

        private bool GetFilename(out string filename, DragEventArgs e)
        {
            bool ret = false;
            filename = String.Empty;
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileDrop") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        filename = ((string[])data)[0];
                        string ext = Path.GetExtension(filename).ToLower();
                        if ((ext == ".jpg") || (ext == ".png") || (ext == ".bmp"))
                        {
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            ClassQueryGet filters = new ClassQueryGet();
            if (!textBox01_NomeTurma.Text.Trim().Equals("")) filters.Nome = textBox01_NomeTurma.Text.Trim();

            int itemsCount = centralPanel.Controls.Count;
            for (int i = itemsCount - 1; i > 0; i--)
            {
                if (centralPanel.Controls[i].Name == "noTurmas")
                {
                    centralPanel.Controls.Remove(centralPanel.Controls[i]);
                    continue;
                }

                Type objectType = centralPanel.Controls[i].GetType();

                if (objectType == typeof(Panel))
                {
                    centralPanel.Controls.Remove(centralPanel.Controls[i]);
                    itemsCount--;
                }
            }

            loadingText.Visible = true;
            loadingCircle1.Visible = true;

            if (filterSelectedSerie != null) filters.IdSerie = filterSelectedSerie.Id;
            if (filterSelectedTeacher != null) filters.RgProfessor = filterSelectedTeacher.RG;

            listTurmas(filters);
        }

        private void showProfessorComboBox_Click(object sender, EventArgs e)
        {
            int itemsCount = parentForm.Controls.Count;
            Panel creationPanel = new Panel();
            for (int i = itemsCount - 1; i >= 0; i--)
            {
                if (parentForm.Controls[i].Name == "creationTurmaPanel")
                {
                    creationPanel = (Panel)parentForm.Controls[i];
                    break;
                }
            }
            for (int i = creationPanel.Controls.Count - 1; i > 0; i--)
            {
                if (creationPanel.Controls[i].Name == "comboBoxProfessor")
                {
                    ((ComboBox)creationPanel.Controls[i]).Focus();
                    ((ComboBox)creationPanel.Controls[i]).DroppedDown = true;
                    break;
                }
            }
        }

        private void iconPanel_Click(object sender, EventArgs e)
        {
            iconsList = new List<IconsFormat>();

            currentIcon = 1;
            iconSelectionPanel = new Panel();
            iconSelectionPanel.Name = "iconSelectionPanel";
            iconSelectionPanel.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.375), Convert.ToInt32(Styles.formSize.Height * 0.391));
            iconSelectionPanel.Location = new Point(Convert.ToInt32(Styles.formSize.Width / 2 - iconSelectionPanel.Width / 2), Convert.ToInt32(Styles.formSize.Height / 2 - iconSelectionPanel.Height / 2));
            iconSelectionPanel.BackColor = Styles.backgroundColor;

            iconSelectionPanel.Controls.Add(cancelIconSelectionButton());

            iconSelectionPanel.HorizontalScroll.Maximum = 0;
            iconSelectionPanel.AutoScroll = false;
            iconSelectionPanel.VerticalScroll.Visible = false;
            iconSelectionPanel.AutoScroll = true;

            Label selectIconLabel = new Label();
            selectIconLabel.Text = "Selecionar Ícone: ";
            selectIconLabel.Location = new Point(20, 20);
            selectIconLabel.Font = Styles.defaultFont;
            selectIconLabel.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.3), Convert.ToInt32(Styles.formSize.Height * 0.039));

            iconSelectionPanel.Controls.Add(selectIconLabel);

            Rectangle rectangle = new Rectangle(0, 0, iconSelectionPanel.Width, iconSelectionPanel.Height);
            GraphicsPath roundedPanel = Transform.BorderRadius(rectangle, 20, true, true, true, true);
            iconSelectionPanel.Region = new Region(roundedPanel);

            int heightNeeded = selectIconLabel.Location.Y + selectIconLabel.Height + 15;

            Size iconButtonSize = new Size(Convert.ToInt32(iconSelectionPanel.Height / 5) - 5, Convert.ToInt32(iconSelectionPanel.Height / 5) - 5);

            int maxIcons = 0, iconPos = 1, posX = 0;

            while (Convert.ToInt32(maxIcons * (iconButtonSize.Width + 10)) < iconSelectionPanel.Width) maxIcons++;

            if (icons == null)
            {
                MessageBox.Show("Aguarde até que os ícones sejam carregados!");
                return;
            }

            foreach (IconsApiResponse icon in icons)
            {
                Button iconButton = new Button();
                iconButton.Name = $"iconButton{icon.ID}";
                getImageThread = new Thread(new ThreadStart(() => getImage(icon)));
                getImageThread.Start();
                iconButton.FlatStyle = FlatStyle.Flat;

                iconButton.BackgroundImageLayout = ImageLayout.Stretch;
                iconButton.BackColor = Color.White;
                iconButton.Click += new EventHandler(finishSelectIcon_Click);

                iconButton.Size = iconButtonSize;

                iconButton.Padding = new Padding(Convert.ToInt32(Styles.formSize.Width * 0.003));

                iconButton.Location = new Point(Convert.ToInt32((posX * (iconButton.Width + 20)) + 30), ((heightNeeded + 20) * iconPos));

                posX++;

                if ((currentIcon % maxIcons == 0) && (currentIcon != 0))
                {
                    iconPos++;
                    posX = 0;
                }

                iconSelectionPanel.Controls.Add(iconButton);
                currentIcon++;
            }

            Panel spacePanel = new Panel();
            spacePanel.Location = new Point(0, ((heightNeeded + 20) * iconPos));
            spacePanel.Size = new Size(iconSelectionPanel.Width, 20);
            iconSelectionPanel.Controls.Add(spacePanel);

            parentForm.Controls.Add(iconSelectionPanel);
            iconSelectionPanel.BringToFront();
        }

        private void getImage(IconsApiResponse icon)
        {
                try
                {
                    WebResponse imageResponse = null;
                    Stream responseStream;
                    HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(icon.Link);
                    imageResponse = imageRequest.GetResponse();
                    responseStream = imageResponse.GetResponseStream();

                    Control[] controlsArray = iconSelectionPanel.Controls.Find($"iconButton{icon.ID}", true);

                    Image result = Image.FromStream(responseStream);
                    IconsFormat iconFormated = new IconsFormat(icon.ID, result);
                    iconsList.Add(iconFormated);

                    if (controlsArray.Length >= 1)
                    {
                        Button iconButton = (Button)controlsArray[0];
                        iconButton.BackgroundImage = result;
                    }

                    imageResponse.Close();
                    responseStream.Close();
                }
                catch (Exception ex)
                {
                    userSelectIcon.Image = null;
                    MessageBox.Show("Ocorreu um erro ao escolher o ícone! " + ex.ToString());
                }
        }

        private void finishSelectIcon_Click(object sender, EventArgs e)
        {
            string iconName = ((Button)sender).Name;
            string iconID = iconName.Remove(0, 10);
            selectedIcon = Convert.ToInt32(iconID);

            iconsList = iconsList.OrderBy(x => x.ID).ToList();

            foreach(IconsFormat icon in iconsList)
            {
                if(icon.ID == (int)selectedIcon) turmaPicture1.Image = turmaPicture2.Image = iconPanelPictureBox.Image = userSelectIcon.Image = icon.Icon;
                turmaPicture2.Padding = turmaPicture1.Padding = new Padding(Convert.ToInt32(Styles.formSize.Width * 0.005));
            }
            parentForm.Controls.Remove(iconSelectionPanel);
        }

        private Button cancelIconSelectionButton()
        {
            Button cancelIconSelection = new Button();
            cancelIconSelection.FlatStyle = FlatStyle.Flat;
            cancelIconSelection.FlatAppearance.BorderSize = 0;
            cancelIconSelection.ForeColor = Styles.white;
            cancelIconSelection.Text = "X";
            cancelIconSelection.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.Size * 0.75));
            cancelIconSelection.BackColor = Color.Transparent;
            cancelIconSelection.Size = new Size(Convert.ToInt32(Styles.defaultFont.Size * 1.5), Convert.ToInt32(Styles.defaultFont.Size * 1.5));
            cancelIconSelection.Location = new Point(iconSelectionPanel.Width - cancelIconSelection.Width - 20, 0);
            cancelIconSelection.Click += new EventHandler(cancelIconSelection_Click);

            return cancelIconSelection;
        }

        private void cancelIconSelection_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < parentForm.Controls.Count; i++)
            {
                if (parentForm.Controls[i].Name == "iconSelectionPanel")
                {
                    parentForm.Controls.Remove(parentForm.Controls[i]);
                    break;
                }
            }
        }

        private Color hexaToColor(string hx)
        {
            hx = hx.Remove(0, 1);
            int x = int.Parse(hx, System.Globalization.NumberStyles.HexNumber);
            Color cor = ColorTranslator.FromOle(x);
            return cor;
        }

        private void cancelColorSelection_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < parentForm.Controls.Count; i++)
            {
                if (parentForm.Controls[i].Name == "colorSelectionPanel")
                {
                    parentForm.Controls.Remove(parentForm.Controls[i]);
                    break;
                }
            }
        }

        private Button cancelColorSelectionButton()
        {
            Button cancelColorSelection = new Button();
            cancelColorSelection.FlatStyle = FlatStyle.Flat;
            cancelColorSelection.FlatAppearance.BorderSize = 0;
            cancelColorSelection.ForeColor = Styles.white;
            cancelColorSelection.Text = "X";
            cancelColorSelection.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.Size * 0.75));
            cancelColorSelection.BackColor = Color.Transparent;
            cancelColorSelection.Size = new Size(Convert.ToInt32(Styles.defaultFont.Size * 1.5), Convert.ToInt32(Styles.defaultFont.Size * 1.5));
            cancelColorSelection.Location = new Point(colorSelectionPanel.Width - cancelColorSelection.Width, 0);
            cancelColorSelection.Click += new EventHandler(cancelColorSelection_Click);

            return cancelColorSelection;
        }

        private void colorPanel_Click(object sender, EventArgs e)
        {
            currentColor = 0;
            colorSelectionPanel = new Panel();
            colorSelectionPanel.Name = "colorSelectionPanel";
            colorSelectionPanel.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.375), Convert.ToInt32(Styles.formSize.Height * 0.391));
            colorSelectionPanel.Location = new Point(Convert.ToInt32(Styles.formSize.Width / 2 - colorSelectionPanel.Width / 2), Convert.ToInt32(Styles.formSize.Height / 2 - colorSelectionPanel.Height / 2));
            colorSelectionPanel.BackColor = Styles.backgroundColor;

            colorSelectionPanel.Controls.Add(cancelColorSelectionButton());

            colorSelectionPanel.HorizontalScroll.Maximum = 0;
            colorSelectionPanel.AutoScroll = false;
            colorSelectionPanel.VerticalScroll.Visible = false;
            colorSelectionPanel.AutoScroll = true;

            Label selectColorLabel = new Label();
            selectColorLabel.Text = "Selecionar Cor: ";
            selectColorLabel.Location = new Point(20, 20);
            selectColorLabel.Font = Styles.defaultFont;
            selectColorLabel.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.3), Convert.ToInt32(Styles.formSize.Height * 0.039));

            colorSelectionPanel.Controls.Add(selectColorLabel);

            Rectangle rectangle = new Rectangle(0, 0, colorSelectionPanel.Width, colorSelectionPanel.Height);
            GraphicsPath roundedPanel = Transform.BorderRadius(rectangle, 20, true, true, true, true);
            colorSelectionPanel.Region = new Region(roundedPanel);

            int heightNeeded = selectColorLabel.Location.Y + selectColorLabel.Height;

            Size colorButtonSize = new Size(Convert.ToInt32(colorSelectionPanel.Height / 5) - 5, Convert.ToInt32(colorSelectionPanel.Height / 5) - 5);

            int maxColors = 0, colorPos = 1, posX = 0;

            while (Convert.ToInt32(maxColors * (colorButtonSize.Width) + 10) < colorSelectionPanel.Width) maxColors++;

            if (colors == null)
            {
                MessageBox.Show("Aguarde até que as cores sejam carregadas!");
                return;
            }
            foreach (ColorsApiResponse color in colors)
            {

                Button colorButton = new Button();
                colorButton.Name = $"colorButton{color.ID}";
                colorButton.FlatStyle = FlatStyle.Flat;
                colorButton.BackColor = hexaToColor(color.CorPrim);
                colorButton.Click += new EventHandler(finishSelectColor_Click);

                colorButton.Size = colorButtonSize;

                colorButton.Padding = new Padding(Convert.ToInt32(Styles.formSize.Width * 0.003));

                colorButton.Location = new Point(Convert.ToInt32(posX * (colorButton.Width + 20) + 5), heightNeeded * colorPos + 10);

                posX++;

                if ((currentColor % maxColors == 0) && (currentColor != 0))
                {
                    colorPos++;
                    posX = 0;
                }

                colorSelectionPanel.Controls.Add(colorButton);
                currentColor++;
            }

            parentForm.Controls.Add(colorSelectionPanel);
            colorSelectionPanel.BringToFront();
        }

        private void finishSelectColor_Click(object sender, EventArgs e)
        {
            string colorName = ((Button)sender).Name;
            string colorID = colorName.Remove(0, 11);
            selectedColor = Convert.ToInt32(colorID);
            colorPanel.BackColor = primaryColor.BackColor = hexaToColor(colors[(int)selectedColor - 1].CorPrim);
            secondaryColor.BackColor = hexaToColor(colors[(int)selectedColor - 1].CorSec);

            parentForm.Controls.Remove(colorSelectionPanel);
        }

        private void plusButtonPictureBox_Click(object sender, EventArgs e)
        {
            int labelSize = Convert.ToInt32(Styles.formSize.Height * 0.029) + 10;
            int objectHeight = Convert.ToInt32(Styles.formSize.Height * 0.06);

            Panel creationTurmaPanel = styleCreationPanel();
            creationTurmaPanel.Name = "creationTurmaPanel";

            creationTurmaPanel.Controls.Add(cancelTurmaCreationButton());
            creationTurmaPanel.Controls.Add(finishTurmaCreationButton());
            creationTurmaPanel.Controls.Add(createTurmaPanelLabel(
                    "labelTitle",
                    "Adicionar nova Turma:",
                    new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                    Styles.defaultFont,
                    new Size(Convert.ToInt32(Styles.formSize.Width * 0.268), Convert.ToInt32(Styles.formSize.Height * 0.039))
            ));

            objectHeight += labelSize;

            creationTurmaPanel.Controls.Add(createTurmaPanelLabel(
                    "labelNome",
                    "Nome: ",
                    new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                    Styles.customFont,
                    new Size(Convert.ToInt32(Styles.formSize.Width * 0.05), labelSize)
            ));

            objectHeight += labelSize;

            creationTurmaPanel.Controls.Add(createTurmaPanelTextBox(
                     "textBoxNome",
                     new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                     creationTurmaPanel
             ));

            #region Exibe cor e ícone
            selectedColorIcon = new Panel();
            primaryColor = new Panel();
            secondaryColor = new Panel();

            selectedColorIcon.BackColor = Styles.backgroundColor;
            selectedColorIcon.Location = new Point(Convert.ToInt32(Styles.formSize.Width * 0.474) + 20, objectHeight);
            selectedColorIcon.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.116), Convert.ToInt32(Styles.formSize.Width * 0.116));

            Rectangle rectangle = new Rectangle(0, 0, selectedColorIcon.Width, selectedColorIcon.Height);
            GraphicsPath roundedPanel = Transform.BorderRadius(rectangle, 15, true, true, true, true);
            selectedColorIcon.Region = new Region(roundedPanel);

            #region Cor Primária

            primaryColor.Size = new Size(Convert.ToInt32(selectedColorIcon.Width / 2), selectedColorIcon.Height);
            primaryColor.Location = new Point(0, 0);

            rectangle = new Rectangle(0, 0, primaryColor.Width, primaryColor.Height);
            roundedPanel = Transform.BorderRadius(rectangle, 15, true, false, false, true);
            primaryColor.Region = new Region(roundedPanel);

            selectedColorIcon.Controls.Add(primaryColor);

            #endregion

            #region Cor Secundária

            secondaryColor.Size = new Size(Convert.ToInt32(selectedColorIcon.Width / 2), selectedColorIcon.Height);
            secondaryColor.Location = new Point(primaryColor.Width, 0);

            rectangle = new Rectangle(0, 0, secondaryColor.Width, secondaryColor.Height);
            roundedPanel = Transform.BorderRadius(rectangle, 15, false, true, true, false);
            secondaryColor.Region = new Region(roundedPanel);

            selectedColorIcon.Controls.Add(secondaryColor);

            #endregion

            turmaPicture1.Image = null;
            turmaPicture1.BackColor = Color.Transparent;
            turmaPicture1.Size = new Size(selectedColorIcon.Width, selectedColorIcon.Height);
            turmaPicture1.SizeMode = PictureBoxSizeMode.StretchImage;
            turmaPicture1.Location = new Point(Convert.ToInt32(selectedColorIcon.Width / 2 - turmaPicture1.Width / 2), Convert.ToInt32(selectedColorIcon.Height / 2 - turmaPicture1.Height / 2));
            turmaPicture1.BringToFront();

            primaryColor.Controls.Add(turmaPicture1);

            turmaPicture2.Image = null;
            turmaPicture2.BackColor = Color.Transparent;
            turmaPicture2.Size = new Size(selectedColorIcon.Width, selectedColorIcon.Height);
            turmaPicture2.SizeMode = PictureBoxSizeMode.StretchImage;
            turmaPicture2.Location = new Point(Convert.ToInt32(-turmaPicture2.Width / 2), Convert.ToInt32(selectedColorIcon.Height / 2 - turmaPicture2.Height / 2));
            turmaPicture2.BringToFront();

            secondaryColor.Controls.Add(turmaPicture2);

            creationTurmaPanel.Controls.Add(selectedColorIcon);
            #endregion

            #region Seleciona Cor
            colorPanel = new Panel();
            colorPanel.Size = new Size(Convert.ToInt32(selectedColorIcon.Width / 2 - 10), Convert.ToInt32(Styles.formSize.Height * 0.07));
            colorPanel.Location = new Point(selectedColorIcon.Location.X, selectedColorIcon.Location.Y + selectedColorIcon.Height + 20);
            colorPanel.BackColor = Styles.darkGray;
            //colorPanel.Click += new EventHandler(this.colorPanel_Click);

            colorPanelPictureBox.Image = Properties.Resources.select_color;
            colorPanelPictureBox.Size = new Size(Convert.ToInt32(selectedColorIcon.Width / 2 - 10), Convert.ToInt32(Styles.formSize.Height * 0.07));
            colorPanelPictureBox.Padding = new Padding(Convert.ToInt32(Styles.formSize.Width * 0.001));
            colorPanelPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            colorPanelPictureBox.BringToFront();
            colorPanelPictureBox.Click += new EventHandler(this.colorPanel_Click);
            colorPanel.Controls.Add(colorPanelPictureBox);

            rectangle = new Rectangle(0, 0, colorPanel.Width, colorPanel.Height);
            roundedPanel = Transform.BorderRadius(rectangle, 15, true, true, true, true);
            colorPanel.Region = new Region(roundedPanel);

            creationTurmaPanel.Controls.Add(colorPanel);
            #endregion

            #region Seleciona Icone
            Panel iconPanel = new Panel();
            iconPanel.Size = new Size(Convert.ToInt32(selectedColorIcon.Width / 2 - 10), Convert.ToInt32(Styles.formSize.Height * 0.07));
            iconPanel.Location = new Point(selectedColorIcon.Location.X + colorPanel.Width + 20, selectedColorIcon.Location.Y + selectedColorIcon.Height + 20);
            iconPanel.BackColor = Styles.darkGray;
            //iconPanel.Click += new EventHandler(this.iconPanel_Click);

            rectangle = new Rectangle(0, 0, iconPanel.Width, iconPanel.Height);
            roundedPanel = Transform.BorderRadius(rectangle, 15, true, true, true, true);
            iconPanel.Region = new Region(roundedPanel);

            iconPanelPictureBox.Image = Properties.Resources.select_icon;
            iconPanelPictureBox.Size = new Size(Convert.ToInt32(selectedColorIcon.Width / 2 - 10), Convert.ToInt32(Styles.formSize.Height * 0.07));
            iconPanelPictureBox.Padding = new Padding(Convert.ToInt32(Styles.formSize.Width * 0.001));
            iconPanelPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            iconPanelPictureBox.BringToFront();
            iconPanelPictureBox.Click += new EventHandler(this.iconPanel_Click);
            iconPanel.Controls.Add(iconPanelPictureBox);

            creationTurmaPanel.Controls.Add(iconPanel);
            #endregion

            objectHeight += Convert.ToInt32(Styles.formSize.Height * 0.039);

            #region ComboBox Série

            creationTurmaPanel.Controls.Add(createTurmaPanelLabel(
                "labelSerie",
                "Série: ",
                new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                Styles.customFont,
                new Size(Convert.ToInt32(Styles.formSize.Width * 0.041), labelSize)
            ));

            objectHeight += labelSize;

            creationTurmaPanel.Controls.Add(createTurmaPanelComboBox(
                     "comboBoxSerie",
                     new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                     creationTurmaPanel,
                     siglaSerieList
             ));

            #endregion

            objectHeight += Convert.ToInt32(Styles.formSize.Height * 0.039);

            #region ComboBox Professor
            creationTurmaPanel.Controls.Add(createTurmaPanelLabel(
                "labelProfessor",
                "Professor: ",
                new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                Styles.customFont,
                new Size(Convert.ToInt32(Styles.formSize.Width * 0.068), labelSize)
            ));

            objectHeight += labelSize;

            creationTurmaPanel.Controls.Add(createTurmaPanelComboBox(
                        "comboBoxProfessor",
                        new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                        creationTurmaPanel,
                        siglaTeacherList
                ));
        }
        #endregion
        #endregion

        private void comboBox01_Serie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox01_Serie.SelectedItem.Equals(""))
            {
                filterSelectedSerie = null;
                return;
            }
            foreach (SeriesApiResponse serie in series)
            {
                if (serie.Sigla == comboBox01_Serie.SelectedItem.ToString())
                {
                    filterSelectedSerie = serie;
                }
            }
        }

        private void comboBox02_Professor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox02_Professor.SelectedItem.Equals(""))
            {
                filterSelectedTeacher = null;
                return;
            }
            foreach (TeachersApiResponse teacher in teachers)
            {
                if (teacher.Nome == comboBox02_Professor.SelectedItem.ToString())
                {
                    filterSelectedTeacher = teacher;
                }
            }

        }
    }

    public class IconsFormat
    {
        public int ID;
        public Image Icon;

        public IconsFormat(int id, Image icon)
        {
            ID = id;
            Icon = icon;
        }
    }
}
