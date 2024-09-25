using System;
using System.Windows.Forms;

namespace CRMProgramı
{
    public partial class DetayGosterForm : MetroFramework.Forms.MetroForm
    {
        public DetayGosterForm(string detay)
        {
            InitializeComponent();
            richTextBoxDetay.Text = detay;
        }
    }
}
