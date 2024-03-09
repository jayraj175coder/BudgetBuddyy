using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetBuddy
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        public static string User;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jayrajj\OneDrive\Documents\BuddyBudjet.mdf;Integrated Security=True;Connect Timeout=30");
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (UserName.Text == "" || UserPsd.Text == "")
            {
                MessageBox.Show("Plz Enter UserName and Password");
            }
            else
            {
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter("select count(*) from Users where UserName='" + UserName.Text + "' and UserPassword='" + UserPsd.Text + "'", conn);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    User = UserName.Text;
                    DashBoard obj = new DashBoard();
                    obj.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("The UserName And Passeword is not There");
                    conn.Close();
                }
            }
        conn.Close();   
        }
    }
}
