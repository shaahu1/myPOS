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

namespace POS
{
    public partial class exitCashier : Form
    {
        DateTime today = DateTime.Now;
        
        SqlConnection con = new SqlConnection(@"Data Source=SHAAHU;Initial Catalog=posSystem;Integrated Security=True");

        string userName;
        string passWord;
        string name;

        public exitCashier(string un)
        {
            InitializeComponent();
            userName = un;

            date.Text = today.ToShortDateString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void checkUser()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE password = '"+passWord+"' " , con);
            SqlDataReader read = cmd.ExecuteReader();
            read.Read();
            
            if (userName == read.GetString(0))
            {
                //MessageBox.Show("ok");
                password.Text = read.GetString(2);
                name = read.GetString(3);
            }
            else
            {
                MessageBox.Show("User Error !");
                this.Visible = false;
            }

            read.Close();

            con.Close();
            

        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {

            if (keyData == Keys.Enter)
            {

                passWord = password.Text;

                //MessageBox.Show(passWord);
                checkUser();
                fill();

                return true;
            }
            else if (keyData == Keys.Escape)
            {
                this.Visible = false;
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void exitCashier_Load(object sender, EventArgs e)
        {

        }

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        public void fill()
        {
            int count = 0;
            float total = 0;
            bool state = true;

            con.Open();

            MessageBox.Show(today.ToShortDateString());
            SqlCommand cmd = new SqlCommand("SELECT * FROM invoiceInfo WHERE invoiceDate = '"+ today.ToShortDateString() + "' ", con);
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                count++;
                //MessageBox.Show("" + float.Parse(read[5].ToString()));
                total += float.Parse(read[5].ToString());
            }

            read.Close();

            cashierNameValue.Text = name;
            noOfBillsValue.Text = count.ToString();
            totalBillAmountValue.Text = total.ToString();

        }
    }
}
