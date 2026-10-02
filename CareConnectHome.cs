using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CareConnectLog
{
    public partial class CareConnectHome : Form
    {

        public CareConnectHome()
        {
            InitializeComponent();
        }

        private void CareConnectHome_Load(object sender, EventArgs e)
        {

        }

        private void btnUser_MouseHover(object sender, EventArgs e)
        {
            btnUser.BackColor = System.Drawing.Color.DarkRed;
            btnUser.ForeColor = System.Drawing.Color.WhiteSmoke;
        }
         private void btnUser_MouseLeave(object sender, EventArgs e)
        {
            btnUser.BackColor = System.Drawing.Color.WhiteSmoke;
            btnUser.ForeColor = System.Drawing.Color.DarkRed;
        }
        private void btnSupportProvider_MouseHover(object sender, EventArgs e)
        {
            btnSupportProvider.BackColor = System.Drawing.Color.DarkRed;
            btnSupportProvider.ForeColor = System.Drawing.Color.WhiteSmoke;
        }

        private void btnSupportProvider_MouseLeave(object sender, EventArgs e)
        {
            btnSupportProvider.BackColor = System.Drawing.Color.WhiteSmoke;
            btnSupportProvider.ForeColor = System.Drawing.Color.DarkRed;
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.ForeColor = System.Drawing.Color.Maroon;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = System.Drawing.Color.WhiteSmoke;
        }

        private void btnSupportProvider_Click(object sender, EventArgs e)
        {
            new CareConnectLogin().Show();
            this.Hide();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            new UserLogIn().Show();
            this.Hide();
        }

        
    }
}
