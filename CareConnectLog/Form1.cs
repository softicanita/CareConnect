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
    public partial class CareConnectRegister : Form
    {
        private int nextId = 1;
        string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";

        public CareConnectRegister()
        {
            InitializeComponent();
            NameTxt.Focus();
            LoadNextId(); 
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PasswordTXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Load(object sender, EventArgs e)
        {

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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = UsernameTxt.Text.Trim();
    string password = PasswordTxt.Text.Trim();
    string conpassword = ConfirmPasswordTXT.Text.Trim();

    string name = NameTxt.Text.Trim();
    string serviceType = servicetypetxt.SelectedItem.ToString(); 
    string price = PriceTxt.Text.Trim();
    string location = LocationTxt.Text.Trim();
    string description = DescriptionrichTxt.Text.Trim();

    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(conpassword))
    {
        if (password != conpassword)
        {
            MessageBox.Show("Passwords do not match. Please re-enter!", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            PasswordTxt.Clear();
            ConfirmPasswordTXT.Clear();
            return;
        }
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(serviceType) || string.IsNullOrEmpty(price) || string.IsNullOrEmpty(location))
        {
            MessageBox.Show("All fields must be filled in.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
    }
    else
    {
        MessageBox.Show("Please enter both username and password.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    string hashedPassword = HashPassword(password);

    using (OleDbConnection conn = new OleDbConnection(connStr))
    {
        string query1 = "INSERT INTO ProviderAccounts (ProviderName, ProviderUsername, ProviderPassword, ServiceType, ServiceDescription, ServicePrice, ServiceLocation) " +
                        "VALUES (?, ?, ?, ?, ?, ?, ?)";

        using (OleDbCommand cmd1 = new OleDbCommand(query1, conn))
        {
            cmd1.Parameters.AddWithValue("?", name);
            cmd1.Parameters.AddWithValue("?", username);
            cmd1.Parameters.AddWithValue("?", hashedPassword);
            cmd1.Parameters.AddWithValue("?", serviceType);
            cmd1.Parameters.AddWithValue("?", description);
            cmd1.Parameters.AddWithValue("?", price);
            cmd1.Parameters.AddWithValue("?", location);

            try
            {
                conn.Open();
                cmd1.ExecuteNonQuery();

                // Dohvati ProviderID tog korisnika
                string selectQuery = "SELECT ProviderID FROM ProviderAccounts WHERE ProviderUsername = ?";
                using (OleDbCommand selectCmd = new OleDbCommand(selectQuery, conn))
                {
                    selectCmd.Parameters.AddWithValue("?", username);

                    object result = selectCmd.ExecuteScalar();
                    if (result != null)
                    {
                        int providerId = Convert.ToInt32(result);

                        string query2 = "INSERT INTO ServiceDetails (ServiceName, ServicePrice, ServiceLocation, ProviderName, ProviderID) " +
                 "VALUES (?, ?, ?, ?, ?)";


                        using (OleDbCommand cmd2 = new OleDbCommand(query2, conn))
                        {
                            cmd2.Parameters.AddWithValue("?", serviceType);
                            cmd2.Parameters.AddWithValue("?", price);
                            cmd2.Parameters.AddWithValue("?", location);
                            cmd2.Parameters.AddWithValue("?", name);  // Dodajemo ProviderName kao parametar
                            cmd2.Parameters.AddWithValue("?", providerId);
                           

                            cmd2.ExecuteNonQuery();
                        }


                        MessageBox.Show("Your Account has been Successfully Created!", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear fields
                        NameTxt.Clear();
                        UsernameTxt.Clear();
                        PasswordTxt.Clear();
                        ConfirmPasswordTXT.Clear();
                        DescriptionrichTxt.Clear();
                        PriceTxt.Clear();
                        LocationTxt.Clear();
                        servicetypetxt.SelectedIndex = -1;
                        NameTxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Error: Provider ID not found after insert.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving to database: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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

        private void ShowPassswordCheckBx_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassswordCheckBx.Checked)
            {
                PasswordTxt.PasswordChar = '\0';
                ConfirmPasswordTXT.PasswordChar = '\0';
            }
            else
            {
                PasswordTxt.PasswordChar = '•';
                ConfirmPasswordTXT.PasswordChar = '•';
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            NameTxt.Clear();
            UsernameTxt.Clear();
            PasswordTxt.Clear();
            ConfirmPasswordTXT.Clear();
            DescriptionrichTxt.Clear();
            PriceTxt.Clear();
            LocationTxt.Clear();
            UsernameTxt.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new CareConnectLogin().Show();
            this.Hide();
        }

        

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new CareConnectHome().Show();
            this.Hide();
        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void typetxt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddService(int providerId, string serviceName, decimal servicePrice, string serviceLocation)
        {
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // Dohvatimo ProviderName za dati ProviderID
                    string getProviderNameQuery = "SELECT ProviderName FROM ProviderAccounts WHERE ID = ?";
                    string providerName = "";

                    using (OleDbCommand cmd = new OleDbCommand(getProviderNameQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", providerId);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            providerName = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Provider not found.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Ubacivanje podataka u ServiceDetails
                    string insertQuery = "INSERT INTO ServiceDetails (ProviderID, ProviderName, ServiceName, ServicePrice, ServiceLocation) VALUES (?, ?, ?, ?, ?)";

                    using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@ProviderID", providerId);
                        insertCmd.Parameters.AddWithValue("@ProviderName", providerName);
                        insertCmd.Parameters.AddWithValue("@ServiceName", serviceName);
                        insertCmd.Parameters.AddWithValue("@ServicePrice", servicePrice);
                        insertCmd.Parameters.AddWithValue("@ServiceLocation", serviceLocation);

                        insertCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Service successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding service: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
       
    

