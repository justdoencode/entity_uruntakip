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
    public partial class frm_urun : Form
    {
        public frm_urun()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        entity_urunEntities db = new entity_urunEntities();
        public void listele()
        {
            dataGridView1.DataSource = (from x in db.tbl_urun select new { x.urun_id, x.urun_ad, x.urun_marka, x.urun_stok, x.urun_fiyat, x.tbl_category.cad_ad,x.urun_durum }).ToList();
        }
        private void btn_listele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            tbl_urun urun = new tbl_urun();
            urun.urun_ad = txt_ad.Text;
            urun.urun_marka = txt_marka.Text;
            urun.urun_stok = short.Parse(txt_stok.Text);
            urun.urun_fiyat = decimal.Parse(txt_fiyat.Text);
            urun.urun_durum = true;
            urun.urun_category = int.Parse(combo_kategori.SelectedValue.ToString());
            db.tbl_urun.Add(urun);
            db.SaveChanges();
            MessageBox.Show("Kayıt Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();

        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txt_id.Text);
            var urun = db.tbl_urun.Find(x);
            db.tbl_urun.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Kayıt Silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txt_id.Text);
            var urun = db.tbl_urun.Find(x);
            urun.urun_ad = txt_ad.Text;
            urun.urun_marka = txt_marka.Text;
            urun.urun_stok = short.Parse(txt_stok.Text);
            db.SaveChanges();
            MessageBox.Show("Kayıt Güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void frm_urun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.tbl_category select new { x.cat_id, x.cad_ad }).ToList();
            combo_kategori.ValueMember = "cat_id";
            combo_kategori.DisplayMember = "cad_ad";
            combo_kategori.DataSource = kategoriler;
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            txt_ad.Clear();
            txt_durum.Clear();
            txt_fiyat.Clear();
            txt_id.Clear();
            txt_marka.Clear();
            txt_stok.Clear();
        }
    }
}
