﻿using System;
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
            txtFind.Text = FindSubClass.Target.SelectedText != "" ? FindSubClass.Target.SelectedText : FindSubClass.Parameters.textToFind;
            btnFind.Enabled = txtFind.TextLength > 0;
            chkUpLow.Checked = FindSubClass.Parameters.isCaseSensitive;
            chkTextAround.Checked = FindSubClass.Parameters.isTextAround;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            FindSubClass.Parameters.textToFind = txtFind.Text;
            btnFind.Enabled = txtFind.TextLength > 0;
        }

        private void chkUpLow_CheckedChanged(object sender, EventArgs e)
        {
            FindSubClass.Parameters.isCaseSensitive = chkUpLow.Checked;
        }

        private void chkTextAround_CheckedChanged(object sender, EventArgs e)
        {
            FindSubClass.Parameters.isTextAround = chkTextAround.Checked;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (FindSubClass.Find() == -1)
            {
                this.TopMost = false;
                FindSubClass.ShowNotFoundMessage();
                this.TopMost = true;
            }
        }
    }
}
