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
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BudgetBuddy
{
    public partial class Income : Form
    {
        public Income()
        {
            InitializeComponent();
            GoToIncomeTotal();
        }

        private void Income_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            View_Income income = new View_Income();
            income.Show();
            this.Close
                ();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void IncName_TextChanged(object sender, EventArgs e)
        {
        }
        private void Clear()
        {
            ExpenseAmt.Text = "";
            ExpenseCat.Text = "";
            ExpenseName.Text = "";
            ExpenseDate.Text = "";
            ExpenseDesc.Text = "";
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jayrajj\OneDrive\Documents\BuddyBudjet.mdf;Integrated Security=True;Connect Timeout=30");

        private void AddExpense_Click(object sender, EventArgs e)
        {
            if (ExpenseName.Text == "")
            {
                MessageBox.Show("Name cannot be empty!");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Incomes(IncomeName, IncomeAmt, IncomeCat, IncomeDate, IncomeDesc,IncomeUser) VALUES (@IncomeName, @IncomeAmt, @IncomeCat, @IncomeDate, @IncomeDesc,@icc)", conn);
                    cmd.Parameters.AddWithValue("@IncomeName", ExpenseName.Text);
                    cmd.Parameters.AddWithValue("@IncomeAmt",ExpenseAmt.Text); // Assuming IncomeAmt is of a numeric data type
                    cmd.Parameters.AddWithValue("@IncomeCat", ExpenseCat.Text);
                    cmd.Parameters.AddWithValue("@IncomeDesc", ExpenseDesc.Text);
                    cmd.Parameters.AddWithValue("@IncomeDate", ExpenseDate.Text);
                    cmd.Parameters.AddWithValue("@icc", Login.User);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Income added successfully!");
                    conn.Close();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding income: " + ex.Message);
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            DashBoard dashBoard = new DashBoard();
            dashBoard.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Income income = new Income();
            income.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            View_Income expense = new View_Income();
                expense.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewExpense expense = new ViewExpense();    
            expense.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Login l=new Login();
            l.Show();
            this.Hide();
        }
       
        public void GoToIncomeTotal()
        {
            try
            {
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter("SELECT SUM(IncomeAmt) FROM Incomes WHERE IncomeUser='" + Login.User + "'", conn);
                DataTable dt = new DataTable();
                ad.Fill(dt);

               
                if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                {
                    TotalInc.Text = dt.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching total income: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ExpenseDesc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}