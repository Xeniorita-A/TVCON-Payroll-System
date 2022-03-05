using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace payrollSystem_Version2
{
    /// <summary>
    /// Interaction logic for ManageUsers.xaml
    /// </summary>
    /// 

   

    public partial class SuperUsers : Window
    {
        public class User
        {
            public Int16 UserID { get; set; }
            public String Name { get; set; }
            public String Username { get; set; }
            public String Type { get; set; }
        }

        const string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_payroll_system;";
        User currUser = null;
        public SuperUsers()
        {
            InitializeComponent();
            users();
            date.Text = DateTime.Now.ToString("dddd , MMM dd yyyy");

            string plainData = "Mahesh";
            Console.WriteLine("Raw data: {0}", plainData);
            string hashedData = ComputeSha256Hash(plainData);
            Console.WriteLine("Hash {0}", hashedData);
            Console.WriteLine(ComputeSha256Hash("Mahesh"));
            Console.ReadLine();
            btnAdd.IsEnabled = true;
           
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public void users()
        {
            lvUsers.Items.Clear();
            string query = "SELECT * FROM `tbl_users`";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        User _tmpUser = new User { UserID = reader.GetInt16(0), Name = reader.GetString(1), Username = reader.GetString(2), Type = reader.GetString(4) };
                        lvUsers.Items.Add(_tmpUser);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                databaseConnection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void btnHome_Click_1(object sender, RoutedEventArgs e)
        {
            SuperAdmin home = new SuperAdmin();
            home.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show("Please input your username and password.");
                return;
            }
            if (cbUserType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select user level!");
                return;
            }
            else
            {
                try
                {
                    String query = "INSERT INTO `tbl_users` ( `Name`,`Username`,`Pass`, `Type`) VALUES (@name, @username, @password, @userLevel)";
                String hashedData = ComputeSha256Hash(txtPassword.Text);
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@name", txtName.Text);
                commandDatabase.Parameters.AddWithValue("@username", txtUsername.Text);
                commandDatabase.Parameters.AddWithValue("@password", hashedData);
                commandDatabase.Parameters.AddWithValue("@userLevel", cbUserType.Text);
                commandDatabase.CommandTimeout = 60;

               
                    databaseConnection.Open();
                    MySqlDataReader myReader = commandDatabase.ExecuteReader();

                    //  MessageBox.Show("User succesfully registered!");

                    databaseConnection.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please check your inputs.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                transactionAdd();
                users();
            }
        }
        public void transactionAdd()
        {
            string query2 = "INSERT INTO `tbl_audit_trail` (`UserResponsible`, `TransactionHistory`, `DateOfTransaction`)  VALUES (@user, @history, @date)";
            MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection2);
            commandDatabase2.Parameters.AddWithValue("@user", "SUPER ADMIN");
            commandDatabase2.Parameters.AddWithValue("@history", "Added a new user account. (" + cbUserType.Text + ": " + txtUsername.Text + ").");
            commandDatabase2.Parameters.AddWithValue("@date", DateTime.Now);
            commandDatabase2.CommandTimeout = 60;
            MySqlDataReader reader2;
            try
            {
                databaseConnection2.Open();
                reader2 = commandDatabase2.ExecuteReader();
                databaseConnection2.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void transactionUpdate()
        {
            string query2 = "INSERT INTO  `tbl_audit_trail` (`UserResponsible`, `TransactionHistory`, `DateOfTransaction`)  VALUES (@user, @history, @date)";
            MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection2);
            commandDatabase2.Parameters.AddWithValue("@user", "SUPER ADMIN");
            commandDatabase2.Parameters.AddWithValue("@history", "Updated the user account (" + cbUserType.Text + ": " + txtUsername.Text + ").");
            commandDatabase2.Parameters.AddWithValue("@date", DateTime.Now);
            commandDatabase2.CommandTimeout = 60;
            MySqlDataReader reader2;
            try
            {
                databaseConnection2.Open();
                reader2 = commandDatabase2.ExecuteReader();
                databaseConnection2.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void transactionDelete()
        {
            string query2 = "INSERT INTO `tbl_audit_trail` (`UserResponsible`, `TransactionHistory`, `DateOfTransaction`)  VALUES (@user, @history, @date)";
            MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection2);
            commandDatabase2.Parameters.AddWithValue("@user", "SUPER ADMIN");
            commandDatabase2.Parameters.AddWithValue("@history", "Deleted a user account (" + cbUserType.Text + ": " + txtUsername.Text + ").");
            commandDatabase2.Parameters.AddWithValue("@date", DateTime.Now);
            commandDatabase2.CommandTimeout = 60;
            MySqlDataReader reader2;
            try
            {
                databaseConnection2.Open();
                reader2 = commandDatabase2.ExecuteReader();
                databaseConnection2.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try { 
            if (lvUsers.SelectedIndex >-1) {
                String query = "UPDATE `tbl_users` SET `Name`= @name, `Username` = @username,`Pass`= @password, `Type`= @userLevel WHERE `UserID` = @id";
                String hashedData = ComputeSha256Hash(txtPassword.Text);

                MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase2 = new MySqlCommand(query, databaseConnection2);
                commandDatabase2.Parameters.AddWithValue("@id", txtUserID.Text);
                commandDatabase2.Parameters.AddWithValue("@name", txtName.Text);
                commandDatabase2.Parameters.AddWithValue("@username", txtUsername.Text);
                commandDatabase2.Parameters.AddWithValue("@password", hashedData);
                commandDatabase2.Parameters.AddWithValue("@userLevel", cbUserType.Text);
               
                    commandDatabase2.CommandTimeout = 60;
                    databaseConnection2.Open();
                    MessageBox.Show("Successfully Updated User!");
                    MySqlDataReader myReader = commandDatabase2.ExecuteReader();
                    databaseConnection2.Close();
                    transactionUpdate();
                    users();
                }
                else
                {
                    MessageBox.Show("Please select a user account you want to edit.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please check your inputs!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
        txtUserID.Text = "";
        txtName.Text = "";
        txtUsername.Text = "";
        txtPassword.Text = "";
        cbUserType.SelectedIndex = 0;
        lvUsers.SelectedIndex = -1;
        btnAdd.IsEnabled = true;
       
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lvUsers.SelectedIndex > -1)
                {
                    if (MessageBox.Show("Are you sure to delete this User account?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        string query = "DELETE FROM `tbl_users` WHERE `tbl_users`.`UserID` = @UserID";

                        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                        commandDatabase.Parameters.AddWithValue("@UserID", txtUserID.Text);
                        commandDatabase.CommandTimeout = 60;
                        MySqlDataReader reader;

                        databaseConnection.Open();
                        reader = commandDatabase.ExecuteReader();
                        MessageBox.Show("Successfully Deleted the user!");
                        databaseConnection.Close();
                       
                    }
                }
                else
                {
                    MessageBox.Show("Please select a user account you want to delete.");
                }
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);

            }
            finally
            {
                transactionDelete();
                users();
               
            }
            btnNew_Click(sender, e);
        }

        private void lvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvUsers.SelectedIndex > -1)
            {
                
                currUser = (User)lvUsers.SelectedItem;
                txtUserID.Text = currUser.UserID.ToString();
                txtUserID.IsEnabled = false;
                txtName.Text = currUser.Name.ToString();
                txtUsername.Text = currUser.Username;
                cbUserType.Text = currUser.Type;
                btnAdd.IsEnabled = false;
                
            }
        }
        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("WHO ARE WE? \n\n\tWith a team of dedicated IT students of Pamantasan ng Lungsod ng Valenzuela, TvCon Payroll System was created on December 3, 2019. TvCon Payroll System was designed to meet the company's specific needs. The Payroll System take away the hassle of creating payroll and managing employee records. It allows the user to experience stress-free managing and monitoring of records.Our leadership team is dedicated to create a system that is easy to use, efficient and helpful.", "ABOUT US", MessageBoxButton.OK, MessageBoxImage.None);
        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("\nCONTACT US \n\nGet in touch with us. We gladly welcome your inquiries and feedback. Please feel free to contact us at our email (Tvcon09@gmail.com) and contact number(09771865983). \n\nHAVE A GOOD DAY!", "HELP", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("\nHELP \n\nYou can add, delete or update the user's information with the given fields and button below.\n\nHow can I add user? \nYou'll need to input the necessary informations such as the name, username, password and usertype. \n\nHow can I edit the users account? \nYou can Edit or update user account by clicking the userID on the list and then the information will be editable after editing it you can now click the update button.\n\nHow can I delete Users? \nYou can delete user/s by clicking the userID on the list and Clicking the delete button after.\n\nWhat is the purpose of new button? \nThe sole purpose of the new button is just to clear all the fields at once. \n\nHopefully this information was helpful to you. \n\nHave a good day!", "HELP", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        }
}
