namespace POS
{
    partial class exitCashier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.noOfBills = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.noOfBillsValue = new System.Windows.Forms.Label();
            this.totalBillAmountValue = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cashierNameValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // noOfBills
            // 
            this.noOfBills.AutoSize = true;
            this.noOfBills.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noOfBills.Location = new System.Drawing.Point(63, 216);
            this.noOfBills.Name = "noOfBills";
            this.noOfBills.Size = new System.Drawing.Size(86, 19);
            this.noOfBills.TabIndex = 0;
            this.noOfBills.Text = "No of Bills :";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Location = new System.Drawing.Point(435, 103);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(0, 19);
            this.date.TabIndex = 1;
            this.date.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Bill Amount :";
            // 
            // noOfBillsValue
            // 
            this.noOfBillsValue.AutoSize = true;
            this.noOfBillsValue.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noOfBillsValue.Location = new System.Drawing.Point(217, 214);
            this.noOfBillsValue.Name = "noOfBillsValue";
            this.noOfBillsValue.Size = new System.Drawing.Size(0, 19);
            this.noOfBillsValue.TabIndex = 3;
            // 
            // totalBillAmountValue
            // 
            this.totalBillAmountValue.AutoSize = true;
            this.totalBillAmountValue.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalBillAmountValue.Location = new System.Drawing.Point(217, 265);
            this.totalBillAmountValue.Name = "totalBillAmountValue";
            this.totalBillAmountValue.Size = new System.Drawing.Size(0, 19);
            this.totalBillAmountValue.TabIndex = 4;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(98, 102);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(121, 20);
            this.password.TabIndex = 5;
            this.password.Text = "password";
            this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.password_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(235, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 33);
            this.label2.TabIndex = 6;
            this.label2.Text = "End Report";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cashier Name : ";
            // 
            // cashierNameValue
            // 
            this.cashierNameValue.AutoSize = true;
            this.cashierNameValue.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashierNameValue.Location = new System.Drawing.Point(217, 170);
            this.cashierNameValue.Name = "cashierNameValue";
            this.cashierNameValue.Size = new System.Drawing.Size(0, 19);
            this.cashierNameValue.TabIndex = 8;
            // 
            // exitCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(606, 566);
            this.Controls.Add(this.cashierNameValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.password);
            this.Controls.Add(this.totalBillAmountValue);
            this.Controls.Add(this.noOfBillsValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.date);
            this.Controls.Add(this.noOfBills);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "exitCashier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.exitCashier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label noOfBills;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label noOfBillsValue;
        private System.Windows.Forms.Label totalBillAmountValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label cashierNameValue;
        private System.Windows.Forms.TextBox password;
    }
}