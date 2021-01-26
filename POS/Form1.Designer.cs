namespace POS
{
    partial class Form1
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
            this.logIn = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.TextBox();
            this.passWord = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.RoyalBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(714, 41);
            this.label1.TabIndex = 0;
            this.label1.Tag = "";
            // 
            // logIn
            // 
            this.logIn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.logIn.Location = new System.Drawing.Point(268, 293);
            this.logIn.Name = "logIn";
            this.logIn.Size = new System.Drawing.Size(162, 36);
            this.logIn.TabIndex = 3;
            this.logIn.Text = "Log In";
            this.logIn.UseVisualStyleBackColor = false;
            this.logIn.Click += new System.EventHandler(this.logIn_Click);
            // 
            // userName
            // 
            this.userName.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.ForeColor = System.Drawing.Color.Silver;
            this.userName.Location = new System.Drawing.Point(208, 121);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(286, 30);
            this.userName.TabIndex = 4;
            this.userName.Text = "User Name";
            this.userName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.userName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.userName.Enter += new System.EventHandler(this.username_enter);
            this.userName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userName_KeyDown);
            this.userName.Leave += new System.EventHandler(this.username_leave);
            // 
            // passWord
            // 
            this.passWord.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passWord.ForeColor = System.Drawing.Color.Silver;
            this.passWord.Location = new System.Drawing.Point(208, 204);
            this.passWord.Name = "passWord";
            this.passWord.Size = new System.Drawing.Size(286, 30);
            this.passWord.TabIndex = 5;
            this.passWord.Text = "Password";
            this.passWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passWord.Enter += new System.EventHandler(this.password_enter);
            this.passWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passWord_KeyDown);
            this.passWord.Leave += new System.EventHandler(this.username_leave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 400);
            this.Controls.Add(this.passWord);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.logIn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POS ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button logIn;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox passWord;
    }
}

