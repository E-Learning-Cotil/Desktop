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

        private void filterButtonStyle()
        {
            filterButton.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints * 0.7));
            filterButton.Size = new Size(Convert.ToInt32(filterButtonPanel.Width * 0.830), Convert.ToInt32(filterButtonPanel.Height * 0.574));
            filterButton.Location = new Point(Convert.ToInt32(filterButtonPanel.Width / 2 - filterButton.Width / 2), Convert.ToInt32(filterButtonPanel.Height / 2 - filterButton.Height / 2));
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
            filterButtonPanel.Size = new Size(Convert.ToInt32(this.Width * 0.263), Convert.ToInt32(this.Height * 0.103));
            rectangle = new Rectangle(0, 0, filterButtonPanel.Width, filterButtonPanel.Height);
            roundedPanel = Transform.BorderRadius(rectangle, 20, false, false, true, true);
            filterButtonPanel.Region = new Region(roundedPanel);

            linePanel.Location = new Point(filterButtonPanel.Location.X, filterButtonPanel.Location.Y);
            linePanel.Size = new Size(filterButtonPanel.Width, 2);

            teachersPanel.Location = new Point(0, 7);
            teachersPanel.Size = new Size(Convert.ToInt32(this.Width * 0.673), this.Height);

            nameLabel.Font = telephoneLabel.Font = emailLabel.Font = rgLabel.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints * 0.875));
            nameLabel.ForeColor = telephoneLabel.ForeColor = emailLabel.ForeColor = rgLabel.ForeColor = Styles.filterTitleColor;

            nameTextBox.Font = telephoneTextBox.Font = emailTextBox.Font = rgTextBox.Font = new Font(Styles.customFont.FontFamily, Convert.ToInt32(Styles.customFont.SizeInPoints * 0.75));
            nameTextBox.Size = telephoneTextBox.Size = emailTextBox.Size = rgTextBox.Size = new Size(filterPanel.Width - 20, Convert.ToInt32(Styles.customFont.SizeInPoints * 0.75));

            nameLabel.Location = new Point(10, 20);
            nameTextBox.Location = new Point(10, nameLabel.Location.Y + nameLabel.Height + 10);

            telephoneLabel.Location = new Point(10, nameTextBox.Location.Y + nameTextBox.Height + 10);
            telephoneTextBox.Location = new Point(10, telephoneLabel.Location.Y + telephoneLabel.Height + 10);

            emailLabel.Location = new Point(10, telephoneTextBox.Location.Y + telephoneTextBox.Height + 10);
            emailTextBox.Location = new Point(10, emailLabel.Location.Y + emailLabel.Height + 10);

            rgLabel.Location = new Point(10, emailTextBox.Location.Y + emailTextBox.Height + 10);
            rgTextBox.Location = new Point(10, rgLabel.Location.Y + rgLabel.Height + 10);
        }

        private void loadingMessageStyle()
        {
            loadingText.Font = Styles.defaultFont;

            loadingCircle1.Location = new Point(Convert.ToInt32((teachersPanel.Width / 2) - (loadingCircle1.Width / 2)), Convert.ToInt32(this.Height / 2 - loadingCircle1.Height / 2));

            loadingText.Location = new Point(Convert.ToInt32((teachersPanel.Width / 2) - (loadingText.Width / 2)) + 10, loadingCircle1.Location.Y - loadingText.Height - 10);
        }

        private void stylePlusButton()
        {
            plusButtonPictureBox.Size = new Size(Convert.ToInt32(this.Height * 0.083), Convert.ToInt32(this.Height * 0.083));

            plusButtonPictureBox.Location = new Point(Styles.seriesSize.Width + 20 - plusButtonPictureBox.Width, teachersPanel.Height - plusButtonPictureBox.Height - 7);

            Rectangle rectangle = new Rectangle(0, 0, plusButtonPictureBox.Width, plusButtonPictureBox.Height);
            GraphicsPath roundedButton = Transform.BorderRadius(rectangle, 60, true, true, true, true);
            plusButtonPictureBox.Region = new Region(roundedButton);
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
                    teachersPanel.Controls.Add(noTeachers);
                }
                else
                {
                    for (int i = 0; i < teachers.Length; i++)
                    {
                        TeachersApiResponse teachersData = teachers[i];

                        Teachers serie = new Teachers(teachersData.Nome, teachersData.Telefone, teachersData.Email, teachersData.RG, teachersData.Foto, i);
                        teachersPanel.Controls.Add(serie.getSeriePanel());
                        teachersPanel.Size = new Size(teachersPanel.Width, teachersPanel.Height - 1);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Um erro occoreu: " + ex.ToString());
            }

          
    }

        private void Form3_Load(object sender, EventArgs e)
        {
            filterPosition();
            filterButtonStyle();

            stylePlusButton();

            loadingMessageStyle();

            listTeachers(null);
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
            data.Foto = "vazio";

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

        private void cancelSerieCreation_Click(object sender, EventArgs e)
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
            cancelTeacherCreation.Click += new EventHandler(cancelSerieCreation_Click);

            return cancelTeacherCreation;
        }

        private Button finishTeacherCreationButton()
        {
            Button finishTeacherCreation = new Button();

            finishTeacherCreation.Font = Styles.customFont;
            finishTeacherCreation.Text = "Finalizar";
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

        private void showSerieComboBox_Click(object sender, EventArgs e)
        {
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
            var apiPath = RestService.For<ApiService>(Routes.sendImageBaseUrl);
            try
            {
                var imageData = ImageToByteArray(image);
                var dataResponse = await apiPath.SendImageToApi(new ByteArrayPart(imageData, "file.png"));
                MessageBox.Show(dataResponse);
                Console.WriteLine(dataResponse);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
            int itemsCount = teachersPanel.Controls.Count;
            for (int i = itemsCount - 1; i > 0; i--)
            {
                if (teachersPanel.Controls[i].Name == "noTeachers")
                {
                    teachersPanel.Controls.Remove(teachersPanel.Controls[i]);
                    continue;
                }

                Type objectType = teachersPanel.Controls[i].GetType();

                if (objectType == typeof(Panel))
                {
                    teachersPanel.Controls.Remove(teachersPanel.Controls[i]);
                    itemsCount--;
                }
            }

            loadingText.Visible = true;
            loadingCircle1.Visible = true;

            TeacherQueryParameters filters = new TeacherQueryParameters();
            if (nameTextBox.Text.Trim() != "") filters.Nome = nameTextBox.Text.Trim();
            if (telephoneTextBox.Text.Trim() != "") filters.Telefone = telephoneTextBox.Text.Trim();
            if (emailTextBox.Text.Trim() != "") filters.Email = emailTextBox.Text.Trim();
            if (rgTextBox.Text.Trim() != "") filters.RG = rgTextBox.Text.Trim();

            listTeachers(filters);
        }
    }
}
