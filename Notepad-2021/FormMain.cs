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
    public partial class FormMain : Form
    {

        string fileName;
        string filePath;
        string savedContent;

        public FormMain()
        {
            fileName = "Senza nome";
            filePath = "";
            savedContent = "";
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (richTextBoxMain.Text != savedContent)
            {
                MessageBox.Show("C'è qualcosa da salvare...");
                e.Cancel = true;
            }
        }

        private void salvaconnomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialogMain.ShowDialog() == DialogResult.OK)
                saveDocument(saveFileDialogMain.FileName);
        }

        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filePath.Length == 0)
                salvaconnomeToolStripMenuItem_Click(sender, e);
            else
                saveDocument(filePath);
        }

        private void saveDocument(string filePath)
        {
            MessageBox.Show("Sto per salvare al path: " + filePath);
        }
    }
}
