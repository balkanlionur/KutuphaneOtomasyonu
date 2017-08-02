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
    public partial class emanet : Form
    {
        public emanet()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = BALKANLIONUR; Initial Catalog = Kutuphane; Integrated Security = True");


        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            

            SqlCommand komut = new SqlCommand("Insert into Emanet(barkod,tc,baslangic,bitis) values (@barkod,@tc,@basla,@bitis)", baglanti);
            komut.Parameters.AddWithValue("@barkod",Convert.ToInt64(textBox1.Text));
            komut.Parameters.AddWithValue("@tc", Convert.ToInt32(textBox2.Text));
            komut.Parameters.AddWithValue("@basla", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@bitis", dateTimePicker2.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Başarıyla Kaydedildi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            emanet.ActiveForm.Close();
        }

        private void emanet_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}
