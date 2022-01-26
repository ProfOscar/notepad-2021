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
    public partial class FormSostituisci : FormBaseTrovaSostituisci
    {
        public FormSostituisci()
        {
            InitializeComponent();
            txtFind_TextChanged(null, null);
        }

        private void FormSostituisci_Load(object sender, EventArgs e)
        {
            btnCancel.Location = new Point(252, 96);
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            btnReplace.Enabled = btnReplaceAll.Enabled = txtFind.TextLength > 0;
        }

        private void txtReplace_TextChanged(object sender, EventArgs e)
        {
            FindSubClass.Parameters.textToReplace = txtReplace.Text;
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {

        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            FindSubClass.ReplaceAll();
        }
    }
}
