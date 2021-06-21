using MRG.Controls.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
    public partial class Form3 : Form
    {
        #region Declaração de Variáveis
        TeachersApiResponse[] teachers;

        string[] serie = { "1", "2", "3" };
        string[] serieName = { "1º ano", "2º ano", "3º ano" };

        protected bool validData;
        protected string imageUrl = "";
        protected Image image;
        protected Thread getImageThread;
        protected PictureBox teacherPicture;
        string path;

        Form1 parentForm = null;
        #endregion

        public Form3(Form1 parentForm)
        {
            InitializeComponent();
            this.ControlBox = false; //Ocultar barra superior
            this.BackColor = Styles.darkGray;
            this.ForeColor = Styles.white;
            this.parentForm = parentForm;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //FILTRO
            Filter.arrangeFilterPanelsPosition(this);
            Filter.filterButtonStyle(filterButtonPanel);
            Filter.orderFilterElements(filterPanel);

            //Localização e estilos
            ScreenElements.arrangeCentralPanelLocation(this);
            ScreenElements.stylizePlusButton(this);
            ScreenElements.stylizeLoadingMessage(this);

            listTeachers(null);
        }

        private async void listTeachers(TeacherQueryParameters filters)
        {
            try
            {
                var apiPath = RestService.For<ApiService>(Routes.baseUrl);
                if (filters == null)
                {
                    var dataResponse = await apiPath.GetTeachersAsync();
                    teachers = JsonConvert.DeserializeObject<TeachersApiResponse[]>(dataResponse.ToString());
                }
                else
                {
                    var dataResponse = await apiPath.GetTeachersFilteredAsync(filters);
                    teachers = JsonConvert.DeserializeObject<TeachersApiResponse[]>(dataResponse.ToString());
                }

                loadingText.Visible = false;
                loadingCircle1.Visible = false;

                if (teachers.Length == 0)
                {
                    Label noTeachers = new Label();
                    noTeachers.Name = "noTeachers";
                    noTeachers.Text = "Não há professores cadastrados!";
                    noTeachers.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints));
                    noTeachers.AutoSize = true;
                    noTeachers.Location = new Point(20, 20);
                    centralPanel.Controls.Add(noTeachers);
                }
                else
                {
                    int i;
                    for (i = 0; i < teachers.Length; i++)
                    {
                        TeachersApiResponse teachersData = teachers[i];

                        Teachers serie = new Teachers(teachersData.Nome, teachersData.Telefone, teachersData.Email, teachersData.RG, teachersData.Foto, i);
                        centralPanel.Controls.Add(serie.getSeriePanel());
                    }
                    Panel panel = new Panel();
                    panel.Size = new Size(1, 20);
                    panel.Location = new Point(20, (20 + Styles.seriesSize.Height) * (i));
                    centralPanel.Controls.Add(panel);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Um erro occoreu: " + ex.ToString());
            }

          
    }


        #region Botão Criar Professor

        private Panel styleCreationPanel()
        {
            Panel panel = new Panel();

            panel.Name = "creationTeacherPanel";
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

        private async void finishTeacherCreation_Click(object sender, EventArgs e)
        {
            TeacherQueryParameters data = new TeacherQueryParameters();

            int itemsCount = parentForm.Controls.Count;
            Panel creationPanel = new Panel();

            for (int i = itemsCount - 1; i >= 0; i--)
            {
                if (parentForm.Controls[i].Name == "creationTeacherPanel")
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

                    else if (creationPanel.Controls[i].Name.Contains("RG"))
                    {
                        if (creationPanel.Controls[i].Text.Trim() == "")
                        {
                            MessageBox.Show("O RG é obrigatório!");
                            return;
                        }
                        else data.RG = creationPanel.Controls[i].Text.Trim();
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

            var apiPath = RestService.For<ApiService>(Routes.baseUrl);
            try
            {
                bool isOk = true;

                for (int i = 0; i < teachers.Length; i++)
                { 
                    if(teachers[i].RG == data.RG)
                    {
                        isOk = false;
                        MessageBox.Show("O RG já existe no banco de dados!");
                        break;
                    }
                    if(teachers[i].Email == data.Email)
                    {
                        isOk = false;
                        MessageBox.Show("O Email já existe no banco de dados!");
                        break;
                    }
                    if (teachers[i].Telefone == data.Telefone)
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
                        if (parentForm.Controls[i].Name == "creationTeacherPanel")
                        {
                            p = (Panel)parentForm.Controls[i];
                            break;
                        }
                    }
                    for (int i = 0; i < p.Controls.Count; i++)
                    {
                        if (p.Controls[i].Name == "finishTeacherCreation")
                        {
                            b = (Button)p.Controls[i];
                            break;
                        }
                    }

                    b.Text = "Aguarde...";
                    b.Enabled = false;

                    var dataResponse = await apiPath.InsertTeachersAsync(data);
                    var response = JsonConvert.DeserializeObject<ApiMessageResponse>(dataResponse.ToString());
                    MessageBox.Show(response.Message);
                    for (int i = 0; i < parentForm.Controls.Count; i++)
                    {
                        if (parentForm.Controls[i].Name == "creationTeacherPanel")
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

        private void cancelTeacherCreation_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < parentForm.Controls.Count; i++)
            {
                if (parentForm.Controls[i].Name == "creationTeacherPanel")
                {
                    parentForm.Controls.Remove(parentForm.Controls[i]);
                    break;
                }
            }
        }

        private Button cancelTeacherCreationButton()
        {
            Button cancelTeacherCreation = new Button();
            cancelTeacherCreation.FlatStyle = FlatStyle.Flat;
            cancelTeacherCreation.FlatAppearance.BorderSize = 0;
            cancelTeacherCreation.ForeColor = Styles.white;
            cancelTeacherCreation.Text = "X";
            cancelTeacherCreation.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.Size * 0.75));
            cancelTeacherCreation.BackColor = Color.Transparent;
            cancelTeacherCreation.Size = new Size(Convert.ToInt32(Styles.defaultFont.Size * 1.5), Convert.ToInt32(Styles.defaultFont.Size * 1.5));
            cancelTeacherCreation.Location = new Point(Styles.creationPanelSize.Width - cancelTeacherCreation.Width, 0);
            cancelTeacherCreation.Click += new EventHandler(cancelTeacherCreation_Click);

            return cancelTeacherCreation;
        }

        private Button finishTeacherCreationButton()
        {
            Button finishTeacherCreation = new Button();

            finishTeacherCreation.Font = Styles.customFont;
            finishTeacherCreation.Text = "Finalizar";
            finishTeacherCreation.Name = "finishTeacherCreation";
            finishTeacherCreation.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.117), Convert.ToInt32(Styles.formSize.Height * 0.042));

            Rectangle rectangle = new Rectangle(0, 0, finishTeacherCreation.Width, finishTeacherCreation.Height);
            GraphicsPath roundedButton = Transform.BorderRadius(rectangle, 25, true, true, true, true);
            finishTeacherCreation.Region = new Region(roundedButton);

            finishTeacherCreation.FlatStyle = FlatStyle.Flat;
            finishTeacherCreation.Location = new Point(Convert.ToInt32(Styles.formSize.Width * 0.624) - finishTeacherCreation.Width, Styles.creationPanelSize.Height - finishTeacherCreation.Height - Convert.ToInt32(Styles.formSize.Width * 0.025));

            finishTeacherCreation.ForeColor = Color.Black;
            finishTeacherCreation.BackColor = Styles.white;
            finishTeacherCreation.Click += new EventHandler(this.finishTeacherCreation_Click);

            return finishTeacherCreation;
        }

        private Label createTeacherPanelLabel(string name, string text, Point location, Font font, Size size)
        {
            Label label = new Label();
            label.Name = name;
            label.Text = text;
            label.Location = location;
            label.Font = font;
            label.Size = size;

            return label;
        }

        private TextBox createTeacherPanelTextBox(string name, Point location, Panel parentPanel)
        {
            TextBox textBox = new TextBox();

            textBox.Name = name;
            textBox.Font = new Font(Styles.customFont.FontFamily, Convert.ToInt32((Styles.formSize.Height * 0.039) / 2));
            textBox.BackColor = Styles.backgroundColor;
            textBox.ForeColor = Styles.white;
            textBox.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.405), textBox.Height);
            textBox.Location = location;
            textBox.BorderStyle = BorderStyle.None;

            Rectangle rectangle = new Rectangle(0, 0, textBox.Width, textBox.Height);
            GraphicsPath roundedTextBox = Transform.BorderRadius(rectangle, 5, true, true, true, true);
            textBox.Region = new Region(roundedTextBox);

            return textBox;
        }

        private void teacherPicture_DragDrop(object sender, DragEventArgs e)
        {
            if (validData)
            {
                while (getImageThread.IsAlive)
                {
                    Application.DoEvents();
                    Thread.Sleep(0);
                }
                teacherPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                teacherPicture.Image = image;
                sendTeacherImage();
                
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

        private async void sendTeacherImage()
        {
            Panel p = new Panel();
            Button b = new Button();
            for (int i = 0; i < parentForm.Controls.Count; i++)
            {
                if (parentForm.Controls[i].Name == "creationTeacherPanel")
                {
                    p = (Panel)parentForm.Controls[i];
                    break;
                }
            }
            for (int i = 0; i < p.Controls.Count; i++)
            {
                if (p.Controls[i].Name == "finishTeacherCreation")
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
            catch(Exception ex)
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

        private void teacherPicture_DragEnter(object sender, DragEventArgs e)
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

        private void teacherPicture_Click(object sender, EventArgs e)
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
                    sendTeacherImage();
                    teacherPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                    teacherPicture.Image = image;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void plusButtonPictureBox_Click(object sender, EventArgs e)
        {
            int labelSize = Convert.ToInt32(Styles.formSize.Height * 0.029) + 10;
            int objectHeight = Convert.ToInt32(Styles.formSize.Height * 0.06);

            Panel creationSeriePanel = styleCreationPanel();

            creationSeriePanel.Controls.Add(cancelTeacherCreationButton());
            creationSeriePanel.Controls.Add(finishTeacherCreationButton());
            creationSeriePanel.Controls.Add(createTeacherPanelLabel(
                    "labelTitle",
                    "Adicionar novo Professor:",
                    new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                    Styles.defaultFont,
                    new Size(Convert.ToInt32(Styles.formSize.Width * 0.268), Convert.ToInt32(Styles.formSize.Height * 0.039))
            ));

            objectHeight += labelSize;

            creationSeriePanel.Controls.Add(createTeacherPanelLabel(
                    "labelNome",
                    "Nome: ",
                    new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                    Styles.customFont,
                    new Size(Convert.ToInt32(Styles.formSize.Width * 0.05), labelSize)
            ));

            objectHeight += labelSize;

            creationSeriePanel.Controls.Add(createTeacherPanelTextBox(
                     "textBoxNome",
                     new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                     creationSeriePanel
             ));

            #region Adicionar imagem

            Panel panel = new Panel();

            panel.BackColor = Styles.backgroundColor;
            panel.Location = new Point(Convert.ToInt32(Styles.formSize.Width * 0.474) + 20, objectHeight);
            panel.Size = new Size(Convert.ToInt32(Styles.formSize.Width * 0.137), Convert.ToInt32(Styles.formSize.Height*0.266));

            Rectangle rectangle = new Rectangle(0, 0, panel.Width, panel.Height);
            GraphicsPath roundedPanel = Transform.BorderRadius(rectangle, 15, true, true, true, true);
            panel.Region = new Region(roundedPanel);

            teacherPicture = new PictureBox();

            teacherPicture.Image = Properties.Resources.upload;
            teacherPicture.Size = new Size(panel.Width, panel.Height);
            teacherPicture.SizeMode = PictureBoxSizeMode.CenterImage;
            teacherPicture.Location = new Point(Convert.ToInt32(panel.Width / 2 - teacherPicture.Width / 2), Convert.ToInt32(panel.Height / 2 - teacherPicture.Height / 2));

            teacherPicture.AllowDrop = true;
            teacherPicture.Click += new EventHandler(this.teacherPicture_Click);
            teacherPicture.DragEnter += new DragEventHandler(this.teacherPicture_DragEnter);
            teacherPicture.DragDrop += new DragEventHandler(this.teacherPicture_DragDrop);

            panel.Controls.Add(teacherPicture);
            creationSeriePanel.Controls.Add(panel);

            #endregion

            objectHeight += Convert.ToInt32(Styles.formSize.Height * 0.039);
            
            creationSeriePanel.Controls.Add(createTeacherPanelLabel(
                    "labelEmail",
                    "Email: ",
                    new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                    Styles.customFont,
                    new Size(Convert.ToInt32(Styles.formSize.Width * 0.046), labelSize)
            ));

            objectHeight += labelSize;

            creationSeriePanel.Controls.Add(createTeacherPanelTextBox(
                     "textBoxEmail",
                     new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                     creationSeriePanel
             ));

            objectHeight += Convert.ToInt32(Styles.formSize.Height * 0.039);

            creationSeriePanel.Controls.Add(createTeacherPanelLabel(
                    "labelRG",
                    "RG: ",
                    new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                    Styles.customFont,
                    new Size(Convert.ToInt32(Styles.formSize.Width * 0.03), labelSize)
            ));

            objectHeight += labelSize;

            creationSeriePanel.Controls.Add(createTeacherPanelTextBox(
                     "textBoxRG",
                     new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                     creationSeriePanel
             ));

            objectHeight += Convert.ToInt32(Styles.formSize.Height * 0.039);

            creationSeriePanel.Controls.Add(createTeacherPanelLabel(
                    "labelTelefone",
                    "Telefone: ",
                    new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                    Styles.customFont,
                    new Size(Convert.ToInt32(Styles.formSize.Width * 0.068), labelSize)
            ));

            objectHeight += labelSize;

            creationSeriePanel.Controls.Add(createTeacherPanelTextBox(
                     "textBoxTelefone",
                     new Point(Convert.ToInt32(Styles.formSize.Width * 0.069), objectHeight),
                     creationSeriePanel
             ));
        }

        #endregion

        private void filterButton_Click(object sender, EventArgs e)
        {
            int itemsCount = centralPanel.Controls.Count;
            for (int i = itemsCount - 1; i > 0; i--)
            {
                if (centralPanel.Controls[i].Name == "noTeachers")
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

            TeacherQueryParameters filters = new TeacherQueryParameters();
            if (textBox1_Nome.Text.Trim() != "") filters.Nome = textBox1_Nome.Text.Trim();
            if (textBox2_Telefone.Text.Trim() != "") filters.Telefone = textBox2_Telefone.Text.Trim();
            if (textBox3_Email.Text.Trim() != "") filters.Email = textBox3_Email.Text.Trim();
            if (textBox4_RG.Text.Trim() != "") filters.RG = textBox4_RG.Text.Trim();

            listTeachers(filters);
        }
    }
}
