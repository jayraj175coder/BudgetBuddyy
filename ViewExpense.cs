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
    public partial class ViewExpense : Form
    {
        public ViewExpense()
        {
            InitializeComponent();
            DisplayItems(); 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            ViewExpense viewExpense = new ViewExpense();
            viewExpense.Show();
            this.Hide();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jayrajj\OneDrive\Documents\BuddyBudjet.mdf;Integrated Security=True;Connect Timeout=30");

        private void DisplayItems()
        {
            conn.Open();
            String query = "select * from Expenses where ExpenseUser='"+Login.User+"'";
            SqlDataAdapter a = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(a);
            var ds = new DataSet();
            a.Fill(ds);
            ExpenseBG.DataSource = ds.Tables[0];
            conn.Close();

        }
        private void ExpenseBG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            DashBoard obj = new DashBoard();
            obj.Show();
            this.Hide(); 
        }

        private void label15_Click(object sender, EventArgs e)
        {
          Income obj = new Income();
            obj.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Expense obj = new Expense();
            obj.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
           View_Income obj = new View_Income();
            obj.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Login obj = new Login();    
            obj.Show();
                this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }
}
