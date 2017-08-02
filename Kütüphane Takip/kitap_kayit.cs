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
    public partial class kitap_kayit : Form
    {
        public kitap_kayit()
        {
            InitializeComponent();
        }
        int barkod;

        SqlConnection baglanti = new SqlConnection("Data Source = BALKANLIONUR; Initial Catalog = Kutuphane; Integrated Security = True");

        private void button1_Click(object sender, EventArgs e)
        {
           
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into Kitap(barkod_no,kitap_adi,yazar_adi,yayin_evi,kitap_turu,kitap_konu,baski_yeri,baski_sayisi,baskı_tarihi,stok) values (@barkod,@kitapadi,@yazaradi,@yayinevi,@kitapturu,@kitapkonu,@baskıyeri,@baskısayısı,@baskıtarihi,@stok)", baglanti);
            komut.Parameters.AddWithValue("@barkod", int.Parse(textBox1.Text));
            komut.Parameters.AddWithValue("@kitapadi", textBox2.Text);
            komut.Parameters.AddWithValue("@yazaradi", textBox3.Text);
            komut.Parameters.AddWithValue("@yayinevi", textBox4.Text);
            komut.Parameters.AddWithValue("@kitapturu", textBox5.Text);
            komut.Parameters.AddWithValue("@kitapkonu", richTextBox1.Text);
            komut.Parameters.AddWithValue("@baskıyeri", textBox6.Text);
            komut.Parameters.AddWithValue("@baskısayısı", int.Parse(textBox7.Text));
            komut.Parameters.AddWithValue("@baskıtarihi", DateTime.Parse(dateTimePicker1.Text));
            komut.Parameters.AddWithValue("@stok", int.Parse(textBox8.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Yeni Kitap Başarıyla Eklendi");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(" update Kitap set barkod_no='" + textBox1.Text + "',kitap_adi='" + textBox2.Text + "',yazar_adi='" + textBox3.Text + "',yayin_evi='" + textBox4.Text + "',kitap_turu='" + textBox5.Text + "',kitap_konu='" + richTextBox1.Text + "',baski_yeri='" + textBox6.Text + "',baski_sayisi='" + textBox7.Text + "',baskı_tarihi='" + dateTimePicker1.Value + "', stok='" + textBox8.Text + "' where barkod_no='"+barkod+"' ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla Güncellendi");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from Kitap where barkod_no=@barkod", baglanti);
            komut.Parameters.AddWithValue("@barkod ", textBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kayıt Başarıyla Silindi");
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear();
            textBox4.Clear(); textBox5.Clear(); textBox6.Clear();
            textBox7.Clear(); textBox8.Clear();
            
            richTextBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear();
            textBox4.Clear(); textBox5.Clear(); textBox6.Clear();
            textBox7.Clear(); textBox8.Clear(); 

            richTextBox1.Clear();
        }

       

        private void button5_Click(object sender, EventArgs e)
        {
            kitap_kayit.ActiveForm.Close();
        }

        private void kitap_kayit_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (textBox1.Text != "")
            {
                barkod = Convert.ToInt32(textBox1.Text);
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
    }
}
