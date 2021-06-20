
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
            this.studentsPanel = new System.Windows.Forms.Panel();
            this.loadingCircle1 = new MRG.Controls.UI.LoadingCircle();
            this.loadingText = new System.Windows.Forms.Label();
            this.plusButtonPictureBox = new System.Windows.Forms.PictureBox();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label01Title = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.button09 = new System.Windows.Forms.Button();
            this.label05 = new System.Windows.Forms.Label();
            this.button03 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label02Title = new System.Windows.Forms.Label();
            this.label04 = new System.Windows.Forms.Label();
            this.button07 = new System.Windows.Forms.Button();
            this.button02 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button08 = new System.Windows.Forms.Button();
            this.button06 = new System.Windows.Forms.Button();
            this.label09Title = new System.Windows.Forms.Label();
            this.button05 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label07 = new System.Windows.Forms.Label();
            this.label08 = new System.Windows.Forms.Label();
            this.label03 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label06Title = new System.Windows.Forms.Label();
            this.button04 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.button01 = new System.Windows.Forms.Button();
            this.filterButtonPanel = new System.Windows.Forms.Panel();
            this.filterButton = new System.Windows.Forms.Button();
            this.linePanel = new System.Windows.Forms.Panel();
            this.studentsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plusButtonPictureBox)).BeginInit();
            this.filterPanel.SuspendLayout();
            this.filterButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // studentsPanel
            // 
            this.studentsPanel.AutoScroll = true;
            this.studentsPanel.Controls.Add(this.loadingCircle1);
            this.studentsPanel.Controls.Add(this.loadingText);
            this.studentsPanel.Location = new System.Drawing.Point(12, 18);
            this.studentsPanel.Name = "studentsPanel";
            this.studentsPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.studentsPanel.Size = new System.Drawing.Size(485, 420);
            this.studentsPanel.TabIndex = 46;
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
            // 
            // filterPanel
            // 
            this.filterPanel.AutoScroll = true;
            this.filterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.filterPanel.Controls.Add(this.label15);
            this.filterPanel.Controls.Add(this.nameTextBox);
            this.filterPanel.Controls.Add(this.label01Title);
            this.filterPanel.Controls.Add(this.label14);
            this.filterPanel.Controls.Add(this.button11);
            this.filterPanel.Controls.Add(this.button09);
            this.filterPanel.Controls.Add(this.label05);
            this.filterPanel.Controls.Add(this.button03);
            this.filterPanel.Controls.Add(this.label13);
            this.filterPanel.Controls.Add(this.label02Title);
            this.filterPanel.Controls.Add(this.label04);
            this.filterPanel.Controls.Add(this.button07);
            this.filterPanel.Controls.Add(this.button02);
            this.filterPanel.Controls.Add(this.button10);
            this.filterPanel.Controls.Add(this.button08);
            this.filterPanel.Controls.Add(this.button06);
            this.filterPanel.Controls.Add(this.label09Title);
            this.filterPanel.Controls.Add(this.button05);
            this.filterPanel.Controls.Add(this.label12);
            this.filterPanel.Controls.Add(this.label07);
            this.filterPanel.Controls.Add(this.label08);
            this.filterPanel.Controls.Add(this.label03);
            this.filterPanel.Controls.Add(this.label10);
            this.filterPanel.Controls.Add(this.label06Title);
            this.filterPanel.Controls.Add(this.button04);
            this.filterPanel.Controls.Add(this.label11);
            this.filterPanel.Controls.Add(this.button01);
            this.filterPanel.Location = new System.Drawing.Point(534, 18);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.filterPanel.Size = new System.Drawing.Size(225, 430);
            this.filterPanel.TabIndex = 48;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(56, 451);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 68;
            this.label15.Text = "Qualidade";
            // 
            // nameTextBox
            // 
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.Location = new System.Drawing.Point(15, 43);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(173, 20);
            this.nameTextBox.TabIndex = 43;
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
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(56, 420);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 67;
            this.label14.Text = "Mecânica";
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.White;
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button11.Location = new System.Drawing.Point(22, 446);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(29, 23);
            this.button11.TabIndex = 57;
            this.button11.UseVisualStyleBackColor = false;
            // 
            // button09
            // 
            this.button09.BackColor = System.Drawing.Color.White;
            this.button09.FlatAppearance.BorderSize = 0;
            this.button09.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button09.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button09.Location = new System.Drawing.Point(21, 386);
            this.button09.Name = "button09";
            this.button09.Size = new System.Drawing.Size(29, 23);
            this.button09.TabIndex = 55;
            this.button09.UseVisualStyleBackColor = false;
            // 
            // label05
            // 
            this.label05.AutoSize = true;
            this.label05.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label05.Location = new System.Drawing.Point(55, 158);
            this.label05.Name = "label05";
            this.label05.Size = new System.Drawing.Size(38, 13);
            this.label05.TabIndex = 60;
            this.label05.Text = "3º ano";
            // 
            // button03
            // 
            this.button03.BackColor = System.Drawing.Color.White;
            this.button03.FlatAppearance.BorderSize = 0;
            this.button03.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button03.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button03.Location = new System.Drawing.Point(20, 153);
            this.button03.Name = "button03";
            this.button03.Size = new System.Drawing.Size(29, 23);
            this.button03.TabIndex = 49;
            this.button03.UseVisualStyleBackColor = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(56, 391);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 66;
            this.label13.Text = "Informática";
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
            // label04
            // 
            this.label04.AutoSize = true;
            this.label04.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label04.Location = new System.Drawing.Point(55, 129);
            this.label04.Name = "label04";
            this.label04.Size = new System.Drawing.Size(38, 13);
            this.label04.TabIndex = 59;
            this.label04.Text = "2º ano";
            // 
            // button07
            // 
            this.button07.BackColor = System.Drawing.Color.White;
            this.button07.FlatAppearance.BorderSize = 0;
            this.button07.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button07.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button07.Location = new System.Drawing.Point(21, 328);
            this.button07.Name = "button07";
            this.button07.Size = new System.Drawing.Size(29, 23);
            this.button07.TabIndex = 53;
            this.button07.UseVisualStyleBackColor = false;
            // 
            // button02
            // 
            this.button02.BackColor = System.Drawing.Color.White;
            this.button02.FlatAppearance.BorderSize = 0;
            this.button02.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button02.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button02.Location = new System.Drawing.Point(20, 124);
            this.button02.Name = "button02";
            this.button02.Size = new System.Drawing.Size(29, 23);
            this.button02.TabIndex = 48;
            this.button02.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.White;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button10.Location = new System.Drawing.Point(22, 415);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(29, 23);
            this.button10.TabIndex = 56;
            this.button10.UseVisualStyleBackColor = false;
            // 
            // button08
            // 
            this.button08.BackColor = System.Drawing.Color.White;
            this.button08.FlatAppearance.BorderSize = 0;
            this.button08.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button08.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button08.Location = new System.Drawing.Point(22, 352);
            this.button08.Name = "button08";
            this.button08.Size = new System.Drawing.Size(29, 23);
            this.button08.TabIndex = 54;
            this.button08.UseVisualStyleBackColor = false;
            // 
            // button06
            // 
            this.button06.BackColor = System.Drawing.Color.White;
            this.button06.FlatAppearance.BorderSize = 0;
            this.button06.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button06.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button06.Location = new System.Drawing.Point(22, 299);
            this.button06.Name = "button06";
            this.button06.Size = new System.Drawing.Size(29, 23);
            this.button06.TabIndex = 52;
            this.button06.UseVisualStyleBackColor = false;
            // 
            // label09Title
            // 
            this.label09Title.AutoSize = true;
            this.label09Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.label09Title.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label09Title.Location = new System.Drawing.Point(13, 273);
            this.label09Title.Name = "label09Title";
            this.label09Title.Size = new System.Drawing.Size(37, 13);
            this.label09Title.TabIndex = 46;
            this.label09Title.Text = "Curso:";
            // 
            // button05
            // 
            this.button05.BackColor = System.Drawing.Color.White;
            this.button05.FlatAppearance.BorderSize = 0;
            this.button05.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button05.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button05.Location = new System.Drawing.Point(20, 238);
            this.button05.Name = "button05";
            this.button05.Size = new System.Drawing.Size(29, 23);
            this.button05.TabIndex = 51;
            this.button05.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(56, 362);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 65;
            this.label12.Text = "Geodésia";
            // 
            // label07
            // 
            this.label07.AutoSize = true;
            this.label07.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label07.Location = new System.Drawing.Point(55, 214);
            this.label07.Name = "label07";
            this.label07.Size = new System.Drawing.Size(38, 13);
            this.label07.TabIndex = 61;
            this.label07.Text = "Diurno";
            // 
            // label08
            // 
            this.label08.AutoSize = true;
            this.label08.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label08.Location = new System.Drawing.Point(55, 243);
            this.label08.Name = "label08";
            this.label08.Size = new System.Drawing.Size(45, 13);
            this.label08.TabIndex = 62;
            this.label08.Text = "Noturno";
            // 
            // label03
            // 
            this.label03.AutoSize = true;
            this.label03.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label03.Location = new System.Drawing.Point(55, 100);
            this.label03.Name = "label03";
            this.label03.Size = new System.Drawing.Size(38, 13);
            this.label03.TabIndex = 58;
            this.label03.Text = "1º ano";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(56, 304);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 63;
            this.label10.Text = "Edificações";
            // 
            // label06Title
            // 
            this.label06Title.AutoSize = true;
            this.label06Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.label06Title.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label06Title.Location = new System.Drawing.Point(12, 188);
            this.label06Title.Name = "label06Title";
            this.label06Title.Size = new System.Drawing.Size(38, 13);
            this.label06Title.TabIndex = 45;
            this.label06Title.Text = "Turno:";
            // 
            // button04
            // 
            this.button04.BackColor = System.Drawing.Color.White;
            this.button04.FlatAppearance.BorderSize = 0;
            this.button04.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button04.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button04.Location = new System.Drawing.Point(21, 209);
            this.button04.Name = "button04";
            this.button04.Size = new System.Drawing.Size(29, 23);
            this.button04.TabIndex = 50;
            this.button04.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(56, 333);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 64;
            this.label11.Text = "Enfermagem";
            // 
            // button01
            // 
            this.button01.BackColor = System.Drawing.Color.White;
            this.button01.FlatAppearance.BorderSize = 0;
            this.button01.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button01.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button01.Location = new System.Drawing.Point(20, 95);
            this.button01.Name = "button01";
            this.button01.Size = new System.Drawing.Size(29, 23);
            this.button01.TabIndex = 47;
            this.button01.UseVisualStyleBackColor = false;
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
            // 
            // linePanel
            // 
            this.linePanel.BackColor = System.Drawing.Color.White;
            this.linePanel.Location = new System.Drawing.Point(537, 454);
            this.linePanel.Name = "linePanel";
            this.linePanel.Size = new System.Drawing.Size(225, 10);
            this.linePanel.TabIndex = 50;
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
            this.Controls.Add(this.studentsPanel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form5";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form5_Load);
            this.studentsPanel.ResumeLayout(false);
            this.studentsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plusButtonPictureBox)).EndInit();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.filterButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel studentsPanel;
        private MRG.Controls.UI.LoadingCircle loadingCircle1;
        private System.Windows.Forms.Label loadingText;
        private System.Windows.Forms.PictureBox plusButtonPictureBox;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label01Title;
        private System.Windows.Forms.Panel filterButtonPanel;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Panel linePanel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button09;
        private System.Windows.Forms.Label label05;
        private System.Windows.Forms.Button button03;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label02Title;
        private System.Windows.Forms.Label label04;
        private System.Windows.Forms.Button button07;
        private System.Windows.Forms.Button button02;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button08;
        private System.Windows.Forms.Button button06;
        private System.Windows.Forms.Label label09Title;
        private System.Windows.Forms.Button button05;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label07;
        private System.Windows.Forms.Label label08;
        private System.Windows.Forms.Label label03;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label06Title;
        private System.Windows.Forms.Button button04;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button01;
    }
}