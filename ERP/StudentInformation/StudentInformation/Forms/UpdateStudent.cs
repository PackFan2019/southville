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
    public partial class UpdateStudent : Form
    {
        private Loading loadingScreen = new Loading();
        //private List<Object> chosenFields = ;
        private String caption = "Selected Students with filter applied:";
        public UpdateStudent()
        {
            InitializeComponent();
        }

        private void UpdateStudent_Load(object sender, EventArgs e)
        {
            loadChosenFields();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = Session.getInstance().SelectedCustomerList;
        }
        private void loadChosenFields()
        {
            String choosenStringField = "";
            foreach(Object fields in Session.getInstance().SelectedFields)
            {
                choosenStringField += ", " + fields;
            }
            captionLbl.Text = caption;
            if (choosenStringField != "")
            {
                choosenFieldLbl.Text = choosenStringField.Substring(2);
            }
        }
        private void updateByEnrollStatscb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void updateByStudTypecb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (fieldToUpdatecb.Text != "" && newValuecb.Text != "")
            {
                String column = fieldToUpdatecb.Text;
                String newVal = newValuecb.Text;
                DialogResult result = MessageBox.Show("Are you sure you want to update column ''" + column +
                    " = " + newVal + "''? If you answer Yes, this operation cannot be undone.", "SQL Server Enterprise Manager",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result.Equals(DialogResult.Yes))
                {
                    this.Enabled = false;
                    loadingScreen.Show();
                    updateCustomer();
                    this.Enabled = true;
                    loadingScreen.Hide();
                }
            }
            else { MessageBox.Show("You must choose field to update", "Update Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private List<Customer> getSelectedCustomer()
        {
            List<Customer> selectedStudents = new List<Customer>();
            foreach(DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells[0].Value != null)
                {
                    Customer c = new Customer();
                    c.CustomerID = dr.Cells[1].Value.ToString();
                    selectedStudents.Add(c);
                }
            }
            return selectedStudents;
        }
        private String getPT_UD_Number(String stringValue)
        {
            String UD_number = null;
            switch (stringValue)
            {
                case "Enrollment Status": UD_number = Constants.ENROLLED_FIELD_ID;
                    break;
                case "Student Class": UD_number = Constants.CUSTOMERCLASS;
                    break;
                case "Level": UD_number = Constants.LEVEL_FIELD_ID;
                    break;
                case "Section": UD_number = Constants.SECTION_FIELD_ID;
                    break;
                case "Nationality": UD_number = Constants.NATIONALITY_FIELD_ID;
                    break;
                case "Religion": UD_number = Constants.RELIGION_FIELD_ID;
                    break;
            }
            return UD_number;
        }
        private void updateCustomer()
        {
            String PT_Ud_Id = getPT_UD_Number(fieldToUpdatecb.Text);
            String window_ext_id = Constants.WINDOW_EXT_ID;
            String newValue = newValuecb.Text;
            SQLData.getInstance().massUpdate(window_ext_id, getSelectedCustomer(), newValue, PT_Ud_Id);
        }

        private void updateByLevelcb_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        public static List<Object> getSection(String Level)
        {
            List<Object> section = new List<Object>();
            switch (Level)
            {
                case "Grade 1": section.Add("Einstein");
                    section.Add("Galileo");
                    section.Add("Newton");
                    break;
                case "Grade 2": section.Add("Archimedes");
                    section.Add("Franklin");
                    section.Add("Euclid");
                    break;
                case "Grade 3": section.Add("Peace");
                    section.Add("Peace-ESL");
                    section.Add("Faith");
                    section.Add("Piety");
                    section.Add("Piety-ESL");
                    section.Add("Wisdom");
                    break;
                case "Grade 4": section.Add("Hope");
                    section.Add("Hope-INNOVE");
                    section.Add("Charity");
                    section.Add("Respectfulness");
                    section.Add("Humility");
                    section.Add("Respectfulness-ESL");
                    break;
                case "Grade 5": section.Add("Righteousness");
                    section.Add("Loyalty");
                    section.Add("Trustworthiness");
                    section.Add("Trustworthiness-INNOVE");
                    section.Add("Honesty");
                    section.Add("Honesty-ESL");
                    break;
                case "Grade 6": section.Add("Courage");
                    section.Add("Punctuality");
                    section.Add("Perseverance");
                    section.Add("Collaboration");
                    section.Add("Punctuality-ESL");
                    break;
                case "Grade 7": section.Add("Resilience");
                    section.Add("Resilience-ESL");
                    break;
                case "HS I": section.Add("Integrity");
                    section.Add("Justice");
                    section.Add("Empathy");
                    section.Add("Joy");
                    section.Add("Creativity");
                    section.Add("Creativity-ESL");
                    break;
                case "HS II": section.Add("Generosity");
                    section.Add("Generosity-ESL");
                    section.Add("Generosity-INNOVE");
                    section.Add("Compassion");
                    section.Add("Sincerity");
                    section.Add("Diligence");
                    section.Add("Fortitude");
                    break;
                case "HS III": section.Add("Prudence");
                    section.Add("Responsibility");
                    section.Add("Conviction");
                    section.Add("Leadership");
                    section.Add("Leadership-ESL");
                    section.Add("Commitment");
                    section.Add("Patriotism");
                    break;
                case "HS IV": section.Add("Patience");
                    section.Add("Industry");
                    section.Add("Excellence");
                    section.Add("Competence");
                    section.Add("Synergy");
                    section.Add("Synergy-ESL");
                    break;
            }
            return section;
        }
        public static List<Object> getLevel(String Type)
        {
            List<Object> level = new List<Object>();
            switch(Type)
            {
                case "College": level.Add("ABMA 2004");
                    level.Add("ABMA 2007");
                    level.Add("ABMA 2009");
                    level.Add("ABMC 2002");
                    level.Add("ABMC 2007");
                    level.Add("ABMC 2009");
                    level.Add("BEED");
                    level.Add("BEED 2007");
                    level.Add("BEED 2009");
                    level.Add("BSBAHRM 2005");
                    level.Add("BSBAHRM 2007");
                    level.Add("BSBAHRM 2009");
                    level.Add("BSBAM 2005");
                    level.Add("BSBAM 2007");
                    level.Add("BSBAM 2009");
                    level.Add("BSEMF");
                    level.Add("BSENTREP 2006");
                    level.Add("BSENTREP 2007");
                    level.Add("BSENTREP 2009");
                    level.Add("BSENTREP 2006");
                    level.Add("BSIT");
                    level.Add("BSIT 2003");
                    level.Add("BSIT 2006");
                    level.Add("BSIT 2007");
                    level.Add("BSIT 2009");
                    level.Add("BSN 2004");
                    level.Add("BSN 2008");
                    level.Add("BSN 2009");
                    level.Add("BSPSYC 2004");
                    level.Add("BSPSYC 2007");
                    level.Add("BS PSYC 2009");
                    level.Add("BST");
                    level.Add("BST 2009");
                    level.Add("All");
                    break;
                case "International Baccal": level.Add("IB Year 1");
                    level.Add("IB Year 2");
                    level.Add("All");
                    break;
                case "Basic Education": level.Add("Junior Prep");
                    level.Add("Senior Prep");
                    level.Add("Kinder");
                    level.Add("Nursery");
                    level.Add("Grade 1");
                    level.Add("Grade 2");
                    level.Add("Grade 3");
                    level.Add("Grade 4");
                    level.Add("Grade 5");
                    level.Add("Grade 6");
                    level.Add("Grade 7");
                    level.Add("HS I");
                    level.Add("HS II");
                    level.Add("HS III");
                    level.Add("HS IV");
                    level.Add("All");
                    break;
            }
            return level;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fieldToUpdatecb_SelectedIndexChanged(object sender, EventArgs e)
        {
            newValuecb.Items.Clear();
            List<Object> selectedAttributes = getFieldAttributes(fieldToUpdatecb.Text);
            foreach (Object attributes in selectedAttributes)
            {
                newValuecb.Items.Add(attributes);
            }
            newValuecb.SelectedIndex = 0;
        }
        private List<Object> getFieldAttributes(String selectedField)
        {
            List<Object> attributes = new List<Object>();
            switch (selectedField)
            {
                case "Student Type": attributes.Add("Basic Education");
                    attributes.Add("International Baccal");
                    attributes.Add("College");
                    attributes.Add("Innove");
                    attributes.Add("Other");
                    attributes.Add("Not Applicable");
                    break;
                case "Student Status": 
                    attributes.Add("New student");
                    attributes.Add("Old student");
                    attributes.Add("Returning");
                    attributes.Add("Not applicable");
                    break;
                case "Enrollment Status": attributes.Add("Enrolled");
                    attributes.Add("Not Enrolled");
                    attributes.Add("Assessed");
                    attributes.Add("Not Applicable");
                    break;
                case "Student Class": attributes.Add("STUDENT");
                    attributes.Add("COLLEGE_STUDENT");
                    break;
                case "Level": attributes.Add("Junior Prep");
                    attributes.Add("Senior Prep");
                    attributes.Add("Kinder");
                    attributes.Add("Nursery");
                    attributes.Add("Grade 1");
                    attributes.Add("Grade 2");
                    attributes.Add("Grade 3");
                    attributes.Add("Grade 4");
                    attributes.Add("Grade 5");
                    attributes.Add("Grade 6");
                    attributes.Add("Grade 7");
                    attributes.Add("HS I");
                    attributes.Add("HS II");
                    attributes.Add("HS III");
                    attributes.Add("HS IV");
                    attributes.Add("IB Year 1");
                    attributes.Add("IB Year 2");
                    attributes.Add("ABMA 2004");
                    attributes.Add("ABMA 2007");
                    attributes.Add("ABMA 2009");
                    attributes.Add("ABMC 2002");
                    attributes.Add("ABMC 2007");
                    attributes.Add("ABMC 2009");
                    attributes.Add("BEED");
                    attributes.Add("BEED 2007");
                    attributes.Add("BEED 2009");
                    attributes.Add("BSBAHRM 2005");
                    attributes.Add("BSBAHRM 2007");
                    attributes.Add("BSBAHRM 2009");
                    attributes.Add("BSBAM 2005");
                    attributes.Add("BSBAM 2007");
                    attributes.Add("BSBAM 2009");
                    attributes.Add("BSEMF");
                    attributes.Add("BSENTREP 2006");
                    attributes.Add("BSENTREP 2007");
                    attributes.Add("BSENTREP 2009");
                    attributes.Add("BSENTREP 2006");
                    attributes.Add("BSIT");
                    attributes.Add("BSIT 2003");
                    attributes.Add("BSIT 2006");
                    attributes.Add("BSIT 2007");
                    attributes.Add("BSIT 2009");
                    attributes.Add("BSN 2004");
                    attributes.Add("BSN 2008");
                    attributes.Add("BSN 2009");
                    attributes.Add("BSPSYC 2004");
                    attributes.Add("BSPSYC 2007");
                    attributes.Add("BS PSYC 2009");
                    attributes.Add("BST");
                    attributes.Add("BST 2009");
                    break;
                case "Section":attributes.Add("Einstein");
                    attributes.Add("Galileo");
                    attributes.Add("Newton");
                    attributes.Add("Archimedes");
                    attributes.Add("Franklin");
                    attributes.Add("Euclid");
                    attributes.Add("Peace");
                    attributes.Add("Faith");
                    attributes.Add("Piety");
                    attributes.Add("Piety(ILC)");
                    attributes.Add("Wisdom");
                    attributes.Add("Hope");
                    attributes.Add("Charity");
                    attributes.Add("Respectfulness");
                    attributes.Add("Humility)");
                    attributes.Add("Respectfulness(ILC)");
                    attributes.Add("Righteousness");
                    attributes.Add("Loyalty");
                    attributes.Add("Trustworthiness");
                    attributes.Add("Honesty)");
                    attributes.Add("Honesty(ILC)");
                    attributes.Add("Courage");
                    attributes.Add("Punctuality");
                    attributes.Add("Perseverance");
                    attributes.Add("Collaboration)");
                    attributes.Add("Punctuality(ILC)");
                    attributes.Add("Resilience");
                    attributes.Add("Resilience(ILC)");
                    attributes.Add("Integrity");
                    attributes.Add("Justice");
                    attributes.Add("Joy");
                    attributes.Add("Creativity)");
                    attributes.Add("Creativity(ILC)");
                    attributes.Add("Generosity");
                    attributes.Add("Compassion");
                    attributes.Add("Sincerity");
                    attributes.Add("Diligence)");
                    attributes.Add("Fortitude");
                    attributes.Add("Fortitude(ILC)");
                    attributes.Add("Prudence");
                    attributes.Add("Responsibility");
                    attributes.Add("Conviction");
                    attributes.Add("Leadership");
                    attributes.Add("Leadership(ILC)");
                    attributes.Add("Commitment");
                    attributes.Add("Patriotism");
                    attributes.Add("Patience");
                    attributes.Add("Industry");
                    attributes.Add("Excellence");
                    attributes.Add("Competence");
                    attributes.Add("Synergy");
                    attributes.Add("Synergy(ILC)");
                    break;
                case "Religion": attributes.Add("7th Day Adventist");
                    attributes.Add("Roman Catholic");
                    break;
            }
            return attributes;
        }
    }
}
