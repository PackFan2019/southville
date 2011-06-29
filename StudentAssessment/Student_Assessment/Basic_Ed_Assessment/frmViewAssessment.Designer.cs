namespace StudentAssessment
{
    partial class frmViewAssessment
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
            this.grpHeader = new System.Windows.Forms.GroupBox();
            this.txtSYTo = new System.Windows.Forms.TextBox();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.txtCurrencyID = new System.Windows.Forms.TextBox();
            this.lblSchoolYear = new System.Windows.Forms.Label();
            this.lblCurrencyID = new System.Windows.Forms.Label();
            this.txtSYFrom = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtAssessmentNo = new System.Windows.Forms.TextBox();
            this.lblBatchID = new System.Windows.Forms.Label();
            this.lblAssessmentNo = new System.Windows.Forms.Label();
            this.txtBatchID = new System.Windows.Forms.TextBox();
            this.dtpDocumentDate = new System.Windows.Forms.DateTimePicker();
            this.grpTotals = new System.Windows.Forms.GroupBox();
            this.btnExpandDiscount = new System.Windows.Forms.Button();
            this.btnExpandNetAmount = new System.Windows.Forms.Button();
            this.txtReservationFee = new System.Windows.Forms.TextBox();
            this.lblReservationFee = new System.Windows.Forms.Label();
            this.txtInstallmentFee = new System.Windows.Forms.TextBox();
            this.lblInstallmentFee = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblNetAmountToPay = new System.Windows.Forms.Label();
            this.txtNetAmountToPay = new System.Windows.Forms.TextBox();
            this.txtAdditionalFees = new System.Windows.Forms.TextBox();
            this.lblAdditionalFees = new System.Windows.Forms.Label();
            this.txtMiscellaneousFees = new System.Windows.Forms.TextBox();
            this.lblDirectCosts = new System.Windows.Forms.Label();
            this.lblMiscellaneousFees = new System.Windows.Forms.Label();
            this.txtDirectCosts = new System.Windows.Forms.TextBox();
            this.grpBreakdown = new System.Windows.Forms.GroupBox();
            this.txtTuitionFee = new System.Windows.Forms.TextBox();
            this.lblTuitionFee = new System.Windows.Forms.Label();
            this.lstItems = new System.Windows.Forms.ListView();
            this.cboDoctype = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOK = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.grpRemarks = new System.Windows.Forms.GroupBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.grpHeader.SuspendLayout();
            this.grpTotals.SuspendLayout();
            this.grpBreakdown.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.grpRemarks.SuspendLayout();
            this.SuspendLayout();
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
            this.grpHeader.Controls.Add(this.txtCurrencyID);
            this.grpHeader.Controls.Add(this.lblSchoolYear);
            this.grpHeader.Controls.Add(this.lblCurrencyID);
            this.grpHeader.Controls.Add(this.txtSYFrom);
            this.grpHeader.Controls.Add(this.lblDate);
            this.grpHeader.Controls.Add(this.txtAssessmentNo);
            this.grpHeader.Controls.Add(this.lblBatchID);
            this.grpHeader.Controls.Add(this.lblAssessmentNo);
            this.grpHeader.Controls.Add(this.txtBatchID);
            this.grpHeader.Controls.Add(this.dtpDocumentDate);
            this.grpHeader.Location = new System.Drawing.Point(4, 32);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(505, 110);
            this.grpHeader.TabIndex = 59;
            this.grpHeader.TabStop = false;
            // 
            // txtSYTo
            // 
            this.txtSYTo.Location = new System.Drawing.Point(447, 80);
            this.txtSYTo.Name = "txtSYTo";
            this.txtSYTo.ReadOnly = true;
            this.txtSYTo.Size = new System.Drawing.Size(48, 20);
            this.txtSYTo.TabIndex = 18;
            this.txtSYTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.txtStudentID.ReadOnly = true;
            this.txtStudentID.Size = new System.Drawing.Size(100, 20);
            this.txtStudentID.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(11, 61);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(100, 58);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(169, 20);
            this.txtName.TabIndex = 5;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(11, 83);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(36, 13);
            this.lblLevel.TabIndex = 6;
            this.lblLevel.Text = "Level:";
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(100, 80);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.ReadOnly = true;
            this.txtLevel.Size = new System.Drawing.Size(100, 20);
            this.txtLevel.TabIndex = 7;
            // 
            // txtCurrencyID
            // 
            this.txtCurrencyID.Location = new System.Drawing.Point(395, 10);
            this.txtCurrencyID.Name = "txtCurrencyID";
            this.txtCurrencyID.ReadOnly = true;
            this.txtCurrencyID.Size = new System.Drawing.Size(100, 20);
            this.txtCurrencyID.TabIndex = 11;
            // 
            // lblSchoolYear
            // 
            this.lblSchoolYear.AutoSize = true;
            this.lblSchoolYear.Location = new System.Drawing.Point(276, 83);
            this.lblSchoolYear.Name = "lblSchoolYear";
            this.lblSchoolYear.Size = new System.Drawing.Size(68, 13);
            this.lblSchoolYear.TabIndex = 16;
            this.lblSchoolYear.Text = "School Year:";
            // 
            // lblCurrencyID
            // 
            this.lblCurrencyID.AutoSize = true;
            this.lblCurrencyID.Location = new System.Drawing.Point(276, 13);
            this.lblCurrencyID.Name = "lblCurrencyID";
            this.lblCurrencyID.Size = new System.Drawing.Size(66, 13);
            this.lblCurrencyID.TabIndex = 10;
            this.lblCurrencyID.Text = "Currency ID:";
            // 
            // txtSYFrom
            // 
            this.txtSYFrom.Location = new System.Drawing.Point(395, 80);
            this.txtSYFrom.Name = "txtSYFrom";
            this.txtSYFrom.ReadOnly = true;
            this.txtSYFrom.Size = new System.Drawing.Size(48, 20);
            this.txtSYFrom.TabIndex = 17;
            this.txtSYFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(276, 61);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 14;
            this.lblDate.Text = "Date:";
            // 
            // txtAssessmentNo
            // 
            this.txtAssessmentNo.Location = new System.Drawing.Point(100, 10);
            this.txtAssessmentNo.Name = "txtAssessmentNo";
            this.txtAssessmentNo.ReadOnly = true;
            this.txtAssessmentNo.Size = new System.Drawing.Size(100, 20);
            this.txtAssessmentNo.TabIndex = 1;
            // 
            // lblBatchID
            // 
            this.lblBatchID.AutoSize = true;
            this.lblBatchID.Location = new System.Drawing.Point(276, 37);
            this.lblBatchID.Name = "lblBatchID";
            this.lblBatchID.Size = new System.Drawing.Size(52, 13);
            this.lblBatchID.TabIndex = 12;
            this.lblBatchID.Text = "Batch ID:";
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
            // txtBatchID
            // 
            this.txtBatchID.Location = new System.Drawing.Point(395, 34);
            this.txtBatchID.Name = "txtBatchID";
            this.txtBatchID.ReadOnly = true;
            this.txtBatchID.Size = new System.Drawing.Size(100, 20);
            this.txtBatchID.TabIndex = 13;
            // 
            // dtpDocumentDate
            // 
            this.dtpDocumentDate.Enabled = false;
            this.dtpDocumentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDocumentDate.Location = new System.Drawing.Point(395, 57);
            this.dtpDocumentDate.Name = "dtpDocumentDate";
            this.dtpDocumentDate.Size = new System.Drawing.Size(100, 20);
            this.dtpDocumentDate.TabIndex = 15;
            // 
            // grpTotals
            // 
            this.grpTotals.Controls.Add(this.btnExpandDiscount);
            this.grpTotals.Controls.Add(this.btnExpandNetAmount);
            this.grpTotals.Controls.Add(this.txtReservationFee);
            this.grpTotals.Controls.Add(this.lblReservationFee);
            this.grpTotals.Controls.Add(this.txtInstallmentFee);
            this.grpTotals.Controls.Add(this.lblInstallmentFee);
            this.grpTotals.Controls.Add(this.txtDiscount);
            this.grpTotals.Controls.Add(this.txtSubtotal);
            this.grpTotals.Controls.Add(this.lblSubtotal);
            this.grpTotals.Controls.Add(this.lblDiscount);
            this.grpTotals.Controls.Add(this.lblNetAmountToPay);
            this.grpTotals.Controls.Add(this.txtNetAmountToPay);
            this.grpTotals.Location = new System.Drawing.Point(517, 285);
            this.grpTotals.Name = "grpTotals";
            this.grpTotals.Size = new System.Drawing.Size(230, 153);
            this.grpTotals.TabIndex = 56;
            this.grpTotals.TabStop = false;
            // 
            // btnExpandDiscount
            // 
            this.btnExpandDiscount.Image = global::StudentAssessment.Properties.Resources.Field_Expansion;
            this.btnExpandDiscount.Location = new System.Drawing.Point(203, 45);
            this.btnExpandDiscount.Name = "btnExpandDiscount";
            this.btnExpandDiscount.Size = new System.Drawing.Size(21, 23);
            this.btnExpandDiscount.TabIndex = 52;
            this.btnExpandDiscount.TabStop = false;
            this.btnExpandDiscount.UseVisualStyleBackColor = true;
            this.btnExpandDiscount.Click += new System.EventHandler(this.btnExpandDiscount_Click);
            // 
            // btnExpandNetAmount
            // 
            this.btnExpandNetAmount.Image = global::StudentAssessment.Properties.Resources.Field_Expansion;
            this.btnExpandNetAmount.Location = new System.Drawing.Point(203, 124);
            this.btnExpandNetAmount.Name = "btnExpandNetAmount";
            this.btnExpandNetAmount.Size = new System.Drawing.Size(21, 23);
            this.btnExpandNetAmount.TabIndex = 53;
            this.btnExpandNetAmount.TabStop = false;
            this.btnExpandNetAmount.UseVisualStyleBackColor = true;
            this.btnExpandNetAmount.Click += new System.EventHandler(this.btnExpandNetAmount_Click);
            // 
            // txtReservationFee
            // 
            this.txtReservationFee.Enabled = false;
            this.txtReservationFee.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReservationFee.Location = new System.Drawing.Point(101, 99);
            this.txtReservationFee.Name = "txtReservationFee";
            this.txtReservationFee.ReadOnly = true;
            this.txtReservationFee.Size = new System.Drawing.Size(101, 20);
            this.txtReservationFee.TabIndex = 51;
            this.txtReservationFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblReservationFee
            // 
            this.lblReservationFee.AutoSize = true;
            this.lblReservationFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReservationFee.Location = new System.Drawing.Point(6, 102);
            this.lblReservationFee.Name = "lblReservationFee";
            this.lblReservationFee.Size = new System.Drawing.Size(88, 13);
            this.lblReservationFee.TabIndex = 50;
            this.lblReservationFee.Text = "Reservation Fee:";
            // 
            // txtInstallmentFee
            // 
            this.txtInstallmentFee.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstallmentFee.Location = new System.Drawing.Point(101, 73);
            this.txtInstallmentFee.Name = "txtInstallmentFee";
            this.txtInstallmentFee.ReadOnly = true;
            this.txtInstallmentFee.Size = new System.Drawing.Size(101, 20);
            this.txtInstallmentFee.TabIndex = 49;
            this.txtInstallmentFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblInstallmentFee
            // 
            this.lblInstallmentFee.AutoSize = true;
            this.lblInstallmentFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstallmentFee.Location = new System.Drawing.Point(13, 76);
            this.lblInstallmentFee.Name = "lblInstallmentFee";
            this.lblInstallmentFee.Size = new System.Drawing.Size(81, 13);
            this.lblInstallmentFee.TabIndex = 48;
            this.lblInstallmentFee.Text = "Installment Fee:";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(101, 47);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Size = new System.Drawing.Size(101, 20);
            this.txtDiscount.TabIndex = 44;
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubtotal.Location = new System.Drawing.Point(101, 21);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(101, 20);
            this.txtSubtotal.TabIndex = 42;
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(45, 24);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(49, 13);
            this.lblSubtotal.TabIndex = 43;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(42, 50);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(52, 13);
            this.lblDiscount.TabIndex = 45;
            this.lblDiscount.Text = "Discount:";
            // 
            // lblNetAmountToPay
            // 
            this.lblNetAmountToPay.AutoSize = true;
            this.lblNetAmountToPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetAmountToPay.Location = new System.Drawing.Point(8, 130);
            this.lblNetAmountToPay.Name = "lblNetAmountToPay";
            this.lblNetAmountToPay.Size = new System.Drawing.Size(86, 13);
            this.lblNetAmountToPay.TabIndex = 47;
            this.lblNetAmountToPay.Text = "Total Amount:";
            this.lblNetAmountToPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNetAmountToPay
            // 
            this.txtNetAmountToPay.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetAmountToPay.Location = new System.Drawing.Point(101, 125);
            this.txtNetAmountToPay.Name = "txtNetAmountToPay";
            this.txtNetAmountToPay.ReadOnly = true;
            this.txtNetAmountToPay.Size = new System.Drawing.Size(101, 20);
            this.txtNetAmountToPay.TabIndex = 46;
            this.txtNetAmountToPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAdditionalFees
            // 
            this.txtAdditionalFees.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdditionalFees.Location = new System.Drawing.Point(101, 97);
            this.txtAdditionalFees.Name = "txtAdditionalFees";
            this.txtAdditionalFees.ReadOnly = true;
            this.txtAdditionalFees.Size = new System.Drawing.Size(101, 20);
            this.txtAdditionalFees.TabIndex = 32;
            this.txtAdditionalFees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAdditionalFees
            // 
            this.lblAdditionalFees.AutoSize = true;
            this.lblAdditionalFees.Location = new System.Drawing.Point(12, 100);
            this.lblAdditionalFees.Name = "lblAdditionalFees";
            this.lblAdditionalFees.Size = new System.Drawing.Size(82, 13);
            this.lblAdditionalFees.TabIndex = 33;
            this.lblAdditionalFees.Text = "Additional Fees:\r\n";
            // 
            // txtMiscellaneousFees
            // 
            this.txtMiscellaneousFees.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiscellaneousFees.Location = new System.Drawing.Point(101, 45);
            this.txtMiscellaneousFees.Name = "txtMiscellaneousFees";
            this.txtMiscellaneousFees.ReadOnly = true;
            this.txtMiscellaneousFees.Size = new System.Drawing.Size(101, 20);
            this.txtMiscellaneousFees.TabIndex = 31;
            this.txtMiscellaneousFees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDirectCosts
            // 
            this.lblDirectCosts.AutoSize = true;
            this.lblDirectCosts.Location = new System.Drawing.Point(12, 74);
            this.lblDirectCosts.Name = "lblDirectCosts";
            this.lblDirectCosts.Size = new System.Drawing.Size(67, 13);
            this.lblDirectCosts.TabIndex = 30;
            this.lblDirectCosts.Text = "Direct Costs:";
            // 
            // lblMiscellaneousFees
            // 
            this.lblMiscellaneousFees.AutoSize = true;
            this.lblMiscellaneousFees.Location = new System.Drawing.Point(12, 39);
            this.lblMiscellaneousFees.Name = "lblMiscellaneousFees";
            this.lblMiscellaneousFees.Size = new System.Drawing.Size(74, 26);
            this.lblMiscellaneousFees.TabIndex = 28;
            this.lblMiscellaneousFees.Text = "Miscellaneous\r\nFees:";
            // 
            // txtDirectCosts
            // 
            this.txtDirectCosts.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDirectCosts.Location = new System.Drawing.Point(101, 71);
            this.txtDirectCosts.Name = "txtDirectCosts";
            this.txtDirectCosts.ReadOnly = true;
            this.txtDirectCosts.Size = new System.Drawing.Size(101, 20);
            this.txtDirectCosts.TabIndex = 29;
            this.txtDirectCosts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.grpBreakdown.Location = new System.Drawing.Point(517, 148);
            this.grpBreakdown.Name = "grpBreakdown";
            this.grpBreakdown.Size = new System.Drawing.Size(230, 128);
            this.grpBreakdown.TabIndex = 63;
            this.grpBreakdown.TabStop = false;
            // 
            // txtTuitionFee
            // 
            this.txtTuitionFee.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTuitionFee.Location = new System.Drawing.Point(101, 19);
            this.txtTuitionFee.Name = "txtTuitionFee";
            this.txtTuitionFee.ReadOnly = true;
            this.txtTuitionFee.Size = new System.Drawing.Size(101, 20);
            this.txtTuitionFee.TabIndex = 27;
            this.txtTuitionFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTuitionFee
            // 
            this.lblTuitionFee.AutoSize = true;
            this.lblTuitionFee.Location = new System.Drawing.Point(12, 22);
            this.lblTuitionFee.Name = "lblTuitionFee";
            this.lblTuitionFee.Size = new System.Drawing.Size(63, 13);
            this.lblTuitionFee.TabIndex = 26;
            this.lblTuitionFee.Text = "Tuition Fee:";
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
            this.lstItems.Location = new System.Drawing.Point(4, 148);
            this.lstItems.MultiSelect = false;
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(505, 293);
            this.lstItems.TabIndex = 53;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            // 
            // cboDoctype
            // 
            this.cboDoctype.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cboDoctype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoctype.Enabled = false;
            this.cboDoctype.Name = "cboDoctype";
            this.cboDoctype.Size = new System.Drawing.Size(121, 26);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOK,
            this.toolStripSeparator2,
            this.btnPrint,
            this.toolStripSeparator3,
            this.cboDoctype});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(752, 26);
            this.toolStrip1.TabIndex = 52;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = false;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Text = "&OK";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
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
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.Text = "&Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // grpRemarks
            // 
            this.grpRemarks.Controls.Add(this.lblRemarks);
            this.grpRemarks.Controls.Add(this.txtRemarks);
            this.grpRemarks.Location = new System.Drawing.Point(516, 32);
            this.grpRemarks.Name = "grpRemarks";
            this.grpRemarks.Size = new System.Drawing.Size(231, 110);
            this.grpRemarks.TabIndex = 64;
            this.grpRemarks.TabStop = false;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(6, 10);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(52, 13);
            this.lblRemarks.TabIndex = 23;
            this.lblRemarks.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(7, 26);
            this.txtRemarks.MaxLength = 500;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ReadOnly = true;
            this.txtRemarks.Size = new System.Drawing.Size(217, 78);
            this.txtRemarks.TabIndex = 0;
            // 
            // frmViewAssessment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 446);
            this.Controls.Add(this.grpRemarks);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.grpTotals);
            this.Controls.Add(this.grpBreakdown);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmViewAssessment";
            this.Text = "Transaction Inquiry Zoom";
            this.Load += new System.EventHandler(this.frmViewAssessment_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmViewAssessment_FormClosing);
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.grpTotals.ResumeLayout(false);
            this.grpTotals.PerformLayout();
            this.grpBreakdown.ResumeLayout(false);
            this.grpBreakdown.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grpRemarks.ResumeLayout(false);
            this.grpRemarks.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpHeader;
        private System.Windows.Forms.TextBox txtSYTo;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.TextBox txtCurrencyID;
        private System.Windows.Forms.Label lblSchoolYear;
        private System.Windows.Forms.Label lblCurrencyID;
        private System.Windows.Forms.TextBox txtSYFrom;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtAssessmentNo;
        private System.Windows.Forms.Label lblBatchID;
        private System.Windows.Forms.Label lblAssessmentNo;
        private System.Windows.Forms.TextBox txtBatchID;
        private System.Windows.Forms.DateTimePicker dtpDocumentDate;
        private System.Windows.Forms.GroupBox grpTotals;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblNetAmountToPay;
        private System.Windows.Forms.TextBox txtNetAmountToPay;
        private System.Windows.Forms.TextBox txtAdditionalFees;
        private System.Windows.Forms.Label lblAdditionalFees;
        private System.Windows.Forms.TextBox txtMiscellaneousFees;
        private System.Windows.Forms.Label lblDirectCosts;
        private System.Windows.Forms.Label lblMiscellaneousFees;
        private System.Windows.Forms.TextBox txtDirectCosts;
        private System.Windows.Forms.GroupBox grpBreakdown;
        private System.Windows.Forms.TextBox txtTuitionFee;
        private System.Windows.Forms.Label lblTuitionFee;
        private System.Windows.Forms.ListView lstItems;
        private System.Windows.Forms.ToolStripComboBox cboDoctype;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnOK;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.GroupBox grpRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtInstallmentFee;
        private System.Windows.Forms.Label lblInstallmentFee;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtReservationFee;
        private System.Windows.Forms.Label lblReservationFee;
        private System.Windows.Forms.Button btnExpandDiscount;
        private System.Windows.Forms.Button btnExpandNetAmount;
    }
}