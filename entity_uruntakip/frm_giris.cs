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
    public partial class frm_giris : Form
    {
        public frm_giris()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_kategori frmkategori = new frm_kategori();
            frmkategori.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_urun frmurun = new frm_urun();
            frmurun.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_istatistik frmistatistik = new frm_istatistik();
            frmistatistik.Show();
        }
    }
}
