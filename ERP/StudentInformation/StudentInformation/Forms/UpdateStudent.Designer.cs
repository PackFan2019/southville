namespace StudentInformation.Forms
{
    partial class UpdateStudent
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
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.newValuecb = new System.Windows.Forms.ComboBox();
            this.backBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.fieldToUpdatecb = new System.Windows.Forms.ComboBox();
            this.captionLbl = new System.Windows.Forms.Label();
            this.choosenFieldLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.StudentID,
            this.StudentName});
            this.dataGridView1.Location = new System.Drawing.Point(12, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(445, 409);
            this.dataGridView1.TabIndex = 1;
            // 
            // Check
            // 
            this.Check.FalseValue = "";
            this.Check.HeaderText = "";
            this.Check.Name = "Check";
            this.Check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Check.TrueValue = "";
            this.Check.Width = 30;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.backBtn);
            this.groupBox1.Controls.Add(this.updateBtn);
            this.groupBox1.Controls.Add(this.fieldToUpdatecb);
            this.groupBox1.Location = new System.Drawing.Point(463, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 318);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose field/s to Update";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(11, 195);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(150, 112);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "***Note:\nTo use the \"Mass Update\", just choose the field you want to update and c" +
                "hoose the new value. \n\nEx. Field: Enrolment Status; New Value: Enrolled";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.newValuecb);
            this.groupBox2.Location = new System.Drawing.Point(6, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(155, 66);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose new value";
            // 
            // newValuecb
            // 
            this.newValuecb.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.newValuecb.FormattingEnabled = true;
            this.newValuecb.Location = new System.Drawing.Point(11, 30);
            this.newValuecb.Name = "newValuecb";
            this.newValuecb.Size = new System.Drawing.Size(132, 21);
            this.newValuecb.TabIndex = 0;
            // 
            // backBtn
            // 
            this.backBtn.Image = global::StudentInformation.Properties.Resources.back;
            this.backBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.backBtn.Location = new System.Drawing.Point(11, 156);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(59, 23);
            this.backBtn.TabIndex = 2;
            this.backBtn.Text = "Back";
            this.backBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Image = global::StudentInformation.Properties.Resources.save;
            this.updateBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.updateBtn.Location = new System.Drawing.Point(91, 156);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(58, 23);
            this.updateBtn.TabIndex = 3;
            this.updateBtn.Text = "Save";
            this.updateBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // fieldToUpdatecb
            // 
            this.fieldToUpdatecb.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.fieldToUpdatecb.FormattingEnabled = true;
            this.fieldToUpdatecb.Items.AddRange(new object[] {
            "Enrollment Status",
            "Level",
            "Section",
            "Religion"});
            this.fieldToUpdatecb.Location = new System.Drawing.Point(17, 32);
            this.fieldToUpdatecb.Name = "fieldToUpdatecb";
            this.fieldToUpdatecb.Size = new System.Drawing.Size(132, 21);
            this.fieldToUpdatecb.TabIndex = 0;
            this.fieldToUpdatecb.SelectedIndexChanged += new System.EventHandler(this.fieldToUpdatecb_SelectedIndexChanged);
            // 
            // captionLbl
            // 
            this.captionLbl.AutoSize = true;
            this.captionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captionLbl.Location = new System.Drawing.Point(12, 18);
            this.captionLbl.Name = "captionLbl";
            this.captionLbl.Size = new System.Drawing.Size(41, 15);
            this.captionLbl.TabIndex = 5;
            this.captionLbl.Text = "label1";
            // 
            // choosenFieldLbl
            // 
            this.choosenFieldLbl.AutoSize = true;
            this.choosenFieldLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choosenFieldLbl.Location = new System.Drawing.Point(12, 44);
            this.choosenFieldLbl.Name = "choosenFieldLbl";
            this.choosenFieldLbl.Size = new System.Drawing.Size(47, 15);
            this.choosenFieldLbl.TabIndex = 6;
            this.choosenFieldLbl.Text = "label1";
            // 
            // UpdateStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 505);
            this.Controls.Add(this.choosenFieldLbl);
            this.Controls.Add(this.captionLbl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(649, 532);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(649, 532);
            this.Name = "UpdateStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Student";
            this.Load += new System.EventHandler(this.UpdateStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox fieldToUpdatecb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox newValuecb;
        private System.Windows.Forms.Label captionLbl;
        private System.Windows.Forms.Label choosenFieldLbl;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
    }
}