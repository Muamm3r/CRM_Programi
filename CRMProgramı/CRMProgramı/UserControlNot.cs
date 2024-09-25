using System;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı.Controls
{
    public partial class UserControlNot : UserControl
    {
        private int kullaniciId;

        public UserControlNot(int kullaniciId)
        {
            InitializeComponent();
            this.kullaniciId = kullaniciId;
            LoadNot(); // Kullanıcının mevcut notunu yükler
        }

        private void LoadNot()
        {
            try
            {
                using (var connection = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True"))
                {
                    connection.Open();
                    string query = "SELECT `not` FROM kullanicilar WHERE KullaniciID = @KullaniciID";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNot.Text = reader["not"].ToString(); // Mevcut notu yükler
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

        private void btnNotKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new MySqlConnection($"Server={VeriServisleri.Server};Port={VeriServisleri.Port};Database={VeriServisleri.Database};Uid={VeriServisleri.VKullanici};Pwd={VeriServisleri.VSifre};AllowUserVariables=True;UseCompression=True;Character Set=utf8;Convert Zero Datetime=True"))
                {
                    connection.Open();
                    string query = "UPDATE kullanicilar SET `not` = @Not WHERE KullaniciID = @KullaniciID";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Not", txtNot.Text);
                        command.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Not kaydedildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
        }
    }
}
