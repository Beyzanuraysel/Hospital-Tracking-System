using System.Data.SqlClient;

using System.Drawing;

namespace HastaTakipSistemi 
{
    internal class frmSqlBaglanti

    {
        string adres = @"Data Source=DESKTOP-4B4IINQ\SQLEXPRESS;Initial Catalog=db_HastaneYonetim;Integrated Security=True;Encrypt=False";
        public SqlConnection baglan()
        {
            SqlConnection baglanti = new SqlConnection(adres);
            baglanti.Open();
            return baglanti;

        }

        
    }
}
