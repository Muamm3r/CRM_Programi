using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class UserControlMesajlasma : UserControl
    {
        private string kullaniciAdi = KullaniciBilgileri.KullaniciAdi; // Giriş yapan kullanıcının adını saklayan değişken

        public UserControlMesajlasma()
        {
            InitializeComponent();
            KullaniciListele(); // Kullanıcıları listeleme metodunu çağır
        }

        private void KullaniciListele()
        {
            try
            {
                lstKullanicilar.DisplayMember = "Text";
                lstKullanicilar.ValueMember = "Value";
                lstKullanicilar.Items.Clear();

                string sorgu = "SELECT KullaniciID, KullaniciAdi FROM kullanicilar";
                VeriServisleri.baglanti.Open();
                MySqlCommand komut = new MySqlCommand(sorgu, (MySqlConnection)VeriServisleri.baglanti);
                MySqlDataReader okuyucu = komut.ExecuteReader();

                while (okuyucu.Read())
                {
                    lstKullanicilar.Items.Add(new ListBoxItem
                    {
                        Text = okuyucu["KullaniciAdi"].ToString(),
                        Value = okuyucu["KullaniciID"]
                    });
                }

                okuyucu.Close();
                VeriServisleri.baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcılar yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void lstKullanicilar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstKullanicilar.SelectedItem != null)
            {
                if (int.TryParse(((ListBoxItem)lstKullanicilar.SelectedItem).Value.ToString(), out int aliciId))
                {
                    MesajlariYukle(aliciId);
                }
                else
                {
                    MessageBox.Show("Kullanıcı ID'si geçerli bir sayı değil.");
                }
            }
        }

        private void MesajlariYukle(int aliciId)
        {
            try
            {
                int gonderenId = KullaniciBilgileri.KullaniciId;

                string query = "SELECT gonderen_id, alici_id, mesaj_icerigi FROM mesajlar WHERE (gonderen_id = @GonderenId AND alici_id = @AliciId) OR (gonderen_id = @AliciId AND alici_id = @GonderenId) ORDER BY zaman ASC";
                VeriServisleri.baglanti.Open();
                MySqlCommand komut = new MySqlCommand(query, (MySqlConnection)VeriServisleri.baglanti);
                komut.Parameters.AddWithValue("@GonderenId", gonderenId);
                komut.Parameters.AddWithValue("@AliciId", aliciId);
                MySqlDataReader reader = komut.ExecuteReader();

                flowLayoutPanelMesajlar.Controls.Clear(); // Eski mesajları temizle
                while (reader.Read())
                {
                    int gonderenIdFromDB = Convert.ToInt32(reader["gonderen_id"]);
                    int aliciIdFromDB = Convert.ToInt32(reader["alici_id"]);
                    string mesaj = reader["mesaj_icerigi"].ToString();

                    // Mesajı doğru tarafa eklemek için gonderenId kontrolü yapıyoruz
                    bool mesajGonderenMi = (gonderenIdFromDB == gonderenId); // Gönderici kimse true olur

                    // Mesajı ekle
                    MesajEkle(mesaj, mesajGonderenMi);
                }

                reader.Close();
                VeriServisleri.baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mesajlar yüklenirken bir hata oluştu: " + ex.Message);
                if (VeriServisleri.baglanti.State == ConnectionState.Open)
                {
                    VeriServisleri.baglanti.Close();
                }
            }
        }

        // Mesajları FlowLayoutPanel'e ekleyip sağa/sola hizalama ve arka plan rengi uygulama
        private void MesajEkle(string mesaj, bool gonderenMi)
        {
            // Mesaj balonunu gösterecek panel oluştur
            Panel mesajPaneli = new Panel();
            mesajPaneli.AutoSize = true;
            mesajPaneli.MaximumSize = new Size(250, 0); // Balon genişliği sınırlı olsun, taşarsa alt satıra geçsin
            mesajPaneli.BackColor = gonderenMi ? Color.FromArgb(37, 211, 102) : Color.FromArgb(235, 235, 235); // Gönderen için yeşil, alıcı için gri
            mesajPaneli.Padding = new Padding(10);
            mesajPaneli.Margin = new Padding(5); // Her mesaj arasında boşluk bırak

            // Mesajı göstermek için Label oluştur
            Label mesajLabel = new Label();
            mesajLabel.Text = mesaj;
            mesajLabel.AutoSize = true; // Boyutunu kendisi ayarlayacak
            mesajLabel.MaximumSize = new Size(200, 0); // Genişlik sınırlı, satır sonuna gelince alt satıra geçsin
            mesajLabel.ForeColor = gonderenMi ? Color.White : Color.Black; // Gönderen beyaz, alıcı siyah yazı rengi

            mesajPaneli.Controls.Add(mesajLabel); // Mesajı panele ekle

            // Gönderen mesajı sağa yasla, alıcı mesajı sola yasla
            if (gonderenMi)
            {
                // Gönderen mesajını sağ tarafa yasla
                mesajPaneli.RightToLeft = RightToLeft.Yes;  // Sağ tarafa yaslamak için
                mesajPaneli.Anchor = AnchorStyles.Right;    // Sağ tarafa hizala
                mesajPaneli.Margin = new Padding(50, 3, 10, 3);  // Sağ tarafa biraz boşluk bırak
            }
            else
            {
                // Alıcı mesajını sola yasla
                mesajPaneli.RightToLeft = RightToLeft.No;
                mesajPaneli.Anchor = AnchorStyles.Left;
                mesajPaneli.Margin = new Padding(10, 3, 50, 3);  // Sol tarafa biraz boşluk bırak
            }

            // FlowLayoutPanel'e mesajı ekle ve en son mesaja kaydır
            flowLayoutPanelMesajlar.Controls.Add(mesajPaneli);
            flowLayoutPanelMesajlar.ScrollControlIntoView(mesajPaneli); // En son mesaja kaydır
        }



        private void btnGonder_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMesaj.Text))
            {
                // Mesajı ekle (true: Gönderen)
               /*esajEkle(txtMesaj.Text, true); // Gönderici mesajı sağ tarafa hizalanacak
                txtMesaj.Clear(); // Mesaj kutusunu temizle*/

                // Mesajı veritabanına ekleyelim
                try
                {
                    int gonderenId = KullaniciBilgileri.KullaniciId;

                    if (lstKullanicilar.SelectedItem == null)
                    {
                        MessageBox.Show("Lütfen bir kullanıcı seçin.");
                        return;
                    }

                    if (!int.TryParse(((ListBoxItem)lstKullanicilar.SelectedItem).Value.ToString(), out int aliciId))
                    {
                        MessageBox.Show("Kullanıcı ID'si geçerli bir sayı değil.");
                        return;
                    }

                    string mesajIcerigi = txtMesaj.Text;

                    if (string.IsNullOrWhiteSpace(mesajIcerigi))
                    {
                        MessageBox.Show("Lütfen mesaj içeriğini girin.");
                        return;
                    }

                    if (VeriServisleri.baglanti.State != ConnectionState.Open)
                    {
                        VeriServisleri.baglanti.Open();
                    }

                    string sql = "INSERT INTO mesajlar (gonderen_id, alici_id, mesaj_icerigi) VALUES (@GonderenId, @AliciId, @MesajIcerigi)";
                    using (var komut = new MySqlCommand(sql, (MySqlConnection)VeriServisleri.baglanti))
                    {
                        komut.Parameters.AddWithValue("@GonderenId", gonderenId);
                        komut.Parameters.AddWithValue("@AliciId", aliciId);
                        komut.Parameters.AddWithValue("@MesajIcerigi", mesajIcerigi);

                        komut.ExecuteNonQuery();
                    }

                    VeriServisleri.baglanti.Close();

                    // Mesajı ekle (Gönderici olduğumuz için true)
                    MesajEkle(mesajIcerigi, true);

                    txtMesaj.Clear(); // Mesaj kutusunu temizle
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mesaj gönderilirken bir hata oluştu: " + ex.Message);
                    if (VeriServisleri.baglanti.State == ConnectionState.Open)
                    {
                        VeriServisleri.baglanti.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir mesaj girin.");
            }
        }

        // Mesajları silmek için butona tıklama işlevi
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lstKullanicilar.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.");
                return;
            }

            if (!int.TryParse(((ListBoxItem)lstKullanicilar.SelectedItem).Value.ToString(), out int aliciId))
            {
                MessageBox.Show("Kullanıcı ID'si geçerli bir sayı değil.");
                return;
            }

            // Kullanıcıdan onay almak için onay penceresi gösteriyoruz
            DialogResult dialogResult = MessageBox.Show("Seçilen kullanıcıyla olan tüm mesajları silmek istediğinizden emin misiniz?", "Mesajları Sil", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    int gonderenId = KullaniciBilgileri.KullaniciId;

                    if (VeriServisleri.baglanti.State != ConnectionState.Open)
                    {
                        VeriServisleri.baglanti.Open();
                    }

                    // Seçilen kullanıcıya ait mesajları silen SQL sorgusu
                    string sql = "DELETE FROM mesajlar WHERE (gonderen_id = @GonderenId AND alici_id = @AliciId) OR (gonderen_id = @AliciId AND alici_id = @GonderenId)";
                    using (var komut = new MySqlCommand(sql, (MySqlConnection)VeriServisleri.baglanti))
                    {
                        komut.Parameters.AddWithValue("@GonderenId", gonderenId);
                        komut.Parameters.AddWithValue("@AliciId", aliciId);
                        komut.ExecuteNonQuery();
                    }

                    VeriServisleri.baglanti.Close();

                    // Mesaj kutusunu temizle ve kullanıcıya mesajları gösterme işlemini yenile
                    flowLayoutPanelMesajlar.Controls.Clear();
                    MessageBox.Show("Seçilen kullanıcıyla olan mesajlar başarıyla silindi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mesajlar silinirken bir hata oluştu: " + ex.Message);
                    if (VeriServisleri.baglanti.State == ConnectionState.Open)
                    {
                        VeriServisleri.baglanti.Close();
                    }
                }
            }
            else
            {
                // Eğer kullanıcı "Hayır" derse silme işlemi iptal edilir
                MessageBox.Show("Mesajlar silinmedi.");
            }
        }
    }

    public class ListBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text; // ListBox'ta sadece metin gösterilecek
        }
    }

    public static class KullaniciBilgileri
    {
        public static int KullaniciId { get; set; }
        public static string KullaniciAdi { get; set; }
    }
}
