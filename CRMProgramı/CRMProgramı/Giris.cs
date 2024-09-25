using System;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class Giris : MetroFramework.Forms.MetroForm
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifreyi giriniz.");
                return;
            }

            string kullaniciadi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            // Veritabanı bağlantısını kur
            VeriServisleri.Server = CRMProgramı.Properties.Settings.Default.ServerLocalIp;
            VeriServisleri.Port = CRMProgramı.Properties.Settings.Default.LocalPort;
            VeriServisleri.VKullanici = CRMProgramı.Properties.Settings.Default.LocalVKullanici;
            VeriServisleri.VSifre = CRMProgramı.Properties.Settings.Default.LocalVSifre;
            VeriServisleri.Database = "crm_db";

            VeriServisleri.baglanti = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True");

            try
            {
                VeriServisleri.baglanti.Open();
                string sql = $"SELECT * FROM kullanicilar WHERE KullaniciAdi = '{kullaniciadi}' AND Sifre = '{sifre}'";
                MySqlCommand komut = new MySqlCommand(sql, (MySqlConnection)VeriServisleri.baglanti);
                MySqlDataReader reader = komut.ExecuteReader();

                if (reader.Read())
                {
                    // Kullanıcı doğrulandı, giriş başarılı
                    string rolString = reader["rol"].ToString().ToLower(); // Kullanıcı rolünü veritabanından alır
                    int kullaniciId = Convert.ToInt32(reader["KullaniciID"]); // Kullanıcı ID'sini okuyun

                    // Kullanıcı bilgilerini sakla
                    KullaniciBilgileri.KullaniciId = kullaniciId; // Kullanıcı ID'sini sakla
                    KullaniciBilgileri.KullaniciAdi = kullaniciadi; // Kullanıcı adını sakla

                    this.Hide();
                    AnaSayfa anaSayfaFormu = new AnaSayfa(rolString, kullaniciId, kullaniciadi); // İki parametreyi de geçirin
                    anaSayfaFormu.Show(); // Kullanıcının rolüne göre AnaSayfa formu açılır
                }
                else
                {
                    // Kullanıcı adı veya şifre hatalı
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
                }

                reader.Close();
                VeriServisleri.baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
        }


        private void txtKullaniciAdi_Click(object sender, EventArgs e)
        {
            txtKullaniciAdi.Text = string.Empty;
        }

        private void txtSifre_Click(object sender, EventArgs e)
        {
            txtSifre.Text = string.Empty;
        }


    }
}
