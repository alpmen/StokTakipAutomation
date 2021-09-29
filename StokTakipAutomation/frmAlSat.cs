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
    public partial class frmAlSat : Form
    {
        public frmAlSat()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();
        //Listele
        public void listele()
        {
            SqlCommand komut = new SqlCommand("select * from TblUrun", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }
        //Firmaları combobxa al

        public void firmaDoldur()
        {
            SqlCommand komut = new SqlCommand("select * from TblFirmalar", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader(); 
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[1].ToString());
            }
            bgl.baglanti().Close();
        }

        //Kategorileri comboboxa al
        public void KategoriDoldur()
        {
            SqlCommand komut = new SqlCommand("select * from TblKategori", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[1].ToString());
            }
            bgl.baglanti().Close();
        }



        private void frmAlSat_Load(object sender, EventArgs e)
        {
            listele();

            //Firmaları al
            firmaDoldur();
            //Kategori al
            KategoriDoldur();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = dataGridView1.SelectedCells[0].RowIndex;
            textBox11.Text = dataGridView1.Rows[x].Cells[0].Value.ToString();
            textBox10.Text = dataGridView1.Rows[x].Cells[1].Value.ToString();
            textBox9.Text = dataGridView1.Rows[x].Cells[2].Value.ToString();
            textBox8.Text = dataGridView1.Rows[x].Cells[3].Value.ToString();
            textBox7.Text = dataGridView1.Rows[x].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[x].Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox9.Text!="" && textBox8.Text!="")
            {
                double adet = Convert.ToDouble(textBox9.Text);
                double fiyat = Convert.ToDouble(textBox8.Text);
                double total = adet * fiyat;
                label8.Text = total.ToString();
            }

            

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double gelir=Convert.ToDouble(label8.Text);
           
            
             
           //SqlCommand komut = new SqlCommand("select * from TblKasa", bgl.baglanti());
           // SqlDataReader dr = komut.ExecuteReader();
           // while (dr.Read())
           // {
           //     gelir =Convert.ToDouble(dr[0].ToString());
           //     gider =Convert.ToDouble(dr[1].ToString());

           // }

           // gelir = gelir + Convert.ToDouble(label8.Text);

            if (label8.Text!="-" && textBox11.Text!="")
            {
                
                SqlCommand komut2 = new SqlCommand("insert into TblKasa (ÜCRET,DURUM) values (@p1,@p2)",bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", gelir);
                komut2.Parameters.AddWithValue("@p2", 1);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Satış Onaylandı");

                SqlCommand komut3 = new SqlCommand("delete from TblUrun where ID=@k1", bgl.baglanti());
                komut3.Parameters.AddWithValue("@k1", textBox11.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();
                listele();
                textBox11.Text = "";
                textBox10.Text = "";
                textBox9.Text = "";
                textBox8.Text = "";
                textBox7.Text = "";
                textBox6.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text!="" && textBox3.Text!="")
            {
                double adet = Convert.ToDouble(textBox2.Text);
                double fiyat = Convert.ToDouble(textBox3.Text);
                double total = adet * fiyat;
                label7.Text = total.ToString();
            }
            else
            {
                MessageBox.Show("Lütfen ücret ve adet bilgisi giriniz");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double ucret = Convert.ToDouble(label7.Text);
            if (textBox1.Text!="" && textBox2.Text != "" && textBox2.Text != "" && comboBox1.Text!="" && comboBox2.Text!="")
            {
                SqlCommand komut = new SqlCommand("insert into TblKAsa (Ücret,Durum) values (@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", ucret);
                komut.Parameters.AddWithValue("@p2", 0);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Satın Alma Başarılı");

                SqlCommand komut2 = new SqlCommand("insert into TblUrun (ÜrünAdi,Adet,Fiyat,YollanacakFirma,Kategori) values(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", textBox1.Text);
                komut2.Parameters.AddWithValue("@p2", textBox2.Text);
                komut2.Parameters.AddWithValue("@p3", textBox3.Text);
                komut2.Parameters.AddWithValue("@p4", comboBox1.Text);
                komut2.Parameters.AddWithValue("@p5", comboBox2.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                listele();
                

            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun");
            }
        }
    }
}
