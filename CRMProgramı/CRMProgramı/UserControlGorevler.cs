using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class UserControlGorevler : UserControl
    {
        private int kullaniciId;

        public UserControlGorevler(int kullaniciId)
        {
            InitializeComponent();
            this.kullaniciId = kullaniciId;
            LoadGorevListesi();
        }

        private void LoadGorevListesi()
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

                VeriServisleri.baglanti.Open(); // Bağlantıyı aç

                string query = $"SELECT GorevID, GorevAdi, Durum FROM gorevler WHERE KullaniciID = {kullaniciId}";
                DataSet ds = VeriServisleri.goster(query);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    int yPos = 70; // Başlangıç y konumu
                    int labelSpacing = 20; // Etiketler arası mesafe

                    // Font boyutunu artır
                    Font labelFont = new Font("Arial", 12, FontStyle.Regular);

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string durum = row["Durum"].ToString();

                        // Sadece "Devam Ediyor" ve "Yapılmamış" durumundaki görevleri göster
                        if (durum != "Tamamlanmış")
                        {
                            // Görev ve durum bilgilerini tek bir label'da göster
                            Label lblGorevDurum = new Label();
                            lblGorevDurum.Text = $"Görev: {row["GorevAdi"]} - Durum: {durum}";
                            lblGorevDurum.Location = new Point(20, yPos); // X pozisyonunu ayarla
                            lblGorevDurum.Size = new Size(350, 0); // Sabit genişlik, otomatik yükseklik
                            lblGorevDurum.MaximumSize = new Size(350, 0); // Maksimum genişlik 350 piksel
                            lblGorevDurum.AutoSize = true;
                            lblGorevDurum.Font = labelFont;
                            lblGorevDurum.BackColor = ColorTranslator.FromHtml("#e2e2e2"); // Arka planı transparan yap

                            // Etiketi kontrol listesine ekle
                            this.Controls.Add(lblGorevDurum);

                            // Etiketi ön plana getir
                            lblGorevDurum.BringToFront();

                            yPos += lblGorevDurum.Height + labelSpacing; // Bir sonraki satıra geç
                        }
                    }
                }
                //else
                //{
                //    MessageBox.Show("Görev bulunamadı veya kullanıcının görevi yok.");
                //}

                VeriServisleri.baglanti.Close(); // Bağlantıyı kapat

                // Panelin arka plan rengini transparan yap
                this.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Görevler yüklenirken bir hata oluştu: " + ex.Message);
                if (VeriServisleri.baglanti != null && VeriServisleri.baglanti.State == ConnectionState.Open)
                {
                    VeriServisleri.baglanti.Close(); // Bağlantıyı kapat
                }
            }
        }
    }
}
