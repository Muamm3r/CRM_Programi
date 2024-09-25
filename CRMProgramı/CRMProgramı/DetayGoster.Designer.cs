namespace CRMProgramı
{
    partial class DetayGosterForm
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
            this.richTextBoxDetay = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxDetay
            // 
            this.richTextBoxDetay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxDetay.Location = new System.Drawing.Point(20, 60);
            this.richTextBoxDetay.Name = "richTextBoxDetay";
            this.richTextBoxDetay.Size = new System.Drawing.Size(760, 370);
            this.richTextBoxDetay.TabIndex = 1;
            this.richTextBoxDetay.Text = "";
            // 
            // DetayGosterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBoxDetay);
            this.MaximizeBox = false;
            this.Name = "DetayGosterForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxDetay;
    }
}