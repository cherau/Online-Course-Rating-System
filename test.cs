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
namespace WindowsFormsApp1
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
            wmp.URL = @"D:\pyth\Foreign - The Complete Python Course  Learn Python by Doing\1. Intro to Python\1. Welcome to this course!.mp4";

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=login;Integrated Security=True;Connect Timeout=30");

            try
            {
                Con.Open();
                string query = "select * from [Table] where email='"+email.Text+"' and password='"+pass.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Logged In Successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Invalid Email or Password!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException E)
            {
                Console.WriteLine(E);
                MessageBox.Show("Failure!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fromAddress = new MailAddress("cheraujain@pec.edu");
            var toAddress = new MailAddress("cheraujain@gmail.com");
            const string fromPassword = "43070754sunil";
            const string subject = "Hack Test";
            const string body = "Account successfully hacked!";

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
                MessageBox.Show("E-Mail sent successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
            {
                    MessageBox.Show(ex.Message);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=login;Integrated Security=True;Connect Timeout=30");

            try
            {
                Con.Open();
                string query = "select email,password from [Table]"; // where email='" + email.Text + "' and password='" + pass.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Console.WriteLine(dt);
                 table.DataSource=dt;
            }
            catch (SqlException E)
            {
                Console.WriteLine(E);
                MessageBox.Show("Failure!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Con.Close();

        }
    }
}
