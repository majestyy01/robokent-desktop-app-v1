using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;




namespace RoboKent
{
    public partial class sifremiunuttumcs : Form
    {
        public sifremiunuttumcs()
        {
            InitializeComponent();
        }

        private void sifremiunuttumcs_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlbaglantisi bgln = new sqlbaglantisi();
            SqlCommand komut = new SqlCommand("Select * From uye_bilgii Where kullanici_adi= '"+textBox1.Text.ToString()+
                "'and eposta ='" + textBox2.Text.ToString()+"'",bgln.baglanti());

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                try
                {
                    if(bgln.baglanti().State == ConnectionState.Closed)
                    {
                        bgln.baglanti().Open();
                    }
                    SmtpClient smptpserver = new SmtpClient();
                    MailMessage mail = new MailMessage();
                    String tarih = DateTime.Now.ToLongDateString();
                    String mailadresim = ("epostanız");
                    String sifre = ("Eposta şifreniz");
                    String smptpsrvr = "smtp.gmail.com"; //eğer gmail üzerinden gönderim yapacaksanız burayı değiştirmenize gerek yok.
                    String kime = (oku["eposta"].ToString());
                    String konu = ("Şifre Hatırlatma Metni");
                    String yaz = ("Sayın, " + oku["ad_soyad"].ToString() + "\n"+"Bizden"+ tarih+ 
                        "Tarihinde Şifre Hatırlatma Talebinde Bulundunuz"+"\n"+"Parolanız : "+oku["sifre"].ToString()+"\nİyi Günler");
                    smptpserver.Credentials = new NetworkCredential(mailadresim, sifre);
                    smptpserver.Port = 587; //portun böyle kalması daha makul.
                    smptpserver.Host = smptpsrvr;
                    smptpserver.EnableSsl = true; //her zaman açık kalsın.
                    mail.From = new MailAddress(mailadresim);
                    mail.To.Add(kime);
                    mail.Subject = konu;
                    mail.Body = yaz;
                    smptpserver.Send(mail);
                    DialogResult bilgi = new DialogResult();
                    bilgi = MessageBox.Show("Girmiş olduğunuz bilgiler uyuşuyor.Şifreniz Mail Adresinize Gönderilmiştir.");
                    this.Hide();

                }
                catch(Exception Hata)
                {
                    MessageBox.Show("Mail Gönderme Hatası\n" + Hata.Message);
                }
            }
        }
    }
}
