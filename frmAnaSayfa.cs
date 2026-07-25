using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaTakipSistemi
{
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }
        
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
        frmSqlBaglanti bgl = new frmSqlBaglanti();
        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
            Listele();
            DurumDoldur();
            BolumDoldur();
        }
        private void Listele() 
        {
         SqlCommand Liste = new SqlCommand("Listele",bgl.baglan());
            SqlDataAdapter da= new SqlDataAdapter(Liste);
            DataTable dt = new DataTable();
            da.Fill(dt); //da yı datatable dan gelen değerle dolduracaksın
            dataGridView1.DataSource = dt;

        }
        private void DurumDoldur()
        {
            //sql deki DurumDoldur tablosunu buraya bağla.
            SqlCommand Durum = new SqlCommand("DurumDoldur", bgl.baglan());
            SqlDataAdapter da= new SqlDataAdapter(Durum);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtDurum.DataSource = dt;
            txtDurum.DisplayMember = "DurumAd"; //burada durumad kısmını seçenek olarak göstermeyi sağlar 
            txtDurum.ValueMember = "DurumID";
        }
        private void BolumDoldur()
        {
            //Sql deki bölüm tablosunu buraya bağla
            SqlCommand Bolum = new SqlCommand("BolumDoldur", bgl.baglan() );
            SqlDataAdapter bl = new SqlDataAdapter(Bolum);
            DataTable dt= new DataTable();
            bl.Fill(dt);
            txtBolum.DataSource = dt;
            txtBolum.DisplayMember = "BolumAd";
            txtBolum.ValueMember = "BolumID";
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //bilgilere tıkladığımızda otomatik olarak doldursun.cells kısmını sql tablosundaki sıraya göre yaz 
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtTC.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtTelefon.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtYas.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtCinsiyet.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            txtSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            txtTarih.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            txtDurum.SelectedValue = dataGridView1.Rows[secilen].Cells[9].Value.ToString(); 
            txtBolum.SelectedValue = dataGridView1.Rows[secilen].Cells[10].Value.ToString();

            lblEx.Text = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
        }

        private void rbEvet_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEvet.Checked == true)
            {
                lblEx.Text = "True";
            }
            else
            { 
             lblEx.Text = "False";
            }
        }

        private void lblEx_TextChanged(object sender, EventArgs e)
        {
            if (lblEx.Text == "True") 
            {
              rbEvet.Checked = true;    
            }
            else 
            {
                rbHayır.Checked = true;
                }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAd.Text != "" && txtSoyad.Text != "" && txtCinsiyet.Text != "" && txtSikayet.Text != "" && txtTarih.Text != "" && txtTC.Text != "" && txtTelefon.Text != "" && txtYas.Text != "" && txtBolum.Text != "" && txtDurum.Text != "") 
            {
                Kaydet();
            }
            else
            { 
               MessageBox.Show("Lütfen İlgili Tüm Alanları Doldurun" ,"Kayıt Başarısız" ,MessageBoxButtons.OK, MessageBoxIcon.Error);   
            }
        }
        private void Kaydet() 
        {
          SqlCommand Kaydet=new SqlCommand("Kaydet", bgl.baglan());
            Kaydet.CommandType = CommandType.StoredProcedure;
            Kaydet.Parameters.AddWithValue("Ad", txtAd.Text.ToString());
            Kaydet.Parameters.AddWithValue("Soyad", txtSoyad.Text.ToString());
            Kaydet.Parameters.AddWithValue("Cinsiyet", txtCinsiyet.Text.ToString());
            Kaydet.Parameters.AddWithValue("Sikayet", txtSikayet.Text.ToString());
            Kaydet.Parameters.AddWithValue("Tarih", DateTime.Now);
            Kaydet.Parameters.AddWithValue("Tc", txtTC.Text);
            Kaydet.Parameters.AddWithValue("Telefon", txtTC.Text);
            Kaydet.Parameters.AddWithValue("Yas", txtYas.Text);
            Kaydet.Parameters.AddWithValue("Durum", txtDurum.SelectedValue);
            Kaydet.Parameters.AddWithValue("Bolum", txtBolum.SelectedValue);
            if (lblEx.Text == "True")
            {
                Kaydet.Parameters.AddWithValue("Ex", 1);

            }
            else
            {
                Kaydet.Parameters.AddWithValue("Ex", 0);
            }
            Kaydet.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarıyla Eklendi", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();

        }

        private void txtBolum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDurum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtYas_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Sil();
        }
        private void Sil()
        {
            DialogResult dr = MessageBox.Show($"{txtID.Text} numaralı kayıt silinecek.Onaylıyor Musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                SqlCommand Sil = new SqlCommand("Sil", bgl.baglan());
                Sil.CommandType = CommandType.StoredProcedure;
                Sil.Parameters.AddWithValue("id", int.Parse(txtID.Text));
                Sil.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarıyla Silindi", "Kayıt Silme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Kaydı sildikten sonra otomatik olarak listelensin yani tekrar listele butonuna basmaya gerek duyulmasın.
                Listele();

            }


        }

        private void txtTarih_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"{txtID.Text} numaralı kayıt güncellenecek.Onaylıyor Musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Guncelle();
            } 
        }
        private void Guncelle()
        {

            SqlCommand Guncelle = new SqlCommand("Guncelle", bgl.baglan());
            Guncelle.CommandType = CommandType.StoredProcedure;
            Guncelle.Parameters.AddWithValue("id", int.Parse(txtID.Text));
            Guncelle.Parameters.AddWithValue("Ad", txtAd.Text.ToString());
            Guncelle.Parameters.AddWithValue("Soyad", txtSoyad.Text.ToString());
            Guncelle.Parameters.AddWithValue("Cinsiyet", txtCinsiyet.Text.ToString());
            Guncelle.Parameters.AddWithValue("Sikayet", txtSikayet.Text.ToString());
            Guncelle.Parameters.AddWithValue("Tarih", DateTime.Now);
            Guncelle.Parameters.AddWithValue("Tc", txtTC.Text.ToString());
            Guncelle.Parameters.AddWithValue("Telefon", txtTelefon.Text.ToString());
            Guncelle.Parameters.AddWithValue("Yas", int.Parse(txtYas.Text.ToString()));
            Guncelle.Parameters.AddWithValue("Durum", txtDurum.SelectedValue);
            Guncelle.Parameters.AddWithValue("Bolum", txtBolum.SelectedValue);
            if (lblEx.Text == "True")
            {
                Guncelle.Parameters.AddWithValue("Ex", 1);

            }
            else
            {
                Guncelle.Parameters.AddWithValue("Ex", 0);
            }
            Guncelle.ExecuteNonQuery();
            MessageBox.Show("Güncelleme Başarıyla Eklendi", "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();

        }

        private void temizle()
        {
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtCinsiyet.Text = "";
            txtSikayet.Text = "";
            txtTarih.Text = "";
            txtTC.Text = "";
            txtTelefon.Text = "";
            txtYas.Text = "";
            txtDurum.Text = "";
            txtBolum.Text = "";
            rbHayır.Checked = true;
            lblEx.Text = "False";
        }

        private void btnFormuTemizle_Click(object sender, EventArgs e)
        {
            temizle();  
            Listele();
        }

        private void btnİstatistik_Click(object sender, EventArgs e)
        {
            Frmİstatistic fr = new Frmİstatistic();
                fr.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
  
}
