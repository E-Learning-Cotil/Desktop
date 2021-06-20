
namespace ElearningDesktop
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.centralPanel = new System.Windows.Forms.Panel();
            this.loadingCircle1 = new MRG.Controls.UI.LoadingCircle();
            this.loadingText = new System.Windows.Forms.Label();
            this.plusButtonPictureBox = new System.Windows.Forms.PictureBox();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.textBox01_NomeTurma = new System.Windows.Forms.TextBox();
            this.label01Title = new System.Windows.Forms.Label();
            this.label02Title = new System.Windows.Forms.Label();
            this.label03Title = new System.Windows.Forms.Label();
            this.filterButtonPanel = new System.Windows.Forms.Panel();
            this.filterButton = new System.Windows.Forms.Button();
            this.linePanel = new System.Windows.Forms.Panel();
            this.comboBox01_Serie = new System.Windows.Forms.ComboBox();
            this.comboBox02_Professor = new System.Windows.Forms.ComboBox();
            this.centralPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plusButtonPictureBox)).BeginInit();
            this.filterPanel.SuspendLayout();
            this.filterButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // centralPanel
            // 
            this.centralPanel.AutoScroll = true;
            this.centralPanel.Controls.Add(this.loadingCircle1);
            this.centralPanel.Controls.Add(this.loadingText);
            this.centralPanel.Location = new System.Drawing.Point(12, 18);
            this.centralPanel.Name = "centralPanel";
            this.centralPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.centralPanel.Size = new System.Drawing.Size(485, 420);
            this.centralPanel.TabIndex = 46;
            // 
            // loadingCircle1
            // 
            this.loadingCircle1.Active = true;
            this.loadingCircle1.BackColor = System.Drawing.Color.Transparent;
            this.loadingCircle1.Color = System.Drawing.Color.DarkGray;
            this.loadingCircle1.InnerCircleRadius = 8;
            this.loadingCircle1.Location = new System.Drawing.Point(17, 10);
            this.loadingCircle1.Name = "loadingCircle1";
            this.loadingCircle1.NumberSpoke = 24;
            this.loadingCircle1.OuterCircleRadius = 9;
            this.loadingCircle1.RotationSpeed = 20;
            this.loadingCircle1.Size = new System.Drawing.Size(33, 23);
            this.loadingCircle1.SpokeThickness = 4;
            this.loadingCircle1.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.IE7;
            this.loadingCircle1.TabIndex = 1;
            this.loadingCircle1.Text = "loadingCircle1";
            // 
            // loadingText
            // 
            this.loadingText.AutoSize = true;
            this.loadingText.Font = new System.Drawing.Font("Wide Latin", 8.25F, System.Drawing.FontStyle.Bold);
            this.loadingText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.loadingText.Location = new System.Drawing.Point(98, 19);
            this.loadingText.Name = "loadingText";
            this.loadingText.Size = new System.Drawing.Size(150, 14);
            this.loadingText.TabIndex = 0;
            this.loadingText.Text = "Carregando ...";
            // 
            // plusButtonPictureBox
            // 
            this.plusButtonPictureBox.BackColor = System.Drawing.Color.White;
            this.plusButtonPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.plusButtonPictureBox.Image = global::ElearningDesktop.Properties.Resources.plus;
            this.plusButtonPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.plusButtonPictureBox.Location = new System.Drawing.Point(465, 388);
            this.plusButtonPictureBox.Name = "plusButtonPictureBox";
            this.plusButtonPictureBox.Padding = new System.Windows.Forms.Padding(15);
            this.plusButtonPictureBox.Size = new System.Drawing.Size(50, 50);
            this.plusButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.plusButtonPictureBox.TabIndex = 47;
            this.plusButtonPictureBox.TabStop = false;
            this.plusButtonPictureBox.Click += new System.EventHandler(this.plusButtonPictureBox_Click);
            // 
            // filterPanel
            // 
            this.filterPanel.AutoScroll = true;
            this.filterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.filterPanel.Controls.Add(this.comboBox02_Professor);
            this.filterPanel.Controls.Add(this.comboBox01_Serie);
            this.filterPanel.Controls.Add(this.textBox01_NomeTurma);
            this.filterPanel.Controls.Add(this.label01Title);
            this.filterPanel.Controls.Add(this.label02Title);
            this.filterPanel.Controls.Add(this.label03Title);
            this.filterPanel.Location = new System.Drawing.Point(534, 18);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.filterPanel.Size = new System.Drawing.Size(225, 430);
            this.filterPanel.TabIndex = 48;
            // 
            // textBox01_NomeTurma
            // 
            this.textBox01_NomeTurma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox01_NomeTurma.Location = new System.Drawing.Point(15, 43);
            this.textBox01_NomeTurma.Name = "textBox01_NomeTurma";
            this.textBox01_NomeTurma.Size = new System.Drawing.Size(173, 20);
            this.textBox01_NomeTurma.TabIndex = 43;
            // 
            // label01Title
            // 
            this.label01Title.AutoSize = true;
            this.label01Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.label01Title.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label01Title.Location = new System.Drawing.Point(13, 19);
            this.label01Title.Margin = new System.Windows.Forms.Padding(0);
            this.label01Title.Name = "label01Title";
            this.label01Title.Size = new System.Drawing.Size(38, 13);
            this.label01Title.TabIndex = 0;
            this.label01Title.Text = "Nome:";
            // 
            // label02Title
            // 
            this.label02Title.AutoSize = true;
            this.label02Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.label02Title.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label02Title.Location = new System.Drawing.Point(12, 76);
            this.label02Title.Margin = new System.Windows.Forms.Padding(0);
            this.label02Title.Name = "label02Title";
            this.label02Title.Size = new System.Drawing.Size(34, 13);
            this.label02Title.TabIndex = 44;
            this.label02Title.Text = "Série:";
            // 
            // label03Title
            // 
            this.label03Title.AutoSize = true;
            this.label03Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.label03Title.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label03Title.Location = new System.Drawing.Point(12, 132);
            this.label03Title.Name = "label03Title";
            this.label03Title.Size = new System.Drawing.Size(54, 13);
            this.label03Title.TabIndex = 46;
            this.label03Title.Text = "Professor:";
            // 
            // filterButtonPanel
            // 
            this.filterButtonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.filterButtonPanel.Controls.Add(this.filterButton);
            this.filterButtonPanel.Location = new System.Drawing.Point(534, 454);
            this.filterButtonPanel.Name = "filterButtonPanel";
            this.filterButtonPanel.Size = new System.Drawing.Size(225, 61);
            this.filterButtonPanel.TabIndex = 49;
            // 
            // filterButton
            // 
            this.filterButton.BackColor = System.Drawing.Color.White;
            this.filterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filterButton.ForeColor = System.Drawing.Color.Black;
            this.filterButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.filterButton.Location = new System.Drawing.Point(79, 19);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 23);
            this.filterButton.TabIndex = 2;
            this.filterButton.Text = "Filtrar";
            this.filterButton.UseVisualStyleBackColor = false;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // linePanel
            // 
            this.linePanel.BackColor = System.Drawing.Color.White;
            this.linePanel.Location = new System.Drawing.Point(537, 454);
            this.linePanel.Name = "linePanel";
            this.linePanel.Size = new System.Drawing.Size(225, 10);
            this.linePanel.TabIndex = 50;
            // 
            // comboBox01_Serie
            // 
            this.comboBox01_Serie.FormattingEnabled = true;
            this.comboBox01_Serie.Location = new System.Drawing.Point(16, 92);
            this.comboBox01_Serie.Name = "comboBox01_Serie";
            this.comboBox01_Serie.Size = new System.Drawing.Size(172, 21);
            this.comboBox01_Serie.TabIndex = 69;
            // 
            // comboBox02_Professor
            // 
            this.comboBox02_Professor.FormattingEnabled = true;
            this.comboBox02_Professor.Location = new System.Drawing.Point(15, 148);
            this.comboBox02_Professor.Name = "comboBox02_Professor";
            this.comboBox02_Professor.Size = new System.Drawing.Size(172, 21);
            this.comboBox02_Professor.TabIndex = 70;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(800, 538);
            this.Controls.Add(this.linePanel);
            this.Controls.Add(this.filterButtonPanel);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.plusButtonPictureBox);
            this.Controls.Add(this.centralPanel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form5";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form5_Load);
            this.centralPanel.ResumeLayout(false);
            this.centralPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plusButtonPictureBox)).EndInit();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.filterButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel centralPanel;
        private MRG.Controls.UI.LoadingCircle loadingCircle1;
        private System.Windows.Forms.Label loadingText;
        private System.Windows.Forms.PictureBox plusButtonPictureBox;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.TextBox textBox01_NomeTurma;
        private System.Windows.Forms.Label label01Title;
        private System.Windows.Forms.Panel filterButtonPanel;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Panel linePanel;
        private System.Windows.Forms.Label label02Title;
        private System.Windows.Forms.Label label03Title;
        private System.Windows.Forms.ComboBox comboBox01_Serie;
        private System.Windows.Forms.ComboBox comboBox02_Professor;
    }
}