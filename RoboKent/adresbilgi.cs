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
    public partial class adresbilgi : Form
    {
        public adresbilgi()
        {
            InitializeComponent();
        }
        static string constirng = "Data Source=DESKTOP-J59HL2O\\SQLEXPRESS;Initial Catalog=Robokent;Integrated Security=True";
        SqlConnection baglan = new SqlConnection(constirng);

        public void kayitlari_listele()
        {
            baglan.Open();
            string getir = "Select *  from siparis Order By siparis_adres";

            SqlCommand komut = new SqlCommand(getir, baglan);

            SqlDataAdapter adapter = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();

        }
        public void verisil(int id)
        {
            string sil = "Delete from siparis Where id = @id";
            SqlCommand komut = new SqlCommand(sil, baglan);
            baglan.Open();
            komut.Parameters.AddWithValue("id", id);
            komut.ExecuteNonQuery();
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kayitlari_listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                verisil(id);
                kayitlari_listele();
            }
        }
    }
}
