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
    public partial class kartlar : Form
    {
        public kartlar()
        {
            InitializeComponent();
        }
        static string constirng = "Data Source=DESKTOP-J59HL2O\\SQLEXPRESS;Initial Catalog=Robokent;Integrated Security=True";
        SqlConnection baglan = new SqlConnection(constirng);

        public void kayitlari_listele()
        {
            baglan.Open();
            string getir = "Select *  from credit_cards Order By card_number";

            SqlCommand komut = new SqlCommand(getir, baglan);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            kartlargrid.DataSource = dt;

            baglan.Close();

        }
        public void verisil2(int id)
        {
            string sil = "Delete from urun_bilgii Where urun_id = @urun_id";
            SqlCommand komut = new SqlCommand(sil, baglan);
            baglan.Open();
            komut.Parameters.AddWithValue("urun_id", id);
            komut.ExecuteNonQuery();
            baglan.Close();
        }

        private void btn_listele2_Click(object sender, EventArgs e)
        {
            kayitlari_listele();
        }

        private void btn_sil2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in kartlargrid.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                verisil2(id);
                kayitlari_listele();
            }
        }
    }
}
