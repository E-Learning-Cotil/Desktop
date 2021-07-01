using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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

        TeachersApiResponse[] teachers;
        TeachersApiResponse filterSelectedTeacher;
        List<string> siglaTeacherList;
        List<string> rgTeacherList;
        Panel selectedColorIcon;
        Panel iconSelectionPanel;
        Panel colorSelectionPanel;

        protected bool validData;
        protected int? selectedIcon;
        protected int? selectedColor;
        protected Image image;
        protected Thread getImageThread;
        protected PictureBox turmaPicture = new PictureBox();
        protected PictureBox iconPanelPictureBox = new PictureBox();
        protected Panel primaryColor;
        protected Panel secondaryColor;
        protected PictureBox userSelectIcon = new PictureBox();
        
        string path;

        string[] serieId;

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

            await loadSeriesAsync();
            await loadTeachersAsync();
            await loadIcons();
            await loadColors();

            listTurmas(null);
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
                //if ((filters == null) || ((filters.Nome == null) && (filters.IdSerie == null) && (filters.RgProfessor == null== null)))
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
                if (parentForm.Controls[i].Name == "creationTurmasPanel")
                {
                    creationPanel = (Panel)parentForm.Controls[i];
                    break;
                }
            }

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
            }
            if (selectedIcon != null)
            {
                foreach(IconsApiResponse icon in icons){
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

            int selectedSerie = -1;
            for (int i = 0; i < creationPanel.Controls.Count; i++)
            {

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
                        break;
                    }
                }
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
        finishTurmaCreation.Location = new Point(Convert.ToInt32(Styles.formSize.Width * 0.624) - finishTurmaCreation.Width, Styles.creationPanelSize.Height - finishTurmaCreation.Height - Convert.ToInt32(Styles.formSize.Width * 0.025));

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

            if(filterSelectedSerie != null) filters.IdSerie = filterSelectedSerie.Id;
            if(filterSelectedTeacher != null) filters.RgProfessor = filterSelectedTeacher.RG;

            listTurmas(filters);
        }

        private void showProfessorComboBox_Click (object sender, EventArgs e)
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
            iconSelectionPanel = new Panel();
            iconSelectionPanel.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.375), Convert.ToInt32(Styles.formSize.Height * 0.391));
            iconSelectionPanel.Location = new Point(Convert.ToInt32(Styles.formSize.Width/2 - iconSelectionPanel.Width/2), Convert.ToInt32(Styles.formSize.Height / 2 - iconSelectionPanel.Height / 2));
            iconSelectionPanel.BackColor = Styles.backgroundColor;

            Label selectIconLabel = new Label();
            selectIconLabel.Text = "Selecionar Ícone: ";
            selectIconLabel.Location = new Point(20, 20);
            selectIconLabel.Font = Styles.defaultFont;
            selectIconLabel.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.3), Convert.ToInt32(Styles.formSize.Height * 0.039));

            iconSelectionPanel.Controls.Add(selectIconLabel);

            Rectangle rectangle = new Rectangle(0, 0, iconSelectionPanel.Width, iconSelectionPanel.Height);
            GraphicsPath roundedPanel = Transform.BorderRadius(rectangle, 20, true, true, true, true);
            iconSelectionPanel.Region = new Region(roundedPanel);

            Button finishSelectIcon = new Button();
            finishSelectIcon.Font = Styles.customFont;
            finishSelectIcon.Name = "finishSelectIcon";
            finishSelectIcon.Text = "Finalizar";
            finishSelectIcon.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.117), Convert.ToInt32(Styles.formSize.Height * 0.042));

            rectangle = new Rectangle(0, 0, finishSelectIcon.Width, finishSelectIcon.Height);
            GraphicsPath roundedButton = Transform.BorderRadius(rectangle, 25, true, true, true, true);
            finishSelectIcon.Region = new Region(roundedButton);

            finishSelectIcon.FlatStyle = FlatStyle.Flat;
            finishSelectIcon.Location = new Point(iconSelectionPanel.Width - finishSelectIcon.Width - Convert.ToInt32(Styles.formSize.Width * 0.003), iconSelectionPanel.Height - finishSelectIcon.Height - Convert.ToInt32(Styles.formSize.Height * 0.003));

            finishSelectIcon.ForeColor = Color.Black;
            finishSelectIcon.BackColor = Styles.white;
            finishSelectIcon.Click += new EventHandler(finishSelectIcon_Click);

            iconSelectionPanel.Controls.Add(finishSelectIcon);

            parentForm.Controls.Add(iconSelectionPanel);
            iconSelectionPanel.BringToFront();
        }

        private void finishSelectIcon_Click(object sender, EventArgs e)
        {
            ((Button)sender).Text = "Aguarde...";
            ((Button)sender).Enabled = false;
            selectedIcon = 2;
            getImageThread = new Thread(new ThreadStart(getImage));
            getImageThread.Start();
            parentForm.Controls.Remove(iconSelectionPanel);
            turmaPicture.BringToFront();
            ((Button)sender).Text = "Finalizar";
            ((Button)sender).Enabled = true;
        }

        private void getImage()
        {
            try
            {
                foreach (IconsApiResponse icon in icons)
                {
                    if (icon.ID == selectedIcon)
                    {
                        WebResponse imageResponse = null;
                        Stream responseStream;
                        HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(icon.Link);
                        imageResponse = imageRequest.GetResponse();
                        responseStream = imageResponse.GetResponseStream();
                        turmaPicture.Image = iconPanelPictureBox.Image = userSelectIcon.Image = Image.FromStream(responseStream);
                        turmaPicture.Padding = new Padding(Convert.ToInt32(Styles.formSize.Width * 0.005));
                        responseStream.Close();
                        imageResponse.Close();
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                userSelectIcon.Image = null;
                MessageBox.Show("Ocorreu um erro ao escolher o ícone! " + ex.ToString());
            }
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
                selectedColorIcon.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.117), Convert.ToInt32(Styles.formSize.Width * 0.117));

                Rectangle rectangle = new Rectangle(0, 0, selectedColorIcon.Width, selectedColorIcon.Height);
                GraphicsPath roundedPanel = Transform.BorderRadius(rectangle, 15, true, true, true, true);
                selectedColorIcon.Region = new Region(roundedPanel);

            #region Cor Primária
                
            primaryColor.Size = new Size(Convert.ToInt32(selectedColorIcon.Width / 2), selectedColorIcon.Height);
            primaryColor.Location = new Point(0,0);
            primaryColor.BackColor = Color.Red;

            rectangle = new Rectangle(0, 0, primaryColor.Width, primaryColor.Height);
            roundedPanel = Transform.BorderRadius(rectangle, 15, true, false, false, true);
            primaryColor.Region = new Region(roundedPanel);

            selectedColorIcon.Controls.Add(primaryColor);

            #endregion

            #region Cor Secundária

            secondaryColor.Size = new Size(Convert.ToInt32(selectedColorIcon.Width / 2), selectedColorIcon.Height);
            secondaryColor.Location = new Point(primaryColor.Width, 0);
            secondaryColor.BackColor = Color.Blue;

            rectangle = new Rectangle(0, 0, secondaryColor.Width, secondaryColor.Height);
            roundedPanel = Transform.BorderRadius(rectangle, 15, false, true, true, false);
            secondaryColor.Region = new Region(roundedPanel);

            selectedColorIcon.Controls.Add(secondaryColor);

            #endregion

            turmaPicture.Image = null;
            turmaPicture.BackColor = Color.Transparent;
            turmaPicture.Size = new Size(selectedColorIcon.Width, selectedColorIcon.Height);
            turmaPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            turmaPicture.Location = new Point(Convert.ToInt32(selectedColorIcon.Width / 2 - turmaPicture.Width / 2), Convert.ToInt32(selectedColorIcon.Height / 2 - turmaPicture.Height / 2));
            
            selectedColorIcon.Controls.Add(turmaPicture);

            creationTurmaPanel.Controls.Add(selectedColorIcon);
            #endregion

            #region Seleciona Cor
                Panel colorPanel = new Panel();
                colorPanel.BackColor = Styles.backgroundColor;
                colorPanel.Size = new Size(Convert.ToInt32(selectedColorIcon.Width/2 - 10), Convert.ToInt32(Styles.formSize.Height * 0.073));
                colorPanel.Location = new Point(selectedColorIcon.Location.X, selectedColorIcon.Location.Y + selectedColorIcon.Height + 20);

                rectangle = new Rectangle(0, 0, colorPanel.Width, colorPanel.Height);
                roundedPanel = Transform.BorderRadius(rectangle, 15, true, true, true, true);
                colorPanel.Region = new Region(roundedPanel);

                creationTurmaPanel.Controls.Add(colorPanel);
            #endregion

            #region Seleciona Icone
            Panel iconPanel = new Panel();
            iconPanel.Size = new Size(Convert.ToInt32(selectedColorIcon.Width / 2 - 10), Convert.ToInt32(Styles.formSize.Height * 0.073));
            iconPanel.Location = new Point(selectedColorIcon.Location.X + colorPanel.Width + 20, selectedColorIcon.Location.Y + selectedColorIcon.Height + 20);
            iconPanel.BackColor = Styles.backgroundColor;
            iconPanel.Click += new EventHandler(this.iconPanel_Click);

            rectangle = new Rectangle(0, 0, iconPanel.Width, iconPanel.Height);
            roundedPanel = Transform.BorderRadius(rectangle, 15, true, true, true, true);
            iconPanel.Region = new Region(roundedPanel);

            iconPanelPictureBox.Size = new Size(Convert.ToInt32(selectedColorIcon.Width / 2 - 10), Convert.ToInt32(Styles.formSize.Height * 0.073));
            iconPanelPictureBox.Padding = new Padding(Convert.ToInt32(Styles.formSize.Width * 0.005));
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
}
