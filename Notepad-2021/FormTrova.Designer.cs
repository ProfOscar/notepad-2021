namespace Notepad_2021
{
    partial class FormTrova
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
            this.gbDirection = new System.Windows.Forms.GroupBox();
            this.rbDown = new System.Windows.Forms.RadioButton();
            this.rbUp = new System.Windows.Forms.RadioButton();
            this.gbDirection.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDirection
            // 
            this.gbDirection.Controls.Add(this.rbDown);
            this.gbDirection.Controls.Add(this.rbUp);
            this.gbDirection.Location = new System.Drawing.Point(138, 66);
            this.gbDirection.Name = "gbDirection";
            this.gbDirection.Size = new System.Drawing.Size(103, 45);
            this.gbDirection.TabIndex = 6;
            this.gbDirection.TabStop = false;
            this.gbDirection.Text = "Direzione";
            // 
            // rbDown
            // 
            this.rbDown.AutoSize = true;
            this.rbDown.Checked = true;
            this.rbDown.Location = new System.Drawing.Point(54, 19);
            this.rbDown.Name = "rbDown";
            this.rbDown.Size = new System.Drawing.Size(41, 17);
            this.rbDown.TabIndex = 5;
            this.rbDown.TabStop = true;
            this.rbDown.Text = "Giù";
            this.rbDown.UseVisualStyleBackColor = true;
            // 
            // rbUp
            // 
            this.rbUp.AutoSize = true;
            this.rbUp.Location = new System.Drawing.Point(8, 19);
            this.rbUp.Name = "rbUp";
            this.rbUp.Size = new System.Drawing.Size(38, 17);
            this.rbUp.TabIndex = 4;
            this.rbUp.Text = "Su";
            this.rbUp.UseVisualStyleBackColor = true;
            // 
            // FormTrova
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 123);
            this.Controls.Add(this.gbDirection);
            this.Name = "FormTrova";
            this.Text = "Trova";
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.gbDirection, 0);
            this.gbDirection.ResumeLayout(false);
            this.gbDirection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDirection;
        private System.Windows.Forms.RadioButton rbDown;
        private System.Windows.Forms.RadioButton rbUp;
    }
}