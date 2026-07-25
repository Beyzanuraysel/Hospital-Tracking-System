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

namespace HastaTakipSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        frmSqlBaglanti bgl = new frmSqlBaglanti();
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtGiris_Click(object sender, EventArgs e)
        {
            if (txtKulAdi.Text != "" && txtSifre.Text != "")
            {
                SqlCommand Giris = new SqlCommand("girisYap", bgl.baglan());
                Giris.CommandType=CommandType.StoredProcedure;
                Giris.Parameters.AddWithValue ("kulAdi",txtKulAdi.Text);
                Giris.Parameters.AddWithValue("Sifre", txtSifre.Text);
                SqlDataReader dr = Giris.ExecuteReader();
                if (dr.Read())
                {
                       MessageBox.Show("Giriş İşlemi Başarılı","Giriş Başarılı",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmAnaSayfa fr=new frmAnaSayfa();
                    this.Hide();
                    fr.Show();

                    //this.Close(); Giriş ekranı kapat demek ama biz kapatmak değil ana sayfaya girmek istiyoruz
                    //o yüzden this.Hide yazmalıyız.
                }

                else
                {
                    MessageBox.Show("Giriş İşlemi Başarısız", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            else
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            FrmKayit fr = new FrmKayit();
            fr.Show();
        }
       


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
