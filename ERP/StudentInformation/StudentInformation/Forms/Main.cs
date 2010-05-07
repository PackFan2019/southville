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
        private SelectStudents selectStudentsScreen = new SelectStudents();
        private static int TYPE_COMBOBOXDEFAULT = 0;
        private static int GENDER_COMBOBOXDEFAULT = 0;
        private static int STATUS_COMBOBOXDEFAULT = 0;
        private static int STUDENTSTATUS_COMBOBOXDEFAULT = 0;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            TYPE_COMBOBOXDEFAULT = typeCombobox.Items.Count - 1;
            GENDER_COMBOBOXDEFAULT = genderCombobox.Items.Count - 1;
            STATUS_COMBOBOXDEFAULT = statusCombobox.Items.Count - 1;
            STUDENTSTATUS_COMBOBOXDEFAULT = studentStatusCombobox.Items.Count - 1;
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
            nationalityTextbox.Text = "";
            levelCombobox.Text = "";
            sectionTextbox.Text = "";
            religionTextbox.Text = "";
            lastschoolTextbox.Text = "";
            placeOfBirthTextbox.Text = "";
            typeCombobox.SelectedIndex = TYPE_COMBOBOXDEFAULT;
            genderCombobox.SelectedIndex = GENDER_COMBOBOXDEFAULT;
            statusCombobox.SelectedIndex = STATUS_COMBOBOXDEFAULT;
            studentStatusCombobox.SelectedIndex = STUDENTSTATUS_COMBOBOXDEFAULT;
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
            if (c.Birthday != null && !(c.Birthday.Equals(defaultDateTime))) birthdayDatetimePicker.Value = c.Birthday;
            if (c.LastEnrolledDate != null && !(c.LastEnrolledDate.Equals(defaultDateTime))) lastEnrolledDateTimePicker.Value = c.LastEnrolledDate;
            nationalityTextbox.Text = c.Nationality;
            levelCombobox.Text = c.Level;
            sectionTextbox.Text = c.Section;
            religionTextbox.Text = c.Religion;
            lastschoolTextbox.Text = c.LastSchAttended;
            placeOfBirthTextbox.Text = c.PlaceOfBirth;
            if (c.Type != null) setComboboxValue(typeCombobox, c.Type, TYPE_COMBOBOXDEFAULT);
            if (c.Gender != null) setComboboxValue(genderCombobox, c.Gender, GENDER_COMBOBOXDEFAULT);
            if (c.OfficiallyEnrolled != null) setComboboxValue(statusCombobox, c.OfficiallyEnrolled, STATUS_COMBOBOXDEFAULT);
            if (c.StudentStatus != null) setComboboxValue(studentStatusCombobox, c.StudentStatus, STUDENTSTATUS_COMBOBOXDEFAULT);
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
            c.Birthday = birthdayDatetimePicker.Value;
            c.LastEnrolledDate = lastEnrolledDateTimePicker.Value;
            if ((nationalityTextbox.Text != null) && !(nationalityTextbox.Text.Equals("")))
                c.Nationality = nationalityTextbox.Text;
            if ((levelCombobox.Text != null) && !(levelCombobox.Text.Equals("")))
                c.Level = levelCombobox.Text;
            if ((sectionTextbox.Text != null) && !(sectionTextbox.Text.Equals("")))
                c.Section = sectionTextbox.Text;
            if ((religionTextbox.Text != null) && !(religionTextbox.Text.Equals("")))
                c.Religion = religionTextbox.Text;
            if ((placeOfBirthTextbox.Text != null) && !(placeOfBirthTextbox.Text.Equals("")))
                c.PlaceOfBirth = placeOfBirthTextbox.Text;
            if ((lastschoolTextbox.Text != null) && !(lastschoolTextbox.Text.Equals("")))
                c.LastSchAttended = lastschoolTextbox.Text;
            c.Type = typeCombobox.Text;
            c.Gender = genderCombobox.Text;
            c.OfficiallyEnrolled = statusCombobox.Text;
            c.StudentStatus = studentStatusCombobox.Text;
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
            this.Close();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.clearData();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            bool valid = validateFields();
            if (valid)
            {
                this.Enabled = false;
                loadingScreen.Show();
                Customer c = getCustomer();
                CustomerDAO.getInstance().saveCustomer(c);
                this.Enabled = true;
                loadingScreen.Hide();
            }
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





  


        

        


    }
}
