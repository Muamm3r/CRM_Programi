using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class Gorevler : MetroFramework.Forms.MetroForm
    {
        public Gorevler()
        {
            InitializeComponent();
            ConfigureDataGridView(); // DataGridView yapılandırmasını önce ayarla
            LoadGorevListesi(); // Görev listesini yükle
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

                // Bağlantıyı aç
                VeriServisleri.baglanti.Open();

                string query = @"
                    SELECT gorevler.GorevID, kullanicilar.KullaniciAdi, gorevler.Durum, gorevler.GorevAdi 
                    FROM gorevler
                    INNER JOIN kullanicilar ON gorevler.KullaniciID = kullanicilar.KullaniciID";

                DataSet ds = VeriServisleri.goster(query);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dataGridGorevler.DataSource = ds.Tables[0];
                }

                VeriServisleri.baglanti.Close(); // Bağlantıyı kapat
            }
            catch (Exception ex)
            {
                MessageBox.Show("Görev listesi yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void ConfigureDataGridView()
        {
            dataGridGorevler.AutoGenerateColumns = false;

            // GorevID sütunu ekle
            DataGridViewTextBoxColumn gorevIdColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GorevID",
                HeaderText = "Görev ID",
                Name = "GorevID"
            };
            dataGridGorevler.Columns.Add(gorevIdColumn);

            // Kullanıcı sütunu ekle
            DataGridViewTextBoxColumn kullaniciColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "KullaniciAdi",
                HeaderText = "Kullanıcı",
                Name = "KullaniciAdi"
            };
            dataGridGorevler.Columns.Add(kullaniciColumn);

            // Durum sütunu ekle
            DataGridViewTextBoxColumn durumColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Durum",
                HeaderText = "Durum",
                Name = "Durum"
            };
            dataGridGorevler.Columns.Add(durumColumn);

            // Görev Detayı sütunu ekle
            DataGridViewTextBoxColumn gorevDetayColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GorevAdi",
                HeaderText = "Görev Detayı",
                Name = "GorevDetay"
            };
            dataGridGorevler.Columns.Add(gorevDetayColumn);

            // Silme butonu sütunu ekle
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Sil",
                Name = "Sil",
                Text = "Sil",
                UseColumnTextForButtonValue = true
            };
            dataGridGorevler.Columns.Add(deleteButtonColumn);

            // Güncelle butonu sütunu ekle
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Güncelle",
                Name = "Guncelle",
                Text = "Güncelle",
                UseColumnTextForButtonValue = true
            };
            dataGridGorevler.Columns.Add(editButtonColumn);

            // DataGridView stil ayarları
            dataGridGorevler.BackgroundColor = Color.White;
            dataGridGorevler.DefaultCellStyle.BackColor = Color.White;
            dataGridGorevler.DefaultCellStyle.ForeColor = Color.Black;
            dataGridGorevler.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridGorevler.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridGorevler.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridGorevler.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridGorevler.EnableHeadersVisualStyles = false;
            dataGridGorevler.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridGorevler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridGorevler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // DataGridView'in otomatik boyutlandırma özelliklerini ayarla
            dataGridGorevler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridGorevler.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Hücre tıklama olaylarını tanımla
            dataGridGorevler.CellContentClick += DataGridGorevler_CellContentClick;
        }

        private void DataGridGorevler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Sadece veri satırlarında işlem yapılmasını sağla (Başlık ve boş satırlardan kaçınmak için)
            if (e.RowIndex >= 0)
            {
                int gorevId = Convert.ToInt32(dataGridGorevler.Rows[e.RowIndex].Cells["GorevID"].Value);

                if (e.ColumnIndex == dataGridGorevler.Columns["Sil"].Index)
                {
                    // Silme işlemini onaylama
                    DialogResult result = MessageBox.Show("Bu görevi silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            string deleteQuery = $"DELETE FROM gorevler WHERE GorevID = {gorevId}";
                            VeriServisleri.calistir(deleteQuery);
                            MessageBox.Show("Görev başarıyla silindi.");
                            LoadGorevListesi(); // Listeyi güncelle
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Görev silinirken bir hata oluştu: " + ex.Message);
                        }
                    }
                }
                else if (e.ColumnIndex == dataGridGorevler.Columns["Guncelle"].Index)
                {
                    // Güncelleme formunu aç
                    GorevVer gorevGuncelleForm = new GorevVer(gorevId); // Güncelleme için ID'yi iletin
                    gorevGuncelleForm.ShowDialog();
                    LoadGorevListesi(); // Listeyi güncelle
                }
            }
        }
    }
}
