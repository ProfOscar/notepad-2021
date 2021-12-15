namespace Notepad_2021
{
    partial class FormVaiAllaRiga
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
            this.components = new System.ComponentModel.Container();
            this.lblNumeroRiga = new System.Windows.Forms.Label();
            this.txtNumeroRiga = new System.Windows.Forms.TextBox();
            this.btnVaiA = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.errorProviderGeneric = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderGeneric)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumeroRiga
            // 
            this.lblNumeroRiga.AutoSize = true;
            this.lblNumeroRiga.Location = new System.Drawing.Point(12, 15);
            this.lblNumeroRiga.Name = "lblNumeroRiga";
            this.lblNumeroRiga.Size = new System.Drawing.Size(67, 13);
            this.lblNumeroRiga.TabIndex = 0;
            this.lblNumeroRiga.Text = "Numero riga:";
            // 
            // txtNumeroRiga
            // 
            this.txtNumeroRiga.Location = new System.Drawing.Point(85, 12);
            this.txtNumeroRiga.Name = "txtNumeroRiga";
            this.txtNumeroRiga.Size = new System.Drawing.Size(100, 20);
            this.txtNumeroRiga.TabIndex = 1;
            // 
            // btnVaiA
            // 
            this.btnVaiA.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnVaiA.Location = new System.Drawing.Point(15, 56);
            this.btnVaiA.Name = "btnVaiA";
            this.btnVaiA.Size = new System.Drawing.Size(75, 23);
            this.btnVaiA.TabIndex = 2;
            this.btnVaiA.Text = "Vai a";
            this.btnVaiA.UseVisualStyleBackColor = true;
            this.btnVaiA.Click += new System.EventHandler(this.btnVaiA_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(126, 56);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 3;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            // 
            // errorProviderGeneric
            // 
            this.errorProviderGeneric.ContainerControl = this;
            // 
            // FormVaiAllaRiga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 91);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnVaiA);
            this.Controls.Add(this.txtNumeroRiga);
            this.Controls.Add(this.lblNumeroRiga);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormVaiAllaRiga";
            this.Text = "Vai alla riga";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderGeneric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumeroRiga;
        private System.Windows.Forms.TextBox txtNumeroRiga;
        private System.Windows.Forms.Button btnVaiA;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.ErrorProvider errorProviderGeneric;
    }
}