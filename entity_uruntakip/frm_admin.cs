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
    public partial class frm_admin : Form
    {
        public frm_admin()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            entity_urunEntities db = new entity_urunEntities();

            var sorgu = (from x in db.tbl_kullanici where x.kullanici_adi == txt_kullaniciadi.Text && x.kullanici_sifre == txt_sifre.Text select x);
            if (sorgu.Any())
            {
                frm_giris frmgiris = new frm_giris();
                frmgiris.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı Veya Şifre Girişi","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
