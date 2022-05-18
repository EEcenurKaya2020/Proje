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
using System.Net;
using System.Net.Mail;


namespace SınavSistemi
{
    public partial class SifreYenile : Form
    {
        string randomcode;
        public static string to;
        public SifreYenile()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            string from, pass, messageBody;
            Random rand = new Random();
            randomcode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (txt_maily.Text).ToString();
            from = "211305072@yetgen.mef.edu.tr";
            pass = "Yetgen@Mef2021!";
            messageBody = $"Şifreyi sıfırlama kodu: {randomcode}";
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Şifre Sıfırlama Kodu";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("Kod Başarıyla Gönderildi");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           if(randomcode == (txt_guvenlik.Text).ToString())
            {
                to = txt_maily.Text;
                TekrarSifre ts = new TekrarSifre();
                this.Hide();
                ts.Show();
            }
            else
            {
                MessageBox.Show("Yanlış Kod");
            }
        }
    }
}
