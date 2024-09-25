using System;
using System.Drawing;
using System.Windows.Forms;
using CRMProgramı.Controls;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class AnaSayfa : MetroFramework.Forms.MetroForm
    {
        private string kullaniciRol;
        private int kullaniciId; // Kullanıcı ID'si alan olarak tanımlandı
        private string kullaniciAdi;

        public AnaSayfa(string rol, int kullaniciId, string kullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciRol = rol; // Rol burada saklanıyor
            this.kullaniciId = kullaniciId; // Kullanıcı ID'sini burada saklıyoruz
            this.kullaniciAdi = kullaniciAdi;

            LoadUserSelections(); // Kullanıcı seçimlerini yükleme metodu
            lblKullanici.Text = $"Hoşgeldiniz, {kullaniciAdi}";
        }

        public void LoadUserSelections()
        {
            try
            {
                // Veritabanı bağlantısını kullanarak seçimleri yükleyin
                VeriServisleri.baglanti = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True");
                VeriServisleri.baglanti.Open();

                string query = "SELECT TakvimSecili, AnalizGrafikleriSecili, GorevlerSecili, MusteriSayilariSecili, NotSecili FROM kullanicilar WHERE KullaniciID = @KullaniciID";
                using (var command = new MySqlCommand(query, (MySqlConnection)VeriServisleri.baglanti))
                {
                    command.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Ana paneli temizle
                            panelAna.Controls.Clear();

                            if (Convert.ToBoolean(reader["TakvimSecili"]))
                                AddControl(new UserControlTakvim()); // Takvim UserControl'ünü göster

                            if (Convert.ToBoolean(reader["GorevlerSecili"]))
                                AddControl(new UserControlGorevler(kullaniciId)); // Görevler UserControl'ünü göster

                            if (Convert.ToBoolean(reader["MusteriSayilariSecili"]))
                                AddControl(new UserControlMusteriSayilari()); // Müşteri Sayıları UserControl'ünü göster

                            if (Convert.ToBoolean(reader["NotSecili"]))
                                AddControl(new UserControlNot(kullaniciId)); // Not UserControl'ünü oluştururken kullaniciId'yi geçin
                        }
                    }
                }

                VeriServisleri.baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
        }

        public void AddControl(UserControl control)
        {
            // Yeni küçük bir panel oluştur
            Panel smallPanel = new Panel
            {
                Width = 400, // Küçük panelin genişliği
                Height = 300, // Küçük panelin yüksekliği
                AutoScroll = true, // Scroll bar için AutoScroll özelliğini etkinleştir
                Margin = new Padding(10) // Panelin dış kenar boşlukları
            };

            // Küçük panelin konumunu belirleyin
            int index = panelAna.Controls.Count;
            int x = (index % 2) * (smallPanel.Width + 10); // Yan yana en fazla 2 tane olacak şekilde ayarlama
            int y = (index / 2) * (smallPanel.Height + 10); // Yeni satıra geçme

            smallPanel.Location = new Point(x, y);

            // Küçük paneli ana panele ekleyin
            panelAna.Controls.Add(smallPanel);

            // UserControl'ü küçük panele ekleyin
            control.Dock = DockStyle.Fill; // UserControl'ü küçük panelin içine sığdır
            smallPanel.Controls.Add(control);
        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            LoadUserSelections(); // Ana sayfa için kullanıcı seçimlerini yeniden yükle
        }

        private void btnMusteriYonetim_Click(object sender, EventArgs e)
        {
            UserControlMusteriYonetim musteriYonetimControl = new UserControlMusteriYonetim();
            ShowSingleControl(musteriYonetimControl);
        }

        private void btnIletisimTakip_Click(object sender, EventArgs e)
        {
            // İletişim Takip UserControl'ünü göster
            UserControlIletisimTakip iletisimTakipControl = new UserControlIletisimTakip();
            ShowSingleControl(iletisimTakipControl);
        }

        private void btnSatisYonetim_Click(object sender, EventArgs e)
        {
            // Satış Yönetim UserControl'ünü göster
            UserControlSatisYonetim satisYonetimControl = new UserControlSatisYonetim();
            ShowSingleControl(satisYonetimControl);
        }

        private void btnGorevlerim_Click(object sender, EventArgs e)
        {
            // Görev ve Takvim UserControl'ünü göster
            UserControlGorevlerim userControlGorevlerim = new UserControlGorevlerim(kullaniciId); // Kullanıcı ID'sini geçiyoruz
            ShowSingleControl(userControlGorevlerim);
        }

        private void btnMesajlar_Click(object sender, EventArgs e)
        {
            UserControlMesajlasma userControlMesajlasma = new UserControlMesajlasma();
            ShowSingleControl(userControlMesajlasma);
        }

        private void btnYonetim_Click(object sender, EventArgs e)
        {
            // Rol kontrolü yap
            if (kullaniciRol == "yonetici")
            {
                // Müşteri Yönetim UserControl'ünü göster
                UserControlYonetim userControlYonetim = new UserControlYonetim();
                ShowSingleControl(userControlYonetim);
            }
            else
            {
                MessageBox.Show("Bu alana sadece yönetici girebilir.");
            }
        }

        private void ShowSingleControl(UserControl control)
        {
            // Ana paneli temizle ve yeni UserControl'ü ekle
            panelAna.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelAna.Controls.Add(control);
        }

        private void btnBilesenSecimi_Click(object sender, EventArgs e)
        {
            // FormBilesenSecimi formunu oluştur ve kullaniciId'yi ve anaSayfa referansını parametre olarak geç
            FormBilesenSecimi form = new FormBilesenSecimi(kullaniciId, this);

            // Formu dialog olarak aç
            form.ShowDialog();
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("F");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Tarih ve saati iki satırda gösterecek şekilde günceller
            lblDateTime.Text = DateTime.Now.ToString("dd MMMM yyyy dddd") + Environment.NewLine + DateTime.Now.ToString("HH:mm:ss");
        }


    }
}
