using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class KullaniciEkle : MetroFramework.Forms.MetroForm
    {
        private int? kullaniciId; // Null olabilen kullanıcı ID'si

        // Varsayılan yapıcı
        public KullaniciEkle()
        {
            InitializeComponent();
        }

        // Parametre alan yapıcı
        public KullaniciEkle(int kullaniciId)
        {
            InitializeComponent();
            this.kullaniciId = kullaniciId;
            LoadKullaniciBilgileri(); // Kullanıcı bilgilerini yükle
        }

        private void LoadKullaniciBilgileri()
        {
            if (kullaniciId == null)
                return;

            try
            {
                // Veritabanı bağlantısını yap
                VeriServisleri.Server = CRMProgramı.Properties.Settings.Default.ServerLocalIp;
                VeriServisleri.Port = CRMProgramı.Properties.Settings.Default.LocalPort;
                VeriServisleri.VKullanici = CRMProgramı.Properties.Settings.Default.LocalVKullanici;
                VeriServisleri.VSifre = CRMProgramı.Properties.Settings.Default.LocalVSifre;
                VeriServisleri.Database = "crm_db";

                // MySQL bağlantısını oluştur
                VeriServisleri.baglanti = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True");

                string query = $"SELECT KullaniciAdi, sifre, rol FROM kullanicilar WHERE KullaniciID = {kullaniciId}";
                DataSet ds = VeriServisleri.goster(query);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    txtKullaniciAdi.Text = dr["KullaniciAdi"].ToString();
                    txtSifre.Text = dr["sifre"].ToString();
                    comboBoxRol.SelectedItem = dr["rol"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı bilgileri yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // Kullanıcı bilgilerini al
                string kullaniciAdi = txtKullaniciAdi.Text;
                string sifre = txtSifre.Text;
                string rol = comboBoxRol.SelectedItem?.ToString();

                if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(sifre) || string.IsNullOrWhiteSpace(rol))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                    return;
                }

                // Veritabanı bağlantısını yap
                VeriServisleri.Server = CRMProgramı.Properties.Settings.Default.ServerLocalIp;
                VeriServisleri.Port = CRMProgramı.Properties.Settings.Default.LocalPort;
                VeriServisleri.VKullanici = CRMProgramı.Properties.Settings.Default.LocalVKullanici;
                VeriServisleri.VSifre = CRMProgramı.Properties.Settings.Default.LocalVSifre;
                VeriServisleri.Database = "crm_db";

                // MySQL bağlantısını oluştur
                VeriServisleri.baglanti = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True");

                // Bağlantıyı aç
                VeriServisleri.baglanti.Open();

                if (kullaniciId == null)
                {
                    // Yeni kullanıcı ekle
                    string insertQuery = "INSERT INTO kullanicilar (KullaniciAdi, sifre, rol) VALUES (@KullaniciAdi, @Sifre, @Rol)";
                    using (var command = new MySqlCommand(insertQuery, (MySqlConnection)VeriServisleri.baglanti))
                    {
                        command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                        command.Parameters.AddWithValue("@Sifre", sifre);
                        command.Parameters.AddWithValue("@Rol", rol);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Kullanıcı başarıyla eklendi.");
                }
                else
                {
                    // Mevcut kullanıcıyı güncelle
                    string updateQuery = "UPDATE kullanicilar SET KullaniciAdi = @KullaniciAdi, sifre = @Sifre, rol = @Rol WHERE KullaniciID = @KullaniciID";
                    using (var command = new MySqlCommand(updateQuery, (MySqlConnection)VeriServisleri.baglanti))
                    {
                        command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                        command.Parameters.AddWithValue("@Sifre", sifre);
                        command.Parameters.AddWithValue("@Rol", rol);
                        command.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Kullanıcı bilgileri başarıyla güncellendi.");
                }

                // Bağlantıyı kapat
                VeriServisleri.baglanti.Close();

                this.Close(); // Formu kapat
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
            finally
            {
                if (VeriServisleri.baglanti.State == ConnectionState.Open)
                {
                    VeriServisleri.baglanti.Close();
                }
            }
        }

    }
}
