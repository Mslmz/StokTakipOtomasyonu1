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
    public partial class frmKategori : Form
    {
        public frmKategori()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti= new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=Stok_Takip.accdb");
        bool durum;
        private void kategorikontrol()
        {
            durum = true;
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select *from kategoribilgileri", baglanti);
            OleDbDataReader read = komut.ExecuteReader();
            while(read.Read())
            {
                if(textBox1.Text==read["kategori"].ToString() || textBox1.Text=="")
                {
                    durum = false;
                }
            }
            baglanti.Close();
        }
        private void frmKategori_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kategorikontrol();
            if(durum ==true)
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into kategoribilgileri(kategori) values('" + textBox1.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kategori eklendi");
            }
            else
            {
                MessageBox.Show("Böyle bir kategori var", "Uyarı");
            }
            textBox1.Text = "";
        }
    }
}
