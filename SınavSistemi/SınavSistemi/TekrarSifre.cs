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
    public partial class TekrarSifre : Form
    {
        string email = SifreYenile.to;
        
        public TekrarSifre()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string password = txt_sifre_tekrar.Text;
            if (txt_yeni_sifre.Text == password)
            {

                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-HVTB9LK;Integrated Security=SSPI;Initial Catalog=YazilimYapimi");
                string q = "update [Bilgi] set [sifre]='" + password + "'where mail='" + email + "'";
                SqlCommand cmd = new SqlCommand(q, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Şifre başarıyla değiştirildi");
                Form1 f1 = new Form1();
                f1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Şifreler Aynı Değil");
            }
                
        }
    }
}
