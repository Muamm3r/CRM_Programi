using System;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class SatisFirsatEkle : MetroFramework.Forms.MetroForm
    {
        public SatisFirsatEkle()
        {
            InitializeComponent();
            cmbDurum.Items.AddRange(new string[] { "Yeni", "Devam Ediyor", "Kazanıldı", "Kaybedildi" });
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string firsatAdi = txtFirsatAdi.Text;
                string aciklama = txtAciklama.Text;
                decimal tahminiDeger;
                if (!decimal.TryParse(txtTahminiDeger.Text, out tahminiDeger))
                {
                    MessageBox.Show("Lütfen geçerli bir tahmini değer girin.");
                    return;
                }
                DateTime tahminiKapanisTarihi = dtpTahminiKapanisTarihi.Value;
                string durum = cmbDurum.SelectedItem.ToString();

                VeriServisleri.Server = CRMProgramı.Properties.Settings.Default.ServerLocalIp;
                VeriServisleri.Port = CRMProgramı.Properties.Settings.Default.LocalPort;
                VeriServisleri.VKullanici = CRMProgramı.Properties.Settings.Default.LocalVKullanici;
                VeriServisleri.VSifre = CRMProgramı.Properties.Settings.Default.LocalVSifre;
                VeriServisleri.Database = "crm_db";

                using (var connection = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True"))
                {
                    connection.Open();
                    string query = "INSERT INTO satis_firsatlari (firsat_adi, aciklama, tahmini_deger, tahmini_kapanis_tarihi, durum, olusturma_tarihi) VALUES (@FirsatAdi, @Aciklama, @TahminiDeger, @TahminiKapanisTarihi, @Durum, NOW())";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirsatAdi", firsatAdi);
                        command.Parameters.AddWithValue("@Aciklama", aciklama);
                        command.Parameters.AddWithValue("@TahminiDeger", tahminiDeger);
                        command.Parameters.AddWithValue("@TahminiKapanisTarihi", tahminiKapanisTarihi);
                        command.Parameters.AddWithValue("@Durum", durum);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Satış fırsatı başarıyla eklendi.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }
    }
}
