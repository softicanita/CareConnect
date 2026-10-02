using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Security.Cryptography;

namespace CareConnectLog
{
    public partial class CareConnectLogin : Form
    {
        private int nextId = 1; 

        public CareConnectLogin()
        {
            InitializeComponent();
            LoadNextId(); 
        }

        private void CareConnectLog2_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = UsernameTXT.Text.Trim();
            string password = PasswordTXT.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Logging in Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (ValidateUser(username, password))
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    new mainform2().Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

        }
        private void LoadNextId()
        {
            if (File.Exists("providers.txt"))
            {
                try
                {
                    string[] lines = File.ReadAllLines("providers.txt");
                    if (lines.Length > 0)
                    {
                        string lastLine = lines[lines.Length - 1];
                        string[] parts = lastLine.Split(',');
                        if (parts.Length > 0)
                        {
                            int lastId;
                            if (int.TryParse(parts[0].Trim(), out lastId))
                            {
                                nextId = lastId + 1;
                            }
                        }
                    }
                }
                catch 
                {
                    MessageBox.Show("Error while loading ID: ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }

        private bool ValidateUser(string username, string password)
        {
            /*if (!File.Exists("providers.txt"))
            {
                return false; 
            }

            string[] lines = File.ReadAllLines("providers.txt");
            string currentUsername = string.Empty;
            string currentPassword = string.Empty;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("provider:"))
                {
                    currentUsername = lines[i].Substring(9).Trim();
                }
                if (lines[i].StartsWith("password:"))
                {
                    currentPassword = lines[i].Substring(9).Trim(); 
                }

           
                if (!string.IsNullOrEmpty(currentUsername) && !string.IsNullOrEmpty(currentPassword))
                {
                    if (currentUsername == username && currentPassword == password)
                    {
                        return true;
                    }

                    currentUsername = string.Empty;
                    currentPassword = string.Empty;
                }
            }

            return false;*/

            string hashedPassword = HashPassword(password);

            using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;"))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM ProviderAccounts WHERE ProviderUsername = ? AND ProviderPassword = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", username);
                    cmd.Parameters.AddWithValue("?", hashedPassword);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void ShowPassswordCheckBx_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassswordCheckBx.Checked)
            {
                
                PasswordTXT.PasswordChar = '\0';
            }
            else
            {
                
                PasswordTXT.PasswordChar = '•';
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            UsernameTXT.Clear();
            PasswordTXT.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            new CareConnectRegister().Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new CareConnectHome().Show();
            this.Hide();
        }

       

    }
}
