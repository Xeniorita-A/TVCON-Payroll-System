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
    /// Interaction logic for AdminPayrollList.xaml
    /// </summary>
    public partial class AdminPayrollList : Window
    {
        public class Pays
        {
            public String DateIssued { get; set; }
            public string EID { get; set; }
            public double Num_days { get; set; }
            public double Leave { get; set; }
            public double RateWage { get; set; }
            public double OThours { get; set; }
            public double Overtime { get; set; }
            public double NightDifferential { get; set; }
            public double HollPay { get; set; }
            public double Basic_Pay { get; set; }
            public double Cash_ad { get; set; }
            public double Philhealth { get; set; }
            public double WithholdingTax { get; set; }
            public double Pagibig { get; set; }
            public double SSS { get; set; }
            public string d1 { get; set; }
            public string d2 { get; set; }
            public string d3 { get; set; }
            public double da1 { get; set; }
            public double da2 { get; set; }
            public double da3 { get; set; }
            public double totald { get; set; }
            public double Net_income { get; set; }
            public String PayDay { get; set; }
        }
        const string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_payroll_system;";

        private void listPayroll()
        {
            lvPayroll.Items.Clear();
            string query = "SELECT * FROM `tbl_payroll` ORDER BY `dateIssued` DESC";
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
                        Pays _tmpPayroll = new Pays
                        {
                            EID = reader.GetString(1),
                            PayDay = reader.GetString(2),
                            Num_days = reader.GetDouble(3),
                            Leave = reader.GetDouble(4),
                            RateWage = reader.GetDouble(5),
                            Overtime = reader.GetDouble(6),
                            OThours = reader.GetDouble(7),
                            NightDifferential = reader.GetDouble(8),
                            HollPay = reader.GetDouble(9),
                            Basic_Pay = reader.GetDouble(10),
                            Cash_ad = reader.GetDouble(11),
                            Philhealth = reader.GetDouble(12),
                            WithholdingTax = reader.GetDouble(13),
                            Pagibig = reader.GetDouble(14),
                            SSS = reader.GetDouble(15),
                            d1 = reader.GetString(16),
                            da1 = reader.GetDouble(17),
                            d2 = reader.GetString(18),
                            da2 = reader.GetDouble(19),
                            d3 = reader.GetString(20),
                            da3 = reader.GetDouble(21),
                            totald = reader.GetDouble(22),
                            Net_income = reader.GetDouble(23),
                            DateIssued = reader.GetString(24),
                        };
                        lvPayroll.Items.Add(_tmpPayroll);
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
        public AdminPayrollList()
        {
            InitializeComponent();
            date.Text = DateTime.Now.ToString("dddd , MMM dd yyyy");
            listPayroll();
        }

        private void btnHome_Click_1(object sender, RoutedEventArgs e)
        {
            AdminPage load = new AdminPage();
            load.Show();
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchedPay();
            if (txtSearch.Text == "")
            {
                listPayroll();
            }
        }
        public void searchedPay()
        {
            try
            {
                lvPayroll.Items.Clear();
                string query = "SELECT * FROM `tbl_payroll` WHERE `EID` LIKE '" + txtSearch.Text + "%' ORDER BY `dateIssued` DESC";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pays _tmpPayroll = new Pays
                        {
                            EID = reader.GetString(1),
                            PayDay = reader.GetString(2),
                            Num_days = reader.GetDouble(3),
                            Leave = reader.GetDouble(4),
                            RateWage = reader.GetDouble(5),
                            Overtime = reader.GetDouble(6),
                            OThours = reader.GetDouble(7),
                            NightDifferential = reader.GetDouble(8),
                            HollPay = reader.GetDouble(9),
                            Basic_Pay = reader.GetDouble(10),
                            Cash_ad = reader.GetDouble(11),
                            Philhealth = reader.GetDouble(12),
                            WithholdingTax = reader.GetDouble(13),
                            Pagibig = reader.GetDouble(14),
                            SSS = reader.GetDouble(15),
                            d1 = reader.GetString(16),
                            da1 = reader.GetDouble(17),
                            d2 = reader.GetString(18),
                            da2 = reader.GetDouble(19),
                            d3 = reader.GetString(20),
                            da3 = reader.GetDouble(21),
                            totald = reader.GetDouble(22),
                            Net_income = reader.GetDouble(23),
                            DateIssued = reader.GetString(24),
                        };
                        lvPayroll.Items.Add(_tmpPayroll);
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
        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("HELP \nWhat can I do? \nYou can search the payroll table with the search field. However, you can only view the details of the employee's payroll you cannot edit or delete it. For other queries please contact us. \n\nHopefully this is helpful for you! \n\nHAVE A GOOD DAY!!", "HELP", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("WHO ARE WE? \n\n\tWith a team of dedicated IT students of Pamantasan ng Lungsod ng Valenzuela, TvCon Payroll System was created on December 3, 2019. TvCon Payroll System was designed to meet the company's specific needs. The Payroll System take away the hassle of creating payroll and managing employee records. It allows the user to experience stress-free managing and monitoring of records.Our leadership team is dedicated to create a system that is easy to use, efficient and helpful.", "ABOUT US", MessageBoxButton.OK, MessageBoxImage.None);
        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("\nCONTACT US \n\nGet in touch with us. We gladly welcome your inquiries and feedback. Please feel free to contact us at our email (Tvcon09@gmail.com) and contact number(09771865983). \n\nHAVE A GOOD DAY!", "HELP", MessageBoxButton.OK, MessageBoxImage.Question);
        }
    }
}
