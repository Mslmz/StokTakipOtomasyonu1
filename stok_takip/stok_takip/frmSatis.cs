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
    public partial class frmSatis : Form
    {
        public frmSatis()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=Stok_Takip.accdb");
        DataSet daset = new DataSet();
        private void sepetListele()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select *from sepet", baglanti);
            adtr.Fill(daset, "sepet");
            dataGridView1.DataSource = daset.Tables["sepet"];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            baglanti.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            frmMüşteriEkle ekle = new frmMüşteriEkle();
            ekle.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmMüşteriListele listele = new frmMüşteriListele();
            listele.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmÜrünEkle ekle = new frmÜrünEkle();
            ekle.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmKategori kategori = new frmKategori();
            kategori.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMarka marka = new frmMarka();
            marka.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmÜrünListele listele = new frmÜrünListele();
            listele.ShowDialog();
        }
        private void hesapla()
        {
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select sum(toplamfiyati) from sepet", baglanti);
                label9.Text = komut.ExecuteScalar() + "TL";
                baglanti.Close();
            }
            catch (Exception)
            {

            }
        }
        private void frmSatis_Load(object sender, EventArgs e)
        {
            sepetListele();
        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {
            if (txtTc.Text =="")
            {
                txtAdSoyad.Text = "";
                txtTelefon.Text = "";

            }
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select *from müşteri where tc like '"+txtTc.Text+"'", baglanti);
            OleDbDataReader read = komut.ExecuteReader();
            while(read.Read())
            {
                txtAdSoyad.Text = read["adsoyad"].ToString();
                txtTelefon.Text = read["telefon"].ToString();
            }
            baglanti.Close();
        }
        private void Temizle()
        {
            if (txtBarkodNo.Text == "")
            {
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != txtMiktari)
                        {
                            item.Text = "";
                        }
                    }

                }
            }
        }
        private void txtBarkodNo_TextChanged(object sender, EventArgs e)
        {
            Temizle();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select *from urun where barkodno like '" + txtBarkodNo.Text + "'", baglanti);
            OleDbDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtÜrünAdı.Text = read["urunadi"].ToString();
                txtSatışFiyatı.Text = read["satisfiyati"].ToString();
            }
            baglanti.Close();
        }
        bool durum;
        private void barkodkontrol()
        {
            durum = true;
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select *from sepet", baglanti);
            OleDbDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (txtBarkodNo.Text ==read["barkodno"].ToString())
                {
                    durum = false;
                }
            }
            baglanti.Close();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            barkodkontrol();
            if(durum ==true)
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into sepet(tc,adsoyad,telefon,barkodno,urunadi,miktari,satisfiyati,toplamfiyati,tarih) values(@tc,@adsoyad,@telefon,@barkodno,@urunadi,@miktari,@satisfiyati,@toplamfiyati,@tarih)", baglanti);
                komut.Parameters.AddWithValue("@tc", txtTc.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                komut.Parameters.AddWithValue("@barkodno", txtBarkodNo.Text);
                komut.Parameters.AddWithValue("@urunadi", txtÜrünAdı.Text);
                komut.Parameters.AddWithValue("@miktari", int.Parse(txtMiktari.Text));
                komut.Parameters.AddWithValue("@satisfiyati", double.Parse(txtSatışFiyatı.Text));
                komut.Parameters.AddWithValue("@toplamfiyati", double.Parse(txtToplamFiyat.Text));
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            else
            {
                baglanti.Open();
                OleDbCommand komut2 = new OleDbCommand("update sepet set miktari=miktari+'"+int.Parse(txtMiktari.Text)+ "'where barkodno='" + txtBarkodNo.Text + "'", baglanti);
                komut2.ExecuteNonQuery();
                OleDbCommand komut3 = new OleDbCommand("update sepet set toplamfiyati=miktari*satisfiyati where barkodno='"+txtBarkodNo.Text+"'", baglanti);
                komut3.ExecuteNonQuery();
                baglanti.Close();
            }
            txtMiktari.Text = "1";
            daset.Tables["sepet"].Clear();
            sepetListele();
            hesapla();
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    if (item != txtMiktari)
                    {
                        item.Text = "";
                    }
                }

            }
        }

        private void txtMiktari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtToplamFiyat.Text = (double.Parse(txtMiktari.Text) * double.Parse(txtSatışFiyatı.Text)).ToString();
            }
            catch(Exception)
            {
                ;
            }
        }

        private void txtSatışFiyatı_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtToplamFiyat.Text = (double.Parse(txtMiktari.Text) * double.Parse(txtSatışFiyatı.Text)).ToString();
            }
            catch (Exception)
            {
                ;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("delete from sepet where barkodno='"+dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString()+"'",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün sepetten çıkarıldı");
            daset.Tables["sepet"].Clear();
            sepetListele();
            hesapla();
        }

        private void btnSatışİptal_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("delete from sepet", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün sepetten çıkarıldı");
            daset.Tables["sepet"].Clear();
            sepetListele();
            hesapla();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmSatışListele listele = new frmSatışListele();
            listele.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnSatışYap_Click(object sender, EventArgs e)
        {
            for (int i =0; i< dataGridView1.Rows.Count-1; i++)
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into satis(tc,adsoyad,telefon,barkodno,urunadi,miktari,satisfiyati,toplamfiyati,tarih) values(@tc,@adsoyad,@telefon,@barkodno,@urunadi,@miktari,@satisfiyati,@toplamfiyati,@tarih)", baglanti);
                komut.Parameters.AddWithValue("@tc", txtTc.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                komut.Parameters.AddWithValue("@barkodno", dataGridView1.Rows[i].Cells["barkodno"].Value.ToString());
                komut.Parameters.AddWithValue("@urunadi", dataGridView1.Rows[i].Cells["urunadi"].Value.ToString());
                komut.Parameters.AddWithValue("@miktari", int.Parse(dataGridView1.Rows[i].Cells["miktari"].Value.ToString()));
                komut.Parameters.AddWithValue("@satisfiyati", double.Parse(dataGridView1.Rows[i].Cells["satisfiyati"].Value.ToString()));
                komut.Parameters.AddWithValue("@toplamfiyati", double.Parse(dataGridView1.Rows[i].Cells["toplamfiyati"].Value.ToString()));
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                komut.ExecuteNonQuery();
                OleDbCommand komut2 = new OleDbCommand("update urun set miktar=miktar- '" + int.Parse(dataGridView1.Rows[i].Cells["miktari"].Value.ToString()) + "' where barkodno='" + dataGridView1.Rows[i].Cells["barkodno"].Value.ToString() + "'", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            baglanti.Open();
            OleDbCommand komut3 = new OleDbCommand("delete from sepet", baglanti);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["sepet"].Clear();
            sepetListele();
            hesapla();
        }
    }
}
