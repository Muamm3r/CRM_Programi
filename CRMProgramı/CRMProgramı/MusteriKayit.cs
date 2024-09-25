using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class MusteriKayit : MetroFramework.Forms.MetroForm
    {
        public event EventHandler MusteriEklendi;

        public MusteriKayit()
        {
            InitializeComponent();
        }

        private void BtnHarita_Click(object sender, EventArgs e)
        {
            // Harita formunu aç ve kullanıcı bir konum seçerse adresi güncelle
            using (var mapForm = new MapForm(new RichTextBox()))
            {
                if (mapForm.ShowDialog() == DialogResult.OK)
                {
                    txtAdres.Text = mapForm.SelectedLocation;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // TextBox'lardan müşteri bilgilerini al
                string ad = txtAd.Text.Replace("'", "");
                string soyad = txtSoyad.Text;
                string isTelefonu = txtIsCep.Text;
                string cepTelefonu = txtCep.Text;
                string fax = txtFax.Text;
                string email = txtEmail.Text;
                string web = txtWeb.Text;
                string adres = txtAdres.Text;
                string vergiDairesiNo = txtVergiNo.Text;

                // Yeni müşteri kimliği al
                int kimlik = YeniMusteriId();

                // Veritabanı bağlantı bilgilerini yükle
                VeriServisleri.Server = CRMProgramı.Properties.Settings.Default.ServerLocalIp;
                VeriServisleri.Port = CRMProgramı.Properties.Settings.Default.LocalPort;
                VeriServisleri.VKullanici = CRMProgramı.Properties.Settings.Default.LocalVKullanici;
                VeriServisleri.VSifre = CRMProgramı.Properties.Settings.Default.LocalVSifre;
                VeriServisleri.Database = "crm_db";

                // MySQL bağlantısını oluştur
                VeriServisleri.baglanti = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True");

                // Kayıt ekleme sorgusunu oluştur ve çalıştır
                string kayitEkle = $"INSERT INTO musteriler (musteri_id, ad, soyad, is_telefonu, telefon, fax, eposta, web, adres, vergidairesino) " +
                                   $"VALUES ({kimlik}, '{ad}', '{soyad}', '{isTelefonu}', '{cepTelefonu}', '{fax}', '{email}', '{web}', '{adres}', '{vergiDairesiNo}')";
                VeriServisleri.calistir(kayitEkle);

                // Kullanıcıya başarı mesajı göster
                MessageBox.Show("Müşteri başarıyla kaydedildi.");

                MusteriEklendi?.Invoke(this, EventArgs.Empty);

                this.Close(); // Formu kapat
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri kaydedilirken bir hata oluştu: " + ex.Message);
            }
        }

        private int YeniMusteriId()
        {
            int nextId = 1;

            // Veritabanı bağlantı bilgilerini yükle
            VeriServisleri.Server = CRMProgramı.Properties.Settings.Default.ServerLocalIp;
            VeriServisleri.Port = CRMProgramı.Properties.Settings.Default.LocalPort;
            VeriServisleri.VKullanici = CRMProgramı.Properties.Settings.Default.LocalVKullanici;
            VeriServisleri.VSifre = CRMProgramı.Properties.Settings.Default.LocalVSifre;
            VeriServisleri.Database = "crm_db";

            // MySQL bağlantısını oluştur
            VeriServisleri.baglanti = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True");

            // Son müşteri kimliğini almak için sorgu oluştur
            string query = "SELECT MAX(musteri_id) FROM musteriler";
            DataSet ds = VeriServisleri.goster(query);

            // Veri kontrolü ve sonraki müşteri kimliğini belirleme
            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][0] != DBNull.Value)
            {
                nextId = Convert.ToInt32(ds.Tables[0].Rows[0][0]) + 1;
            }

            return nextId;
        }
    }
}
