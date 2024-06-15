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
    public partial class mainuye : Form
    {
        public mainuye()
        {
            InitializeComponent();
        }
        static string constirng = "Data Source=DESKTOP-J59HL2O\\SQLEXPRESS;Initial Catalog=Robokent;Integrated Security=True";
        SqlConnection baglan = new SqlConnection(constirng);
        public void kayitlari_listele()
        {
            baglan.Open();
            string getir = "Select *  from uye_bilgii Order By kullanici_adi";

            SqlCommand komut = new SqlCommand(getir, baglan);

            SqlDataAdapter adapter = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

            baglan.Close();

        }
        private void KullaniciBilgileriniGetir(string kullaniciAdi)
        {
            // SQL bağlantı dizesi
            string connectionString = "Data Source=DESKTOP-J59HL2O\\SQLEXPRESS;Initial Catalog=Robokent;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL sorgusu
                    string query = "SELECT kullanici_adi, sifre, ad_soyad, telefon_no, eposta FROM uye_bilgii WHERE kullanici_adi = @kullaniciAdi";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                label9.Text = reader["kullanici_adi"].ToString();
                                label10.Text = reader["sifre"].ToString();
                                label11.Text = reader["ad_soyad"].ToString();
                                label12.Text = reader["telefon_no"].ToString();
                                label13.Text = reader["eposta"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı bulunamadı.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string kayitguncelle = ("Select * from uye_bilgii  kullanici_adi=@kullanici_adi, sifre= @sifre,ad_soyad=@ad_soyad ,telefon_no=@telefon_no , eposta=@eposta");
            SqlCommand komutt = new SqlCommand(kayitguncelle, baglan);

            komutt.Parameters.AddWithValue("@kullanici_adi", label9.Text);
            komutt.Parameters.AddWithValue("@sifre", label10.Text);
            komutt.Parameters.AddWithValue("@ad_soyad", label11.Text);
            komutt.Parameters.AddWithValue("@telefon_no", label12.Text);
            komutt.Parameters.AddWithValue("@eposta", label13.Text);
            komutt.ExecuteNonQuery();
            baglan.Close();
            kayitlari_listele();
        }

        private void mainuye_Load(object sender, EventArgs e)
        {
           
                string kullaniciAdi = "kullanici_adi"; // Bu değişkeni giriş yapan kullanıcı adıyla set etmelisiniz.
                KullaniciBilgileriniGetir(kullaniciAdi);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 goster = new Form2();
            goster.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 goster = new Form2();
            goster.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
