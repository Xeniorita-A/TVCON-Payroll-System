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
    /// Interaction logic for AdminEmployee.xaml
    /// </summary>
    public partial class AdminEmployee : Window
    {

        public class Employees
        {
            public String EmployeeID { get; set; }
            public String Name { get; set; }
            public String Gender { get; set; }
            public string Age { get; set; }
            public string Birthdate { get; set; }
            public String Address { get; set; }
            public String Status { get; set; }
            public String Contact { get; set; }
            public String Econtact { get; set; }
            public String Position { get; set; }
            public Double Dailyrate { get; set; }
            public String WorkStatus { get; set; }
            public string Hired { get; set; }
        }
        const string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_payroll_system;";
        private void listEmployees()
        {
            dtgemplist.Items.Clear();
            string query = "SELECT `tbl_employee`.`EID`, `tbl_employee`.`LastName`, `tbl_employee`.`FirstName`, `tbl_employee`.`MiddleName`, `tbl_employee`.`Sex`, `tbl_employee`.`Birthdate`, `tbl_employee`.`House_num`, `tbl_employee`.`Street`, `tbl_brgy`.`brgyDesc`, `tbl_city`.`cityDesc`, `tbl_province`.`provDesc`, `tbl_region`.`regDesc`, `tbl_employee`.`MaritalStatus`, `tbl_employee`.`Contact`, `tbl_employee`.`Emergency_Contact`, `tbl_employee_workinfo`.`Position`, `tbl_employee_workinfo`.`DailyRate`, `tbl_employee_workinfo`.`WorkStatus`, `tbl_employee_workinfo`.`HiredDate` FROM `tbl_employee`"
             + "LEFT JOIN `tbl_brgy` ON `tbl_employee`.`brgyCode` = `tbl_brgy`.`brgyCode` "
             + "LEFT JOIN `tbl_city` ON `tbl_brgy`.`cityCode` = `tbl_city`.`cityCode` "
             + "LEFT JOIN `tbl_province` ON `tbl_city`.`provCode` = `tbl_province`.`provCode` "
             + "LEFT JOIN `tbl_region` ON `tbl_province`.`regCode` = `tbl_region`.`regCode` "
             + "LEFT JOIN `tbl_employee_workinfo` ON `tbl_employee_workinfo`.`EID` = `tbl_employee`.`EID` WHERE  `tbl_employee_workinfo`.`WorkStatus` = 'Active'";
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
                        if (reader.GetInt16(4) == 0)
                        {
                            DateTime FROM = reader.GetDateTime(5);
                            DateTime TO = DateTime.Now;
                            TimeSpan TSPAN = TO - FROM;
                            Double DAYS = TSPAN.TotalDays;

                            Employees _tmpEmp = new Employees
                            {
                                EmployeeID = reader.GetString(0),
                                Name = reader.GetString(1) + ", " + reader.GetString(2) + " " + reader.GetString(3),
                                Gender = "Male",
                                Age = (DAYS / 365).ToString("0"),
                                Birthdate = reader.GetString(5),
                                Address = reader.GetString(6) + " " + reader.GetString(7) + ", " + reader.GetString(8) + ", " + reader.GetString(9) + ", " + reader.GetString(10) + ", " + reader.GetString(11),
                                Status = reader.GetString(12),
                                Contact = reader.GetString(13),
                                Econtact = reader.GetString(14),
                                Position = reader.GetString(15),
                                Dailyrate = reader.GetDouble(16),
                                WorkStatus = reader.GetString(17),
                                Hired = reader.GetString(18)
                            };
                            dtgemplist.Items.Add(_tmpEmp);
                        }
                        else if (reader.GetInt16(4) == 1)
                        {
                            DateTime FROM = reader.GetDateTime(5);
                            DateTime TO = DateTime.Now;
                            TimeSpan TSPAN = TO - FROM;
                            Double DAYS = TSPAN.TotalDays;
                            Employees _tmpEmp = new Employees
                            {
                                EmployeeID = reader.GetString(0),
                                Name = reader.GetString(1) + ", " + reader.GetString(2) + " " + reader.GetString(3),
                                Gender = "Female",
                                Age = (DAYS / 365).ToString("0"),
                                Birthdate = reader.GetString(5),
                                Address = reader.GetString(6) + " " + reader.GetString(7) + ", " + reader.GetString(8) + ", " + reader.GetString(9) + ", " + reader.GetString(10) + ", " + reader.GetString(11),
                                Status = reader.GetString(12),
                                Contact = reader.GetString(13),
                                Econtact = reader.GetString(14),
                                Position = reader.GetString(15),
                                Dailyrate = reader.GetDouble(16),
                                WorkStatus = reader.GetString(17),
                                Hired = reader.GetString(18)
                            };
                            dtgemplist.Items.Add(_tmpEmp);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public AdminEmployee()
        {
            InitializeComponent();
            listEmployees();
            date.Text = DateTime.Now.ToString("dddd , MMM dd yyyy");
        }

        public void searchedResult()
        {
            dtgemplist.Items.Clear();
            string query = "SELECT `tbl_employee`.`EID`, `tbl_employee`.`LastName`, `tbl_employee`.`FirstName`, `tbl_employee`.`MiddleName`, `tbl_employee`.`Sex`, `tbl_employee`.`Birthdate`, `tbl_employee`.`House_num`, `tbl_employee`.`Street`, `tbl_brgy`.`brgyDesc`, `tbl_city`.`cityDesc`, `tbl_province`.`provDesc`, `tbl_region`.`regDesc`, `tbl_employee`.`MaritalStatus`, `tbl_employee`.`Contact`, `tbl_employee`.`Emergency_Contact`, `tbl_employee_workinfo`.`Position`, `tbl_employee_workinfo`.`DailyRate`, `tbl_employee_workinfo`.`WorkStatus`, `tbl_employee_workinfo`.`HiredDate` FROM `tbl_employee`"
                + "LEFT JOIN `tbl_brgy` ON `tbl_employee`.`brgyCode` = `tbl_brgy`.`brgyCode` "
                + "LEFT JOIN `tbl_city` ON `tbl_brgy`.`cityCode` = `tbl_city`.`cityCode` "
                + "LEFT JOIN `tbl_province` ON `tbl_city`.`provCode` = `tbl_province`.`provCode` "
                + "LEFT JOIN `tbl_region` ON `tbl_province`.`regCode` = `tbl_region`.`regCode` "
                + "LEFT JOIN `tbl_employee_workinfo` ON `tbl_employee_workinfo`.`EID` = `tbl_employee`.`EID` WHERE `tbl_employee_workinfo`.`WorkStatus` = 'Active' AND `tbl_employee`.`EID` LIKE '" + txtSearch.Text + "%' OR `tbl_employee`.`LastName` LIKE '" + txtSearch.Text + "%' AND `tbl_employee_workinfo`.`WorkStatus` = 'Active' OR `tbl_employee`.`FirstName` LIKE '" + txtSearch.Text + "%' AND `tbl_employee_workinfo`.`WorkStatus` = 'Active' OR `tbl_employee`.`Sex` LIKE '" + txtSearch.Text + "%' AND `tbl_employee_workinfo`.`WorkStatus` = 'Active' OR `tbl_brgy`.`brgyDesc` LIKE '" + txtSearch.Text + "%' AND `tbl_employee_workinfo`.`WorkStatus` = 'Active' ";

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
                        if (reader.GetInt16(4) == 0)
                        {
                            DateTime FROM = reader.GetDateTime(5);
                            DateTime TO = DateTime.Now;
                            TimeSpan TSPAN = TO - FROM;
                            Double DAYS = TSPAN.TotalDays;

                            Employees _tmpEmp = new Employees
                            {
                                EmployeeID = reader.GetString(0),
                                Name = reader.GetString(1) + ", " + reader.GetString(2) + " " + reader.GetString(3),
                                Gender = "Male",
                                Age = (DAYS / 365).ToString("0"),
                                Birthdate = reader.GetString(5),
                                Address = reader.GetString(6) + " " + reader.GetString(7) + ", " + reader.GetString(8) + ", " + reader.GetString(9) + ", " + reader.GetString(10) + ", " + reader.GetString(11),
                                Status = reader.GetString(12),
                                Contact = reader.GetString(13),
                                Econtact = reader.GetString(14),
                                Position = reader.GetString(15),
                                Dailyrate = reader.GetDouble(16),
                                WorkStatus = reader.GetString(17),
                                Hired = reader.GetString(18)
                            };
                            dtgemplist.Items.Add(_tmpEmp);
                        }
                        else if (reader.GetInt16(4) == 1)
                        {
                            DateTime FROM = reader.GetDateTime(5);
                            DateTime TO = DateTime.Now;
                            TimeSpan TSPAN = TO - FROM;
                            Double DAYS = TSPAN.TotalDays;
                            Employees _tmpEmp = new Employees
                            {
                                EmployeeID = reader.GetString(0),
                                Name = reader.GetString(1) + ", " + reader.GetString(2) + " " + reader.GetString(3),
                                Gender = "Female",
                                Age = (DAYS / 365).ToString("0"),
                                Birthdate = reader.GetString(5),
                                Address = reader.GetString(6) + " " + reader.GetString(7) + ", " + reader.GetString(8) + ", " + reader.GetString(9) + ", " + reader.GetString(10) + ", " + reader.GetString(11),
                                Status = reader.GetString(12),
                                Contact = reader.GetString(13),
                                Econtact = reader.GetString(14),
                                Position = reader.GetString(15),
                                Dailyrate = reader.GetDouble(16),
                                WorkStatus = reader.GetString(17),
                                Hired = reader.GetString(18)
                            };
                            dtgemplist.Items.Add(_tmpEmp);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //Toggle Menu Buttons
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            AdminPage admin = new AdminPage();
            admin.Show();
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchedResult();
            if (txtSearch.Text == "")
            {
                listEmployees();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("HELP \nWhat can I do? \nYou can search the employee details with the search field. However, you can only view the details of the employees you cannot edit or delete it. For other queries please contact us. \n\nHopefully this is helpful for you! \n\nHAVE A GOOD DAY!!", "HELP", MessageBoxButton.OK, MessageBoxImage.Question);
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

