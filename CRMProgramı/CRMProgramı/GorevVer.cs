using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class GorevVer : MetroFramework.Forms.MetroForm
    {
        private int? gorevId = null;

        public GorevVer()
        {
            InitializeComponent();
            LoadKullaniciListesi(); // Kullanıcı listesini yükle
            LoadDurumListesi(); // Görev durumu listesini yükle
        }

        public GorevVer(int gorevId) : this()
        {
            this.gorevId = gorevId;
            LoadGorevBilgileri(); // Güncelleme için görev bilgilerini yükle
        }

        private void LoadKullaniciListesi()
        {
            try
            {
                // Veritabanı bağlantı bilgilerini yükle
                VeriServisleri.Server = CRMProgramı.Properties.Settings.Default.ServerLocalIp;
                VeriServisleri.Port = CRMProgramı.Properties.Settings.Default.LocalPort;
                VeriServisleri.VKullanici = CRMProgramı.Properties.Settings.Default.LocalVKullanici;
                VeriServisleri.VSifre = CRMProgramı.Properties.Settings.Default.LocalVSifre;
                VeriServisleri.Database = "crm_db";

                // Veritabanı bağlantısı hazırlandı ve sorgu çalıştırıldı
                string query = "SELECT KullaniciID, KullaniciAdi FROM kullanicilar";
                DataSet ds = VeriServisleri.goster(query);

                if (ds != null && ds.Tables.Count > 0)
                {
                    comboBoxKullanici.DataSource = ds.Tables[0];
                    comboBoxKullanici.DisplayMember = "KullaniciAdi";
                    comboBoxKullanici.ValueMember = "KullaniciID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı listesi yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void LoadDurumListesi()
        {
            // Görev durumlarını yükleyin
            comboBoxDurum.Items.Add("Yapılmamış");
            comboBoxDurum.Items.Add("Devam Ediyor");
            comboBoxDurum.Items.Add("Tamamlanmış");
            comboBoxDurum.SelectedIndex = 0; // Varsayılan olarak "Yapılmamış" seçin
        }

        private void LoadGorevBilgileri()
        {
            if (gorevId.HasValue)
            {
                try
                {
                    // Veritabanı bağlantı bilgilerini yükle
                    VeriServisleri.Server = CRMProgramı.Properties.Settings.Default.ServerLocalIp;
                    VeriServisleri.Port = CRMProgramı.Properties.Settings.Default.LocalPort;
                    VeriServisleri.VKullanici = CRMProgramı.Properties.Settings.Default.LocalVKullanici;
                    VeriServisleri.VSifre = CRMProgramı.Properties.Settings.Default.LocalVSifre;
                    VeriServisleri.Database = "crm_db";

                    // Görev bilgilerini veritabanından alın
                    string query = $"SELECT * FROM gorevler WHERE GorevID = {gorevId.Value}";
                    DataSet ds = VeriServisleri.goster(query);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = ds.Tables[0].Rows[0];
                        txtGorevAdi.Text = row["GorevAdi"].ToString();
                        comboBoxDurum.SelectedItem = row["Durum"].ToString();
                        comboBoxKullanici.SelectedValue = row["KullaniciID"];
                    }
                    else
                    {
                        MessageBox.Show("Görev bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Görev bilgileri yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                int kullaniciId = Convert.ToInt32(comboBoxKullanici.SelectedValue);
                string gorevAdi = txtGorevAdi.Text;
                string durum = comboBoxDurum.SelectedItem.ToString();

                if (string.IsNullOrWhiteSpace(gorevAdi))
                {
                    MessageBox.Show("Görev adını giriniz.");
                    return;
                }

                using (MySqlConnection baglanti = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True"))
                {
                    baglanti.Open();

                    if (gorevId.HasValue)
                    {
                        // Güncelleme sorgusu
                        string updateQuery = "UPDATE gorevler SET KullaniciID = @KullaniciID, GorevAdi = @GorevAdi, Durum = @Durum, guncelleme_tarihi = NOW() WHERE GorevID = @GorevID";
                        using (MySqlCommand command = new MySqlCommand(updateQuery, baglanti))
                        {
                            command.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                            command.Parameters.AddWithValue("@GorevAdi", gorevAdi);
                            command.Parameters.AddWithValue("@Durum", durum);
                            command.Parameters.AddWithValue("@GorevID", gorevId.Value);
                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("Görev başarıyla güncellendi.");
                    }
                    else
                    {
                        // Ekleme sorgusu
                        string insertQuery = "INSERT INTO gorevler (KullaniciID, GorevAdi, Durum, olusturma_tarihi) VALUES (@KullaniciID, @GorevAdi, @Durum, NOW())";
                        using (MySqlCommand command = new MySqlCommand(insertQuery, baglanti))
                        {
                            command.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                            command.Parameters.AddWithValue("@GorevAdi", gorevAdi);
                            command.Parameters.AddWithValue("@Durum", durum);
                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("Görev başarıyla eklendi.");
                    }
                }
                this.Close(); // Formu kapat
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }
    }
}
