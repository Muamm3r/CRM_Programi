using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class DetayEkle : MetroFramework.Forms.MetroForm
    {
        private int MusteriId;

        public DetayEkle(int musteriId)
        {
            InitializeComponent();
            this.MusteriId = musteriId;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string detay = txtDetay.Text;

            try
            {
                // Veritabanı bağlantı bilgileri
                VeriServisleri.Server = CRMProgramı.Properties.Settings.Default.ServerLocalIp;
                VeriServisleri.Port = CRMProgramı.Properties.Settings.Default.LocalPort;
                VeriServisleri.VKullanici = CRMProgramı.Properties.Settings.Default.LocalVKullanici;
                VeriServisleri.VSifre = CRMProgramı.Properties.Settings.Default.LocalVSifre;
                VeriServisleri.Database = "crm_db";

                // MySQL bağlantısı oluşturma ve açma
                using (MySqlConnection connection = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True"))
                {
                    connection.Open();

                    // Güncelleme sorgusu oluşturma ve çalıştırma
                    string query = $"UPDATE musteriler SET detay = CONCAT(IFNULL(detay, ''), @detay, '\n') WHERE musteri_id = @MusteriId";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@detay", detay);
                    cmd.Parameters.AddWithValue("@MusteriId", MusteriId);
                    cmd.ExecuteNonQuery();
                }

                // Başarı mesajı gösterme ve formu kapatma
                MessageBox.Show("Detay başarıyla eklendi.");
                this.Close();
            }
            catch (Exception ex)
            {
                // Hata durumunda hata mesajı gösterme
                MessageBox.Show("Detay eklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
