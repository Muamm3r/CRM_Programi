namespace CRMProgramı
{
    partial class FormBilesenSecimi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBilesenSecimi));
            this.checkBoxTakvim = new System.Windows.Forms.CheckBox();
            this.checkBoxGorevler = new System.Windows.Forms.CheckBox();
            this.checkBoxMusteriSayilari = new System.Windows.Forms.CheckBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.checkBoxNot = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBoxTakvim
            // 
            this.checkBoxTakvim.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBoxTakvim.BackgroundImage")));
            this.checkBoxTakvim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.checkBoxTakvim.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBoxTakvim.Location = new System.Drawing.Point(23, 25);
            this.checkBoxTakvim.Name = "checkBoxTakvim";
            this.checkBoxTakvim.Size = new System.Drawing.Size(372, 54);
            this.checkBoxTakvim.TabIndex = 0;
            this.checkBoxTakvim.Text = "Takvim";
            this.checkBoxTakvim.UseVisualStyleBackColor = true;
            // 
            // checkBoxGorevler
            // 
            this.checkBoxGorevler.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBoxGorevler.BackgroundImage")));
            this.checkBoxGorevler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.checkBoxGorevler.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBoxGorevler.Location = new System.Drawing.Point(23, 98);
            this.checkBoxGorevler.Name = "checkBoxGorevler";
            this.checkBoxGorevler.Size = new System.Drawing.Size(429, 54);
            this.checkBoxGorevler.TabIndex = 0;
            this.checkBoxGorevler.Text = "Görevler";
            this.checkBoxGorevler.UseVisualStyleBackColor = true;
            // 
            // checkBoxMusteriSayilari
            // 
            this.checkBoxMusteriSayilari.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBoxMusteriSayilari.BackgroundImage")));
            this.checkBoxMusteriSayilari.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.checkBoxMusteriSayilari.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBoxMusteriSayilari.Location = new System.Drawing.Point(23, 174);
            this.checkBoxMusteriSayilari.Name = "checkBoxMusteriSayilari";
            this.checkBoxMusteriSayilari.Size = new System.Drawing.Size(560, 54);
            this.checkBoxMusteriSayilari.TabIndex = 0;
            this.checkBoxMusteriSayilari.Text = "Müşteri Sayıları";
            this.checkBoxMusteriSayilari.UseVisualStyleBackColor = true;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(109, 319);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(124, 43);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // checkBoxNot
            // 
            this.checkBoxNot.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBoxNot.BackgroundImage")));
            this.checkBoxNot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.checkBoxNot.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBoxNot.Location = new System.Drawing.Point(23, 250);
            this.checkBoxNot.Name = "checkBoxNot";
            this.checkBoxNot.Size = new System.Drawing.Size(305, 54);
            this.checkBoxNot.TabIndex = 0;
            this.checkBoxNot.Text = "Not";
            this.checkBoxNot.UseVisualStyleBackColor = true;
            // 
            // FormBilesenSecimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 394);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.checkBoxNot);
            this.Controls.Add(this.checkBoxMusteriSayilari);
            this.Controls.Add(this.checkBoxGorevler);
            this.Controls.Add(this.checkBoxTakvim);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBilesenSecimi";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxTakvim;
        private System.Windows.Forms.CheckBox checkBoxGorevler;
        private System.Windows.Forms.CheckBox checkBoxMusteriSayilari;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.CheckBox checkBoxNot;
    }
}