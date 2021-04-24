using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class forgot_password : Form
    {
        private readonly Random _random = new Random();
        public string OTP;
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
        public forgot_password()
        {
            InitializeComponent();
        }
        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var log = new login();
            log.Show();
            this.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fromAddress = new MailAddress("cheraujain@pec.edu");
            var toAddress = new MailAddress(email.Text);
            const string fromPassword = "cheraujain007";
            const string subject = "OTP";
            OTP = RandomString(5); 
            string body = "This is your One Time Password : "+ OTP;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
                try
                {
                    smtp.Send(message);
                    MessageBox.Show("OTP sent!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void otp_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(otp.Text != OTP)
            {
                MessageBox.Show("Incorrect OTP!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
            {
                SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=login;Integrated Security=True;Connect Timeout=30");
                try
                {
                    Con.Open();

                    SqlCommand cmd = new SqlCommand("update [Table] set password='" + pwd.Text + "' where email='" + email.Text +"'", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Password Updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var log = new login();
                    log.Show();

                    this.Hide();
              }
                catch (SqlException E)
                {
                    Console.WriteLine("Email  pwd were " + email.Text + " " + pwd.Text);
                    Console.WriteLine(E);
                    MessageBox.Show("Invalid Account!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Con.Close();

            }
        }
    }
}
