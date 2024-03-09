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
    public partial class Expense : Form
    {
        public Expense()
        {
            InitializeComponent();
            GoToExpenseTotal();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jayrajj\OneDrive\Documents\BuddyBudjet.mdf;Integrated Security=True;Connect Timeout=30");

        private void Clear()
        {
            ExpenseAmt.Text = "";
            ExpenseCat.Text = "";
            ExpenseName.Text = "";
            ExpenseDate.Text = "";
            ExpenseDesc.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ExpenseName.Text == "")
            {
                MessageBox.Show("Cant Be Empty!");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Expenses(ExpenseName,ExpenseAmt,ExpenseCat,ExpenseDate,ExpenseDesc,ExpenseUser) values(@UI,@UPS,@UAD,@UP,@UDa,@Uu)", conn);
                    cmd.Parameters.AddWithValue("@UI", ExpenseName.Text);
                    cmd.Parameters.AddWithValue("@UAD", ExpenseCat.Text);
                    cmd.Parameters.AddWithValue("@UDa", ExpenseDesc.Text);
                    cmd.Parameters.AddWithValue("@UP", ExpenseDate.Text);
                    cmd.Parameters.AddWithValue("@UPS", ExpenseAmt.Text);
                    cmd.Parameters.AddWithValue("@Uu", Login.User);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Expense Addded Successfully!!!!");
                    SqlConnection.ClearPool(conn);
                    conn.Close();

                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void GoToExpenseTotal()
        {
            try
            {
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter("select SUM(ExpenseAmt) from Expenses where ExpenseUser='" + Login.User + "'", conn);
                DataTable dataTable = new DataTable();
                ad.Fill(dataTable);

                TotalExp.Text = dataTable.Rows[0][0].ToString();

            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void ExpenseCat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ExpenseDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void ExpenseDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void ExpenseName_TextChanged(object sender, EventArgs e)
        {

        }

        private void ExpenseAmt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            DashBoard o = new DashBoard();
            o.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Income income = new Income();   
            income.Show();
            this.Hide();    
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Expense expense = new Expense();    
            expense.Show(); 
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            View_Income income = new View_Income();
            income.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewExpense expense = new ViewExpense();    
            expense.Show();
                this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Expense_Load(object sender, EventArgs e)
        {

        }
    }
}
