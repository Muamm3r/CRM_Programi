namespace CRMProgramı
{
    partial class GorevVer
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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GorevVer));
            this.comboBoxKullanici = new System.Windows.Forms.ComboBox();
            this.comboBoxDurum = new System.Windows.Forms.ComboBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.txtGorevAdi = new System.Windows.Forms.RichTextBox();
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.lblGorev = new System.Windows.Forms.Label();
            this.lblDurum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxKullanici
            // 
            this.comboBoxKullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxKullanici.FormattingEnabled = true;
            this.comboBoxKullanici.Location = new System.Drawing.Point(153, 31);
            this.comboBoxKullanici.Name = "comboBoxKullanici";
            this.comboBoxKullanici.Size = new System.Drawing.Size(289, 28);
            this.comboBoxKullanici.TabIndex = 0;
            // 
            // comboBoxDurum
            // 
            this.comboBoxDurum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxDurum.FormattingEnabled = true;
            this.comboBoxDurum.Location = new System.Drawing.Point(153, 152);
            this.comboBoxDurum.Name = "comboBoxDurum";
            this.comboBoxDurum.Size = new System.Drawing.Size(289, 28);
            this.comboBoxDurum.TabIndex = 2;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKaydet.BackgroundImage")));
            this.btnKaydet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.ForeColor = System.Drawing.Color.Transparent;
            this.btnKaydet.Location = new System.Drawing.Point(153, 199);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(289, 51);
            this.btnKaydet.TabIndex = 3;
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtGorevAdi
            // 
            this.txtGorevAdi.Location = new System.Drawing.Point(153, 70);
            this.txtGorevAdi.Name = "txtGorevAdi";
            this.txtGorevAdi.Size = new System.Drawing.Size(289, 76);
            this.txtGorevAdi.TabIndex = 4;
            this.txtGorevAdi.Text = "";
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKullaniciAdi.Location = new System.Drawing.Point(78, 33);
            this.lblKullaniciAdi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(68, 25);
            this.lblKullaniciAdi.TabIndex = 5;
            this.lblKullaniciAdi.Text = "Kime :";
            // 
            // lblGorev
            // 
            this.lblGorev.AutoSize = true;
            this.lblGorev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGorev.Location = new System.Drawing.Point(70, 70);
            this.lblGorev.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGorev.Name = "lblGorev";
            this.lblGorev.Size = new System.Drawing.Size(76, 25);
            this.lblGorev.TabIndex = 5;
            this.lblGorev.Text = "Görev :";
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDurum.Location = new System.Drawing.Point(65, 154);
            this.lblDurum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(81, 25);
            this.lblDurum.TabIndex = 5;
            this.lblDurum.Text = "Durum :";
            // 
            // GorevVer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 270);
            this.Controls.Add(this.lblDurum);
            this.Controls.Add(this.lblGorev);
            this.Controls.Add(this.lblKullaniciAdi);
            this.Controls.Add(this.txtGorevAdi);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.comboBoxDurum);
            this.Controls.Add(this.comboBoxKullanici);
            this.MaximizeBox = false;
            this.Name = "GorevVer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxKullanici;
        private System.Windows.Forms.ComboBox comboBoxDurum;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.RichTextBox txtGorevAdi;
        private System.Windows.Forms.Label lblKullaniciAdi;
        private System.Windows.Forms.Label lblGorev;
        private System.Windows.Forms.Label lblDurum;
    }
}
