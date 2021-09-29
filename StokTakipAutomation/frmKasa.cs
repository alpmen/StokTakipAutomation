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
    public partial class frmKasa : Form
    {
        public frmKasa()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();

        public double gelir = 0;
        public double gider=0;
        public double netKazanc=0;
        private void frmKasa_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("select ücret from TblKasa where Durum=1", bgl.baglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    gelir = gelir + Convert.ToDouble(dr[0].ToString());
                }
            }
            catch (Exception)
            {

                gelir = 0;
            }


            try
            {
                SqlCommand komut2 = new SqlCommand("select ücret from TblKasa where Durum=0", bgl.baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();
                //do-while döngüsü
                do
                {
                    gider = gider + Convert.ToDouble(dr2[0].ToString());
                } while (dr2.Read());
               
            }
            catch (Exception)
            {

                gider = 0 ;
            }

            netKazanc = gelir - gider;
            label5.Text = gelir + " ₺";
            label6.Text = gider + " ₺";
            label7.Text = netKazanc + " ₺";













        }
    }
}
