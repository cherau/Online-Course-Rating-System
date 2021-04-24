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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }


        public delegate void storeEmail(string em);

        public storeEmail se;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var fp = new forgot_password();
            fp.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sign = new signup();
            sign.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=login;Integrated Security=True;Connect Timeout=30");

            try
            {
                Con.Open();
                string query = "select * from [Table] where email='" + email.Text + "' and password='" + pwd.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Signed In!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Form1 f1=new Form1();
                    this.se += new storeEmail(f1.setUser);
                    //Console.WriteLine(dt.Rows[0][0]+" "+dt.Rows[0][1]);
                    se(dt.Rows[0][1].ToString());
                    f1.Show();
                    this.Hide();
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

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
