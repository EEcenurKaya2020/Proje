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
    public partial class SinavSorumlusuGirisi : Form
    {
        public SinavSorumlusuGirisi()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=DESKTOP-HVTB9LK;Integrated Security=SSPI;Initial Catalog=YazilimYapimi";
        SqlConnection connect = new SqlConnection(constring);
        
        private void SinavSorumlusuGirisi_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
                string kayit = "insert into SoruEkle (Soru, A, B, C, D, Dogru) values(@Soru, @A, @B, @C, @D, @Dogru)";
                SqlCommand komut = new SqlCommand(kayit, connect);

                komut.Parameters.AddWithValue("@Soru", txt_soru.Text);
                komut.Parameters.AddWithValue("@A", txt_a.Text);
                komut.Parameters.AddWithValue("@B", txt_b.Text);
                komut.Parameters.AddWithValue("@C", txt_c.Text);
                komut.Parameters.AddWithValue("@D", txt_d.Text);
                //komut.Parameters.AddWithValue("@Dogru", txt_dc.Text);

                if (txt_dc.Text == "A")
                {
                    komut.Parameters.AddWithValue("@Dogru", txt_a.Text);
                }
                else if (txt_dc.Text == "B")
                {
                    komut.Parameters.AddWithValue("@Dogru", txt_b.Text);
                }
                else if (txt_dc.Text == "B")
                {
                    komut.Parameters.AddWithValue("@Dogru", txt_c.Text);

                }
                else if (txt_dc.Text == "B")
                {
                    komut.Parameters.AddWithValue("@Dogru", txt_d.Text);
                }
                else
                {
                    MessageBox.Show("Geçersiz Karakter Girdiniz");
                }
                komut.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Soru Eklendi");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata meydana geldi", hata.Message);
            }
        }
    }
}
