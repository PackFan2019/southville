namespace StudentAssessment
{
    partial class frmAssessment
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.lblStudentID = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtBatchID = new System.Windows.Forms.TextBox();
            this.lblBatchID = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtSYFrom = new System.Windows.Forms.TextBox();
            this.lblSchoolYear = new System.Windows.Forms.Label();
            this.lblPlan = new System.Windows.Forms.Label();
            this.dtpDocumentDate = new System.Windows.Forms.DateTimePicker();
            this.txtSYTo = new System.Windows.Forms.TextBox();
            this.cboPlan = new System.Windows.Forms.ComboBox();
            this.lblAssessmentNo = new System.Windows.Forms.Label();
            this.txtAssessmentNo = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cboDoctype = new System.Windows.Forms.ToolStripComboBox();
            this.txtCurrencyID = new System.Windows.Forms.TextBox();
            this.lblCurrencyID = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lstItems = new System.Windows.Forms.ListView();
            this.lblTuitionFee = new System.Windows.Forms.Label();
            this.txtTuitionFee = new System.Windows.Forms.TextBox();
            this.txtDirectCosts = new System.Windows.Forms.TextBox();
            this.lblMiscellaneousFees = new System.Windows.Forms.Label();
            this.txtMiscellaneousFees = new System.Windows.Forms.TextBox();
            this.lblDirectCosts = new System.Windows.Forms.Label();
            this.lblAdditionalFees = new System.Windows.Forms.Label();
            this.txtAdditionalFees = new System.Windows.Forms.TextBox();
            this.grpTotals = new System.Windows.Forms.GroupBox();
            this.chkDiscountEnabled = new System.Windows.Forms.CheckBox();
            this.btnSaveReservationFee = new System.Windows.Forms.Button();
            this.txtReservationFee = new System.Windows.Forms.TextBox();
            this.lblReservationFee = new System.Windows.Forms.Label();
            this.txtInstallmentFee = new System.Windows.Forms.TextBox();
            this.btnExpandDiscount = new System.Windows.Forms.Button();
            this.lblInstallmentFee = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.btnExpandNetAmount = new System.Windows.Forms.Button();
            this.lblNetAmountToPay = new System.Windows.Forms.Label();
            this.txtNetAmountToPay = new System.Windows.Forms.TextBox();
            this.lblSelectTemplate = new System.Windows.Forms.Label();
            this.cboTemplate = new System.Windows.Forms.ComboBox();
            this.grpHeader = new System.Windows.Forms.GroupBox();
            this.btnStudentIDLookup = new System.Windows.Forms.Button();
            this.txtItemNo = new System.Windows.Forms.TextBox();
            this.txtItemDescription = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.grpBreakdown = new System.Windows.Forms.GroupBox();
            this.btnSaveItem = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.txtMarkdown = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.lblItemNo = new System.Windows.Forms.Label();
            this.lblItemDescription = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.lblMarkdown = new System.Windows.Forms.Label();
            this.grpRemarks = new System.Windows.Forms.GroupBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.grpTotals.SuspendLayout();
            this.grpHeader.SuspendLayout();
            this.grpBreakdown.SuspendLayout();
            this.grpRemarks.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(11, 37);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(61, 13);
            this.lblStudentID.TabIndex = 2;
            this.lblStudentID.Text = "Student ID:";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(100, 34);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(100, 20);
            this.txtStudentID.TabIndex = 3;
            this.txtStudentID.Leave += new System.EventHandler(this.txtStudentID_Leave);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(100, 58);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(169, 20);
            this.txtName.TabIndex = 6;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(11, 61);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name:";
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(100, 80);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.ReadOnly = true;
            this.txtLevel.Size = new System.Drawing.Size(100, 20);
            this.txtLevel.TabIndex = 8;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(11, 83);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(36, 13);
            this.lblLevel.TabIndex = 7;
            this.lblLevel.Text = "Level:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(11, 105);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Status:";
            // 
            // txtBatchID
            // 
            this.txtBatchID.Location = new System.Drawing.Point(395, 37);
            this.txtBatchID.Name = "txtBatchID";
            this.txtBatchID.Size = new System.Drawing.Size(100, 20);
            this.txtBatchID.TabIndex = 14;
            // 
            // lblBatchID
            // 
            this.lblBatchID.AutoSize = true;
            this.lblBatchID.Location = new System.Drawing.Point(276, 40);
            this.lblBatchID.Name = "lblBatchID";
            this.lblBatchID.Size = new System.Drawing.Size(52, 13);
            this.lblBatchID.TabIndex = 13;
            this.lblBatchID.Text = "Batch ID:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(276, 64);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 15;
            this.lblDate.Text = "Date:";
            // 
            // txtSYFrom
            // 
            this.txtSYFrom.Location = new System.Drawing.Point(395, 83);
            this.txtSYFrom.Name = "txtSYFrom";
            this.txtSYFrom.ReadOnly = true;
            this.txtSYFrom.Size = new System.Drawing.Size(48, 20);
            this.txtSYFrom.TabIndex = 18;
            this.txtSYFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSchoolYear
            // 
            this.lblSchoolYear.AutoSize = true;
            this.lblSchoolYear.Location = new System.Drawing.Point(276, 86);
            this.lblSchoolYear.Name = "lblSchoolYear";
            this.lblSchoolYear.Size = new System.Drawing.Size(68, 13);
            this.lblSchoolYear.TabIndex = 17;
            this.lblSchoolYear.Text = "School Year:";
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(276, 108);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(31, 13);
            this.lblPlan.TabIndex = 20;
            this.lblPlan.Text = "Plan:";
            // 
            // dtpDocumentDate
            // 
            this.dtpDocumentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDocumentDate.Location = new System.Drawing.Point(395, 60);
            this.dtpDocumentDate.Name = "dtpDocumentDate";
            this.dtpDocumentDate.Size = new System.Drawing.Size(100, 20);
            this.dtpDocumentDate.TabIndex = 16;
            this.dtpDocumentDate.ValueChanged += new System.EventHandler(this.dtpDocumentDate_ValueChanged);
            // 
            // txtSYTo
            // 
            this.txtSYTo.Location = new System.Drawing.Point(447, 83);
            this.txtSYTo.Name = "txtSYTo";
            this.txtSYTo.ReadOnly = true;
            this.txtSYTo.Size = new System.Drawing.Size(48, 20);
            this.txtSYTo.TabIndex = 19;
            this.txtSYTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboPlan
            // 
            this.cboPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlan.FormattingEnabled = true;
            this.cboPlan.Location = new System.Drawing.Point(395, 105);
            this.cboPlan.Name = "cboPlan";
            this.cboPlan.Size = new System.Drawing.Size(100, 21);
            this.cboPlan.TabIndex = 21;
            this.cboPlan.SelectedIndexChanged += new System.EventHandler(this.cboPlan_SelectedIndexChanged);
            // 
            // lblAssessmentNo
            // 
            this.lblAssessmentNo.AutoSize = true;
            this.lblAssessmentNo.Location = new System.Drawing.Point(11, 13);
            this.lblAssessmentNo.Name = "lblAssessmentNo";
            this.lblAssessmentNo.Size = new System.Drawing.Size(79, 13);
            this.lblAssessmentNo.TabIndex = 0;
            this.lblAssessmentNo.Text = "Document No.:";
            // 
            // txtAssessmentNo
            // 
            this.txtAssessmentNo.Location = new System.Drawing.Point(100, 10);
            this.txtAssessmentNo.Name = "txtAssessmentNo";
            this.txtAssessmentNo.Size = new System.Drawing.Size(100, 20);
            this.txtAssessmentNo.TabIndex = 1;
            this.txtAssessmentNo.Leave += new System.EventHandler(this.txtAssessmentNo_Leave);
            this.txtAssessmentNo.Enter += new System.EventHandler(this.txtAssessmentNo_Enter);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClear,
            this.toolStripSeparator2,
            this.btnPrint,
            this.toolStripSeparator3,
            this.cboDoctype});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(751, 26);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnClear
            // 
            this.btnClear.AutoSize = false;
            this.btnClear.Image = global::StudentAssessment.Properties.Resources.Toolbar_Clear;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.Text = "&Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // btnPrint
            // 
            this.btnPrint.AutoSize = false;
            this.btnPrint.Image = global::StudentAssessment.Properties.Resources.Toolbar_Print;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(110, 23);
            this.btnPrint.Text = "&Save and Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // cboDoctype
            // 
            this.cboDoctype.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cboDoctype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoctype.Name = "cboDoctype";
            this.cboDoctype.Size = new System.Drawing.Size(121, 26);
            this.cboDoctype.SelectedIndexChanged += new System.EventHandler(this.cboDoctype_SelectedIndexChanged);
            // 
            // txtCurrencyID
            // 
            this.txtCurrencyID.Location = new System.Drawing.Point(395, 13);
            this.txtCurrencyID.Name = "txtCurrencyID";
            this.txtCurrencyID.ReadOnly = true;
            this.txtCurrencyID.Size = new System.Drawing.Size(100, 20);
            this.txtCurrencyID.TabIndex = 12;
            // 
            // lblCurrencyID
            // 
            this.lblCurrencyID.AutoSize = true;
            this.lblCurrencyID.Location = new System.Drawing.Point(276, 16);
            this.lblCurrencyID.Name = "lblCurrencyID";
            this.lblCurrencyID.Size = new System.Drawing.Size(66, 13);
            this.lblCurrencyID.TabIndex = 11;
            this.lblCurrencyID.Text = "Currency ID:";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboStatus.Enabled = false;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(100, 102);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(100, 21);
            this.cboStatus.TabIndex = 10;
            // 
            // lstItems
            // 
            this.lstItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstItems.FullRowSelect = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "lvgTuitionFee";
            listViewGroup2.Header = "ListViewGroup";
            listViewGroup2.Name = "lvgMiscellaneousFees";
            listViewGroup3.Header = "ListViewGroup";
            listViewGroup3.Name = "lvgDirectCosts";
            listViewGroup4.Header = "ListViewGroup";
            listViewGroup4.Name = "lvgAdditionalFees";
            listViewGroup5.Header = "ListViewGroup";
            listViewGroup5.Name = "lvgDiscounts";
            this.lstItems.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5});
            this.lstItems.Location = new System.Drawing.Point(6, 226);
            this.lstItems.MultiSelect = false;
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(505, 290);
            this.lstItems.TabIndex = 13;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            // 
            // lblTuitionFee
            // 
            this.lblTuitionFee.AutoSize = true;
            this.lblTuitionFee.Location = new System.Drawing.Point(12, 22);
            this.lblTuitionFee.Name = "lblTuitionFee";
            this.lblTuitionFee.Size = new System.Drawing.Size(63, 13);
            this.lblTuitionFee.TabIndex = 0;
            this.lblTuitionFee.Text = "Tuition Fee:";
            // 
            // txtTuitionFee
            // 
            this.txtTuitionFee.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTuitionFee.Location = new System.Drawing.Point(101, 19);
            this.txtTuitionFee.Name = "txtTuitionFee";
            this.txtTuitionFee.ReadOnly = true;
            this.txtTuitionFee.Size = new System.Drawing.Size(101, 20);
            this.txtTuitionFee.TabIndex = 1;
            this.txtTuitionFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDirectCosts
            // 
            this.txtDirectCosts.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDirectCosts.Location = new System.Drawing.Point(101, 71);
            this.txtDirectCosts.Name = "txtDirectCosts";
            this.txtDirectCosts.ReadOnly = true;
            this.txtDirectCosts.Size = new System.Drawing.Size(101, 20);
            this.txtDirectCosts.TabIndex = 5;
            this.txtDirectCosts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMiscellaneousFees
            // 
            this.lblMiscellaneousFees.AutoSize = true;
            this.lblMiscellaneousFees.Location = new System.Drawing.Point(12, 39);
            this.lblMiscellaneousFees.Name = "lblMiscellaneousFees";
            this.lblMiscellaneousFees.Size = new System.Drawing.Size(74, 26);
            this.lblMiscellaneousFees.TabIndex = 2;
            this.lblMiscellaneousFees.Text = "Miscellaneous\r\nFees:";
            // 
            // txtMiscellaneousFees
            // 
            this.txtMiscellaneousFees.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiscellaneousFees.Location = new System.Drawing.Point(101, 45);
            this.txtMiscellaneousFees.Name = "txtMiscellaneousFees";
            this.txtMiscellaneousFees.ReadOnly = true;
            this.txtMiscellaneousFees.Size = new System.Drawing.Size(101, 20);
            this.txtMiscellaneousFees.TabIndex = 3;
            this.txtMiscellaneousFees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDirectCosts
            // 
            this.lblDirectCosts.AutoSize = true;
            this.lblDirectCosts.Location = new System.Drawing.Point(12, 74);
            this.lblDirectCosts.Name = "lblDirectCosts";
            this.lblDirectCosts.Size = new System.Drawing.Size(67, 13);
            this.lblDirectCosts.TabIndex = 4;
            this.lblDirectCosts.Text = "Direct Costs:";
            // 
            // lblAdditionalFees
            // 
            this.lblAdditionalFees.AutoSize = true;
            this.lblAdditionalFees.Location = new System.Drawing.Point(12, 100);
            this.lblAdditionalFees.Name = "lblAdditionalFees";
            this.lblAdditionalFees.Size = new System.Drawing.Size(82, 13);
            this.lblAdditionalFees.TabIndex = 6;
            this.lblAdditionalFees.Text = "Additional Fees:\r\n";
            // 
            // txtAdditionalFees
            // 
            this.txtAdditionalFees.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdditionalFees.Location = new System.Drawing.Point(101, 97);
            this.txtAdditionalFees.Name = "txtAdditionalFees";
            this.txtAdditionalFees.ReadOnly = true;
            this.txtAdditionalFees.Size = new System.Drawing.Size(101, 20);
            this.txtAdditionalFees.TabIndex = 7;
            this.txtAdditionalFees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpTotals
            // 
            this.grpTotals.Controls.Add(this.chkDiscountEnabled);
            this.grpTotals.Controls.Add(this.btnSaveReservationFee);
            this.grpTotals.Controls.Add(this.txtReservationFee);
            this.grpTotals.Controls.Add(this.lblReservationFee);
            this.grpTotals.Controls.Add(this.txtInstallmentFee);
            this.grpTotals.Controls.Add(this.btnExpandDiscount);
            this.grpTotals.Controls.Add(this.lblInstallmentFee);
            this.grpTotals.Controls.Add(this.txtDiscount);
            this.grpTotals.Controls.Add(this.txtSubtotal);
            this.grpTotals.Controls.Add(this.lblSubtotal);
            this.grpTotals.Controls.Add(this.btnExpandNetAmount);
            this.grpTotals.Controls.Add(this.lblNetAmountToPay);
            this.grpTotals.Controls.Add(this.txtNetAmountToPay);
            this.grpTotals.Location = new System.Drawing.Point(516, 363);
            this.grpTotals.Name = "grpTotals";
            this.grpTotals.Size = new System.Drawing.Size(230, 153);
            this.grpTotals.TabIndex = 17;
            this.grpTotals.TabStop = false;
            // 
            // chkDiscountEnabled
            // 
            this.chkDiscountEnabled.AutoSize = true;
            this.chkDiscountEnabled.Checked = true;
            this.chkDiscountEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDiscountEnabled.Location = new System.Drawing.Point(24, 44);
            this.chkDiscountEnabled.Name = "chkDiscountEnabled";
            this.chkDiscountEnabled.Size = new System.Drawing.Size(71, 17);
            this.chkDiscountEnabled.TabIndex = 21;
            this.chkDiscountEnabled.Text = "Discount:";
            this.chkDiscountEnabled.UseVisualStyleBackColor = true;
            this.chkDiscountEnabled.CheckedChanged += new System.EventHandler(this.chkDiscountEnabled_CheckedChanged);
            // 
            // btnSaveReservationFee
            // 
            this.btnSaveReservationFee.Enabled = false;
            this.btnSaveReservationFee.Image = global::StudentAssessment.Properties.Resources.Toolbar_Save;
            this.btnSaveReservationFee.Location = new System.Drawing.Point(203, 94);
            this.btnSaveReservationFee.Name = "btnSaveReservationFee";
            this.btnSaveReservationFee.Size = new System.Drawing.Size(21, 23);
            this.btnSaveReservationFee.TabIndex = 20;
            this.btnSaveReservationFee.TabStop = false;
            this.btnSaveReservationFee.UseVisualStyleBackColor = true;
            this.btnSaveReservationFee.Click += new System.EventHandler(this.btnSaveReservationFee_Click);
            // 
            // txtReservationFee
            // 
            this.txtReservationFee.Enabled = false;
            this.txtReservationFee.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReservationFee.Location = new System.Drawing.Point(101, 94);
            this.txtReservationFee.Name = "txtReservationFee";
            this.txtReservationFee.Size = new System.Drawing.Size(101, 20);
            this.txtReservationFee.TabIndex = 11;
            this.txtReservationFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblReservationFee
            // 
            this.lblReservationFee.AutoSize = true;
            this.lblReservationFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReservationFee.Location = new System.Drawing.Point(6, 97);
            this.lblReservationFee.Name = "lblReservationFee";
            this.lblReservationFee.Size = new System.Drawing.Size(88, 13);
            this.lblReservationFee.TabIndex = 10;
            this.lblReservationFee.Text = "Reservation Fee:";
            // 
            // txtInstallmentFee
            // 
            this.txtInstallmentFee.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstallmentFee.Location = new System.Drawing.Point(101, 68);
            this.txtInstallmentFee.Name = "txtInstallmentFee";
            this.txtInstallmentFee.ReadOnly = true;
            this.txtInstallmentFee.Size = new System.Drawing.Size(101, 20);
            this.txtInstallmentFee.TabIndex = 9;
            this.txtInstallmentFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnExpandDiscount
            // 
            this.btnExpandDiscount.Enabled = false;
            this.btnExpandDiscount.Image = global::StudentAssessment.Properties.Resources.Field_Expansion;
            this.btnExpandDiscount.Location = new System.Drawing.Point(203, 41);
            this.btnExpandDiscount.Name = "btnExpandDiscount";
            this.btnExpandDiscount.Size = new System.Drawing.Size(21, 23);
            this.btnExpandDiscount.TabIndex = 4;
            this.btnExpandDiscount.TabStop = false;
            this.btnExpandDiscount.UseVisualStyleBackColor = true;
            this.btnExpandDiscount.Click += new System.EventHandler(this.btnExpandDiscount_Click);
            // 
            // lblInstallmentFee
            // 
            this.lblInstallmentFee.AutoSize = true;
            this.lblInstallmentFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstallmentFee.Location = new System.Drawing.Point(13, 71);
            this.lblInstallmentFee.Name = "lblInstallmentFee";
            this.lblInstallmentFee.Size = new System.Drawing.Size(81, 13);
            this.lblInstallmentFee.TabIndex = 8;
            this.lblInstallmentFee.Text = "Installment Fee:";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(101, 42);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Size = new System.Drawing.Size(101, 20);
            this.txtDiscount.TabIndex = 3;
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubtotal.Location = new System.Drawing.Point(101, 16);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(101, 20);
            this.txtSubtotal.TabIndex = 1;
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(45, 19);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(49, 13);
            this.lblSubtotal.TabIndex = 0;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // btnExpandNetAmount
            // 
            this.btnExpandNetAmount.Enabled = false;
            this.btnExpandNetAmount.Image = global::StudentAssessment.Properties.Resources.Field_Expansion;
            this.btnExpandNetAmount.Location = new System.Drawing.Point(203, 120);
            this.btnExpandNetAmount.Name = "btnExpandNetAmount";
            this.btnExpandNetAmount.Size = new System.Drawing.Size(21, 23);
            this.btnExpandNetAmount.TabIndex = 7;
            this.btnExpandNetAmount.TabStop = false;
            this.btnExpandNetAmount.UseVisualStyleBackColor = true;
            this.btnExpandNetAmount.Click += new System.EventHandler(this.btnExpandNetAmount_Click);
            // 
            // lblNetAmountToPay
            // 
            this.lblNetAmountToPay.AutoSize = true;
            this.lblNetAmountToPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetAmountToPay.Location = new System.Drawing.Point(12, 125);
            this.lblNetAmountToPay.Name = "lblNetAmountToPay";
            this.lblNetAmountToPay.Size = new System.Drawing.Size(86, 13);
            this.lblNetAmountToPay.TabIndex = 5;
            this.lblNetAmountToPay.Text = "Total Amount:";
            this.lblNetAmountToPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNetAmountToPay
            // 
            this.txtNetAmountToPay.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetAmountToPay.Location = new System.Drawing.Point(101, 120);
            this.txtNetAmountToPay.Name = "txtNetAmountToPay";
            this.txtNetAmountToPay.ReadOnly = true;
            this.txtNetAmountToPay.Size = new System.Drawing.Size(101, 20);
            this.txtNetAmountToPay.TabIndex = 6;
            this.txtNetAmountToPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSelectTemplate
            // 
            this.lblSelectTemplate.AutoSize = true;
            this.lblSelectTemplate.Location = new System.Drawing.Point(528, 183);
            this.lblSelectTemplate.Name = "lblSelectTemplate";
            this.lblSelectTemplate.Size = new System.Drawing.Size(54, 13);
            this.lblSelectTemplate.TabIndex = 14;
            this.lblSelectTemplate.Text = "Template:";
            // 
            // cboTemplate
            // 
            this.cboTemplate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTemplate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTemplate.Enabled = false;
            this.cboTemplate.FormattingEnabled = true;
            this.cboTemplate.Location = new System.Drawing.Point(531, 199);
            this.cboTemplate.Name = "cboTemplate";
            this.cboTemplate.Size = new System.Drawing.Size(187, 21);
            this.cboTemplate.TabIndex = 15;
            this.cboTemplate.SelectedIndexChanged += new System.EventHandler(this.cboTemplate_SelectedIndexChanged);
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.txtSYTo);
            this.grpHeader.Controls.Add(this.lblStudentID);
            this.grpHeader.Controls.Add(this.txtStudentID);
            this.grpHeader.Controls.Add(this.lblName);
            this.grpHeader.Controls.Add(this.txtName);
            this.grpHeader.Controls.Add(this.lblLevel);
            this.grpHeader.Controls.Add(this.txtLevel);
            this.grpHeader.Controls.Add(this.lblStatus);
            this.grpHeader.Controls.Add(this.cboStatus);
            this.grpHeader.Controls.Add(this.lblPlan);
            this.grpHeader.Controls.Add(this.txtCurrencyID);
            this.grpHeader.Controls.Add(this.lblSchoolYear);
            this.grpHeader.Controls.Add(this.lblCurrencyID);
            this.grpHeader.Controls.Add(this.txtSYFrom);
            this.grpHeader.Controls.Add(this.lblDate);
            this.grpHeader.Controls.Add(this.txtAssessmentNo);
            this.grpHeader.Controls.Add(this.lblBatchID);
            this.grpHeader.Controls.Add(this.lblAssessmentNo);
            this.grpHeader.Controls.Add(this.txtBatchID);
            this.grpHeader.Controls.Add(this.btnStudentIDLookup);
            this.grpHeader.Controls.Add(this.dtpDocumentDate);
            this.grpHeader.Controls.Add(this.cboPlan);
            this.grpHeader.Location = new System.Drawing.Point(6, 29);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(505, 132);
            this.grpHeader.TabIndex = 0;
            this.grpHeader.TabStop = false;
            // 
            // btnStudentIDLookup
            // 
            this.btnStudentIDLookup.Image = global::StudentAssessment.Properties.Resources.Field_Lookup;
            this.btnStudentIDLookup.Location = new System.Drawing.Point(201, 32);
            this.btnStudentIDLookup.Name = "btnStudentIDLookup";
            this.btnStudentIDLookup.Size = new System.Drawing.Size(21, 23);
            this.btnStudentIDLookup.TabIndex = 4;
            this.btnStudentIDLookup.TabStop = false;
            this.btnStudentIDLookup.UseVisualStyleBackColor = true;
            this.btnStudentIDLookup.Click += new System.EventHandler(this.btnStudentIDLookup_Click);
            // 
            // txtItemNo
            // 
            this.txtItemNo.Location = new System.Drawing.Point(6, 200);
            this.txtItemNo.Name = "txtItemNo";
            this.txtItemNo.ReadOnly = true;
            this.txtItemNo.Size = new System.Drawing.Size(94, 20);
            this.txtItemNo.TabIndex = 1;
            // 
            // txtItemDescription
            // 
            this.txtItemDescription.Location = new System.Drawing.Point(101, 200);
            this.txtItemDescription.Name = "txtItemDescription";
            this.txtItemDescription.Size = new System.Drawing.Size(156, 20);
            this.txtItemDescription.TabIndex = 3;
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(258, 200);
            this.txtQty.MaxLength = 2;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(39, 20);
            this.txtQty.TabIndex = 5;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpBreakdown
            // 
            this.grpBreakdown.Controls.Add(this.txtTuitionFee);
            this.grpBreakdown.Controls.Add(this.txtMiscellaneousFees);
            this.grpBreakdown.Controls.Add(this.txtAdditionalFees);
            this.grpBreakdown.Controls.Add(this.txtDirectCosts);
            this.grpBreakdown.Controls.Add(this.lblAdditionalFees);
            this.grpBreakdown.Controls.Add(this.lblMiscellaneousFees);
            this.grpBreakdown.Controls.Add(this.lblTuitionFee);
            this.grpBreakdown.Controls.Add(this.lblDirectCosts);
            this.grpBreakdown.Location = new System.Drawing.Point(516, 226);
            this.grpBreakdown.Name = "grpBreakdown";
            this.grpBreakdown.Size = new System.Drawing.Size(230, 128);
            this.grpBreakdown.TabIndex = 16;
            this.grpBreakdown.TabStop = false;
            // 
            // btnSaveItem
            // 
            this.btnSaveItem.Enabled = false;
            this.btnSaveItem.Image = global::StudentAssessment.Properties.Resources.Toolbar_Save;
            this.btnSaveItem.Location = new System.Drawing.Point(418, 198);
            this.btnSaveItem.Name = "btnSaveItem";
            this.btnSaveItem.Size = new System.Drawing.Size(21, 23);
            this.btnSaveItem.TabIndex = 10;
            this.btnSaveItem.TabStop = false;
            this.btnSaveItem.UseVisualStyleBackColor = true;
            this.btnSaveItem.Click += new System.EventHandler(this.btnSaveItem_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Enabled = false;
            this.btnAddItem.Image = global::StudentAssessment.Properties.Resources.Field_Lookup;
            this.btnAddItem.Location = new System.Drawing.Point(442, 198);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(21, 23);
            this.btnAddItem.TabIndex = 11;
            this.btnAddItem.TabStop = false;
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Enabled = false;
            this.btnDeleteItem.Image = global::StudentAssessment.Properties.Resources.Field_Delete;
            this.btnDeleteItem.Location = new System.Drawing.Point(466, 198);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(21, 23);
            this.btnDeleteItem.TabIndex = 12;
            this.btnDeleteItem.TabStop = false;
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // txtMarkdown
            // 
            this.txtMarkdown.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarkdown.Location = new System.Drawing.Point(378, 200);
            this.txtMarkdown.MaxLength = 5;
            this.txtMarkdown.Name = "txtMarkdown";
            this.txtMarkdown.Size = new System.Drawing.Size(39, 20);
            this.txtMarkdown.TabIndex = 9;
            this.txtMarkdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitPrice.Location = new System.Drawing.Point(298, 200);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.ReadOnly = true;
            this.txtUnitPrice.Size = new System.Drawing.Size(78, 20);
            this.txtUnitPrice.TabIndex = 7;
            this.txtUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblItemNo
            // 
            this.lblItemNo.AutoSize = true;
            this.lblItemNo.Location = new System.Drawing.Point(6, 181);
            this.lblItemNo.Name = "lblItemNo";
            this.lblItemNo.Size = new System.Drawing.Size(47, 13);
            this.lblItemNo.TabIndex = 0;
            this.lblItemNo.Text = "Item No.";
            // 
            // lblItemDescription
            // 
            this.lblItemDescription.AutoSize = true;
            this.lblItemDescription.Location = new System.Drawing.Point(103, 181);
            this.lblItemDescription.Name = "lblItemDescription";
            this.lblItemDescription.Size = new System.Drawing.Size(83, 13);
            this.lblItemDescription.TabIndex = 2;
            this.lblItemDescription.Text = "Item Description";
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(255, 181);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(23, 13);
            this.lblQty.TabIndex = 4;
            this.lblQty.Text = "Qty";
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Location = new System.Drawing.Point(295, 181);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(53, 13);
            this.lblUnitPrice.TabIndex = 6;
            this.lblUnitPrice.Text = "Unit Price";
            // 
            // lblMarkdown
            // 
            this.lblMarkdown.AutoSize = true;
            this.lblMarkdown.Location = new System.Drawing.Point(375, 168);
            this.lblMarkdown.Name = "lblMarkdown";
            this.lblMarkdown.Size = new System.Drawing.Size(62, 26);
            this.lblMarkdown.TabIndex = 8;
            this.lblMarkdown.Text = "Markdown\r\nPercentage";
            // 
            // grpRemarks
            // 
            this.grpRemarks.Controls.Add(this.lblRemarks);
            this.grpRemarks.Controls.Add(this.txtRemarks);
            this.grpRemarks.Location = new System.Drawing.Point(516, 29);
            this.grpRemarks.Name = "grpRemarks";
            this.grpRemarks.Size = new System.Drawing.Size(230, 132);
            this.grpRemarks.TabIndex = 18;
            this.grpRemarks.TabStop = false;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(6, 11);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(52, 13);
            this.lblRemarks.TabIndex = 22;
            this.lblRemarks.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(7, 32);
            this.txtRemarks.MaxLength = 500;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(216, 92);
            this.txtRemarks.TabIndex = 0;
            // 
            // btnClearAll
            // 
            this.btnClearAll.Enabled = false;
            this.btnClearAll.Image = global::StudentAssessment.Properties.Resources.Toolbar_Clear;
            this.btnClearAll.Location = new System.Drawing.Point(490, 198);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(21, 23);
            this.btnClearAll.TabIndex = 20;
            this.btnClearAll.TabStop = false;
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // frmAssessment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 523);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.grpRemarks);
            this.Controls.Add(this.lblMarkdown);
            this.Controls.Add(this.lblUnitPrice);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.lblItemDescription);
            this.Controls.Add(this.lblItemNo);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.txtMarkdown);
            this.Controls.Add(this.grpBreakdown);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtItemDescription);
            this.Controls.Add(this.txtItemNo);
            this.Controls.Add(this.btnSaveItem);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.cboTemplate);
            this.Controls.Add(this.lblSelectTemplate);
            this.Controls.Add(this.grpTotals);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAssessment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction Entry";
            this.Load += new System.EventHandler(this.frmAssessment_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAssessment_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAssessment_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grpTotals.ResumeLayout(false);
            this.grpTotals.PerformLayout();
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.grpBreakdown.ResumeLayout(false);
            this.grpBreakdown.PerformLayout();
            this.grpRemarks.ResumeLayout(false);
            this.grpRemarks.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtBatchID;
        private System.Windows.Forms.Label lblBatchID;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtSYFrom;
        private System.Windows.Forms.Label lblSchoolYear;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.DateTimePicker dtpDocumentDate;
        private System.Windows.Forms.TextBox txtSYTo;
        private System.Windows.Forms.ComboBox cboPlan;
        private System.Windows.Forms.Button btnStudentIDLookup;
        private System.Windows.Forms.Label lblAssessmentNo;
        private System.Windows.Forms.TextBox txtAssessmentNo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.TextBox txtCurrencyID;
        private System.Windows.Forms.Label lblCurrencyID;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ListView lstItems;
        private System.Windows.Forms.Label lblTuitionFee;
        private System.Windows.Forms.TextBox txtTuitionFee;
        private System.Windows.Forms.TextBox txtDirectCosts;
        private System.Windows.Forms.Label lblMiscellaneousFees;
        private System.Windows.Forms.TextBox txtMiscellaneousFees;
        private System.Windows.Forms.Label lblDirectCosts;
        private System.Windows.Forms.Label lblAdditionalFees;
        private System.Windows.Forms.TextBox txtAdditionalFees;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.GroupBox grpTotals;
        private System.Windows.Forms.Label lblSelectTemplate;
        private System.Windows.Forms.ComboBox cboTemplate;
        private System.Windows.Forms.GroupBox grpHeader;
        private System.Windows.Forms.Button btnSaveItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Button btnExpandDiscount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Button btnExpandNetAmount;
        private System.Windows.Forms.Label lblNetAmountToPay;
        private System.Windows.Forms.TextBox txtNetAmountToPay;
        private System.Windows.Forms.TextBox txtItemNo;
        private System.Windows.Forms.TextBox txtItemDescription;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.GroupBox grpBreakdown;
        private System.Windows.Forms.ToolStripComboBox cboDoctype;
        private System.Windows.Forms.TextBox txtMarkdown;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label lblItemNo;
        private System.Windows.Forms.Label lblItemDescription;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label lblMarkdown;
        private System.Windows.Forms.GroupBox grpRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtInstallmentFee;
        private System.Windows.Forms.Label lblInstallmentFee;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtReservationFee;
        private System.Windows.Forms.Label lblReservationFee;
        private System.Windows.Forms.Button btnSaveReservationFee;
        private System.Windows.Forms.CheckBox chkDiscountEnabled;
        private System.Windows.Forms.Button btnClearAll;
    }
}

