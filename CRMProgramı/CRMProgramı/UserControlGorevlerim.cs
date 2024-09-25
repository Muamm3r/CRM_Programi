using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class UserControlGorevlerim : UserControl
    {
        private int kullaniciId;

        public UserControlGorevlerim(int kullaniciId)
        {
            InitializeComponent();
            this.kullaniciId = kullaniciId;
            ConfigureDataGridView(); // DataGridView yapılandırmasını önce yap
            LoadGorevlerim(); // Görevleri yükle
        }

        private void LoadGorevlerim()
        {
            try
            {
                // Kullanıcı ID'sinin geçerli olup olmadığını kontrol edin
                if (kullaniciId <= 0)
                {
                    MessageBox.Show("Geçersiz kullanıcı ID'si.");
                    return;
                }

                // Veritabanı bağlantı bilgilerini ayarla
                VeriServisleri.Server = CRMProgramı.Properties.Settings.Default.ServerLocalIp;
                VeriServisleri.Port = CRMProgramı.Properties.Settings.Default.LocalPort;
                VeriServisleri.VKullanici = CRMProgramı.Properties.Settings.Default.LocalVKullanici;
                VeriServisleri.VSifre = CRMProgramı.Properties.Settings.Default.LocalVSifre;
                VeriServisleri.Database = "crm_db";

                using (var baglanti = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True"))
                {
                    baglanti.Open(); // Bağlantıyı aç

                    string query = "SELECT GorevID, GorevAdi, Durum FROM gorevler WHERE KullaniciID = @KullaniciID";
                    MySqlCommand command = new MySqlCommand(query, baglanti);
                    command.Parameters.AddWithValue("@KullaniciID", kullaniciId);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dataGridViewGorevler.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Görev bulunamadı.");
                    }

                    baglanti.Close(); // Bağlantıyı kapat
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Görevler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void ConfigureDataGridView()
        {
            // DataGridView stil ayarları
            dataGridViewGorevler.BackgroundColor = Color.FromArgb(226, 226, 226);
            dataGridViewGorevler.DefaultCellStyle.BackColor = Color.White;
            dataGridViewGorevler.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewGorevler.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridViewGorevler.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridViewGorevler.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridViewGorevler.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewGorevler.EnableHeadersVisualStyles = false;
            dataGridViewGorevler.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewGorevler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridViewGorevler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // DataGridView'in otomatik boyutlandırma özelliklerini ayarla
            dataGridViewGorevler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewGorevler.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Hücre ve satır sınırlarını ayarlayın
            dataGridViewGorevler.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewGorevler.RowHeadersVisible = false; // Satır başlıklarını gizleyin
            dataGridViewGorevler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewGorevler.MultiSelect = false; // Tek satır seçimine izin ver

            // Satır yüksekliğini ayarlayın
            dataGridViewGorevler.RowTemplate.Height = 30;

            // Sütunları yapılandırın
            if (!dataGridViewGorevler.Columns.Contains("GorevID"))
            {
                DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "GorevID",
                    HeaderText = "Görev ID",
                    Name = "GorevID"
                };
                dataGridViewGorevler.Columns.Add(idColumn);
            }

            if (!dataGridViewGorevler.Columns.Contains("GorevAdi"))
            {
                DataGridViewTextBoxColumn adiColumn = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "GorevAdi",
                    HeaderText = "Görev Adı",
                    Name = "GorevAdi"
                };
                dataGridViewGorevler.Columns.Add(adiColumn);
            }

            if (!dataGridViewGorevler.Columns.Contains("Durum"))
            {
                DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn
                {
                    DataPropertyName = "Durum",
                    HeaderText = "Durum",
                    Name = "Durum"
                };
                comboBoxColumn.Items.AddRange("Yapılmamış", "Devam Ediyor", "Tamamlanmış");
                dataGridViewGorevler.Columns.Add(comboBoxColumn);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // Veritabanı bağlantısını aç
                using (var baglanti = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True"))
                {
                    baglanti.Open();

                    foreach (DataGridViewRow row in dataGridViewGorevler.Rows)
                    {
                        if (row.Cells["GorevID"].Value != null && row.Cells["Durum"].Value != null)
                        {
                            int gorevId = Convert.ToInt32(row.Cells["GorevID"].Value);
                            string yeniDurum = row.Cells["Durum"].Value.ToString();

                            // Görev durumunu güncelleme sorgusu
                            string updateQuery = "UPDATE gorevler SET Durum = @Durum WHERE GorevID = @GorevID";
                            using (MySqlCommand command = new MySqlCommand(updateQuery, baglanti))
                            {
                                command.Parameters.AddWithValue("@Durum", yeniDurum);
                                command.Parameters.AddWithValue("@GorevID", gorevId);
                                command.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Görev durumu başarıyla güncellendi.");
                    LoadGorevlerim(); // Görevleri yenile

                    baglanti.Close(); // Bağlantıyı kapat
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void DataGridViewGorevler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Burada tıklanan hücre içeriği için gerekli işlemleri yapabilirsiniz
            // Örneğin, Sil veya Güncelle butonlarına tıklama işlemleri
        }
    }
}
 