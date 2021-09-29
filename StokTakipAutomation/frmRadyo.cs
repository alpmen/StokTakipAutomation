using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakipAutomation
{
    public partial class frmRadyo : Form
    {
        public frmRadyo()
        {
            InitializeComponent();
        }
        public int k = 0;
        string[] kanallar = { "http://stream.34bit.net/ar64.mp3", "http://kralwmp.radyotvonline.com:80/;",
            "http://37.247.98.8/stream/166/","https://radyo.duhnet.tv/slowturk" };
        private void button1_Click(object sender, EventArgs e)
        {
            //For döngüsü ile kanal listeli değiştirilebilecek şekilde tasarlanmıştır.
            for (int i = 0; i < kanallar.Length; i++)
            {
                if (i==k)
                {
                    axWindowsMediaPlayer1.URL = kanallar[k];
                }
            }
            k++;
        }

        
    }
}
