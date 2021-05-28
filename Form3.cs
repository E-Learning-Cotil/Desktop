using Newtonsoft.Json;
using Refit;
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
    public partial class Form3 : Form
    {
        #region Declaração de Variáveis
        TeachersApiResponse[] teachers;

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

            nameLabel.Font = telephoneLabel.Font = emailLabel.Font = new Font(Styles.defaultFont.FontFamily, Convert.ToInt32(Styles.defaultFont.SizeInPoints * 0.875));
            nameLabel.ForeColor = telephoneLabel.ForeColor = emailLabel.ForeColor = Styles.filterTitleColor;

            nameTextBox.Font = telephoneTextBox.Font = emailTextBox.Font = new Font(Styles.customFont.FontFamily, Convert.ToInt32(Styles.customFont.SizeInPoints * 0.75));
            nameTextBox.Size = telephoneTextBox.Size = emailTextBox.Size = new Size(filterPanel.Width - 20, Convert.ToInt32(Styles.customFont.SizeInPoints * 0.75));

            nameLabel.Location = new Point(10, 20);
            nameTextBox.Location = new Point(10, nameLabel.Location.Y + nameLabel.Height + 10);

            telephoneLabel.Location = new Point(10, nameTextBox.Location.Y + nameTextBox.Height + 10);
            telephoneTextBox.Location = new Point(10, telephoneLabel.Location.Y + telephoneLabel.Height + 10);

            emailLabel.Location = new Point(10, telephoneTextBox.Location.Y + telephoneTextBox.Height + 10);
            emailTextBox.Location = new Point(10, emailLabel.Location.Y + emailLabel.Height + 10);
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

                        Teachers serie = new Teachers(teachersData.Nome, teachersData.Telefone, teachersData.Email,teachersData.RG, teachersData.Foto,i);
                        teachersPanel.Controls.Add(serie.getSeriePanel());
                        teachersPanel.Size = new Size(teachersPanel.Width, teachersPanel.Height - 1);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro durante a conexão com a base de dados. " + ex.Message);
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

        private void plusButtonPictureBox_Click(object sender, EventArgs e)
        {

        }

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
            if (nameTextBox.Text.Trim() != "") filters.nome = nameTextBox.Text;
            if (telephoneTextBox.Text.Trim() != "") filters.telefone = telephoneTextBox.Text;
            if (emailTextBox.Text.Trim() != "") filters.email = emailTextBox.Text;

            listTeachers(filters);
        }
    }
}
