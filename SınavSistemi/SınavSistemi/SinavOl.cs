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
    public partial class SinavOl : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        int sayac = 0;
        string g;

        int saniye = 60;
        int dakika = 0;

        public SinavOl()
        {
            InitializeComponent();
        }

        private void SinavOl_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            btn_sonraki.Text = "Sonraki";
            if (sayac < 10)
            {
                timer1.Start();
                dakika = 10;

                con = new SqlConnection("Data Source=DESKTOP-HVTB9LK;Integrated Security=SSPI;Initial Catalog=YazilimYapimi");
                cmd = new SqlCommand();
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = "select top 10 soru,a,b,c,d,dogruCevap,dogruSayisi FROM SoruBilgisi ORDER BY NEWID()";
                dr = cmd.ExecuteReader();

                if (rb_a.Checked == true)
                {
                    g = "A";
                }
                else if (rb_b.Checked == true)
                {
                    g = "B";
                }
                else if (rb_c.Checked == true)
                {
                    g = "C";
                }
                else if (rb_d.Checked == true)
                {
                    g = "D";
                }
                else
                {
                    MessageBox.Show("Bir şık seçiniz.");
                }

                while (dr.Read())
                {
                    label_soru.Text = dr["soru"].ToString();
                    label_a.Text = dr["a"].ToString();
                    label_b.Text = dr["b"].ToString();
                    label_c.Text = dr["c"].ToString();
                    label_d.Text = dr["d"].ToString();
                    if (dr["dogruCevap"] == g)
                    {
                        string q = "update [SoruBilgisi] set [dogruSayisi]='"+ (Convert.ToInt32(dr["dogruSayisi"]) + 1) + "' where soruİd='" + dr["soruİd"] + "'";
                    }


                }
                con.Close();
                dr.Close();
                sayac++;
            }
            else
            {
                OgrenciGirisi og = new OgrenciGirisi();
                og.ShowDialog();
            }

            }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            saniye -= 1;
            lbl_sn.Text = saniye.ToString();
            lbl_dk.Text = (dakika-1).ToString();
            if (saniye == 0)
            {
                dakika -= 1;
                lbl_dk.Text = dakika.ToString();
                saniye = 60;
            }
            if (lbl_dk.Text == "-1")
            {
                timer1.Stop();
                lbl_dk.Text ="00"; 
                lbl_sn.Text = "00";
                MessageBox.Show("süre bitti");
            }
        }
    }
}
