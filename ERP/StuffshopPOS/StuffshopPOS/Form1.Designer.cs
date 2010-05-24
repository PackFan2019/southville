namespace StuffshopPOS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.itemList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.priceGroupBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.itemCodeLabel = new System.Windows.Forms.Label();
            this.itemDescLabel = new System.Windows.Forms.Label();
            this.itemPriceLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerPricegroupReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quantityPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.quantityTb = new System.Windows.Forms.TextBox();
            this.Cancelbtn = new System.Windows.Forms.Button();
            this.confirmbtn = new System.Windows.Forms.Button();
            this.removeCartbtn = new System.Windows.Forms.Button();
            this.printReceiptbtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalLbl = new System.Windows.Forms.Label();
            this.cashTb = new System.Windows.Forms.TextBox();
            this.changeLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.UOFMlist = new System.Windows.Forms.ListBox();
            this.custPanel = new System.Windows.Forms.Panel();
            this.conBtn = new System.Windows.Forms.Button();
            this.creditRb = new System.Windows.Forms.RadioButton();
            this.cashRb = new System.Windows.Forms.RadioButton();
            this.pricepanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.prctb = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.printOptionpanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.PnSbtn = new System.Windows.Forms.Button();
            this.skinCrafterLight1 = new DMSoft.SkinCrafterLight();
            this.menuStrip1.SuspendLayout();
            this.quantityPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.custPanel.SuspendLayout();
            this.pricepanel.SuspendLayout();
            this.printOptionpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemList
            // 
            this.itemList.FormattingEnabled = true;
            this.itemList.Location = new System.Drawing.Point(15, 54);
            this.itemList.Name = "itemList";
            this.itemList.Size = new System.Drawing.Size(312, 368);
            this.itemList.TabIndex = 0;
            this.itemList.SelectedIndexChanged += new System.EventHandler(this.itemList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pricegroup";
            // 
            // priceGroupBox
            // 
            this.priceGroupBox.FormattingEnabled = true;
            this.priceGroupBox.Items.AddRange(new object[] {
            "All",
            "OFFICE EQP"});
            this.priceGroupBox.Location = new System.Drawing.Point(76, 30);
            this.priceGroupBox.Name = "priceGroupBox";
            this.priceGroupBox.Size = new System.Drawing.Size(248, 21);
            this.priceGroupBox.TabIndex = 2;
            this.priceGroupBox.SelectedIndexChanged += new System.EventHandler(this.priceGroupBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Item Code:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Item Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Price:";
            // 
            // itemCodeLabel
            // 
            this.itemCodeLabel.AutoSize = true;
            this.itemCodeLabel.Location = new System.Drawing.Point(440, 94);
            this.itemCodeLabel.Name = "itemCodeLabel";
            this.itemCodeLabel.Size = new System.Drawing.Size(39, 13);
            this.itemCodeLabel.TabIndex = 7;
            this.itemCodeLabel.Text = "(blank)";
            // 
            // itemDescLabel
            // 
            this.itemDescLabel.AutoSize = true;
            this.itemDescLabel.Location = new System.Drawing.Point(440, 119);
            this.itemDescLabel.Name = "itemDescLabel";
            this.itemDescLabel.Size = new System.Drawing.Size(39, 13);
            this.itemDescLabel.TabIndex = 8;
            this.itemDescLabel.Text = "(blank)";
            // 
            // itemPriceLabel
            // 
            this.itemPriceLabel.AutoSize = true;
            this.itemPriceLabel.Location = new System.Drawing.Point(440, 140);
            this.itemPriceLabel.Name = "itemPriceLabel";
            this.itemPriceLabel.Size = new System.Drawing.Size(39, 13);
            this.itemPriceLabel.TabIndex = 9;
            this.itemPriceLabel.Text = "(blank)";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(776, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem1.Text = "Page Set&up";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem2.Text = "Print Pre&vew";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem3.Text = "&Print";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.reportViewerToolStripMenuItem,
            this.customerPricegroupReportToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.optionToolStripMenuItem.Text = "&Option";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            // 
            // reportViewerToolStripMenuItem
            // 
            this.reportViewerToolStripMenuItem.Name = "reportViewerToolStripMenuItem";
            this.reportViewerToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.reportViewerToolStripMenuItem.Text = "Customer Report";
            this.reportViewerToolStripMenuItem.Click += new System.EventHandler(this.reportViewerToolStripMenuItem_Click);
            // 
            // customerPricegroupReportToolStripMenuItem
            // 
            this.customerPricegroupReportToolStripMenuItem.Name = "customerPricegroupReportToolStripMenuItem";
            this.customerPricegroupReportToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.customerPricegroupReportToolStripMenuItem.Text = "Customer Pricegroup Report";
            this.customerPricegroupReportToolStripMenuItem.Click += new System.EventHandler(this.customerPricegroupReportToolStripMenuItem_Click);
            // 
            // quantityPanel
            // 
            this.quantityPanel.Controls.Add(this.label5);
            this.quantityPanel.Controls.Add(this.quantityTb);
            this.quantityPanel.Controls.Add(this.Cancelbtn);
            this.quantityPanel.Controls.Add(this.confirmbtn);
            this.quantityPanel.Enabled = false;
            this.quantityPanel.Location = new System.Drawing.Point(495, 30);
            this.quantityPanel.Name = "quantityPanel";
            this.quantityPanel.Size = new System.Drawing.Size(200, 100);
            this.quantityPanel.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Quantity";
            // 
            // quantityTb
            // 
            this.quantityTb.Location = new System.Drawing.Point(51, 24);
            this.quantityTb.Name = "quantityTb";
            this.quantityTb.Size = new System.Drawing.Size(100, 20);
            this.quantityTb.TabIndex = 2;
            this.quantityTb.Text = "1";
            this.quantityTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.Location = new System.Drawing.Point(102, 65);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(75, 23);
            this.Cancelbtn.TabIndex = 1;
            this.Cancelbtn.Text = "Cancel";
            this.Cancelbtn.UseVisualStyleBackColor = true;
            this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // confirmbtn
            // 
            this.confirmbtn.Location = new System.Drawing.Point(21, 65);
            this.confirmbtn.Name = "confirmbtn";
            this.confirmbtn.Size = new System.Drawing.Size(75, 23);
            this.confirmbtn.TabIndex = 0;
            this.confirmbtn.Text = "Confirm";
            this.confirmbtn.UseVisualStyleBackColor = true;
            this.confirmbtn.Click += new System.EventHandler(this.confirmbtn_Click);
            // 
            // removeCartbtn
            // 
            this.removeCartbtn.Location = new System.Drawing.Point(642, 391);
            this.removeCartbtn.Name = "removeCartbtn";
            this.removeCartbtn.Size = new System.Drawing.Size(104, 25);
            this.removeCartbtn.TabIndex = 13;
            this.removeCartbtn.Text = "Remove from cart";
            this.removeCartbtn.UseVisualStyleBackColor = true;
            this.removeCartbtn.Click += new System.EventHandler(this.removeCartbtn_Click);
            // 
            // printReceiptbtn
            // 
            this.printReceiptbtn.Enabled = false;
            this.printReceiptbtn.Location = new System.Drawing.Point(642, 432);
            this.printReceiptbtn.Name = "printReceiptbtn";
            this.printReceiptbtn.Size = new System.Drawing.Size(104, 25);
            this.printReceiptbtn.TabIndex = 14;
            this.printReceiptbtn.Text = "Print Receipt";
            this.printReceiptbtn.UseVisualStyleBackColor = true;
            this.printReceiptbtn.Click += new System.EventHandler(this.printReceiptbtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(344, 187);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(420, 163);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ItemName";
            this.Column1.HeaderText = "ItemName";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "UOFM";
            this.Column2.HeaderText = "UOFM";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Price";
            this.Column3.HeaderText = "Price";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Quantity";
            this.Column4.HeaderText = "Quantity";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Total";
            this.Column5.HeaderText = "Total";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // totalLbl
            // 
            this.totalLbl.AutoSize = true;
            this.totalLbl.Location = new System.Drawing.Point(431, 370);
            this.totalLbl.Name = "totalLbl";
            this.totalLbl.Size = new System.Drawing.Size(13, 13);
            this.totalLbl.TabIndex = 17;
            this.totalLbl.Text = "0";
            // 
            // cashTb
            // 
            this.cashTb.Location = new System.Drawing.Point(434, 396);
            this.cashTb.Name = "cashTb";
            this.cashTb.Size = new System.Drawing.Size(80, 20);
            this.cashTb.TabIndex = 18;
            this.cashTb.TextChanged += new System.EventHandler(this.cashTb_TextChanged);
            // 
            // changeLbl
            // 
            this.changeLbl.AutoSize = true;
            this.changeLbl.Location = new System.Drawing.Point(431, 435);
            this.changeLbl.Name = "changeLbl";
            this.changeLbl.Size = new System.Drawing.Size(13, 13);
            this.changeLbl.TabIndex = 19;
            this.changeLbl.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(345, 370);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Amount Due";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(345, 403);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Cash";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(345, 433);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Change";
            // 
            // UOFMlist
            // 
            this.UOFMlist.Enabled = false;
            this.UOFMlist.FormattingEnabled = true;
            this.UOFMlist.Location = new System.Drawing.Point(344, 40);
            this.UOFMlist.Name = "UOFMlist";
            this.UOFMlist.Size = new System.Drawing.Size(145, 43);
            this.UOFMlist.TabIndex = 23;
            this.UOFMlist.SelectedIndexChanged += new System.EventHandler(this.UOFMlist_SelectedIndexChanged);
            // 
            // custPanel
            // 
            this.custPanel.Controls.Add(this.conBtn);
            this.custPanel.Controls.Add(this.creditRb);
            this.custPanel.Controls.Add(this.cashRb);
            this.custPanel.Location = new System.Drawing.Point(289, 169);
            this.custPanel.Name = "custPanel";
            this.custPanel.Size = new System.Drawing.Size(190, 87);
            this.custPanel.TabIndex = 24;
            this.custPanel.Visible = false;
            // 
            // conBtn
            // 
            this.conBtn.Location = new System.Drawing.Point(101, 50);
            this.conBtn.Name = "conBtn";
            this.conBtn.Size = new System.Drawing.Size(75, 23);
            this.conBtn.TabIndex = 4;
            this.conBtn.Text = "Confirm";
            this.conBtn.UseVisualStyleBackColor = true;
            this.conBtn.Click += new System.EventHandler(this.conBtn_Click);
            // 
            // creditRb
            // 
            this.creditRb.AutoSize = true;
            this.creditRb.Location = new System.Drawing.Point(114, 17);
            this.creditRb.Name = "creditRb";
            this.creditRb.Size = new System.Drawing.Size(52, 17);
            this.creditRb.TabIndex = 3;
            this.creditRb.TabStop = true;
            this.creditRb.Text = "Credit";
            this.creditRb.UseVisualStyleBackColor = true;
            // 
            // cashRb
            // 
            this.cashRb.AutoSize = true;
            this.cashRb.Location = new System.Drawing.Point(19, 17);
            this.cashRb.Name = "cashRb";
            this.cashRb.Size = new System.Drawing.Size(49, 17);
            this.cashRb.TabIndex = 2;
            this.cashRb.TabStop = true;
            this.cashRb.Text = "Cash";
            this.cashRb.UseVisualStyleBackColor = true;
            // 
            // pricepanel
            // 
            this.pricepanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pricepanel.Controls.Add(this.label6);
            this.pricepanel.Controls.Add(this.prctb);
            this.pricepanel.Controls.Add(this.button1);
            this.pricepanel.Location = new System.Drawing.Point(289, 95);
            this.pricepanel.Name = "pricepanel";
            this.pricepanel.Size = new System.Drawing.Size(190, 87);
            this.pricepanel.TabIndex = 25;
            this.pricepanel.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Please input Desired price";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // prctb
            // 
            this.prctb.Location = new System.Drawing.Point(42, 31);
            this.prctb.Name = "prctb";
            this.prctb.Size = new System.Drawing.Size(100, 20);
            this.prctb.TabIndex = 5;
            this.prctb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // printOptionpanel
            // 
            this.printOptionpanel.Controls.Add(this.button2);
            this.printOptionpanel.Controls.Add(this.savebtn);
            this.printOptionpanel.Controls.Add(this.PnSbtn);
            this.printOptionpanel.Location = new System.Drawing.Point(257, 262);
            this.printOptionpanel.Name = "printOptionpanel";
            this.printOptionpanel.Size = new System.Drawing.Size(267, 100);
            this.printOptionpanel.TabIndex = 26;
            this.printOptionpanel.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(178, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 53);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(97, 24);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 53);
            this.savebtn.TabIndex = 4;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // PnSbtn
            // 
            this.PnSbtn.Location = new System.Drawing.Point(16, 24);
            this.PnSbtn.Name = "PnSbtn";
            this.PnSbtn.Size = new System.Drawing.Size(75, 53);
            this.PnSbtn.TabIndex = 3;
            this.PnSbtn.Text = "Print && Save";
            this.PnSbtn.UseVisualStyleBackColor = true;
            this.PnSbtn.Click += new System.EventHandler(this.PnSbtn_Click);
            // 
            // skinCrafterLight1
            // 
            this.skinCrafterLight1.Skin = DMSoft.Skinset.Skinastic;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 462);
            this.Controls.Add(this.printOptionpanel);
            this.Controls.Add(this.pricepanel);
            this.Controls.Add(this.custPanel);
            this.Controls.Add(this.UOFMlist);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.changeLbl);
            this.Controls.Add(this.cashTb);
            this.Controls.Add(this.totalLbl);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.printReceiptbtn);
            this.Controls.Add(this.removeCartbtn);
            this.Controls.Add(this.quantityPanel);
            this.Controls.Add(this.itemPriceLabel);
            this.Controls.Add(this.itemDescLabel);
            this.Controls.Add(this.itemCodeLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.priceGroupBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.quantityPanel.ResumeLayout(false);
            this.quantityPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.custPanel.ResumeLayout(false);
            this.custPanel.PerformLayout();
            this.pricepanel.ResumeLayout(false);
            this.pricepanel.PerformLayout();
            this.printOptionpanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox itemList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox priceGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label itemCodeLabel;
        private System.Windows.Forms.Label itemDescLabel;
        private System.Windows.Forms.Label itemPriceLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Panel quantityPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox quantityTb;
        private System.Windows.Forms.Button Cancelbtn;
        private System.Windows.Forms.Button confirmbtn;
        private System.Windows.Forms.Button removeCartbtn;
        private System.Windows.Forms.Button printReceiptbtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label totalLbl;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.TextBox cashTb;
        private System.Windows.Forms.Label changeLbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox UOFMlist;
        private System.Windows.Forms.Panel custPanel;
        private System.Windows.Forms.Button conBtn;
        private System.Windows.Forms.RadioButton creditRb;
        private System.Windows.Forms.RadioButton cashRb;
        private System.Windows.Forms.Panel pricepanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox prctb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.Panel printOptionpanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button PnSbtn;
        private System.Windows.Forms.ToolStripMenuItem reportViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerPricegroupReportToolStripMenuItem;
        private DMSoft.SkinCrafterLight skinCrafterLight1;
    }
}

