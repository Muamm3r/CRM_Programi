using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; // Bu satırı ekleyin
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CRMProgramı
{
    partial class DetayFormu
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
            this.txtDetay = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtDetay
            // 
            this.txtDetay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDetay.Location = new System.Drawing.Point(11, 34);
            this.txtDetay.Name = "txtDetay";
            this.txtDetay.ReadOnly = true;
            this.txtDetay.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtDetay.Size = new System.Drawing.Size(408, 176);
            this.txtDetay.TabIndex = 1;
            this.txtDetay.Text = "";
            // 
            // DetayFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 223);
            this.Controls.Add(this.txtDetay);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "DetayFormu";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.ResumeLayout(false);

        }


        #endregion
        private RichTextBox txtDetay;
    }
}