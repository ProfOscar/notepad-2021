namespace Notepad_2021
{
    partial class FormBaseTrovaSostituisci
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFind = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.chkUpLow = new System.Windows.Forms.CheckBox();
            this.chkTextAround = new System.Windows.Forms.CheckBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(8, 13);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(38, 13);
            this.lblFind.TabIndex = 0;
            this.lblFind.Text = "Trova:";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(52, 10);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(189, 20);
            this.txtFind.TabIndex = 1;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // chkUpLow
            // 
            this.chkUpLow.AutoSize = true;
            this.chkUpLow.Location = new System.Drawing.Point(6, 78);
            this.chkUpLow.Name = "chkUpLow";
            this.chkUpLow.Size = new System.Drawing.Size(126, 17);
            this.chkUpLow.TabIndex = 2;
            this.chkUpLow.Text = "Maiuscole/minuscole";
            this.chkUpLow.UseVisualStyleBackColor = true;
            // 
            // chkTextAround
            // 
            this.chkTextAround.AutoSize = true;
            this.chkTextAround.Location = new System.Drawing.Point(6, 101);
            this.chkTextAround.Name = "chkTextAround";
            this.chkTextAround.Size = new System.Drawing.Size(88, 17);
            this.chkTextAround.TabIndex = 3;
            this.chkTextAround.Text = "Testo intorno";
            this.chkTextAround.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(252, 8);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(103, 23);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "Trova successivo";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(252, 37);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Annulla";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormBaseTrovaSostituisci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 123);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.chkTextAround);
            this.Controls.Add(this.chkUpLow);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.lblFind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormBaseTrovaSostituisci";
            this.Text = "FormBaseTrovaSostituisci";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.CheckBox chkUpLow;
        private System.Windows.Forms.CheckBox chkTextAround;
        private System.Windows.Forms.Button btnFind;
        public System.Windows.Forms.Button btnCancel;
    }
}