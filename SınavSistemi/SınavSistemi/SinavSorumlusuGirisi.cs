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
using System.IO;

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
        string imagepath;
        
        private void SinavSorumlusuGirisi_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fileStream = new FileStream(imagepath, FileMode.Open, FileAccess.Read); ;
                BinaryReader binaryReader = new BinaryReader(fileStream);
                byte[] Resim = binaryReader.ReadBytes((int)fileStream.Length);
                binaryReader.Close();
                fileStream.Close();

                if (connect.State == ConnectionState.Closed)
                    connect.Open();
                string kayit = "insert into SoruEkle (Soru, A, B, C, D, Dogru, Resim) values(@Soru, @A, @B, @C, @D, @Dogru, @Resim)";
                SqlCommand komut = new SqlCommand(kayit, connect);



                komut.Parameters.AddWithValue("@Soru", txt_soru.Text);
                komut.Parameters.AddWithValue("@A", txt_a.Text);
                komut.Parameters.AddWithValue("@B", txt_b.Text);
                komut.Parameters.AddWithValue("@C", txt_c.Text);
                komut.Parameters.AddWithValue("@D", txt_d.Text);
                komut.Parameters.Add("@Resim", SqlDbType.Image, Resim.Length).Value = Resim;

                if (txt_dgr.Text == "A")
                {
                    komut.Parameters.AddWithValue("@Dogru", txt_a.Text);
                }
                else if (txt_dgr.Text == "B")
                {
                    komut.Parameters.AddWithValue("@Dogru", txt_b.Text);
                }
                else if (txt_dgr.Text == "C")
                {
                    komut.Parameters.AddWithValue("@Dogru", txt_c.Text);

                }
                else if (txt_dgr.Text == "D")
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            /*string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    picture.ImageLocation = imageLocation;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }*/

            openFileDialog1.Title = "resim seç";
            openFileDialog1.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picture.Image = Image.FromFile(openFileDialog1.FileName);
                imagepath = openFileDialog1.FileName;
            }

        }

        private void txt_soru_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
