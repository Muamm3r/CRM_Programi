using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class MusteriDetay : MetroFramework.Forms.MetroForm
    {
        private int MusteriId;
        private string mevcutDetay; // Mevcut detay bilgisini tutmak için

        public MusteriDetay(int musteriId)
        {
            InitializeComponent();
            this.MusteriId = musteriId;
            //InitializeDataGridView();
            LoadMusteriDetails();

            // RichTextBox ve Butonları başlangıçta gizle
            richTextDetay.Visible = false;
            btnDetayKaydet.Visible = false;
            btnDetayIptal.Visible = false;
        }

     /*   private void InitializeDataGridView()
        {
            dataGridDetaylar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridDetaylar.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 12, FontStyle.Bold);
            dataGridDetaylar.DefaultCellStyle.Font = new Font("Verdana", 12, FontStyle.Regular);
            dataGridDetaylar.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridDetaylar.RowTemplate.Height = 30;
            dataGridDetaylar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridDetaylar.MultiSelect = false;
        }*/

        private void LoadMusteriDetails()
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

                string query = $"SELECT * FROM musteriler WHERE musteri_id = {MusteriId}";
                DataSet ds = VeriServisleri.goster(query);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    // İlk müşteri kaydını al ve Label kontrollerine yükle
                    DataRow dr = dt.Rows[0];
                    lblAd.Text = $"Ad: {dr["ad"]}";
                    lblSoyad.Text = $"Soyad: {dr["soyad"]}";
                    lblIsCep.Text = $"İş Telefonu: {dr["is_telefonu"]}";
                    lblCep.Text = $"Cep Telefonu: {dr["telefon"]}";
                    lblFax.Text = $"Fax: {dr["fax"]}";
                    lblEmail.Text = $"E-mail: {dr["eposta"]}";
                    lblWeb.Text = $"Web: {dr["web"]}";
                    lblSirket.Text = $"Şirket: {dr["sirket"]}";
                    lblAdres.Text = $"Adres: {dr["adres"]}";
                    lblVergiNo.Text = $"Vergi Dairesi No: {dr["vergidairesino"]}";
                    mevcutDetay = dr["detay"].ToString(); // Mevcut detayı al
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri bilgilerini yüklerken bir hata oluştu: " + ex.Message);
            }
        }

        private void btnDetay_Click(object sender, EventArgs e)
        {
            // Detay ekleme veya düzenleme işlemleri için RichTextBox ve Butonları göster
            richTextDetay.Visible = true;
            btnDetayKaydet.Visible = true;
            btnDetayIptal.Visible = true;
            richTextDetay.Text = mevcutDetay; // Mevcut detayı göster
        }

        private void btnDetayKaydet_Click(object sender, EventArgs e)
        {
            // Kullanıcının girdiği detayı veritabanına kaydet
            try
            {
                // Veritabanı bağlantı bilgilerini yükle
                VeriServisleri.Server = CRMProgramı.Properties.Settings.Default.ServerLocalIp;
                VeriServisleri.Port = CRMProgramı.Properties.Settings.Default.LocalPort;
                VeriServisleri.VKullanici = CRMProgramı.Properties.Settings.Default.LocalVKullanici;
                VeriServisleri.VSifre = CRMProgramı.Properties.Settings.Default.LocalVSifre;
                VeriServisleri.Database = "crm_db";

                // MySQL bağlantısını oluştur
                using (MySqlConnection conn = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True"))
                {
                    conn.Open();
                    string query = $"UPDATE musteriler SET detay = @Detay WHERE musteri_id = @MusteriID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Detay", richTextDetay.Text);
                    cmd.Parameters.AddWithValue("@MusteriID", MusteriId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Detay başarıyla kaydedildi.");
                richTextDetay.Visible = false;
                btnDetayKaydet.Visible = false;
                btnDetayIptal.Visible = false;
                mevcutDetay = richTextDetay.Text; // Kaydedilen detayı güncelle
            }
            catch (Exception ex)
            {
                MessageBox.Show("Detay kaydedilirken bir hata oluştu: " + ex.Message);
            }
        }

        private void btnDetayIptal_Click(object sender, EventArgs e)
        {
            // Detay ekleme veya düzenleme işlemini iptal et
            richTextDetay.Visible = false;
            btnDetayKaydet.Visible = false;
            btnDetayIptal.Visible = false;
            richTextDetay.Text = mevcutDetay; // Mevcut detayı geri yükle
        }

        private void MenuSil_Click(object sender, EventArgs e)
        {
            // Detayı silme işlemi
            try
            {
                DialogResult result = MessageBox.Show("Detayı silmek istediğinize emin misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // Veritabanı bağlantı bilgilerini yükle
                    VeriServisleri.Server = CRMProgramı.Properties.Settings.Default.ServerLocalIp;
                    VeriServisleri.Port = CRMProgramı.Properties.Settings.Default.LocalPort;
                    VeriServisleri.VKullanici = CRMProgramı.Properties.Settings.Default.LocalVKullanici;
                    VeriServisleri.VSifre = CRMProgramı.Properties.Settings.Default.LocalVSifre;
                    VeriServisleri.Database = "crm_db";

                    // MySQL bağlantısını oluştur
                    using (MySqlConnection conn = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True"))
                    {
                        conn.Open();
                        string query = $"UPDATE musteriler SET detay = '' WHERE musteri_id = @MusteriID";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MusteriID", MusteriId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Detay başarıyla silindi.");
                    mevcutDetay = ""; // Silinen detayı güncelle
                    richTextDetay.Text = ""; // RichTextBox'ı temizle
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Detay silinirken bir hata oluştu: " + ex.Message);
            }
        }
    }
}
