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

namespace POS
{
    public partial class cashier : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=SHAAHU;Initial Catalog=posSystem;Integrated Security=True");
        DateTime today = DateTime.Now;
        string username;
        string cashierName, cashierId;
        int invoiceNo;
        

        float totalAmountVariable = 0;
        int cusCount = 0;

        string startTime;

        int[] itemQty = new int [50];

        public cashier(string name)
        {
            InitializeComponent();
            username = name;
            totalAmount.Text = totalAmountVariable.ToString();
            
        }
        

        private void cashier_Load(object sender, EventArgs e)
        {
            
            con.Open();

            string query = "SELECT * FROM users WHERE userName = '" + username + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader read = cmd.ExecuteReader();

            if (read.Read())
            {
                
                cashierName = read.GetString(3).Trim();
                cashierId = read.GetString(2).Trim();

                name.Text = cashierName;
                cId.Text = cashierId;
                date.Text = today.ToShortDateString();
                time.Text = today.ToShortTimeString();
                
            }

            con.Close();

            getBillNo();
            invoiceNumber.Text = invoiceNo.ToString();


        }

        string checkEnter = "";
        int validCode = 0;
        private void cellLeave(object sender, DataGridViewCellEventArgs e)
        {

            //MessageBox.Show(checkEnter + "");
            

            con.Open();


            int irow = dataGridView2.CurrentCell.RowIndex;

            

            string colno = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex.ToString();
            string rowno = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].RowIndex.ToString();

            string code = dataGridView2.Rows[e.RowIndex].Cells[1].EditedFormattedValue.ToString();
            string count = dataGridView2.Rows[e.RowIndex].Cells[4].EditedFormattedValue.ToString();


            //MessageBox.Show(count+"    "+ colno);
            


            if (int.Parse(colno) == 1)
            {

                if (code != "")
                {
                    //invalideCode = true;
                    SqlCommand cmd = new SqlCommand("SELECT * FROM itemData WHERE itemCode = '" + code + "' ", con);
                    SqlDataReader read = cmd.ExecuteReader();

                    if (dataGridView2.Rows[irow].Cells[7].EditedFormattedValue.ToString() != "")
                    {
                        string codeNo = dataGridView2.Rows[e.RowIndex].Cells[1].EditedFormattedValue.ToString();
                        dataGridView2.Rows[int.Parse(rowno)].Cells[1].Value = codeNo;
                    }
                    else if (read.Read())
                    {
                        if (read.GetInt32(3) > 0)
                        {
                            dataGridView2.Rows[e.RowIndex].Cells[2].Value = read.GetString(1);
                            dataGridView2.Rows[e.RowIndex].Cells[3].Value = read.GetSqlMoney(2);
                            dataGridView2.Rows[int.Parse(rowno)].Cells[5].Value = 0;
                            dataGridView2.Rows[int.Parse(rowno)].Cells[6].Value = 0;
                            label8.Visible = true;
                            label8.Text = "Stock in hand : " + read.GetInt32(3);
                            read.Close();
                        }
                        else
                        {
                            MessageBox.Show("Zero Stock !");
                            dataGridView2.Rows[e.RowIndex].Cells[1].Value = "";
                            validCode = 1;
                        }
                        

                    }
                    else
                    {
                        MessageBox.Show("Invalide Code");
                        dataGridView2.Rows[e.RowIndex].Cells[1].Value = "";
                        validCode = 1;

                    }
                }
                else
                {
                    //MessageBox.Show("Invalide Code");
                    dataGridView2.Rows[e.RowIndex].Cells[1].Value = "";
                    validCode = 1;

                }

            }

            if (int.Parse(colno) == 4)
            {
                if(validCode == 0)
                {

                    string disV = dataGridView2.Rows[e.RowIndex].Cells[5].EditedFormattedValue.ToString();
                    string disP = dataGridView2.Rows[e.RowIndex].Cells[6].EditedFormattedValue.ToString();

                    string priced = dataGridView2.Rows[e.RowIndex].Cells[3].EditedFormattedValue.ToString();

                    //MessageBox.Show("" + priced);

                    if (int.Parse(disV) == 0 && int.Parse(disP) > 0)
                    {
                        dataGridView2.Rows[e.RowIndex].Cells[7].Value = ((float.Parse(priced) * int.Parse(count)) - ((float.Parse(priced) * int.Parse(count)) / 100) * int.Parse(disP));
                        string total = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                        totalAmountVariable += float.Parse(total);

                        //MessageBox.Show(totalAmountVariable + "");
                    }
                    else if (int.Parse(disP) == 0 && int.Parse(disV) > 0)
                    {
                        dataGridView2.Rows[e.RowIndex].Cells[7].Value = ((float.Parse(priced) * int.Parse(count)) - int.Parse(disV));
                        string total = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                        totalAmountVariable += float.Parse(total);
                        //MessageBox.Show(totalAmountVariable + "");
                    }
                    else if (int.Parse(disP) > 0 && int.Parse(disV) > 0)
                    {
                        dataGridView2.Rows[e.RowIndex].Cells[7].Value = ((float.Parse(priced) * int.Parse(count)) - int.Parse(disV)) - (((float.Parse(priced) * int.Parse(count)) / 100) * int.Parse(disP));
                        string total = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                        totalAmountVariable += float.Parse(total);

                    }
                    else
                    {
                        dataGridView2.Rows[e.RowIndex].Cells[7].Value = float.Parse(priced) * int.Parse(count);
                        string total = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                        totalAmountVariable += float.Parse(total);
                        //MessageBox.Show(totalAmountVariable + "");
                    }
                    label8.Visible = false;
                    totalAmount.Text = totalAmountFun().ToString();

                }
                else if (dataGridView2.Rows[irow].Cells[7].EditedFormattedValue.ToString() != "")
                {
                    string disV = dataGridView2.Rows[e.RowIndex].Cells[5].EditedFormattedValue.ToString();
                    string disP = dataGridView2.Rows[e.RowIndex].Cells[6].EditedFormattedValue.ToString();

                    string priced = dataGridView2.Rows[e.RowIndex].Cells[3].EditedFormattedValue.ToString();

                    //MessageBox.Show("" + priced);

                    if (int.Parse(disV) == 0 && int.Parse(disP) > 0)
                    {
                        dataGridView2.Rows[e.RowIndex].Cells[7].Value = ((float.Parse(priced) * int.Parse(count)) - ((float.Parse(priced) * int.Parse(count)) / 100) * int.Parse(disP));
                        string total = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                        totalAmountVariable += float.Parse(total);

                        //MessageBox.Show(totalAmountVariable + "");
                    }
                    else if (int.Parse(disP) == 0 && int.Parse(disV) > 0)
                    {
                        dataGridView2.Rows[e.RowIndex].Cells[7].Value = ((float.Parse(priced) * int.Parse(count)) - int.Parse(disV));
                        string total = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                        totalAmountVariable += float.Parse(total);
                        //MessageBox.Show(totalAmountVariable + "");
                    }
                    else if (int.Parse(disP) > 0 && int.Parse(disV) > 0)
                    {
                        dataGridView2.Rows[e.RowIndex].Cells[7].Value = ((float.Parse(priced) * int.Parse(count)) - int.Parse(disV)) - (((float.Parse(priced) * int.Parse(count)) / 100) * int.Parse(disP));
                        string total = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                        totalAmountVariable += float.Parse(total);

                    }
                    else
                    {
                        dataGridView2.Rows[e.RowIndex].Cells[7].Value = float.Parse(priced) * int.Parse(count);
                        string total = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                        totalAmountVariable += float.Parse(total);
                    }
                    totalAmount.Text = totalAmountFun().ToString(); 
                }

            }

            if(int.Parse(colno) == 5 || int.Parse(colno) == 6)
            {
                
                string disV = dataGridView2.Rows[e.RowIndex].Cells[5].EditedFormattedValue.ToString();
                string disP = dataGridView2.Rows[e.RowIndex].Cells[6].EditedFormattedValue.ToString();

                string priced = dataGridView2.Rows[e.RowIndex].Cells[3].EditedFormattedValue.ToString();

                //MessageBox.Show("" + priced);

                if (int.Parse(disV) == 0 && int.Parse(disP) > 0)
                {
                    dataGridView2.Rows[e.RowIndex].Cells[7].Value = ((float.Parse(priced) * int.Parse(count)) - ((float.Parse(priced) * int.Parse(count)) / 100) * int.Parse(disP));
                    string total = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                    totalAmountVariable += float.Parse(total);
                    
                    //MessageBox.Show(totalAmountVariable + "");
                }
                else if (int.Parse(disP) == 0 && int.Parse(disV) > 0)
                {
                    dataGridView2.Rows[e.RowIndex].Cells[7].Value = ((float.Parse(priced) * int.Parse(count)) - int.Parse(disV));
                    string total = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                    totalAmountVariable += float.Parse(total);
                    //MessageBox.Show(totalAmountVariable + "");
                }
                else if (int.Parse(disP) > 0 && int.Parse(disV) > 0)
                {
                    dataGridView2.Rows[e.RowIndex].Cells[7].Value = ((float.Parse(priced) * int.Parse(count)) - int.Parse(disV)) - (((float.Parse(priced) * int.Parse(count)) / 100) * int.Parse(disP));
                    string total = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                    totalAmountVariable += float.Parse(total);

                }
                else
                {
                    dataGridView2.Rows[e.RowIndex].Cells[7].Value = float.Parse(priced) * int.Parse(count);
                    string total = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                    totalAmountVariable += float.Parse(total);
                }
                totalAmount.Text = totalAmountFun().ToString();

            }


            



            con.Close();
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cashier_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void invoiceNumber_Leave(object sender, EventArgs e)
        {
            DateTime today1 = DateTime.Now;
            startTime = today1.ToLongTimeString();
            //MessageBox.Show("startTime time : " + startTime);
        }

        private void dataGridView2_Enter(object sender, EventArgs e)
        {
            checkEnter = "table";
            validCode = 0;
            
        }

        private void invoiceNumber_Enter(object sender, EventArgs e)
        {
            checkEnter = "invoice";
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private float totalAmountFun ()
        {
            float sum = 0;
            bool state = true;
            for (int i = 0; state == true ; i++)
            {
                if (dataGridView2.Rows[i].Cells[7].EditedFormattedValue.ToString() != "")
                {

                    sum += float.Parse(dataGridView2.Rows[i].Cells[7].Value.ToString());
                }
                else
                {
                    state = false;
                }
            }
            return sum;
        }

        private void updateQty(int rowCount , int qty , string code , int row)
        {
            con.Open();
            //rowCount--;
            int qtyAfter;

            //MessageBox.Show(""+itemQty[0]);

            SqlCommand cmd = new SqlCommand("SELECT * FROM itemData WHERE itemCode = '" + code + "' ", con);
            SqlDataReader read = cmd.ExecuteReader();
            read.Read();
            int qtyBefor = read.GetInt32(3);
            read.Close();
            //MessageBox.Show("" + row +"    "+ rowCount);

            if (row < rowCount - 1)
            { 
                qtyAfter = (qtyBefor + itemQty[row]) - qty;

                //MessageBox.Show("" + qtyAfter + "   = "  + "("+ qtyBefor+" +"+ itemQty[row] +" )-"+qty +"");
                // stork + perValue - [irow][4]

                if (qtyAfter >= 0)
                {
                    SqlCommand cmd2 = new SqlCommand("UPDATE itemData SET Stock = " + qtyAfter + "  WHERE itemCode = '" + code + "' ", con);

                    if (cmd2.ExecuteNonQuery() > 0)
                    {
                        //MessageBox.Show("update ok");
                    }
                    else
                    {
                        //MessageBox.Show("Not that much quntity");
                    }
                }
                else
                {
                    MessageBox.Show("Not that much quntity");
                    con.Close();
                    label8.Visible = true;
                    dataGridView2.CurrentCell = dataGridView2[4, row];
                }

                
                

            }
            else if (row == rowCount-1)
            {
                qtyAfter = qtyBefor - qty;

                //MessageBox.Show("" + qtyAfter + "    " + row);
                // stork - [irow][4]

                if (qtyAfter >= 0)
                {
                    SqlCommand cmd3 = new SqlCommand("UPDATE itemData SET Stock = " + qtyAfter + "  WHERE itemCode = '" + code + "' ", con);

                    if (cmd3.ExecuteNonQuery() > 0)
                    {
                        //MessageBox.Show("update ok 2");
                    }
                    else
                    {
                        //MessageBox.Show("update no 2");
                    }
                }
                else
                {
                    MessageBox.Show("Not that much quntity");
                    con.Close();
                    label8.Visible = true;
                    dataGridView2.CurrentCell = dataGridView2[4, row];
                }
                
            }
            con.Close();

        }


        private int qtyArrayFill()
        {
            //int[] itemQty;
            int rowCount = 0;
            bool state = true;
            for (int i = 0; state == true; i++)
            {
                if (dataGridView2.Rows[i].Cells[7].EditedFormattedValue.ToString() != "")
                {
                    itemQty[i] = int.Parse(dataGridView2.Rows[i].Cells[4].Value.ToString());
                    //MessageBox.Show("" + itemQty[i]);
                }
                else
                {
                    state = false;
                }
            }
            //MessageBox.Show("" + rowCount);
            return rowCount;
        }


        private int rowCount()
        {
            //int[] itemQty;
            int rowCount = 0;
            bool state = true;
            for (int i = 0 ; state == true ; i++)
            {
                if (dataGridView2.Rows[i].Cells[7].EditedFormattedValue.ToString() != "")
                {

                    rowCount += 1;
                    //MessageBox.Show(dataGridView2.Rows[i].Cells[4].Value.ToString() + "" + i);
                }
                else
                {
                    state = false;
                }
            }
            //MessageBox.Show("" + rowCount);
            return rowCount;
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            //MessageBox.Show(checkEnter + "");

            if (keyData == Keys.Enter)
            {
                if ( checkEnter == "table")
                {
                    int irow = dataGridView2.CurrentCell.RowIndex;
                    int icolumn = dataGridView2.CurrentCell.ColumnIndex;
                    dataGridView2.Rows[irow].Cells[0].Value = irow+1;
                    


                    if (icolumn == dataGridView2.Columns.Count - 2)
                    {
                        //dataGridView2.Rows.Add();

                        dataGridView2.CurrentCell = dataGridView2[1, irow + 1];
                        
                        totalAmount.Text = totalAmountVariable.ToString();

                        

                    }
                    else
                    {
                        if (icolumn == 1)
                        {
                            if (validCode == 0)
                            {
                                if(dataGridView2.Rows[irow].Cells[4].EditedFormattedValue.ToString() == "")
                                {
                                    dataGridView2.Rows[irow].Cells[4].Value = 1;
                                }
                                dataGridView2.CurrentCell = dataGridView2[4, irow];
                            }
                            if (validCode == 1)
                            {
                                //MessageBox.Show("invalide code" + validCode);
                                dataGridView2.CurrentCell = dataGridView2[1, irow];
                                dataGridView2.Rows[irow].Cells[1].Value = "";
                                validCode = 0;
                            }
                            else if (dataGridView2.Rows[irow].Cells[7].EditedFormattedValue.ToString() != "")
                            {
                                
                                //MessageBox.Show("ok");
                                bool state = true;
                                for (int i = 1; state == true; i++)
                                {
                                    if (dataGridView2.Rows[irow + i].Cells[1].EditedFormattedValue.ToString() == "")
                                    {
                                        dataGridView2.CurrentCell = dataGridView2[1, irow + i];
                                        state = false;
                                    }

                                }

                            }
                            rowCount();
                        }
                       
                        else if (icolumn == 4)
                        {
                            bool state = true;
                            for (int i = 1; state == true; i++)
                            {
                                if (dataGridView2.Rows[irow + i].Cells[7].EditedFormattedValue.ToString() == "")
                                {
                                    string qty = dataGridView2.Rows[irow].Cells[4].Value.ToString();
                                    string code = dataGridView2.Rows[irow].Cells[1].Value.ToString();
                                    int row = irow;
                                    //updateQty(rowCount() , qty , code , irow);
                                    dataGridView2.CurrentCell = dataGridView2[1, irow + i];
                                    int qtyUp = int.Parse(dataGridView2.Rows[row].Cells[4].Value.ToString());
                                    updateQty(rowCount(), qtyUp, code, row) ;
                                    state = false;
                                    qtyArrayFill();
                                }

                            }
                            



                        }
                        /*else if (icolumn == 5)
                        {
                            bool state = true;
                            for (int i = 1; state == true; i++)
                            {
                                if (dataGridView2.Rows[irow + i].Cells[1].EditedFormattedValue.ToString() == "")
                                {
                                    dataGridView2.CurrentCell = dataGridView2[1, irow + i];
                                    state = false;
                                }

                            }
                        }*/
                        else if (icolumn == 6)
                        {
                            
                            dataGridView2.CurrentCell = dataGridView2[7, irow];
                                    
                        }
                        else if (icolumn == 5 || icolumn == 3 || icolumn == 7 || icolumn == 2)
                        {
                            bool state = true;
                            for (int i = 1; state == true ; i++)
                            {
                                if (dataGridView2.Rows[irow+i].Cells[1].EditedFormattedValue.ToString() == "")
                                {
                                    dataGridView2.CurrentCell = dataGridView2[1, irow + i];
                                    state = false;
                                }
                                
                            }

                            
                        }
                        else
                        {
                            dataGridView2.CurrentCell = dataGridView2[icolumn + 1, irow];
                        }

                    }
                    
                }

                if(checkEnter == "invoice")
                {
                    //MessageBox.Show("ok");
                    //review bill

                    if (invoiceNumber.Text == invoiceNo.ToString())
                    {
                        dataGridView2.Focus();
                        dataGridView2.CurrentCell = dataGridView2[1, 0];
                    }
                }

                return true;
            }

            if (keyData == Keys.Tab)
            {
                int icolumn = dataGridView2.CurrentCell.ColumnIndex; 
                int irow = dataGridView2.CurrentCell.RowIndex;

                if ( icolumn == 1 && dataGridView2.Rows[irow].Cells[1].EditedFormattedValue.ToString() == "" )
                {
                    //MessageBox.Show("22");
                    int count = -1;
                    for (int i = 0; i < dataGridView2.Rows.Count-1; i++)
                    {
                        //MessageBox.Show("22");
                        if (true)
                        {
                            //MessageBox.Show("23");
                            con.Open();

                            count += 1;
                            string id = dataGridView2.Rows[count].Cells[0].Value.ToString();
                            string code = dataGridView2.Rows[count].Cells[1].Value.ToString();
                            string discription = dataGridView2.Rows[count].Cells[2].Value.ToString();
                            string price = dataGridView2.Rows[count].Cells[3].Value.ToString();
                            string quantity = dataGridView2.Rows[count].Cells[4].Value.ToString();
                            string discountP = dataGridView2.Rows[count].Cells[6].Value.ToString();
                            string total = dataGridView2.Rows[count].Cells[7].Value.ToString();
                            string discountV = dataGridView2.Rows[count].Cells[5].Value.ToString();

                            

                            SqlCommand cmd = new SqlCommand("INSERT INTO invoiceDetailsGoods  VALUES (" + int.Parse(id) + " , " + int.Parse(code) + " , '" + discription + "' , " + float.Parse(price) + " , " + int.Parse(quantity) + " , " + int.Parse(discountP) + " , " + float.Parse(total) + " , '" + invoiceNumber.Text + "' , '" + today.ToShortDateString() + "' ,  " + int.Parse(discountV) + " )", con);

                            cmd.ExecuteNonQuery();

                            con.Close();
                        }

                        

                        if (i == dataGridView2.Rows.Count - 2) 
                        {
                            //MessageBox.Show("24");
                            con.Open();

                            DateTime today2 = DateTime.Now;
                            //MessageBox.Show(startTime + "   " + today2.ToLongTimeString());

                            SqlCommand cmd2 = new SqlCommand("INSERT INTO invoiceInfo VALUES ('" + invoiceNumber.Text + "' ,'" + today.ToShortDateString() + "' , '" + startTime + "' , '" + today2.ToLongTimeString() + "' , '" + cashierId + "' , '"+ totalAmountVariable + "' )", con);

                            cmd2.ExecuteNonQuery();

                            con.Close();

                            int exit = 0; 

                            dataGridView2.Rows.Clear();
                            //MessageBox.Show("Data Inserted !");
                            invoiceNo += 1;
                            invoiceNumber.Text = invoiceNo.ToString();
                            invoiceNumber.Focus();
                            startTime = "";

                            billCompleat billClose = new billCompleat(totalAmountVariable, exit);
                            billClose.Show();

                            totalAmountVariable = 0;
                            label7.Text = "Custermer Count : " + ++cusCount;

                        }
                    }

                }
                else
                {
                    MessageBox.Show("Invalide Code");
                    validCode = 1;
                }

                return true;
            }
            if (keyData == Keys.F12)
            {
                //MessageBox.Show("f12");

                con.Open();

        
                SqlCommand cmd3 = new SqlCommand("UPDATE billCount SET billCount = " + invoiceNo + "  WHERE id = '1' ", con);

                if (cmd3.ExecuteNonQuery() > 0)
                {
                    //MessageBox.Show("update ok 2");
                }
                else
                {
                    MessageBox.Show("Update Error ! Bill Count");
                }

                con.Close();

                exitCashier exitCachier  = new exitCashier(username);
                exitCachier.Show();

                //Form2 exitCachier = new Form2(username);
                //exitCachier.Show();

                return true;
            }

            else
                return base.ProcessCmdKey(ref msg, keyData);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void getBillNo()
        {
            con.Open();

            string query = "SELECT max(invoiceNo) FROM invoiceInfo";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader read = cmd.ExecuteReader();
            if(read.Read())
            {
               
                //MessageBox.Show("ok");
                
                invoiceNo = read.GetInt32(0) +1;
                
            }
            else
            {
               
                //MessageBox.Show("no");
            }
            

            con.Close();
        }
    }
}

