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
namespace RoboKent
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataReader dr;
        SqlDataReader dr2;
        SqlCommand com;
        SqlCommand com2;

        private void btn_giris_Click(object sender, EventArgs e)
        {
            string user = txt_kullanici_adi2.Text;
            string password = txt_sifre2.Text;
            string adminad = txt_kullanici_adi2.Text;
            string adminsifre = txt_sifre2.Text;
            con = new SqlConnection("Data Source=DESKTOP-J59HL2O\\SQLEXPRESS;Initial Catalog=Robokent;Integrated Security=True");
            com = new SqlCommand();
            com2 = new SqlCommand();
            con.Open();
            com.Connection = con;
            com2.Connection = con;
            com.CommandText = "Select*From uye_bilgii where kullanici_adi='" + txt_kullanici_adi2.Text +
                "'And sifre='" + txt_sifre2.Text + "'";
            com2.CommandText = "Select*From adminler where admin_adi='" + txt_kullanici_adi2.Text +
                "'And admin_sifre='" + txt_sifre2.Text + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı.\nHoş Geldiniz");
                mainuye göster = new mainuye();
                göster.Show();
                
            }
            else
            {
                MessageBox.Show("Giriş Başarısız Lütfen Tekrar Deneyiniz");
               
            }
            dr.Close();
            dr2 = com2.ExecuteReader();
            if (dr2.Read())
            {
                MessageBox.Show("Giriş Başarılı Admin.\nHoş Geldiniz");
                adminmaincs göster2 = new adminmaincs();
                göster2.Show();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız Lütfen Tekrar Deneyiniz");
            }
            con.Close();
        }
    }
}
