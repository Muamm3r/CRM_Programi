namespace CRMProgramı.Controls
{
    partial class UserControlNot
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlNot));
            this.btnNotKaydet = new System.Windows.Forms.Button();
            this.txtNot = new System.Windows.Forms.RichTextBox();
            this.lblBaslik = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaslik)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNotKaydet
            // 
            this.btnNotKaydet.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNotKaydet.BackColor = System.Drawing.Color.Transparent;
            this.btnNotKaydet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNotKaydet.BackgroundImage")));
            this.btnNotKaydet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNotKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnNotKaydet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnNotKaydet.Location = new System.Drawing.Point(132, 320);
            this.btnNotKaydet.Name = "btnNotKaydet";
            this.btnNotKaydet.Size = new System.Drawing.Size(249, 37);
            this.btnNotKaydet.TabIndex = 142;
            this.btnNotKaydet.UseVisualStyleBackColor = false;
            this.btnNotKaydet.Click += new System.EventHandler(this.btnNotKaydet_Click);
            // 
            // txtNot
            // 
            this.txtNot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtNot.Location = new System.Drawing.Point(40, 64);
            this.txtNot.Name = "txtNot";
            this.txtNot.Size = new System.Drawing.Size(427, 240);
            this.txtNot.TabIndex = 143;
            this.txtNot.Text = "";
            // 
            // lblBaslik
            // 
            this.lblBaslik.BackColor = System.Drawing.Color.Transparent;
            this.lblBaslik.Image = ((System.Drawing.Image)(resources.GetObject("lblBaslik.Image")));
            this.lblBaslik.Location = new System.Drawing.Point(69, 8);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(393, 50);
            this.lblBaslik.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lblBaslik.TabIndex = 144;
            this.lblBaslik.TabStop = false;
            // 
            // UserControlNot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblBaslik);
            this.Controls.Add(this.txtNot);
            this.Controls.Add(this.btnNotKaydet);
            this.DoubleBuffered = true;
            this.Name = "UserControlNot";
            this.Size = new System.Drawing.Size(534, 383);
            ((System.ComponentModel.ISupportInitialize)(this.lblBaslik)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNotKaydet;
        private System.Windows.Forms.RichTextBox txtNot;
        private System.Windows.Forms.PictureBox lblBaslik;
    }
}
