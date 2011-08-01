using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Southville.GP.Data;
using Southville.GP.Beans;
 
namespace StudentInformation.Forms
{
    public partial class Main : Form
    {
        private static DateTime defaultDateTime = new DateTime();
        private Loading loadingScreen = new Loading();
        private String yearID = null;
        private List<Customer> customers = SQLData.getInstance().getAllCustomers();
        private SelectStudents selectStudentsScreen = new SelectStudents();
        private static int TYPE_COMBOBOXDEFAULT = 0;
        private static int GENDER_COMBOBOXDEFAULT = 0;
        private static int STATUS_COMBOBOXDEFAULT = 0;
        private static int STUDENTSTATUS_COMBOBOXDEFAULT = 0;
        private static int STUDENTCLASS_COMBOBOXDEFAULT = 0;

        //private static 
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //idTextbox.Text = getnewStudentID("Basic Education");
            loadCustomerDetails();
            getLastSchoolAtt();
            getNationalities();
            getReligions();
            TYPE_COMBOBOXDEFAULT = typeCombobox.Items.Count - 1;
            GENDER_COMBOBOXDEFAULT = genderCombobox.Items.Count - 1;
            STATUS_COMBOBOXDEFAULT = statusCombobox.Items.Count - 1;
            STUDENTSTATUS_COMBOBOXDEFAULT = studentStatusCombobox.Items.Count - 1;
            classComboBox.Items.Clear();
            foreach (string s in Constants.STUDENTCLASSES)
            {
                classComboBox.Items.Add(s);
            }
            STUDENTCLASS_COMBOBOXDEFAULT = 0;
        }
        private void loadCustomerDetails()
        {
            customers = selectStudentsScreen.loadDetails();
        }
        private void getNationalities()
        {
            foreach (Customer c in customers)
            {
                String nationality = c.Nationality;
                if (nationality != null && nationality != "")
                {
                    if (!nationalityComboBox.Items.Contains(nationality))
                    {
                        nationalityComboBox.Items.Add(nationality);
                    }
                }
            }
            nationalityComboBox.Items.Add("");
        }
        private void getLastSchoolAtt()
        {
            foreach (Customer c in customers)
            {
                String lastSchool = c.LastSchAttended;
                if (lastSchool != null && lastSchool != "" && !lastSchoolcb.Items.Contains(lastSchool))
                {
                    lastSchoolcb.Items.Add(c.LastSchAttended.ToString().Trim());
                }
            }
            lastSchoolcb.Items.Add("");
        }
        private void getReligions()
        {
            foreach (Customer c in customers)
            {
                String religion = c.Religion.ToLower();
                if (religion != null && religion != "" && !religionComboBox.Items.Contains(religion))
                {
                    religionComboBox.Items.Add(religion);
                }
            }
        }
        public void convertToTitleCase(TextBox tb,  KeyPressEventArgs e)
        {
            if (tb.Text.Length > 1 && tb.Text.Substring(tb.Text.Length - 1, 1) == " ")
            {
                // convert first character to upper case after space
                e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
            }
            else if (tb.Text.Length == 0)
            {
                // convert first character typed in texbox to upper case
                e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
            }
        }
        public void convertToTitleCaseCB(ComboBox cb, KeyPressEventArgs e)
        {
            if (cb.Text.Length > 1 && cb.Text.Substring(cb.Text.Length - 1, 1) == " ")
            {
                // convert first character to upper case after space
                e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
            }
            else if (cb.Text.Length == 0)
            {
                // convert first character typed in texbox to upper case
                e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
            }
        }
        private String getnewStudentID(String year, String studType)
        {
            //yearID = year;
            String newStudentId = "";
            String StudentType = typeCombobox.Text;
            int listCount = getStudentNumbers().Count;
            int collegeCount = getCollegeCount();
            int IBCount = getIBCount();
            int BEdCount = listCount - collegeCount - IBCount;

            switch (studType)
            {
                case "College": newStudentId = year.Substring(2) + "-" + getActualNumber((collegeCount + 1).ToString()) + "C";
                    break;
                case "International Baccalaureate": newStudentId = year.Substring(2) + "-" + getActualNumber((IBCount + 1).ToString()) + "IB";
                    break;
                default: newStudentId = newStudentId = year.Substring(2) + "-" + getActualNumber((BEdCount + 1).ToString());
                    break;

                //case "College": newStudentId = SQLData.getInstance().suggestID(year.Substring(2), "C");
                //    break;
                //case "International Baccalaureate": newStudentId = SQLData.getInstance().suggestID(year.Substring(2), "IB");
                //    break;
                //default: newStudentId = newStudentId = SQLData.getInstance().suggestID(year.Substring(2), "");
                //    break;
            }
            return newStudentId;
        }
        private int getIBCount()
        {

            List<Customer> IB = new List<Customer>();
            List<Customer> studentNumbers = getStudentNumbers();

            foreach(Customer c in studentNumbers)
            {
                if (c.CustomerID.Contains("IB"))
                {
                    IB.Add(c);
                }
            }
            return IB.Count;
        }
        private int getCollegeCount()
        {
            List<Customer> college = new List<Customer>();
            List<Customer> studentNumbers = getStudentNumbers();

            foreach (Customer c in studentNumbers)
            {
                if (c.CustomerID.Contains("C"))
                {
                    college.Add(c);
                }
            }
            return college.Count;
        }
        private List<Customer> getStudentNumbers()
        {
            Session.getInstance().CustomerList = SQLData.getInstance().getAllCustomers();
            List<Customer> customerList = Session.getInstance().CustomerList;
            List<Customer> filteredList = new List<Customer>();
            foreach (Customer c in customerList)
            {
                String custYearId = c.CustomerID.Trim().Substring(0, 2);
                if (custYearId.Equals(yearID.Substring(2)))
                {
                    filteredList.Add(c);
                }
            }
            return filteredList;
        }
        private String getActualNumber(String count)
        {
            int stopper = 1;
            int countLength = count.Length;
            int counter = 4-countLength;
            String result = "";
            while (stopper <= counter)
            {
                result += "0";
                stopper++;
            }
            return result + count;
        }
        private void setComboboxValue(ComboBox cb, String value, int defaultValue)
        {
            int i = 0;
            foreach (Object o in cb.Items)
            {
                if (o.ToString().Equals(value))
                {
                    cb.SelectedIndex = i;
                    return;
                }
                i++;
            }
            cb.SelectedIndex = defaultValue;
        }

        private void clearData()
        {
            idTextbox.Text = "";
            firstnameTextbox.Text = "";
            middlenameTextbox.Text = "";
            lastnameTextbox.Text = "";
            emailTextbox.Text = "";
            nicknameTextbox.Text = "";
            inactiveCheckbox.Checked = false;
            DateTime defaultDate = new DateTime(1990, 1, 1);
            birthdayDatetimePicker.Value = defaultDate;
            lastEnrolledDateTimePicker.Value = defaultDate;
            nationalityComboBox.Text = "";
            levelCombobox.Text = "";
            sectionTextbox.Text = "";
            religionComboBox.Text = "";
            lastSchoolcb.Text = "";
            placeOfBirthTextbox.Text = "";
            typeCombobox.SelectedIndex = TYPE_COMBOBOXDEFAULT;
            genderCombobox.SelectedIndex = GENDER_COMBOBOXDEFAULT;
            statusCombobox.SelectedIndex = STATUS_COMBOBOXDEFAULT;
            studentStatusCombobox.SelectedIndex = STUDENTSTATUS_COMBOBOXDEFAULT;
            classComboBox.SelectedIndex = STUDENTCLASS_COMBOBOXDEFAULT;
            billingContactTextbox.Text = "";
            addressTextbox.Text = "";
            cityTextbox.Text = "";
            stateTextbox.Text = "";
            zipcodeTextbox.Text = "";
            countryTextbox.Text = "";
            phoneNumberTextbox.Text = "";
            mobileNumberTextbox.Text = "";
            faxNumberTextbox.Text = "";
        }
        private void loadCustomer(Customer c)
        {
            firstnameTextbox.Text = c.FirstName;
            middlenameTextbox.Text = c.MiddleName;
            lastnameTextbox.Text = c.LastName;
            emailTextbox.Text = c.EmailAddress;
            nicknameTextbox.Text = c.ShortName;
            inactiveCheckbox.Checked = c.Inactive;
            if (c.Birthday != null && !(c.Birthday.Equals(defaultDateTime))) birthdayDatetimePicker.Value = Convert.ToDateTime(c.Birthday);
            if (c.LastEnrolledDate != null && !(c.LastEnrolledDate.Equals(defaultDateTime))) lastEnrolledDateTimePicker.Value = c.LastEnrolledDate;
            nationalityComboBox.Text = c.Nationality;
            levelCombobox.Text = c.Level;
            sectionTextbox.Text = c.Section;
            religionComboBox.Text = c.Religion;
            lastSchoolcb.Text = c.LastSchAttended;
            placeOfBirthTextbox.Text = c.PlaceOfBirth;
            if (c.Type != null) setComboboxValue(typeCombobox, c.Type, TYPE_COMBOBOXDEFAULT);
            if (c.Gender != null) setComboboxValue(genderCombobox, c.Gender, GENDER_COMBOBOXDEFAULT);
            if (c.OfficiallyEnrolled != null) setComboboxValue(statusCombobox, c.OfficiallyEnrolled, STATUS_COMBOBOXDEFAULT);
            if (c.StudentStatus != null) setComboboxValue(studentStatusCombobox, c.StudentStatus, STUDENTSTATUS_COMBOBOXDEFAULT);
            if (c.CustomerClass != null) setComboboxValue(classComboBox, c.CustomerClass, STUDENTCLASS_COMBOBOXDEFAULT);
            billingContactTextbox.Text = c.CustomerAddress.AddressContact;
            addressTextbox.Text = c.CustomerAddress.AddressString;
            cityTextbox.Text = c.CustomerAddress.City;
            stateTextbox.Text = c.CustomerAddress.State;
            zipcodeTextbox.Text = c.CustomerAddress.Zipcode;
            countryTextbox.Text = c.CustomerAddress.Country;
            phoneNumberTextbox.Text = c.CustomerAddress.PhoneNumber1;
            mobileNumberTextbox.Text = c.CustomerAddress.PhoneNumber2;
            faxNumberTextbox.Text = c.CustomerAddress.FaxNumber;
        }
        private void fillIdBox()
        {
            if (typeCombobox.Text != null && typeCombobox.Text != "")
            {
                idTextbox.Text = getnewStudentID(DateTime.Now.Year.ToString(), typeCombobox.Text);
            }
            else
            {
                MessageBox.Show("Student Type Field must have value","Student Type Field Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        private Customer getCustomer()
        {
            Customer c = new Customer();
            if ((idTextbox.Text != null) && !(idTextbox.Text.Equals("")))
                c.CustomerID = idTextbox.Text;
            if ((firstnameTextbox.Text != null) && !(firstnameTextbox.Text.Equals("")))
                c.FirstName = firstnameTextbox.Text;
            if ((middlenameTextbox.Text != null) && !(middlenameTextbox.Text.Equals("")))
                c.MiddleName = middlenameTextbox.Text;
            if ((lastnameTextbox.Text != null) && !(lastnameTextbox.Text.Equals("")))
                c.LastName = lastnameTextbox.Text;
            if ((emailTextbox.Text != null) && !(emailTextbox.Text.Equals("")))
                c.EmailAddress = emailTextbox.Text;
            if ((nicknameTextbox.Text != null) && !(nicknameTextbox.Text.Equals("")))
                c.ShortName = nicknameTextbox.Text;
            c.Inactive = inactiveCheckbox.Checked;
            c.Birthday = Convert.ToDateTime(birthdayDatetimePicker.Value);
            c.LastEnrolledDate = lastEnrolledDateTimePicker.Value;
            if ((nationalityComboBox.Text != null) && !(nationalityComboBox.Text.Equals("")))
                c.Nationality = nationalityComboBox.Text;
            if ((levelCombobox.Text != null) && !(levelCombobox.Text.Equals("")))
                c.Level = levelCombobox.Text;
            if ((sectionTextbox.Text != null) && !(sectionTextbox.Text.Equals("")))
                c.Section = sectionTextbox.Text;
            if ((religionComboBox.Text != null) && !(religionComboBox.Text.Equals("")))
                c.Religion = religionComboBox.Text;
            if ((placeOfBirthTextbox.Text != null) && !(placeOfBirthTextbox.Text.Equals("")))
                c.PlaceOfBirth = placeOfBirthTextbox.Text;
            if ((lastSchoolcb.Text != null) && !(lastSchoolcb.Text.Equals("")))
                c.LastSchAttended = lastSchoolcb.Text;
            c.Type = typeCombobox.Text;
            c.Gender = genderCombobox.Text;
            c.OfficiallyEnrolled = statusCombobox.Text;
            c.StudentStatus = studentStatusCombobox.Text;
            c.CustomerClass = classComboBox.Text;
            if ((billingContactTextbox.Text != null) && !(billingContactTextbox.Text.Equals("")))
                c.CustomerAddress.AddressContact = billingContactTextbox.Text;
            if ((addressTextbox.Text != null) && !(addressTextbox.Text.Equals("")))
                c.CustomerAddress.AddressString = addressTextbox.Text;
            if ((cityTextbox.Text != null) && !(cityTextbox.Text.Equals("")))
                c.CustomerAddress.City = cityTextbox.Text;
            if ((stateTextbox.Text != null) && !(stateTextbox.Text.Equals("")))
                c.CustomerAddress.State = stateTextbox.Text;
            if ((zipcodeTextbox.Text != null) && !(zipcodeTextbox.Text.Equals("")))
                c.CustomerAddress.Zipcode = zipcodeTextbox.Text;
            if ((countryTextbox.Text != null) && !(countryTextbox.Text.Equals("")))
                c.CustomerAddress.Country = countryTextbox.Text;
            if ((phoneNumberTextbox.Text != null) && !(phoneNumberTextbox.Text.Equals("")))
                c.CustomerAddress.PhoneNumber1 = phoneNumberTextbox.Text;
            if ((mobileNumberTextbox.Text != null) && !(mobileNumberTextbox.Text.Equals("")))
                c.CustomerAddress.PhoneNumber2 = mobileNumberTextbox.Text;
            if ((faxNumberTextbox.Text != null) && !(faxNumberTextbox.Text.Equals("")))
                c.CustomerAddress.FaxNumber = faxNumberTextbox.Text;
            
            return c;
        }
        private bool validateFields()
        {
            bool valid = true;
            string invalidMessage = "Problems! Need to:";
            if ((idTextbox.Text == null) || idTextbox.Text.Equals(""))
            {
                valid = false;
                invalidMessage += "\nFill out the id textbox";
            }

            if ((firstnameTextbox.Text == null) || firstnameTextbox.Text.Equals(""))
            {
                valid = false;
                invalidMessage += "\nFill out the First name";
            }

            if ((lastnameTextbox.Text == null) || lastnameTextbox.Text.Equals(""))
            {
                valid = false;
                invalidMessage += "\nFill out the Last name";
            }

            if (!valid)
            {
                MessageBox.Show(invalidMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valid;
        }
        private void checkStudent()
        {
            if (!idTextbox.Text.Equals(""))
            {
                
                loadingScreen.Show();
                this.Enabled = false;
                //Load customer from database (might take awhile, put a loading screen)
                string customerId = idTextbox.Text.ToUpper();
                Customer c = CustomerDAO.getInstance().getCustomer(customerId);
                this.Enabled = true;
                loadingScreen.Hide();

                if (c == null)
                {
                    clearData();
                    AddNewStudent addNewStudent = new AddNewStudent();
                    DialogResult result = addNewStudent.ShowDialog();
                    if (result.Equals(DialogResult.No))
                    {
                        clearData();
                    }
                    else if (result.Equals(DialogResult.Yes))
                    {
                        clearData();
                        idTextbox.Text = customerId;
                    }
                }
                else
                {
                    loadCustomer(c);
                }
                
                
            }
        }

        private void idTextbox_Leave(object sender, EventArgs e)
        {
            checkStudent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
           
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void lookupBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = selectStudentsScreen.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                this.clearData();
                idTextbox.Text = selectStudentsScreen.selectedStudent.CustomerID;
                checkStudent();
            }
            else
            {
                this.clearData();
            }
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripMenuItemEnrollmentReport_Click(object sender, EventArgs e)
        {
            EnrollmentReportDialog dialog = new EnrollmentReportDialog();
            DialogResult result = dialog.ShowDialog();
            
            if (result.Equals(DialogResult.OK))
            {
                ReportViewer viewer = new ReportViewer();
                loadingScreen.Show();
                List<Customer> students = 
                    SQLData.getInstance().getAllCustomers(dialog.enrollmentStatus, dialog.level, dialog.section);
                viewer.loadEnrollmentReport(students, dialog.enrollmentStatus, students.Count + " student(s)");
                loadingScreen.Hide();
                viewer.Show();
            }

        }
        private void ToolStripMenuItemEasyGradeProReport_Click(object sender, EventArgs e)
        {
            EnrollmentReportDialog dialog = new EnrollmentReportDialog();
            DialogResult result = dialog.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                ReportViewer viewer = new ReportViewer();
                loadingScreen.Show();
                List<Customer> students =
                    SQLData.getInstance().getAllCustomersForEGP(dialog.enrollmentStatus, dialog.level, dialog.section);
                viewer.loadEasyGradeProReport(students);
                loadingScreen.Hide();
                viewer.Show();
            }
        }

        private void ToolStripMenuItemEasyGradeProCSV_Click(object sender, EventArgs e)
        {
            TextViewer viewer = new TextViewer();
            EnrollmentReportDialog dialog = new EnrollmentReportDialog();
            DialogResult result = dialog.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                loadingScreen.Show();
                String EGPText =
                    SQLData.getInstance().getAllCustomersString(dialog.enrollmentStatus, dialog.level, dialog.section);
                viewer.setText(EGPText);
                viewer.Show();
                loadingScreen.Hide();
            }
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void idTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitButn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Boolean validateStudentId()
        {
            Session.getInstance().CustomerList = SQLData.getInstance().getAllCustomers();
            List<Customer> updatedList = Session.getInstance().CustomerList;
            Boolean result = false;
            foreach (Customer c in updatedList)
            {
                if (c.CustomerID.Equals(idTextbox.Text))
                {
                    result = false;
                }
                else {result = true; }
            }
            return result;
        }
        private void saveButn_Click(object sender, EventArgs e)
        {
            //fillIdBox();
            bool valid = validateFields();
            Boolean validStudId = validateStudentId();
            if (valid)
            {
                this.Enabled = false;
                loadingScreen.Show();
                //if (validStudId)
                //{
                    Customer c = getCustomer();
                    if (CustomerDAO.getInstance().saveCustomer(c))
                    { MessageBox.Show("The Student saved successfully","Message",MessageBoxButtons.OK,MessageBoxIcon.Information); }
                //}
                //else { MessageBox.Show("Student ID (" + idTextbox.Text + ") already exist in the database. Please generate new Student ID", "Duplication Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                this.Enabled = true;
                loadingScreen.Hide();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.clearData();
        }

        private void typeCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //idTextbox.Text = SQLData.getInstance().suggestID(yearID.Substring(2), typeCombobox.Text);
        }

        private void suggestIdbtn_Click(object sender, EventArgs e)
        {
            StudentType dialog= new StudentType();
            DialogResult result = dialog.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                yearID = dialog.year;
               idTextbox.Text = getnewStudentID(dialog.year, dialog.studType);
               idTextbox.Focus();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void firstnameTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            convertToTitleCase(firstnameTextbox, e);
        }

        private void middlenameTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            convertToTitleCase(middlenameTextbox, e);
        }

        private void lastnameTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            convertToTitleCase(lastnameTextbox, e);
        }

        private void nicknameTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            convertToTitleCase(nicknameTextbox, e);
        }

        private void sectionTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            convertToTitleCase(sectionTextbox, e);
        }

        private void religionComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            convertToTitleCaseCB(religionComboBox, e);
        }

        private void lastSchoolcb_KeyPress(object sender, KeyPressEventArgs e)
        {
            convertToTitleCaseCB(lastSchoolcb, e);
        }

        private void placeOfBirthTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            convertToTitleCase(placeOfBirthTextbox, e);
        }

        private void billingContactTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            convertToTitleCase(billingContactTextbox, e);
        }

        private void addressTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            convertToTitleCase(addressTextbox, e);
        }

        private void cityTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            convertToTitleCase(cityTextbox, e);
        }

        private void stateTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            convertToTitleCase(stateTextbox, e);
        }

        private void countryTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            convertToTitleCase(countryTextbox, e);
        }

        private void nationalityTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //convertToTitleCase(nationalityTextbox, e);
        }

        private void nationalityComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            convertToTitleCaseCB(nationalityComboBox, e);
        }

        private void religionComboBox_Leave(object sender, EventArgs e)
        {
            try
            {
                String text = religionComboBox.Text;
                String convertedText = null;
                if (text.Contains(" "))
                {
                    String[] inputTexts = text.Split(' ');
                    String firstWord;
                    String secondWord;
                    String thirdWord;
                    if (inputTexts.Length > 2)
                    {
                        firstWord = inputTexts[0][0].ToString().ToUpper() + inputTexts[0].Substring(1);
                        secondWord = inputTexts[1][0].ToString().ToUpper() + inputTexts[1].Substring(1);
                        thirdWord = inputTexts[2][0].ToString().ToUpper() + inputTexts[2].Substring(1);
                        convertedText = firstWord + " " + secondWord + " " + thirdWord;
                    }
                    else
                    {
                        firstWord = inputTexts[0][0].ToString().ToUpper() + inputTexts[0].Substring(1);
                        secondWord = inputTexts[1][0].ToString().ToUpper() + inputTexts[1].Substring(1);
                        convertedText = firstWord + " " + secondWord;
                    }
                }
                else { convertedText = text[0].ToString().ToUpper() + text.Substring(1); }
                religionComboBox.Text = "";
                religionComboBox.Text = convertedText;
            }
            catch { }
        }

        private void enrolmentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void iDReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnrollmentReportDialog dialog = new EnrollmentReportDialog();
            DialogResult result = dialog.ShowDialog();

            if (result.Equals(DialogResult.OK))
            {
                ReportViewer viewer = new ReportViewer();
                loadingScreen.Show();
                List<Customer> students =
                    SQLData.getInstance().getAllCustomers(dialog.enrollmentStatus, dialog.level, dialog.section);
                viewer.EnrolmentStatus(students);
                loadingScreen.Hide();
                viewer.Show();
            }
        }

        private void demographicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnrollmentReportDialog dialog = new EnrollmentReportDialog();
            DialogResult result = dialog.ShowDialog();

            if (result.Equals(DialogResult.OK))
            {
                ReportViewer viewer = new ReportViewer();
                loadingScreen.Show();
                List<Customer> students =
                    SQLData.getInstance().getAllCustomers(dialog.enrollmentStatus, dialog.level, dialog.section);
                viewer.EnrolmentStatus(students);
                loadingScreen.Hide();
                viewer.Show();
            }
        }

        private void basicEducationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnrollmentReportDialog dialog = new EnrollmentReportDialog();
            DialogResult result = dialog.ShowDialog();

            if (result.Equals(DialogResult.OK))
            {
                ReportViewer viewer = new ReportViewer();
                loadingScreen.Show();
                List<Customer> students =
                    SQLData.getInstance().getAllCustomers(dialog.enrollmentStatus, dialog.level, dialog.section);
                viewer.loadAgeProfile(students);
                loadingScreen.Hide();
                viewer.Show();
            }
        }

    }
}
