namespace CRMProgramı
{
    partial class UserControlIletisimTakip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlIletisimTakip));
            this.lblFiltre = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFiltre = new System.Windows.Forms.TextBox();
            this.btnIletisimEkle = new System.Windows.Forms.Button();
            this.dataGridIletisim = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIletisim)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFiltre
            // 
            this.lblFiltre.AutoSize = true;
            this.lblFiltre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFiltre.Location = new System.Drawing.Point(23, 64);
            this.lblFiltre.Name = "lblFiltre";
            this.lblFiltre.Size = new System.Drawing.Size(83, 29);
            this.lblFiltre.TabIndex = 122;
            this.lblFiltre.Text = "Filtre :";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(219)))));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(219)))));
            this.label3.Location = new System.Drawing.Point(112, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 1);
            this.label3.TabIndex = 121;
            this.label3.Text = "label2";
            // 
            // txtFiltre
            // 
            this.txtFiltre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFiltre.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtFiltre.ForeColor = System.Drawing.Color.Black;
            this.txtFiltre.Location = new System.Drawing.Point(112, 68);
            this.txtFiltre.Name = "txtFiltre";
            this.txtFiltre.Size = new System.Drawing.Size(200, 25);
            this.txtFiltre.TabIndex = 120;
            // 
            // btnIletisimEkle
            // 
            this.btnIletisimEkle.BackColor = System.Drawing.Color.Transparent;
            this.btnIletisimEkle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnIletisimEkle.BackgroundImage")));
            this.btnIletisimEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIletisimEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIletisimEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIletisimEkle.ForeColor = System.Drawing.Color.Transparent;
            this.btnIletisimEkle.Location = new System.Drawing.Point(4, 3);
            this.btnIletisimEkle.Name = "btnIletisimEkle";
            this.btnIletisimEkle.Size = new System.Drawing.Size(334, 46);
            this.btnIletisimEkle.TabIndex = 119;
            this.btnIletisimEkle.UseVisualStyleBackColor = false;
            // 
            // dataGridIletisim
            // 
            this.dataGridIletisim.BackgroundColor = System.Drawing.Color.White;
            this.dataGridIletisim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridIletisim.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridIletisim.Location = new System.Drawing.Point(28, 120);
            this.dataGridIletisim.Name = "dataGridIletisim";
            this.dataGridIletisim.RowHeadersWidth = 51;
            this.dataGridIletisim.RowTemplate.Height = 24;
            this.dataGridIletisim.Size = new System.Drawing.Size(815, 364);
            this.dataGridIletisim.TabIndex = 118;
            // 
            // UserControlIletisimTakip
            // 
            this.Controls.Add(this.lblFiltre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFiltre);
            this.Controls.Add(this.btnIletisimEkle);
            this.Controls.Add(this.dataGridIletisim);
            this.Name = "UserControlIletisimTakip";
            this.Size = new System.Drawing.Size(1146, 720);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIletisim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblFiltre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFiltre;
        private System.Windows.Forms.Button btnIletisimEkle;
        private System.Windows.Forms.DataGridView dataGridIletisim;
    }
}
