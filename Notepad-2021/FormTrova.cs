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
    public partial class FormTrova : FormBaseTrovaSostituisci
    {
        public FormTrova()
        {
            InitializeComponent();
            rbUp.Checked = FindSubClass.Parameters.isUp;
        }

        private void rbUp_CheckedChanged(object sender, EventArgs e)
        {
            FindSubClass.Parameters.isUp = rbUp.Checked;
        }
    }
}
