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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MRG.WinForm.Test
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            loadingCircle.Active = true;
            loadingCircleFF.Active = true;
            loadingCircleIE7.Active = true;
            loadingCircleMacOSX.Active = true;
            loadingCircleToolStripMenuItem1.LoadingCircleControl.Active = true;
        }

        private void btnDesactivate_Click(object sender, EventArgs e)
        {
            loadingCircle.Active = false;
            loadingCircleFF.Active = false;
            loadingCircleIE7.Active = false;
            loadingCircleMacOSX.Active = false;
            loadingCircleToolStripMenuItem1.LoadingCircleControl.Active = false;
        }

        private void nudInnerCircleRadius_ValueChanged(object sender, EventArgs e)
        {
            loadingCircle.InnerCircleRadius = (int)nudInnerCircleRadius.Value;
            loadingCircleToolStripMenuItem1.LoadingCircleControl.InnerCircleRadius = (int)nudInnerCircleRadius.Value;
        }

        private void nudNumberSpoke_ValueChanged(object sender, EventArgs e)
        {
            loadingCircle.NumberSpoke = (short)nudNumberSpoke.Value;
            loadingCircleToolStripMenuItem1.LoadingCircleControl.NumberSpoke = (short)nudNumberSpoke.Value;
        }

        private void nudSpokesThickness_ValueChanged(object sender, EventArgs e)
        {
            loadingCircle.SpokeThickness = (int)nudSpokesThickness.Value;
            loadingCircleToolStripMenuItem1.LoadingCircleControl.SpokeThickness = (int)nudSpokesThickness.Value;
        }

        private void nudOuterCircleRadius_ValueChanged(object sender, EventArgs e)
        {
            loadingCircle.OuterCircleRadius = (int)nudOuterCircleRadius.Value;
            loadingCircleToolStripMenuItem1.LoadingCircleControl.OuterCircleRadius = (int)nudOuterCircleRadius.Value;
        }

        private void cbColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadingCircle.Color = Color.FromKnownColor((System.Drawing.KnownColor)Enum.Parse(typeof(System.Drawing.KnownColor), cbColors.SelectedItem.ToString()));
            loadingCircleToolStripMenuItem1.LoadingCircleControl.Color = Color.FromKnownColor((System.Drawing.KnownColor)Enum.Parse(typeof(System.Drawing.KnownColor), cbColors.SelectedItem.ToString()));
        }

        private void nudRotationSpeed_ValueChanged(object sender, EventArgs e)
        {
            loadingCircle.RotationSpeed = (int)nudRotationSpeed.Value;
            loadingCircleToolStripMenuItem1.LoadingCircleControl.RotationSpeed = (int)nudRotationSpeed.Value;
        }

        private void btnMacOSXStyle_Click(object sender, EventArgs e)
        {
            nudNumberSpoke.Value = 12;
            nudSpokesThickness.Value = 2;
            nudInnerCircleRadius.Value = 5;
            nudOuterCircleRadius.Value = 11;
            nudRotationSpeed.Value = 80;
        }

        private void btnFireFoxStyle_Click(object sender, EventArgs e)
        {
            nudNumberSpoke.Value = 9;
            nudSpokesThickness.Value = 4;
            nudInnerCircleRadius.Value = 6;
            nudOuterCircleRadius.Value = 7;
            nudRotationSpeed.Value = 80;
        }

        private void btnIE7Style_Click(object sender, EventArgs e)
        {
            nudNumberSpoke.Value = 36;
            nudSpokesThickness.Value = 4;
            nudInnerCircleRadius.Value = 8;
            nudOuterCircleRadius.Value = 9;
            nudRotationSpeed.Value = 20;

            loadingCircleToolStripMenuItem1.LoadingCircleControl.NumberSpoke = 36;
            loadingCircleToolStripMenuItem1.LoadingCircleControl.SpokeThickness = 4;
            loadingCircleToolStripMenuItem1.LoadingCircleControl.InnerCircleRadius = 8;
            loadingCircleToolStripMenuItem1.LoadingCircleControl.OuterCircleRadius = 9;
            loadingCircleToolStripMenuItem1.LoadingCircleControl.RotationSpeed = 20;
        }

        private void lnkMartinGagne_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:martingagne@gmail.com?subject=LoadingCircle");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            foreach (string strColor in Enum.GetNames(typeof(System.Drawing.KnownColor)))
            {
                cbColors.Items.Add(strColor);
            }

            nudNumberSpoke.Value = loadingCircle.NumberSpoke;
            nudSpokesThickness.Value = loadingCircle.SpokeThickness;
            nudInnerCircleRadius.Value = loadingCircle.InnerCircleRadius;
            nudOuterCircleRadius.Value = loadingCircle.OuterCircleRadius;
            nudRotationSpeed.Value = loadingCircle.RotationSpeed;
            cbColors.SelectedIndex = cbColors.FindString(loadingCircle.Color.ToKnownColor().ToString());
        }
    }
}