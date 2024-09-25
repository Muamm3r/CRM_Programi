using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector; // Veritabanı bağlantısı için gerekli kütüphane

namespace CRMProgramı
{
    public partial class UserControlIletisimTakip : UserControl
    {
        private DataTable iletisimDataTable;

        public UserControlIletisimTakip()
        {
            InitializeComponent();
            iletisimDataTable = new DataTable(); // DataTable'i initialize edin
            this.Load += UserControlIletisimTakip_Load; // UserControl yüklendiğinde yapılacak işlemler
            this.dataGridIletisim.CellContentClick += DataGridIletisim_CellContentClick; // DataGrid hücre tıklama olayı
            this.txtFiltre.TextChanged += TxtFiltre_TextChanged; // Filtre metni değiştiğinde yapılacak işlemler
            this.btnIletisimEkle.Click += BtnIletisimEkle_Click; // İletişim ekle butonuna tıklama olayı
        }

        private void UserControlIletisimTakip_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView(); // DataGridView yapılandırmasını ayarla
            GuncelIletisimKayitlariList(); // İletişim kayıtlarını güncelle
        }

        private void ConfigureDataGridView()
        {
            dataGridIletisim.AutoGenerateColumns = false;
            dataGridIletisim.Columns.Clear(); // Var olan tüm sütunları temizleyin

            // kayit_id sütunu ekle (görünmez olacak şekilde)
            if (!dataGridIletisim.Columns.Contains("kayit_id"))
            {
                DataGridViewTextBoxColumn kayitIdColumn = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "kayit_id",
                    HeaderText = "ID",
                    Name = "kayit_id",
                    Visible = false // Bu sütunu gizliyoruz
                };
                dataGridIletisim.Columns.Add(kayitIdColumn);
            }

            // Tarih sütunu ekle
            if (!dataGridIletisim.Columns.Contains("Tarih"))
            {
                DataGridViewTextBoxColumn tarihColumn = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "tarih",
                    HeaderText = "Tarih",
                    Name = "Tarih"
                };
                dataGridIletisim.Columns.Add(tarihColumn);
            }

            // Müşteri Adı sütunu ekle
            if (!dataGridIletisim.Columns.Contains("MusteriAdi"))
            {
                DataGridViewTextBoxColumn musteriAdiColumn = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "musteri_adi",
                    HeaderText = "Müşteri Adı",
                    Name = "MusteriAdi"
                };
                dataGridIletisim.Columns.Add(musteriAdiColumn);
            }

            // Detay sütunu ekle
            if (!dataGridIletisim.Columns.Contains("Detaylar"))
            {
                DataGridViewTextBoxColumn detaylarColumn = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "detaylar",
                    HeaderText = "Detay",
                    Name = "Detaylar"
                };
                dataGridIletisim.Columns.Add(detaylarColumn);
            }

            // Silme butonu sütunu ekle
            if (!dataGridIletisim.Columns.Contains("Sil"))
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Sil",
                    Name = "Sil",
                    Text = "Sil",
                    UseColumnTextForButtonValue = true // Butonun üzerinde yazı olarak "Sil" kullan
                };
                dataGridIletisim.Columns.Add(deleteButtonColumn);
            }

            // Düzenle butonu sütunu ekle
            if (!dataGridIletisim.Columns.Contains("Duzenle"))
            {
                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Düzenle",
                    Name = "Duzenle",
                    Text = "Düzenle",
                    UseColumnTextForButtonValue = true // Butonun üzerinde yazı olarak "Düzenle" kullan
                };
                dataGridIletisim.Columns.Add(editButtonColumn);
            }

            // Detay butonu sütunu ekle
            if (!dataGridIletisim.Columns.Contains("Detay"))
            {
                DataGridViewButtonColumn detailButtonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Detay",
                    Name = "Detay",
                    Text = "Detay",
                    UseColumnTextForButtonValue = true // Butonun üzerinde yazı olarak "Detay" kullan
                };
                dataGridIletisim.Columns.Add(detailButtonColumn);
            }

            // DataGridView stil ayarları
            dataGridIletisim.BackgroundColor = Color.White;
            dataGridIletisim.DefaultCellStyle.BackColor = Color.White;
            dataGridIletisim.DefaultCellStyle.ForeColor = Color.Black;
            dataGridIletisim.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridIletisim.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridIletisim.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridIletisim.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridIletisim.EnableHeadersVisualStyles = false;
            dataGridIletisim.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridIletisim.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridIletisim.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridIletisim.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridIletisim.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }




        private void GuncelIletisimKayitlariList()
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

                string query = @"
        SELECT 
            iletisim_kayitlari.kayit_id,
            iletisim_kayitlari.tarih,
            musteriler.ad AS musteri_adi,
            iletisim_kayitlari.detaylar
        FROM iletisim_kayitlari
        JOIN musteriler ON iletisim_kayitlari.musteri_id = musteriler.musteri_id";

                DataSet ds = VeriServisleri.goster(query);

                if (ds != null && ds.Tables.Count > 0)
                {
                    iletisimDataTable = ds.Tables[0];
                    dataGridIletisim.DataSource = iletisimDataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İletişim kayıtlarını güncellerken bir hata oluştu: " + ex.Message);
            }
        }


        private void TxtFiltre_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtFiltre.Text.ToLower();
            DataView dv = iletisimDataTable.DefaultView;
            dv.RowFilter = string.Format("musteri_adi LIKE '%{0}%' OR detaylar LIKE '%{0}%'", filterText);
            dataGridIletisim.DataSource = dv;
        }

        private void BtnIletisimEkle_Click(object sender, EventArgs e)
        {
            // Kullanıcı ID'sini al
            int kullaniciId = KullaniciBilgileri.KullaniciId;

            // İletişim ekleme formunu oluştur ve kullanıcı ID'sini parametre olarak geç
            IletisimEkleme iletisimEklemeFormu = new IletisimEkleme(kullaniciId);

            // Formu göster
            iletisimEklemeFormu.ShowDialog();

            // Form kapandıktan sonra iletişim kayıtlarını güncelle
            GuncelIletisimKayitlariList();
        }


        // Kullanıcı ID'sini alacak bir yöntem ekleyin (örneğin giriş işlemi sırasında set edilecek bir değişken)
        public static class KullaniciBilgileri
        {
            public static int KullaniciId { get; set; }
        }



        private void DataGridIletisim_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int kayitId = Convert.ToInt32(dataGridIletisim.Rows[e.RowIndex].Cells["kayit_id"].Value);

                // Sil butonuna tıklandıysa
                if (e.ColumnIndex == dataGridIletisim.Columns["Sil"].Index)
                {
                    SilIletisimKaydi(kayitId);
                }
                // Düzenle butonuna tıklandıysa
                else if (e.ColumnIndex == dataGridIletisim.Columns["Duzenle"].Index)
                {
                    DuzenleIletisimKaydi(kayitId);
                }
                // Detay butonuna tıklandıysa
                else if (e.ColumnIndex == dataGridIletisim.Columns["Detay"].Index)
                {
                    DetayIletisimKaydi(kayitId);
                }
            }
        }
        private void SilIletisimKaydi(int kayitId)
        {
            if (MessageBox.Show("Bu iletişim kaydını silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string deleteQuery = $"DELETE FROM iletisim_kayitlari WHERE kayit_id = {kayitId}";
                    VeriServisleri.calistir(deleteQuery);

                    MessageBox.Show("İletişim kaydı başarıyla silindi.");
                    GuncelIletisimKayitlariList(); // Silme işleminden sonra listeyi güncelle
                }
                catch (Exception ex)
                {
                    MessageBox.Show("İletişim kaydı silinirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void DuzenleIletisimKaydi(int kayitId)
        {
            // İletişim kaydı bilgilerini düzenleme formuna gönder
            IletisimEkleme iletisimEklemeFormu = new IletisimEkleme(KullaniciBilgileri.KullaniciId, kayitId);
            iletisimEklemeFormu.ShowDialog();

            GuncelIletisimKayitlariList(); // Düzenleme işleminden sonra listeyi güncelle
        }

        private void DetayIletisimKaydi(int kayitId)
        {
            // Detayları göstermek için yeni bir form oluştur
            DetayFormu detayFormu = new DetayFormu(kayitId);
            detayFormu.ShowDialog();
        }


    }
}
