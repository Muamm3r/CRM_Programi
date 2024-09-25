using System;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class SatisFirsatDuzenle : MetroFramework.Forms.MetroForm
    {
        private int firsatId;

        public SatisFirsatDuzenle(int firsatId)
        {
            InitializeComponent();
            this.firsatId = firsatId;
            cmbDurum.Items.AddRange(new string[] { "Yeni", "Devam Ediyor", "Kazanıldı", "Kaybedildi" });
            LoadFirsatDetails();
        }

        private void LoadFirsatDetails()
        {
            try
            {
                VeriServisleri.Server = CRMProgramı.Properties.Settings.Default.ServerLocalIp;
                VeriServisleri.Port = CRMProgramı.Properties.Settings.Default.LocalPort;
                VeriServisleri.VKullanici = CRMProgramı.Properties.Settings.Default.LocalVKullanici;
                VeriServisleri.VSifre = CRMProgramı.Properties.Settings.Default.LocalVSifre;
                VeriServisleri.Database = "crm_db";

                using (var connection = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True"))
                {
                    connection.Open();
                    string query = "SELECT * FROM satis_firsatlari WHERE firsat_id = @FirsatID";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirsatID", firsatId);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtFirsatAdi.Text = reader["firsat_adi"].ToString();
                                txtAciklama.Text = reader["aciklama"].ToString();
                                txtTahminiDeger.Text = reader["tahmini_deger"].ToString();
                                dtpTahminiKapanisTarihi.Value = Convert.ToDateTime(reader["tahmini_kapanis_tarihi"]);
                                cmbDurum.SelectedItem = reader["durum"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
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
                    string query = "UPDATE satis_firsatlari SET firsat_adi = @FirsatAdi, aciklama = @Aciklama, tahmini_deger = @TahminiDeger, tahmini_kapanis_tarihi = @TahminiKapanisTarihi, durum = @Durum WHERE firsat_id = @FirsatID";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirsatAdi", firsatAdi);
                        command.Parameters.AddWithValue("@Aciklama", aciklama);
                        command.Parameters.AddWithValue("@TahminiDeger", tahminiDeger);
                        command.Parameters.AddWithValue("@TahminiKapanisTarihi", tahminiKapanisTarihi);
                        command.Parameters.AddWithValue("@Durum", durum);
                        command.Parameters.AddWithValue("@FirsatID", firsatId);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Satış fırsatı başarıyla güncellendi.");
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
