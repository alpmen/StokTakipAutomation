using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace StokTakipAutomation
{
    class sqlBaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection
               ("Data Source=DESKTOP-38F6FLL\\MSSQLSERVER2014;Initial Catalog=StokTakip;Integrated Security=True");
            baglan.Open();
            return baglan;
        }


    }
}
