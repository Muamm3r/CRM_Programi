using System;
using System.Data;
using System.Windows.Forms;
using FastReport;

namespace CRMProgramı
{
    public partial class UserControlYonetim : UserControl
    {
        public UserControlYonetim()
        {
            InitializeComponent();
        }

        private void BtnKullaniciEkle_Click(object sender, EventArgs e)
        {
            KullaniciEkle kullaniciEkleForm = new KullaniciEkle();
            kullaniciEkleForm.ShowDialog();
        }

        private void btnKullanicilar_Click(object sender, EventArgs e)
        {
            KullaniciListesi kullaniciListesiForm = new KullaniciListesi();
            kullaniciListesiForm.ShowDialog();
        }

        private void btnGorev_Click(object sender, EventArgs e)
        {
            Gorevler gorevler = new Gorevler();
            gorevler.ShowDialog();
        }

        private void MusteriRaporu(string dizaynMi)
        {
            FastReport.Report report = new FastReport.Report();
            DataTable dtMusteriler = VeriServisleri.goster("Select * from musteriler").Tables[0];
            report.Load(Application.StartupPath + "\\Rapor\\cariRaporu.frx");
            report.RegisterData(dtMusteriler, "Musteriler");
            if (dizaynMi == "vet")
                report.Design();
            else
                report.Show();
        }       
        private void btnMusteriRaporlari_Click(object sender, EventArgs e)
        {
            MusteriRaporu("Evet");
        }

        private void btnGorevVer_Click(object sender, EventArgs e)
        {
            GorevVer gorevVer = new GorevVer();
            gorevVer.ShowDialog();
        }

    }
}
