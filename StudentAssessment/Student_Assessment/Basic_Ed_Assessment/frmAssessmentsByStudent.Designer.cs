namespace StudentAssessment
{
    partial class frmAssessmentsByStudent
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOK = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRedisplay = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnStudentIDLookup = new System.Windows.Forms.Button();
            this.lstDocuments = new System.Windows.Forms.ListView();
            this.lblDocumentNo = new System.Windows.Forms.Label();
            this.txtDocumentNo = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(6, 32);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(61, 13);
            this.lblStudentID.TabIndex = 0;
            this.lblStudentID.Text = "Student ID:";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(95, 29);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(100, 20);
            this.txtStudentID.TabIndex = 1;
            this.txtStudentID.Leave += new System.EventHandler(this.txtStudentID_Leave);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 56);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(95, 53);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(169, 20);
            this.txtName.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOK,
            this.toolStripSeparator1,
            this.btnRedisplay,
            this.toolStripSeparator2});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(684, 26);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = false;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Text = "OK";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // btnRedisplay
            // 
            this.btnRedisplay.AutoSize = false;
            this.btnRedisplay.Image = global::StudentAssessment.Properties.Resources.Toolbar_Redisplay;
            this.btnRedisplay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRedisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRedisplay.Name = "btnRedisplay";
            this.btnRedisplay.Size = new System.Drawing.Size(75, 23);
            this.btnRedisplay.Text = "Redisplay";
            this.btnRedisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRedisplay.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnRedisplay.Click += new System.EventHandler(this.btnRedisplay_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // btnStudentIDLookup
            // 
            this.btnStudentIDLookup.Image = global::StudentAssessment.Properties.Resources.Field_Lookup;
            this.btnStudentIDLookup.Location = new System.Drawing.Point(196, 27);
            this.btnStudentIDLookup.Name = "btnStudentIDLookup";
            this.btnStudentIDLookup.Size = new System.Drawing.Size(21, 23);
            this.btnStudentIDLookup.TabIndex = 2;
            this.btnStudentIDLookup.TabStop = false;
            this.btnStudentIDLookup.UseVisualStyleBackColor = true;
            this.btnStudentIDLookup.Click += new System.EventHandler(this.btnStudentIDLookup_Click);
            // 
            // lstDocuments
            // 
            this.lstDocuments.FullRowSelect = true;
            this.lstDocuments.Location = new System.Drawing.Point(9, 79);
            this.lstDocuments.MultiSelect = false;
            this.lstDocuments.Name = "lstDocuments";
            this.lstDocuments.Size = new System.Drawing.Size(667, 264);
            this.lstDocuments.TabIndex = 7;
            this.lstDocuments.UseCompatibleStateImageBehavior = false;
            this.lstDocuments.View = System.Windows.Forms.View.Details;
            this.lstDocuments.DoubleClick += new System.EventHandler(this.lstDocuments_DoubleClick);
            // 
            // lblDocumentNo
            // 
            this.lblDocumentNo.AutoSize = true;
            this.lblDocumentNo.Enabled = false;
            this.lblDocumentNo.Location = new System.Drawing.Point(465, 56);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(79, 13);
            this.lblDocumentNo.TabIndex = 5;
            this.lblDocumentNo.Text = "Document No.:";
            // 
            // txtDocumentNo
            // 
            this.txtDocumentNo.Enabled = false;
            this.txtDocumentNo.Location = new System.Drawing.Point(550, 53);
            this.txtDocumentNo.Name = "txtDocumentNo";
            this.txtDocumentNo.Size = new System.Drawing.Size(126, 20);
            this.txtDocumentNo.TabIndex = 6;
            // 
            // frmAssessmentsByStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 355);
            this.Controls.Add(this.txtDocumentNo);
            this.Controls.Add(this.lblDocumentNo);
            this.Controls.Add(this.lstDocuments);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblStudentID);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnStudentIDLookup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAssessmentsByStudent";
            this.Text = "Transactions Inquiry - Student";
            this.Load += new System.EventHandler(this.frmAssessmentsByStudent_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnStudentIDLookup;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnOK;
        private System.Windows.Forms.ToolStripButton btnRedisplay;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ListView lstDocuments;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label lblDocumentNo;
        private System.Windows.Forms.TextBox txtDocumentNo;
    }
}