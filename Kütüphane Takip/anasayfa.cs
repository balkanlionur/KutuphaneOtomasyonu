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
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
            
        }

        string liste;
        string tarih;
        string barkod, kitapadi, yazaradi, yayinevi, kitapturu, kitapkonu, baskiyeri, baskisayi, stok;
        DateTime baskitarih;

        string tc, adi, soyadi, dyeri, telefon, eposta, cinsiyet, adres;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void anasayfa_Load(object sender, EventArgs e)
        {
          dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

     

        DateTime dtarihi, uyetarih;

        SqlConnection baglantı = new SqlConnection("Data Source = BALKANLIONUR; Initial Catalog = Kutuphane; Integrated Security = True");

        public void kitapverilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler,baglantı);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            

        }
        public void okuyucuverilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglantı);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
 
        }

        public void emanetverilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglantı);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }
        public void tarihigecenlerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglantı);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kitapverilerigoster("Select * From Kitap");
            liste = "kitap";
            dataGridView1.Columns[0].HeaderText = "Barkod No";
            dataGridView1.Columns[1].HeaderText = "Kitap Adı";
            dataGridView1.Columns[2].HeaderText = "Yazar Adı";
            dataGridView1.Columns[3].HeaderText = "Yayın Evi";
            dataGridView1.Columns[4].HeaderText = "Tür";
            dataGridView1.Columns[5].HeaderText = "Konu";
            dataGridView1.Columns[6].HeaderText = "Baskı Yeri";
            dataGridView1.Columns[7].HeaderText = "Baskı Sayısı";
            dataGridView1.Columns[8].HeaderText = "Baskı Tarihi";
            dataGridView1.Columns[9].HeaderText = "Stok";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            okuyucuverilerigoster("Select * From Kişi");
            liste = "okuyucu";
            dataGridView1.Columns[0].HeaderText = "Tc No";
            dataGridView1.Columns[1].HeaderText = "İsim";
            dataGridView1.Columns[2].HeaderText = "Soyisim";
            dataGridView1.Columns[3].HeaderText = "Dogum Yeri";
            dataGridView1.Columns[4].HeaderText = "Dogum Tarihi";
            dataGridView1.Columns[5].HeaderText = "Telefon";
            dataGridView1.Columns[6].HeaderText = "Eposta";
            dataGridView1.Columns[7].HeaderText = "Üyelik Tarihi";
            dataGridView1.Columns[8].HeaderText = "Cinsiyet";
            dataGridView1.Columns[9].HeaderText = "Adres";

        }
        private void button3_Click(object sender, EventArgs e)
        {
           // select kitapad from Kitap union select kitapadi from Kitap2
            kitapverilerigoster("Select barkod,kitap_adi,yazar_adi,tc_no,ad,soyad,tel,baslangic,bitis,adres From Emanet,Kitap,Kişi where  Kişi.tc_no=Emanet.tc and Kitap.barkod_no=Emanet.barkod");
            liste = "emanet";
            dataGridView1.Columns[0].HeaderText = "Barkod No";
            dataGridView1.Columns[1].HeaderText = "Kitap Adı";
            dataGridView1.Columns[2].HeaderText = "Yazar Adı";
            dataGridView1.Columns[3].HeaderText = "Tc No";
            dataGridView1.Columns[4].HeaderText = "İsim";
            dataGridView1.Columns[5].HeaderText = "Soyisim";
            dataGridView1.Columns[6].HeaderText = "Telefon";
            dataGridView1.Columns[7].HeaderText = "Emanet Tarihi";
            dataGridView1.Columns[8].HeaderText = "Bitiş Tarihi";
            dataGridView1.Columns[9].HeaderText = "Adres";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            tarih = DateTime.Now.ToShortDateString();
           
            tarihigecenlerigoster("Select barkod,kitap_adi,yazar_adi,tc_no,ad,soyad,tel,baslangic,bitis,adres From Emanet,Kitap,Kişi where  Kişi.tc_no=Emanet.tc and Kitap.barkod_no=Emanet.barkod and Emanet.bitis<'" + tarih+"' ");
            liste = "kitap";
            dataGridView1.Columns[0].HeaderText = "Barkod No";
            dataGridView1.Columns[1].HeaderText = "Kitap Adı";
            dataGridView1.Columns[2].HeaderText = "Yazar Adı";
            dataGridView1.Columns[3].HeaderText = "TC Numarasi";
            dataGridView1.Columns[4].HeaderText = "Ad";
            dataGridView1.Columns[5].HeaderText = "Soyad";
            dataGridView1.Columns[6].HeaderText = "Telefon";
            dataGridView1.Columns[7].HeaderText = "Başlangıç";
            dataGridView1.Columns[8].HeaderText = "Bitiş Tarihi";
            dataGridView1.Columns[9].HeaderText = "Adres";

        }
        private void button4_Click(object sender, EventArgs e)
        {

            emanet form = new emanet();
            form.textBox1.Text = textBox1.Text;
            form.textBox2.Text = textBox3.Text;
            form.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            teslim form = new teslim();
            form.textBox1.Text = textBox1.Text;
            form.textBox2.Text = textBox3.Text;
            form.Show();
        }
        

        private void button6_Click(object sender, EventArgs e)
        {
            kitap_kayit frm = new kitap_kayit();
            frm.Show();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            okuyucu_kayit frm = new okuyucu_kayit();
            frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked)
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("Select * from Kitap where kitap_adi+yazar_adi+yayin_evi+kitap_turu+baski_yeri like '%" + textBox5.Text + "%'", baglantı);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].HeaderText = "Barkod No";
                dataGridView1.Columns[1].HeaderText = "Kitap Adı";
                dataGridView1.Columns[2].HeaderText = "Yazar Adı";
                dataGridView1.Columns[3].HeaderText = "Yayın Evi";
                dataGridView1.Columns[4].HeaderText = "Tür";
                dataGridView1.Columns[5].HeaderText = "Konu";
                dataGridView1.Columns[6].HeaderText = "Baskı Yeri";
                dataGridView1.Columns[7].HeaderText = "Baskı Sayısı";
                dataGridView1.Columns[8].HeaderText = "Baskı Tarihi";
                dataGridView1.Columns[9].HeaderText = "Stok";
                baglantı.Close();
            }

            if (radioButton2.Checked)
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("Select * from Kişi where ad+soyad+dogum_yeri+cinsiyet like '%" + textBox5.Text + "%'", baglantı);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].HeaderText = "Tc No";
                dataGridView1.Columns[1].HeaderText = "İsim";
                dataGridView1.Columns[2].HeaderText = "Soyisim";
                dataGridView1.Columns[3].HeaderText = "Dogum Yeri";
                dataGridView1.Columns[4].HeaderText = "Dogum Tarihi";
                dataGridView1.Columns[5].HeaderText = "Telefon";
                dataGridView1.Columns[6].HeaderText = "Eposta";
                dataGridView1.Columns[7].HeaderText = "Üyelik Tarihi";
                dataGridView1.Columns[8].HeaderText = "Cinsiyet";
                dataGridView1.Columns[9].HeaderText = "Adres";
                baglantı.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (liste == "kitap")
            {
                int secili = dataGridView1.SelectedCells[0].RowIndex;
                 barkod = dataGridView1.Rows[secili].Cells[0].Value.ToString();
                 kitapadi = dataGridView1.Rows[secili].Cells[1].Value.ToString();

                textBox1.Text = barkod;
                textBox2.Text = kitapadi;
            }
            if(liste == "okuyucu")
            {
                int secili = dataGridView1.SelectedCells[0].RowIndex;
                 tc = dataGridView1.Rows[secili].Cells[0].Value.ToString();
                 adi = dataGridView1.Rows[secili].Cells[1].Value.ToString();

                textBox3.Text = tc;
                textBox4.Text = adi;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (liste == "kitap")
            {
                int secili = dataGridView1.SelectedCells[0].RowIndex;
                 barkod = dataGridView1.Rows[secili].Cells[0].Value.ToString();
                 kitapadi = dataGridView1.Rows[secili].Cells[1].Value.ToString();
                 yazaradi = dataGridView1.Rows[secili].Cells[2].Value.ToString();
                 yayinevi = dataGridView1.Rows[secili].Cells[3].Value.ToString();
                 kitapturu = dataGridView1.Rows[secili].Cells[4].Value.ToString();
                 kitapkonu = dataGridView1.Rows[secili].Cells[5].Value.ToString();
                 baskiyeri = dataGridView1.Rows[secili].Cells[6].Value.ToString();
                 baskisayi = dataGridView1.Rows[secili].Cells[7].Value.ToString();
                 baskitarih =DateTime.Parse(dataGridView1.Rows[secili].Cells[8].Value.ToString());
                 stok = dataGridView1.Rows[secili].Cells[9].Value.ToString();

                kitap_kayit form = new kitap_kayit();
                form.textBox1.Text = barkod;
                form.textBox2.Text = kitapadi;
                form.textBox3.Text = yazaradi;
                form.textBox4.Text = yayinevi;
                form.textBox5.Text = kitapturu;
                form.richTextBox1.Text = kitapkonu;
                form.textBox6.Text = baskiyeri;
                form.textBox7.Text = baskisayi;
                form.dateTimePicker1.Value = baskitarih;
                form.textBox8.Text = stok;

                form.Show();
                
            }
            if (liste == "okuyucu")
            {
                int secili = dataGridView1.SelectedCells[0].RowIndex;
                 tc = dataGridView1.Rows[secili].Cells[0].Value.ToString();
                 adi = dataGridView1.Rows[secili].Cells[1].Value.ToString();
                 soyadi = dataGridView1.Rows[secili].Cells[2].Value.ToString();
                 dyeri = dataGridView1.Rows[secili].Cells[3].Value.ToString();
                 dtarihi = DateTime.Parse(dataGridView1.Rows[secili].Cells[4].Value.ToString());
                 telefon = dataGridView1.Rows[secili].Cells[5].Value.ToString();
                 eposta = dataGridView1.Rows[secili].Cells[6].Value.ToString();
                 uyetarih = DateTime.Parse(dataGridView1.Rows[secili].Cells[7].Value.ToString());
                 cinsiyet = dataGridView1.Rows[secili].Cells[8].Value.ToString();
                 adres = dataGridView1.Rows[secili].Cells[9].Value.ToString();

                okuyucu_kayit form = new okuyucu_kayit();
                form.textBox1.Text = tc;
                form.textBox2.Text = adi;
                form.textBox3.Text = soyadi;
                form.textBox4.Text = dyeri;
                form.dateTimePicker1.Value = dtarihi;
                form.textBox5.Text = telefon;
                form.textBox6.Text = eposta;
                form.dateTimePicker2.Value = uyetarih;
                form.comboBox1.Text = cinsiyet;
                form.richTextBox1.Text = adres;

                form.Show();

            }

            if(liste == "emanet")
            {
                int secili = dataGridView1.SelectedCells[0].RowIndex;
                barkod = dataGridView1.Rows[secili].Cells[0].Value.ToString();
                tc = dataGridView1.Rows[secili].Cells[1].Value.ToString();
                teslim form = new teslim();
                form.textBox1.Text = barkod;
                form.textBox2.Text = tc;
                form.Show();
            }

            
        }

        

        
    }
}
