using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace stok_takip
{
    public partial class frmÜrünEkle : Form
    {
        public frmÜrünEkle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=Stok_Takip.accdb");
        bool durum;
        private void barkodkontrol()
        {
            durum = true;
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select *from urun", baglanti);
            OleDbDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (txtBarkodNo.Text==read["barkodno"].ToString()|| txtBarkodNo.Text =="")
                {
                    durum = false;
                }
            }
            baglanti.Close();
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private void kategorigetir()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select *from kategoribilgileri", baglanti);
            OleDbDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboKategori.Items.Add(read["kategori"].ToString());
            }
            baglanti.Close();
        }
        private void frmÜrünEkle_Load(object sender, EventArgs e)
        {
            kategorigetir();
        }

        private void comboKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboMarka.Items.Clear();
            comboMarka.Text = "";
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select kategori,marka from markabilgileri where kategori='"+comboKategori.SelectedItem+"'", baglanti);
            OleDbDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboMarka.Items.Add(read["marka"].ToString());
            }
            baglanti.Close();
        }

        private void btnYeniEkle_Click(object sender, EventArgs e)
        {
            barkodkontrol();
            if(durum ==true)
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into urun(barkodno,kategori,marka,urunadi,miktar,alisfiyati,satisfiyati,tarih) values(@barkodno,@kategori,@marka,@urunadi,@miktar,@alisfiyati,@satisfiyati,@tarih)", baglanti);
                komut.Parameters.AddWithValue("@barkodno", txtBarkodNo.Text);
                komut.Parameters.AddWithValue("@kategori", comboKategori.Text);
                komut.Parameters.AddWithValue("@marka", comboMarka.Text);
                komut.Parameters.AddWithValue("@urunadi", txtÜrünAdı.Text);
                komut.Parameters.AddWithValue("@miktar", int.Parse(txtMiktarı.Text));
                komut.Parameters.AddWithValue("@alisfiyati", double.Parse(txtAlışFiyatı.Text));
                komut.Parameters.AddWithValue("@satisfiyati", double.Parse(txtSatışFiyatı.Text));
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());

                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ürün eklendi");
            }
            else
            {
                MessageBox.Show("Böyle bir barkodno var!");
            }
            
            comboMarka.Items.Clear();
            foreach(Control item in groupBox1.Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }

        private void BarkodNotxt_TextChanged(object sender, EventArgs e)
        {
            if(BarkodNotxt.Text =="")
            {
                lblMiktari.Text = "";
                foreach(Control item in groupBox2.Controls)
                {
                    if(item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select *from urun where barkodno like'" + BarkodNotxt.Text + "'", baglanti);
            OleDbDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                Kategoritxt.Text = read["kategori"].ToString();
                Markatxt.Text = read["marka"].ToString();
                ÜrünAdıtxt.Text = read["urunadi"].ToString();
                lblMiktari.Text = read["miktar"].ToString();
                AlışFiyatıtxt.Text = read["alisfiyati"].ToString();
                SatışFiyatıtxt.Text = read["satisfiyati"].ToString();
            }
            baglanti.Close();
        }

        private void btnVarOlanaEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("update urun set miktar=miktar +'"+int.Parse(Miktarıtxt.Text)+"' where barkodno='"+BarkodNotxt.Text+"'",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            MessageBox.Show("Var olan ürüne ekleme yapıldı!");
        }
    }
}
