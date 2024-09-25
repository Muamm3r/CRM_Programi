using System.Drawing;
using System.Windows.Forms;

namespace CRMProgramı
{
    partial class UserControlMesajlasma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlMesajlasma));
            this.lstKullanicilar = new System.Windows.Forms.ListBox();
            this.txtMesaj = new System.Windows.Forms.TextBox();
            this.btnGonder = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.flowLayoutPanelMesajlar = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lstKullanicilar
            // 
            this.lstKullanicilar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lstKullanicilar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lstKullanicilar.FormattingEnabled = true;
            this.lstKullanicilar.ItemHeight = 20;
            this.lstKullanicilar.Location = new System.Drawing.Point(246, 125);
            this.lstKullanicilar.Name = "lstKullanicilar";
            this.lstKullanicilar.Size = new System.Drawing.Size(244, 404);
            this.lstKullanicilar.TabIndex = 0;
            this.lstKullanicilar.SelectedIndexChanged += new System.EventHandler(this.lstKullanicilar_SelectedIndexChanged);
            // 
            // txtMesaj
            // 
            this.txtMesaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMesaj.Location = new System.Drawing.Point(496, 497);
            this.txtMesaj.Name = "txtMesaj";
            this.txtMesaj.Size = new System.Drawing.Size(354, 26);
            this.txtMesaj.TabIndex = 2;
            // 
            // btnGonder
            // 
            this.btnGonder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(135)))), ((int)(((byte)(245)))));
            this.btnGonder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGonder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnGonder.ForeColor = System.Drawing.Color.White;
            this.btnGonder.Location = new System.Drawing.Point(740, 540);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(110, 35);
            this.btnGonder.TabIndex = 3;
            this.btnGonder.Text = "Gönder";
            this.btnGonder.UseVisualStyleBackColor = false;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSil.ForeColor = System.Drawing.Color.White;
            this.btnSil.Location = new System.Drawing.Point(624, 540);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(110, 35);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // flowLayoutPanelMesajlar
            // 
            this.flowLayoutPanelMesajlar.AutoScroll = true;
            this.flowLayoutPanelMesajlar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flowLayoutPanelMesajlar.BackgroundImage")));
            this.flowLayoutPanelMesajlar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanelMesajlar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMesajlar.Location = new System.Drawing.Point(496, 125);
            this.flowLayoutPanelMesajlar.Name = "flowLayoutPanelMesajlar";
            this.flowLayoutPanelMesajlar.Size = new System.Drawing.Size(354, 353);
            this.flowLayoutPanelMesajlar.TabIndex = 4;
            this.flowLayoutPanelMesajlar.WrapContents = false;
            // 
            // UserControlMesajlasma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.flowLayoutPanelMesajlar);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.txtMesaj);
            this.Controls.Add(this.lstKullanicilar);
            this.DoubleBuffered = true;
            this.Name = "UserControlMesajlasma";
            this.Size = new System.Drawing.Size(858, 601);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstKullanicilar;
        private System.Windows.Forms.TextBox txtMesaj;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMesajlar;
    }
}
