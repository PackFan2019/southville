using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Southville.GP.Data;
using Southville.GP.Beans;

namespace StudentInformation.Forms
{
    public partial class SelectStudents : Form
    {
        private Loading loadingScreen = new Loading();
        private static List<Customer> loadedList;
        public static Boolean isListLoaded = false;
        private String filterInActive = "All"; //Only active students, (Yes, No, All)
        private String filterType = "All";
        private String filterStudStats = "All";
        private String filterEnrollStats = "All";
        private String filterStudClass = "All";
        private String filterLevel = "All";
        private String filterSection = "All";
        private String filterStudName = " ";
        private String filterreligion = " ";
        private String filterNationality = " ";
        public String filterLastSchoolAtt = "All";

        private UpdateStudent loadUpdateScreen = new UpdateStudent();
        public Customer selectedStudent = new Customer();
        public DialogResult result;
        public SelectStudents()
        {
            InitializeComponent();
        }

        private void SelectStudents_Load(object sender, EventArgs e)
        {
            refreshFields();
            refreshViewFromSearch();
            Session.getInstance().SelectedFields.Clear();
            //groupBox1.Size = new Size(157, 415);
            Session.getInstance().CustomerList = loadDetails();
            loadedList = Session.getInstance().CustomerList;
            getLastSchoolAtt();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = Session.getInstance().CustomerList;
        }
        public void getLastSchoolAtt()
        {
            foreach (Customer c in Session.getInstance().CustomerList)
            {
                String lastSchool = c.LastSchAttended;
                if (lastSchool != null && lastSchool != "")
                {
                    if (!searchByLastSchoolAttcb.Items.Contains(lastSchool))
                    {
                        searchByLastSchoolAttcb.Items.Add(c.LastSchAttended.ToString().Trim());
                    }
                }
            }
            searchByLastSchoolAttcb.Items.Add("");
        }
        private void refreshViewFromSearch()
        {
            Session.getInstance().SelectedFields.Clear();
            List<Customer> filteredResult = new List<Customer>();
            filteredResult = loadedList;
            filteredResult = filterByStudName(filteredResult, filterStudName);
            filteredResult = filterByNationality(filteredResult, filterNationality);
            filteredResult = filterByLastSchoolAtt(filteredResult, filterLastSchoolAtt);
            filteredResult = filterByActive(filteredResult, filterInActive);
            filteredResult = filterByType(filteredResult, filterType);
            filteredResult = filterByStudentStatus(filteredResult, filterStudStats);
            filteredResult = filterByEnrollmentStatus(filteredResult, filterEnrollStats);
            filteredResult = filterByStudentClass(filteredResult, filterStudClass);
            filteredResult = filterByLevel(filteredResult, filterLevel);
            filteredResult = filterBySection(filteredResult, filterSection);
            

            Session.getInstance().SelectedCustomerList = filteredResult;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = filteredResult;

            
        }
        private static List<Customer> filterByActive(List<Customer> customers, String option)
        {
            if (option.Equals("All") || option.Equals("all"))
            {
                return customers;
            }
            else
            {
                return customers.FindAll(delegate(Customer c) { return (c.Inactive.Equals(Convert.ToBoolean(option))); });
            }
        }
        private static List<Customer> filterByStudName(List<Customer> customers, String option)
        {
            if (option.Equals(" "))
            {
                return customers;
            }
            else
            {
                return customers.FindAll(delegate(Customer c) { return (c.CustomerName.Contains(option)); });
            }
        }
        private static List<Customer> filterByNationality(List<Customer> customers, String option)
        {
            if (option.Equals(" "))
            {
                return customers;
            }
            else
            {
                return customers.FindAll(delegate(Customer c) { return (c.Nationality.Contains(option)); });
            }
        }
        private static List<Customer> filterByLastSchoolAtt(List<Customer> customers, String option)
        {
            if (option.Equals("All"))
            {
                return customers;
            }
            else
            {
                return customers.FindAll(delegate(Customer c) { return (c.LastSchAttended.Equals(option)); });
            }
        }
        private static Boolean isExist(String value)
        {
            if (Session.getInstance().SelectedFields.Exists(delegate(Object oldValue) { return oldValue.Equals(value); }))
                return true;
            else return false;
        }
        private List<Customer> filterByType(List<Customer> customers, String option)
        {
            String field = "Student Type (''" + searchByTypecb.Text + "'')" ;
            int index = Session.getInstance().SelectedFields.IndexOf(field);
            if (option.Equals("All"))
            {
                if (isExist(field))
                {
                    Session.getInstance().SelectedFields.Remove(field);
                }
                return customers;
            }
            else
            {
                if (!isExist(field)) Session.getInstance().SelectedFields.Add(field);
                return customers.FindAll(delegate(Customer c) { return (c.Type.Equals(option)); });
            }
        }
        private List<Customer> filterByStudentStatus(List<Customer> customers, String option)
        {
            String field = "Student Status (''" + searchByStudentStatcb.Text + "'')";
            int index = Session.getInstance().SelectedFields.IndexOf(field);
            if (option.Equals("All"))
            {
                if (isExist(field))
                {
                    Session.getInstance().SelectedFields.RemoveAt(index);
                }
                return customers;

            }
            else
            {
                if (!isExist(field)) Session.getInstance().SelectedFields.Add(field);
                return customers.FindAll(delegate(Customer c) { return (c.StudentStatus.Equals(option)); });
            }
        }
        private List<Customer> filterByEnrollmentStatus(List<Customer> customers, String option)
        {
            String field = "Enrollment Status (''" + searchByEnrollStatcb.Text + "'')";
            int index = Session.getInstance().SelectedFields.IndexOf(field);
            if (option.Equals("All"))
            {
                if (isExist(field))
                {
                    Session.getInstance().SelectedFields.RemoveAt(index);
                }
                return customers;
            }
            else
            {
                if (!isExist(field)) Session.getInstance().SelectedFields.Add(field);
                return customers.FindAll(delegate(Customer c) { return (c.OfficiallyEnrolled.Equals(option)); });
            }
        }
        private List<Customer> filterByStudentClass(List<Customer> customers, String option)
        {
            String field = "Student Class (''" + searchByStudClasscb.Text + "'')";
            int index = Session.getInstance().SelectedFields.IndexOf(field);
            if (option.Equals("ALL") || option.Equals("All"))
            {
                if (isExist(field))
                {
                    Session.getInstance().SelectedFields.RemoveAt(index);
                }
                return customers;
            }
            else
            {
                if (!isExist(field)) Session.getInstance().SelectedFields.Add(field);
                return customers.FindAll(delegate(Customer c) { return (c.CustomerClass.Equals(option)); });
            }
        }
        private List<Customer> filterByLevel(List<Customer> customers, String option)
        {
            String field = "Level (''" + searchByLevelcb.Text + "'')";
            int index = Session.getInstance().SelectedFields.IndexOf(field);
            if (option.Equals("All"))
            {
                if (isExist(field))
                {
                    Session.getInstance().SelectedFields.RemoveAt(index);
                }
                return customers;
            }
            else
            {
                if (!isExist(field)) Session.getInstance().SelectedFields.Add(field);
                return customers.FindAll(delegate(Customer c) { return (c.Level.Equals(option)); });
            }
        }
        private List<Customer> filterBySection(List<Customer> customers, String option)
        {
            String field = "Section (''" + searchBySectioncb.Text + "'')";
            int index = Session.getInstance().SelectedFields.IndexOf(field);
            if (option.Equals("All"))
            {
                if (isExist(field))
                {
                    Session.getInstance().SelectedFields.RemoveAt(index);
                }
                return customers;
            }
            else
            {
                if (!isExist(field)) Session.getInstance().SelectedFields.Add(field);
                return customers.FindAll(delegate(Customer c) { return (c.Section.Equals(option)); });
            }
        }
        public List<Customer> loadDetails()
        {
            Dictionary<String, String> enrollment =
               SQLData.getInstance().getExtenderDatabuffer(Constants.WINDOW_EXT_ID, Constants.ENROLLED_FIELD_ID);
            Dictionary<String, String> levels =
                SQLData.getInstance().getExtenderDatabuffer(Constants.WINDOW_EXT_ID, Constants.LEVEL_FIELD_ID);
            Dictionary<String, String> sections =
                SQLData.getInstance().getExtenderDatabuffer(Constants.WINDOW_EXT_ID, Constants.SECTION_FIELD_ID);
            Dictionary<String, String> emails =
                SQLData.getInstance().getExtenderDatabuffer(Constants.WINDOW_EXT_ID, Constants.EMAIL_FIELD_ID);
            Dictionary<String, String> lastSchoolAtt =
               SQLData.getInstance().getExtenderDatabuffer(Constants.WINDOW_EXT_ID, Constants.LASTSCHOOL_FIELD_ID);
            Dictionary<String, DateTime> birthdays =
                SQLData.getInstance().getExtenderDates(Constants.WINDOW_EXT_ID, Constants.BIRTHDAY_FIELD_ID);
            Dictionary<String, String> nationalities =
                SQLData.getInstance().getExtenderDatabuffer(Constants.WINDOW_EXT_ID, Constants.NATIONALITY_FIELD_ID);
            Dictionary<String, String> religions =
                SQLData.getInstance().getExtenderDatabuffer(Constants.WINDOW_EXT_ID, Constants.RELIGION_FIELD_ID);
            Dictionary<String, String> firstname =
                SQLData.getInstance().getExtenderDatabuffer(Constants.WINDOW_EXT_ID, Constants.FIRSTNAME_FIELD_ID);
            Dictionary<String, String> lastname =
                SQLData.getInstance().getExtenderDatabuffer(Constants.WINDOW_EXT_ID, Constants.LASTNAME_FIELD_ID);
            List<Customer> resultList = new List<Customer>();
            try
            {
                foreach (Customer customer in Session.getInstance().CustomerList)
                {
                    customer.FirstName = SQLData.getInstance().getExtenderDataIfExists(customer.CustomerID,firstname);
                    customer.LastName = SQLData.getInstance().getExtenderDataIfExists(customer.CustomerID, lastname);
                    customer.OfficiallyEnrolled = SQLData.getInstance().getExtenderDataIfExists(customer.CustomerID, enrollment);
                    customer.Level = SQLData.getInstance().getExtenderDataIfExists(customer.CustomerID, levels);
                    customer.Section = SQLData.getInstance().getExtenderDataIfExists(customer.CustomerID, sections);
                    customer.EmailAddress = SQLData.getInstance().getExtenderDataIfExists(customer.CustomerID, emails);

                    DateTime bday = SQLData.getInstance().getExtenderBdayIfExists(customer.CustomerID, birthdays);
                    if (bday != null)
                    {
                        customer.Birthday = Convert.ToDateTime(bday);
                    }
                    else { customer.Birthday = Convert.ToDateTime(null); }
                    customer.LastSchAttended = SQLData.getInstance().getExtenderDataIfExists(customer.CustomerID, lastSchoolAtt);
                    customer.Nationality = SQLData.getInstance().getExtenderDataIfExists(customer.CustomerID, nationalities);
                    customer.Religion = SQLData.getInstance().getExtenderDataIfExists(customer.CustomerID, religions);
                    //else { customer.Birthday = null; }
                    resultList.Add(customer);
                }
            }
            catch (FormatException er)
            {
                MessageBox.Show(er.Message);
            }
            return resultList;
        }
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                int i = dataGridView1.CurrentCell.RowIndex;
                String id = dataGridView1[0, i].Value.ToString();
                String name = dataGridView1[1, i].Value.ToString();
                selectedStudent.CustomerID = id;
                selectedStudent.CustomerName = name;
                label1.Text = "Current selected student: " + name;
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            refreshFields();
            refreshFilters();
            refreshViewFromSearch();
            Session.getInstance().SelectedCustomerList = new List<Customer>();
            Session.getInstance().SelectedFields.Clear();
            //groupBox1.Size = new Size(1202,768);
            Session.getInstance().CustomerList = loadDetails();
            loadedList = Session.getInstance().CustomerList;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = Session.getInstance().CustomerList;
        }
        private void refreshFilters()
        {
            filterInActive = "All"; //Only active students, (Yes, No, All)
            filterType = "All";
            filterStudStats = "All";
            filterEnrollStats = "All";
            filterStudClass = "All";
            filterLevel = "All";
            filterSection = "All";
        }
        private void refreshFields()
        {
            searchBystudNameTb.Text = "";
            searchByLastSchoolAttcb.Text = "All";
            searchByTypecb.Text = "All";
            searchByStudentStatcb.Text = "All";
            searchByEnrollStatcb.Text = "All";
            searchByStudClasscb.Text = "All";
            searchByLevelcb.Text = "All";
            searchBySectioncb.Text = "All";
        }
        private void refreshDataGrid()
        {
            Session.getInstance().CustomerList = SQLData.getInstance().getAllCustomers();
            dataGridView1.DataSource = Session.getInstance().CustomerList;
            dataGridView1.Refresh();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            result = DialogResult.OK;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            refreshFields();
            refreshFilters();
            result = DialogResult.Cancel;
        }

        private void searchByActivecb_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void searchByTypecb_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterType = searchByTypecb.Text;
            searchByLevelcb.Items.Clear();
            refreshLevelAndSectionFieldsAndFilters();
            List<Object> Levels = UpdateStudent.getLevel(filterType);

            if (searchByTypecb.Text.Equals("Basic Education"))
            {
                foreach (Object level in Levels)
                {
                    searchByLevelcb.Items.Add(level);
                }
                //groupBox1.Size = new Size(157, 472);
            }
            else
            {
                searchBySectioncb.Text = "All";
                searchByLevelcb.Text = "All";
                //groupBox1.Size = new Size(157, 415);
            }
            if (searchByTypecb.Text.Equals("College") || searchByTypecb.Text.Equals("International Baccal"))
            {
                foreach (Object level in Levels)
                {
                    searchByLevelcb.Items.Add(level);
                }
            }
            
            refreshViewFromSearch();
        }

        private void searchByStudClasscb_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterStudClass = searchByStudClasscb.Text.ToUpper();
            refreshViewFromSearch();
        }

        private void searchByEnrollStatcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterEnrollStats = searchByEnrollStatcb.Text;
            refreshViewFromSearch();
        }

        private void searchByStudentStatcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterStudStats = searchByStudentStatcb.Text;
            refreshViewFromSearch();
        }

        private void massUpdateBtn_Click(object sender, EventArgs e)
        {
            if ( Session.getInstance().SelectedCustomerList != null && Session.getInstance().SelectedCustomerList.Count > 0)
            {
                loadUpdateScreen.ShowDialog();
            }
            else { MessageBox.Show("You must select field/s to update","Update Entry Error",MessageBoxButtons.OK,MessageBoxIcon.Warning); }
        }

        private void searchByLevelcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchBySectioncb.Items.Clear();
            foreach(Object section in UpdateStudent.getSection(searchByLevelcb.Text))
            {
                searchBySectioncb.Items.Add(section);
            }
            filterLevel = searchByLevelcb.Text;
            refreshViewFromSearch();
        }

        private void searchBySectioncb_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterSection = searchBySectioncb.Text;
            refreshViewFromSearch();
        }

        private void refreshLevelAndSectionFieldsAndFilters()
        {
            filterLevel = "All";
            filterSection = "All";
            searchByLevelcb.Text = "All";
            searchBySectioncb.Text = "All";
        }

        private void CSVImportbtn_Click(object sender, EventArgs e)
        {
            //TextViewer viewer = new TextViewer();
            //EnrollmentReportDialog dialog = new EnrollmentReportDialog();
            //DialogResult result = dialog.ShowDialog();
            //if (result.Equals(DialogResult.OK))
            //{
            //    loadingScreen.Show();
            //    String EGPText =
            //        SQLData.getInstance().getCustomerForCSVExport();
            //    viewer.setText(EGPText);
            //    viewer.Show();
            //    loadingScreen.Hide();
            //}
            exportToCSV();
        }
        private void exportToCSV()
        {

            //Asks the filenam with a SaveFileDialog control.

            SaveFileDialog saveFileDialogCSV = new SaveFileDialog();
            saveFileDialogCSV.InitialDirectory = Application.ExecutablePath.ToString();

            saveFileDialogCSV.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialogCSV.FilterIndex = 1;
            saveFileDialogCSV.RestoreDirectory = true;

            if (saveFileDialogCSV.ShowDialog() == DialogResult.OK)
            {
                // Runs the export operation if the given filenam is valid.
                exportToCSVfile(dataGridView1, saveFileDialogCSV.FileName.ToString());
            }
        }
        private void exportToCSVfile(DataGridView dTable, string csvNameWithExt)
        {
            String strExport = "";
            String delimeter = ",";
            foreach (DataGridViewColumn column in dTable.Columns)
            {
                strExport += column.Name + delimeter;
            }
            strExport = strExport.Substring(0, strExport.Length - 1) + Environment.NewLine.ToString();
            foreach (DataGridViewRow drow in dTable.Rows)
            {
                foreach (DataGridViewCell cell in drow.Cells)
                {
                    if (cell.Value != null)
                    {
                        strExport += cell.Value.ToString() + delimeter;
                    }
                }
                strExport += Environment.NewLine.ToString();
            }
            strExport = strExport.Substring(0, strExport.Length - 3) + Environment.NewLine.ToString();

            TextWriter tw = new StreamWriter(csvNameWithExt);
            tw.Write(strExport);
            tw.Close();
        }

        private void studNameTb_TextChanged(object sender, EventArgs e)
        {
            filterStudName = searchBystudNameTb.Text;
            refreshViewFromSearch();
        }

        private void searchByLastSchoolAttcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterLastSchoolAtt = searchByLastSchoolAttcb.Text;
            refreshViewFromSearch();
        }

        private void searchBystudNameTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main mainScreen = new Main();
            mainScreen.convertToTitleCase(searchBystudNameTb, e);
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            LetterOfRequestDialog dialog = new LetterOfRequestDialog();
            dialog.setSchoolName(searchByLastSchoolAttcb.Text);
            DialogResult result = dialog.ShowDialog();

            if (result.Equals(DialogResult.OK))
            {
                ReportViewer viewer = new ReportViewer();
                loadingScreen.Show();
                viewer.loadLetterOfRequest(Session.getInstance().SelectedCustomerList,dialog.schoolName,
                    dialog.schoolAddress,dialog.attainment, dialog.schoolYear);
                loadingScreen.Hide();
                viewer.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            filterNationality = textBox1.Text;
            refreshViewFromSearch();
        }

        private void SelectStudents_FormClosed(object sender, FormClosedEventArgs e)
        {
            refreshFields();
        }
    }
}
