using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class MusteriDuzenle : MetroFramework.Forms.MetroForm
    {
        private int MusteriId;
        public MusteriDuzenle(int musteriId)
        {
            InitializeComponent();
            this.MusteriId = musteriId;
            MusteriDetayYukle();
            //btnHarita.Click += BtnHarita_Click;
        }

        private void MusteriDetayYukle()
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

                // Müşteri detaylarını yüklemek için sorgu oluştur
                string query = $"SELECT * FROM musteriler WHERE musteri_id = {MusteriId}";
                DataSet ds = VeriServisleri.goster(query);

                // Veri seti ve tablo kontrolü
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    // Verileri ilgili TextBox kontrollerine yerleştir
                    txtAd.Text = dr["ad"].ToString();
                    txtSoyad.Text = dr["soyad"].ToString();
                    txtIsCep.Text = dr["is_telefonu"].ToString();
                    txtCep.Text = dr["telefon"].ToString();
                    txtFax.Text = dr["fax"].ToString();
                    txtEmail.Text = dr["eposta"].ToString();
                    txtWeb.Text = dr["web"].ToString();
                    txtAdres.Text = dr["adres"].ToString();
                    txtVergiNo.Text = dr["vergidairesino"].ToString();
                    txtSirketAd.Text = dr["sirket"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri bilgilerini yüklerken bir hata oluştu: " + ex.Message);
            }
        }

       /* private void BtnHarita_Click(object sender, EventArgs e)
        {
            using (var mapForm = new MapForm(new RichTextBox()))
            {
                if (mapForm.ShowDialog() == DialogResult.OK)
                {
                    txtAdres.Text = mapForm.SelectedLocation;
                }
            }
        }*/

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
                VeriServisleri.baglanti = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True");

                // Güncelleme sorgusunu oluştur
                string updateQuery = $"UPDATE musteriler SET " +
                                     $"ad = '{txtAd.Text}', " +
                                     $"soyad = '{txtSoyad.Text}', " +
                                     $"is_telefonu = '{txtIsCep.Text}', " +
                                     $"telefon = '{txtCep.Text}', " +
                                     $"fax = '{txtFax.Text}', " +
                                     $"eposta = '{txtEmail.Text}', " +
                                     $"web = '{txtWeb.Text}', " +
                                     $"adres = '{txtAdres.Text}', " +
                                     $"vergidairesino = '{txtVergiNo.Text}', " +
                                     $"sirket = '{txtSirketAd.Text}' " +
                                     $"WHERE musteri_id = {MusteriId}";

                // Güncelleme sorgusunu çalıştır
                VeriServisleri.calistir(updateQuery);
                MessageBox.Show("Müşteri başarıyla güncellendi.");
                this.Close(); // Formu kapat
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri güncellenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void btnHarita_Click(object sender, EventArgs e)
        {
            using (var mapForm = new MapForm(new RichTextBox()))
            {
                if (mapForm.ShowDialog() == DialogResult.OK)
                {
                    txtAdres.Text = mapForm.SelectedLocation;
                }
            }
        }
    }
}
