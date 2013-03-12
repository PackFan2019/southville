namespace StudentAssessment
{
    partial class frmItemLookup
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
            this.btnOK = new System.Windows.Forms.Button();
            this.lstItemList = new System.Windows.Forms.ListView();
            this.clmClassID = new System.Windows.Forms.ColumnHeader();
            this.clmItemNo = new System.Windows.Forms.ColumnHeader();
            this.clmItemDescription = new System.Windows.Forms.ColumnHeader();
            this.clmUnitPrice = new System.Windows.Forms.ColumnHeader();
            this.txtItemNo = new System.Windows.Forms.TextBox();
            this.lblItemNo = new System.Windows.Forms.Label();
            this.chkCollegeSubjs = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(386, 224);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lstItemList
            // 
            this.lstItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmClassID,
            this.clmItemNo,
            this.clmItemDescription,
            this.clmUnitPrice});
            this.lstItemList.FullRowSelect = true;
            this.lstItemList.Location = new System.Drawing.Point(9, 35);
            this.lstItemList.Name = "lstItemList";
            this.lstItemList.Size = new System.Drawing.Size(452, 178);
            this.lstItemList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstItemList.TabIndex = 6;
            this.lstItemList.UseCompatibleStateImageBehavior = false;
            this.lstItemList.View = System.Windows.Forms.View.Details;
            this.lstItemList.SelectedIndexChanged += new System.EventHandler(this.lstItemList_SelectedIndexChanged);
            this.lstItemList.DoubleClick += new System.EventHandler(this.lstItemList_DoubleClick);
            // 
            // clmClassID
            // 
            this.clmClassID.Text = "Class ID";
            // 
            // clmItemNo
            // 
            this.clmItemNo.Text = "Item No.";
            this.clmItemNo.Width = 80;
            // 
            // clmItemDescription
            // 
            this.clmItemDescription.Text = "Description";
            this.clmItemDescription.Width = 220;
            // 
            // clmUnitPrice
            // 
            this.clmUnitPrice.Text = "Unit Price";
            this.clmUnitPrice.Width = 80;
            // 
            // txtItemNo
            // 
            this.txtItemNo.Location = new System.Drawing.Point(110, 9);
            this.txtItemNo.Name = "txtItemNo";
            this.txtItemNo.Size = new System.Drawing.Size(100, 20);
            this.txtItemNo.TabIndex = 5;
            this.txtItemNo.TextChanged += new System.EventHandler(this.txtItemNo_TextChanged);
            // 
            // lblItemNo
            // 
            this.lblItemNo.AutoSize = true;
            this.lblItemNo.Location = new System.Drawing.Point(6, 12);
            this.lblItemNo.Name = "lblItemNo";
            this.lblItemNo.Size = new System.Drawing.Size(87, 13);
            this.lblItemNo.TabIndex = 4;
            this.lblItemNo.Text = "Find by Item No.:";
            // 
            // chkCollegeSubjs
            // 
            this.chkCollegeSubjs.AutoSize = true;
            this.chkCollegeSubjs.Location = new System.Drawing.Point(13, 224);
            this.chkCollegeSubjs.Name = "chkCollegeSubjs";
            this.chkCollegeSubjs.Size = new System.Drawing.Size(159, 17);
            this.chkCollegeSubjs.TabIndex = 8;
            this.chkCollegeSubjs.Text = "Show College Subjects Only";
            this.chkCollegeSubjs.UseVisualStyleBackColor = true;
            this.chkCollegeSubjs.CheckedChanged += new System.EventHandler(this.chkCollegeSubjs_CheckedChanged);
            // 
            // frmItemLookup
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(469, 252);
            this.Controls.Add(this.chkCollegeSubjs);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lstItemList);
            this.Controls.Add(this.txtItemNo);
            this.Controls.Add(this.lblItemNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmItemLookup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Item Lookup";
            this.Load += new System.EventHandler(this.frmItemLookup_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmItemLookup_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListView lstItemList;
        private System.Windows.Forms.ColumnHeader clmItemNo;
        private System.Windows.Forms.ColumnHeader clmItemDescription;
        private System.Windows.Forms.ColumnHeader clmUnitPrice;
        private System.Windows.Forms.TextBox txtItemNo;
        private System.Windows.Forms.Label lblItemNo;
        private System.Windows.Forms.ColumnHeader clmClassID;
        private System.Windows.Forms.CheckBox chkCollegeSubjs;
    }
}