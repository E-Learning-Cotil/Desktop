
namespace ElearningDesktop
{
    partial class Form3
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
            this.textBox4_RG = new System.Windows.Forms.TextBox();
            this.label04Title_RG = new System.Windows.Forms.Label();
            this.textBox3_Email = new System.Windows.Forms.TextBox();
            this.label03Title_Email = new System.Windows.Forms.Label();
            this.textBox2_Telefone = new System.Windows.Forms.TextBox();
            this.label02Title_Telefone = new System.Windows.Forms.Label();
            this.textBox1_Nome = new System.Windows.Forms.TextBox();
            this.label01Title_Nome = new System.Windows.Forms.Label();
            this.linePanel = new System.Windows.Forms.Panel();
            this.filterButtonPanel = new System.Windows.Forms.Panel();
            this.filterButton = new System.Windows.Forms.Button();
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
            this.centralPanel.Location = new System.Drawing.Point(12, 12);
            this.centralPanel.Name = "centralPanel";
            this.centralPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.centralPanel.Size = new System.Drawing.Size(485, 420);
            this.centralPanel.TabIndex = 4;
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
            this.plusButtonPictureBox.Location = new System.Drawing.Point(447, 411);
            this.plusButtonPictureBox.Name = "plusButtonPictureBox";
            this.plusButtonPictureBox.Padding = new System.Windows.Forms.Padding(15);
            this.plusButtonPictureBox.Size = new System.Drawing.Size(50, 50);
            this.plusButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.plusButtonPictureBox.TabIndex = 5;
            this.plusButtonPictureBox.TabStop = false;
            this.plusButtonPictureBox.Click += new System.EventHandler(this.plusButtonPictureBox_Click);
            // 
            // filterPanel
            // 
            this.filterPanel.AutoScroll = true;
            this.filterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.filterPanel.Controls.Add(this.textBox4_RG);
            this.filterPanel.Controls.Add(this.label04Title_RG);
            this.filterPanel.Controls.Add(this.textBox3_Email);
            this.filterPanel.Controls.Add(this.label03Title_Email);
            this.filterPanel.Controls.Add(this.textBox2_Telefone);
            this.filterPanel.Controls.Add(this.label02Title_Telefone);
            this.filterPanel.Controls.Add(this.textBox1_Nome);
            this.filterPanel.Controls.Add(this.label01Title_Nome);
            this.filterPanel.Location = new System.Drawing.Point(503, 12);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.filterPanel.Size = new System.Drawing.Size(225, 430);
            this.filterPanel.TabIndex = 6;
            // 
            // textBox4_RG
            // 
            this.textBox4_RG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4_RG.Location = new System.Drawing.Point(6, 179);
            this.textBox4_RG.Name = "textBox4_RG";
            this.textBox4_RG.Size = new System.Drawing.Size(173, 20);
            this.textBox4_RG.TabIndex = 49;
            // 
            // label04Title_RG
            // 
            this.label04Title_RG.AutoSize = true;
            this.label04Title_RG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.label04Title_RG.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label04Title_RG.Location = new System.Drawing.Point(3, 163);
            this.label04Title_RG.Margin = new System.Windows.Forms.Padding(0);
            this.label04Title_RG.Name = "label04Title_RG";
            this.label04Title_RG.Size = new System.Drawing.Size(26, 13);
            this.label04Title_RG.TabIndex = 48;
            this.label04Title_RG.Text = "RG:";
            // 
            // textBox3_Email
            // 
            this.textBox3_Email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3_Email.Location = new System.Drawing.Point(6, 126);
            this.textBox3_Email.Name = "textBox3_Email";
            this.textBox3_Email.Size = new System.Drawing.Size(173, 20);
            this.textBox3_Email.TabIndex = 47;
            // 
            // label03Title_Email
            // 
            this.label03Title_Email.AutoSize = true;
            this.label03Title_Email.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.label03Title_Email.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label03Title_Email.Location = new System.Drawing.Point(3, 110);
            this.label03Title_Email.Margin = new System.Windows.Forms.Padding(0);
            this.label03Title_Email.Name = "label03Title_Email";
            this.label03Title_Email.Size = new System.Drawing.Size(38, 13);
            this.label03Title_Email.TabIndex = 46;
            this.label03Title_Email.Text = "E-mail:";
            // 
            // textBox2_Telefone
            // 
            this.textBox2_Telefone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2_Telefone.Location = new System.Drawing.Point(6, 75);
            this.textBox2_Telefone.Name = "textBox2_Telefone";
            this.textBox2_Telefone.Size = new System.Drawing.Size(173, 20);
            this.textBox2_Telefone.TabIndex = 45;
            // 
            // label02Title_Telefone
            // 
            this.label02Title_Telefone.AutoSize = true;
            this.label02Title_Telefone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.label02Title_Telefone.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label02Title_Telefone.Location = new System.Drawing.Point(3, 59);
            this.label02Title_Telefone.Margin = new System.Windows.Forms.Padding(0);
            this.label02Title_Telefone.Name = "label02Title_Telefone";
            this.label02Title_Telefone.Size = new System.Drawing.Size(52, 13);
            this.label02Title_Telefone.TabIndex = 44;
            this.label02Title_Telefone.Text = "Telefone:";
            // 
            // textBox1_Nome
            // 
            this.textBox1_Nome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1_Nome.Location = new System.Drawing.Point(6, 26);
            this.textBox1_Nome.Name = "textBox1_Nome";
            this.textBox1_Nome.Size = new System.Drawing.Size(173, 20);
            this.textBox1_Nome.TabIndex = 43;
            // 
            // label01Title_Nome
            // 
            this.label01Title_Nome.AutoSize = true;
            this.label01Title_Nome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.label01Title_Nome.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label01Title_Nome.Location = new System.Drawing.Point(3, 10);
            this.label01Title_Nome.Margin = new System.Windows.Forms.Padding(0);
            this.label01Title_Nome.Name = "label01Title_Nome";
            this.label01Title_Nome.Size = new System.Drawing.Size(38, 13);
            this.label01Title_Nome.TabIndex = 0;
            this.label01Title_Nome.Text = "Nome:";
            // 
            // linePanel
            // 
            this.linePanel.BackColor = System.Drawing.Color.White;
            this.linePanel.Location = new System.Drawing.Point(503, 446);
            this.linePanel.Name = "linePanel";
            this.linePanel.Size = new System.Drawing.Size(225, 10);
            this.linePanel.TabIndex = 44;
            // 
            // filterButtonPanel
            // 
            this.filterButtonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.filterButtonPanel.Controls.Add(this.filterButton);
            this.filterButtonPanel.Location = new System.Drawing.Point(503, 446);
            this.filterButtonPanel.Name = "filterButtonPanel";
            this.filterButtonPanel.Size = new System.Drawing.Size(225, 61);
            this.filterButtonPanel.TabIndex = 43;
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
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(740, 571);
            this.Controls.Add(this.linePanel);
            this.Controls.Add(this.filterButtonPanel);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.plusButtonPictureBox);
            this.Controls.Add(this.centralPanel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form3";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form3_Load);
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
        private System.Windows.Forms.Label label01Title_Nome;
        private System.Windows.Forms.TextBox textBox3_Email;
        private System.Windows.Forms.Label label03Title_Email;
        private System.Windows.Forms.TextBox textBox2_Telefone;
        private System.Windows.Forms.Label label02Title_Telefone;
        private System.Windows.Forms.TextBox textBox1_Nome;
        private System.Windows.Forms.Panel linePanel;
        private System.Windows.Forms.Panel filterButtonPanel;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.TextBox textBox4_RG;
        private System.Windows.Forms.Label label04Title_RG;
    }
}