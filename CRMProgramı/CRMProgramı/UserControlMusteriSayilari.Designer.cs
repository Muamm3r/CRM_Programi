namespace CRMProgramı.Controls
{
    partial class UserControlMusteriSayilari
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlMusteriSayilari));
            this.lblMusteriSayisi = new System.Windows.Forms.Label();
            this.lblSonMusteriler = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMusteriSayisi
            // 
            this.lblMusteriSayisi.AutoSize = true;
            this.lblMusteriSayisi.BackColor = System.Drawing.Color.Transparent;
            this.lblMusteriSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMusteriSayisi.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblMusteriSayisi.Location = new System.Drawing.Point(285, 24);
            this.lblMusteriSayisi.Name = "lblMusteriSayisi";
            this.lblMusteriSayisi.Size = new System.Drawing.Size(34, 29);
            this.lblMusteriSayisi.TabIndex = 0;
            this.lblMusteriSayisi.Text = "...";
            // 
            // lblSonMusteriler
            // 
            this.lblSonMusteriler.AutoSize = true;
            this.lblSonMusteriler.BackColor = System.Drawing.Color.Transparent;
            this.lblSonMusteriler.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSonMusteriler.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSonMusteriler.Location = new System.Drawing.Point(141, 134);
            this.lblSonMusteriler.Name = "lblSonMusteriler";
            this.lblSonMusteriler.Size = new System.Drawing.Size(54, 26);
            this.lblSonMusteriler.TabIndex = 0;
            this.lblSonMusteriler.Text = ".......";
            // 
            // UserControlMusteriSayilari
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblSonMusteriler);
            this.Controls.Add(this.lblMusteriSayisi);
            this.DoubleBuffered = true;
            this.Name = "UserControlMusteriSayilari";
            this.Size = new System.Drawing.Size(472, 393);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMusteriSayisi;
        private System.Windows.Forms.Label lblSonMusteriler;
    }
}
