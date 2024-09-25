namespace CRMProgramı
{
    partial class UserControlMusteriYonetim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlMusteriYonetim));
            this.label3 = new System.Windows.Forms.Label();
            this.txtFiltre = new System.Windows.Forms.TextBox();
            this.btnMusteri = new System.Windows.Forms.Button();
            this.dataGridMusteriler = new System.Windows.Forms.DataGridView();
            this.lblFiltre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMusteriler)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(219)))));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(219)))));
            this.label3.Location = new System.Drawing.Point(114, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 1);
            this.label3.TabIndex = 116;
            this.label3.Text = "label2";
            // 
            // txtFiltre
            // 
            this.txtFiltre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFiltre.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtFiltre.ForeColor = System.Drawing.Color.Silver;
            this.txtFiltre.Location = new System.Drawing.Point(114, 68);
            this.txtFiltre.Name = "txtFiltre";
            this.txtFiltre.Size = new System.Drawing.Size(200, 25);
            this.txtFiltre.TabIndex = 115;
            // 
            // btnMusteri
            // 
            this.btnMusteri.BackColor = System.Drawing.Color.Transparent;
            this.btnMusteri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMusteri.BackgroundImage")));
            this.btnMusteri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMusteri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMusteri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMusteri.ForeColor = System.Drawing.Color.Transparent;
            this.btnMusteri.Location = new System.Drawing.Point(6, 3);
            this.btnMusteri.Name = "btnMusteri";
            this.btnMusteri.Size = new System.Drawing.Size(334, 46);
            this.btnMusteri.TabIndex = 113;
            this.btnMusteri.UseVisualStyleBackColor = false;
            this.btnMusteri.Click += new System.EventHandler(this.btnMusteriEkle_Click);
            // 
            // dataGridMusteriler
            // 
            this.dataGridMusteriler.BackgroundColor = System.Drawing.Color.White;
            this.dataGridMusteriler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMusteriler.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridMusteriler.Location = new System.Drawing.Point(30, 120);
            this.dataGridMusteriler.Name = "dataGridMusteriler";
            this.dataGridMusteriler.RowHeadersWidth = 51;
            this.dataGridMusteriler.RowTemplate.Height = 24;
            this.dataGridMusteriler.Size = new System.Drawing.Size(815, 364);
            this.dataGridMusteriler.TabIndex = 112;
            // 
            // lblFiltre
            // 
            this.lblFiltre.AutoSize = true;
            this.lblFiltre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFiltre.Location = new System.Drawing.Point(25, 64);
            this.lblFiltre.Name = "lblFiltre";
            this.lblFiltre.Size = new System.Drawing.Size(83, 29);
            this.lblFiltre.TabIndex = 117;
            this.lblFiltre.Text = "Filtre :";
            // 
            // UserControlMusteriYonetim
            // 
            this.Controls.Add(this.lblFiltre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFiltre);
            this.Controls.Add(this.btnMusteri);
            this.Controls.Add(this.dataGridMusteriler);
            this.Name = "UserControlMusteriYonetim";
            this.Size = new System.Drawing.Size(1146, 720);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMusteriler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFiltre;
        private System.Windows.Forms.Button btnMusteri;
        private System.Windows.Forms.DataGridView dataGridMusteriler;
        private System.Windows.Forms.Label lblFiltre;
    }
}
