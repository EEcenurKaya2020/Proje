using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace SınavSistemi
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KullaniciKayit kk = new KullaniciKayit();
            kk.ShowDialog();
        }

     
        private void guna2Button1_Click(object sender, EventArgs e)
        {   

            string mail = txt_mailg.Text;
            string sifre = txt_sifreg.Text;

            con = new SqlConnection("Data Source=DESKTOP-HVTB9LK;Integrated Security=SSPI;Initial Catalog=YazilimYapimi");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "select *from Bilgi where mail='" + txt_mailg.Text + "'and sifre='" + txt_sifreg.Text +"'";

            

            dr = com.ExecuteReader();
            if (dr.Read())
            {
                
                if (dr["kullanici_turu"].ToString()== "Öğrenci")
                {
                    OgrenciGirisi og = new OgrenciGirisi();
                    og.Show();
                    MessageBox.Show("Giriş Başarılı");

                }
                else if (dr["kullanici_turu"].ToString() == "Sınav Sorumlusu")
                {
                    SinavSorumlusuGirisi ssg = new SinavSorumlusuGirisi();
                    ssg.Show();
                    MessageBox.Show("Giriş Başarılı");

                }
                else if (dr["kullanici_turu"].ToString() == "Admin")
                {
                    AdminGirisi ag = new AdminGirisi();
                    ag.Show();
                    MessageBox.Show("Giriş Başarılı");

                }
                MessageBox.Show("Giriş Başarılı");
            }
            else
            {
                MessageBox.Show("Bilgilerinizi Kontrol Ediniz");
            }
            con.Close();
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifreYenile sc = new SifreYenile();
            this.Hide();
            sc.Show();

            //SifreYenile sy = new SifreYenile();
            //sy.ShowDialog();
        }
    }
}
