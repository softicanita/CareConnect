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


namespace CareConnectLog
{
    public partial class mainform2 : Form
    {
        public mainform2()
        {
            InitializeComponent();
            try
            {
                
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";
                string query = "SELECT UserFullName FROM ProviderAccess"; 
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    OleDbCommand command = new OleDbCommand(query, connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string userFullName = reader["UserFullName"].ToString();
                        usersbox.Items.Add(userFullName);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (File.Exists("providersAccess.txt"))
                {
                    string[] lines = File.ReadAllLines("providersAccess.txt");

                    foreach (string line in lines)
                    {
                        if (line.Trim().StartsWith("Name:")) 
                        {
                            string userName = line.Substring(5).Trim();
                            usersbox.Items.Add(userName); 
                        }
                    }
                }
                else
                {
                    MessageBox.Show("File services.txt not found.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch 
            {
                MessageBox.Show("Error loading file: ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            nametext.Clear();
            addresstext.Clear();
            contacttext.Clear();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new CareConnectHome().Show();
            this.Hide();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {

   string name = nametext.Text.Trim();
    string address = addresstext.Text.Trim();
    string contact = contacttext.Text.Trim();
    string userType = comboBox1.SelectedItem.ToString();
    DateTime appointmentDate = date1.Value.Date;
    string appointmentTime = time1.Value.ToString("hh:mm:ss tt");

    if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(contact) || string.IsNullOrEmpty(userType))
    {
        MessageBox.Show("All fields must be filled in.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";
    string query = "INSERT INTO ProviderAccess (UserFullName, UserAddress, UserContact, UserType, AppointmentDate, AppointmentTime) " +
                   "VALUES (?, ?, ?, ?, ?, ?)";

    try
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("?", name);
                command.Parameters.AddWithValue("?", address);
                command.Parameters.AddWithValue("?", contact);
                command.Parameters.AddWithValue("?", userType);
                command.Parameters.AddWithValue("?", appointmentDate);
                command.Parameters.AddWithValue("?", appointmentTime);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("User successfully added to the database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsersIntoComboBox();
                    nametext.Clear();
                    addresstext.Clear();
                    contacttext.Clear();
                    comboBox1.SelectedIndex = -1;
                    date1.Value = DateTime.Now;
                    time1.Value = DateTime.Now;
                }
                else
                {
                    MessageBox.Show("Failed to add user.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Database error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
            
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            /*string dateToCheck = dateCheck.Value.ToString("dd/MM/yyyy");
            string timeToCheck = timeCheck.Value.ToString("h:mm:ss tt");
            

            if (string.IsNullOrEmpty(dateToCheck) || string.IsNullOrEmpty(timeToCheck))
            {
                MessageBox.Show("All fields must be filled in.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (checkDate(dateToCheck, timeToCheck))
                {
                    richTextBox1.Text = "Date is already reserved ! " + "\n";
                }
                else
                {
                    richTextBox1.Text = "Date not reserved." + "\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    // Koristimo FORMAT() kako bismo iz baze dobili isti format vremena kao u aplikaciji
                    string query = "SELECT COUNT(*) FROM ProviderAccess WHERE AppointmentDate = @date AND FORMAT(AppointmentTime, 'hh:mm AM/PM') = @time";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", date1.Value.Date);

                        // Uklonili smo sekunde jer se najčešće ne zapisuju u bazu
                        string formattedTime = time1.Value.ToString("hh:mm tt");
                        cmd.Parameters.AddWithValue("@time", formattedTime);

                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Termin je već zauzet!", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("Termin je slobodan!", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri provjeri termina: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool checkDate(string dateToCheck, string timeToCheck)
        {
            if (!File.Exists("providersAccess.txt"))
            {
                return false;
            }

            string[] lines = File.ReadAllLines("providersAccess.txt");
            string currentDate = string.Empty;
            string currentTime = string.Empty;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("Date:"))
                {
                    currentDate = lines[i].Substring(5).Trim();
                }
                if (lines[i].StartsWith("Time:"))
                {
                    currentTime = lines[i].Substring(5).Trim();
                }

                if (!string.IsNullOrEmpty(currentDate) && !string.IsNullOrEmpty(currentTime))
                {
                    if (currentDate == dateToCheck && currentTime == timeToCheck)
                    {
                        return true;
                    }

                    currentDate = string.Empty;
                    currentTime = string.Empty;
                }
            }
            return false;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new CareConnectHome().Show();
            this.Hide();
        }
        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        private void usersbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedUser = usersbox.SelectedItem.ToString();
            if (string.IsNullOrEmpty(selectedUser))
                return;

            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string providerQuery = "SELECT UserFullName, UserAddress, UserContact, UserType, AppointmentDate, AppointmentTime FROM ProviderAccess WHERE UserFullName = ?";
                    using (OleDbCommand cmdProvider = new OleDbCommand(providerQuery, conn))
                    {
                        cmdProvider.Parameters.AddWithValue("@UserFullName", selectedUser);
                        OleDbDataReader providerReader = cmdProvider.ExecuteReader();

                        if (providerReader.Read())
                        {
                            StringBuilder providerDetails = new StringBuilder();
                            providerDetails.AppendLine("User Name: " + providerReader["UserFullName"].ToString());
                            providerDetails.AppendLine("Address: " + providerReader["UserAddress"].ToString());
                            providerDetails.AppendLine("Contact: " + providerReader["UserContact"].ToString());

                            richTextBoxUser.Text = providerDetails.ToString();
                        }
                        else
                        {
                            richTextBoxUser.Text = "No details found for this provider.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading provider details: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void mainform2_Load(object sender, EventArgs e)
        {
            LoadUsersIntoComboBox();
        }
        private void LoadUsersIntoComboBox()
        {
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT UserFullName FROM ProviderAccess";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        OleDbDataReader reader = cmd.ExecuteReader();

                        usersbox.Items.Clear();

                        while (reader.Read())
                        {
                            usersbox.Items.Add(reader["UserFullName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO ProviderAccess (UserFullName) VALUES (@name)";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", nametxt.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data added successfully!");
                LoadUsersIntoComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM ProviderAccess WHERE UserFullName = @name";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", nametxt.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data deleted successfully!");
                LoadUsersIntoComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE ProviderAccess SET UserFullName = @newName WHERE UserFullName = @oldName";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@newName", nametxt.Text);
                        cmd.Parameters.AddWithValue("@oldName", oldNameTxt.Text); // Unosi se staro ime za identifikaciju
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data updated successfully!");
                LoadUsersIntoComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM ProviderAccess WHERE UserFullName LIKE @name";
                    using (OleDbDataAdapter da = new OleDbDataAdapter(query, conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@name", "%" + nametxt.Text + "%");
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt; // Prikaz pretrage u DataGridView
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM ProviderAccess";
                    using (OleDbDataAdapter da = new OleDbDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt; // Popunjavanje tabele svim podacima
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading error: " + ex.Message);
            }
        }

    }
}
