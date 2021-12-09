using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad_2021
{
    public partial class FormVaiAllaRiga : Form
    {

        public int NumeroRiga;

        public FormVaiAllaRiga()
        {
            InitializeComponent();
            NumeroRiga = 1;
            txtNumeroRiga.Text = NumeroRiga.ToString();
        }

        private void btnVaiA_Click(object sender, EventArgs e)
        {
            NumeroRiga = int.Parse(txtNumeroRiga.Text);
        }
    }
}
