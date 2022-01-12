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
    public partial class FormBaseTrovaSostituisci : Form
    {
        public FormBaseTrovaSostituisci()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            FindSubClass.Parameters.textToFind = txtFind.Text;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (FindSubClass.Find() == -1) MessageBox.Show(
                "Impossibile trovare \"" + FindSubClass.Parameters.textToFind + "\"",
                "Blocco note",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
