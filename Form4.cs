﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElearningDesktop
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            this.ControlBox = false; //Ocultar barra superior

            this.BackColor = Colors.darkGray;
            this.ForeColor = Colors.white;
        }
    }
}