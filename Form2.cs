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
    public partial class Form2 : Form
    {
        private int nextId = 1; // Početni ID korisnika

        public Form2()
        {
            InitializeComponent();
            LoadNextId();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "other...")
            {
                comboBox1.Text = "";
                comboBox1.DropDownStyle = ComboBoxStyle.DropDown; 
            }
        }

        //------------funkcija za hashiranje lozinke------------------------------------------------------------------------------//
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
            string rawPassword = PasswordTxt.Text.Trim();
            string conpassword = ConfirmPasswordTXT.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(rawPassword) || string.IsNullOrEmpty(conpassword))
            {
                MessageBox.Show("Please enter both username and password.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (rawPassword != conpassword)
                {
                    MessageBox.Show("Passwords do not match. Please re-enter!", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PasswordTxt.Clear();
                    ConfirmPasswordTXT.Clear();
                    return;
                }
            }

            /*
            try
            {
                using (StreamWriter sw = new StreamWriter("users.txt", true))
                {
                    sw.WriteLine("ID--> " + nextId + ": " + "\n" + "user: " + username  + "\n" + "password: "+ password + "\n" );
                }

                MessageBox.Show("Your Account has been Successfully Created !", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nextId++;

                NameTxt.Clear();
                UsernameTxt.Clear();
                PasswordTxt.Clear();
                ConfirmPasswordTXT.Clear();
                AddressTxt.Clear();
                ContactTxt.Clear();
                NameTxt.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving data: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
            //--------------------------------------------------baza-----------------------------------------------------------//

            // Hashiraj lozinku nakon validacije
            string password = HashPassword(rawPassword);

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";
            string query = "INSERT INTO UserAccounts (FullName, UserNameField, UserPassword, UserAddress, UserContact, UserType) " +
               "VALUES (?, ?, ?, ?, ?, ?)";


            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", NameTxt.Text.Trim());
                    command.Parameters.AddWithValue("?", username);
                    command.Parameters.AddWithValue("?", password);
                    command.Parameters.AddWithValue("?", AddressTxt.Text.Trim());
                    command.Parameters.AddWithValue("?", ContactTxt.Text.Trim());
                    command.Parameters.AddWithValue("?", comboBox1.Text.Trim()); // User type


                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Your Account has been Successfully Created !", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        command.CommandText = "SELECT @@IDENTITY";
                        command.CommandType = CommandType.Text;
                        command.Parameters.Clear();

                        int newUserId = 0;
                        using (OleDbCommand idCommand = new OleDbCommand("SELECT @@IDENTITY", connection))
                        {
                            object result = idCommand.ExecuteScalar();
                            if (result != null)
                            {
                                newUserId = Convert.ToInt32(result);
                                // sad možeš newUserId koristiti gdje ti treba
                            }
                        }


                        NameTxt.Clear();
                        UsernameTxt.Clear();
                        PasswordTxt.Clear();
                        ConfirmPasswordTXT.Clear();
                        AddressTxt.Clear();
                        ContactTxt.Clear();
                        NameTxt.Focus();
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
            if (File.Exists("users.txt")) 
            {
                try
                {
                    string[] lines = File.ReadAllLines("users.txt"); 
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error while loading ID: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

         

         private void ShowPassswordCheckBx_CheckedChanged_1(object sender, EventArgs e)
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
             pictureBox1.Hide();
             AddressTxt.Clear();
             ContactTxt.Clear();
             
         }

         private void label6_Click(object sender, EventArgs e)
         {
             new UserLogIn().Show();
             this.Hide();
         }

         private void pictureBox2_Click(object sender, EventArgs e)
         {
             new CareConnectHome().Show();
             this.Hide();
         }
        }
    }

