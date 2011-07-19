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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inactive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.searchByStudClasscb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.searchByEnrollStatcb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.searchByStudentStatcb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.searchByTypecb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.searchByActivecb = new System.Windows.Forms.ComboBox();
            this.massUpdateBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentID,
            this.StudentName,
            this.Inactive});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(543, 451);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // StudentID
            // 
            this.StudentID.DataPropertyName = "CustomerID";
            this.StudentID.HeaderText = "Student ID";
            this.StudentID.Name = "StudentID";
            this.StudentID.ReadOnly = true;
            // 
            // StudentName
            // 
            this.StudentName.DataPropertyName = "CustomerName";
            this.StudentName.HeaderText = "StudentName";
            this.StudentName.Name = "StudentName";
            this.StudentName.ReadOnly = true;
            this.StudentName.Width = 300;
            // 
            // Inactive
            // 
            this.Inactive.DataPropertyName = "Inactive";
            this.Inactive.HeaderText = "Inactive";
            this.Inactive.Name = "Inactive";
            this.Inactive.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 469);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current selected student:";
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Image = global::StudentInformation.Properties.Resources.yes;
            this.okBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okBtn.Location = new System.Drawing.Point(419, 469);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(52, 23);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "OK";
            this.okBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Image = global::StudentInformation.Properties.Resources.refresh;
            this.refreshBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.refreshBtn.Location = new System.Drawing.Point(343, 469);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(70, 23);
            this.refreshBtn.TabIndex = 4;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Image = global::StudentInformation.Properties.Resources.cancel;
            this.cancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelBtn.Location = new System.Drawing.Point(477, 469);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(63, 23);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.searchByStudClasscb);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.searchByEnrollStatcb);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.searchByStudentStatcb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.searchByTypecb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.searchByActivecb);
            this.groupBox1.Location = new System.Drawing.Point(561, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 289);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Student Class";
            // 
            // searchByStudClasscb
            // 
            this.searchByStudClasscb.FormattingEnabled = true;
            this.searchByStudClasscb.Items.AddRange(new object[] {
            "Student",
            "College_Student",
            "All"});
            this.searchByStudClasscb.Location = new System.Drawing.Point(18, 249);
            this.searchByStudClasscb.Name = "searchByStudClasscb";
            this.searchByStudClasscb.Size = new System.Drawing.Size(121, 21);
            this.searchByStudClasscb.TabIndex = 8;
            this.searchByStudClasscb.Text = "All";
            this.searchByStudClasscb.SelectedIndexChanged += new System.EventHandler(this.searchByStudClasscb_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Enrollment Status";
            // 
            // searchByEnrollStatcb
            // 
            this.searchByEnrollStatcb.FormattingEnabled = true;
            this.searchByEnrollStatcb.Items.AddRange(new object[] {
            "Enrolled",
            "Assessed",
            "Not Enrolled",
            "Not applicable",
            "All"});
            this.searchByEnrollStatcb.Location = new System.Drawing.Point(18, 198);
            this.searchByEnrollStatcb.Name = "searchByEnrollStatcb";
            this.searchByEnrollStatcb.Size = new System.Drawing.Size(121, 21);
            this.searchByEnrollStatcb.TabIndex = 6;
            this.searchByEnrollStatcb.Text = "All";
            this.searchByEnrollStatcb.SelectedIndexChanged += new System.EventHandler(this.searchByEnrollStatcb_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Student Status";
            // 
            // searchByStudentStatcb
            // 
            this.searchByStudentStatcb.FormattingEnabled = true;
            this.searchByStudentStatcb.Items.AddRange(new object[] {
            "New student",
            "Old student",
            "Returning",
            "Not applicable",
            "All"});
            this.searchByStudentStatcb.Location = new System.Drawing.Point(18, 146);
            this.searchByStudentStatcb.Name = "searchByStudentStatcb";
            this.searchByStudentStatcb.Size = new System.Drawing.Size(121, 21);
            this.searchByStudentStatcb.TabIndex = 4;
            this.searchByStudentStatcb.Text = "All";
            this.searchByStudentStatcb.SelectedIndexChanged += new System.EventHandler(this.searchByStudentStatcb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Type";
            // 
            // searchByTypecb
            // 
            this.searchByTypecb.FormattingEnabled = true;
            this.searchByTypecb.Items.AddRange(new object[] {
            "Basic Education",
            "International Baccal",
            "College",
            "Innove",
            "Other",
            "Not applicable",
            "All"});
            this.searchByTypecb.Location = new System.Drawing.Point(18, 94);
            this.searchByTypecb.Name = "searchByTypecb";
            this.searchByTypecb.Size = new System.Drawing.Size(121, 21);
            this.searchByTypecb.TabIndex = 2;
            this.searchByTypecb.Text = "All";
            this.searchByTypecb.SelectedIndexChanged += new System.EventHandler(this.searchByTypecb_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Active";
            // 
            // searchByActivecb
            // 
            this.searchByActivecb.FormattingEnabled = true;
            this.searchByActivecb.Items.AddRange(new object[] {
            "True",
            "False",
            "All"});
            this.searchByActivecb.Location = new System.Drawing.Point(18, 41);
            this.searchByActivecb.Name = "searchByActivecb";
            this.searchByActivecb.Size = new System.Drawing.Size(121, 21);
            this.searchByActivecb.TabIndex = 0;
            this.searchByActivecb.Text = "All";
            this.searchByActivecb.SelectedIndexChanged += new System.EventHandler(this.searchByActivecb_SelectedIndexChanged);
            // 
            // massUpdateBtn
            // 
            this.massUpdateBtn.Location = new System.Drawing.Point(594, 336);
            this.massUpdateBtn.Name = "massUpdateBtn";
            this.massUpdateBtn.Size = new System.Drawing.Size(93, 23);
            this.massUpdateBtn.TabIndex = 6;
            this.massUpdateBtn.Text = "Mass update";
            this.massUpdateBtn.UseVisualStyleBackColor = true;
            // 
            // SelectStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(751, 504);
            this.Controls.Add(this.massUpdateBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SelectStudents";
            this.Text = "Select  a student";
            this.Load += new System.EventHandler(this.SelectStudents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inactive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox searchByTypecb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox searchByActivecb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox searchByStudClasscb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox searchByEnrollStatcb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox searchByStudentStatcb;
        private System.Windows.Forms.Button massUpdateBtn;
    }
}