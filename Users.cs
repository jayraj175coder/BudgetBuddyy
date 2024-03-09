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
using System.Xml.Serialization;

namespace BudgetBuddy
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            UserPsd.Text = "";
            UserPhone.Text = " ";
            UserName.Text = " ";
            UserAddress.Text = " ";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jayrajj\OneDrive\Documents\BuddyBudjet.mdf;Integrated Security=True;Connect Timeout=30");
        private void button2_Click(object sender, EventArgs e)
        {
            if (UserAddress.Text == "")
            {
                MessageBox.Show("Cant Be Empty!");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Users(UserName,UserDate,UserPhone,UserPassword,UserAddress) values(@UI,@UDa,@UP,@UAD,@UPS)",conn);
                     cmd.Parameters.AddWithValue("@UI", UserName.Text);
                   
                    cmd.Parameters.AddWithValue("@UDa", UserDate.Text);
                    cmd.Parameters.AddWithValue("@UP", UserPhone.Text);
                    cmd.Parameters.AddWithValue("@UAD", UserPsd.Text);

                    cmd.Parameters.AddWithValue("@UPS", UserAddress.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Addded Successfully!!!!");
                    SqlConnection.ClearPool(conn);
                    conn.Close();

                    Clear ();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login users = new Login();
            users.Show();
            this.Hide();
        }
    }
}
