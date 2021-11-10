using System;
using System.Windows.Forms;
using System.IO;

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
            setFormTitle();
        }

        private void setFormTitle()
        {
            this.Text = fileName + this.Tag; ;
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (richTextBoxMain.Text != savedContent)
            {
                DialogResult result = MessageBox.Show(
                    "Salvare le modifiche a " + fileName + "?",
                    "Blocco note",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (result == DialogResult.Yes)
                {
                    if (filePath != "")
                    {
                        saveDocument(filePath);
                    }
                    else
                    {
                        DialogResult saveResponse = saveFileDialogMain.ShowDialog();
                        if (saveResponse == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                        }
                        else
                        {
                            saveDocument(saveFileDialogMain.FileName);
                        }
                    }
                }
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

        private void saveDocument(string fp)
        {
            try
            {
                string content = richTextBoxMain.Text;
                File.WriteAllText(fp, content);
                savedContent = content;
                filePath = fp;
                string[] mySplit = fp.Split('\\');
                fileName = mySplit[mySplit.Length - 1];
                setFormTitle();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Problemi durante il salvataggio del file.",
                    "ATTENZIONE!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
