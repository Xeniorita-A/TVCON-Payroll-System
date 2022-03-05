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
using System.IO;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;

namespace payrollSystem_Version2
{
    /// <summary>
    /// Interaction logic for Payroll.xaml
    /// </summary>
    public partial class SuperPayroll : Window
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
        // To display the data on the listview
        const string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_payroll_system;";
        Employees currUser = null;
        Pays currPay = null;
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
        // this is just to show the dates (it's still important)
        public SuperPayroll()
        {
            InitializeComponent();
            date2.Text = DateTime.Now.ToString("dd/MM/yyyy");
            date1.Text = DateTime.Now.ToString("dddd , MMM dd yyyy");
            date.Text = DateTime.Now.ToString("dddd , MMM dd yyyy");
            EditDateChecker.SelectedDate = DateTime.Now.Date;
            listPayroll();
            listEmployees();
        }
        //CALCULATIONS ng lahat ng Deductions
        private void calc_dedution()
        {
            try
            {
                double withholding;
                double ca, phi, sss, pagibig, d1, d2, d3, total_deduction, basicpay, netincome;
                if (txtcashAdvance.Text == "" || txtcashAdvance.Text == "0")
                {
                    txtcashAdvance.Text = "0";
                }
                if (txtdeduction1val.Text == "" || txtdeduction1val.Text == "0")
                {
                    txtdeduction1val.Text = "0";
                }
                if (txtdeduction2val.Text == "" || txtdeduction2val.Text == "0")
                {
                    txtdeduction2val.Text = "0";
                }
                if (txtdeduction3val.Text == "" || txtdeduction3val.Text == "0")
                {
                    txtdeduction3val.Text = "0";
                }
                ca = Convert.ToDouble(txtcashAdvance.Text);
                phi = Convert.ToDouble(txtPhilhealth.Text);
                sss = Convert.ToDouble(txtSSS.Text);
                pagibig = Convert.ToDouble(txtPagibig.Text);
                d1 = Convert.ToDouble(txtdeduction1val.Text);
                d2 = Convert.ToDouble(txtdeduction2val.Text);
                d3 = Convert.ToDouble(txtdeduction3val.Text);
                basicpay = Convert.ToDouble(txtBasicPay.Text);
                withholding = Convert.ToDouble(txtWithholding.Text);
                total_deduction = ca + phi + sss + pagibig + withholding + d1 + d2 + d3;
                Math.Round(total_deduction);
                txtTotaldeduction.Text = total_deduction.ToString("0.00");
                netincome = basicpay - total_deduction;
                Math.Round(netincome);
                txtNetIncome.Text = netincome.ToString("0.00");
                listPayroll();
            }
            catch (Exception) { }
        }
        //This is to clear all the textfields in the create payroll tab
        public void clearAll()
        {
            txtEmployeeId1.Text = "";
            txtNumDays.Text = "";
            txtEmployeeName.Text = "";
            txtDailyRate.Text = "";
            txtBasicPay.Text = "";
            txtNetIncome.Text = "";
            txtTotaldeduction.Text = "";
            PayDay.Text = "";
            txtLeave.Text = "";
            txtEmployeeName.Text = "";
            txtholnumdays.Text = "";
            txtDifferential.Text = "";
            txtBasicPay.Text = "";
            PayDay.Text = "";
            txtcashAdvance.Text = "";
            txtDailyRate.Text = "";
            txtdeduction1.Text = "";
            txtdeduction1val.Text = "";
            txtdeduction2.Text = "";
            txtdeduction3val.Text = "";
            txtcashAdvance.Text = "";
            txtspecialhol.Text = "";
            txtHollidayPay.Text = "";
            txtHoursOT.Text = "";
            txtNumDays.Text = "";
            txtPagibig.Text = "";
            txtPhilhealth.Text = "";
            txtRatewage.Text = "";
            txtRegOTperDay.Text = "";
            txtSSS.Text = "";
            txtTotaldeduction.Text = "";
            txtWithholding.Text = "";
            btnSave.IsEnabled = true;
        }
        //This is to save the payroll details on the database
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtEmployeeId1.Text != "" || txtNumDays.Text != "" || txtEmployeeName.Text != "" || txtDailyRate.Text != "" || txtBasicPay.Text != "" || txtNetIncome.Text != "" || txtTotaldeduction.Text != "" || PayDay.Text != "")
                {
                    String query = "INSERT INTO `tbl_payroll` (`EID`,`PayDay`,`Num_days`,`Days_onleave`,`RateWage`, `Overtime`, `OThours`,`NightDifferential`,`HollPay`,`Basic_Pay`,`Cash_ad`,`Philhealth`,`WithholdingTax`,`Pagibig`,`SSS`,`Deduc1`,`Deduc1_amt`,`Deduc2`,`Deduc2_amt`,`Deduc3`,`Deduc3_amt`,`Total_deduc`, `Net_income`, `dateIssued`) VALUES (@EID, @payday, @numdays, @onleave, @ratewage, @overtime, @othours, @nd, @hollpay, @basicpay, @cashad, @philhealth, @withholding, @pagibig, @SSS, @d1, @da1, @d2, @da2, @d3, @da3, @totald, @netincome, @dateissued)";
                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    commandDatabase.Parameters.AddWithValue("@EID", txtEmployeeId1.Text);
                    commandDatabase.Parameters.AddWithValue("@payday", Convert.ToDateTime(PayDay.Text));
                    commandDatabase.Parameters.AddWithValue("@numdays", Convert.ToDouble(txtNumDays.Text));
                    commandDatabase.Parameters.AddWithValue("@onleave", Convert.ToDouble(txtLeave.Text));
                    commandDatabase.Parameters.AddWithValue("@ratewage", Convert.ToDouble(txtRatewage.Text));
                    commandDatabase.Parameters.AddWithValue("@overtime", Convert.ToDouble(txtRegOTperDay.Text));
                    commandDatabase.Parameters.AddWithValue("@othours", Convert.ToDouble(txtHoursOT.Text));
                    commandDatabase.Parameters.AddWithValue("@nd", Convert.ToDouble(txtDifferential.Text));
                    commandDatabase.Parameters.AddWithValue("@hollpay", Convert.ToDouble(txtHollidayPay.Text));
                    commandDatabase.Parameters.AddWithValue("@basicpay", Convert.ToDouble(txtBasicPay.Text));
                    commandDatabase.Parameters.AddWithValue("@cashad", Convert.ToDouble(txtcashAdvance.Text));
                    commandDatabase.Parameters.AddWithValue("@philhealth", Convert.ToDouble(txtPhilhealth.Text));
                    commandDatabase.Parameters.AddWithValue("@withholding", Convert.ToDouble(txtWithholding.Text));
                    commandDatabase.Parameters.AddWithValue("@pagibig", Convert.ToDouble(txtPagibig.Text));
                    commandDatabase.Parameters.AddWithValue("@SSS", Convert.ToDouble(txtSSS.Text));
                    commandDatabase.Parameters.AddWithValue("@d1", txtdeduction1.Text);
                    commandDatabase.Parameters.AddWithValue("@da1", Convert.ToDouble(txtdeduction1val.Text));
                    commandDatabase.Parameters.AddWithValue("@d2", txtdeduction2.Text);
                    commandDatabase.Parameters.AddWithValue("@da2", Convert.ToDouble(txtdeduction2val.Text));
                    commandDatabase.Parameters.AddWithValue("@d3", txtdeduction3.Text);
                    commandDatabase.Parameters.AddWithValue("@da3", Convert.ToDouble(txtdeduction3val.Text));
                    commandDatabase.Parameters.AddWithValue("@totald", Convert.ToDouble(txtTotaldeduction.Text));
                    commandDatabase.Parameters.AddWithValue("@netincome", Convert.ToDouble(txtNetIncome.Text));
                    commandDatabase.Parameters.AddWithValue("@dateissued", Convert.ToDateTime(EditDateChecker.Text));
                    commandDatabase.CommandTimeout = 60;
                    databaseConnection.Open();
                    MySqlDataReader myReader = commandDatabase.ExecuteReader();
                    databaseConnection.Close();
                    MessageBox.Show("Successfully Generated Payroll for " + txtEmployeeId1.Text + "!");
                    transactionGenerate();
                    listPayroll();
                }
                else
                {
                    MessageBox.Show("Please input necessary data first!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //This is the method is for the Audit trail (Generating payroll)
        public void transactionGenerate()
        {
            try
            {
                string query2 = "INSERT INTO  `tbl_audit_trail` (`UserResponsible`, `TransactionHistory`, `DateOfTransaction`)  VALUES (@user, @history, @date)";
                MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection2);
                commandDatabase2.Parameters.AddWithValue("@user", "SUPER ADMIN");
                commandDatabase2.Parameters.AddWithValue("@history", "Generate a payroll for " + txtEmployeeName.Text + " (" + txtEmployeeId1.Text + ").");
                commandDatabase2.Parameters.AddWithValue("@date", DateTime.Now);
                commandDatabase2.CommandTimeout = 60;
                MySqlDataReader reader2;
                databaseConnection2.Open();
                reader2 = commandDatabase2.ExecuteReader();
                databaseConnection2.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //This is the method is for the Audit trail (Creating Payslip)
        public void payslipCreated()
        {
            try
            {
                string query2 = "INSERT INTO  `tbl_audit_trail` (`UserResponsible`, `TransactionHistory`, `DateOfTransaction`)  VALUES (@user, @history, @date)";
                MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection2);
                commandDatabase2.Parameters.AddWithValue("@user", "SUPER ADMIN");
                commandDatabase2.Parameters.AddWithValue("@history", "Created a payslip for " + txtEmployeeName.Text + " (" + txtEmployeeId1.Text + ").");
                commandDatabase2.Parameters.AddWithValue("@date", DateTime.Now);
                commandDatabase2.CommandTimeout = 60;
                MySqlDataReader reader2;
                databaseConnection2.Open();
                reader2 = commandDatabase2.ExecuteReader();
                databaseConnection2.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //This is the method is for the Audit trail (Updating Payroll)
        public void PayrollUpdate()
        {
            try
            {
                string query2 = "INSERT INTO  `tbl_audit_trail` (`UserResponsible`, `TransactionHistory`, `DateOfTransaction`)  VALUES (@user, @history, @date)";
                MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection2);
                commandDatabase2.Parameters.AddWithValue("@user", "SUPER ADMIN");
                commandDatabase2.Parameters.AddWithValue("@history", "Edited the payroll of employee " + txtEmployeeName.Text + " (" + txtEmployeeId1.Text + ").");
                commandDatabase2.Parameters.AddWithValue("@date", DateTime.Now);
                commandDatabase2.CommandTimeout = 60;
                MySqlDataReader reader2;
                databaseConnection2.Open();
                reader2 = commandDatabase2.ExecuteReader();
                databaseConnection2.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchedEmployee();
            if (txtSearch.Text == "")
            {
                listEmployees();
            }
        }
        //Method to search on the Payroll list (Employee ID only works! Work on this!)
        public void searchedPay()
        {
            try
            {
                lvPayroll.Items.Clear();
                string query = "SELECT * FROM `tbl_payroll` WHERE `EID` LIKE '" + txtSearchPay.Text + "%' ORDER BY `dateIssued` DESC";
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
        public void searchedEmployee()
        {
            dtgemplist.Items.Clear();
            string query = "SELECT `tbl_employee`.`EID`, `tbl_employee`.`LastName`, `tbl_employee`.`FirstName`, `tbl_employee`.`MiddleName`, `tbl_employee`.`Sex`, `tbl_employee`.`Birthdate`, `tbl_employee`.`House_num`, `tbl_employee`.`Street`, `tbl_brgy`.`brgyDesc`, `tbl_city`.`cityDesc`, `tbl_province`.`provDesc`, `tbl_region`.`regDesc`, `tbl_employee`.`MaritalStatus`, `tbl_employee`.`Contact`, `tbl_employee`.`Emergency_Contact`, `tbl_employee_workinfo`.`Position`, `tbl_employee_workinfo`.`DailyRate`, `tbl_employee_workinfo`.`WorkStatus`, `tbl_employee_workinfo`.`HiredDate` FROM `tbl_employee`"
                + "LEFT JOIN `tbl_brgy` ON `tbl_employee`.`brgyCode` = `tbl_brgy`.`brgyCode` "
                + "LEFT JOIN `tbl_city` ON `tbl_brgy`.`cityCode` = `tbl_city`.`cityCode` "
                + "LEFT JOIN `tbl_province` ON `tbl_city`.`provCode` = `tbl_province`.`provCode` "
                + "LEFT JOIN `tbl_region` ON `tbl_province`.`regCode` = `tbl_region`.`regCode` "
                + "LEFT JOIN `tbl_employee_workinfo` ON `tbl_employee_workinfo`.`EID` = `tbl_employee`.`EID` WHERE `tbl_employee_workinfo`.`WorkStatus` = 'Active' AND  `tbl_employee`.`EID` LIKE '" + txtSearch.Text + "%' OR `tbl_employee`.`LastName` LIKE '" + txtSearch.Text + "%' AND `tbl_employee_workinfo`.`WorkStatus` = 'Active' OR `tbl_employee`.`FirstName` LIKE '" + txtSearch.Text + "%' AND `tbl_employee_workinfo`.`WorkStatus` = 'Active' OR `tbl_employee`.`Sex` LIKE '" + txtSearch.Text + "%' AND `tbl_employee_workinfo`.`WorkStatus` = 'Active' OR `tbl_brgy`.`brgyDesc` LIKE '" + txtSearch.Text + "%' AND `tbl_employee_workinfo`.`WorkStatus` = 'Active' ";

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
        // Method to search for employee
        public void searchedResult()
        {
            try
            {
                if (txtEmployeeId1.Text != "")
                {
                    string query = "SELECT * FROM `tbl_employee` WHERE `EID` LIKE '" + txtEmployeeId1.Text + "%'";
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
                            txtEmployeeName.Text = reader.GetString(3) + ", " + reader.GetString(1) + " " + reader.GetString(2);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    databaseConnection.Close();


                    string query1 = "SELECT * FROM `tbl_employee_workinfo` WHERE EID = @EID";
                    MySqlConnection databaseConnection1 = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase1 = new MySqlCommand(query1, databaseConnection1);
                    commandDatabase1.Parameters.AddWithValue("@EID", txtEmployeeId1.Text);
                    commandDatabase1.CommandTimeout = 60;
                    MySqlDataReader reader1;

                    databaseConnection1.Open();
                    reader1 = commandDatabase1.ExecuteReader();
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            txtDailyRate.Text = Convert.ToString(reader1.GetDouble(2));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    databaseConnection1.Close();
                }
                else
                {
                    clearAll();
                }
            }
            catch (Exception) { }
        }

        //Text changed event for the regular number of days na ipinasok ng employee
        private void txtNumDays_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double rateWage, numberofdays;
                double dailyratesample, basicpay, netincome, nd, ot, holpay;
                if (txtNumDays.Text == "" || txtNumDays.Text == "0")
                {
                    txtRatewage.Text = "0";
                }
                else
                {
                    if (txtLeave.Text == "" || txtLeave.Text == "0")
                    {
                        txtLeave.Text = "0";
                    }
                    if (txtDifferential.Text == "" || txtDifferential.Text == "0")
                    {
                        txtDifferential.Text = "0";
                    }
                    if (txtHoursOT.Text == "" || txtHoursOT.Text == "0")
                    {
                        txtRegOTperDay.Text = "0";
                    }
                    if (txtholnumdays.Text == "" || txtholnumdays.Text == "0")
                    {
                        txtholnumdays.Text = "0";
                    }
                    if (txtholnumdays.Text == "" || txtholnumdays.Text == "0")
                    {
                        txtHollidayPay.Text = "0";
                    }
                    if (txtspecialhol.Text == "" || txtspecialhol.Text == "0")
                    {
                        txtspecialhol.Text = "0";
                    }
                    if (txtHoursOT.Text == "" || txtHoursOT.Text == "0")
                    {
                        txtHoursOT.Text = "0";
                    }
                    ot = Convert.ToDouble(this.txtRegOTperDay.Text);
                    holpay = Convert.ToDouble(this.txtHollidayPay.Text);
                    nd = Convert.ToDouble(txtDifferential.Text);
                    numberofdays = Double.Parse(txtNumDays.Text) + Double.Parse(txtLeave.Text);
                    dailyratesample = Double.Parse(txtDailyRate.Text);
                    rateWage = numberofdays * dailyratesample;
                    Math.Round(rateWage);
                    txtRatewage.Text = rateWage.ToString("0.00");
                    calc_dedution();
                    basicpay = rateWage + ot + holpay + nd;
                    Math.Round(basicpay);
                    txtBasicPay.Text = basicpay.ToString("0.00");
                    netincome = basicpay - double.Parse(txtTotaldeduction.Text);
                    Math.Round(netincome);
                    txtNetIncome.Text = netincome.ToString("0.00");
                    pagibig();
                    sss();
                    philhealth();
                    withholding();
                }
            }
            catch (Exception) { }
        }
        //Method to compute Pag-ibig Deduction (Nababawasan talaga ang pag-ibig)
        public void pagibig()
        {
            double monthly;
            try
            {
                string query = "SELECT * FROM `tbl_pagibig`";
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
                        monthly = Convert.ToDouble(txtDailyRate.Text) * 22;
                        double pagibigs = reader.GetDouble(3) * monthly;
                        Math.Round(pagibigs);
                        txtPagibig.Text = pagibigs.ToString("0.00");
                    }
                }
            }
            catch (Exception) { }
        }
        //Method to Compute the SSS deduction
        public void sss()
        {
            try
            {
                double monthly;
                monthly = Convert.ToDouble(txtDailyRate.Text) * 22;
                string query = "SELECT * FROM `tbl_sss` WHERE '" + monthly + "'<= `s_to` and '" + monthly + "' >= `s_from`";
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
                        txtSSS.Text = Convert.ToString(reader.GetDouble(5));
                    }
                }
            }
            catch (Exception) { }
        }
        public void withholding()
        {
            try
            {
                double monthly, cl, tax, final;
                monthly = Convert.ToDouble(txtDailyRate.Text) * 22;
                string query = "SELECT * FROM `tbl_withholding_tax` WHERE '" + monthly + "'<= `cl_to` and '" + monthly + "' >= `cl_from`";
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
                        if (reader.GetDouble(1) == 0)
                        {
                            txtWithholding.Text = "0";
                        }
                        else
                        {
                            cl = monthly - reader.GetDouble(1);
                            tax = cl * reader.GetDouble(4);
                            final = tax + reader.GetDouble(3);
                            Math.Round(final);
                            txtWithholding.Text = final.ToString("0.00");
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        //Method to Compute for the Philhealth Deduction
        public void philhealth()
        {
            try
            {
                double monthly, mbs, per;
                monthly = Convert.ToDouble(txtDailyRate.Text) * 22;
                string query = "SELECT * FROM `tbl_philhealth` WHERE '" + monthly + "'<= `monthly_to` and '" + monthly + "' >= `monthly_from`";
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
                        if (reader.GetDouble(6) == 549.99)
                        {
                            monthly = Convert.ToDouble(txtDailyRate.Text) * 22;
                            mbs = monthly * 0.0275;
                            per = mbs / 2;
                            Math.Round(per);
                            txtPhilhealth.Text = per.ToString("0.00");
                        }
                        else
                        {
                            txtPhilhealth.Text = Convert.ToString(reader.GetDouble(6));
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        //Textchanged event for the Overtime Hours 
        private void txtHoursOT_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double total, total_OT, basicpay, netincome, ot, holpay, rateWage;
                if (txtHoursOT.Text == "" || txtHoursOT.Text == "0")
                {
                    txtRegOTperDay.Text = "0";
                }
                else
                {
                    total = Double.Parse(txtDailyRate.Text) / 8;
                    total_OT = total * Double.Parse(txtHoursOT.Text);
                    Math.Round(total_OT);
                    txtRegOTperDay.Text = total_OT.ToString("0.00");
                }
                if (txtDifferential.Text == "" || txtDifferential.Text == "0")
                {
                    txtDifferential.Text = "0";
                }
                double nd = Convert.ToDouble(txtDifferential.Text);
                ot = double.Parse(txtRegOTperDay.Text);
                holpay = double.Parse(txtHollidayPay.Text);
                rateWage = double.Parse(txtRatewage.Text);
                basicpay = rateWage + ot + holpay + nd;
                Math.Round(basicpay);
                txtBasicPay.Text = basicpay.ToString("0.00");
                calc_dedution();
                netincome = basicpay - double.Parse(txtTotaldeduction.Text);
                Math.Round(netincome);
                txtNetIncome.Text = netincome.ToString("0.00");
            }
            catch { }
        }
        // Textchanged Event for the number of regular holliday days
        private void txtholnumdays_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double holpay, non, hollidaypay, pay, dailyrate, ot, ratewage, basicpay, netincome, nd, numdays, special, specialpay, day;
                day = double.Parse(txtDailyRate.Text);
                ot = double.Parse(txtRegOTperDay.Text);
                ratewage = double.Parse(txtRatewage.Text);
                nd = double.Parse(txtDifferential.Text);
                numdays = double.Parse(txtholnumdays.Text);
                special = double.Parse(txtspecialhol.Text);
                specialpay = day * .30;
                hollidaypay = Double.Parse(txtDailyRate.Text);
                dailyrate = hollidaypay * 2;
                pay = numdays * dailyrate;
                non = specialpay * special;
                holpay = non + pay;
                Math.Round(holpay);
                txtHollidayPay.Text = holpay.ToString("0.00");
                basicpay = ratewage + ot + holpay + nd;
                Math.Round(basicpay);
                txtBasicPay.Text = basicpay.ToString("0.00");
                calc_dedution();
                netincome = basicpay - double.Parse(txtTotaldeduction.Text);
                Math.Round(netincome);
                txtNetIncome.Text = netincome.ToString("0.00");
            }
            catch (Exception) { }
        }
        //This are the Textchanged events for other deductions that needs to be manually inputted.
        private void txtcashAdvance_TextChanged(object sender, TextChangedEventArgs e)
        {
            calc_dedution();
        }
        private void txtdeduction1val_TextChanged(object sender, TextChangedEventArgs e)
        {
            calc_dedution();
        }
        private void txtdeduction2val_TextChanged(object sender, TextChangedEventArgs e)
        {
            calc_dedution();
        }
        private void txtdeduction3val_TextChanged(object sender, TextChangedEventArgs e)
        {
            calc_dedution();
        }
        //Method for selecting an index in the listview 
        private void dtgemplist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dtgemplist.SelectedIndex > -1)
                {
                    currUser = (Employees)dtgemplist.SelectedItem;
                    txtEmployeeId1.Text = currUser.EmployeeID.ToString();
                    string query1 = "SELECT * FROM `tbl_employee` WHERE EID = @EID";
                    MySqlConnection databaseConnection1 = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase1 = new MySqlCommand(query1, databaseConnection1);
                    commandDatabase1.Parameters.AddWithValue("@EID", txtEmployeeId1.Text);
                    commandDatabase1.CommandTimeout = 60;
                    MySqlDataReader reader1;
                    databaseConnection1.Open();
                    reader1 = commandDatabase1.ExecuteReader();
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            txtEmployeeName.Text = reader1.GetString(3) + ", " + reader1.GetString(1) + " " + reader1.GetString(2);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    databaseConnection1.Close();
                }
            }
            catch (Exception)
            { }
            try
            {
                string query = "SELECT * FROM `tbl_employee_workinfo` WHERE EID = @EID";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@EID", txtEmployeeId1.Text);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtDailyRate.Text = Convert.ToString(reader.GetDouble(2));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                databaseConnection.Close();
                btnUpdate.IsEnabled = false;
                btnSave.IsEnabled = true;
            }
            catch (Exception) { }
        }
        //Text Changed Event for the Search field (Automatically shows the result)
        private void txtSearchPay_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchedPay();
            if (txtSearchPay.Text == "")
            {
                listPayroll();
            }
        }
        // Text Changed event for special non-working holliday textbox 
        private void txtspecialhol_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double holpay, non, hollidaypay, pay, dailyrate, ot, ratewage, basicpay, netincome, nd, numdays, special, specialpay, day;
                day = double.Parse(txtDailyRate.Text);
                ot = double.Parse(txtRegOTperDay.Text);
                ratewage = double.Parse(txtRatewage.Text);
                nd = double.Parse(txtDifferential.Text);
                numdays = double.Parse(txtholnumdays.Text);
                special = double.Parse(txtspecialhol.Text);
                specialpay = day * .30;
                hollidaypay = Double.Parse(txtDailyRate.Text);
                dailyrate = hollidaypay * 2;
                pay = numdays * dailyrate;
                non = specialpay * special;
                holpay = non + pay;
                Math.Round(holpay);
                txtHollidayPay.Text = holpay.ToString("0.00");
                basicpay = ratewage + ot + holpay + nd;
                Math.Round(basicpay);
                txtBasicPay.Text = basicpay.ToString("0.00");
                calc_dedution();
                netincome = basicpay - double.Parse(txtTotaldeduction.Text);
                Math.Round(netincome);
                txtNetIncome.Text = netincome.ToString("0.00");
            }
            catch (Exception)
            { }
        }
        // Text Changed Event for "Number of Days on Leave" textbox
        private void txtLeave_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double rateWage, numberofdays;
                double dailyratesample, basicpay, netincome, nd, ot, holpay;
                if (txtNumDays.Text == "" || txtNumDays.Text == "0")
                {
                    txtRatewage.Text = "0";
                }
                else
                {
                    if (txtLeave.Text == "" || txtLeave.Text == "0")
                    {
                        txtLeave.Text = "0";
                    }
                    if (txtDifferential.Text == "" || txtDifferential.Text == "0")
                    {
                        txtDifferential.Text = "0";
                    }
                    if (txtHoursOT.Text == "" || txtHoursOT.Text == "0")
                    {
                        txtRegOTperDay.Text = "0";
                    }
                    if (txtholnumdays.Text == "" || txtholnumdays.Text == "0")
                    {
                        txtholnumdays.Text = "0";
                    }
                    if (txtholnumdays.Text == "" || txtholnumdays.Text == "0")
                    {
                        txtHollidayPay.Text = "0";
                    }
                    if (txtspecialhol.Text == "" || txtspecialhol.Text == "0")
                    {
                        txtspecialhol.Text = "0";
                    }
                    if (txtHoursOT.Text == "" || txtHoursOT.Text == "0")
                    {
                        txtHoursOT.Text = "0";
                    }
                    ot = Convert.ToDouble(this.txtRegOTperDay.Text);
                    holpay = Convert.ToDouble(this.txtHollidayPay.Text);
                    nd = Convert.ToDouble(txtDifferential.Text);
                    numberofdays = Double.Parse(txtNumDays.Text) + Double.Parse(txtLeave.Text);
                    dailyratesample = Double.Parse(txtDailyRate.Text);
                    rateWage = numberofdays * dailyratesample;
                    Math.Round(rateWage);
                    txtRatewage.Text = rateWage.ToString("0.00");
                    calc_dedution();
                    basicpay = rateWage + ot + holpay + nd;
                    Math.Round(basicpay);
                    txtBasicPay.Text = basicpay.ToString("0.00");
                    netincome = basicpay - double.Parse(txtTotaldeduction.Text);
                    Math.Round(netincome);
                    txtNetIncome.Text = netincome.ToString("0.00");
                    pagibig();
                    sss();
                    philhealth();
                    withholding();
                }
            }
            catch (Exception)
            { }
        }
        //On-click Event to generate payroll of selected employee
        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (dtgemplist.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select an employee first!!");
            }
            else
            {

                btnSave.IsEnabled = true;
                btnUpdate.IsEnabled = false;
                txtholnumdays.Text = "";
                txtDifferential.Text = "";
                txtBasicPay.Text = "";
                PayDay.Text = "";
                txtcashAdvance.Text = "";
                txtdeduction1.Text = "";
                txtdeduction1val.Text = "";
                txtdeduction2.Text = "";
                txtdeduction2val.Text = "";
                txtdeduction3.Text = "";
                txtdeduction3val.Text = "";
                txtSSS.Text = "";
                txtWithholding.Text = "";
                txtPagibig.Text = "";
                txtPhilhealth.Text = "";
                txtspecialhol.Text = "";
                txtLeave.Text = "";
                txtHollidayPay.Text = "";
                txtHoursOT.Text = "";
                txtNetIncome.Text = "";
                txtNumDays.Text = "";
                txtRatewage.Text = "";
                txtRegOTperDay.Text = "";
                txtTotaldeduction.Text = "";
                pagibig();
                sss();
                philhealth();
                withholding();
                int index = tabControl.SelectedIndex - 1;
                tabControl.SelectedIndex = index;
                btnSave.IsEnabled = true;
                btnUpdate.IsEnabled = false;
                lvPayroll.SelectedIndex = -1;

            }
        }

        private void btnEditPayroll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lvPayroll.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select the Payroll record that you want to edit.");
                }
                else
                {
                    if (di.Text == EditDateChecker.Text)
                    {
                        int index = tabControl.SelectedIndex - 2;
                        tabControl.SelectedIndex = index;
                        btnUpdate.IsEnabled = true;
                        btnSave.IsEnabled = false;
                        currPay = (Pays)lvPayroll.SelectedItem;
                        txtEmployeeId1.Text = currPay.EID.ToString();
                        string query1 = "SELECT * FROM `tbl_employee` WHERE EID = @EID";
                        MySqlConnection databaseConnection1 = new MySqlConnection(connectionString);
                        MySqlCommand commandDatabase1 = new MySqlCommand(query1, databaseConnection1);
                        commandDatabase1.Parameters.AddWithValue("@EID", txtEmployeeId1.Text);
                        commandDatabase1.CommandTimeout = 60;
                        MySqlDataReader reader1;
                        databaseConnection1.Open();
                        reader1 = commandDatabase1.ExecuteReader();
                        if (reader1.HasRows)
                        {
                            while (reader1.Read())
                            {
                                txtEmployeeName.Text = reader1.GetString(3) + ", " + reader1.GetString(1) + " " + reader1.GetString(2);
                            }
                        }
                        databaseConnection1.Close();
                        string query = "SELECT * FROM `tbl_employee_workinfo` WHERE EID = @EID";
                        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                        commandDatabase.Parameters.AddWithValue("@EID", txtEmployeeId1.Text);
                        commandDatabase.CommandTimeout = 60;
                        MySqlDataReader reader;
                        databaseConnection.Open();
                        reader = commandDatabase.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                txtDailyRate.Text = Convert.ToString(reader.GetDouble(2));
                            }
                        }
                        databaseConnection.Close();
                        txtNumDays.Text = currPay.Num_days.ToString();
                        txtRatewage.Text = currPay.RateWage.ToString();
                        txtLeave.Text = currPay.Leave.ToString();
                        txtHoursOT.Text = currPay.OThours.ToString();
                        txtRegOTperDay.Text = currPay.Overtime.ToString();
                        txtDifferential.Text = currPay.NightDifferential.ToString();
                        txtHollidayPay.Text = currPay.HollPay.ToString();
                        txtBasicPay.Text = currPay.Basic_Pay.ToString();
                        txtcashAdvance.Text = currPay.Cash_ad.ToString();
                        txtWithholding.Text = currPay.WithholdingTax.ToString();
                        txtNetIncome.Text = currPay.Net_income.ToString();
                        PayDay.Text = currPay.PayDay.ToString();
                        txtdeduction1.Text = currPay.d1.ToString();
                        txtdeduction1val.Text = currPay.da1.ToString();
                        txtdeduction2.Text = currPay.d2.ToString();
                        txtdeduction2val.Text = currPay.da2.ToString();
                        txtdeduction3.Text = currPay.d3.ToString();
                        txtdeduction3val.Text = currPay.da3.ToString();
                        txtTotaldeduction.Text = currPay.totald.ToString();
                        di.Text = currPay.DateIssued.ToString();
                        pagibig();
                        sss();
                        philhealth();
                    }
                    else if (EditDateChecker.Text != di.Text)
                    {
                        MessageBox.Show("Ops. The payroll you're trying to edit is past the duetime that it is editable. You can only edit payroll on the same day it is issued. Thank you!");
                        lvPayroll.SelectedIndex = -1;
                        di.Text = "";
                    }
                }
            }
            catch (Exception) { }
        }

        //This is the code for updating an existing payroll
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (txtEmployeeId1.Text != "" || txtNumDays.Text != "" || txtEmployeeName.Text != "" || txtDailyRate.Text != "" || txtBasicPay.Text != "" || txtNetIncome.Text != "" || txtTotaldeduction.Text != "" || PayDay.Text != "")
                {
                    String query = "UPDATE `tbl_payroll` SET `EID`= @EID,`PayDay`= @payday,`Num_days`= @numdays,`Days_onleave`= @onleave,`RateWage`= @ratewage, `Overtime`= @overtime, `OThours`= @othours,`NightDifferential`= @nd,`HollPay`= @hollpay,`Basic_Pay`= @basicpay,`Cash_ad`= @cashad,`Philhealth`= @philhealth,`WithholdingTax`= @withholding,`Pagibig`= @pagibig,`SSS`= @SSS,`Deduc1`= @d1,`Deduc1_amt`= @da1,`Deduc2`= @d2,`Deduc2_amt`= @da2,`Deduc3`= @d3,`Deduc3_amt`= @da3,`Total_deduc`= @totald, `Net_income`= @netincome, `dateIssued`= @dateissued WHERE EID = @EID AND `dateIssued`= @dateissued";
                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    commandDatabase.Parameters.AddWithValue("@EID", txtEmployeeId1.Text);
                    commandDatabase.Parameters.AddWithValue("@payday", Convert.ToDateTime(PayDay.Text));
                    commandDatabase.Parameters.AddWithValue("@numdays", Convert.ToDouble(txtNumDays.Text));
                    commandDatabase.Parameters.AddWithValue("@onleave", Convert.ToDouble(txtLeave.Text));
                    commandDatabase.Parameters.AddWithValue("@ratewage", Convert.ToDouble(txtRatewage.Text));
                    commandDatabase.Parameters.AddWithValue("@overtime", Convert.ToDouble(txtRegOTperDay.Text));
                    commandDatabase.Parameters.AddWithValue("@othours", Convert.ToDouble(txtHoursOT.Text));
                    commandDatabase.Parameters.AddWithValue("@nd", Convert.ToDouble(txtDifferential.Text));
                    commandDatabase.Parameters.AddWithValue("@hollpay", Convert.ToDouble(txtHollidayPay.Text));
                    commandDatabase.Parameters.AddWithValue("@basicpay", Convert.ToDouble(txtBasicPay.Text));
                    commandDatabase.Parameters.AddWithValue("@cashad", Convert.ToDouble(txtcashAdvance.Text));
                    commandDatabase.Parameters.AddWithValue("@philhealth", Convert.ToDouble(txtPhilhealth.Text));
                    commandDatabase.Parameters.AddWithValue("@withholding", Convert.ToDouble(txtWithholding.Text));
                    commandDatabase.Parameters.AddWithValue("@pagibig", Convert.ToDouble(txtPagibig.Text));
                    commandDatabase.Parameters.AddWithValue("@SSS", Convert.ToDouble(txtSSS.Text));
                    commandDatabase.Parameters.AddWithValue("@d1", txtdeduction1.Text);
                    commandDatabase.Parameters.AddWithValue("@da1", Convert.ToDouble(txtdeduction1val.Text));
                    commandDatabase.Parameters.AddWithValue("@d2", txtdeduction2.Text);
                    commandDatabase.Parameters.AddWithValue("@da2", Convert.ToDouble(txtdeduction2val.Text));
                    commandDatabase.Parameters.AddWithValue("@d3", txtdeduction3.Text);
                    commandDatabase.Parameters.AddWithValue("@da3", Convert.ToDouble(txtdeduction3val.Text));
                    commandDatabase.Parameters.AddWithValue("@totald", Convert.ToDouble(txtTotaldeduction.Text));
                    commandDatabase.Parameters.AddWithValue("@netincome", Convert.ToDouble(txtNetIncome.Text));
                    commandDatabase.Parameters.AddWithValue("@dateissued", EditDateChecker.Text);
                    commandDatabase.CommandTimeout = 60;
                    databaseConnection.Open();
                    MySqlDataReader myReader = commandDatabase.ExecuteReader();
                    databaseConnection.Close();
                    MessageBox.Show("Successfully Updated Payroll for " + txtEmployeeId1.Text + "!");
                    PayrollUpdate();
                    listPayroll();
                    clearAll();
                }
                else
                {
                    MessageBox.Show("Please input necessary data first!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lvPayroll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (lvPayroll.SelectedIndex > -1)
                {
                    currPay = (Pays)lvPayroll.SelectedItem;
                    di.Text = currPay.DateIssued.ToString();
                    btnSave.IsEnabled = false;
                    btnUpdate.IsEnabled = true;
                }
                else
                {
                    currPay = null;
                    btnSave.IsEnabled = true;
                    btnUpdate.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtDifferential_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double rateWage, numberofdays;
                double dailyratesample, basicpay, netincome, nd, ot, holpay;
                if (txtNumDays.Text == "" || txtNumDays.Text == "0")
                {
                    txtRatewage.Text = "0";
                }
                else
                {
                    if (txtLeave.Text == "" || txtLeave.Text == "0")
                    {
                        txtLeave.Text = "0";
                    }
                    if (txtDifferential.Text == "" || txtDifferential.Text == "0")
                    {
                        txtDifferential.Text = "0";
                    }
                    if (txtHoursOT.Text == "" || txtHoursOT.Text == "0")
                    {
                        txtRegOTperDay.Text = "0";
                    }
                    if (txtholnumdays.Text == "" || txtholnumdays.Text == "0")
                    {
                        txtholnumdays.Text = "0";
                    }
                    if (txtholnumdays.Text == "" || txtholnumdays.Text == "0")
                    {
                        txtHollidayPay.Text = "0";
                    }
                    if (txtspecialhol.Text == "" || txtspecialhol.Text == "0")
                    {
                        txtspecialhol.Text = "0";
                    }
                    if (txtHoursOT.Text == "" || txtHoursOT.Text == "0")
                    {
                        txtHoursOT.Text = "0";
                    }
                    ot = Convert.ToDouble(this.txtRegOTperDay.Text);
                    holpay = Convert.ToDouble(this.txtHollidayPay.Text);
                    nd = Convert.ToDouble(txtDifferential.Text);
                    numberofdays = Double.Parse(txtNumDays.Text) + Double.Parse(txtLeave.Text);
                    dailyratesample = Double.Parse(txtDailyRate.Text);
                    rateWage = numberofdays * dailyratesample;
                    Math.Round(rateWage);
                    txtRatewage.Text = rateWage.ToString("0.00");
                    calc_dedution();
                    basicpay = rateWage + ot + holpay + nd;
                    Math.Round(basicpay);
                    txtBasicPay.Text = basicpay.ToString("0.00");
                    netincome = basicpay - double.Parse(txtTotaldeduction.Text);
                    Math.Round(netincome);
                    txtNetIncome.Text = netincome.ToString("0.00");

                }
            }
            catch (Exception) { }
        }
        //onclick event for the toggle menu
        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("WHO ARE WE? \n\n\tWith a team of dedicated IT students of Pamantasan ng Lungsod ng Valenzuela, TvCon Payroll System was created on December 3, 2019. TvCon Payroll System was designed to meet the company's specific needs. The Payroll System take away the hassle of creating payroll and managing employee records. It allows the user to experience stress-free managing and monitoring of records.Our leadership team is dedicated to create a system that is easy to use, efficient and helpful.", "ABOUT US", MessageBoxButton.OK, MessageBoxImage.None);
        }
        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("\nCONTACT US \n\nGet in touch with us. We gladly welcome your inquiries and feedback. Please feel free to contact us at our email (Tvcon09@gmail.com) and contact number(09771865983). \n\nHAVE A GOOD DAY!", "HELP", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        private void btnCalendar_Click(object sender, RoutedEventArgs e)
        {
            pmCalendar calendar = new pmCalendar();
            calendar.Show();
        }
        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("HELP \nHow do I start? \nGo to the employee list tab then click the employee that you want to create a payroll. However, you cannot add, edit, nor delete employee records. You can also use the search textfield to look for the employee that you are searching. \n\nDo I input everything manually? \nYou don't have to input every data manually. The program will calculate it for you.\n\nWhat are the data that I need to input? \nYou need to Input the number of days the employee goes to work, the number of Overtime hours, Night Differential if the employee is night shift, the number of holliday(how many days) and the deductions if there is any.\nAfter generating the payroll you can click the 'Create Payslip' button that will open a word document ready for printing. Then you can now create another payroll by clicking the employee on the employee list.\n\nIMPORTANT NOTE: You can only edit the payroll on the same day that you created the payroll. Please check the information you input carefully before saving it.\n\nHopefully this is helpful for you! \n\nHave a good day!!", "HELP", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        //Code to validate the input of the user (Accept only integer and decimal point)
        private bool IsNumber(string Text)
        {
            int output;
            return int.TryParse(Text, out output);
        }
        private void Textbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != "." && IsNumber(e.Text) == false)
            {
                e.Handled = true;
            }
            else if (e.Text == ".")
            {
                if (((TextBox)sender).Text.IndexOf(e.Text) > -1)
                {
                    e.Handled = true;
                }
            }
        }

        //Find and Replace Method
        private void FindAndReplace(Word.Application wordApp, object ToFindText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllforms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref ToFindText,
                ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundLike,
                ref nmatchAllforms, ref forward,
                ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchKashida,
                ref matchDiactitics, ref matchAlefHamza,
                ref matchControl);
        }

        //Creeate the Doc Method
        private void CreateWordDocument(object filename, object SaveAs)
        {
            try
            {
                Word.Application wordApp = new Word.Application();
                object missing = Missing.Value;
                Word.Document myWordDoc = null;

                if (File.Exists((string)filename))
                {
                    object readOnly = false;
                    object isVisible = false;
                    wordApp.Visible = true;

                    myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing, ref missing);
                    myWordDoc.Activate();

                    //find and replace
                    this.FindAndReplace(wordApp, "<EmployeeId>", txtEmployeeId1.Text);
                    this.FindAndReplace(wordApp, "<EmployeeName>", txtEmployeeName.Text);
                    this.FindAndReplace(wordApp, "<PayDay>", PayDay.Text);
                    this.FindAndReplace(wordApp, "<Daily Rate>", txtDailyRate.Text);
                    this.FindAndReplace(wordApp, "<Regular>", txtNumDays.Text);
                    this.FindAndReplace(wordApp, "<Rate Wage>", txtRatewage.Text);
                    this.FindAndReplace(wordApp, "<On-Leave>", txtLeave.Text);
                    this.FindAndReplace(wordApp, "<Holiday Pay>", txtHollidayPay.Text);
                    this.FindAndReplace(wordApp, "<Regular Holiday>", txtholnumdays.Text);
                    this.FindAndReplace(wordApp, "<Hours of Overtime>", txtHoursOT.Text);
                    this.FindAndReplace(wordApp, "<Special Holiday>", txtspecialhol.Text);
                    this.FindAndReplace(wordApp, "<Regular Overtime>", txtRegOTperDay.Text);
                    this.FindAndReplace(wordApp, "<Night Differential>", txtDifferential.Text);
                    this.FindAndReplace(wordApp, "<Basic Pay>", txtBasicPay.Text);
                    this.FindAndReplace(wordApp, "<Cash Advance>", txtcashAdvance.Text);
                    this.FindAndReplace(wordApp, "<Pag-ibig>", txtPagibig.Text);
                    this.FindAndReplace(wordApp, "<SSS>", txtSSS.Text);
                    this.FindAndReplace(wordApp, "<Philhealth>", txtPhilhealth.Text);
                    this.FindAndReplace(wordApp, "<Withholding>", txtWithholding.Text);
                    this.FindAndReplace(wordApp, "<Deduct1>", txtdeduction1.Text);
                    this.FindAndReplace(wordApp, "<Deduct2>", txtdeduction2.Text);
                    this.FindAndReplace(wordApp, "<Deduct3>", txtdeduction3.Text);
                    this.FindAndReplace(wordApp, "<DAmount1>", txtdeduction1val.Text);
                    this.FindAndReplace(wordApp, "<DAmount2>", txtdeduction2val.Text);
                    this.FindAndReplace(wordApp, "<DAmount3>", txtdeduction3val.Text);
                    this.FindAndReplace(wordApp, "<TotalDeduction>", txtTotaldeduction.Text);
                    this.FindAndReplace(wordApp, "<Net Income>", txtNetIncome.Text);

                }
                else
                {
                    MessageBox.Show("File not Found!");
                }

                //Save as
                myWordDoc.SaveAs2(ref SaveAs, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);

                myWordDoc.Close();
                wordApp.Quit();
                MessageBox.Show("File Created!");
            }
            catch (Exception)
            {
            }
        }

        private void btnPayslip_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmployeeId1.Text == "")
            {
                MessageBox.Show("Please check your inputs.");
            }
            else
            {
                payslipCreated();
                CreateWordDocument(@"E:\2nd Year 2ND SEM\ADVANCE DATABASE\PAYROLL SYSTEM (updated-29-10-2020)\payrollSystem Version2\payrollSystem Version2\resources\PayslipTemplate.docx",
                    @"E:\2nd Year 2ND SEM\ADVANCE DATABASE\PAYROLL SYSTEM (updated-29-10-2020)\payrollSystem Version2\Payslip\" + txtEmployeeId1.Text + "_" + date.Text + ".docx");
            }
        }

        private void btnHome_Click_1(object sender, RoutedEventArgs e)
        {
            SuperAdmin home = new SuperAdmin();
            home.Show();
            this.Close();
        }
    }
}