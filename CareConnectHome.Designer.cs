namespace CareConnectLog
{
    partial class CareConnectHome
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
            this.btnSupportProvider = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSupportProvider
            // 
            this.btnSupportProvider.BackColor = System.Drawing.Color.White;
            this.btnSupportProvider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupportProvider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupportProvider.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSupportProvider.Location = new System.Drawing.Point(391, 331);
            this.btnSupportProvider.Name = "btnSupportProvider";
            this.btnSupportProvider.Size = new System.Drawing.Size(287, 37);
            this.btnSupportProvider.TabIndex = 35;
            this.btnSupportProvider.Text = "SUPPORT PROVIDER";
            this.btnSupportProvider.UseVisualStyleBackColor = false;
            this.btnSupportProvider.MouseLeave += new System.EventHandler(this.btnSupportProvider_MouseLeave);
            this.btnSupportProvider.Click += new System.EventHandler(this.btnSupportProvider_Click);
            this.btnSupportProvider.MouseHover += new System.EventHandler(this.btnSupportProvider_MouseHover);
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUser.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.btnUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkRed;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.ForeColor = System.Drawing.Color.DarkRed;
            this.btnUser.Location = new System.Drawing.Point(391, 288);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(287, 37);
            this.btnUser.TabIndex = 34;
            this.btnUser.Text = "USER";
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.MouseLeave += new System.EventHandler(this.btnUser_MouseLeave);
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            this.btnUser.MouseHover += new System.EventHandler(this.btnUser_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Baskerville Old Face", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(39, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 36);
            this.label1.TabIndex = 36;
            this.label1.Text = "CareConnect";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 15);
            this.label2.TabIndex = 37;
            this.label2.Text = "System of Providing Assistance and Services";
            this.label2.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            this.label2.MouseHover += new System.EventHandler(this.label2_MouseHover);
            // 
            // CareConnectHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CareConnectLog.Properties.Resources.cc2;
            this.ClientSize = new System.Drawing.Size(1025, 607);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSupportProvider);
            this.Controls.Add(this.btnUser);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CareConnectHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CareConnectHome";
            this.Load += new System.EventHandler(this.CareConnectHome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSupportProvider;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;


    }
}