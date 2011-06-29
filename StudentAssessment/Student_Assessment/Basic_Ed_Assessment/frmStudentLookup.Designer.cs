namespace StudentAssessment
{
    partial class frmStudentLookup
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
            this.lblStudentID = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.lstStudentList = new System.Windows.Forms.ListView();
            this.clmStudentID = new System.Windows.Forms.ColumnHeader();
            this.clmName = new System.Windows.Forms.ColumnHeader();
            this.clmLevel = new System.Windows.Forms.ColumnHeader();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(5, 15);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(98, 13);
            this.lblStudentID.TabIndex = 0;
            this.lblStudentID.Text = "Find by Student ID:";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(109, 12);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(100, 20);
            this.txtStudentID.TabIndex = 1;
            this.txtStudentID.TextChanged += new System.EventHandler(this.txtStudentID_TextChanged);
            // 
            // lstStudentList
            // 
            this.lstStudentList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmStudentID,
            this.clmName,
            this.clmLevel});
            this.lstStudentList.FullRowSelect = true;
            this.lstStudentList.Location = new System.Drawing.Point(8, 38);
            this.lstStudentList.MultiSelect = false;
            this.lstStudentList.Name = "lstStudentList";
            this.lstStudentList.Size = new System.Drawing.Size(384, 178);
            this.lstStudentList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstStudentList.TabIndex = 2;
            this.lstStudentList.UseCompatibleStateImageBehavior = false;
            this.lstStudentList.View = System.Windows.Forms.View.Details;
            this.lstStudentList.SelectedIndexChanged += new System.EventHandler(this.lstStudentList_SelectedIndexChanged);
            this.lstStudentList.DoubleClick += new System.EventHandler(this.lstStudentList_DoubleClick);
            // 
            // clmStudentID
            // 
            this.clmStudentID.Text = "Student ID";
            this.clmStudentID.Width = 80;
            // 
            // clmName
            // 
            this.clmName.Text = "Name";
            this.clmName.Width = 220;
            // 
            // clmLevel
            // 
            this.clmLevel.Text = "Level";
            this.clmLevel.Width = 80;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(322, 222);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmStudentLookup
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 252);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lstStudentList);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.lblStudentID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStudentLookup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Student Lookup";
            this.Load += new System.EventHandler(this.frmStudentLookup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.ListView lstStudentList;
        private System.Windows.Forms.ColumnHeader clmStudentID;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.ColumnHeader clmLevel;
        private System.Windows.Forms.Button btnOK;
    }
}