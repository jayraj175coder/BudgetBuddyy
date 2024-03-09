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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
            GoToIncomeTotal();
            GoToExpenseTotal();
            GoToExpenseDate();
            GoToExpenseNumber();
            GoToIncomeDate();
            GoToIncomeNumber();
            GoToMaxIncome();
            GoToMaxExpense();
            GotoBalance();
            GotoBestExpenseCategory();
            GotoBestIncomeCategory();
            GoToMinIncome();
            GoToMinExpense();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jayrajj\OneDrive\Documents\BuddyBudjet.mdf;Integrated Security=True;Connect Timeout=30");
        int INC, EXP;
        public void GotoBalance()
        {
            try {
                double balance = INC - EXP;
                Balance.Text = "Rs " + balance;
            } catch (Exception ex) { }
        }
        public void GoToExpenseTotal()
        {
            try
            {
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter("select SUM(ExpenseAmt) from Expenses where ExpenseUser='" + Login.User + "'", conn);
                DataTable dataTable = new DataTable();
                ad.Fill(dataTable);
                EXP = int.Parse(dataTable.Rows[0][0].ToString());
                TotalExpense.Text = dataTable.Rows[0][0].ToString();
                
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
        }
        public void GoToIncomeTotal()
        {
            try
            {
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter("SELECT SUM(IncomeAmt) FROM Incomes WHERE IncomeUser='" + Login.User + "'", conn);
                DataTable dt = new DataTable();
                ad.Fill(dt);

                INC = int.Parse(dt.Rows[0][0].ToString());
                if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                {
                    TotalIncome.Text = dt.Rows[0][0].ToString();
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
        public void GoToIncomeNumber()
        {
            try
            {
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter("select Count(*) from Incomes where IncomeUser='" + Login.User + "'", conn);
                DataTable dataTable = new DataTable();
                ad.Fill(dataTable);
                IncomeNum.Text = dataTable.Rows[0][0].ToString();
            }
            catch (Exception ex) { }
            finally
            {
                conn.Close();
            }
        }

        public void GoToExpenseNumber()
        {
            try
            {
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter("select Count(*) from Expenses where ExpenseUser='" + Login.User + "'", conn);
                DataTable dataTable = new DataTable();
                ad.Fill(dataTable);
                ExpenseNum.Text = dataTable.Rows[0][0].ToString();
            }
            catch (Exception e) { }
            finally { 
            conn.Close();
        } 
        }
        public void GoToIncomeDate()
        {
            try
            {
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter("select MAX(IncomeDate) from Incomes where IncomeUser='" + Login.User + "'", conn);
                DataTable dataTable = new DataTable();
                ad.Fill(dataTable);
                IncomeDate.Text = dataTable.Rows[0][0].ToString();
                LastIncome.Text = dataTable.Rows[0][0].ToString();
            }catch (Exception ex) { }
            finally { conn.Close(); }
           
        }

        public void GoToExpenseDate()
        {
            try
            {
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter("select MAX(ExpenseDate) from Expenses where ExpenseUser='" + Login.User + "'", conn);
                DataTable dataTable = new DataTable();
                ad.Fill(dataTable);
                ExpenseDate.Text = dataTable.Rows[0][0].ToString();
                LastExpense.Text = dataTable.Rows[0][0].ToString();
            }catch(Exception ex) { }
            finally { conn.Close(); }
                conn.Close();
        }
        public void GoToMaxIncome()
        {
            try
            {
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter("select MAX(IncomeAmt) from Incomes where IncomeUser='" + Login.User + "'", conn);
                DataTable dataTable = new DataTable();
                ad.Fill(dataTable);
                MaxIncome.Text = dataTable.Rows[0][0].ToString();
            }catch( Exception ex) { }   
            finally { conn.Close(); }
                
        }

        public void GoToMaxExpense()
        {
            try
            {
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter("select MAX(ExpenseAmt) from Expenses where ExpenseUser='" + Login.User + "'", conn);
                DataTable dataTable = new DataTable();
                ad.Fill(dataTable);
                MaxExpense.Text = dataTable.Rows[0][0].ToString();
            }catch (Exception ex) { }
            finally { conn.Close(); }   
                
        }
        public void GoToMinIncome()
        {
            try
            {
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter("select MIN(IncomeAmt) from Incomes where IncomeUser='" + Login.User + "'", conn);
                DataTable dataTable = new DataTable();
                ad.Fill(dataTable);
                MinIncome.Text = dataTable.Rows[0][0].ToString();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }

        }
        public void GoToMinExpense()
        {
            try
            {
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter("select MIN(ExpenseAmt) from Expenses where ExpenseUser='" + Login.User + "'", conn);
                DataTable dataTable = new DataTable();
                ad.Fill(dataTable);
                MinExpense.Text = dataTable.Rows[0][0].ToString();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }

        }
        public void GotoBestIncomeCategory()
        {
            try
            {
                conn.Open();
                string query = "select max(IncomeAmt) from Incomes where IncomeUser='"+Login.User+"'";


                SqlDataAdapter ad = new SqlDataAdapter(query, conn);
                DataTable adTable = new DataTable();
                ad.Fill(adTable);
                string q2 = "select IncomeCat from Incomes where IncomeAmt='" + adTable.Rows[0][0].ToString() + "'";
                SqlDataAdapter ad2 = new SqlDataAdapter(q2, conn);
                DataTable d2 = new DataTable();
                ad2.Fill(d2);
                BestIncomeCat.Text = d2.Rows[0][0].ToString();
            }catch ( Exception ex) { }
                conn.Close();
        }
        public void GotoBestExpenseCategory()
        {
            try
            {
                conn.Open();
                string query = "select max(ExpenseAmt) from Expenses where ExpenseUser='" + Login.User + "'";


                SqlDataAdapter ad = new SqlDataAdapter(query, conn);
                DataTable adTable = new DataTable();
                ad.Fill(adTable);
                string q2 = "select ExpenseCat from Expenses where ExpenseAmt='" + adTable.Rows[0][0].ToString() + "'";
                SqlDataAdapter ad2 = new SqlDataAdapter(q2, conn);
                DataTable d2 = new DataTable();
                ad2.Fill(d2);
                BestExpenseCat.Text = d2.Rows[0][0].ToString();
            }catch (Exception ex) { }

                conn.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            DashBoard obj= new DashBoard();
            obj.Show();
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
            Expense expense = new Expense();
            expense.Show(); 
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            View_Income obj= new View_Income();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewExpense obj= new ViewExpense();
            obj.Show();
                this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TotalExpense_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Login l=new Login();
            l.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MaxIncome_Click(object sender, EventArgs e)
        {

        }
    }
}
