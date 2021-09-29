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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from TblYonetici where Mail=@p1 and sifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();
           //Şartlı yapı ile kullanıcı adı ve şifrenin doğruluğu test edilmiştir.
            if (dr.Read())
            {
                frmMainForm fr = new frmMainForm();
                fr.Show();
            }
            else
            {
                MessageBox.Show("Mail veya şifre hatalı");
            }
            bgl.baglanti().Close();

        }
    }
}
