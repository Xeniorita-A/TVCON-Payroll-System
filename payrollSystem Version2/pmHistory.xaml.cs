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
    /// Interaction logic for pmHistory.xaml
    /// </summary>
    public partial class pmHistory : Window
    {
        public class history
        {
            public String User { get; set; }
            public String History { get; set; }
            public String Date { get; set; }
        }
        const string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_payroll_system;";
        private void listHistory()
        {
            lvHistory.Items.Clear();

            string query = "SELECT * FROM  `tbl_audit_trail`";

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

                        history _tmpHistory = new history { User = reader.GetString(1).ToUpper(), History = reader.GetString(2), Date = reader.GetString(3) };
                        lvHistory.Items.Add(_tmpHistory);
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
        public pmHistory()
        {
            InitializeComponent();
            date.Text = DateTime.Now.ToString("dddd , MMM dd yyyy");
            listHistory();
        }

        public void searchedResult()
        {
            lvHistory.Items.Clear();

            string query = "SELECT * FROM  `tbl_audit_trail` WHERE `UserResponsible` LIKE '" + txtSearch.Text + "%'" + " OR `TransactionHistory` LIKE '" + txtSearch.Text + "%'" + " OR `DateOfTransaction` LIKE '" + txtSearch.Text + "%'";

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

                        history _tmpHistory = new history { User = reader.GetString(1), History = reader.GetString(2), Date = reader.GetString(3) };
                        lvHistory.Items.Add(_tmpHistory);
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
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            PayrollMaster load = new PayrollMaster();
            load.Show();
            this.Close();
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("WHO ARE WE? \n\n\tWith a team of dedicated IT students of Pamantasan ng Lungsod ng Valenzuela, TvCon Payroll System was created on December 3, 2019. TvCon Payroll System was designed to meet the company's specific needs. The Payroll System take away the hassle of creating payroll and managing employee records. It allows the user to experience stress-free managing and monitoring of records.Our leadership team is dedicated to create a system that is easy to use, efficient and helpful.", "ABOUT US", MessageBoxButton.OK, MessageBoxImage.None);
        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("\nCONTACT US \n\nGet in touch with us. We gladly welcome your inquiries and feedback. Please feel free to contact us at our email (Tvcon09@gmail.com) and contact number(09771865983). \n\nHAVE A GOOD DAY!", "HELP", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("HELP \nWhat can I do? \nYou can view and search the transaction history with the search field. However, you cannot edit or delete it. For other queries please contact us. \n\nHopefully this is helpful for you! \n\nHAVE A GOOD DAY!!", "HELP", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void txtSearch_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            searchedResult();
            if (txtSearch.Text == "")
            {
                listHistory();
            }
        }
    }
}
