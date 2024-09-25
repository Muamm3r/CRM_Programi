using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class IletisimEkleme : MetroFramework.Forms.MetroForm
    {
        public int KullaniciId { get; set; }  // Giriş yapan kullanıcının ID'si
        private int KayitId { get; set; } // Düzenlenecek kayıt ID'si

        public IletisimEkleme(int kullaniciId, int kayitId = 0)
        {
            InitializeComponent();
            KullaniciId = kullaniciId;
            KayitId = kayitId;

            YukleMusteriListesi(); // Müşteri listesini yükle
            YukleIletisimTurleri(); // İletişim türlerini yükle

            if (KayitId > 0)
            {
                // Kaydı düzenlemek için mevcut bilgileri yükle
                YukleKayitBilgileri(KayitId);
            }
        }

        private void YukleKayitBilgileri(int kayitId)
        {
            try
            {
                string query = $"SELECT * FROM iletisim_kayitlari WHERE kayit_id = {kayitId}";
                DataSet ds = VeriServisleri.goster(query);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    comboBoxMusteri.SelectedValue = dr["musteri_id"];
                    comboBoxIletisimTuru.Text = dr["iletisim_turu"].ToString();
                    txtDetaylar.Text = dr["detaylar"].ToString();
                    dateTimePickerTarih.Value = Convert.ToDateTime(dr["tarih"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İletişim kaydı yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void YukleMusteriListesi()
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
                VeriServisleri.baglanti = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True");

                string query = "SELECT musteri_id, CONCAT(ad, ' ', soyad) AS musteri_ad FROM musteriler";
                DataSet ds = VeriServisleri.goster(query);

                if (ds != null && ds.Tables.Count > 0)
                {
                    comboBoxMusteri.DataSource = ds.Tables[0];
                    comboBoxMusteri.DisplayMember = "musteri_ad";
                    comboBoxMusteri.ValueMember = "musteri_id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri listesi yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void YukleIletisimTurleri()
        {
            try
            {
                // İletişim türlerini ekleyin
                comboBoxIletisimTuru.Items.Add("Telefon");
                comboBoxIletisimTuru.Items.Add("Eposta");
                comboBoxIletisimTuru.Items.Add("Toplanti");
                comboBoxIletisimTuru.Items.Add("Diğer");
                // Gerekirse daha fazla iletişim türü ekleyin
            }
            catch (Exception ex)
            {
                MessageBox.Show("İletişim türleri yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Alanların boş olup olmadığını kontrol edin
            if (comboBoxIletisimTuru.SelectedIndex == -1)
            {
                MessageBox.Show("İletişim türünü seçiniz.");
                return;
            }

            if (comboBoxMusteri.SelectedIndex == -1)
            {
                MessageBox.Show("İletişime geçilen müşteriyi seçiniz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDetaylar.Text))
            {
                MessageBox.Show("Detaylar alanı boş bırakılamaz.");
                return;
            }

            try
            {
                int musteriId = Convert.ToInt32(comboBoxMusteri.SelectedValue);
                string iletisimTuru = comboBoxIletisimTuru.Text;
                string detaylar = txtDetaylar.Text.Replace("'", "''");
                DateTime tarih = dateTimePickerTarih.Value;

                if (KayitId > 0)
                {
                    // Mevcut kaydı güncelle
                    string updateQuery = $"UPDATE iletisim_kayitlari SET musteri_id = {musteriId}, iletisim_turu = '{iletisimTuru}', detaylar = '{detaylar}', tarih = '{tarih.ToString("yyyy-MM-dd HH:mm:ss")}', olusturan_id = {KullaniciId} WHERE kayit_id = {KayitId}";
                    VeriServisleri.calistir(updateQuery);
                    MessageBox.Show("İletişim kaydı başarıyla güncellendi.");
                }
                else
                {
                    // Yeni kayıt ekle
                    string insertQuery = $"INSERT INTO iletisim_kayitlari (musteri_id, iletisim_turu, detaylar, tarih, olusturan_id) VALUES ({musteriId}, '{iletisimTuru}', '{detaylar}', '{tarih.ToString("yyyy-MM-dd HH:mm:ss")}', {KullaniciId})";
                    VeriServisleri.calistir(insertQuery);
                    MessageBox.Show("İletişim kaydı başarıyla eklendi.");
                }

                this.Close(); // Formu kapat
            }
            catch (Exception ex)
            {
                MessageBox.Show("İletişim kaydı kaydedilirken bir hata oluştu: " + ex.Message);
            }
        }


    }
}
