using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;
using System.Windows.Forms;
using StudentAssessment.Objects;
using StudentAssessment.Common;
using StudentAssessment.Adapter;
using log4net;
using System.Reflection;

namespace StudentAssessment
{
    public partial class frmItemLookup : Form
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        NameValueCollection config = (NameValueCollection)ConfigurationManager.AppSettings;
        Items items;
        string itemNumber = "";
        List<string> selectedItems = new List<string>();
        string level;
        string currency;
        bool itemSelected = false;
        bool subjectsOnly = false;

        public string[] GetSelectedItems()
        {
            if (itemSelected)
            {
                return selectedItems.ToArray();
            }
            else
            {
                return null;
            }
            
        }

        public frmItemLookup(string level, string currency)
        {
            //this.itemNumber = itemNumber;            
            InitializeComponent();
            this.level = level;
            this.currency = currency;
            initializeList();            
        }

        public frmItemLookup(string level, string currency, bool subjectsOnly)
        {
            //this.itemNumber = itemNumber;            
            InitializeComponent();
            this.level = level;
            this.currency = currency;
            this.subjectsOnly = subjectsOnly;
            initializeList();


        }

        private void initializeList()
        {
            lstItemList.Columns.Clear();
            lstItemList.Columns.Add("Class ID", 60, HorizontalAlignment.Left);
            lstItemList.Columns.Add("Item No", 90, HorizontalAlignment.Left);
            lstItemList.Columns.Add("Description", 160, HorizontalAlignment.Left);
            lstItemList.Columns.Add("Unit Price", 60, HorizontalAlignment.Right);
        }

        private void addItems(string itemNo)
        {
            string price = "";
            try
            {
                lstItemList.Items.Clear();

                foreach (Item item in items)
                {
                    //Added 11/21/2011
                    bool showCondition = true;

                    if (!item.ItemNo.ToString().ToUpper().
                        StartsWith(itemNo.ToUpper())) showCondition = false;

                    if (chkCollegeSubjs.Checked && item.ItemType != ItemType.Kit)
                        showCondition = false;
                    
                    if (showCondition)
                    {
                        //added 20101007 - don't show the price if the item is a kit
                        if (item.ItemType == ItemType.Kit) 
                        {
                            price = "";
                        }
                        else
                        {
                            price = Convert.ToString(item.Unitprice).Trim();
                        }

                        if (!subjectsOnly) //added 20110426 list only subject identifiers
                        {
                            lstItemList.Items.Add(new ListViewItem(
                            new string[] { 
                            item.ItemClass.Trim(),
                            item.ItemNo.ToString().Trim(),
                            item.ItemDescription.ToString().Trim(), 
                            price}));
                        }
                        else
                        {
                            if (item.ItemClass == config["Subject_Identifier"].ToString())
                            {
                                lstItemList.Items.Add(new ListViewItem(
                                new string[] { 
                                item.ItemClass.Trim(),
                                item.ItemNo.ToString().Trim(),
                                item.ItemDescription.ToString().Trim(), 
                                price}));
                            }
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                Prompt.ShowError(ex.Message);
            }

        }

        private void txtItemNo_TextChanged(object sender, EventArgs e)
        {
            addItems(txtItemNo.Text);
        }

        private void lstItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItems.Clear();
            if (lstItemList.SelectedItems.Count >= 1)
            {
                for (int i = 0; i <= lstItemList.SelectedItems.Count - 1; i++)
                {
                    selectedItems.Add(lstItemList.SelectedItems[i].SubItems[1].Text);
                }
                itemNumber = lstItemList.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void lstItemList_DoubleClick(object sender, EventArgs e)
        {
            btnOK_Click(sender, e);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
            itemSelected = true;
        }

        private void frmItemLookup_Load(object sender, EventArgs e)
        {
            try
            {
                items = ItemAdapter.Instance.GetItems(level
                    , currency
                    , config["Default_U_of_M"]);
                                
                txtItemNo.Text = itemNumber;
                addItems(itemNumber);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                Prompt.ShowError(ex.Message);
            }
        }

        private void frmItemLookup_FormClosing(object sender, FormClosingEventArgs e)
        {
            itemSelected = false;
        }

        private void chkCollegeSubjs_CheckedChanged(object sender, EventArgs e)
        {
            addItems(txtItemNo.Text);
        }
    }
}