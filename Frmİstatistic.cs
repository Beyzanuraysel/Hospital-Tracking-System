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
    public partial class Frmİstatistic : Form
    {
        public Frmİstatistic()
        {
            InitializeComponent();
        }

        frmSqlBaglanti bgl = new frmSqlBaglanti();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Frmİstatistic_Load(object sender, EventArgs e)
        {
            //Kodları yazdıktan sonra buraya gelip çağır.
            ToplamHasta();
            YasOrtalama();
            ErkekSayi();
            KadinSayi();
            ExSayi();
        }
        private void ToplamHasta()
        {
            SqlCommand toplam = new SqlCommand(" SELECT COUNT (*) FROM tbl_HastaBilgi", bgl.baglan());
            SqlDataReader dr = toplam.ExecuteReader();
            // okuma işlemi yap
            while (dr.Read()) 
            {
             lblToplamHasta.Text= dr[0].ToString();
            }                            
        }

        private void YasOrtalama()
        {
            SqlCommand Ortalama = new SqlCommand("SELECT AVG (hYas) FROM Tbl_HastaBilgi" ,bgl.baglan());
            SqlDataReader dr = Ortalama.ExecuteReader();
            // okuma işlemi yap
            while (dr.Read())
            { 
             lblYasOrtalaması.Text= dr[0].ToString();
            }          
        }     

        private void ErkekSayi()
        {

            SqlCommand Erkek = new SqlCommand("SELECT COUNT(*) FROM  tbl_HastaBilgi WHERE hCinsiyet='Erkek'", bgl.baglan());
            SqlDataReader dr = Erkek.ExecuteReader();
            // okuma işlemi yap
            while (dr.Read())
            {
                lblErkekSayi.Text = dr[0].ToString();
            }
        }

        private void KadinSayi()
        {
            SqlCommand Kadin = new SqlCommand("SELECT COUNT(*) FROM  tbl_HastaBilgi WHERE hCinsiyet='Kadın'", bgl.baglan());
            SqlDataReader dr = Kadin.ExecuteReader();
            // okuma işlemi yap
            while (dr.Read())
            {
                lblKadinSayi.Text = dr[0].ToString();
            }
        }

        private void ExSayi()
        {
            SqlCommand Ex = new SqlCommand("SELECT COUNT(*) FROM tbl_HastaBilgi WHERE  hExMi='1'", bgl.baglan());
            SqlDataReader dr = Ex.ExecuteReader();
            // okuma işlemi yap
            while (dr.Read())
            {
                lblExSayi.Text = dr[0].ToString();
            }
        }
    }
    
}
