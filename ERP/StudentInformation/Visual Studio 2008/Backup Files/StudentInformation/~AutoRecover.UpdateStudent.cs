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
        public UpdateStudent()
        {
            InitializeComponent();
        }

        private void UpdateStudent_Load(object sender, EventArgs e)
        {
        }

        private void updateByEnrollStatscb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void updateByStudTypecb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            loadingScreen.Show();
            updateCustomer();
            this.Enabled = true;
            loadingScreen.Hide();
        }
        private void updateCustomer()
        {
            //foreach (Customer c in Session.getInstance().CustomerList)
            //{
            //    if (!updateByEnrollStatscb.Text.Equals(null) && !updateByEnrollStatscb.Text.Equals(""))
            //    {
            //        c.OfficiallyEnrolled = updateByEnrollStatscb.Text;
            //    }
            //    if (!updateByStudTypecb.Text.Equals(null) && !updateByStudTypecb.Text.Equals(""))
            //    {
            //        c.Type = updateByStudTypecb.Text;
            //    }
            //    if (!updateByStudClasscb.Text.Equals(null) && !updateByStudClasscb.Text.Equals(""))
            //    {
            //        c.CustomerClass = updateByStudClasscb.Text;
            //    }
            //    if (!updateByStudStats.Text.Equals(null) && !updateByStudStats.Text.Equals(""))
            //    {
            //        c.StudentStatus = updateByStudStats.Text;
            //    }
            //    if (!updateByLevelcb.Text.Equals(null) && !updateByLevelcb.Text.Equals(""))
            //    {
            //        c.Level = updateByLevelcb.Text;
            //    }
            //    if (!updateBySectioncb.Text.Equals(null) && !updateBySectioncb.Text.Equals(""))
            //    {
            //        c.Section = updateBySectioncb.Text;
            //    }
            //    CustomerDAO.getInstance().saveCustomer(c);
            //}
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
                    section.Add("Faith");
                    section.Add("Piety");
                    section.Add("Piety(ILC)");
                    section.Add("Wisdom");
                    break;
                case "Grade 4": section.Add("Hope");
                    section.Add("Charity");
                    section.Add("Respectfulness");
                    section.Add("Humility)");
                    section.Add("Respectfulness(ILC)");
                    break;
                case "Grade 5": section.Add("Righteousness");
                    section.Add("Loyalty");
                    section.Add("Trustworthiness");
                    section.Add("Honesty)");
                    section.Add("Honesty(ILC)");
                    break;
                case "Grade 6": section.Add("Courage");
                    section.Add("Punctuality");
                    section.Add("Perseverance");
                    section.Add("Collaboration)");
                    section.Add("Punctuality(ILC)");
                    break;
                case "Grade 7": section.Add("Resilience");
                    section.Add("Resilience(ILC)");
                    break;
                case "HS I": section.Add("Integrity");
                    section.Add("Justice");
                    section.Add("Joy");
                    section.Add("Creativity)");
                    section.Add("Creativity(ILC)");
                    break;
                case "HS II": section.Add("Generosity");
                    section.Add("Compassion");
                    section.Add("Sincerity");
                    section.Add("Diligence)");
                    section.Add("Fortitude");
                    section.Add("Fortitude(ILC)");
                    break;
                case "HS III": section.Add("Prudence");
                    section.Add("Responsibility");
                    section.Add("Conviction");
                    section.Add("Leadership");
                    section.Add("Leadership(ILC)");
                    section.Add("Commitment");
                    section.Add("Patriotism");
                    break;
                case "HS IV": section.Add("Patience");
                    section.Add("Industry");
                    section.Add("Excellence");
                    section.Add("Competence");
                    section.Add("Synergy");
                    section.Add("Synergy(ILC)");
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
            this.Hide();
        }
    }
}
