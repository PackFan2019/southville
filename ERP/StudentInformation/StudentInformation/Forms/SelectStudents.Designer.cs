namespace StudentInformation.Forms
{
    partial class SelectStudents
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OfficiallyEnrolled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Section = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Religion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateEnrolled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.searchByLastSchoolAttcb = new System.Windows.Forms.ComboBox();
            this.eXT00101BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sISCDataSet = new StudentInformation.SISCDataSet();
            this.label9 = new System.Windows.Forms.Label();
            this.searchBystudNameTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.searchBySectioncb = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.searchByLevelcb = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.searchByStudClasscb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.searchByEnrollStatcb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.searchByStudentStatcb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.searchByTypecb = new System.Windows.Forms.ComboBox();
            this.eXT00101TableAdapter = new StudentInformation.SISCDataSetTableAdapters.EXT00101TableAdapter();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.CSVImportbtn = new System.Windows.Forms.Button();
            this.massUpdateBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetStudents = new StudentInformation.Datasets.DataSetStudents();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eXT00101BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sISCDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentID,
            this.LastName,
            this.FirstName,
            this.Birthday,
            this.Type,
            this.StudentStatus,
            this.OfficiallyEnrolled,
            this.CustomerClass,
            this.EmailAddress,
            this.Level,
            this.Section,
            this.Address,
            this.Nationality,
            this.Religion,
            this.DateEnrolled});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(16, 15);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(950, 658);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // StudentID
            // 
            this.StudentID.DataPropertyName = "CustomerID";
            this.StudentID.HeaderText = "Student ID";
            this.StudentID.Name = "StudentID";
            this.StudentID.ReadOnly = true;
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "LastName";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "FirstName";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // Birthday
            // 
            this.Birthday.DataPropertyName = "Birthday";
            dataGridViewCellStyle3.Format = "D";
            dataGridViewCellStyle3.NullValue = null;
            this.Birthday.DefaultCellStyle = dataGridViewCellStyle3;
            this.Birthday.HeaderText = "Birthday";
            this.Birthday.Name = "Birthday";
            this.Birthday.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // StudentStatus
            // 
            this.StudentStatus.DataPropertyName = "StudentStatus";
            this.StudentStatus.HeaderText = "Status";
            this.StudentStatus.Name = "StudentStatus";
            this.StudentStatus.ReadOnly = true;
            // 
            // OfficiallyEnrolled
            // 
            this.OfficiallyEnrolled.DataPropertyName = "OfficiallyEnrolled";
            this.OfficiallyEnrolled.HeaderText = "Enrollment Status";
            this.OfficiallyEnrolled.Name = "OfficiallyEnrolled";
            this.OfficiallyEnrolled.ReadOnly = true;
            // 
            // CustomerClass
            // 
            this.CustomerClass.DataPropertyName = "CustomerClass";
            this.CustomerClass.HeaderText = "Student Class";
            this.CustomerClass.Name = "CustomerClass";
            this.CustomerClass.ReadOnly = true;
            // 
            // EmailAddress
            // 
            this.EmailAddress.DataPropertyName = "EmailAddress";
            this.EmailAddress.HeaderText = "Email";
            this.EmailAddress.Name = "EmailAddress";
            this.EmailAddress.ReadOnly = true;
            // 
            // Level
            // 
            this.Level.DataPropertyName = "Level";
            this.Level.HeaderText = "Level";
            this.Level.Name = "Level";
            this.Level.ReadOnly = true;
            // 
            // Section
            // 
            this.Section.DataPropertyName = "Section";
            this.Section.HeaderText = "Section";
            this.Section.Name = "Section";
            this.Section.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "AddressString";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // Nationality
            // 
            this.Nationality.DataPropertyName = "Nationality";
            this.Nationality.HeaderText = "Nationality";
            this.Nationality.Name = "Nationality";
            this.Nationality.ReadOnly = true;
            // 
            // Religion
            // 
            this.Religion.DataPropertyName = "Religion";
            this.Religion.HeaderText = "Religion";
            this.Religion.Name = "Religion";
            this.Religion.ReadOnly = true;
            // 
            // DateEnrolled
            // 
            this.DateEnrolled.DataPropertyName = "LastEnrolledDate";
            this.DateEnrolled.HeaderText = "Date Enrolled";
            this.DateEnrolled.Name = "DateEnrolled";
            this.DateEnrolled.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 678);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current selected student:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.searchByLastSchoolAttcb);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.searchBystudNameTb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.searchBySectioncb);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.searchByLevelcb);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.searchByStudClasscb);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.searchByEnrollStatcb);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.searchByStudentStatcb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.searchByTypecb);
            this.groupBox1.Location = new System.Drawing.Point(970, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(201, 581);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // searchByLastSchoolAttcb
            // 
            this.searchByLastSchoolAttcb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchByLastSchoolAttcb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.eXT00101BindingSource, "STRGA255", true));
            this.searchByLastSchoolAttcb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchByLastSchoolAttcb.DropDownWidth = 250;
            this.searchByLastSchoolAttcb.FormattingEnabled = true;
            this.searchByLastSchoolAttcb.Location = new System.Drawing.Point(19, 125);
            this.searchByLastSchoolAttcb.Margin = new System.Windows.Forms.Padding(4);
            this.searchByLastSchoolAttcb.Name = "searchByLastSchoolAttcb";
            this.searchByLastSchoolAttcb.Size = new System.Drawing.Size(160, 24);
            this.searchByLastSchoolAttcb.Sorted = true;
            this.searchByLastSchoolAttcb.TabIndex = 18;
            this.searchByLastSchoolAttcb.SelectedIndexChanged += new System.EventHandler(this.searchByLastSchoolAttcb_SelectedIndexChanged);
            // 
            // eXT00101BindingSource
            // 
            this.eXT00101BindingSource.DataMember = "EXT00101";
            this.eXT00101BindingSource.DataSource = this.sISCDataSet;
            // 
            // sISCDataSet
            // 
            this.sISCDataSet.DataSetName = "SISCDataSet";
            this.sISCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 94);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Last School Attended";
            // 
            // searchBystudNameTb
            // 
            this.searchBystudNameTb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBystudNameTb.Location = new System.Drawing.Point(20, 54);
            this.searchBystudNameTb.Margin = new System.Windows.Forms.Padding(4);
            this.searchBystudNameTb.Name = "searchBystudNameTb";
            this.searchBystudNameTb.Size = new System.Drawing.Size(157, 22);
            this.searchBystudNameTb.TabIndex = 16;
            this.searchBystudNameTb.TextChanged += new System.EventHandler(this.studNameTb_TextChanged);
            this.searchBystudNameTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBystudNameTb_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Student Name";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 508);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Section";
            // 
            // searchBySectioncb
            // 
            this.searchBySectioncb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBySectioncb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchBySectioncb.FormattingEnabled = true;
            this.searchBySectioncb.Location = new System.Drawing.Point(20, 538);
            this.searchBySectioncb.Margin = new System.Windows.Forms.Padding(4);
            this.searchBySectioncb.Name = "searchBySectioncb";
            this.searchBySectioncb.Size = new System.Drawing.Size(160, 24);
            this.searchBySectioncb.Sorted = true;
            this.searchBySectioncb.TabIndex = 12;
            this.searchBySectioncb.SelectedIndexChanged += new System.EventHandler(this.searchBySectioncb_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 448);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Level";
            // 
            // searchByLevelcb
            // 
            this.searchByLevelcb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchByLevelcb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchByLevelcb.FormattingEnabled = true;
            this.searchByLevelcb.Location = new System.Drawing.Point(20, 469);
            this.searchByLevelcb.Margin = new System.Windows.Forms.Padding(4);
            this.searchByLevelcb.Name = "searchByLevelcb";
            this.searchByLevelcb.Size = new System.Drawing.Size(160, 24);
            this.searchByLevelcb.TabIndex = 10;
            this.searchByLevelcb.SelectedIndexChanged += new System.EventHandler(this.searchByLevelcb_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 370);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Student Class";
            // 
            // searchByStudClasscb
            // 
            this.searchByStudClasscb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchByStudClasscb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchByStudClasscb.FormattingEnabled = true;
            this.searchByStudClasscb.Items.AddRange(new object[] {
            "Student",
            "College_Student",
            "All"});
            this.searchByStudClasscb.Location = new System.Drawing.Point(20, 400);
            this.searchByStudClasscb.Margin = new System.Windows.Forms.Padding(4);
            this.searchByStudClasscb.Name = "searchByStudClasscb";
            this.searchByStudClasscb.Size = new System.Drawing.Size(160, 24);
            this.searchByStudClasscb.TabIndex = 8;
            this.searchByStudClasscb.SelectedIndexChanged += new System.EventHandler(this.searchByStudClasscb_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 301);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Enrollment Status";
            // 
            // searchByEnrollStatcb
            // 
            this.searchByEnrollStatcb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchByEnrollStatcb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchByEnrollStatcb.FormattingEnabled = true;
            this.searchByEnrollStatcb.Items.AddRange(new object[] {
            "Enrolled",
            "Assessed",
            "Not Enrolled",
            "Not Applicable",
            "All"});
            this.searchByEnrollStatcb.Location = new System.Drawing.Point(20, 331);
            this.searchByEnrollStatcb.Margin = new System.Windows.Forms.Padding(4);
            this.searchByEnrollStatcb.Name = "searchByEnrollStatcb";
            this.searchByEnrollStatcb.Size = new System.Drawing.Size(160, 24);
            this.searchByEnrollStatcb.TabIndex = 6;
            this.searchByEnrollStatcb.SelectedIndexChanged += new System.EventHandler(this.searchByEnrollStatcb_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 232);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Student Status";
            // 
            // searchByStudentStatcb
            // 
            this.searchByStudentStatcb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchByStudentStatcb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchByStudentStatcb.FormattingEnabled = true;
            this.searchByStudentStatcb.Items.AddRange(new object[] {
            "New student",
            "Old student",
            "Returning",
            "Not applicable",
            "All"});
            this.searchByStudentStatcb.Location = new System.Drawing.Point(20, 262);
            this.searchByStudentStatcb.Margin = new System.Windows.Forms.Padding(4);
            this.searchByStudentStatcb.Name = "searchByStudentStatcb";
            this.searchByStudentStatcb.Size = new System.Drawing.Size(160, 24);
            this.searchByStudentStatcb.TabIndex = 4;
            this.searchByStudentStatcb.SelectedIndexChanged += new System.EventHandler(this.searchByStudentStatcb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 163);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Type";
            // 
            // searchByTypecb
            // 
            this.searchByTypecb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchByTypecb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchByTypecb.FormattingEnabled = true;
            this.searchByTypecb.Items.AddRange(new object[] {
            "Basic Education",
            "International Baccal",
            "College",
            "Innove",
            "Other",
            "Not applicable",
            "All"});
            this.searchByTypecb.Location = new System.Drawing.Point(20, 193);
            this.searchByTypecb.Margin = new System.Windows.Forms.Padding(4);
            this.searchByTypecb.Name = "searchByTypecb";
            this.searchByTypecb.Size = new System.Drawing.Size(160, 24);
            this.searchByTypecb.TabIndex = 2;
            this.searchByTypecb.SelectedIndexChanged += new System.EventHandler(this.searchByTypecb_SelectedIndexChanged);
            // 
            // eXT00101TableAdapter
            // 
            this.eXT00101TableAdapter.ClearBeforeFill = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Image = global::StudentInformation.Properties.Resources.cancel;
            this.cancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelBtn.Location = new System.Drawing.Point(869, 687);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(97, 28);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.printBtn.Image = global::StudentInformation.Properties.Resources.print;
            this.printBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.printBtn.Location = new System.Drawing.Point(1008, 687);
            this.printBtn.Margin = new System.Windows.Forms.Padding(4);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(109, 28);
            this.printBtn.TabIndex = 8;
            this.printBtn.Text = "Print Letter";
            this.printBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // CSVImportbtn
            // 
            this.CSVImportbtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CSVImportbtn.Image = global::StudentInformation.Properties.Resources.export;
            this.CSVImportbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CSVImportbtn.Location = new System.Drawing.Point(999, 645);
            this.CSVImportbtn.Margin = new System.Windows.Forms.Padding(4);
            this.CSVImportbtn.Name = "CSVImportbtn";
            this.CSVImportbtn.Size = new System.Drawing.Size(129, 28);
            this.CSVImportbtn.TabIndex = 7;
            this.CSVImportbtn.Text = "Export to CSV";
            this.CSVImportbtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CSVImportbtn.UseVisualStyleBackColor = true;
            this.CSVImportbtn.Click += new System.EventHandler(this.CSVImportbtn_Click);
            // 
            // massUpdateBtn
            // 
            this.massUpdateBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.massUpdateBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.massUpdateBtn.Image = global::StudentInformation.Properties.Resources.update;
            this.massUpdateBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.massUpdateBtn.Location = new System.Drawing.Point(1000, 603);
            this.massUpdateBtn.Margin = new System.Windows.Forms.Padding(4);
            this.massUpdateBtn.Name = "massUpdateBtn";
            this.massUpdateBtn.Size = new System.Drawing.Size(127, 28);
            this.massUpdateBtn.TabIndex = 6;
            this.massUpdateBtn.Text = "Mass update";
            this.massUpdateBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.massUpdateBtn.UseVisualStyleBackColor = true;
            this.massUpdateBtn.Click += new System.EventHandler(this.massUpdateBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshBtn.Image = global::StudentInformation.Properties.Resources.refresh;
            this.refreshBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.refreshBtn.Location = new System.Drawing.Point(680, 687);
            this.refreshBtn.Margin = new System.Windows.Forms.Padding(4);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(93, 28);
            this.refreshBtn.TabIndex = 4;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Image = global::StudentInformation.Properties.Resources.yes;
            this.okBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okBtn.Location = new System.Drawing.Point(795, 687);
            this.okBtn.Margin = new System.Windows.Forms.Padding(4);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(69, 28);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "OK";
            this.okBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox1.Location = new System.Drawing.Point(173, 698);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 22);
            this.textBox1.TabIndex = 9;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataMember = "Student";
            this.studentBindingSource.DataSource = this.dataSetStudents;
            // 
            // dataSetStudents
            // 
            this.dataSetStudents.DataSetName = "DataSetStudents";
            this.dataSetStudents.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SelectStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(1184, 723);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.CSVImportbtn);
            this.Controls.Add(this.massUpdateBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "SelectStudents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select  a student";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SelectStudents_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SelectStudents_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eXT00101BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sISCDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox searchByTypecb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox searchByStudClasscb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox searchByEnrollStatcb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox searchByStudentStatcb;
        private System.Windows.Forms.Button massUpdateBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox searchBySectioncb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox searchByLevelcb;
        private System.Windows.Forms.Button CSVImportbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox searchBystudNameTb;
        private System.Windows.Forms.ComboBox searchByLastSchoolAttcb;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private StudentInformation.Datasets.DataSetStudents dataSetStudents;
        private System.Windows.Forms.Label label9;
        private SISCDataSet sISCDataSet;
        private System.Windows.Forms.BindingSource eXT00101BindingSource;
        private StudentInformation.SISCDataSetTableAdapters.EXT00101TableAdapter eXT00101TableAdapter;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn OfficiallyEnrolled;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn Section;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn Religion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateEnrolled;
    }
}