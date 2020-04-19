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
    public partial class frm_kategori : Form
    {
        public frm_kategori()
        {
            InitializeComponent();
        }
        public void listele()
        {
            var kategori = db.tbl_category.ToList();
            dataGridView1.DataSource = kategori;
        }
        entity_urunEntities db = new entity_urunEntities();
        private void btn_listele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            tbl_category cat = new tbl_category();
            cat.cad_ad = txt_ad.Text;
            db.tbl_category.Add(cat);
            db.SaveChanges();
            MessageBox.Show("Kayıt Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txt_id.Text);
            var cat = db.tbl_category.Find(x);
            db.tbl_category.Remove(cat);
            db.SaveChanges();
            MessageBox.Show("Kayıt Silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txt_id.Text);
            var cat = db.tbl_category.Find(x);
            cat.cad_ad = txt_ad.Text;
            db.SaveChanges();
            MessageBox.Show("Kayıt Güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
