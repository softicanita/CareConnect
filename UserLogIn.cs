using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Data.OleDb;

namespace CareConnectLog
{
    public partial class UserLogIn : Form
    {
        private int nextId = 1; // Početni ID korisnika
        public static int LoggedInUserID { get; private set; } // Globalna varijabla u formi ili klasi

        public UserLogIn()
        {
            InitializeComponent();
            // LoadNextId(); // Isključeno ako nije potrebno
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = UsernameTXT.Text.Trim();
            string password = PasswordTXT.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string hashedPassword = HashPassword(password); // Hashiranje lozinke prije provjere
                string userID = ValidateUser(username, hashedPassword);  // Dobijamo UserID kao string iz ValidateUser funkcije.

                if (!string.IsNullOrEmpty(userID))  // Provjeravamo da li je userID validan
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoggedInUserID = int.Parse(userID);  // Spremi UserID za dalje korišćenje u aplikaciji.

                    mainform form = new mainform(userID);  // Prosleđujemo userID glavnoj formi.
                    form.Show();
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

        private string ValidateUser(string username, string hashedPassword)
        {
            string userID = null;
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT UserID FROM UserAccounts WHERE UserNameField = ? AND UserPassword = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserNameField", username);
                        cmd.Parameters.AddWithValue("@UserPassword", hashedPassword); // Koristimo hashiranu lozinku

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                            userID = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return userID;
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

        private void ShowPassswordCheckBx_CheckedChanged_1(object sender, EventArgs e)
        {
            PasswordTXT.PasswordChar = ShowPassswordCheckBx.Checked ? '\0' : '•';
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            UsernameTXT.Clear();
            PasswordTXT.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new CareConnectHome().Show();
            this.Hide();
        }

        private void UserLogIn_Load(object sender, EventArgs e)
        {
        }
    }
}
