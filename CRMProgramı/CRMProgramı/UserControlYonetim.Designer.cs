namespace CRMProgramı
{
    partial class UserControlYonetim
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlYonetim));
            this.btnKullaniciEkle = new System.Windows.Forms.Button();
            this.btnMusteriRaporlari = new System.Windows.Forms.Button();
            this.btnGorevVer = new System.Windows.Forms.Button();
            this.btnKullanicilar = new System.Windows.Forms.Button();
            this.btnGorevler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKullaniciEkle
            // 
            this.btnKullaniciEkle.BackColor = System.Drawing.Color.Transparent;
            this.btnKullaniciEkle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKullaniciEkle.BackgroundImage")));
            this.btnKullaniciEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKullaniciEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKullaniciEkle.ForeColor = System.Drawing.Color.Transparent;
            this.btnKullaniciEkle.Location = new System.Drawing.Point(37, 54);
            this.btnKullaniciEkle.Name = "btnKullaniciEkle";
            this.btnKullaniciEkle.Size = new System.Drawing.Size(308, 101);
            this.btnKullaniciEkle.TabIndex = 0;
            this.btnKullaniciEkle.UseVisualStyleBackColor = false;
            this.btnKullaniciEkle.Click += new System.EventHandler(this.BtnKullaniciEkle_Click);
            // 
            // btnMusteriRaporlari
            // 
            this.btnMusteriRaporlari.BackColor = System.Drawing.Color.Transparent;
            this.btnMusteriRaporlari.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMusteriRaporlari.BackgroundImage")));
            this.btnMusteriRaporlari.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMusteriRaporlari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMusteriRaporlari.ForeColor = System.Drawing.Color.Transparent;
            this.btnMusteriRaporlari.Location = new System.Drawing.Point(37, 421);
            this.btnMusteriRaporlari.Name = "btnMusteriRaporlari";
            this.btnMusteriRaporlari.Size = new System.Drawing.Size(308, 101);
            this.btnMusteriRaporlari.TabIndex = 0;
            this.btnMusteriRaporlari.UseVisualStyleBackColor = false;
            this.btnMusteriRaporlari.Click += new System.EventHandler(this.btnMusteriRaporlari_Click);
            // 
            // btnGorevVer
            // 
            this.btnGorevVer.BackColor = System.Drawing.Color.Transparent;
            this.btnGorevVer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGorevVer.BackgroundImage")));
            this.btnGorevVer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGorevVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGorevVer.ForeColor = System.Drawing.Color.Transparent;
            this.btnGorevVer.Location = new System.Drawing.Point(37, 240);
            this.btnGorevVer.Name = "btnGorevVer";
            this.btnGorevVer.Size = new System.Drawing.Size(308, 101);
            this.btnGorevVer.TabIndex = 0;
            this.btnGorevVer.UseVisualStyleBackColor = false;
            this.btnGorevVer.Click += new System.EventHandler(this.btnGorevVer_Click);
            // 
            // btnKullanicilar
            // 
            this.btnKullanicilar.BackColor = System.Drawing.Color.Transparent;
            this.btnKullanicilar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKullanicilar.BackgroundImage")));
            this.btnKullanicilar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKullanicilar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKullanicilar.ForeColor = System.Drawing.Color.Transparent;
            this.btnKullanicilar.Location = new System.Drawing.Point(432, 54);
            this.btnKullanicilar.Name = "btnKullanicilar";
            this.btnKullanicilar.Size = new System.Drawing.Size(308, 101);
            this.btnKullanicilar.TabIndex = 0;
            this.btnKullanicilar.UseVisualStyleBackColor = false;
            this.btnKullanicilar.Click += new System.EventHandler(this.btnKullanicilar_Click);
            // 
            // btnGorevler
            // 
            this.btnGorevler.BackColor = System.Drawing.Color.Transparent;
            this.btnGorevler.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGorevler.BackgroundImage")));
            this.btnGorevler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGorevler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGorevler.ForeColor = System.Drawing.Color.Transparent;
            this.btnGorevler.Location = new System.Drawing.Point(432, 240);
            this.btnGorevler.Name = "btnGorevler";
            this.btnGorevler.Size = new System.Drawing.Size(308, 101);
            this.btnGorevler.TabIndex = 0;
            this.btnGorevler.UseVisualStyleBackColor = false;
            this.btnGorevler.Click += new System.EventHandler(this.btnGorev_Click);
            // 
            // UserControlYonetim
            // 
            this.Controls.Add(this.btnMusteriRaporlari);
            this.Controls.Add(this.btnGorevler);
            this.Controls.Add(this.btnKullanicilar);
            this.Controls.Add(this.btnGorevVer);
            this.Controls.Add(this.btnKullaniciEkle);
            this.Name = "UserControlYonetim";
            this.Size = new System.Drawing.Size(800, 525);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnKullaniciEkle;
        private System.Windows.Forms.Button btnMusteriRaporlari;
        private System.Windows.Forms.Button btnGorevVer;
        private System.Windows.Forms.Button btnKullanicilar;
        private System.Windows.Forms.Button btnGorevler;
    }
}
