using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;


namespace CareConnectLog
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
            
          
        }
        public mainform(string userID)
        {
            InitializeComponent();
            loggedInUserID = userID;
        }

        public string CurrentUserID { get; set; }  // Ovo treba da bude dodeljeno prilikom logovanja korisnika

        private string loggedInUserID;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new CareConnectHome().Show();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string providerName = providertxt.Text.Trim();
            string serviceType = typetxt.Text.Trim();
            string priceText = pricetxt.Text.Trim();
            string location = locationtxt.Text.Trim();

            if (string.IsNullOrEmpty(providerName) && string.IsNullOrEmpty(serviceType) &&
                string.IsNullOrEmpty(priceText) && string.IsNullOrEmpty(location))
            {
                MessageBox.Show("At least one field must be filled in for search.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    StringBuilder queryBuilder = new StringBuilder("SELECT * FROM ServiceDetails WHERE 1=1");

                    if (!string.IsNullOrEmpty(providerName))
                        queryBuilder.Append(" AND ProviderName LIKE ?");
                    if (!string.IsNullOrEmpty(serviceType))
                        queryBuilder.Append(" AND ServiceName LIKE ?");
                    if (!string.IsNullOrEmpty(priceText))
                        queryBuilder.Append(" AND ServicePrice = ?");
                    if (!string.IsNullOrEmpty(location))
                        queryBuilder.Append(" AND ServiceLocation LIKE ?");

                    using (OleDbCommand cmd = new OleDbCommand(queryBuilder.ToString(), conn))
                    {
                        if (!string.IsNullOrEmpty(providerName))
                            cmd.Parameters.AddWithValue("@ProviderName", "%" + providerName + "%");
                        if (!string.IsNullOrEmpty(serviceType))
                            cmd.Parameters.AddWithValue("@ServiceType", "%" + serviceType + "%");
                        if (!string.IsNullOrEmpty(priceText))
                            cmd.Parameters.AddWithValue("@Price", priceText);
                        if (!string.IsNullOrEmpty(location))
                            cmd.Parameters.AddWithValue("@Location", "%" + location + "%");

                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        // Puniš dataGridView
                        dataGridView2.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            providertxt.Clear();
            typetxt.Text = "";
            pricetxt.Clear();
            locationtxt.Clear();
            providertxt.Focus();

        }

        private bool ProviderFound(string providerName, string serviceType, string priceText, string location)
        {
            if (!File.Exists("services.txt"))
            {
                return false;
            }

            string[] lines = File.ReadAllLines("services.txt");
            string currentProvider = string.Empty;
            string currentService = string.Empty;
            string currentPrice = string.Empty;
            string currentLocation = string.Empty;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("Name:"))
                {
                    currentProvider = lines[i].Substring(5).Trim();
                }
                if (lines[i].StartsWith("Service Type:"))
                {
                    currentService = lines[i].Substring(13).Trim();
                }
                if (lines[i].StartsWith("Price:"))
                {
                    currentPrice = lines[i].Substring(6).Trim();
                }
                if (lines[i].StartsWith("Location:"))
                {
                    currentLocation = lines[i].Substring(9).Trim();
                }


                if (!string.IsNullOrEmpty(currentProvider) && !string.IsNullOrEmpty(currentService) && !string.IsNullOrEmpty(currentPrice) && !string.IsNullOrEmpty(currentLocation))
                {
                    if (currentProvider == providerName && currentService == serviceType && currentPrice == priceText && currentLocation == location)
                    {
                        return true;
                    }

                    currentProvider = string.Empty;
                    currentService = string.Empty;
                    currentPrice = string.Empty;
                    currentLocation = string.Empty;
                }
            }
            return false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            providertxt.Clear();
            pricetxt.Clear();
            locationtxt.Clear();
            typetxt.Text = " ";
            providertxt.Focus();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string provider = providerreview.Text.Trim();
            string grade = Grade.Text.Trim();
            string comment = Comment.Text.Trim();

            if (string.IsNullOrEmpty(provider) || string.IsNullOrEmpty(grade) || string.IsNullOrEmpty(comment))
            {
                MessageBox.Show("All fields must be filled in.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Dobijanje ProviderID na osnovu ProviderName
                string providerID = GetProviderID1(provider);

                if (string.IsNullOrEmpty(providerID))
                {
                    MessageBox.Show("ProviderID not found for " + provider, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string insertQuery = "INSERT INTO Reviews (ProviderName, Grade, Comment, ProviderID, UserID) VALUES (@ProviderName, @Grade, @Comment, @ProviderID, @UserID)";

                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProviderName", provider);
                        cmd.Parameters.AddWithValue("@Grade", grade);
                        cmd.Parameters.AddWithValue("@Comment", comment);
                        cmd.Parameters.AddWithValue("@ProviderID", providerID); // Dodavanje ProviderID
                        //cmd.Parameters.AddWithValue("@UserID", CurrentUserID); // Pretpostavljamo da je CurrentUserID dodeljen
                        cmd.Parameters.AddWithValue("@UserID", loggedInUserID);


                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Your Review has been Successfully Saved!", "Review Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                providerreview.Clear();
                Grade.Clear();
                Comment.Clear();
                providerreview.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving review: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateProviderFromDatabase(string provider)
        {
            bool exists = false;
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM ServiceDetails WHERE ProviderName = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProviderName", provider);

                        int count = (int)cmd.ExecuteScalar();
                        exists = (count > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error during validation: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return exists;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            providerreview.Clear();
            Grade.Clear();
            Comment.Clear();
            providerreview.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string selectedProvider = comboBox1.SelectedItem.ToString();

            if (string.IsNullOrEmpty(selectedProvider))
                return;

            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // --- Učitaj podatke iz ProviderAccounts ---
                    string providerQuery = "SELECT ProviderName, ServiceType, ServiceDescription FROM ProviderAccounts WHERE ProviderName = ?";
                    using (OleDbCommand cmdProvider = new OleDbCommand(providerQuery, conn))
                    {
                        cmdProvider.Parameters.AddWithValue("@ProviderName", selectedProvider);
                        OleDbDataReader providerReader = cmdProvider.ExecuteReader();

                        if (providerReader.Read())
                        {
                            StringBuilder providerDetails = new StringBuilder();
                            providerDetails.AppendLine("Provider Name: " + providerReader["ProviderName"].ToString());
                            providerDetails.AppendLine("Service Type: " + providerReader["ServiceType"].ToString());
                            providerDetails.AppendLine("Service Description: " + providerReader["ServiceDescription"].ToString());

                            richTextBox1.Text = providerDetails.ToString();
                        }
                        else
                        {
                            richTextBox1.Text = "No details found for this provider.";
                        }
                    }

                    // --- Učitaj recenzije iz Reviews ---
                    string reviewsQuery = "SELECT Grade, Comment FROM Reviews WHERE ProviderName = ?";
                    using (OleDbCommand cmdReviews = new OleDbCommand(reviewsQuery, conn))
                    {
                        cmdReviews.Parameters.AddWithValue("@ProviderName", selectedProvider);
                        OleDbDataReader reviewsReader = cmdReviews.ExecuteReader();

                        StringBuilder reviews = new StringBuilder();
                        while (reviewsReader.Read())
                        {
                            reviews.AppendLine("Grade: " + reviewsReader["Grade"].ToString());
                            reviews.AppendLine("Comment: " + reviewsReader["Comment"].ToString());
                            reviews.AppendLine();
                        }

                        if (reviews.Length > 0)
                        {
                            richTextBoxReviews.Text = reviews.ToString();
                        }
                        else
                        {
                            richTextBoxReviews.Text = "No reviews found for this provider.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading provider details: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LoadProviderReviews(string providerName)
        {
            string[] reviewLines = File.ReadAllLines("reviews.txt");
            StringBuilder reviews = new StringBuilder();

            foreach (var line in reviewLines)
            {
                
                if (line.Trim().StartsWith("Provider:"))
                {
                    
                    string providerInReview = line.Substring(9).Trim(); 

                    if (providerInReview.Equals(providerName, StringComparison.OrdinalIgnoreCase))
                    {
                        
                        reviews.AppendLine(line); 
                        reviews.AppendLine("Grade: " + reviewLines[Array.IndexOf(reviewLines, line) + 1].Substring(6)); 
                        reviews.AppendLine("Comment: " + reviewLines[Array.IndexOf(reviewLines, line) + 2].Substring(9)); 
                        reviews.AppendLine(); 
                    }
                }
            }

            
            if (reviews.Length > 0)
            {
                richTextBoxReviews.Text = reviews.ToString();
            }
            else
            {
                richTextBoxReviews.Text = "No reviews found for this provider.";
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

      

        private void ShowProviderDetails(string providerName)
        {
            string[] lines = File.ReadAllLines("services.txt");
            bool providerFound = false;
            StringBuilder providerDetails = new StringBuilder();

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Trim().StartsWith("Name:") && lines[i].Contains(providerName))
                {
                    providerFound = true;
                    providerDetails.AppendLine(lines[i]);

                    for (int j = i + 1; j < lines.Length; j++)
                    {
                        if (lines[j].Trim().StartsWith("ID-->") || lines[j].Trim().StartsWith("Name:"))
                            break;

                        providerDetails.AppendLine(lines[j].Trim());
                    }
                    break;
                }
            }

            if (providerFound)
            {
                richTextBox1.Text = providerDetails.ToString();
                LoadProviderReviews(providerName);
            }
            else
            {
                MessageBox.Show("Provider details not found.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                richTextBox1.Clear();
                richTextBoxReviews.Clear();
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }


        private void LoadServiceDetails()
        {
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM ServiceDetails";

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dataGridView1.DataSource = table;

                        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading ServiceDetails: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mainform_Load(object sender, EventArgs e)
        {
            //this.uslugaTableAdapter.Fill(this.careConnectDataSet.Usluga);
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadProvidersIntoComboBox();


        }
        private void LoadProvidersIntoComboBox()
        {
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ProviderName FROM ProviderAccounts";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        OleDbDataReader reader = cmd.ExecuteReader();

                        comboBox1.Items.Clear();

                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["ProviderName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading providers: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView2.CurrentRow != null && dataGridView2.CurrentRow.Index >= 0)
    {
        
        providertxt.Text = dataGridView2.CurrentRow.Cells["ProviderName"].Value.ToString();
        typetxt.Text = dataGridView2.CurrentRow.Cells["ServiceName"].Value.ToString();
        pricetxt.Text = dataGridView2.CurrentRow.Cells["ServicePrice"].Value.ToString();
        locationtxt.Text = dataGridView2.CurrentRow.Cells["ServiceLocation"].Value.ToString();
    }
        }

        private void Comment_TextChanged(object sender, EventArgs e)
        {

        }

        private void PREVIEW_Click(object sender, EventArgs e)
        {
            LoadServiceDetails();
        }


       
        private string GetProviderID1(string providerName)
        {
            string providerID = string.Empty;

            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CareConnect.accdb;";
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ProviderID FROM ProviderAccounts WHERE ProviderName = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProviderName", providerName);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            providerID = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("ProviderID not found for " + providerName, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving ProviderID: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return providerID;
        }


    }
}
