using System;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class SatisFirsatDetay : MetroFramework.Forms.MetroForm
    {
        private int firsatId;

        public SatisFirsatDetay(int firsatId)
        {
            InitializeComponent();
            this.firsatId = firsatId;
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
                                lblFirsatAdi.Text = reader["firsat_adi"].ToString();
                                lblAciklama.Text = reader["aciklama"].ToString();
                                lblTahminiDeger.Text = reader["tahmini_deger"].ToString();
                                lblTahminiKapanisTarihi.Text = Convert.ToDateTime(reader["tahmini_kapanis_tarihi"]).ToString("dd/MM/yyyy");
                                lblDurum.Text = reader["durum"].ToString();
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
    }
}
