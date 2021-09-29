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
    public partial class frmfirma_islemleri : Form
    {
        public frmfirma_islemleri()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();
        //listeleme fonksiyonu
        public void listele()
        {
            SqlCommand komut = new SqlCommand("select * from TblFirmalar", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        public void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void frmfirma_islemleri_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TblFirmalar (FirmaAdi) values (@p1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ekleme işlemi başarılı");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                SqlCommand komut = new SqlCommand("delete from TblFirmalar where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Silme işlemi başarılı");
            }
            else
            {
                MessageBox.Show("Lütfen bir firma seçin");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlCommand komut = new SqlCommand("update TblFirmalar set FirmaAdi=@p2 where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncelleme işlemi başarılı");
            }
            else
            {
                MessageBox.Show("Lütfen bir firma seçin");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[x].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[x].Cells[1].Value.ToString();
        }
    }
}
