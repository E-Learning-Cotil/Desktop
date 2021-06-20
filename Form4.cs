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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElearningDesktop
{
    public partial class Form4 : Form
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

        public Form4(Form1 parentForm)
        {
            InitializeComponent();
            this.ControlBox = false; //Ocultar barra superior
            this.BackColor = Styles.darkGray;
            this.ForeColor = Styles.white;
            this.parentForm = parentForm;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            //FILTRO
            Filter.arrangeFilterPosition(this);
            Filter.filterButtonStyle(filterButtonPanel);
            Filter.orderFilterElements(filterPanel);

            //Localização e estilos
            ScreenElements.arrangeCentralPanelLocation(this);
            ScreenElements.stylizePlusButton(this);
            ScreenElements.stylizeLoadingMessage(this);

            listStudents(null);
        }

        private async void listStudents(StudentQueryGet filters)
        {
            try
            {
                var apiPath = RestService.For<ApiService>(Routes.baseUrl);
                if ((filters == null) ||((filters.RA.Equals(null)) && (filters.Email == null) && (filters.Nome == null) && (filters.Telefone == null)))
                {
                    var dataResponse = await apiPath.GetStudentsAsync();
                    students = JsonConvert.DeserializeObject<StudentsApiResponse[]>(dataResponse.ToString());
                }
                else
                {
                    var dataResponse = await apiPath.GetStudentsFilteredAsync(filters);
                    students = JsonConvert.DeserializeObject<StudentsApiResponse[]>(dataResponse.ToString());
                }

                loadingText.Visible = false;
                loadingCircle1.Visible = false;

                if (students.Length == 0)
                {
                    Label noStudents = new Label();
                    noStudents.Name = "noStudents";
                    noStudents.Text = "Não há alunos cadastrados!";
                    noStudents.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints));
                    noStudents.AutoSize = true;
                    noStudents.Location = new Point(20, 20);
                    centralPanel.Controls.Add(noStudents);
                }
                else
                {
                    int i;
                    for (i = 0; i< students.Length; i++)
                    {
                        StudentsApiResponse studentsData = students[i];

                        Students student = new Students(studentsData.Nome, studentsData.Telefone, studentsData.Email, studentsData.RA, studentsData.Foto,studentsData.IdSerie, i);
                        centralPanel.Controls.Add(student.getSeriePanel());
                    }
                    Panel panel = new Panel();
                    panel.Size = new Size(1, 20);
                    panel.Location = new Point(20,(20 + Styles.seriesSize.Height) * (i));
                    centralPanel.Controls.Add(panel);
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show("Um erro occoreu: " + ex.ToString());
            }


        }

        #region Botão Criar Aluno

        private Panel styleCreationPanel()
        {
            Panel panel = new Panel();

            panel.Name = "creationStudentPanel";
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

        private async void finishStudentCreation_Click(object sender, EventArgs e)
        {
            StudentQueryParameters data = new StudentQueryParameters();

            int itemsCount = parentForm.Controls.Count;
            Panel creationPanel = new Panel();

            for (int i = itemsCount - 1; i >= 0; i--)
            {
                if (parentForm.Controls[i].Name == "creationStudentPanel")
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

                    else if (creationPanel.Controls[i].Name.Contains("Telefone"))
                    {
                        if (creationPanel.Controls[i].Text.Trim() == "")
                        {
                            MessageBox.Show("O telefone é obrigatório!");
                            return;
                        }
                        else data.Telefone = creationPanel.Controls[i].Text.Trim();
                    }

                    else if (creationPanel.Controls[i].Name.Contains("Email"))
                    {
                        if (creationPanel.Controls[i].Text.Trim() == "")
                        {
                            MessageBox.Show("O email é obrigatório!");
                            return;
                        }
                        else data.Email = creationPanel.Controls[i].Text.Trim();
                    }
                }
            }
            if (!imageUrl.Trim().Equals("")) data.Foto = imageUrl;
            else
            {
                MessageBox.Show("A imagem não pode ser vazia!");
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
            try
            {
                bool isOk = true;

                for (int i = 0; i < students.Length; i++)
                {
                    if (students[i].Email == data.Email)
                    {
                        isOk = false;
                        MessageBox.Show("O Email já existe no banco de dados!");
                        break;
                    }
                    if (students[i].Telefone == data.Telefone)
                    {
                        isOk = false;
                        MessageBox.Show("O Telefone já existe no banco de dados!");
                        break;
                    }
                }

                if (isOk)
                {
                    Panel p = new Panel();
                    Button b = new Button();
                    for (int i = 0; i < parentForm.Controls.Count; i++)
                    {
                        if (parentForm.Controls[i].Name == "creationStudentPanel")
                        {
                            p = (Panel)parentForm.Controls[i];
                            break;
                        }
                    }
                    for (int i = 0; i < p.Controls.Count; i++)
                    {
                        if (p.Controls[i].Name == "finishStudentCreation")
                        {
                            b = (Button)p.Controls[i];
                            break;
                        }
                    }

                    b.Text = "Aguarde...";
                    b.Enabled = false;

                    var dataResponse = await apiPath.InsertStudentsAsync(data);
                    var response = JsonConvert.DeserializeObject<ApiMessageResponse>(dataResponse.ToString());
                    MessageBox.Show(response.Message);
                    for (int i = 0; i < parentForm.Controls.Count; i++)
                    {
                        if (parentForm.Controls[i].Name == "creationStudentPanel")
                        {
                            parentForm.Controls.Remove(parentForm.Controls[i]);
                            filterButton.PerformClick();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelStudentCreation_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < parentForm.Controls.Count; i++)
            {
                if (parentForm.Controls[i].Name == "creationStudentPanel")
                {
                    parentForm.Controls.Remove(parentForm.Controls[i]);
                    break;
                }
            }
        }

        private Button cancelStudentCreationButton()
        {
            Button cancelStudentCreation = new Button();
            cancelStudentCreation.FlatStyle = FlatStyle.Flat;
            cancelStudentCreation.FlatAppearance.BorderSize = 0;
            cancelStudentCreation.ForeColor = Styles.white;
            cancelStudentCreation.Text = "X";
            cancelStudentCreation.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.Size * 0.75));
            cancelStudentCreation.BackColor = Color.Transparent;
            cancelStudentCreation.Size = new Size(Convert.ToInt32(Styles.defaultFont.Size * 1.5), Convert.ToInt32(Styles.defaultFont.Size * 1.5));
            cancelStudentCreation.Location = new Point(Styles.creationPanelSize.Width - cancelStudentCreation.Width, 0);
            cancelStudentCreation.Click += new EventHandler(cancelStudentCreation_Click);

            return cancelStudentCreation;
        }

        private Button finishStudentCreationButton()
        {
            Button finishStudentCreation = new Button();

            finishStudentCreation.Font = Styles.customFont;
            finishStudentCreation.Name = "finishStudentCreation";
            finishStudentCreation.Text = "Finalizar";
            finishStudentCreation.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.117), Convert.ToInt32(Styles.formSize.Height * 0.042));

            Rectangle rectangle = new Rectangle(0, 0, finishStudentCreation.Width, finishStudentCreation.Height);
            GraphicsPath roundedButton = Transform.BorderRadius(rectangle, 25, true, true, true, true);
            finishStudentCreation.Region = new Region(roundedButton);

            finishStudentCreation.FlatStyle = FlatStyle.Flat;
            finishStudentCreation.Location = new Point(Convert.ToInt32(Styles.formSize.Width * 0.624) - finishStudentCreation.Width, Styles.creationPanelSize.Height - finishStudentCreation.Height - Convert.ToInt32(Styles.formSize.Width * 0.025));

            finishStudentCreation.ForeColor = Color.Black;
            finishStudentCreation.BackColor = Styles.white;
            finishStudentCreation.Click += new EventHandler(this.finishStudentCreation_Click);

            return finishStudentCreation;
        }

        private Label createStudentPanelLabel(string name, string text, Point location, Font font, Size size)
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
                if (parentForm.Controls[i].Name == "creationStudentPanel")
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

        private TextBox createStudentPanelTextBox(string name, Point location, Panel parentPanel)
        {
            TextBox textBox = new TextBox();

            textBox.Name = name;
            textBox.Font = new Font(Styles.customFont.FontFamily, Convert.ToInt32((Styles.formSize.Height * 0.039) / 2));
            textBox.BackColor = Styles.backgroundColor;
            textBox.ForeColor = Styles.white;
            textBox.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.405), textBox.Height);
            textBox.Location = location;
            textBox.BorderStyle = BorderStyle.None;

            Rectangle rectangle = new Rectangle(0, 0, textBox.Width, textBox.Height+1);
            GraphicsPath roundedTextBox = Transform.BorderRadius(rectangle, 5, true, true, true, true);
            textBox.Region = new Region(roundedTextBox);

            return textBox;
        }
        
        private ComboBox createStudentPanelComboBox(string name, Point location, Panel parentPanel, string[] comboBoxData)
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
            comboBox.Items.AddRange(comboBoxData);

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
            }

            parentPanel.Controls.Add(comboBoxButton);

            return comboBox;
        }

        private void studentPicture_DragDrop(object sender, DragEventArgs e)
        {
            if (validData)
            {
                while (getImageThread.IsAlive)
                {
                    Application.DoEvents();
                    Thread.Sleep(0);
                }
                studentPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                studentPicture.Image = image;
                sendStudentImage();

            }
        }

        private byte[] ImageToByteArray(Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private async void sendStudentImage()
        {
            Panel p = new Panel();
            Button b = new Button();
            for (int i = 0; i < parentForm.Controls.Count; i++)
            {
                if (parentForm.Controls[i].Name == "creationStudentPanel")
                {
                    p = (Panel)parentForm.Controls[i];
                    break;
                }
            }
            for(int i = 0; i < p.Controls.Count; i++)
            {
                if(p.Controls[i].Name == "finishStudentCreation")
                {
                    b = (Button)p.Controls[i];
                    break;
                }
            }

            b.Text = "Aguarde...";
            b.Enabled = false;

            var apiPath = RestService.For<ApiService>(Routes.sendImageBaseUrl);
            try
            {
                var imageData = ImageToByteArray(image);
                var dataResponse = await apiPath.SendImageToApi(new ByteArrayPart(imageData, "file.png"));
                imageUrl = dataResponse;
                b.Text = "Finalizar";
                b.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                b.Text = "Erro...";
                b.Enabled = false;
            }
        }

        protected void LoadImage()
        {
            image = new Bitmap(path);
        }

        private void studentPicture_DragEnter(object sender, DragEventArgs e)
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

        private void studentPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectedPicture = new OpenFileDialog();
            selectedPicture.Title = "Selecione uma foto: ";
            selectedPicture.Filter = "Images (*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";
            selectedPicture.CheckFileExists = true;
            selectedPicture.CheckPathExists = true;

            DialogResult result = selectedPicture.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string pictureName = selectedPicture.FileName;
                    image = Image.FromFile(pictureName);
                    sendStudentImage();
                    studentPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                    studentPicture.Image = image;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private async void plusButtonPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                var apiPath = RestService.For<ApiService>(Routes.baseUrl);
                var dataResponse = await apiPath.GetSeriesAsync();
                var series = JsonConvert.DeserializeObject<SeriesApiResponse[]>(dataResponse.ToString());
                List<string> siglaList = new List<string>();
                List<string> idList = new List<string>();
                foreach (SeriesApiResponse serie in series)
                {
                    siglaList.Add(serie.Sigla);
                    idList.Add(serie.Id.ToString());
                }
                serieName = siglaList.ToArray();
                serieId = idList.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }


            int labelSize = Convert.ToInt32(Styles.formSize.Height * 0.029) + 10;
            int objectHeight = Convert.ToInt32(Styles.formSize.Height * 0.06);

            Panel creationStudentPanel = styleCreationPanel();
            creationStudentPanel.Name = "creationStudentPanel";

            creationStudentPanel.Controls.Add(cancelStudentCreationButton());
            creationStudentPanel.Controls.Add(finishStudentCreationButton());
            creationStudentPanel.Controls.Add(createStudentPanelLabel(
                    "labelTitle",
                    "Adicionar novo Aluno:",
                    new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                    Styles.defaultFont,
                    new Size(Convert.ToInt32(Styles.formSize.Width * 0.268), Convert.ToInt32(Styles.formSize.Height * 0.039))
            ));

            objectHeight += labelSize;

            creationStudentPanel.Controls.Add(createStudentPanelLabel(
                    "labelNome",
                    "Nome: ",
                    new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                    Styles.customFont,
                    new Size(Convert.ToInt32(Styles.formSize.Width * 0.05), labelSize)
            ));

            objectHeight += labelSize;

            creationStudentPanel.Controls.Add(createStudentPanelTextBox(
                     "textBoxNome",
                     new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                     creationStudentPanel
             ));

            #region Adicionar imagem

            Panel panel = new Panel();

            panel.BackColor = Styles.backgroundColor;
            panel.Location = new Point(Convert.ToInt32(Styles.formSize.Width * 0.474) + 20, objectHeight);
            panel.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.137), Convert.ToInt32(Styles.formSize.Height * 0.266));

            Rectangle rectangle = new Rectangle(0, 0, panel.Width, panel.Height);
            GraphicsPath roundedPanel = Transform.BorderRadius(rectangle, 15, true, true, true, true);
            panel.Region = new Region(roundedPanel);

            studentPicture = new PictureBox();

            studentPicture.Image = Properties.Resources.upload;
            studentPicture.Size = new Size(panel.Width, panel.Height);
            studentPicture.SizeMode = PictureBoxSizeMode.CenterImage;
            studentPicture.Location = new Point(Convert.ToInt32(panel.Width / 2 - studentPicture.Width / 2), Convert.ToInt32(panel.Height / 2 - studentPicture.Height / 2));

            studentPicture.AllowDrop = true;
            studentPicture.Click += new EventHandler(this.studentPicture_Click);
            studentPicture.DragEnter += new DragEventHandler(this.studentPicture_DragEnter);
            studentPicture.DragDrop += new DragEventHandler(this.studentPicture_DragDrop);

            panel.Controls.Add(studentPicture);
            creationStudentPanel.Controls.Add(panel);

            #endregion

            objectHeight += Convert.ToInt32(Styles.formSize.Height * 0.039);

            creationStudentPanel.Controls.Add(createStudentPanelLabel(
                    "labelEmail",
                    "Email: ",
                    new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                    Styles.customFont,
                    new Size(Convert.ToInt32(Styles.formSize.Width * 0.046), labelSize)
            ));

            objectHeight += labelSize;

            creationStudentPanel.Controls.Add(createStudentPanelTextBox(
                     "textBoxEmail",
                     new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                     creationStudentPanel
             ));

            objectHeight += Convert.ToInt32(Styles.formSize.Height * 0.039);

            #region ComboBox Série

            creationStudentPanel.Controls.Add(createStudentPanelLabel(
                "labelSerie",
                "Série: ",
                new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                Styles.customFont,
                new Size(Convert.ToInt32(Styles.formSize.Width * 0.041), labelSize)
            ));

            objectHeight += labelSize;

            creationStudentPanel.Controls.Add(createStudentPanelComboBox(
                     "comboBoxSerie",
                     new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                     creationStudentPanel,
                     serieName
             ));

            #endregion

            objectHeight += Convert.ToInt32(Styles.formSize.Height * 0.039);

            creationStudentPanel.Controls.Add(createStudentPanelLabel(
                    "labelTelefone",
                    "Telefone: ",
                    new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                    Styles.customFont,
                    new Size(Convert.ToInt32(Styles.formSize.Width * 0.068), labelSize)
            ));

            objectHeight += labelSize;

            creationStudentPanel.Controls.Add(createStudentPanelTextBox(
                     "textBoxTelefone",
                     new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                     creationStudentPanel
             ));
        }

        #endregion

        private void filterButton_Click(object sender, EventArgs e)
        {
            StudentQueryGet filters = new StudentQueryGet();
            if (!textBox1_Name.Text.Trim().Equals("")) filters.Nome = textBox1_Name.Text.Trim();
            if (!textBox2_Telefone.Text.Trim().Equals("")) filters.Telefone = textBox2_Telefone.Text.Trim();
            if (!textBox3_Email.Text.Trim().Equals("")) filters.Email = textBox3_Email.Text.Trim();
            try
            {
                if (!textBox4_RA.Text.Trim().Equals(""))
                {
                    filters.RA = Convert.ToInt32(textBox4_RA.Text.Trim());
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("o RA digitado não é inteiro!");
                return;
            }

            int itemsCount = centralPanel.Controls.Count;
            for (int i = itemsCount - 1; i > 0; i--)
            {
                if (centralPanel.Controls[i].Name == "noStudents")
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
            
            listStudents(filters);
        }
    }
}
