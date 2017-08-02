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
    public partial class okuyucu_kayit : Form
    {
        public okuyucu_kayit()
        {
            InitializeComponent();
        }
        int tc;
        SqlConnection baglanti = new SqlConnection("Data Source = BALKANLIONUR; Initial Catalog = Kutuphane; Integrated Security = True");


        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into Kişi(tc_no,ad,soyad,dogum_yeri,dogum_tarihi,tel,eposta,uyelik_tarih,cinsiyet,adres) values(@tc,@adi,@soyadi,@dy,@dt,@tel,@eposta,@ut,@cins,@adres)", baglanti);
            komut.Parameters.AddWithValue("@tc",  Convert.ToInt64(textBox1.Text));
            komut.Parameters.AddWithValue("@adi", textBox2.Text);
            komut.Parameters.AddWithValue("@soyadi", textBox3.Text);
            komut.Parameters.AddWithValue("@dy", textBox4.Text);
            komut.Parameters.AddWithValue("@dt", DateTime.Parse(dateTimePicker1.Text));
            komut.Parameters.AddWithValue("@tel",Convert.ToInt64(textBox5.Text));
            komut.Parameters.AddWithValue("@eposta", textBox6.Text);
            komut.Parameters.AddWithValue("@ut", DateTime.Parse(dateTimePicker2.Text));
            komut.Parameters.AddWithValue("@cins", comboBox1.Text);
            komut.Parameters.AddWithValue("@adres",richTextBox1.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Yeni Okuyucu Başarıyla Eklendi");
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from Kişi where tc_no=@tc", baglanti);
            komut.Parameters.AddWithValue("@tc", textBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Başarıyla Silindi");
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear();
            textBox4.Clear(); textBox5.Clear(); textBox6.Clear();


            comboBox1.Text = "";
            richTextBox1.Clear();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear();
            textBox4.Clear(); textBox5.Clear(); textBox6.Clear();
            

            comboBox1.Text = "";
            richTextBox1.Clear();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            okuyucu_kayit.ActiveForm.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(" update Kişi set tc_no='" + textBox1.Text + "',ad='" + textBox2.Text + "',soyad='" + textBox3.Text + "',dogum_yeri='" + textBox4.Text + "',dogum_tarihi='" + dateTimePicker1.Value + "',tel='" + textBox5.Text + "',eposta='" + textBox6.Text + "',uyelik_tarih='" + dateTimePicker2.Value + "', cinsiyet='" + comboBox1.Text + "', adres='" + richTextBox1.Text + "' where tc_no='" + tc + "' ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla Güncellendi");
        }

        private void okuyucu_kayit_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (textBox1.Text != "")
            {
                tc = Convert.ToInt32(textBox1.Text);
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
