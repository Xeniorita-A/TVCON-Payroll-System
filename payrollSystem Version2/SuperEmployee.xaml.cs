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
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class SuperEmployee : Window
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
        Employees currUser = null;
        Int16 rdo;
        private void listEmployees()
        {
            dtgemplist.Items.Clear();
            txtSearch.Text = "";
            string query = "SELECT `tbl_employee`.`EID`, `tbl_employee`.`LastName`, `tbl_employee`.`FirstName`, `tbl_employee`.`MiddleName`, `tbl_employee`.`Sex`, `tbl_employee`.`Birthdate`, `tbl_employee`.`House_num`, `tbl_employee`.`Street`, `tbl_brgy`.`brgyDesc`, `tbl_city`.`cityDesc`, `tbl_province`.`provDesc`, `tbl_region`.`regDesc`, `tbl_employee`.`MaritalStatus`, `tbl_employee`.`Contact`, `tbl_employee`.`Emergency_Contact`, `tbl_employee_workinfo`.`Position`, `tbl_employee_workinfo`.`DailyRate`, `tbl_employee_workinfo`.`WorkStatus`, `tbl_employee_workinfo`.`HiredDate` FROM `tbl_employee`"
	        +"LEFT JOIN `tbl_brgy` ON `tbl_employee`.`brgyCode` = `tbl_brgy`.`brgyCode` "
	        +"LEFT JOIN `tbl_city` ON `tbl_brgy`.`cityCode` = `tbl_city`.`cityCode` "
	        +"LEFT JOIN `tbl_province` ON `tbl_city`.`provCode` = `tbl_province`.`provCode` "
	        +"LEFT JOIN `tbl_region` ON `tbl_province`.`regCode` = `tbl_region`.`regCode` "
	        +"LEFT JOIN `tbl_employee_workinfo` ON `tbl_employee_workinfo`.`EID` = `tbl_employee`.`EID`";

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
            catch (Exception)
            {
            }
        }
        public SuperEmployee()
        {
            InitializeComponent();
            listEmployees();
            comboBoxItems();
            date.Text = DateTime.Now.ToString("dddd, MMM dd yyyy");
            date1.Text = DateTime.Now.ToString("dddd, MMM dd yyyy");
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dtgemplist.SelectedIndex!= -1)
            {
                int index = tabControl.SelectedIndex - 1;
                tabControl.SelectedIndex = index;
                btnSave.IsEnabled = false;
                btnUpdate.IsEnabled = true;
            }else
            {
                MessageBox.Show("Please select an employee first!");
            }
           
        }
        public void comboBoxItems()
        {
            cbProvince.Items.Clear();
            cbCity.Items.Clear();
            cbBrgy.Items.Clear();
            try
            {
                string query = "Select * From `tbl_region`";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                databaseConnection.Open();
                MySqlDataReader reader;
                commandDatabase.CommandTimeout = 60;
                reader = commandDatabase.ExecuteReader();
                while (reader.Read())
                {
                    String region = reader.GetString(2);
                    cbRegion.Items.Add(region);
                }
                databaseConnection.Close();
                cbProvince.IsEnabled = false;
                cbCity.IsEnabled = false;
                cbBrgy.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dtgemplist.SelectedIndex > -1)
            {
                if (MessageBox.Show("Are you sure to delete this employee?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        string query = "UPDATE `tbl_employee_workinfo` SET `WorkStatus`= @workStatus WHERE `EID` = @EID";
                        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                        commandDatabase.Parameters.AddWithValue("@EID", txtEmployeeId.Text);
                        commandDatabase.Parameters.AddWithValue("@workStatus", "Inactive");
                        commandDatabase.CommandTimeout = 60;
                        MySqlDataReader reader;
                        databaseConnection.Open();
                        reader = commandDatabase.ExecuteReader();
                        MessageBox.Show("Successfully Updated!");
                        databaseConnection.Close();
                        transactionDelete();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    listEmployees();
                    btnNew_Click(sender, e);
                } else
                {
                    listEmployees();
                }
            }
            else
            {
                MessageBox.Show("Please select an employee you want to delete!");
            }
        }
        public void transactionDelete()
        {
            string query2 = "INSERT INTO  `tbl_audit_trail` ( `UserResponsible`, `TransactionHistory`, `DateOfTransaction`)  VALUES (@user, @history, @date)";
            MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection2);
            commandDatabase2.Parameters.AddWithValue("@user", "SUPER ADMIN");
            commandDatabase2.Parameters.AddWithValue("@history", "Tagged employee (" + txtEmployeeId.Text + ") as Inactive.");
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
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmployeeId.Text == "" || txtFirstName.Text == "" || txtLastname.Text == ""
                    || txtContactnumber.Text == "" || txtPlaceofbirth.Text == ""
                    || txtEmergency.Text == "" || txtDailyRate.Text == "" || txtPosition.Text == "" || cbcode.SelectedIndex==-1)
            {
                MessageBox.Show("One of the box is empty. Data is required.");
            }
            else
            {
                if (rbMale.IsChecked == true)
                {
                    rdo = 0;
                }
                else
                {
                    rdo = 1;
                }
                try
                {
                    String query = "INSERT INTO `tbl_employee` ( `EID`,`FirstName`,`MiddleName`, `LastName`, `House_num`, `Street`, `brgyCode`, `Contact`,`MaritalStatus`,`Birthdate`,`Birthplace`,`Sex`, `Emergency_Contact`) VALUES (@EID, @firstName, @middleName, @lastName, @house, @street, @brgy, @contact, @status, @birthdate, @birthplace, @sex, @eContact)";

                    MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase2 = new MySqlCommand(query, databaseConnection2);
                    commandDatabase2.Parameters.AddWithValue("@EID", txtEmployeeId.Text);
                    commandDatabase2.Parameters.AddWithValue("@firstName", txtFirstName.Text);
                    commandDatabase2.Parameters.AddWithValue("@middleName", txtMiddlename.Text);
                    commandDatabase2.Parameters.AddWithValue("@lastName", txtLastname.Text);
                    commandDatabase2.Parameters.AddWithValue("@house", txtHouseNo.Text);
                    commandDatabase2.Parameters.AddWithValue("@street", txtStreet.Text);
                    commandDatabase2.Parameters.AddWithValue("@brgy", cbcode.SelectedValue.ToString());
                    commandDatabase2.Parameters.AddWithValue("@contact", txtContactnumber.Text);
                    commandDatabase2.Parameters.AddWithValue("@status", cbMaritalStatus.Text);
                    commandDatabase2.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(DateOfBirth.Text));
                    commandDatabase2.Parameters.AddWithValue("@birthplace", txtPlaceofbirth.Text);
                    commandDatabase2.Parameters.AddWithValue("@sex", rdo);
                    commandDatabase2.Parameters.AddWithValue("@eContact", txtEmergency.Text);
                    commandDatabase2.CommandTimeout = 60;


                    databaseConnection2.Open();
                    MySqlDataReader myReader = commandDatabase2.ExecuteReader();

                    //  MessageBox.Show("User succesfully registered!");

                    databaseConnection2.Close();
                }
                catch (Exception)
                {
                }

                workinfo();
                transactionAdd();
            }
        }
        public void transactionAdd()
        {
            string query2 = "INSERT INTO  `tbl_audit_trail` ( `UserResponsible`, `TransactionHistory`, `DateOfTransaction`)  VALUES (@user, @history, @date)";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query2, databaseConnection);
            commandDatabase.Parameters.AddWithValue("@user", "SUPER ADMIN");
            commandDatabase.Parameters.AddWithValue("@history", "Added a new record of employee (" + txtEmployeeId.Text + ") to the database.");
            commandDatabase.Parameters.AddWithValue("@date", DateTime.Now);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void workinfo()
        {
            //employee details
            try
            {
                string query = "INSERT INTO `tbl_employee_workinfo` ( `EID`, `DailyRate`, `Position`, `WorkStatus`, `HiredDate`)  VALUES (@EID, @dailyRate, @position, @workStatus, @hired)";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@EID", txtEmployeeId.Text);
                commandDatabase.Parameters.AddWithValue("@dailyRate", Convert.ToDouble(txtDailyRate.Text));
                commandDatabase.Parameters.AddWithValue("@position", txtPosition.Text);
                commandDatabase.Parameters.AddWithValue("@workStatus", cbWorkStatus.Text);
                commandDatabase.Parameters.AddWithValue("@Hired", Convert.ToDateTime(hiredDate.Text));
                commandDatabase.CommandTimeout = 60;
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception)
            {
            }
            listEmployees();
            MessageBox.Show("Succesfully registered the employee!");
        }



        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmployeeId.Text == "" || txtFirstName.Text == "" || txtLastname.Text == ""
                  || txtContactnumber.Text == "" || txtPlaceofbirth.Text == ""
                   || txtEmergency.Text == "" || txtDailyRate.Text == "" || txtPosition.Text == "" || cbBrgy.Text=="" )
            {
                MessageBox.Show("One of the box is empty. Data is required.");
            }
            else
            {
                if (rbMale.IsChecked == true)
                {
                    rdo = 0;
                }
                else
                {
                    rdo = 1;
                }
                try
                {
                    string query = "UPDATE `tbl_employee` SET `EID`= @EID,`FirstName`=@firstName, `MiddleName`= @middleName, `LastName`= @lastName, `House_num`= @house, `Street`= @street,`brgyCode`=@brgy, `Contact` = @contact,`MaritalStatus`=@status, `Birthdate`=@birthdate, `Birthplace`=@birthplace, `Sex`=@sex,`Emergency_Contact`= @eContact WHERE EID = @EID";
                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    commandDatabase.Parameters.AddWithValue("@EID", txtEmployeeId.Text);
                    commandDatabase.Parameters.AddWithValue("@firstName", txtFirstName.Text);
                    commandDatabase.Parameters.AddWithValue("@middleName", txtMiddlename.Text);
                    commandDatabase.Parameters.AddWithValue("@lastName", txtLastname.Text);
                    commandDatabase.Parameters.AddWithValue("@house", txtHouseNo.Text);
                    commandDatabase.Parameters.AddWithValue("@street", txtStreet.Text);
                    commandDatabase.Parameters.AddWithValue("@brgy", cbcode.SelectedValue.ToString());
                    commandDatabase.Parameters.AddWithValue("@contact", txtContactnumber.Text);
                    commandDatabase.Parameters.AddWithValue("@status", cbMaritalStatus.Text);
                    commandDatabase.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(DateOfBirth.Text));
                    commandDatabase.Parameters.AddWithValue("@birthplace", txtPlaceofbirth.Text);
                    commandDatabase.Parameters.AddWithValue("@sex", rdo);
                    commandDatabase.Parameters.AddWithValue("@eContact", txtEmergency.Text);
                    commandDatabase.CommandTimeout = 60;
                    MySqlDataReader reader;

                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    databaseConnection.Close();
                    Updateworkinfo();
                    transactionUpdate();
                }
                catch (Exception)
                {
                }


            }
        }
        public void transactionUpdate()
        {
            try
            {
                string query2 = "INSERT INTO  `tbl_audit_trail` (`UserResponsible`, `TransactionHistory`, `DateOfTransaction`)  VALUES (@user, @history, @date)";
                MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection2);
                commandDatabase2.Parameters.AddWithValue("@user", "SUPER ADMIN");
                commandDatabase2.Parameters.AddWithValue("@history", "Updated the record of employee (" + txtEmployeeId.Text + ") from the database.");
                commandDatabase2.Parameters.AddWithValue("@date", DateTime.Now);
                commandDatabase2.CommandTimeout = 60;
                MySqlDataReader reader2;

                databaseConnection2.Open();
                reader2 = commandDatabase2.ExecuteReader();
                databaseConnection2.Close();
            }
            catch (Exception)
            {
            }
        }
        public void Updateworkinfo()
        {
            //employee details
            try
            {
                string query = "UPDATE `tbl_employee_workinfo` SET `EID`= @EID,`DailyRate`=@payRate, `Position`= @position, `WorkStatus`= @workStatus, `HiredDate` = @hired WHERE EID = @EID";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@EID", txtEmployeeId.Text);
                commandDatabase.Parameters.AddWithValue("@payRate", Convert.ToDouble(txtDailyRate.Text));
                commandDatabase.Parameters.AddWithValue("@position", txtPosition.Text);
                commandDatabase.Parameters.AddWithValue("@workStatus", cbWorkStatus.Text);
                commandDatabase.Parameters.AddWithValue("@Hired", Convert.ToDateTime(hiredDate.Text));
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                MessageBox.Show("Successfully Updated!");
                databaseConnection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please check your inputs!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            listEmployees();
        }
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            txtContactnumber.Text = "";
            txtDailyRate.Text = "";
            txtEmergency.Text = "";
            txtEmployeeId.Text = "";
            txtFirstName.Text = "";
            txtLastname.Text = "";
            txtMiddlename.Text = "";
            txtPlaceofbirth.Text = "";
            txtPosition.Text = "";
            DateOfBirth.Text = "";
            hiredDate.Text = "";
            cbMaritalStatus.SelectedIndex = 1;
            cbWorkStatus.SelectedIndex = 0;
            rbMale.IsChecked = true;
            btnSave.IsEnabled = true;
            btnUpdate.IsEnabled = true;
            txtEmployeeId.Clear();
            txtHouseNo.Text = "";
            txtStreet.Text = "";
            cbRegion.SelectedIndex = -1;
            cbProvince.SelectedIndex = -1;
            cbCity.SelectedIndex = -1;
            cbBrgy.SelectedIndex = -1;
            listEmployees();
        }

        private void dtgemplist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgemplist.SelectedIndex > -1)
            {
                currUser = (Employees)dtgemplist.SelectedItem;
                txtEmployeeId.Text = currUser.EmployeeID.ToString();
                txtContactnumber.Text = currUser.Contact;
                cbMaritalStatus.Text = currUser.Status;
                DateOfBirth.Text = currUser.Birthdate;
                if (currUser.Gender == "Male")
                {
                    rbMale.IsChecked = true;
                }
                else
                {
                    rbFemale.IsChecked = true;
                }
                btnEdit.IsEnabled = true;
                BtnDelete.IsEnabled = true;
            //KUNIN ANG LAMAN NG LIST
                string query1 = "SELECT * FROM `tbl_employee` WHERE EID = @EID";
                MySqlConnection databaseConnection1 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase1 = new MySqlCommand(query1, databaseConnection1);
                commandDatabase1.Parameters.AddWithValue("@EID", txtEmployeeId.Text);
                commandDatabase1.CommandTimeout = 60;
                MySqlDataReader reader1;
                try
                {
                    databaseConnection1.Open();
                    reader1 = commandDatabase1.ExecuteReader();
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            txtFirstName.Text = reader1.GetString(1);
                            txtMiddlename.Text = reader1.GetString(2);
                            txtLastname.Text = reader1.GetString(3);
                            txtHouseNo.Text = reader1.GetString(4);
                            txtStreet.Text = reader1.GetString(5);
                            cbcode.Text = reader1.GetString(6);
                            txtPlaceofbirth.Text = reader1.GetString(10);
                            txtEmergency.Text = reader1.GetString(12);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }

                    databaseConnection1.Close();
                }
                catch (Exception)
                {
                }
                string query = "SELECT * FROM `tbl_employee_workinfo` WHERE EID = @EID";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@EID", txtEmployeeId.Text);
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
                            txtDailyRate.Text = reader.GetString(2);
                            txtPosition.Text = reader.GetString(3);
                            cbWorkStatus.Text = reader.GetString(4);
                            hiredDate.Text = reader.GetString(5);
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
                fillComboBoxes();
                currUser = null;
                btnEdit.IsEnabled = true;
                BtnDelete.IsEnabled = true;
            }
            else
            {
                currUser = null;
                btnEdit.IsEnabled = true;
                BtnDelete.IsEnabled = true;
            }
        }
        public void fillComboBoxes()
        {
            try
            {
                cbcode.Items.Clear();
                string query1 = "SELECT `tbl_brgy`.`brgyCode`, `tbl_brgy`.`brgyDesc`, `tbl_city`.`cityDesc`, `tbl_province`.`provDesc`, `tbl_region`.`regDesc`"
                +"FROM `tbl_brgy` "
	            +"LEFT JOIN `tbl_city` ON `tbl_brgy`.`cityCode` = `tbl_city`.`cityCode`" 
	            +"LEFT JOIN `tbl_province` ON `tbl_city`.`provCode` = `tbl_province`.`ProvCode`"
	            +"LEFT JOIN `tbl_region` ON `tbl_province`.`regCode` = `tbl_region`.`regCode` WHERE `tbl_brgy`.`brgyCode`=@brgycode";
                MySqlConnection databaseConnection1 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase1 = new MySqlCommand(query1, databaseConnection1);
                databaseConnection1.Open();
                commandDatabase1.Parameters.AddWithValue("@brgycode", cbcode.Text);
                MySqlDataReader reader1;
                commandDatabase1.CommandTimeout = 60;
                reader1 = commandDatabase1.ExecuteReader();
                while (reader1.Read())
                {
                    cbRegion.Text = reader1.GetString(4);
                    cbProvince.Text = reader1.GetString(3);
                    cbCity.Text = reader1.GetString(2);
                    cbBrgy.Text = reader1.GetString(1);
                }

                cbcode.SelectedIndex = 0;
                databaseConnection1.Close();
            }
            catch (Exception)
            {
            }
        }
        public void searchedResult()
        {
            dtgemplist.Items.Clear();
            string query = "SELECT `tbl_employee`.`EID`, `tbl_employee`.`LastName`, `tbl_employee`.`FirstName`, `tbl_employee`.`MiddleName`, `tbl_employee`.`Sex`, `tbl_employee`.`Birthdate`, `tbl_employee`.`House_num`, `tbl_employee`.`Street`, `tbl_brgy`.`brgyDesc`, `tbl_city`.`cityDesc`, `tbl_province`.`provDesc`, `tbl_region`.`regDesc`, `tbl_employee`.`MaritalStatus`, `tbl_employee`.`Contact`, `tbl_employee`.`Emergency_Contact`, `tbl_employee_workinfo`.`Position`, `tbl_employee_workinfo`.`DailyRate`, `tbl_employee_workinfo`.`WorkStatus`, `tbl_employee_workinfo`.`HiredDate` FROM `tbl_employee`"
                + "LEFT JOIN `tbl_brgy` ON `tbl_employee`.`brgyCode` = `tbl_brgy`.`brgyCode` "
                + "LEFT JOIN `tbl_city` ON `tbl_brgy`.`cityCode` = `tbl_city`.`cityCode` "
                + "LEFT JOIN `tbl_province` ON `tbl_city`.`provCode` = `tbl_province`.`provCode` "
                + "LEFT JOIN `tbl_region` ON `tbl_province`.`regCode` = `tbl_region`.`regCode` "
                + "LEFT JOIN `tbl_employee_workinfo` ON `tbl_employee_workinfo`.`EID` = `tbl_employee`.`EID` WHERE  `tbl_employee`.`EID` LIKE '" + txtSearch.Text + "%' OR `tbl_employee`.`LastName` LIKE '" + txtSearch.Text + "%' OR `tbl_employee`.`FirstName` LIKE '" + txtSearch.Text + "%' OR `tbl_employee`.`Sex` LIKE '" + txtSearch.Text + "%' OR `tbl_brgy`.`brgyDesc` LIKE '" + txtSearch.Text + "%' ";

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

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text == "")
            {
                listEmployees();
            }else
            {
                cbStatus.SelectedIndex = 0;
                searchedResult();
            }
        }

        private void cbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
            if (cbStatus.SelectedIndex == 1)
            {
                dtgemplist.Items.Clear();
                txtSearch.Text = "";
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
            else if (cbStatus.SelectedIndex == 2)
            {
                dtgemplist.Items.Clear();
                txtSearch.Text = "";
                string query = "SELECT `tbl_employee`.`EID`, `tbl_employee`.`LastName`, `tbl_employee`.`FirstName`, `tbl_employee`.`MiddleName`, `tbl_employee`.`Sex`, `tbl_employee`.`Birthdate`, `tbl_employee`.`House_num`, `tbl_employee`.`Street`, `tbl_brgy`.`brgyDesc`, `tbl_city`.`cityDesc`, `tbl_province`.`provDesc`, `tbl_region`.`regDesc`, `tbl_employee`.`MaritalStatus`, `tbl_employee`.`Contact`, `tbl_employee`.`Emergency_Contact`, `tbl_employee_workinfo`.`Position`, `tbl_employee_workinfo`.`DailyRate`, `tbl_employee_workinfo`.`WorkStatus`, `tbl_employee_workinfo`.`HiredDate` FROM `tbl_employee`"
                + "LEFT JOIN `tbl_brgy` ON `tbl_employee`.`brgyCode` = `tbl_brgy`.`brgyCode` "
                + "LEFT JOIN `tbl_city` ON `tbl_brgy`.`cityCode` = `tbl_city`.`cityCode` "
                + "LEFT JOIN `tbl_province` ON `tbl_city`.`provCode` = `tbl_province`.`provCode` "
                + "LEFT JOIN `tbl_region` ON `tbl_province`.`regCode` = `tbl_region`.`regCode` "
                + "LEFT JOIN `tbl_employee_workinfo` ON `tbl_employee_workinfo`.`EID` = `tbl_employee`.`EID` WHERE  `tbl_employee_workinfo`.`WorkStatus` = 'Inactive'";

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
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                dtgemplist.Items.Clear();
                listEmployees();
            }
        }
       
        private void cbRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbProvince.Items.Clear();
                cbCity.Items.Clear();
                cbBrgy.Items.Clear();
                cbProvince.SelectedIndex = -1;
                comboBoxItems();
                string query = "SELECT `tbl_region`.`regCode`, `tbl_region`.`regDesc`, `tbl_province`.`ProvCode`, `tbl_province`.`ProvDesc` FROM `tbl_region` LEFT JOIN `tbl_province` ON `tbl_province`.`regCode` = `tbl_region`.`regCode` where  `tbl_region`.`regDesc`=@regDesc";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                databaseConnection.Open();
                commandDatabase.Parameters.AddWithValue("@regDesc",cbRegion.SelectedItem.ToString());
                MySqlDataReader reader;
                commandDatabase.CommandTimeout = 60;
                reader = commandDatabase.ExecuteReader();
                while (reader.Read())
                {
                        String province = reader.GetString(3);
                        cbProvince.Items.Add(province);
                }
                databaseConnection.Close();
                cbProvince.IsEnabled = true;
                cbCity.IsEnabled = true;
                cbBrgy.IsEnabled = false;
            }
            catch (Exception)
            {
            }
        }

        private void cbProvince_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbCity.Items.Clear();
                cbBrgy.Items.Clear();
                cbCity.SelectedIndex = -1;
                string query = "SELECT `tbl_province`.`provCode`, `tbl_province`.`provDesc`, `tbl_city`.`cityCode`, `tbl_city`.`cityDesc` FROM `tbl_province` LEFT JOIN `tbl_city` ON `tbl_city`.`provCode` = `tbl_province`.`provCode` where  `tbl_province`.`provDesc`=@provDesc";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                databaseConnection.Open();
                commandDatabase.Parameters.AddWithValue("@provDesc", cbProvince.SelectedItem.ToString());
                MySqlDataReader reader;
                commandDatabase.CommandTimeout = 60;
                reader = commandDatabase.ExecuteReader();
                while (reader.Read())
                {
                    String city = reader.GetString(3);
                    cbCity.Items.Add(city);
                }
                databaseConnection.Close();
                cbProvince.IsEnabled = true;
                cbCity.IsEnabled = true;
                cbBrgy.IsEnabled = true;
            }
            catch (Exception)
            {
            }
        }

        private void cbCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbBrgy.Items.Clear();
                string query = "SELECT `tbl_city`.`cityCode`, `tbl_city`.`cityDesc`, `tbl_brgy`.`brgyCode`, `tbl_brgy`.`brgyDesc` FROM `tbl_city` LEFT JOIN `tbl_brgy` ON `tbl_brgy`.`cityCode` = `tbl_city`.`cityCode` where  `tbl_city`.`cityDesc`= @cityDesc";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                databaseConnection.Open();
                commandDatabase.Parameters.AddWithValue("@cityDesc", cbCity.SelectedItem.ToString());
                MySqlDataReader reader;
                commandDatabase.CommandTimeout = 60;
                reader = commandDatabase.ExecuteReader();
                while (reader.Read())
                {
                    String brgy = reader.GetString(3);
                    cbBrgy.Items.Add(brgy);
                }
                databaseConnection.Close();
                cbProvince.IsEnabled = true;
                cbCity.IsEnabled = true;
                cbBrgy.IsEnabled = true;
            }
            catch (Exception)
            {
            }
        }

        private void cbBrgy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbcode.Items.Clear();
                string query1 = "SELECT `brgyCode` from tbl_brgy where `brgyDesc`=@brgyDesc";
                MySqlConnection databaseConnection1 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase1 = new MySqlCommand(query1, databaseConnection1);
                databaseConnection1.Open();
                commandDatabase1.Parameters.AddWithValue("@brgyDesc", cbBrgy.SelectedItem.ToString());
                MySqlDataReader reader1;
                commandDatabase1.CommandTimeout = 60;
                reader1 = commandDatabase1.ExecuteReader();
                while (reader1.Read())
                {
                    string code = reader1.GetString(0);
                    cbcode.Items.Add(code);
                }
               
                cbcode.SelectedIndex = 0;
                databaseConnection1.Close();
            }
            catch (Exception)
            {
            }
        }

        //toggle menu buttons
        private void btnHome_Click_1(object sender, RoutedEventArgs e)
        {
            SuperAdmin home = new SuperAdmin();
            home.Show();
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("\nHELP \nYou can add, delete or update the employee's record with the given fields and button below. \n\nHow can I add employee? \nYou'll need to input the necessary informations specifically the personal and working information of the employee's. \n\nHow can I edit the employee's record?? \nYou can Edit or update employee details by clicking the row of employee information that you want to edit on the list then click edit.\n\nWhere can I find the Employee list?\nYou can see the employee list on the next tab, just click the tab named employee list. just select the employee details then click edit. After editting the details you can now click update button to save the changes you've made.\n\nHow can I delete employee record/s? \nYou can delete employee/s by clicking the employee on the list and Clicking the delete button after or You can click the employee and tag it as inactive then click update.\n\nWhat is the purpose of new button? \nThe sole purpose of the new button is just to clear all the fields at once. \n\nHopefully this information was helpful to you. \n\nHave a good day!", "HELP", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void btnCalendar_Click(object sender, RoutedEventArgs e)
        {
            pmCalendar calendar = new pmCalendar();
            calendar.Show();
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

    }
}



