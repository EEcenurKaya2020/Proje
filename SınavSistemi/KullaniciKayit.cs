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

namespace SınavSistemi
{
    public partial class KullaniciKayit : Form
    {
        public KullaniciKayit()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=DESKTOP-HVTB9LK;Integrated Security=SSPI;Initial Catalog=YazilimYapimi";
        SqlConnection connect = new SqlConnection(constring);
        string g;

        private void KullaniciKayit_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            if (rb_admin.Checked == true)
            {
                g = "Admin";
            }
            else if (rb_sinav_sorumlusu.Checked == true)
            {
                g = "Sınav Sorumlusu";
            }
            else
            {
                g = "Öğrenci";
            }

            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
                string kayit = "insert into Bilgi (mail, kullanici_adi, ad_sayad, sifre, kullanici_turu) values(@mail, @kullanici_adi, @ad_sayad, @sifre, @kullanici_turu)";
                SqlCommand komut = new SqlCommand(kayit, connect);

                komut.Parameters.AddWithValue("@mail", txt_mail.Text);
                komut.Parameters.AddWithValue("@ad_sayad", txt_ad_soyad.Text);
                komut.Parameters.AddWithValue("@kullanici_adi", txt_kullanici_adi.Text);
                komut.Parameters.AddWithValue("@sifre", txt_sifre.Text);
                komut.Parameters.AddWithValue("@kullanici_turu", g);

                komut.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Kayıt Eklendi");
            }
            catch(Exception hata)
            {
                MessageBox.Show("Hata meydana geldi", hata.Message);
            }
        }
    }
}
