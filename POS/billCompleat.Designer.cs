namespace POS
{
    partial class billCompleat
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
            this.label1 = new System.Windows.Forms.Label();
            this.totalamount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.receivedamount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.balancelbl = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Amount :    Rs.";
            // 
            // totalamount
            // 
            this.totalamount.AutoSize = true;
            this.totalamount.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalamount.Location = new System.Drawing.Point(272, 40);
            this.totalamount.Name = "totalamount";
            this.totalamount.Size = new System.Drawing.Size(0, 23);
            this.totalamount.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Received Amount  :    Rs.";
            // 
            // receivedamount
            // 
            this.receivedamount.Font = new System.Drawing.Font("Book Antiqua", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receivedamount.Location = new System.Drawing.Point(270, 93);
            this.receivedamount.Name = "receivedamount";
            this.receivedamount.Size = new System.Drawing.Size(158, 26);
            this.receivedamount.TabIndex = 3;
            this.receivedamount.TextChanged += new System.EventHandler(this.receivedamount_TextChanged);
            this.receivedamount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.receivedamount_KeyDown);
            this.receivedamount.Leave += new System.EventHandler(this.receivedamount_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(129, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Balance :    Rs.";
            // 
            // balancelbl
            // 
            this.balancelbl.AutoSize = true;
            this.balancelbl.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balancelbl.Location = new System.Drawing.Point(272, 148);
            this.balancelbl.Name = "balancelbl";
            this.balancelbl.Size = new System.Drawing.Size(0, 23);
            this.balancelbl.TabIndex = 5;
            // 
            // ok
            // 
            this.ok.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ok.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ok.Location = new System.Drawing.Point(190, 204);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(108, 33);
            this.ok.TabIndex = 6;
            this.ok.Text = "Ok";
            this.ok.UseVisualStyleBackColor = false;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            this.ok.Enter += new System.EventHandler(this.ok_Enter);
            // 
            // billCompleat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 264);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.balancelbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.receivedamount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.totalamount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "billCompleat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.billCompleat_Load);
            this.Leave += new System.EventHandler(this.billCompleat_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalamount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox receivedamount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label balancelbl;
        private System.Windows.Forms.Button ok;
    }
}