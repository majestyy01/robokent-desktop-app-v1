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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string conString = "Data Source=DESKTOP-J59HL2O\\SQLEXPRESS;Initial Catalog=Robokent;Integrated Security=True";
        SqlConnection connect = new SqlConnection(conString);

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
                string kayit = "insert into uye_bilgii(kullanici_adi,sifre,ad_soyad,telefon_no,eposta) values(@kullanici_adi,@sifre,@ad_soyad,@telefon_no,@eposta)";
                SqlCommand komut = new SqlCommand(kayit, connect);

                komut.Parameters.AddWithValue("@kullanici_adi", txt_kullanici_adi.Text);
                komut.Parameters.AddWithValue("@sifre", txt_sifre.Text);
                komut.Parameters.AddWithValue("@ad_soyad", txt_adsoyad.Text);
                komut.Parameters.AddWithValue("@telefon_no", txt_telefon.Text);
                komut.Parameters.AddWithValue("@eposta", txt_eposta.Text);

                komut.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Kayıt Olundu");
            }
            catch(Exception hata)
            {
                MessageBox.Show("Hata Meydana geldi" + hata.Message);
            }
            this.Hide();
            giris goster = new giris();
            goster.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            giris göster = new giris();
            göster.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            sifremiunuttumcs goster = new sifremiunuttumcs();
            goster.Show();
        }
    }
}
