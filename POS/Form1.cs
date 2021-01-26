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
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=SHAAHU;Initial Catalog=posSystem;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        

        private void logIn_Click(object sender, EventArgs e)
        {
            string name = userName.Text;
            string pass = passWord.Text;

            con.Open();

            string query = "SELECT * FROM users WHERE userName = '" + name + "' AND password = '" + pass + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader read = cmd.ExecuteReader();

            if (read.Read())
            {
                POS pos = new POS(name);
                pos.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid User Name or Password !");
            }

            con.Close();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void username_enter(object sender, EventArgs e)
        {
            if (userName.Text == "User Name")
            {
                userName.Text = "";
                userName.ForeColor = Color.Black;
            }
        }

        private void username_leave(object sender, EventArgs e)
        {
            if(userName.Text == "")
            {
                userName.Text = "User Name";
                userName.ForeColor = Color.Silver;
            }
        }
        private void password_enter(object sender, EventArgs e)
        {
            if (passWord.Text == "Password")
            {
                passWord.Text = "";
                passWord.PasswordChar = '*';
                passWord.ForeColor = Color.Black;
            }
        }

        private void password_leave(object sender, EventArgs e)
        {
            if (passWord.Text == "")
            {
                passWord.Text = "Password";
                passWord.ForeColor = Color.Silver;
            }
        }

        private void passWord_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                logIn.Focus();
            }
        }

        private void userName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                passWord.Focus();
            }
        }

        
    }
}
