using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for PayrollMaster.xaml
    /// </summary>
    public partial class PayrollMaster : Window
    {
        public class Notes
        {
            public String Title { get; set; }
            public String Note { get; set; }
            public String Date { get; set; }
        }

        const string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_payroll_system;";
        Notes currUser = null;
        private void NotesSaved()
        {
            Notepad.Items.Clear();
            string query = "SELECT * FROM `tbl_notes` WHERE `userType` LIKE '" + userType.Content + "%'";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                // Success, now list 
                // If there are available rows
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Notes _tmpUser = new Notes { Date = reader.GetString(1), Title = reader.GetString(2).ToUpper() };
                        Notepad.Items.Add(_tmpUser);
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
        public PayrollMaster()
        {
            InitializeComponent();
            NotesSaved();
        }

        private void btnPayroll_Click(object sender, RoutedEventArgs e)
        {
            Payroll load = new Payroll();
            load.Show();
            this.Close();
        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out of the application?", "EXIT", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MainWindow load = new MainWindow();
                load.Show();
                transactionAdd();
                this.Close();
            }
        }
        public void transactionAdd()
        {
            const string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_payroll_system;";
            string query2 = "INSERT INTO  `tbl_audit_trail` (`UserResponsible`, `TransactionHistory`, `DateOfTransaction`)  VALUES (@user, @history, @date)";
            MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection2);
            commandDatabase2.Parameters.AddWithValue("@user", userType.Content);
            commandDatabase2.Parameters.AddWithValue("@history", "Logout of the system.");
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
        private void btnAddNote_Click(object sender, RoutedEventArgs e)
        {
            if (txtNote.Text == "" || txtTitle.Text == "" || DateWritten.Text == "")
            {
                MessageBox.Show("Please input all the necessary information!");

            }
            else
            {
                String query = "INSERT INTO `tbl_notes` ( `DateWritten`,`Title`, `Note`,`userType`) VALUES (@date, @title, @note, @type)";
          
                MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase2 = new MySqlCommand(query, databaseConnection2);
                commandDatabase2.Parameters.AddWithValue("@date", Convert.ToDateTime(DateWritten.Text));
                commandDatabase2.Parameters.AddWithValue("@title", txtTitle.Text);
                commandDatabase2.Parameters.AddWithValue("@note", txtNote.Text);
                commandDatabase2.Parameters.AddWithValue("@type", userType.Content);
                commandDatabase2.CommandTimeout = 60;

                try
                {
                    databaseConnection2.Open();
                    MySqlDataReader myReader = commandDatabase2.ExecuteReader();

                    MessageBox.Show("Noted!");
                    txtNote.Text = "";
                    txtTitle.Text = "";
                    DateWritten.Text = "";

                    databaseConnection2.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                NotesSaved();
            }

        }

        private void btnDeleteNote_Click(object sender, RoutedEventArgs e)
        { if (Notepad.SelectedIndex > -1) {
                if (MessageBox.Show("Are you sure you want to delete this note?", "DELETE", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    string query = "DELETE FROM `tbl_notes` WHERE  `tbl_notes`.`Title` = @title";

                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    commandDatabase.Parameters.AddWithValue("@title", txtTitle.Text);
                    commandDatabase.CommandTimeout = 60;
                    MySqlDataReader reader;

                    try
                    {
                        databaseConnection.Open();
                        reader = commandDatabase.ExecuteReader();

                        // Succesfully deleted

                        databaseConnection.Close();
                        btnNewNote_Click(sender, e);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        NotesSaved();
                        btnAddNote1.IsEnabled = true;
                    }
                }

            }else
            {
                MessageBox.Show("Please select a note you want to delete!!");
            }
          
        }

        private void btnNewNote_Click(object sender, RoutedEventArgs e)
        {
            txtTitle.Text = "";
            txtNote.Text = "";
            DateWritten.Text = "";
            Notepad.SelectedIndex = -1;
            btnAddNote1.IsEnabled = true;
        }

        private void Notepad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Notepad.SelectedIndex > -1)
            {
                currUser = (Notes)Notepad.SelectedItem;
                DateWritten.Text = currUser.Date.ToString();
                txtTitle.Text = currUser.Title.ToString();
                string query = "SELECT * FROM `tbl_notes` WHERE Title = @title";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@title", txtTitle.Text);
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
                            txtNote.Text = reader.GetString(3);
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
                }

            }
            else
            {
                currUser = null;


            }

        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out of the application?", "EXIT", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
                MainWindow load = new MainWindow();
                load.Show();
                transactionAdd();
            }
        }

        private void btnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Visible;
            btnCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void btnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Collapsed;
            btnCloseMenu.Visibility = Visibility.Visible;
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
            MessageBox.Show("\nHELP \nYou can save note using the fields provided below. Please input the necessary information to save your note.You can also go to other forms by clicking the button at the menu tab. \n\nHopefully this information was helpful to you. \n\nHave a good day!", "HELP", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            pmHistory his = new pmHistory();
            his.Show();
            this.Close();
        }

        private void btnContribution_Click(object sender, RoutedEventArgs e)
        {
            Contributions CN = new Contributions();
            CN.Show();
            this.Close();
        }
    }
}
