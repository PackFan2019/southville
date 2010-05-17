using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using StuffshopPOS.Data;
using StuffshopPOS.Beans;
namespace StuffshopPOS
{
    public partial class Form1 : Form
    {
       
        private StreamWriter itemWriter;
        private StreamReader itemReader;
        private PrintDocument printDoc = new PrintDocument();
        private PageSettings pgSettings = new PageSettings();
        private PrinterSettings prtSettings = new PrinterSettings();
        private Double amountDue = 0;
        private Double cash = 0;
        private Double change = 0;
        private Double grandTotal = 0;
        private String itemCode = "";
        private String UOFM = "";
        private Double itemPrice = 2.1;
        private int quantity = 2;
        private Double total = 2.1;
        private string custcash = "";
        private const int COLUMN_ITEMNAME = 0;
        private const int COLUMN_PRICE = 1;
        private const int COLUMN_UOFM = 2;
        private const int COLUMN_QUANTITY = 3;
        private const int COLUMN_TOTAL = 4;
        private const string CUSTNAMECREDIT = "Credit";
        private const string CUSTNAMECASH = "Cash";


        public Form1()
        {
            InitializeComponent();
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
        }
    

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                int index = itemList.Items.Count;

                List<Item> stuff = GPData.getAllItems();
                foreach (Item i in stuff)
                {
                    itemList.Items.Add(i.ToString());
                }
                itemList.SelectedIndex = 0;
                FileData fd = new FileData();
                fd.createSales();
                fd.createSalesHeader();
            }
            catch
            {
            }
        }

        private void priceGroupBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Item> stuff = GPData.getItems(priceGroupBox.Text);
            itemList.Items.Clear();
            foreach (Item i in stuff)
            {
                itemList.Items.Add(i.ToString());
            }
        }
        private void itemList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            UOFMlist.Refresh(); //Refreshes the list
            try
            {
                int index = itemList.SelectedIndex;
                if (index >= 0)//ItemList Checker
                {
                    UOFMlist.Items.Clear();
                    string sample = index.ToString();
                    Item i = GPData.items[index];
                    string temp = itemList.Items[index].ToString();
                    itemCodeLabel.Text = i.itemcode;
                    itemDescLabel.Text = i.itemname;
                    int uofmCount = UOFMlist.Items.Count;
                    foreach (Price n in i.priceList.prices)
                    {
                        UOFMlist.Items.Add(n.uofm.ToString());
                    }
                    if (i.priceList.prices.Count < 2)
                    {
                        UOFMlist.Enabled = true;
                        quantityPanel.Enabled = true;
                        if (i.priceList.prices.Count == 0) //This Adds "N/A" as a UOFM in items that contains no UOFM
                        {
                            UOFMlist.Items.Add("N/A");
                        }
                    }
                    else
                    {
                        UOFMlist.Enabled = true;
                        quantityPanel.Enabled = false;                      
                        if (UOFMlist.Items.Count > 1)
                        {
                            for (int j = 0; j < UOFMlist.Items.Count - 1; j++)
                                if (UOFMlist.Items[j].ToString() == UOFMlist.Items[j + 1].ToString())
                                {
                                    UOFMlist.Items.RemoveAt(j);
                                }
                        }
                    }
                    UOFMlist.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No item is selected", "Ooops!!!");
                }
            }
            catch (Exception er)
            {
            }
        }
        private void addCartbtn_Click(object sender, EventArgs e)
        {            
            quantityPanel.Visible = true;
        }

        private void refreshDataGrid()
        {
            grandTotal = 0;
            int count = Session.Cart.getSalesList().Count;
            int stopper = 0;
            while (stopper != count)
            {
                dataGridView1.DataSource = null;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = Session.Cart.getSalesList();
                stopper++;
            }
            if (Session.Cart.getSalesList().Count == 0)
            {
                dataGridView1.DataSource = null;
            }

            foreach (SalesEntry se1 in Session.Cart.getSalesList())
            {
                grandTotal += se1.Total; 

            }
            totalLbl.Text = grandTotal.ToString("0.00");
        }

        private void confirmbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (UOFMlist.SelectedItem.ToString() != "N/A")
                {
                    inserttable();
                }
                else
                {
                    pricepanel.Visible = true;
                }
            }
            catch
            {
            }
        }
        private void inserttable()
        {
            try
            {
                Item i = new Item();
                string temp = itemList.Items[itemList.SelectedIndex].ToString();
                i = GPData.getItem(temp);
                getTotal(i);
                refreshDataGrid();
                SalesEntry se = new SalesEntry();
                se.UOFM = UOFMlist.SelectedItem.ToString();
                Price p = new Price();
                p = i.priceList.prices.Find(delegate(Price er) { return er.uofm.Equals(se.UOFM); });
                quantityPanel.Enabled = false;
                confirmbtn.Enabled = true;
            }
            catch
            {
                Console.Write("Quantity should be a positive integer", "Ooops!!!");
            }

        }
        private void getTotal(Item i)
        {
            Price p = new Price();
            SalesEntry se = new SalesEntry();
            SalesEntry se2 = new SalesEntry();
            foreach (SalesEntry br in Session.Cart.getSalesList())
            {
                if (br.ItemCode == i.itemcode)
                {
                    se2 = br;
                }
            }
            se.ItemCode = i.itemcode;
            se.ItemName = i.itemname;
            se.UOFM = UOFMlist.SelectedItem.ToString();
            se.Quantity = int.Parse(quantityTb.Text);
            se.Price = 0;
            if (UOFMlist.SelectedItem.ToString() == "N/A")
            {
                if (se2.Price == 0)
                {
                    pricepanel.Visible = true;
                }
                se.Price = double.Parse(prctb.Text);
                se.Total = se.Price * Convert.ToDouble(se.Quantity);
                Session.Cart.addEntry(se);
            }
            else
            {
                p = i.priceList.prices.Find(delegate(Price er) { return er.uofm.Equals(se.UOFM); });
                se.Price = p.Uomprice;
                se.Total = se.Price * Convert.ToDouble(se.Quantity) * p.Qtybsoum;
                Session.Cart.addEntry(se);
            }
            grandTotal = 0;

            foreach (SalesEntry se1 in Session.Cart.getSalesList())
            {
                grandTotal += se1.Total;
                foreach (Price pr in i.priceList.prices)
                {
                    if (pr.uofm == se1.UOFM && se1.Quantity >= pr.Fromqty && se1.Quantity < pr.Toqty)
                    {
                        se1.Price = pr.Uomprice;
                    }

                }

            }
            totalLbl.Text = grandTotal.ToString("0.00");
            Item it = new Item();
            it.Gtotal = grandTotal;
        }

        private void removeCartbtn_Click(object sender, EventArgs e)
        {
            try
            {
                grandTotal = 0;
                removeItem();
                refreshDataGrid();        
            }

            catch (System.Exception error)
            {
                MessageBox.Show(error.Message, "Ooops!!!");
            }
        }
        private void removeItem()
        {
            try
            {
                //refreshing the list in SalesEntry after the item was removed
                SalesEntry se = new SalesEntry();

                int i = dataGridView1.CurrentCell.RowIndex;
                String itemName = dataGridView1[0, i].Value.ToString();
                String uofm = dataGridView1[1, i].Value.ToString();
                String price = dataGridView1[2, i].Value.ToString();
                String quantity = dataGridView1[3, i].Value.ToString();
                String total = dataGridView1[4, i].Value.ToString();

                se.ItemName = itemName;
                se.UOFM = uofm;
                se.Price = Convert.ToDouble(price);
                se.Quantity = Convert.ToInt32(quantity);
                se.Total = Convert.ToDouble(total);
                Session.Cart.removeEntry(se);
                refreshDataGrid();
            }
            catch
            {
                MessageBox.Show("What is your error");
            }
        }

        /*
         * This function ....
         */ 
        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            quantityPanel.Enabled = false;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //page setup menu
            PageSetupDialog pageSetupDialog = new PageSetupDialog();
            pageSetupDialog.PageSettings = pgSettings;
            pageSetupDialog.PrinterSettings = prtSettings;
            pageSetupDialog.AllowOrientation = true;
            pageSetupDialog.AllowMargins = true;
            pageSetupDialog.ShowDialog();
        }

        private void printItem()
        {
            try
            {
                File.Delete("itemPrint.txt");//deleting the current text file
                itemWriter = new StreamWriter("itemPrint.txt", true);//setting up textfile to append the data
                itemWriter.WriteLine("{0,-5}{1,-18}{2,-5}{3,-3}{4,-10}{5,-8}", "Qty", "Item Code", "UOFM", " ", "Price", "Total");//setting up header positioning
                itemWriter.WriteLine("------------------------------------------------");
                foreach (SalesEntry se1 in Session.Cart.getSalesList())//getting all the entry in Session.Cart.getSalesList() list
                {
                    itemCode = se1.ItemCode;
                    itemPrice = se1.Price;
                    quantity = se1.Quantity;
                    UOFM = se1.UOFM;
                    total = se1.Total;
                    //setting up item positioning to print as receipt
                    itemWriter.WriteLine("{0,-5}{1,-18}{2,-5}{3,-3}{4,-10:C}{5,-8:C}", quantity.ToString(), itemCode, UOFM, "@", itemPrice.ToString("0.00"), total.ToString("0.00"));
                }
                itemWriter.Close();
            }
            catch(System.Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }
        private void getTransId()
        {
            //setting up the transactionId/TransID
            SalesEntry.transId = DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
        }
        private void printDoc_PrintPage(Object sender, PrintPageEventArgs e)
        {
            try
            {
                getTransId();
                int quantityCount = 0;
                printItem();
                foreach (SalesEntry se in Session.Cart.getSalesList())//getting all the quantity entry in Session.Cart.getSalesList() list
                {
                    quantityCount += se.Quantity;
                }
                //getting all the entries in a textfile named itemPrint.txt
                itemReader = new StreamReader("itemPrint.txt");
                String printReader = itemReader.ReadToEnd();//reading all item in the textfile until the bottom part
                itemReader.Close();
                //setting up the format and output of the receipt to be printed
                String textToPrint =
                    "  SOUTHVILLE INTERNATIONAL SCHOOL AND COLLEGES" + "\n" +
                    "    1281 Tropical Ave., Cor Luxembourg St.," + "\n" +
                    "           BF Homes Las Piñas City" + "\n" +
                    "\n------------------------------------------------\n" +
                "TRAN " + SalesEntry.transId.ToString() +
                "\n------------------------------------------------\n" +
                printReader.ToString() + "\n" +
               quantityCount + "  Item(s)" +
                "\n------------------------------------------------\n" +
                "Paid in : \t\t\t\t\t" + custcash +
                "\n\nAMOUNT DUE :" + "\t\t\t" + grandTotal.ToString("0.00") +
                "\nCASH       :" + "\t\t\t" + cash.ToString("0.00") +"\n" +
                "\n------------------------------------------------\n" +
                "CHANGE     :" + "\t\t\t" + change.ToString("0.00") + "\n" +
                DateTime.Now.ToLongDateString() + "\n" +
                "Thank you! Come Again.";
                Font printFont = new Font("Courier New", 7);//setting up the font type and font size of the text in receipt
                int leftMargin = 0;
                int topMargin = 0;
                e.Graphics.DrawString(textToPrint, printFont, Brushes.Black,
                      leftMargin, topMargin);
            }
            catch (System.Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                int zoomValue = 150;
                PrintPreviewDialog dlg = new PrintPreviewDialog();
                dlg.Document = printDoc;                
                dlg.Height = 600;
                dlg.Width = 445;
                dlg.PrintPreviewControl.Zoom = zoomValue / 100f;
                dlg.ShowDialog();

            }
            catch
            {
                MessageBox.Show("There was an error in Print Preview option..Please restart the POS..","Ooops!!!");
            }
        }

        public void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                printDoc.DefaultPageSettings = pgSettings;
                PrintDialog dlg = new PrintDialog();
                dlg.Document = printDoc;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
            catch
            {
                MessageBox.Show("Printer is not available!!!","Ooops!!!");
            }
        }

        private void salesReportentry()
        {
            SalesEntry se = new SalesEntry();
            se.ItemCode = itemCode;
            se.Price = itemPrice;
            se.Quantity = quantity;
            FileData.saveToFile(SalesEntry.transId, se);//calling other function to save the file(transId, SalesEntry se)
        }

        private void printReceiptbtn_Click(object sender, EventArgs e)
        {
                if (cashTb.Text == "") MessageBox.Show("Please Input Payment Value", "Ooops");//if cash textbox is not empty or null
                if (Convert.ToDouble(cashTb.Text) < grandTotal) MessageBox.Show("Insuffecient Payment", "Ooops");//if cash paid is less than the total bill/grandtotal 
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to print the receipt?", "Print Receipt", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        custPanel.Visible = true;
                    }
                }
        }

        private void cashTb_TextChanged(object sender, EventArgs e)
        {
            if (cashTb.Text == "")
            {
                MessageBox.Show("Input Payment", "Ooops");
            }
            else
            {
                try
                {
                    amountDue = Convert.ToDouble(totalLbl.Text);
                    cash = Convert.ToDouble(cashTb.Text);
                    getChange(amountDue, cash);
                    printReceiptbtn.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Please Input a Valid Value", "Ooops");
                    printReceiptbtn.Enabled = false;
                }
            }
        }

        private void getChange(Double x, Double y)
        {
            change = y - x;
            changeLbl.Text = change.ToString("0.00");
        }

        private void UOFMlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                itemPriceLabel.Text = "";
                quantityPanel.Enabled = true;
                int index = itemList.SelectedIndex;
                Item i = GPData.items[index];
                Price p = new Price();
                SalesEntry se = new SalesEntry();//new SalesEntry method
                se.UOFM = UOFMlist.SelectedItem.ToString();
                p = i.priceList.prices.Find(delegate(Price er) { return er.uofm.Equals(se.UOFM); });//searching uofm from prices in i.priceList.prices list entries
                itemPriceLabel.Text = p.Uomprice.ToString();
            }
            catch
            {
            }
        }

        private void conBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (cashRb.Checked == true)
                {
                    custcash = CUSTNAMECASH;
                }
                else if (creditRb.Checked == true)
                {
                    custcash = CUSTNAMECREDIT;
                }
                else
                {
                    MessageBox.Show("Please input term of payment", "Ooops");
                }
                toolStripMenuItem2_Click(sender, e);
                printOptionpanel.Visible = true;
                itemList.Enabled = true;
                UOFMlist.Enabled = true;
                quantityPanel.Enabled = true;
                custPanel.Visible = false;

              
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (prctb.Text == "")
            {
                MessageBox.Show("Please Input Price", "Ooops");
            }
            else
            {
                try 
                {
                    Convert.ToInt32(prctb.Text);
                    inserttable();
                    pricepanel.Visible = false;
                }
                catch
                {
                    MessageBox.Show("Please Input Valid Value","Ooops");
                }
            }
        }
       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void PnSbtn_Click(object sender, EventArgs e)
        {
            toolStripMenuItem3_Click(sender,e);
            salesReportentry();
            printOptionpanel.Visible = false;

            getTransId();
            Session.Cart.getSalesList().Clear();
            refreshDataGrid();
            grandTotal = 0;
            cashTb.Text = "";

            saveTrans();
        }
        private void saveTrans()
        {
            //saving the filename of the text file and it's transaction info
            itemWriter = new StreamWriter("sales-" + DateTime.Now.ToString("MMMM") + "-" + DateTime.Now.Day.ToString() + "-link.txt", true);
            itemWriter.WriteLine(SalesEntry.transId.ToString() + "," + DateTime.Now.ToShortDateString());
            itemWriter.Close();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            getTransId();
            salesReportentry();
            printOptionpanel.Visible = false;

            Session.Cart.getSalesList().Clear();
            refreshDataGrid();
            grandTotal = 0;
            cashTb.Text = "";
            saveTrans();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printOptionpanel.Visible = false;
        }

        private void reportViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report_Viewer viiew = new Report_Viewer();
            viiew.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
