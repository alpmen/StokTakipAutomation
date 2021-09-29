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
    public partial class frmUrunİslemleri : Form
    {
        public frmUrunİslemleri()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();
        //Listeleme işlemi fonksiyon içine tanımlanmıştır.
        public void listele()
        {
            SqlCommand komut = new SqlCommand("select * from TblUrun", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        //Kutuları temizleme fonksiyonu 
        public void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }
        private void frmUrunİslemleri_Load(object sender, EventArgs e)
        {
            listele();


            //firmaların combobox1'e listelenmesi
            SqlCommand komut2 = new SqlCommand("select * from TblFirmalar", bgl.baglanti());
            SqlDataReader dr = komut2.ExecuteReader();
            //While ile dr nesnesi veriyi okuduğu sürece bu veriler combobox1'e eklenecek şekilde tasarlanmıştır.
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[1].ToString());
            }
            bgl.baglanti().Close();


            //Kategorilerin combobox2'ye listelenmesi
            SqlCommand komut3 = new SqlCommand("select * from TblKategori", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                comboBox2.Items.Add(dr3[1].ToString());
            }
            bgl.baglanti().Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[x].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[x].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[x].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[x].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[x].Cells[4].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[x].Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TblUrun (Ürünadi,Adet,Fiyat,YollanacakFirma,Kategori) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.Parameters.AddWithValue("@p2", textBox3.Text);
            komut.Parameters.AddWithValue("@p3", textBox4.Text);
            komut.Parameters.AddWithValue("@p4", comboBox1.Text);
            komut.Parameters.AddWithValue("@p5", comboBox2.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ekleme işlemi başarılı");
            listele();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                SqlCommand komut = new SqlCommand("delete from TblUrun where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Silme işlemi başarılı");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //bool tipinde isTure değişkeni oluşturuldu ve ID değerinin boş olup olmadığı burada kontrol edildi.
            bool isTrue = true;
            if (textBox1.Text != "")
            {
                isTrue = true;
            }
            else
            {
                isTrue = false;
            }
            
            if (isTrue)
            {
                SqlCommand komut = new SqlCommand("update TblUrun set ÜrünAdi=@p1, Adet=@p2, Fiyat=@p3,YollanacakFirma=@p4,Kategori=@p5 where ID=@p6", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox2.Text);
                komut.Parameters.AddWithValue("@p2", textBox3.Text);
                komut.Parameters.AddWithValue("@p3", textBox4.Text);
                komut.Parameters.AddWithValue("@p4", comboBox1.Text);
                komut.Parameters.AddWithValue("@p5", comboBox2.Text);
                komut.Parameters.AddWithValue("@p6", textBox1.Text);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncelleme işlemi Başarılı");
            }
        }
    }
}
