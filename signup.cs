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
namespace WindowsFormsApp1
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=login;Integrated Security=True;Connect Timeout=30");
            try
            {
                Con.Open();

                SqlCommand cmd = new SqlCommand("insert into [Table] values('" + mail.Text + "','" + nam.Text + "','" + pwd.Text + "','" + age.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Account created!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                var log = new login();
                log.Show();
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
            var log = new login();
            log.Show();
            this.Hide();
            //Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
