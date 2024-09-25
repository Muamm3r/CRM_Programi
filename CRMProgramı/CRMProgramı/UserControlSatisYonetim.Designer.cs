namespace CRMProgramı
{
    partial class UserControlSatisYonetim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlSatisYonetim));
            this.dataGridSatisFirsatlari = new System.Windows.Forms.DataGridView();
            this.btnYeniFirsat = new System.Windows.Forms.Button();
            this.cmbDurumFiltre = new System.Windows.Forms.ComboBox();
            this.lblFiltre = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFiltre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSatisFirsatlari)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridSatisFirsatlari
            // 
            this.dataGridSatisFirsatlari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSatisFirsatlari.Location = new System.Drawing.Point(118, 215);
            this.dataGridSatisFirsatlari.Name = "dataGridSatisFirsatlari";
            this.dataGridSatisFirsatlari.RowHeadersWidth = 51;
            this.dataGridSatisFirsatlari.RowTemplate.Height = 24;
            this.dataGridSatisFirsatlari.Size = new System.Drawing.Size(590, 236);
            this.dataGridSatisFirsatlari.TabIndex = 0;
            // 
            // btnYeniFirsat
            // 
            this.btnYeniFirsat.BackColor = System.Drawing.Color.Transparent;
            this.btnYeniFirsat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnYeniFirsat.BackgroundImage")));
            this.btnYeniFirsat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYeniFirsat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniFirsat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnYeniFirsat.Location = new System.Drawing.Point(509, 164);
            this.btnYeniFirsat.Name = "btnYeniFirsat";
            this.btnYeniFirsat.Size = new System.Drawing.Size(199, 40);
            this.btnYeniFirsat.TabIndex = 1;
            this.btnYeniFirsat.UseVisualStyleBackColor = false;
            this.btnYeniFirsat.Click += new System.EventHandler(this.BtnYeniFirsat_Click);
            // 
            // cmbDurumFiltre
            // 
            this.cmbDurumFiltre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbDurumFiltre.FormattingEnabled = true;
            this.cmbDurumFiltre.Location = new System.Drawing.Point(320, 183);
            this.cmbDurumFiltre.Name = "cmbDurumFiltre";
            this.cmbDurumFiltre.Size = new System.Drawing.Size(121, 26);
            this.cmbDurumFiltre.TabIndex = 4;
            this.cmbDurumFiltre.Text = "Durum";
            // 
            // lblFiltre
            // 
            this.lblFiltre.AutoSize = true;
            this.lblFiltre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lblFiltre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFiltre.Location = new System.Drawing.Point(113, 184);
            this.lblFiltre.Name = "lblFiltre";
            this.lblFiltre.Size = new System.Drawing.Size(65, 25);
            this.lblFiltre.TabIndex = 120;
            this.lblFiltre.Text = "Filtre :";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(219)))));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(219)))));
            this.label3.Location = new System.Drawing.Point(183, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 1);
            this.label3.TabIndex = 119;
            this.label3.Text = "label2";
            // 
            // txtFiltre
            // 
            this.txtFiltre.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFiltre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFiltre.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtFiltre.ForeColor = System.Drawing.Color.Black;
            this.txtFiltre.Location = new System.Drawing.Point(184, 185);
            this.txtFiltre.Name = "txtFiltre";
            this.txtFiltre.Size = new System.Drawing.Size(114, 21);
            this.txtFiltre.TabIndex = 118;
            // 
            // UserControlSatisYonetim
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblFiltre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFiltre);
            this.Controls.Add(this.cmbDurumFiltre);
            this.Controls.Add(this.btnYeniFirsat);
            this.Controls.Add(this.dataGridSatisFirsatlari);
            this.DoubleBuffered = true;
            this.Name = "UserControlSatisYonetim";
            this.Size = new System.Drawing.Size(823, 519);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSatisFirsatlari)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dataGridSatisFirsatlari;
        private System.Windows.Forms.Button btnYeniFirsat;
        private System.Windows.Forms.ComboBox cmbDurumFiltre;
        private System.Windows.Forms.Label lblFiltre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFiltre;
    }
}
