using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class KullaniciListesi : MetroFramework.Forms.MetroForm
    {
        private DataTable kullaniciDataTable;

        public KullaniciListesi()
        {
            InitializeComponent();
            LoadKullaniciListesi();
            ConfigureDataGridView(); // DataGridView yapılandırmasını ayarla
        }

        private void LoadKullaniciListesi()
        {
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

                // "olusturulma_tarihi" ve "guncellenme_tarihi" sütunlarını sorgudan kaldırdık
                string query = "SELECT KullaniciID, KullaniciAdi, rol FROM kullanicilar";
                DataSet ds = VeriServisleri.goster(query);

                if (ds != null && ds.Tables.Count > 0)
                {
                    kullaniciDataTable = ds.Tables[0];
                    dataGridKullanicilar.DataSource = kullaniciDataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı listesi yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void ConfigureDataGridView()
        {
            dataGridKullanicilar.AutoGenerateColumns = false;

            // KullaniciID sütunu ekle
            if (!dataGridKullanicilar.Columns.Contains("KullaniciID"))
            {
                DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
                idColumn.DataPropertyName = "KullaniciID";
                idColumn.HeaderText = "Kullanıcı ID";
                idColumn.Name = "KullaniciID";
                dataGridKullanicilar.Columns.Add(idColumn);
            }

            // KullaniciAdi sütunu ekle
            if (!dataGridKullanicilar.Columns.Contains("KullaniciAdi"))
            {
                DataGridViewTextBoxColumn adiColumn = new DataGridViewTextBoxColumn();
                adiColumn.DataPropertyName = "KullaniciAdi";
                adiColumn.HeaderText = "Kullanıcı Adı";
                adiColumn.Name = "KullaniciAdi";
                dataGridKullanicilar.Columns.Add(adiColumn);
            }

            // Rol sütunu ekle
            if (!dataGridKullanicilar.Columns.Contains("rol"))
            {
                DataGridViewTextBoxColumn rolColumn = new DataGridViewTextBoxColumn();
                rolColumn.DataPropertyName = "rol";
                rolColumn.HeaderText = "Rol";
                rolColumn.Name = "rol";
                dataGridKullanicilar.Columns.Add(rolColumn);
            }

            // Silme butonu sütunu ekle
            if (!dataGridKullanicilar.Columns.Contains("Sil"))
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.HeaderText = "Sil";
                deleteButtonColumn.Name = "Sil";
                deleteButtonColumn.Text = "Sil";
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                dataGridKullanicilar.Columns.Add(deleteButtonColumn);
            }

            // Güncelle butonu sütunu ekle
            if (!dataGridKullanicilar.Columns.Contains("Guncelle"))
            {
                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
                editButtonColumn.HeaderText = "Güncelle";
                editButtonColumn.Name = "Guncelle";
                editButtonColumn.Text = "Güncelle";
                editButtonColumn.UseColumnTextForButtonValue = true;
                dataGridKullanicilar.Columns.Add(editButtonColumn);
            }

            // DataGridView stil ayarları
            dataGridKullanicilar.BackgroundColor = Color.White;
            dataGridKullanicilar.DefaultCellStyle.BackColor = Color.White;
            dataGridKullanicilar.DefaultCellStyle.ForeColor = Color.Black;
            dataGridKullanicilar.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridKullanicilar.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridKullanicilar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridKullanicilar.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridKullanicilar.EnableHeadersVisualStyles = false;
            dataGridKullanicilar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridKullanicilar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridKullanicilar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // DataGridView'in otomatik boyutlandırma özelliklerini ayarla
            dataGridKullanicilar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridKullanicilar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Hücre tıklama olaylarını tanımla
            dataGridKullanicilar.CellContentClick += DataGridKullanicilar_CellContentClick;
        }

        private void DataGridKullanicilar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Sadece veri satırlarında işlem yapılmasını sağla (Başlık ve boş satırlardan kaçınmak için)
            if (e.RowIndex >= 0)
            {
                int kullaniciId = Convert.ToInt32(dataGridKullanicilar.Rows[e.RowIndex].Cells["KullaniciID"].Value);

                if (e.ColumnIndex == dataGridKullanicilar.Columns["Sil"].Index)
                {
                    // Silme işlemini onaylama
                    DialogResult result = MessageBox.Show("Bu kullanıcıyı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            string deleteQuery = $"DELETE FROM kullanicilar WHERE KullaniciID = {kullaniciId}";
                            VeriServisleri.calistir(deleteQuery);
                            MessageBox.Show("Kullanıcı başarıyla silindi.");
                            LoadKullaniciListesi(); // Listeyi güncelle
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Kullanıcı silinirken bir hata oluştu: " + ex.Message);
                        }
                    }
                }
                else if (e.ColumnIndex == dataGridKullanicilar.Columns["Guncelle"].Index)
                {
                    // Güncelleme formunu aç
                    KullaniciEkle kullaniciGuncelleForm = new KullaniciEkle(kullaniciId); // Güncelleme için ID'yi iletin
                    kullaniciGuncelleForm.ShowDialog();
                    LoadKullaniciListesi(); // Listeyi güncelle
                }
            }
        }
    }
}
