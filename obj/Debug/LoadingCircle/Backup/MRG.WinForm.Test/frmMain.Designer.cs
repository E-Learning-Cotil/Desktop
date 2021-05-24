//
// Copyright © 2006, Martin R. Gagné (martingagne@gmail.com)
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//   - Redistributions of source code must retain the above copyright notice, 
//     this list of conditions and the following disclaimer.
//
//   - Redistributions in binary form must reproduce the above copyright notice, 
//     this list of conditions and the following disclaimer in the documentation 
//     and/or other materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
// IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, 
// OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.
//

namespace MRG.WinForm.Test
{
    partial class frmMain
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
            this.btnActivate = new System.Windows.Forms.Button();
            this.btnDesactivate = new System.Windows.Forms.Button();
            this.nudOuterCircleRadius = new System.Windows.Forms.NumericUpDown();
            this.lblOuterCircleRadius = new System.Windows.Forms.Label();
            this.lblInnerCircleRadius = new System.Windows.Forms.Label();
            this.nudInnerCircleRadius = new System.Windows.Forms.NumericUpDown();
            this.lblNumberSpoke = new System.Windows.Forms.Label();
            this.nudNumberSpoke = new System.Windows.Forms.NumericUpDown();
            this.nudSpokesThickness = new System.Windows.Forms.NumericUpDown();
            this.lblSpokeThickness = new System.Windows.Forms.Label();
            this.cbColors = new System.Windows.Forms.ComboBox();
            this.btnMacOSXStyle = new System.Windows.Forms.Button();
            this.btnFireFoxStyle = new System.Windows.Forms.Button();
            this.lblLoadingCircle = new System.Windows.Forms.Label();
            this.lnkMartinGagne = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRotationSpeed = new System.Windows.Forms.Label();
            this.nudRotationSpeed = new System.Windows.Forms.NumericUpDown();
            this.btnIE7Style = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCustomizable = new System.Windows.Forms.Label();
            this.lblFireFox = new System.Windows.Forms.Label();
            this.lblIE7Style = new System.Windows.Forms.Label();
            this.lblMacOSXStyle = new System.Windows.Forms.Label();
            this.loadingCircleMacOSX = new MRG.Controls.UI.LoadingCircle();
            this.loadingCircleIE7 = new MRG.Controls.UI.LoadingCircle();
            this.loadingCircleFF = new MRG.Controls.UI.LoadingCircle();
            this.loadingCircleToolStripMenuItem1 = new MRG.Controls.UI.LoadingCircleToolStripMenuItem();
            this.loadingCircle = new MRG.Controls.UI.LoadingCircle();
            ((System.ComponentModel.ISupportInitialize)(this.nudOuterCircleRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInnerCircleRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberSpoke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpokesThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRotationSpeed)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnActivate
            // 
            this.btnActivate.Location = new System.Drawing.Point(12, 67);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(121, 23);
            this.btnActivate.TabIndex = 1;
            this.btnActivate.Text = "Activate";
            this.btnActivate.UseVisualStyleBackColor = true;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // btnDesactivate
            // 
            this.btnDesactivate.Location = new System.Drawing.Point(12, 96);
            this.btnDesactivate.Name = "btnDesactivate";
            this.btnDesactivate.Size = new System.Drawing.Size(121, 23);
            this.btnDesactivate.TabIndex = 2;
            this.btnDesactivate.Text = "Desactivate";
            this.btnDesactivate.UseVisualStyleBackColor = true;
            this.btnDesactivate.Click += new System.EventHandler(this.btnDesactivate_Click);
            // 
            // nudOuterCircleRadius
            // 
            this.nudOuterCircleRadius.Location = new System.Drawing.Point(12, 261);
            this.nudOuterCircleRadius.Name = "nudOuterCircleRadius";
            this.nudOuterCircleRadius.Size = new System.Drawing.Size(121, 22);
            this.nudOuterCircleRadius.TabIndex = 3;
            this.nudOuterCircleRadius.ValueChanged += new System.EventHandler(this.nudOuterCircleRadius_ValueChanged);
            // 
            // lblOuterCircleRadius
            // 
            this.lblOuterCircleRadius.AutoSize = true;
            this.lblOuterCircleRadius.Location = new System.Drawing.Point(9, 245);
            this.lblOuterCircleRadius.Name = "lblOuterCircleRadius";
            this.lblOuterCircleRadius.Size = new System.Drawing.Size(106, 13);
            this.lblOuterCircleRadius.TabIndex = 4;
            this.lblOuterCircleRadius.Text = "Outer Circle Radius";
            // 
            // lblInnerCircleRadius
            // 
            this.lblInnerCircleRadius.AutoSize = true;
            this.lblInnerCircleRadius.Location = new System.Drawing.Point(9, 206);
            this.lblInnerCircleRadius.Name = "lblInnerCircleRadius";
            this.lblInnerCircleRadius.Size = new System.Drawing.Size(103, 13);
            this.lblInnerCircleRadius.TabIndex = 6;
            this.lblInnerCircleRadius.Text = "Inner Circle Radius";
            // 
            // nudInnerCircleRadius
            // 
            this.nudInnerCircleRadius.Location = new System.Drawing.Point(12, 222);
            this.nudInnerCircleRadius.Name = "nudInnerCircleRadius";
            this.nudInnerCircleRadius.Size = new System.Drawing.Size(121, 22);
            this.nudInnerCircleRadius.TabIndex = 5;
            this.nudInnerCircleRadius.ValueChanged += new System.EventHandler(this.nudInnerCircleRadius_ValueChanged);
            // 
            // lblNumberSpoke
            // 
            this.lblNumberSpoke.AutoSize = true;
            this.lblNumberSpoke.Location = new System.Drawing.Point(9, 122);
            this.lblNumberSpoke.Name = "lblNumberSpoke";
            this.lblNumberSpoke.Size = new System.Drawing.Size(96, 13);
            this.lblNumberSpoke.TabIndex = 7;
            this.lblNumberSpoke.Text = "Number of spoke";
            // 
            // nudNumberSpoke
            // 
            this.nudNumberSpoke.Location = new System.Drawing.Point(12, 138);
            this.nudNumberSpoke.Name = "nudNumberSpoke";
            this.nudNumberSpoke.Size = new System.Drawing.Size(121, 22);
            this.nudNumberSpoke.TabIndex = 8;
            this.nudNumberSpoke.ValueChanged += new System.EventHandler(this.nudNumberSpoke_ValueChanged);
            // 
            // nudSpokesThickness
            // 
            this.nudSpokesThickness.Location = new System.Drawing.Point(12, 181);
            this.nudSpokesThickness.Name = "nudSpokesThickness";
            this.nudSpokesThickness.Size = new System.Drawing.Size(121, 22);
            this.nudSpokesThickness.TabIndex = 10;
            this.nudSpokesThickness.ValueChanged += new System.EventHandler(this.nudSpokesThickness_ValueChanged);
            // 
            // lblSpokeThickness
            // 
            this.lblSpokeThickness.AutoSize = true;
            this.lblSpokeThickness.Location = new System.Drawing.Point(9, 165);
            this.lblSpokeThickness.Name = "lblSpokeThickness";
            this.lblSpokeThickness.Size = new System.Drawing.Size(95, 13);
            this.lblSpokeThickness.TabIndex = 9;
            this.lblSpokeThickness.Text = "Spokes thickness";
            // 
            // cbColors
            // 
            this.cbColors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColors.FormattingEnabled = true;
            this.cbColors.Location = new System.Drawing.Point(12, 339);
            this.cbColors.Name = "cbColors";
            this.cbColors.Size = new System.Drawing.Size(121, 21);
            this.cbColors.TabIndex = 11;
            this.cbColors.SelectedIndexChanged += new System.EventHandler(this.cbColors_SelectedIndexChanged);
            // 
            // btnMacOSXStyle
            // 
            this.btnMacOSXStyle.Location = new System.Drawing.Point(12, 366);
            this.btnMacOSXStyle.Name = "btnMacOSXStyle";
            this.btnMacOSXStyle.Size = new System.Drawing.Size(121, 23);
            this.btnMacOSXStyle.TabIndex = 12;
            this.btnMacOSXStyle.Text = "MacOS X Style";
            this.btnMacOSXStyle.UseVisualStyleBackColor = true;
            this.btnMacOSXStyle.Click += new System.EventHandler(this.btnMacOSXStyle_Click);
            // 
            // btnFireFoxStyle
            // 
            this.btnFireFoxStyle.Location = new System.Drawing.Point(12, 395);
            this.btnFireFoxStyle.Name = "btnFireFoxStyle";
            this.btnFireFoxStyle.Size = new System.Drawing.Size(121, 23);
            this.btnFireFoxStyle.TabIndex = 13;
            this.btnFireFoxStyle.Text = "FireFox Style";
            this.btnFireFoxStyle.UseVisualStyleBackColor = true;
            this.btnFireFoxStyle.Click += new System.EventHandler(this.btnFireFoxStyle_Click);
            // 
            // lblLoadingCircle
            // 
            this.lblLoadingCircle.AutoSize = true;
            this.lblLoadingCircle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadingCircle.Location = new System.Drawing.Point(12, 13);
            this.lblLoadingCircle.Name = "lblLoadingCircle";
            this.lblLoadingCircle.Size = new System.Drawing.Size(168, 18);
            this.lblLoadingCircle.TabIndex = 15;
            this.lblLoadingCircle.Text = "LoadingCircle v1.1";
            this.lblLoadingCircle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lnkMartinGagne
            // 
            this.lnkMartinGagne.AutoSize = true;
            this.lnkMartinGagne.Location = new System.Drawing.Point(12, 31);
            this.lnkMartinGagne.Name = "lnkMartinGagne";
            this.lnkMartinGagne.Size = new System.Drawing.Size(93, 13);
            this.lnkMartinGagne.TabIndex = 17;
            this.lnkMartinGagne.TabStop = true;
            this.lnkMartinGagne.Text = "by Martin Gagné";
            this.lnkMartinGagne.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMartinGagne_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Color";
            // 
            // lblRotationSpeed
            // 
            this.lblRotationSpeed.AutoSize = true;
            this.lblRotationSpeed.Location = new System.Drawing.Point(9, 284);
            this.lblRotationSpeed.Name = "lblRotationSpeed";
            this.lblRotationSpeed.Size = new System.Drawing.Size(87, 13);
            this.lblRotationSpeed.TabIndex = 20;
            this.lblRotationSpeed.Text = "Rotation Speed";
            // 
            // nudRotationSpeed
            // 
            this.nudRotationSpeed.Location = new System.Drawing.Point(12, 300);
            this.nudRotationSpeed.Name = "nudRotationSpeed";
            this.nudRotationSpeed.Size = new System.Drawing.Size(121, 22);
            this.nudRotationSpeed.TabIndex = 19;
            this.nudRotationSpeed.ValueChanged += new System.EventHandler(this.nudRotationSpeed_ValueChanged);
            // 
            // btnIE7Style
            // 
            this.btnIE7Style.Location = new System.Drawing.Point(12, 424);
            this.btnIE7Style.Name = "btnIE7Style";
            this.btnIE7Style.Size = new System.Drawing.Size(121, 23);
            this.btnIE7Style.TabIndex = 21;
            this.btnIE7Style.Text = "IE 7 Style";
            this.btnIE7Style.UseVisualStyleBackColor = true;
            this.btnIE7Style.Click += new System.EventHandler(this.btnIE7Style_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadingCircleToolStripMenuItem1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 457);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(356, 22);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel1.Text = "Loading...";
            // 
            // lblCustomizable
            // 
            this.lblCustomizable.AutoSize = true;
            this.lblCustomizable.Location = new System.Drawing.Point(148, 122);
            this.lblCustomizable.Name = "lblCustomizable";
            this.lblCustomizable.Size = new System.Drawing.Size(144, 13);
            this.lblCustomizable.TabIndex = 23;
            this.lblCustomizable.Text = "Customizable LoadingCirle";
            // 
            // lblFireFox
            // 
            this.lblFireFox.AutoSize = true;
            this.lblFireFox.Location = new System.Drawing.Point(148, 206);
            this.lblFireFox.Name = "lblFireFox";
            this.lblFireFox.Size = new System.Drawing.Size(71, 13);
            this.lblFireFox.TabIndex = 25;
            this.lblFireFox.Text = "FireFox Style";
            // 
            // lblIE7Style
            // 
            this.lblIE7Style.AutoSize = true;
            this.lblIE7Style.Location = new System.Drawing.Point(148, 284);
            this.lblIE7Style.Name = "lblIE7Style";
            this.lblIE7Style.Size = new System.Drawing.Size(49, 13);
            this.lblIE7Style.TabIndex = 27;
            this.lblIE7Style.Text = "IE7 Style";
            // 
            // lblMacOSXStyle
            // 
            this.lblMacOSXStyle.AutoSize = true;
            this.lblMacOSXStyle.Location = new System.Drawing.Point(148, 363);
            this.lblMacOSXStyle.Name = "lblMacOSXStyle";
            this.lblMacOSXStyle.Size = new System.Drawing.Size(79, 13);
            this.lblMacOSXStyle.TabIndex = 29;
            this.lblMacOSXStyle.Text = "Mac OSX Style";
            // 
            // loadingCircleMacOSX
            // 
            this.loadingCircleMacOSX.Active = false;
            this.loadingCircleMacOSX.BackColor = System.Drawing.Color.Transparent;
            this.loadingCircleMacOSX.Color = System.Drawing.Color.DarkGray;
            this.loadingCircleMacOSX.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.loadingCircleMacOSX.InnerCircleRadius = 5;
            this.loadingCircleMacOSX.Location = new System.Drawing.Point(151, 387);
            this.loadingCircleMacOSX.Name = "loadingCircleMacOSX";
            this.loadingCircleMacOSX.NumberSpoke = 12;
            this.loadingCircleMacOSX.OuterCircleRadius = 11;
            this.loadingCircleMacOSX.RotationSpeed = 80;
            this.loadingCircleMacOSX.Size = new System.Drawing.Size(193, 60);
            this.loadingCircleMacOSX.SpokeThickness = 2;
            this.loadingCircleMacOSX.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircleMacOSX.TabIndex = 28;
            this.loadingCircleMacOSX.Text = "loadingCircle1";
            // 
            // loadingCircleIE7
            // 
            this.loadingCircleIE7.Active = false;
            this.loadingCircleIE7.BackColor = System.Drawing.Color.Transparent;
            this.loadingCircleIE7.Color = System.Drawing.Color.DarkGray;
            this.loadingCircleIE7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.loadingCircleIE7.InnerCircleRadius = 8;
            this.loadingCircleIE7.Location = new System.Drawing.Point(151, 300);
            this.loadingCircleIE7.Name = "loadingCircleIE7";
            this.loadingCircleIE7.NumberSpoke = 24;
            this.loadingCircleIE7.OuterCircleRadius = 9;
            this.loadingCircleIE7.RotationSpeed = 80;
            this.loadingCircleIE7.Size = new System.Drawing.Size(193, 60);
            this.loadingCircleIE7.SpokeThickness = 4;
            this.loadingCircleIE7.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.IE7;
            this.loadingCircleIE7.TabIndex = 26;
            this.loadingCircleIE7.Text = "loadingCircle1";
            // 
            // loadingCircleFF
            // 
            this.loadingCircleFF.Active = false;
            this.loadingCircleFF.BackColor = System.Drawing.Color.Transparent;
            this.loadingCircleFF.Color = System.Drawing.Color.DarkGray;
            this.loadingCircleFF.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.loadingCircleFF.InnerCircleRadius = 6;
            this.loadingCircleFF.Location = new System.Drawing.Point(151, 222);
            this.loadingCircleFF.Name = "loadingCircleFF";
            this.loadingCircleFF.NumberSpoke = 9;
            this.loadingCircleFF.OuterCircleRadius = 7;
            this.loadingCircleFF.RotationSpeed = 80;
            this.loadingCircleFF.Size = new System.Drawing.Size(193, 59);
            this.loadingCircleFF.SpokeThickness = 4;
            this.loadingCircleFF.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.Firefox;
            this.loadingCircleFF.TabIndex = 24;
            this.loadingCircleFF.Text = "loadingCircleFF";
            // 
            // loadingCircleToolStripMenuItem1
            // 
            // 
            // loadingCircleToolStripMenuItem1
            // 
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.AccessibleName = "loadingCircleToolStripMenuItem1";
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.Active = false;
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.Color = System.Drawing.Color.DarkGray;
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.InnerCircleRadius = 6;
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.Location = new System.Drawing.Point(1, 2);
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.Name = "loadingCircleToolStripMenuItem1";
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.NumberSpoke = 9;
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.OuterCircleRadius = 7;
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.RotationSpeed = 100;
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.Size = new System.Drawing.Size(22, 20);
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.SpokeThickness = 4;
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.Firefox;
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.TabIndex = 1;
            this.loadingCircleToolStripMenuItem1.LoadingCircleControl.Text = "loadingCircleToolStripMenuItem1";
            this.loadingCircleToolStripMenuItem1.Name = "loadingCircleToolStripMenuItem1";
            this.loadingCircleToolStripMenuItem1.Size = new System.Drawing.Size(22, 20);
            this.loadingCircleToolStripMenuItem1.Text = "loadingCircleToolStripMenuItem1";
            // 
            // loadingCircle
            // 
            this.loadingCircle.Active = false;
            this.loadingCircle.BackColor = System.Drawing.Color.Transparent;
            this.loadingCircle.Color = System.Drawing.Color.DarkGray;
            this.loadingCircle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.loadingCircle.InnerCircleRadius = 5;
            this.loadingCircle.Location = new System.Drawing.Point(151, 138);
            this.loadingCircle.Name = "loadingCircle";
            this.loadingCircle.NumberSpoke = 12;
            this.loadingCircle.OuterCircleRadius = 11;
            this.loadingCircle.RotationSpeed = 80;
            this.loadingCircle.Size = new System.Drawing.Size(193, 65);
            this.loadingCircle.SpokeThickness = 2;
            this.loadingCircle.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircle.TabIndex = 14;
            this.loadingCircle.Text = "loadingCircle";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(356, 479);
            this.Controls.Add(this.lblMacOSXStyle);
            this.Controls.Add(this.loadingCircleMacOSX);
            this.Controls.Add(this.lblIE7Style);
            this.Controls.Add(this.loadingCircleIE7);
            this.Controls.Add(this.lblFireFox);
            this.Controls.Add(this.loadingCircleFF);
            this.Controls.Add(this.lblCustomizable);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnIE7Style);
            this.Controls.Add(this.lblRotationSpeed);
            this.Controls.Add(this.nudRotationSpeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lnkMartinGagne);
            this.Controls.Add(this.lblLoadingCircle);
            this.Controls.Add(this.loadingCircle);
            this.Controls.Add(this.btnFireFoxStyle);
            this.Controls.Add(this.btnMacOSXStyle);
            this.Controls.Add(this.cbColors);
            this.Controls.Add(this.nudSpokesThickness);
            this.Controls.Add(this.lblSpokeThickness);
            this.Controls.Add(this.nudNumberSpoke);
            this.Controls.Add(this.lblNumberSpoke);
            this.Controls.Add(this.lblInnerCircleRadius);
            this.Controls.Add(this.nudInnerCircleRadius);
            this.Controls.Add(this.lblOuterCircleRadius);
            this.Controls.Add(this.nudOuterCircleRadius);
            this.Controls.Add(this.btnDesactivate);
            this.Controls.Add(this.btnActivate);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "LoadingCircle v1.1 by Martin Gagné";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudOuterCircleRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInnerCircleRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberSpoke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpokesThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRotationSpeed)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private LoadingCircle loadingCircle;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Button btnDesactivate;
        private System.Windows.Forms.NumericUpDown nudOuterCircleRadius;
        private System.Windows.Forms.Label lblOuterCircleRadius;
        private System.Windows.Forms.Label lblInnerCircleRadius;
        private System.Windows.Forms.NumericUpDown nudInnerCircleRadius;
        private System.Windows.Forms.Label lblNumberSpoke;
        private System.Windows.Forms.NumericUpDown nudNumberSpoke;
        private System.Windows.Forms.NumericUpDown nudSpokesThickness;
        private System.Windows.Forms.Label lblSpokeThickness;
        private System.Windows.Forms.ComboBox cbColors;
        private System.Windows.Forms.Button btnMacOSXStyle;
        private System.Windows.Forms.Button btnFireFoxStyle;
        private MRG.Controls.UI.LoadingCircle loadingCircle;
        private System.Windows.Forms.Label lblLoadingCircle;
        private System.Windows.Forms.LinkLabel lnkMartinGagne;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRotationSpeed;
        private System.Windows.Forms.NumericUpDown nudRotationSpeed;
        private System.Windows.Forms.Button btnIE7Style;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private MRG.Controls.UI.LoadingCircleToolStripMenuItem loadingCircleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label lblCustomizable;
        private System.Windows.Forms.Label lblFireFox;
        private MRG.Controls.UI.LoadingCircle loadingCircleFF;
        private System.Windows.Forms.Label lblIE7Style;
        private MRG.Controls.UI.LoadingCircle loadingCircleIE7;
        private System.Windows.Forms.Label lblMacOSXStyle;
        private MRG.Controls.UI.LoadingCircle loadingCircleMacOSX;

    }
}

