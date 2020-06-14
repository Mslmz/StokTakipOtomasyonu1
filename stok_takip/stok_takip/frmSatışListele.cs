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
    public partial class frmSatışListele : Form
    {
        public frmSatışListele()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=Stok_Takip.accdb");
        DataSet daset = new DataSet();
        private void satışlistele()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select *from satis", baglanti);
            adtr.Fill(daset, "sepet");
            dataGridView1.DataSource = daset.Tables["sepet"];
            baglanti.Close();
        }
        private void frmSatışListele_Load(object sender, EventArgs e)
        {
            
        }
    }
}
