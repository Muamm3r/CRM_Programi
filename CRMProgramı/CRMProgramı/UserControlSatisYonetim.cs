using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class UserControlSatisYonetim : UserControl
    {
        private DataTable satisFirsatlariDataTable;

        public UserControlSatisYonetim()
        {
            InitializeComponent();
            satisFirsatlariDataTable = new DataTable();
            this.Load += UserControlSatisYonetim_Load;
            this.dataGridSatisFirsatlari.CellContentClick += DataGridSatisFirsatlari_CellContentClick;
            this.txtFiltre.TextChanged += TxtFiltre_TextChanged;
            this.cmbDurumFiltre.SelectedIndexChanged += CmbDurumFiltre_SelectedIndexChanged;
            cmbDurumFiltre.Items.AddRange(new string[] { "Yeni", "Devam Ediyor", "Kazanıldı", "Kaybedildi" });
        }

        private void UserControlSatisYonetim_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            GuncelSatisFirsatlariList();
        }

        private void ConfigureDataGridView()
        {
            dataGridSatisFirsatlari.AutoGenerateColumns = false;
            dataGridSatisFirsatlari.Columns.Clear();

            // firsat_id sütunu ekle (görünmez olacak şekilde)
            if (!dataGridSatisFirsatlari.Columns.Contains("firsat_id"))
            {
                DataGridViewTextBoxColumn firsatIdColumn = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "firsat_id",
                    HeaderText = "ID",
                    Name = "firsat_id",
                    Visible = false
                };
                dataGridSatisFirsatlari.Columns.Add(firsatIdColumn);
            }

            // Fırsat Adı sütunu ekle
            if (!dataGridSatisFirsatlari.Columns.Contains("FirsatAdi"))
            {
                DataGridViewTextBoxColumn firsatAdiColumn = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "firsat_adi",
                    HeaderText = "Fırsat Adı",
                    Name = "FirsatAdi"
                };
                dataGridSatisFirsatlari.Columns.Add(firsatAdiColumn);
            }

            // Durum sütunu ekle
            if (!dataGridSatisFirsatlari.Columns.Contains("Durum"))
            {
                DataGridViewTextBoxColumn durumColumn = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "durum",
                    HeaderText = "Durum",
                    Name = "Durum"
                };
                dataGridSatisFirsatlari.Columns.Add(durumColumn);
            }

            // Silme butonu sütunu ekle
            if (!dataGridSatisFirsatlari.Columns.Contains("Sil"))
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Sil",
                    Name = "Sil",
                    Text = "Sil",
                    UseColumnTextForButtonValue = true
                };
                dataGridSatisFirsatlari.Columns.Add(deleteButtonColumn);
            }

            // Düzenle butonu sütunu ekle
            if (!dataGridSatisFirsatlari.Columns.Contains("Duzenle"))
            {
                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Düzenle",
                    Name = "Duzenle",
                    Text = "Düzenle",
                    UseColumnTextForButtonValue = true
                };
                dataGridSatisFirsatlari.Columns.Add(editButtonColumn);
            }

            // Detay butonu sütunu ekle
            if (!dataGridSatisFirsatlari.Columns.Contains("Detay"))
            {
                DataGridViewButtonColumn detailButtonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Detay",
                    Name = "Detay",
                    Text = "Detay",
                    UseColumnTextForButtonValue = true
                };
                dataGridSatisFirsatlari.Columns.Add(detailButtonColumn);
            }

            // DataGridView stil ayarları
            dataGridSatisFirsatlari.BackgroundColor = Color.White;
            dataGridSatisFirsatlari.DefaultCellStyle.BackColor = Color.White;
            dataGridSatisFirsatlari.DefaultCellStyle.ForeColor = Color.Black;
            dataGridSatisFirsatlari.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridSatisFirsatlari.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridSatisFirsatlari.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridSatisFirsatlari.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridSatisFirsatlari.EnableHeadersVisualStyles = false;
            dataGridSatisFirsatlari.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridSatisFirsatlari.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridSatisFirsatlari.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridSatisFirsatlari.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridSatisFirsatlari.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void GuncelSatisFirsatlariList()
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

                string query = "SELECT firsat_id, firsat_adi, durum FROM satis_firsatlari";
                DataSet ds = VeriServisleri.goster(query);

                if (ds != null && ds.Tables.Count > 0)
                {
                    satisFirsatlariDataTable = ds.Tables[0];
                    dataGridSatisFirsatlari.DataSource = satisFirsatlariDataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satış fırsatları listesi güncellenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void TxtFiltre_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtFiltre.Text.ToLower();
            DataView dv = satisFirsatlariDataTable.DefaultView;
            dv.RowFilter = string.Format("firsat_adi LIKE '%{0}%'", filterText);
            dataGridSatisFirsatlari.DataSource = dv;
        }

        private void CmbDurumFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDurum = cmbDurumFiltre.SelectedItem.ToString();
            DataView dv = satisFirsatlariDataTable.DefaultView;

            if (selectedDurum == "Tümü")
            {
                dv.RowFilter = ""; // Tüm kayıtları göster
            }
            else
            {
                dv.RowFilter = string.Format("durum = '{0}'", selectedDurum);
            }

            dataGridSatisFirsatlari.DataSource = dv;
        }

        private void DataGridSatisFirsatlari_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int firsatId = Convert.ToInt32(dataGridSatisFirsatlari.Rows[e.RowIndex].Cells["firsat_id"].Value);

                // Sil butonuna tıklandıysa
                if (e.ColumnIndex == dataGridSatisFirsatlari.Columns["Sil"].Index)
                {
                    SilSatisFirsati(firsatId);
                }
                // Düzenle butonuna tıklandıysa
                else if (e.ColumnIndex == dataGridSatisFirsatlari.Columns["Duzenle"].Index)
                {
                    DuzenleSatisFirsati(firsatId);
                }
                // Detay butonuna tıklandıysa
                else if (e.ColumnIndex == dataGridSatisFirsatlari.Columns["Detay"].Index)
                {
                    DetaySatisFirsati(firsatId);
                }
            }
        }

        private void SilSatisFirsati(int firsatId)
        {
            if (MessageBox.Show("Bu satış fırsatını silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string deleteQuery = $"DELETE FROM satis_firsatlari WHERE firsat_id = {firsatId}";
                    VeriServisleri.calistir(deleteQuery);

                    MessageBox.Show("Satış fırsatı başarıyla silindi.");
                    GuncelSatisFirsatlariList(); // Silme işleminden sonra listeyi güncelle
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Satış fırsatı silinirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void DuzenleSatisFirsati(int firsatId)
        {
            // Satış fırsatı bilgilerini düzenleme formuna gönderir
            SatisFirsatDuzenle satisFirsatDuzenleFormu = new SatisFirsatDuzenle(firsatId);
            satisFirsatDuzenleFormu.ShowDialog();

            GuncelSatisFirsatlariList(); // Düzenleme işleminden sonra listeyi günceller
        }

        private void DetaySatisFirsati(int firsatId)
        {
            // Detayları göstermek için yeni bir form oluştur
            SatisFirsatDetay satisFirsatDetayFormu = new SatisFirsatDetay(firsatId);
            satisFirsatDetayFormu.ShowDialog();
        }

        private void BtnYeniFirsat_Click(object sender, EventArgs e)
        {
            // Yeni satış fırsatı ekleme formunu oluştur
            SatisFirsatEkle satisFirsatEkleFormu = new SatisFirsatEkle();

            // Formu göster
            satisFirsatEkleFormu.ShowDialog();

            // Form kapandıktan sonra satış fırsatları listesini güncelle
            GuncelSatisFirsatlariList();
        }

    }
}
