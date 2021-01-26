using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class billCompleat : Form
    {
        float totalAmount;
        int receivedAmount;
        float balance;
        int exit;

        public billCompleat( float totalAmount , int exit)
        {
            InitializeComponent();
            this.totalAmount = totalAmount;
            this.exit = exit;
        }

        private void billCompleat_Load(object sender, EventArgs e)
        {
            totalamount.Text = totalAmount.ToString();
        }

        private void receivedamount_Leave(object sender, EventArgs e)
        {
            balance = int.Parse(receivedamount.Text) - totalAmount;
            balancelbl.Text = balance.ToString();
        }
        
        private void receivedamount_TextChanged(object sender, EventArgs e)
        {

        }

        private void ok_Click(object sender, EventArgs e)
        {
            exit = 1;
            this.Close();
        }

        private void receivedamount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                ok.Focus();
            }
            //
        }

        private void ok_Enter(object sender, EventArgs e)
        {
            
        }

        private void billCompleat_Leave(object sender, EventArgs e)
        {
            
        }
    }
}
