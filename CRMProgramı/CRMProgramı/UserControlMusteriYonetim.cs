using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class UserControlMusteriYonetim : UserControl
    {
        #region Fields
        private DataTable musterilerDataTable;
        #endregion

        public UserControlMusteriYonetim()
        {
            InitializeComponent();
            musterilerDataTable = new DataTable(); // DataTable'i initialize edin
            this.Load += UserControlMusteriYonetim_Load; // UserControl yüklendiğinde yapılacak işlemler
            this.dataGridMusteriler.CellContentClick += dataGridMusteriler_CellContentClick; // DataGrid hücre tıklama olayı
            this.txtFiltre.TextChanged += TxtFilter_TextChanged; // Filtre metni değiştiğinde yapılacak işlemler
        }

        private void UserControlMusteriYonetim_Load(object sender, EventArgs e)
        {
            guncelMusterilerList(); // Müşteri listesini güncelle
            ConfigureDataGridView(); // DataGridView yapılandırmasını ayarla
        }

        #region Buton Kodları
        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            MusteriKayit musteriKayit = new MusteriKayit();
            musteriKayit.FormClosed += new FormClosedEventHandler(this.MusteriKayit_FormClosed); // Form kapandığında listeyi güncelle
            musteriKayit.Show();
        }

        private void MusteriKayit_FormClosed(object sender, FormClosedEventArgs e)
        {
            guncelMusterilerList(); // Müşteri listesini güncelle
        }

        private void txtFiltre_Click(object sender, EventArgs e)
        {
            txtFiltre.Clear(); // Filtre metnini temizle
        }
        #endregion

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtFiltre.Text.ToLower();
            DataView dv = musterilerDataTable.DefaultView;
            dv.RowFilter = string.Format("ad LIKE '%{0}%' OR soyad LIKE '%{0}%'", filterText);
            dataGridMusteriler.DataSource = dv;
        }

        private void MusteriSil(int musteriId)
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

                string deleteQuery = $"DELETE FROM musteriler WHERE musteri_id = {musteriId}";
                VeriServisleri.calistir(deleteQuery);

                // Başarı mesajını burada göster
                MessageBox.Show("Müşteri başarıyla silindi.");
                guncelMusterilerList(); // Güncelleme
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri silinirken bir hata oluştu: " + ex.Message);
            }
        }

        #region Müşterilerin DataGridView'i
        private void ConfigureDataGridView()
        {
            dataGridMusteriler.AutoGenerateColumns = false;


            // Ad sütunu ekle
            if (!dataGridMusteriler.Columns.Contains("Ad"))
            {
                DataGridViewTextBoxColumn adColumn = new DataGridViewTextBoxColumn();
                adColumn.DataPropertyName = "ad";
                adColumn.HeaderText = "Ad";
                adColumn.Name = "Ad";
                dataGridMusteriler.Columns.Add(adColumn);
            }

            // Soyad sütunu ekle
            if (!dataGridMusteriler.Columns.Contains("Soyad"))
            {
                DataGridViewTextBoxColumn soyadColumn = new DataGridViewTextBoxColumn();
                soyadColumn.DataPropertyName = "soyad";
                soyadColumn.HeaderText = "Soyad";
                soyadColumn.Name = "Soyad";
                dataGridMusteriler.Columns.Add(soyadColumn);
            }

            // Silme butonu sütunu ekle
            if (!dataGridMusteriler.Columns.Contains("Sil"))
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.HeaderText = "Sil";
                deleteButtonColumn.Name = "Sil";
                deleteButtonColumn.Text = "Sil";
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                dataGridMusteriler.Columns.Add(deleteButtonColumn);
            }

            // Düzenle butonu sütunu ekle
            if (!dataGridMusteriler.Columns.Contains("Duzenle"))
            {
                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
                editButtonColumn.HeaderText = "Düzenle";
                editButtonColumn.Name = "Duzenle";
                editButtonColumn.Text = "Düzenle";
                editButtonColumn.UseColumnTextForButtonValue = true;
                dataGridMusteriler.Columns.Add(editButtonColumn);
            }

            // Detay butonu sütunu ekle
            if (!dataGridMusteriler.Columns.Contains("Detay"))
            {
                DataGridViewButtonColumn detailButtonColumn = new DataGridViewButtonColumn();
                detailButtonColumn.HeaderText = "Detay";
                detailButtonColumn.Name = "Detay";
                detailButtonColumn.Text = "Detay";
                detailButtonColumn.UseColumnTextForButtonValue = true;
                dataGridMusteriler.Columns.Add(detailButtonColumn);
            }

            // Hatırlatma butonu sütunu ekle
           /* if (!dataGridMusteriler.Columns.Contains("Hatirlatma"))
            {
                DataGridViewButtonColumn reminderButtonColumn = new DataGridViewButtonColumn();
                reminderButtonColumn.HeaderText = "Hatırlatma";
                reminderButtonColumn.Name = "Hatirlatma";
                reminderButtonColumn.Text = "Hatırlatma";
                reminderButtonColumn.UseColumnTextForButtonValue = true;
                dataGridMusteriler.Columns.Add(reminderButtonColumn);
            }*/

            // DataGridView stil ayarları
            dataGridMusteriler.BackgroundColor = Color.White; // Arka plan rengini ayarla
            dataGridMusteriler.DefaultCellStyle.BackColor = Color.White; // Hücrelerin arka plan rengini ayarla
            dataGridMusteriler.DefaultCellStyle.ForeColor = Color.Black; // Hücrelerin metin rengini siyah yap
            dataGridMusteriler.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridMusteriler.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridMusteriler.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249); // Alternatif satırların arka plan rengini ayarla
            dataGridMusteriler.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black; // Alternatif satırların metin rengini ayarla
            dataGridMusteriler.EnableHeadersVisualStyles = false;
            dataGridMusteriler.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridMusteriler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridMusteriler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // DataGridView'in otomatik boyutlandırma özelliklerini ayarla
            dataGridMusteriler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridMusteriler.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        #endregion

        #region Müşteriler listesini günceller
        private void guncelMusterilerList()
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

                string query = "SELECT musteri_id, ad, soyad FROM musteriler";
                DataSet ds = VeriServisleri.goster(query);

                if (ds != null && ds.Tables.Count > 0)
                {
                    musterilerDataTable = ds.Tables[0]; // DataTable'i doldurun
                    dataGridMusteriler.DataSource = musterilerDataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri listesini güncellerken bir hata oluştu: " + ex.Message);
            }
        }
        #endregion

        private void dataGridMusteriler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Sadece veri satırlarında işlem yapılmasını sağla (Başlık ve boş satırlardan kaçınmak için)
            if (e.RowIndex >= 0)
            {
                if (dataGridMusteriler.Rows[e.RowIndex].Cells["musteri_id"].Value == DBNull.Value)
                {
                    return; // Eğer hücre değeri boşsa işlem yapma
                }
                int musteriId = Convert.ToInt32(dataGridMusteriler.Rows[e.RowIndex].Cells["musteri_id"].Value);
                if (e.ColumnIndex == dataGridMusteriler.Columns["Sil"].Index)
                {
                    // Silme işlemini onaylama
                    DialogResult result = MessageBox.Show("Bu müşteri kaydını silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        MusteriSil(musteriId);
                        guncelMusterilerList();

                        //işlem tamamlandığında olayı işlenmiş olarak işaretle
                        dataGridMusteriler.ClearSelection();
                        dataGridMusteriler.CurrentCell = null;
                    }
                }
                else if (e.ColumnIndex == dataGridMusteriler.Columns["Duzenle"].Index)
                {
                    //düzenleme formunu aç
                    MusteriDuzenle musteriDuzenle = new MusteriDuzenle(musteriId);
                    musteriDuzenle.FormClosed += new FormClosedEventHandler(this.MusteriKayit_FormClosed);
                    musteriDuzenle.ShowDialog();
                }
                else if (e.ColumnIndex == dataGridMusteriler.Columns["Detay"].Index)
                {
                    //detay formunu aç 
                    MusteriDetay musteriDetay = new MusteriDetay(musteriId);
                    musteriDetay.ShowDialog();
                }
               /* else if (e.ColumnIndex == dataGridMusteriler.Columns["Hatirlatma"].Index)
                {
                    // Hatırlatma ekleme formunu aç
                    Musteri secilenMusteri = new Musteri { Id = musteriId, Ad = dataGridMusteriler.Rows[e.RowIndex].Cells["ad"].Value.ToString() };
                    HatirlatmaEkle hatirlatmaEkle = new HatirlatmaEkle(secilenMusteri);
                    hatirlatmaEkle.FormClosed += new FormClosedEventHandler(this.MusteriKayit_FormClosed);
                    hatirlatmaEkle.ShowDialog();
                }*/
            }
        }
    }
}
