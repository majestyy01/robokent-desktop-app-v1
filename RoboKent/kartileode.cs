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
    public partial class kartileode : Form
    {
        public kartileode()
        {
            InitializeComponent();
        }
        static string constirng = "Data Source=DESKTOP-J59HL2O\\SQLEXPRESS;Initial Catalog=Robokent;Integrated Security=True";
        SqlConnection baglan = new SqlConnection(constirng);

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    string kayit = "insert into credit_cards (card_number,expiration_month,expiration_year,cvv)values(@card_number,@expiration_month,@expiration_year,@cvv)";
                    SqlCommand kayit_komut = new SqlCommand(kayit, baglan);
                    kayit_komut.Parameters.AddWithValue("@card_number", textBox2.Text);
                    kayit_komut.Parameters.AddWithValue("@expiration_month", textBox1.Text);
                    kayit_komut.Parameters.AddWithValue("@expiration_year", textBox3.Text);
                    kayit_komut.Parameters.AddWithValue("@cvv", textBox4.Text);
                    kayit_komut.ExecuteNonQuery();
                    MessageBox.Show("Ödeme Başarılı 3 iş günü içerisinde teslime dilecektir");


                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata var" + hata.Message);
            }
        }
    }
}
