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
    public partial class frmMüşteriEkle : Form
    {
        public frmMüşteriEkle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=Stok_Takip.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into müşteri(tc,adsoyad,telefon,adres,email) values(@tc,@adsoyad,@telefon,@adres,@email)", baglanti);
            komut.Parameters.AddWithValue("@tc",txtTc.Text);
            komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut.Parameters.AddWithValue("@adres", txtAdres.Text);
            komut.Parameters.AddWithValue("@email", txtEmail.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri kaydı eklendi");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }
    }
}
