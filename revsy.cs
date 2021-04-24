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

namespace test1
{
    public partial class revsy : Form
    {
        public revsy()
        {
            InitializeComponent();
        }
        public string course;
        public void recieveCourse(string s)
        {
            this.course = s;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string rev = review.Text;
            float val=rating.Value;

            SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=login;Integrated Security=True;Connect Timeout=30");

            try
            {
                Con.Open();
                string query = "insert into [reviews] values ('"+this.course+"','"+rating.Value+"','"+review.Text+"','')";
                //string query = "insert into [reviews] values ('a','')";

                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Reviewed!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                
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
