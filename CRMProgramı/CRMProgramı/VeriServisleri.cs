using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace CRMProgramı
{

    class VeriServisleri
    {
        public static IDbConnection baglanti;
        private static int sonKayitId;

        #region
        public static string Server;
        public static string Port;
        public static string Database;
        public static string VKullanici;
        public static string VSifre;

        public static int SonKayitId { get => SonKayitId1; set => SonKayitId1 = value; }
        public static int SonKayitId1 { get => sonKayitId; set => sonKayitId = value; }
        #endregion


        public static DataSet goster(string sql, bool DuzenlesinMiSql = false)
        {
            DataSet ds = new DataSet();
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == false)
            {
                MessageBox.Show("İnternet bağlantınız yok, Lütfen internet bağlantınızı kontrol ediniz. Program kapanacaktır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Application.OpenForms["AnaForm"].Close();
            }
            else
            {
                if (baglanti.State != ConnectionState.Closed)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlDataAdapter adaptor = new MySqlDataAdapter(sql, (MySqlConnection)baglanti);
                adaptor.SelectCommand.CommandTimeout = 5000;
                adaptor.Fill(ds, "tablo");
                baglanti.Close();
            }
            return ds;


        }
        public static long calistir(string sql, string kriterNo = "", bool guncelleMiSql = false, bool logKaydiMi = false)
        {
            long sonKayitId1 = 0;
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == false)
            {
                MessageBox.Show("İnternet bağlantınız yok, Lütfen internet bağlantınızı kontrol ediniz. Program kapanacaktır.");
                //Application.OpenForms["AnaForm"].Close();
            }
            else
            {
                MySqlCommand komut = new MySqlCommand(sql, (MySqlConnection)baglanti);
                if (komut.Connection.State == ConnectionState.Open)
                {
                    komut.Connection.Close();
                }
                komut.Connection.Open();
                komut.ExecuteNonQuery();
                sonKayitId1 = Convert.ToInt64(komut.LastInsertedId); // long tipine dönüştürdük
                komut.Connection.Close();
            }
            return sonKayitId1;
        }






    }
}
