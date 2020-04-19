using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entity_uruntakip
{
    public partial class frm_istatistik : Form
    {
        public frm_istatistik()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        entity_urunEntities db = new entity_urunEntities();
        private void frm_istatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.tbl_category.Count().ToString();
            label3.Text = db.tbl_urun.Count().ToString();
            label5.Text = db.tbl_musteri.Count(x => x.musteri_durum == true).ToString();
            label7.Text = db.tbl_musteri.Count(x => x.musteri_durum == false).ToString();
            label11.Text = db.tbl_urun.Sum(x => x.urun_stok).ToString();
            label19.Text = db.tbl_satis.Sum(x => x.satis_fiyat).ToString();
            label13.Text = (from x in db.tbl_urun orderby x.urun_fiyat descending select x.urun_ad).FirstOrDefault();
            label15.Text = (from x in db.tbl_urun orderby x.urun_fiyat ascending select x.urun_ad).FirstOrDefault();
            label9.Text = db.tbl_urun.Count(x => x.urun_category == 1).ToString();
            label23.Text = db.tbl_urun.Count(x => x.urun_ad == "Buzdolabı").ToString();
            label17.Text = (from x in db.tbl_musteri select x.musteri_sehir).Distinct().Count().ToString();
            label21.Text = db.markagetir().FirstOrDefault();
        }
    }
}
