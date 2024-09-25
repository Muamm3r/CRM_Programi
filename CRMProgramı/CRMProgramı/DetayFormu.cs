using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRMProgramı
{
    public partial class DetayFormu : MetroFramework.Forms.MetroForm
    {
        public DetayFormu(int kayitId)
        {
            InitializeComponent();
            YukleDetay(kayitId);
        }

        private void YukleDetay(int kayitId)
        {
            try
            {
                string query = $"SELECT detaylar FROM iletisim_kayitlari WHERE kayit_id = {kayitId}";
                DataSet ds = VeriServisleri.goster(query);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    txtDetay.Text = dr["detaylar"].ToString(); // Detayı TextBox'ta gösterin
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Detay yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

    }

}
