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

        private int totRighe;
        private bool isCancel = true;

        public int NumeroRiga;

        public FormVaiAllaRiga(int tr, int riga)
        {
            totRighe = tr;
            InitializeComponent();
            NumeroRiga = riga + 1;
            txtNumeroRiga.Text = NumeroRiga.ToString();
        }

        private void btnVaiA_Click(object sender, EventArgs e)
        {
            NumeroRiga = txtNumeroRiga.Text != "" && txtNumeroRiga.Text != "0" ? int.Parse(txtNumeroRiga.Text): int.MaxValue;
            isCancel = false;
        }

        private void txtNumeroRiga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                errorProviderGeneric.SetError((Control)sender, "Carattere non ammesso");
                e.Handled = true;
            }
            else
            {
                errorProviderGeneric.Clear();
            }
        }

        private void FormVaiAllaRiga_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (NumeroRiga > totRighe && !isCancel)
            {
                MessageBox.Show("Numero di riga maggiore del numero di righe totale", "Blocco note. Vai alla riga");
                isCancel = true;
                e.Cancel = true;
            }
        }
    }
}
