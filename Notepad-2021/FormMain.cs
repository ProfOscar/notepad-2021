﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Notepad_2021
{
    public partial class FormMain : Form
    {

        #region variables

        string fileName;
        string filePath;
        string savedContent;

        int line = 1;
        int column = 1;

        const string WIN = "Windows (CRLF)";
        const string MAC = "Macintosh (CR)";
        const string LIN = "Unix (LF)";
        string lineTerminator = "";
        // Read this: https://stackoverflow.com/questions/7067899/richtextbox-newline-conversion

        Encoding fileEncoding;

        // variable to trace text to print for pagination
        private int m_nFirstCharOnPage;

        #endregion

        #region initialization

        public FormMain()
        {
            InitializeComponent();
            richTextBoxMain.WordWrap = acapoautomaticoToolStripMenuItem.Checked;
            pageSetupDialogMain.Document = printDocumentMain;
            printDialogMain.Document = printDocumentMain;
            FindSubClass.Target = richTextBoxMain;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            initializeVariables();
        }

        private void initializeVariables()
        {
            fileName = "Senza nome";
            filePath = "";
            savedContent = "";
            richTextBoxMain.Clear();
            setFormTitle();
            annullaToolStripMenuItem.Enabled = false;
            enableDisableCopyCut();
            enableDisableFinds();
            toolStripStatusLabelTerminatoreRiga.Text = Environment.NewLine == "\r\n" ? WIN : Environment.NewLine == "\r" ? MAC : LIN;
            lineTerminator = Environment.NewLine;
            fileEncoding = Encoding.Default;
            toolStripStatusLabelEncoding.Text = "UTF-8";
        }

        private void setFormTitle()
        {
            this.Text = fileName + this.Tag;
        }

        #endregion

        #region menu-item handlers

        private void nuovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBoxMain.Text != savedContent)
            {
                DialogResult result = checkIfUserWantToSave();
                if (result == DialogResult.Cancel) return;
                else if (result == DialogResult.Yes)
                {
                    if (filePath != "") saveDocument(filePath);
                    else
                    {
                        DialogResult saveResponse = saveFileDialogMain.ShowDialog();
                        if (saveResponse == DialogResult.Cancel) return;
                        else saveDocument(saveFileDialogMain.FileName);
                    }
                }
            }
            initializeVariables();
        }

        private void apriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBoxMain.Text != savedContent)
            {
                DialogResult result = checkIfUserWantToSave();
                if (result == DialogResult.Cancel) return;
                else if (result == DialogResult.Yes)
                {
                    if (filePath != "") saveDocument(filePath);
                    else
                    {
                        DialogResult saveResponse = saveFileDialogMain.ShowDialog();
                        if (saveResponse == DialogResult.Cancel) return;
                        else saveDocument(saveFileDialogMain.FileName);
                    }
                }
            }
            if (openFileDialogMain.ShowDialog() == DialogResult.OK)
            {
                openDocument(openFileDialogMain.FileName);
                openFileDialogMain.FileName = "";
            }
        }

        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filePath.Length == 0)
                salvaconnomeToolStripMenuItem_Click(sender, e);
            else
                saveDocument(filePath);
        }

        private void salvaconnomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialogMain.ShowDialog() == DialogResult.OK)
                saveDocument(saveFileDialogMain.FileName);
        }

        private void impostapaginaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialogMain.ShowDialog();
        }

        private void stampaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDocumentMain.DocumentName = fileName;
            if (printDialogMain.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocumentMain.Print();
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "Problemi durante la stampa.\nSe stai stampando su file verifica che il file di destinazione non sia aperto.",
                        "ATTENZIONE!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void annullaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMain.Undo();
        }

        private void tagliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMain.Cut();
        }

        private void copiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMain.Copy();
        }

        private void incollaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMain.Paste();
        }

        private void eliminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMain.SelectedText = "";
        }

        private void cercaConBingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://www.bing.com/search?q=";
            int startPos = 0; int finalPos = richTextBoxMain.TextLength - 1;
            if (richTextBoxMain.SelectionStart == 0)
            {
                finalPos = richTextBoxMain.Find(new char[] { ' ' }, 0);
            }
            else
            {
                if (richTextBoxMain.SelectionLength > 0)
                {
                    startPos = richTextBoxMain.SelectionStart;
                    finalPos = startPos + richTextBoxMain.SelectionLength;
                }
                else
                {
                    startPos = richTextBoxMain.Text.LastIndexOf(' ', richTextBoxMain.SelectionStart - 1);
                    if (startPos == -1) startPos = 0;
                    finalPos = richTextBoxMain.Text.IndexOf(' ', richTextBoxMain.SelectionStart);
                    if (finalPos == -1) finalPos = richTextBoxMain.TextLength;
                }
            }
            int length = finalPos - startPos;
            if (length < 0) length = 0;
            string key = richTextBoxMain.Text.Substring(startPos, length);
            Process.Start(url + key);
        }

        private void trovaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTrova ft = new FormTrova();
            ft.Show();
        }

        private void trovaSuccessivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FindSubClass.Parameters.textToFind.Length == 0)
            {
                trovaToolStripMenuItem_Click(sender, e);
            }
            else
            {
                FindSubClass.Parameters.isUp = false;
                if (FindSubClass.Find() == -1)
                {
                    FindSubClass.ShowNotFoundMessage();
                }
            }
        }

        private void trovaPrecedenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FindSubClass.Parameters.textToFind.Length == 0)
            {
                trovaToolStripMenuItem_Click(sender, e);
            }
            else
            {
                FindSubClass.Parameters.isUp = true;
                if (FindSubClass.Find() == -1)
                {
                    FindSubClass.ShowNotFoundMessage();
                }
            }
        }

        private void sostituisciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindSubClass.Parameters.isUp = false;
            FormSostituisci fs = new FormSostituisci();
            fs.Show();
        }

        private void vaiAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVaiAllaRiga formVaiAllaRiga = new FormVaiAllaRiga(
                richTextBoxMain.Lines.Length, 
                richTextBoxMain.GetLineFromCharIndex(richTextBoxMain.SelectionStart));
            if (formVaiAllaRiga.ShowDialog() == DialogResult.OK)
            {
                int numRiga = richTextBoxMain.GetFirstCharIndexFromLine(formVaiAllaRiga.NumeroRiga - 1);
                if (numRiga > -1) richTextBoxMain.SelectionStart = numRiga;
            }
        }

        private void selezionatuttoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMain.SelectAll();
        }

        private void oraDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            richTextBoxMain.SelectedText = now.ToString("t") + " " + now.ToString("d");
        }

        private void acapoautomaticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMain.WordWrap = acapoautomaticoToolStripMenuItem.Checked;
            vaiAToolStripMenuItem.Enabled = !acapoautomaticoToolStripMenuItem.Checked;
        }

        private void carattereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialogMain.Font = richTextBoxMain.Font;
            if (fontDialogMain.ShowDialog() == DialogResult.OK)
            {
                richTextBoxMain.Font = fontDialogMain.Font;
            }
        }

        private void zoomAvantiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBoxMain.ZoomFactor < 63)
            {
                richTextBoxMain.ZoomFactor += (float)0.1;
            }
            writeZoomInStatusBar();
        }

        private void zoomIndietroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBoxMain.ZoomFactor > 0.35)
            {
                richTextBoxMain.ZoomFactor -= 0.1F;
            }
            writeZoomInStatusBar();
        }

        private void ripristinaZoomPredefinitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMain.ZoomFactor = 1;
            writeZoomInStatusBar();
        }

        private void writeZoomInStatusBar()
        {
            toolStripStatusLabelZoom.Text = (richTextBoxMain.ZoomFactor * 100).ToString("0") + "%";
        }

        private void barraDistatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusBarMain.Visible = barraDistatoToolStripMenuItem.Checked;
        }

        private void guidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://go.microsoft.com/fwlink/?LinkId=834783");
        }

        private void inviafeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ProfOscar/notepad-2021/issues");
        }

        private void informazionisuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBoxMain aboutForm = new AboutBoxMain();
            aboutForm.ShowDialog();
        }

        #endregion

        #region event handlers

        private void FormMain_Activated(object sender, EventArgs e)
        {
            incollaToolStripMenuItem.Enabled = Clipboard.ContainsText() || Clipboard.ContainsImage();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (richTextBoxMain.Text != savedContent)
            {
                DialogResult result = checkIfUserWantToSave();
                if (result == DialogResult.Cancel) e.Cancel = true;
                else if (result == DialogResult.Yes)
                {
                    if (filePath != "") saveDocument(filePath);
                    else
                    {
                        DialogResult saveResponse = saveFileDialogMain.ShowDialog();
                        if (saveResponse == DialogResult.Cancel) e.Cancel = true;
                        else saveDocument(saveFileDialogMain.FileName);
                    }
                }
            }
        }

        private void richTextBoxMain_TextChanged(object sender, EventArgs e)
        {
            if (richTextBoxMain.Text != savedContent && fileName[0] != '*')
            {
                fileName = "*" + fileName;
                setFormTitle();
            }
            else if (richTextBoxMain.Text == savedContent && fileName[0] == '*')
            {
                fileName = fileName.Remove(0, 1);
                setFormTitle();
            }
            annullaToolStripMenuItem.Enabled = true;
            enableDisableFinds();
        }

        private void richTextBoxMain_SelectionChanged(object sender, EventArgs e)
        {
            enableDisableCopyCut();
            if (richTextBoxMain.Text.Length > 0)
            {
                string portion = richTextBoxMain.Text.Substring(0, richTextBoxMain.SelectionStart);
                line = Regex.Matches(portion, @"\n").Count + 1;
                int lastNewLinePos = portion.LastIndexOf('\n');
                column = richTextBoxMain.SelectionStart - lastNewLinePos;
            }
            else if (richTextBoxMain.Text.Length == 0 && richTextBoxMain.TextLength == 0)
            {
                // A causa di bug nel comportamento del richtextbox al cambio di wordwrap
                line = 1;
                column = 1;
            }
            string st = "Linea " + line + ", colonna " + column;
            toolStripStatusLabelLineaColonna.Text = st;
        }

        private void printDocumentMain_BeginPrint(object sender, PrintEventArgs e)
        {
            // Start at the beginning of the text
            m_nFirstCharOnPage = 0;
        }

        private void printDocumentMain_PrintPage(object sender, PrintPageEventArgs e)
        {
            //string content = richTextBoxMain.Text;
            //Font font = richTextBoxMain.Font;
            //e.Graphics.DrawString(
            //    content,
            //    font,
            //    new SolidBrush(Color.Black),
            //    e.MarginBounds.X,
            //    e.MarginBounds.Y);
            // To print the boundaries of the current page margins
            // uncomment the next line:
            // e.Graphics.DrawRectangle(System.Drawing.Pens.Blue, e.MarginBounds);

            // make the RichTextBoxEx calculate and render as much text as will
            // fit on the page and remember the last character printed for the
            // beginning of the next page
            m_nFirstCharOnPage = richTextBoxMain.FormatRange(false,
                                                    e,
                                                    m_nFirstCharOnPage,
                                                    richTextBoxMain.TextLength);

            // check if there are more pages to print
            if (m_nFirstCharOnPage < richTextBoxMain.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        private void printDocumentMain_EndPrint(object sender, PrintEventArgs e)
        {
            // Clean up cached information
            richTextBoxMain.FormatRangeDone();
        }

        #endregion

        #region helper functions

        private DialogResult checkIfUserWantToSave()
        {
            return MessageBox.Show(
                    "Salvare le modifiche a " + fileName + "?",
                    "Blocco note",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);
        }

        private string getFileNameFromPath(string fp)
        {
            string[] mySplit = fp.Split('\\');
            return mySplit[mySplit.Length - 1];
        }

        private void openDocument(string fp)
        {
            try
            {
                string rawText = File.ReadAllText(fp);
                if (rawText.Contains("\r\n")) 
                { 
                    toolStripStatusLabelTerminatoreRiga.Text = WIN;
                    lineTerminator = "\r\n";
                }
                else if (rawText.Contains("\r")) 
                { 
                    toolStripStatusLabelTerminatoreRiga.Text = MAC;
                    lineTerminator = "\r";
                }
                else
                {
                    toolStripStatusLabelTerminatoreRiga.Text = LIN;
                    lineTerminator = "\n";
                }
                fileEncoding = GetEncoding(fp);
                toolStripStatusLabelEncoding.Text = fileEncoding.BodyName.ToUpper();
                richTextBoxMain.Text = rawText;
                savedContent = richTextBoxMain.Text;
                filePath = fp;
                fileName = getFileNameFromPath(fp);
                setFormTitle();
                annullaToolStripMenuItem.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Problemi durante l'apertura del file.",
                    "ATTENZIONE!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void saveDocument(string fp)
        {
            try
            {
                string content = richTextBoxMain.Text;
                content = content.Replace("\n", lineTerminator);
                File.WriteAllText(fp, content, fileEncoding);
                savedContent = content;
                filePath = fp;
                fileName = getFileNameFromPath(fp);
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

        private void enableDisableCopyCut()
        {
            copiaToolStripMenuItem.Enabled = richTextBoxMain.SelectedText.Length > 0;
            tagliaToolStripMenuItem.Enabled = copiaToolStripMenuItem.Enabled;
            eliminaToolStripMenuItem.Enabled = copiaToolStripMenuItem.Enabled;
        }

        private void enableDisableFinds()
        {
            trovaToolStripMenuItem.Enabled = richTextBoxMain.Text.Length > 0;
            trovaSuccessivoToolStripMenuItem.Enabled = trovaToolStripMenuItem.Enabled;
            trovaPrecedenteToolStripMenuItem.Enabled = trovaToolStripMenuItem.Enabled;
        }

        /// <summary>
        /// Determines a text file's encoding by analyzing its byte order mark (BOM).
        /// Defaults to UTF8.
        /// </summary>
        /// <param name="fileName">The text file to analyze.</param>
        /// <returns>The detected encoding.</returns>
        public static Encoding GetEncoding(string fileName)
        {
            using (var reader = new StreamReader(fileName, Encoding.UTF8, true))
            {
                reader.Peek(); // you need this!
                return reader.CurrentEncoding;
            }
        }

        #endregion
    }
}
