using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Southville.GP.Data;
using Southville.GP.Beans;

namespace StudentInformation.Forms
{
    public partial class SelectStudents : Form
    {
        private Loading loadingScreen = new Loading();
        private String filterInActive = "All"; //Only active students, (Yes, No, All)
        private String filterType = "All";
        private String filterStudStats = "All";
        private String filterEnrollStats = "All";
        private String filterStudClass = "All";

        public Customer selectedStudent = new Customer();
        public DialogResult result;
        public SelectStudents()
        {
            InitializeComponent();
        }

        private void SelectStudents_Load(object sender, EventArgs e)
        {
            //try
            //{
            //Session.getInstance().CustomerList = SQLData.getInstance().getAllCustomers();
            
            
            Session.getInstance().CustomerList = loadDetails();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = Session.getInstance().CustomerList;
            
            //}
            //catch (Exception er)
            //{
            //    MessageBox.Show(er.Message);
            //}
        }

        private void refreshViewFromSearch()
        {
            List<Customer> filteredResult = new List<Customer>();

           
                foreach (Customer c in Session.getInstance().CustomerList)
                {
                    try
                    {
                        if (filterInActive != "All" && filterType != "All" && filterStudStats != "All" && filterEnrollStats != "All" && filterStudClass != "All")
                        {
                            if (c.Inactive.Equals(Convert.ToBoolean(filterInActive)) && c.Type.Equals(filterType) && c.StudentStatus.Equals(filterStudStats) && c.OfficiallyEnrolled.Equals(filterEnrollStats) && c.CustomerClass.Equals(filterStudClass))
                            {
                                filteredResult.Add(c);
                            }
                        }

                        if (filterInActive != "All" && filterType == "All" && filterStudStats == "All" && filterEnrollStats == "All" && filterStudClass == "All")
                        {
                            if (c.Inactive.Equals(Convert.ToBoolean(filterInActive)))
                            {
                                filteredResult.Add(c);
                            }
                        }

                        if (filterInActive != "All" && filterType != "All" && filterStudStats == "All" && filterEnrollStats == "All" && filterStudClass == "All")
                        {
                            if (c.Inactive.Equals(Convert.ToBoolean(filterInActive)) && c.Type.Equals(filterType))
                            {
                                filteredResult.Add(c);
                            }
                        }
                        if (filterInActive != "All" && filterType != "All" && filterStudStats != "All" && filterEnrollStats == "All" && filterStudClass == "All")
                        {
                            if (c.Inactive.Equals(Convert.ToBoolean(filterInActive)) && c.Type.Equals(filterType) && c.StudentStatus.Equals(filterStudStats))
                            {
                                filteredResult.Add(c);
                            }
                        }
                        if (filterInActive != "All" && filterType != "All" && filterStudStats != "All" && filterEnrollStats != "All" && filterStudClass == "All")
                        {
                            if (c.Inactive.Equals(Convert.ToBoolean(filterInActive)) && c.Type.Equals(filterType) && c.StudentStatus.Equals(filterStudStats) && c.OfficiallyEnrolled.Equals(filterEnrollStats))
                            {
                                filteredResult.Add(c);
                            }
                        }

                        if (filterInActive == "All" && filterType == "All" && filterStudStats != "All" && filterEnrollStats == "All" && filterStudClass == "All")
                        {
                            if (c.StudentStatus.Equals(filterStudStats))
                            {
                                filteredResult.Add(c);
                            }
                        }

                        if (filterInActive == "All" && filterType == "All" && filterStudStats == "All" && filterEnrollStats == "All" && filterStudClass == "All")
                        {
                           
                        }
                    }
                    catch (NoNullAllowedException er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = filteredResult;
           
            
        }
        private List<Customer> loadDetails()
        {
            //List<Customer> resultList = new List<Customer>();
            //foreach (Customer customer in Session.getInstance().CustomerList)
            //{
            //    Customer c = EConnectData.getInstance().getCustomer(customer.CustomerID);
            //    c = SQLData.getInstance().getCustomer(c);
            //    resultList.Add(c);
            //}
            //return resultList;
            //loadingScreen.ShowDialog();
            List<Customer> resultList = new List<Customer>();
            try
            {
                foreach (Customer customer in Session.getInstance().CustomerList)
                {
                    Customer c = SQLData.getInstance().getCustomer(customer);
                    if (c.OfficiallyEnrolled == null)
                    {
                        c.OfficiallyEnrolled = "Not Applicable";
                    }
                    resultList.Add(c);
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            //loadingScreen.Hide();
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
            refreshDataGrid();
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
            result = DialogResult.Cancel;
        }

        private void searchByActivecb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchByActivecb.Text != "All")
            {
                filterInActive = searchByActivecb.Text.ToLower();
                refreshViewFromSearch();
            }
        }

        private void searchByTypecb_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterType = searchByTypecb.Text;
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

 


    }
}
