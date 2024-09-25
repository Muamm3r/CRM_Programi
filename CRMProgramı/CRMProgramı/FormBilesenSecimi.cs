using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using CRMProgramı.Controls;
using MySqlConnector;

namespace CRMProgramı
{
    public partial class FormBilesenSecimi : MetroFramework.Forms.MetroForm
    {
        private int kullaniciId;
        private AnaSayfa anaSayfa; // AnaSayfa formu referansı

        public FormBilesenSecimi(int kullaniciId, AnaSayfa anaSayfa)
        {
            InitializeComponent();
            this.kullaniciId = kullaniciId;
            this.anaSayfa = anaSayfa; // AnaSayfa referansını atama
            LoadSelections();
        }

        private void LoadSelections()
        {
            try
            {
                using (var connection = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True"))
                {
                    connection.Open();
                    string query = "SELECT TakvimSecili, GorevlerSecili, MusteriSayilariSecili, NotSecili FROM kullanicilar WHERE KullaniciID = @KullaniciID";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                checkBoxTakvim.Checked = Convert.ToBoolean(reader["TakvimSecili"]);
                                checkBoxGorevler.Checked = Convert.ToBoolean(reader["GorevlerSecili"]);
                                checkBoxMusteriSayilari.Checked = Convert.ToBoolean(reader["MusteriSayilariSecili"]);
                                checkBoxNot.Checked = Convert.ToBoolean(reader["NotSecili"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True"))
                {
                    connection.Open();
                    string query = "UPDATE kullanicilar SET TakvimSecili = @TakvimSecili, GorevlerSecili = @GorevlerSecili, MusteriSayilariSecili = @MusteriSayilariSecili, NotSecili = @NotSecili WHERE KullaniciID = @KullaniciID";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TakvimSecili", checkBoxTakvim.Checked);
                        command.Parameters.AddWithValue("@GorevlerSecili", checkBoxGorevler.Checked);
                        command.Parameters.AddWithValue("@MusteriSayilariSecili", checkBoxMusteriSayilari.Checked);
                        command.Parameters.AddWithValue("@NotSecili", checkBoxNot.Checked);
                        command.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Seçimler kaydedildi.");

                // AnaSayfa formundaki paneli güncelle
                anaSayfa.LoadUserSelections(); // Bu metod zaten UserControl'leri ekleyecek

                // Kullanıcı seçimlerine göre UserControl'leri tekrar eklemeye gerek yok
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
        }


    }
}
