namespace CareConnectLog
{
    partial class CareConnectRegister
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
            this.label2 = new System.Windows.Forms.Label();
            this.UsernameTxt = new System.Windows.Forms.TextBox();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ConfirmPasswordTXT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ShowPassswordCheckBx = new System.Windows.Forms.CheckBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.PriceTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.DescriptionrichTxt = new System.Windows.Forms.RichTextBox();
            this.LocationTxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.servicetypetxt = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(100, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Get Started";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.UsernameTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsernameTxt.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTxt.Location = new System.Drawing.Point(36, 249);
            this.UsernameTxt.Multiline = true;
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.Size = new System.Drawing.Size(287, 30);
            this.UsernameTxt.TabIndex = 2;
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.PasswordTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordTxt.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTxt.Location = new System.Drawing.Point(36, 322);
            this.PasswordTxt.Multiline = true;
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.PasswordChar = '•';
            this.PasswordTxt.Size = new System.Drawing.Size(287, 30);
            this.PasswordTxt.TabIndex = 4;
            this.PasswordTxt.TextChanged += new System.EventHandler(this.PasswordTXT_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ConfirmPasswordTXT
            // 
            this.ConfirmPasswordTXT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.ConfirmPasswordTXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConfirmPasswordTXT.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPasswordTXT.Location = new System.Drawing.Point(36, 395);
            this.ConfirmPasswordTXT.Multiline = true;
            this.ConfirmPasswordTXT.Name = "ConfirmPasswordTXT";
            this.ConfirmPasswordTXT.PasswordChar = '•';
            this.ConfirmPasswordTXT.Size = new System.Drawing.Size(287, 30);
            this.ConfirmPasswordTXT.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Confirm Password:";
            // 
            // ShowPassswordCheckBx
            // 
            this.ShowPassswordCheckBx.AutoSize = true;
            this.ShowPassswordCheckBx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShowPassswordCheckBx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowPassswordCheckBx.Location = new System.Drawing.Point(36, 431);
            this.ShowPassswordCheckBx.Name = "ShowPassswordCheckBx";
            this.ShowPassswordCheckBx.Size = new System.Drawing.Size(119, 21);
            this.ShowPassswordCheckBx.TabIndex = 7;
            this.ShowPassswordCheckBx.Text = "Show Password";
            this.ShowPassswordCheckBx.UseVisualStyleBackColor = true;
            this.ShowPassswordCheckBx.CheckedChanged += new System.EventHandler(this.ShowPassswordCheckBx_CheckedChanged);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.DarkRed;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(196, 445);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(287, 37);
            this.btnRegister.TabIndex = 8;
            this.btnRegister.Text = "REGISTER";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.DarkRed;
            this.btnClear.Location = new System.Drawing.Point(196, 488);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(287, 37);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 541);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Already Have an Account?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(288, 567);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Back to LOGIN";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // PriceTxt
            // 
            this.PriceTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.PriceTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PriceTxt.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.PriceTxt.Location = new System.Drawing.Point(372, 322);
            this.PriceTxt.Multiline = true;
            this.PriceTxt.Name = "PriceTxt";
            this.PriceTxt.Size = new System.Drawing.Size(287, 30);
            this.PriceTxt.TabIndex = 47;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(369, 292);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 17);
            this.label8.TabIndex = 46;
            this.label8.Text = "Price:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(369, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 17);
            this.label9.TabIndex = 44;
            this.label9.Text = "Service Description:";
            // 
            // DescriptionrichTxt
            // 
            this.DescriptionrichTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.DescriptionrichTxt.Location = new System.Drawing.Point(372, 170);
            this.DescriptionrichTxt.Name = "DescriptionrichTxt";
            this.DescriptionrichTxt.Size = new System.Drawing.Size(287, 109);
            this.DescriptionrichTxt.TabIndex = 48;
            this.DescriptionrichTxt.Text = "";
            // 
            // LocationTxt
            // 
            this.LocationTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.LocationTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LocationTxt.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocationTxt.Location = new System.Drawing.Point(372, 395);
            this.LocationTxt.Multiline = true;
            this.LocationTxt.Name = "LocationTxt";
            this.LocationTxt.Size = new System.Drawing.Size(287, 30);
            this.LocationTxt.TabIndex = 50;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(369, 365);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 17);
            this.label10.TabIndex = 49;
            this.label10.Text = "Location:";
            // 
            // NameTxt
            // 
            this.NameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.NameTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameTxt.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTxt.Location = new System.Drawing.Point(36, 170);
            this.NameTxt.Multiline = true;
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(287, 30);
            this.NameTxt.TabIndex = 52;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(33, 140);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(135, 17);
            this.label11.TabIndex = 51;
            this.label11.Text = "First and Last Name:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(50, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(230, 13);
            this.label12.TabIndex = 54;
            this.label12.Text = "System of Providing Assistance and Services";
            this.label12.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Maroon;
            this.label13.Location = new System.Drawing.Point(50, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 18);
            this.label13.TabIndex = 53;
            this.label13.Text = "CareConnect";
            this.label13.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Image = global::CareConnectLog.Properties.Resources.Arrioch_Whack_Whack_Windows_Live_Messenger_256;
            this.pictureBox2.Location = new System.Drawing.Point(1, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 55;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // servicetypetxt
            // 
            this.servicetypetxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.servicetypetxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.servicetypetxt.FormattingEnabled = true;
            this.servicetypetxt.Items.AddRange(new object[] {
            "-->babysitting",
            "-->learning aid",
            "-->psychologist",
            "-->freelancing",
            "other..."});
            this.servicetypetxt.Location = new System.Drawing.Point(372, 92);
            this.servicetypetxt.Name = "servicetypetxt";
            this.servicetypetxt.Size = new System.Drawing.Size(287, 25);
            this.servicetypetxt.TabIndex = 57;
            this.servicetypetxt.SelectedIndexChanged += new System.EventHandler(this.typetxt_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(369, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 17);
            this.label7.TabIndex = 56;
            this.label7.Text = "Service Type:";
            this.label7.Click += new System.EventHandler(this.label7_Click_1);
            // 
            // CareConnectRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(706, 598);
            this.Controls.Add(this.servicetypetxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.NameTxt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.LocationTxt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.DescriptionrichTxt);
            this.Controls.Add(this.PriceTxt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.ShowPassswordCheckBx);
            this.Controls.Add(this.ConfirmPasswordTXT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PasswordTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UsernameTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CareConnectRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.btnRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UsernameTxt;
        private System.Windows.Forms.TextBox PasswordTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ConfirmPasswordTXT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ShowPassswordCheckBx;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox PriceTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox DescriptionrichTxt;
        private System.Windows.Forms.TextBox LocationTxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox NameTxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox servicetypetxt;
        private System.Windows.Forms.Label label7;
    }
}

