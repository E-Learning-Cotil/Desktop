using System;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            this.ControlBox = false; //Ocultar barra superior

            this.BackColor = Styles.darkGray;
            this.ForeColor = Styles.white;
        }
    }
}
