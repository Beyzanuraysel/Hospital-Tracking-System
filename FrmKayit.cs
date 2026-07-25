using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace HastaTakipSistemi
{
    public partial class FrmKayit : Form
    {
        public FrmKayit()
        {
            InitializeComponent();
        }
            frmSqlBaglanti bgl =new frmSqlBaglanti();
        private void btnKayit_Click(object sender, EventArgs e)
        {
            if (txtKulAdi.Text != "" && txtSifre.Text != "")
            {
                SqlCommand kayit = new SqlCommand("kayitOl", bgl.baglan());
                kayit.CommandType = CommandType.StoredProcedure;
                kayit.Parameters.AddWithValue("KulAdi",txtKulAdi.Text);
                kayit.Parameters.AddWithValue("Sifre", txtSifre.Text);
                kayit.ExecuteNonQuery();
                MessageBox.Show("Kayıt İşlemi Başarılı", "Kayıt Başarılı",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            { 
             MessageBox.Show ("Lütfen Tüm Alanları Doldurunuz.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) 
        { 
        }
    }
}
