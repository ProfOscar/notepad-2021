namespace Notepad_2021
{
    partial class FormSostituisci
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
            this.btnSubstAll = new System.Windows.Forms.Button();
            this.btnSubst = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSubstAll
            // 
            this.btnSubstAll.Location = new System.Drawing.Point(252, 67);
            this.btnSubstAll.Name = "btnSubstAll";
            this.btnSubstAll.Size = new System.Drawing.Size(103, 23);
            this.btnSubstAll.TabIndex = 13;
            this.btnSubstAll.Text = "Sostituisci tutto";
            this.btnSubstAll.UseVisualStyleBackColor = true;
            // 
            // btnSubst
            // 
            this.btnSubst.Location = new System.Drawing.Point(252, 37);
            this.btnSubst.Name = "btnSubst";
            this.btnSubst.Size = new System.Drawing.Size(103, 23);
            this.btnSubst.TabIndex = 12;
            this.btnSubst.Text = "Sostituisci";
            this.btnSubst.UseVisualStyleBackColor = true;
            // 
            // FormSostituisci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 123);
            this.Controls.Add(this.btnSubstAll);
            this.Controls.Add(this.btnSubst);
            this.Name = "FormSostituisci";
            this.Text = "FormSostituisci";
            this.Load += new System.EventHandler(this.FormSostituisci_Load);
            this.Controls.SetChildIndex(this.btnSubst, 0);
            this.Controls.SetChildIndex(this.btnSubstAll, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubstAll;
        private System.Windows.Forms.Button btnSubst;
    }
}