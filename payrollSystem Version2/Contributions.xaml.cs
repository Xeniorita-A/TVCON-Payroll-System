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
    /// Interaction logic for Contributions.xaml
    /// </summary>
    public partial class Contributions : Window
    {
        const string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_payroll_system;";

        public class Pagibig
        {
            public Int32 pID { get; set; }
            public String monthlyCom { get; set; }
            public double employee { get; set; }
            public double employer { get; set; }
        }
        public class SSS
        {
            public Int32 sID { get; set; }
            public string range { get; set; }
            public double monthlySalary { get; set; }
            public double ER { get; set; }
            public double EE { get; set; }
            public double sTotal { get; set; }
            public Int32 EC { get; set; }
        }
        public class Philhealth
        { 
            public Int32 phID { get; set; }
            public String monBasic { get; set; }
            public String monPremium { get; set; }
            public String perShare { get; set; }
            public String empShare { get; set; }
        }
        public class Withholding
        {
            public Int32 wID { get; set; }
            public String CL { get; set; }
            public double withTax { get; set; }
            public double percentOverCL { get; set; }
        }
        Pagibig currPagibig = null;
        SSS currSSS = null;
        Philhealth currPhilhealth = null;
        Withholding currWithholding = null;


        //This is the code to display the data on the listview
        private void PagibigTable()
        {
            lvPagibig.Items.Clear();
            string query = "SELECT * FROM `tbl_pagibig`";
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
                        if (reader.GetInt32(0) == 1)
                        {
                            Pagibig _tmpPagibig = new Pagibig
                            {
                                pID = reader.GetInt32(0),
                                monthlyCom = "Below " + reader.GetString(1),
                                employee = reader.GetDouble(2) * 100,
                                employer = reader.GetDouble(3) * 100
                            };
                            lvPagibig.Items.Add(_tmpPagibig);
                        }else if (reader.GetInt32(0) == 2)
                        {
                            Pagibig _tmpPagibig = new Pagibig
                            {
                                pID = reader.GetInt32(0),
                                monthlyCom = reader.GetString(1) + " and Above",
                                employee = reader.GetDouble(2) * 100,
                                employer = reader.GetDouble(3) * 100
                            };
                            lvPagibig.Items.Add(_tmpPagibig);
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
        private void SSSTable()
        {
            lvSSS.Items.Clear();
            string query = "SELECT * FROM `tbl_sss`";
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
                        SSS _tmpSSS = new SSS
                        {
                            sID = reader.GetInt32(0),
                            range = reader.GetDouble(1) +" - "+ reader.GetDouble(2),
                            monthlySalary = reader.GetDouble(3),
                            ER = reader.GetDouble(4),
                            EE = reader.GetDouble(5),
                            sTotal = reader.GetDouble(6),
                            EC = reader.GetInt32(7)
                        };
                        lvSSS.Items.Add(_tmpSSS);
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
        private void PhilhealthTable()
        {
            lvPhilhealth.Items.Clear();
            string query = "SELECT * FROM `tbl_philhealth`";
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
                        Philhealth _tmpPhilhealth = new Philhealth
                        {
                            phID = reader.GetInt32(0),
                            monBasic = reader.GetDouble(1) + " - " + reader.GetDouble(2),
                            monPremium = reader.GetDouble(3) + " - " + reader.GetDouble(4),
                            perShare = reader.GetDouble(5) + " - " + reader.GetDouble(6),
                            empShare = reader.GetDouble(7) + " - " + reader.GetDouble(8),
                        };
                        lvPhilhealth.Items.Add(_tmpPhilhealth);
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
        private void WithholdingTable()
        {
            lvWithholding.Items.Clear();
            string query = "SELECT * FROM `tbl_withholding_tax`";
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
                        Withholding _tmpwithholding = new Withholding
                        {
                            wID = reader.GetInt32(0),
                            CL = reader.GetDouble(1) + " - " + reader.GetDouble(2),
                            withTax = reader.GetDouble(3),
                            percentOverCL = reader.GetDouble(4) * 100
                        };
                        lvWithholding.Items.Add(_tmpwithholding);
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
        public Contributions()
        {
            InitializeComponent();
            date3.Text = DateTime.Now.ToString("dddd , MMM dd yyyy");
            date2.Text = DateTime.Now.ToString("dddd , MMM dd yyyy");
            date1.Text = DateTime.Now.ToString("dddd , MMM dd yyyy");
            date.Text = DateTime.Now.ToString("dddd , MMM dd yyyy");
            PagibigTable();
            SSSTable();
            PhilhealthTable();
            WithholdingTable();
        }

        //This is the code to get the data from the listview or from the database to show in the textfields
        private void lvSSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvSSS.SelectedIndex > -1)
            {
                currSSS = (SSS)lvSSS.SelectedItem;
                txtSalaryCredit.Text = currSSS.monthlySalary.ToString();
                txtSER.Text = currSSS.ER.ToString();
                txtSEE.Text = currSSS.EE.ToString();
                txtConTotal.Text = currSSS.sTotal.ToString();
                txtEC.Text = currSSS.EC.ToString();
                txtSSSid.Text = currSSS.sID.ToString();
                string query1 = "SELECT * FROM `tbl_sss` WHERE s_id = @ID";
                MySqlConnection databaseConnection1 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase1 = new MySqlCommand(query1, databaseConnection1);
                commandDatabase1.Parameters.AddWithValue("@ID",txtSSSid.Text);
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
                           txtRangeFrom.Text = Convert.ToString(reader1.GetDouble(1));
                           txtRangeTo.Text = Convert.ToString(reader1.GetDouble(2));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }

                    databaseConnection1.Close();
                }
                catch (Exception)
                { }
            }
        }

        private void lvPagibig_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvPagibig.SelectedIndex > -1)
            {
                currPagibig = (Pagibig)lvPagibig.SelectedItem;
                txtpID.Text = currPagibig.pID.ToString();
                txtPEE.Text = currPagibig.employee.ToString();
                txtPER.Text = currPagibig.employer.ToString();
                string query1 = "SELECT * FROM `tbl_pagibig` WHERE p_id = @ID";
                MySqlConnection databaseConnection1 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase1 = new MySqlCommand(query1, databaseConnection1);
                commandDatabase1.Parameters.AddWithValue("@ID", txtpID.Text);
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
                            txtMonthlycomp.Text = Convert.ToString(reader1.GetDouble(1));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }

                    databaseConnection1.Close();
                }
                catch (Exception)
                { }
            }
        }

        private void lvPhilhealth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvPhilhealth.SelectedIndex > -1)
            {
                currPhilhealth = (Philhealth)lvPhilhealth.SelectedItem;
                txtphID.Text = currPhilhealth.phID.ToString();
                string query1 = "SELECT * FROM `tbl_philhealth` WHERE ph_id = @ID";
                MySqlConnection databaseConnection1 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase1 = new MySqlCommand(query1, databaseConnection1);
                commandDatabase1.Parameters.AddWithValue("@ID", txtphID.Text);
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
                            txtMonFrom.Text = Convert.ToString(reader1.GetDouble(1));
                            txtMonTo.Text = Convert.ToString(reader1.GetDouble(2));
                            txtmonPremiumFrom.Text = Convert.ToString(reader1.GetDouble(3));
                            txtmonPremiumTo.Text = Convert.ToString(reader1.GetDouble(4));
                            txtPershareFrom.Text = Convert.ToString(reader1.GetDouble(5));
                            txtPershareTo.Text = Convert.ToString(reader1.GetDouble(6));
                            txtEmpshareFrom.Text = Convert.ToString(reader1.GetDouble(7));
                            txtEmpshareTo.Text = Convert.ToString(reader1.GetDouble(8));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }

                    databaseConnection1.Close();
                }
                catch (Exception)
                { }
            }
        }

        private void lvWithholding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvWithholding.SelectedIndex > -1)
            {
                currWithholding = (Withholding)lvWithholding.SelectedItem;
                txtPercentageTax.Text = currWithholding.percentOverCL.ToString();
                txtMinTax.Text = currWithholding.withTax.ToString();
                txtwID.Text = currWithholding.wID.ToString();
                string query1 = "SELECT * FROM `tbl_withholding_tax` WHERE w_id = @ID";
                MySqlConnection databaseConnection1 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase1 = new MySqlCommand(query1, databaseConnection1);
                commandDatabase1.Parameters.AddWithValue("@ID", txtwID.Text);
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
                            txtCLFrom.Text = Convert.ToString(reader1.GetDouble(1));
                            txtCLTo.Text = Convert.ToString(reader1.GetDouble(2));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }

                    databaseConnection1.Close();
                }
                catch (Exception)
                { }
            }
        }

        //This is the code to update the contribution tables
        private void btnEditPagibig_Click(object sender, RoutedEventArgs e)
        {
            if (txtMonthlycomp.Text == "" || txtPEE.Text == "" || txtPER.Text == "")
            {
                MessageBox.Show("One of the textfield is empty! Please input necessary information to proceed.");
            }else
            {
                 try
                {
                    string query = "UPDATE `tbl_pagibig` SET `p_id`= @ID,`mon_compensation`= @mon_comp, `employee_share`= @employee, `employer_share`= @employer WHERE p_id = @ID";
                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    commandDatabase.Parameters.AddWithValue("@ID", txtpID.Text);
                    commandDatabase.Parameters.AddWithValue("@mon_comp", txtMonthlycomp.Text);
                    commandDatabase.Parameters.AddWithValue("@employee", Convert.ToDouble(txtPEE.Text)/100);
                    commandDatabase.Parameters.AddWithValue("@employer", Convert.ToDouble(txtPER.Text)/100);
                    commandDatabase.CommandTimeout = 60;
                    MySqlDataReader reader;

                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    databaseConnection.Close();
                }
                catch (Exception)
                {
                }
                try
                {
                    string query2 = "INSERT INTO  `tbl_audit_trail` (`UserResponsible`, `TransactionHistory`, `DateOfTransaction`)  VALUES (@user, @history, @date)";
                    MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection2);
                    commandDatabase2.Parameters.AddWithValue("@user", "PAYROLL MASTER");
                    commandDatabase2.Parameters.AddWithValue("@history", "Updated the Pag-ibig Contribution Table");
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
                MessageBox.Show("Successfully Updated!");
                PagibigTable();
            }
        }

        private void btnEditSSS_Click(object sender, RoutedEventArgs e)
        {
            if (txtRangeFrom.Text == "" || txtRangeTo.Text == "" || txtSalaryCredit.Text == "" || txtSER.Text == "" || txtSEE.Text == "" || txtConTotal.Text == "" || txtEC.Text == "")
            {
                MessageBox.Show("One of the textfield is empty! Please input necessary information to proceed.");
            }
            else
            {
                try
                {
                    string query = "UPDATE `tbl_sss` SET `s_id`= @ID,`s_from`= @sfrom, `s_to`= @sto, `s_mon_salary_credit`= @monthlysal, `s_er`=@er, `s_ee`=@ee, `s_total`=@total, `s_ec_con`=@ec WHERE s_id = @ID";
                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    commandDatabase.Parameters.AddWithValue("@ID", txtSSSid.Text);
                    commandDatabase.Parameters.AddWithValue("@sfrom", txtRangeFrom.Text);
                    commandDatabase.Parameters.AddWithValue("@sto", txtRangeTo.Text);
                    commandDatabase.Parameters.AddWithValue("@monthlysal", txtSalaryCredit.Text);
                    commandDatabase.Parameters.AddWithValue("@er", txtSER.Text);
                    commandDatabase.Parameters.AddWithValue("@ee", txtSEE.Text);
                    commandDatabase.Parameters.AddWithValue("@total", txtConTotal.Text);
                    commandDatabase.Parameters.AddWithValue("@ec", txtEC.Text);
                    commandDatabase.CommandTimeout = 60;
                    MySqlDataReader reader;

                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    databaseConnection.Close();

                    MessageBox.Show("Successfully Updated!");
                    SSSTable();
                }
                catch (Exception em)
                {
                    MessageBox.Show(em.ToString());
                }
                try
                {
                    string query2 = "INSERT INTO  `tbl_audit_trail` (`UserResponsible`, `TransactionHistory`, `DateOfTransaction`)  VALUES (@user, @history, @date)";
                    MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection2);
                    commandDatabase2.Parameters.AddWithValue("@user", "PAYROLL MASTER");
                    commandDatabase2.Parameters.AddWithValue("@history", "Updated the SSS Contribution Table");
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
        }

        private void btnEditPh_Click(object sender, RoutedEventArgs e)
        {
            if (txtMonFrom.Text == "" || txtMonTo.Text == "" || txtmonPremiumFrom.Text == "" || txtmonPremiumTo.Text == "" || txtPershareFrom.Text == "" || txtPershareTo.Text == "" || txtEmpshareFrom.Text == "" || txtEmpshareTo.Text == "")
            {
                MessageBox.Show("One of the textfield is empty! Please input necessary information to proceed.");
            }
            else
            {
                try
                {
                    string query = "UPDATE `tbl_philhealth` SET `ph_id`= @ID,`monthly_from`= @monfrom, `monthly_to`= @monto, `mon_premium_from`= @monpremfrom, `mon_premium_to`=@monpremto, `personal_share_from`=@persharefrom, `personal_share_to`=@pershareto,`emp_share_from`=@empfrom, `emp_share_to`=@empto WHERE ph_id = @ID";
                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    commandDatabase.Parameters.AddWithValue("@ID", txtphID.Text);
                    commandDatabase.Parameters.AddWithValue("@monfrom", txtMonFrom.Text);
                    commandDatabase.Parameters.AddWithValue("@monto", txtMonTo.Text);
                    commandDatabase.Parameters.AddWithValue("@monpremfrom", txtmonPremiumFrom.Text);
                    commandDatabase.Parameters.AddWithValue("@monpremto", txtmonPremiumTo.Text);
                    commandDatabase.Parameters.AddWithValue("@persharefrom", txtPershareFrom.Text);
                    commandDatabase.Parameters.AddWithValue("@pershareto", txtPershareTo.Text);
                    commandDatabase.Parameters.AddWithValue("@empfrom", txtEmpshareFrom.Text);
                    commandDatabase.Parameters.AddWithValue("@empto", txtEmpshareTo.Text);
                    commandDatabase.CommandTimeout = 60;
                    MySqlDataReader reader;

                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    databaseConnection.Close();
                    MessageBox.Show("Successfully Updated!");
                    PhilhealthTable();
                }
                catch (Exception)
                {
                }
                try
                {
                    string query2 = "INSERT INTO  `tbl_audit_trail` (`UserResponsible`, `TransactionHistory`, `DateOfTransaction`)  VALUES (@user, @history, @date)";
                    MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection2);
                    commandDatabase2.Parameters.AddWithValue("@user", "PAYROLL MASTER");
                    commandDatabase2.Parameters.AddWithValue("@history", "Updated the Philhealth Contribution Table");
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
        }

        private void btnEditTax_Click(object sender, RoutedEventArgs e)
        {
            if (txtwID.Text == "" || txtCLFrom.Text == "" || txtCLTo.Text == "" || txtMinTax.Text == "" || txtPercentageTax.Text == "")
            {
                MessageBox.Show("One of the textfield is empty! Please input necessary information to proceed.");
            }
            else
            {
                try
                {
                    string query = "UPDATE `tbl_withholding_tax` SET `w_id`= @ID,`cl_from`= @clfrom, `cl_to`= @clto, `pres_min`= @presmin, `tax`=@tax WHERE w_id = @ID";
                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    commandDatabase.Parameters.AddWithValue("@ID", txtwID.Text);
                    commandDatabase.Parameters.AddWithValue("@clfrom", txtCLFrom.Text);
                    commandDatabase.Parameters.AddWithValue("@clto", txtCLTo.Text);
                    commandDatabase.Parameters.AddWithValue("@presmin", txtMinTax.Text);
                    commandDatabase.Parameters.AddWithValue("@tax", Convert.ToDouble(txtPercentageTax.Text) / 100);
                    commandDatabase.CommandTimeout = 60;
                    MySqlDataReader reader;

                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    databaseConnection.Close();
                    MessageBox.Show("Successfully Updated!");
                    WithholdingTable();
                }
                catch (Exception)
                {
                }
                try
                {
                    string query2 = "INSERT INTO  `tbl_audit_trail` (`UserResponsible`, `TransactionHistory`, `DateOfTransaction`)  VALUES (@user, @history, @date)";
                    MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection2);
                    commandDatabase2.Parameters.AddWithValue("@user", "PAYROLL MASTER");
                    commandDatabase2.Parameters.AddWithValue("@history", "Updated the Withholding Tax Contribution Table");
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
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            PayrollMaster home = new PayrollMaster();
            home.Show();
            this.Close();
        }
        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("HELP \nThe contribution table can be edited by simply clicking the row that you want to update/edit. Carefully check the data inputted in the textfields before clicking the update button. You can only input Numbers.\n\nHopefully this is helpful for you! \n\nHave a good day!!", "HELP", MessageBoxButton.OK, MessageBoxImage.Question);
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
