
namespace ElearningDesktop
{
    partial class Form4
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
            this.linePanel = new System.Windows.Forms.Panel();
            this.filterButtonPanel = new System.Windows.Forms.Panel();
            this.filterButton = new System.Windows.Forms.Button();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.raTextBox = new System.Windows.Forms.TextBox();
            this.raLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.telephoneTextBox = new System.Windows.Forms.TextBox();
            this.telephoneLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.plusButtonPictureBox = new System.Windows.Forms.PictureBox();
            this.studentsPanel = new System.Windows.Forms.Panel();
            this.loadingCircle1 = new MRG.Controls.UI.LoadingCircle();
            this.loadingText = new System.Windows.Forms.Label();
            this.filterButtonPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plusButtonPictureBox)).BeginInit();
            this.studentsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // linePanel
            // 
            this.linePanel.BackColor = System.Drawing.Color.White;
            this.linePanel.Location = new System.Drawing.Point(503, 443);
            this.linePanel.Name = "linePanel";
            this.linePanel.Size = new System.Drawing.Size(225, 10);
            this.linePanel.TabIndex = 49;
            // 
            // filterButtonPanel
            // 
            this.filterButtonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.filterButtonPanel.Controls.Add(this.filterButton);
            this.filterButtonPanel.Location = new System.Drawing.Point(503, 443);
            this.filterButtonPanel.Name = "filterButtonPanel";
            this.filterButtonPanel.Size = new System.Drawing.Size(225, 61);
            this.filterButtonPanel.TabIndex = 48;
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
            // 
            // filterPanel
            // 
            this.filterPanel.AutoScroll = true;
            this.filterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.filterPanel.Controls.Add(this.raTextBox);
            this.filterPanel.Controls.Add(this.raLabel);
            this.filterPanel.Controls.Add(this.emailTextBox);
            this.filterPanel.Controls.Add(this.emailLabel);
            this.filterPanel.Controls.Add(this.telephoneTextBox);
            this.filterPanel.Controls.Add(this.telephoneLabel);
            this.filterPanel.Controls.Add(this.nameTextBox);
            this.filterPanel.Controls.Add(this.nameLabel);
            this.filterPanel.Location = new System.Drawing.Point(503, 9);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.filterPanel.Size = new System.Drawing.Size(225, 430);
            this.filterPanel.TabIndex = 47;
            // 
            // raTextBox
            // 
            this.raTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.raTextBox.Location = new System.Drawing.Point(6, 179);
            this.raTextBox.Name = "raTextBox";
            this.raTextBox.Size = new System.Drawing.Size(173, 20);
            this.raTextBox.TabIndex = 49;
            // 
            // raLabel
            // 
            this.raLabel.AutoSize = true;
            this.raLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.raLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.raLabel.Location = new System.Drawing.Point(3, 163);
            this.raLabel.Margin = new System.Windows.Forms.Padding(0);
            this.raLabel.Name = "raLabel";
            this.raLabel.Size = new System.Drawing.Size(25, 13);
            this.raLabel.TabIndex = 48;
            this.raLabel.Text = "RA:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailTextBox.Location = new System.Drawing.Point(6, 126);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(173, 20);
            this.emailTextBox.TabIndex = 47;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.emailLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.emailLabel.Location = new System.Drawing.Point(3, 110);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(38, 13);
            this.emailLabel.TabIndex = 46;
            this.emailLabel.Text = "E-mail:";
            // 
            // telephoneTextBox
            // 
            this.telephoneTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.telephoneTextBox.Location = new System.Drawing.Point(6, 75);
            this.telephoneTextBox.Name = "telephoneTextBox";
            this.telephoneTextBox.Size = new System.Drawing.Size(173, 20);
            this.telephoneTextBox.TabIndex = 45;
            // 
            // telephoneLabel
            // 
            this.telephoneLabel.AutoSize = true;
            this.telephoneLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.telephoneLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.telephoneLabel.Location = new System.Drawing.Point(3, 59);
            this.telephoneLabel.Margin = new System.Windows.Forms.Padding(0);
            this.telephoneLabel.Name = "telephoneLabel";
            this.telephoneLabel.Size = new System.Drawing.Size(52, 13);
            this.telephoneLabel.TabIndex = 44;
            this.telephoneLabel.Text = "Telefone:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.Location = new System.Drawing.Point(6, 26);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(173, 20);
            this.nameTextBox.TabIndex = 43;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.nameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nameLabel.Location = new System.Drawing.Point(3, 10);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Nome:";
            // 
            // plusButtonPictureBox
            // 
            this.plusButtonPictureBox.BackColor = System.Drawing.Color.White;
            this.plusButtonPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.plusButtonPictureBox.Image = global::ElearningDesktop.Properties.Resources.plus;
            this.plusButtonPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.plusButtonPictureBox.Location = new System.Drawing.Point(447, 408);
            this.plusButtonPictureBox.Name = "plusButtonPictureBox";
            this.plusButtonPictureBox.Padding = new System.Windows.Forms.Padding(15);
            this.plusButtonPictureBox.Size = new System.Drawing.Size(50, 50);
            this.plusButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.plusButtonPictureBox.TabIndex = 46;
            this.plusButtonPictureBox.TabStop = false;
            // 
            // studentsPanel
            // 
            this.studentsPanel.AutoScroll = true;
            this.studentsPanel.Controls.Add(this.loadingCircle1);
            this.studentsPanel.Controls.Add(this.loadingText);
            this.studentsPanel.Location = new System.Drawing.Point(12, 9);
            this.studentsPanel.Name = "studentsPanel";
            this.studentsPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.studentsPanel.Size = new System.Drawing.Size(485, 420);
            this.studentsPanel.TabIndex = 45;
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
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(740, 571);
            this.Controls.Add(this.linePanel);
            this.Controls.Add(this.filterButtonPanel);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.plusButtonPictureBox);
            this.Controls.Add(this.studentsPanel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form4";
            this.Text = "Form4";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.filterButtonPanel.ResumeLayout(false);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plusButtonPictureBox)).EndInit();
            this.studentsPanel.ResumeLayout(false);
            this.studentsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel linePanel;
        private System.Windows.Forms.Panel filterButtonPanel;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.TextBox raTextBox;
        private System.Windows.Forms.Label raLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox telephoneTextBox;
        private System.Windows.Forms.Label telephoneLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.PictureBox plusButtonPictureBox;
        private System.Windows.Forms.Panel studentsPanel;
        private MRG.Controls.UI.LoadingCircle loadingCircle1;
        private System.Windows.Forms.Label loadingText;
    }
}