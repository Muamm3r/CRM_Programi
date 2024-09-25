using System;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class MusteriDetayDuzen : MetroFramework.Forms.MetroForm
    {
        private int MusteriId;
        private int DetayId; // Bu alan kullanılmıyor ancak güncelleme için bırakıldı

        public MusteriDetayDuzen(int musteriId, string mevcutDetay, int detayId = -1)
        {
            InitializeComponent();
            this.MusteriId = musteriId;
            this.DetayId = detayId;
            // Detayları göster
            txtDetay.Text = mevcutDetay;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // Veritabanı bağlantı bilgilerini yükle
                VeriServisleri.Server = CRMProgramı.Properties.Settings.Default.ServerLocalIp;
                VeriServisleri.Port = CRMProgramı.Properties.Settings.Default.LocalPort;
                VeriServisleri.VKullanici = CRMProgramı.Properties.Settings.Default.LocalVKullanici;
                VeriServisleri.VSifre = CRMProgramı.Properties.Settings.Default.LocalVSifre;
                VeriServisleri.Database = "crm_db";

                // MySQL bağlantısını oluştur
                using (MySqlConnection conn = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True"))
                {
                    conn.Open();

                    // Yeni veya mevcut detayı güncelleme sorgusu oluştur
                    string query = "UPDATE musteriler SET detay = @Detay WHERE musteri_id = @MusteriID";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Detay", txtDetay.Text);
                    cmd.Parameters.AddWithValue("@MusteriID", MusteriId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Detay başarıyla kaydedildi.");
                this.Close(); // Formu kapat
            }
            catch (Exception ex)
            {
                MessageBox.Show("Detay kaydedilirken bir hata oluştu: " + ex.Message);
            }
        }
    }
}
