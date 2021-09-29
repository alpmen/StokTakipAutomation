using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace StokTakipAutomation
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from TblUrun", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToLongDateString() + " "+ DateTime.Now.Hour.ToString()+":" + DateTime.Now.Minute.ToString();
            label2.Text = time;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmUrunİslemleri fr = new frmUrunİslemleri();
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmKategori_islemleri fr = new frmKategori_islemleri();
            fr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmRadyo fr = new frmRadyo();
            fr.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmfirma_islemleri fr = new frmfirma_islemleri();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmYonetici_islemleri fr = new frmYonetici_islemleri();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAlSat fr = new frmAlSat();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmKasa fr = new frmKasa();
            fr.Show();
        }
    }
}
