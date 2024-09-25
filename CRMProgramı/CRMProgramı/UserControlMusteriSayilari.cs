using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı.Controls
{
    public partial class UserControlMusteriSayilari : UserControl
    {
        public UserControlMusteriSayilari()
        {
            InitializeComponent();
            MüşteriBilgileriniYükle();
        }

        private void MüşteriBilgileriniYükle()
        {
            // Veritabanı bağlantı bilgilerini ayarla
            VeriServisleri.Server = CRMProgramı.Properties.Settings.Default.ServerLocalIp;
            VeriServisleri.Port = CRMProgramı.Properties.Settings.Default.LocalPort;
            VeriServisleri.VKullanici = CRMProgramı.Properties.Settings.Default.LocalVKullanici;
            VeriServisleri.VSifre = CRMProgramı.Properties.Settings.Default.LocalVSifre;
            VeriServisleri.Database = "crm_db";

            // MySQL bağlantısını oluştur
            using (MySqlConnection baglanti = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True"))
            {
                baglanti.Open();

                // Müşteri sayısını al
                string sayiSorgusu = "SELECT COUNT(*) FROM musteriler";
                MySqlCommand sayiKomut = new MySqlCommand(sayiSorgusu, baglanti);
                int musteriSayisi = Convert.ToInt32(sayiKomut.ExecuteScalar());

                lblMusteriSayisi.Text = "" + musteriSayisi;

                // Son eklenen 5 müşteriyi al
                string sonMusterilerSorgusu = "SELECT ad, soyad FROM musteriler ORDER BY olusturulma_tarihi DESC LIMIT 7";
                MySqlCommand sonMusterilerKomut = new MySqlCommand(sonMusterilerSorgusu, baglanti);
                MySqlDataReader reader = sonMusterilerKomut.ExecuteReader();

                string musteriListesi = "";

                while (reader.Read())
                {
                    string ad = reader["ad"].ToString();
                    string soyad = reader["soyad"].ToString();
                    musteriListesi += $"{ad} {soyad}\n";
                }

                lblSonMusteriler.Text = musteriListesi;

                baglanti.Close();
            }
        }
    }
}
