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
    public partial class adminmaincs : Form
    {
        public adminmaincs()
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
        public void kayitlari_listele2()
        {
            baglan.Open();
            string getir2 = "Select *  from urun_bilgii Order By urun_adi";

            SqlCommand komut = new SqlCommand(getir2, baglan);

            SqlDataAdapter adapter2 = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adapter2.Fill(dt);
            dataGridView2.DataSource = dt;

            baglan.Close();

        }
        public void verisil(int id)
        {
            string sil = "Delete from uye_bilgii Where id = @id";
            SqlCommand komut = new SqlCommand(sil, baglan);
            baglan.Open();
            komut.Parameters.AddWithValue("id", id);
            komut.ExecuteNonQuery();
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





        private void adminmaincs_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;

            tabControl1.AutoSize = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            kayitlari_listele();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        int i = 0;
        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string kayitguncelle = ("Update uye_bilgii Set  kullanici_adi= @kullanici_adi, sifre= @sifre,ad_soyad=@ad_soyad ,telefon_no=@telefon_no , eposta=@eposta Where id=@id");
            SqlCommand komutt = new SqlCommand(kayitguncelle,baglan);

            komutt.Parameters.AddWithValue("@kullanici_adi",textBox1.Text);
            komutt.Parameters.AddWithValue("@sifre", textBox2.Text);
            komutt.Parameters.AddWithValue("@ad_soyad", textBox3.Text);
            komutt.Parameters.AddWithValue("@telefon_no", textBox4.Text);
            komutt.Parameters.AddWithValue("@eposta", textBox6.Text);
            komutt.Parameters.AddWithValue("id", dataGridView1.Rows[i].Cells[0].Value);
            komutt.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarıyla Güncellendi");
            baglan.Close();
            kayitlari_listele();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow  drow in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                verisil(id);
                kayitlari_listele();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string kayit = "Select * From uye_bilgii Where  ad_soyad=@ad_soyad";
            SqlCommand komuttt = new SqlCommand(kayit, baglan);

            komuttt.Parameters.AddWithValue("@ad_soyad", textBox5.Text);

            SqlDataAdapter ad = new SqlDataAdapter(komuttt);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();

        }

        private void btn_sil2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView2.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                verisil2(id);
                kayitlari_listele2();
            }
        }

        private void btn_listele2_Click(object sender, EventArgs e)
        {
            kayitlari_listele2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(baglan.State== ConnectionState.Closed)
                {
                    baglan.Open();
                    string kayit = "insert into urun_bilgii (urun_adi,urun_kategori,urun_stok,urun_fiyat)values(@urun_adi,@urun_kategori,@urun_stok,@urun_fiyat)";
                    SqlCommand kayit_komut = new SqlCommand(kayit,baglan);
                    kayit_komut.Parameters.AddWithValue("@urun_adi", textBox9.Text);
                    kayit_komut.Parameters.AddWithValue("@urun_kategori", textBox10.Text);
                    kayit_komut.Parameters.AddWithValue("@urun_stok", textBox11.Text);
                    kayit_komut.Parameters.AddWithValue("@urun_fiyat", textBox12.Text);
                    kayit_komut.ExecuteNonQuery();
                    MessageBox.Show("Ürün Ekleme İşlemi Başarılı");


                }
            }
            catch(Exception hata)
            {
                MessageBox.Show("Bir hata var" + hata.Message);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            kartlar goster = new kartlar();
            goster.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            adresbilgi adr = new adresbilgi();
            adr.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
