namespace stok_takip
{
    partial class frmMüşteriListele
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMüşteriListele));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGüncelle = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.txtAdSoyad = new System.Windows.Forms.TextBox();
            this.txtTc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSilme = new System.Windows.Forms.Button();
            this.txtTcAra = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(261, 99);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(595, 275);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnGüncelle
            // 
            this.btnGüncelle.Location = new System.Drawing.Point(180, 293);
            this.btnGüncelle.Name = "btnGüncelle";
            this.btnGüncelle.Size = new System.Drawing.Size(75, 23);
            this.btnGüncelle.TabIndex = 21;
            this.btnGüncelle.Text = "Güncelle";
            this.btnGüncelle.UseVisualStyleBackColor = true;
            this.btnGüncelle.Click += new System.EventHandler(this.btnGüncelle_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(103, 240);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(152, 20);
            this.txtEmail.TabIndex = 20;
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(103, 210);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(152, 20);
            this.txtAdres.TabIndex = 19;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(103, 180);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(152, 20);
            this.txtTelefon.TabIndex = 18;
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.Location = new System.Drawing.Point(103, 150);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Size = new System.Drawing.Size(152, 20);
            this.txtAdSoyad.TabIndex = 17;
            // 
            // txtTc
            // 
            this.txtTc.Location = new System.Drawing.Point(103, 120);
            this.txtTc.Name = "txtTc";
            this.txtTc.Size = new System.Drawing.Size(152, 20);
            this.txtTc.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "E-mail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Adres";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Telefon";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ad Soyad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "TC";
            // 
            // btnSilme
            // 
            this.btnSilme.Location = new System.Drawing.Point(180, 322);
            this.btnSilme.Name = "btnSilme";
            this.btnSilme.Size = new System.Drawing.Size(75, 23);
            this.btnSilme.TabIndex = 22;
            this.btnSilme.Text = "Sil";
            this.btnSilme.UseVisualStyleBackColor = true;
            this.btnSilme.Click += new System.EventHandler(this.btnSilme_Click);
            // 
            // txtTcAra
            // 
            this.txtTcAra.Location = new System.Drawing.Point(321, 57);
            this.txtTcAra.Name = "txtTcAra";
            this.txtTcAra.Size = new System.Drawing.Size(133, 20);
            this.txtTcAra.TabIndex = 23;
            this.txtTcAra.TextChanged += new System.EventHandler(this.txtTcAra_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(258, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "TC Ara";
            // 
            // frmMüşteriListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(949, 504);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTcAra);
            this.Controls.Add(this.btnSilme);
            this.Controls.Add(this.btnGüncelle);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.txtAdSoyad);
            this.Controls.Add(this.txtTc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMüşteriListele";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Müşteri Listeleme Sayfası";
            this.Load += new System.EventHandler(this.frmMüşteriListele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGüncelle;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.TextBox txtAdSoyad;
        private System.Windows.Forms.TextBox txtTc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSilme;
        private System.Windows.Forms.TextBox txtTcAra;
        private System.Windows.Forms.Label label6;
    }
}