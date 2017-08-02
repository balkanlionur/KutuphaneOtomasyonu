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

namespace Kütüphane_Takip
{
    public partial class teslim : Form
    {
        public teslim()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            teslim.ActiveForm.Close();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=BALKANLIONUR;Initial Catalog=Kutuphane;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from Emanet where (barkod=@barkod)", baglanti);
            komut.Parameters.AddWithValue("@barkod ", textBox1.Text);
            
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap Teslimi Başarıyla Alındı");
            textBox1.Clear(); textBox2.Clear();

        }

        private void teslim_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}
