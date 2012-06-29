namespace StudentAssessment
{
    partial class frmStatementOfAccountParameters
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtStudentNo = new System.Windows.Forms.TextBox();
            this.lblStudentNo = new System.Windows.Forms.Label();
            this.btnStudentIDLookup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(129, 45);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(31, 45);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtStudentNo
            // 
            this.txtStudentNo.Location = new System.Drawing.Point(95, 12);
            this.txtStudentNo.Name = "txtStudentNo";
            this.txtStudentNo.Size = new System.Drawing.Size(100, 20);
            this.txtStudentNo.TabIndex = 10;
            // 
            // lblStudentNo
            // 
            this.lblStudentNo.AutoSize = true;
            this.lblStudentNo.Location = new System.Drawing.Point(15, 15);
            this.lblStudentNo.Name = "lblStudentNo";
            this.lblStudentNo.Size = new System.Drawing.Size(67, 13);
            this.lblStudentNo.TabIndex = 9;
            this.lblStudentNo.Text = "Student No.:";
            // 
            // btnStudentIDLookup
            // 
            this.btnStudentIDLookup.Image = global::StudentAssessment.Properties.Resources.Field_Lookup;
            this.btnStudentIDLookup.Location = new System.Drawing.Point(197, 10);
            this.btnStudentIDLookup.Name = "btnStudentIDLookup";
            this.btnStudentIDLookup.Size = new System.Drawing.Size(21, 23);
            this.btnStudentIDLookup.TabIndex = 11;
            this.btnStudentIDLookup.TabStop = false;
            this.btnStudentIDLookup.UseVisualStyleBackColor = true;
            this.btnStudentIDLookup.Click += new System.EventHandler(this.btnStudentIDLookup_Click);
            // 
            // frmStatementOfAccountParameters
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(233, 80);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnStudentIDLookup);
            this.Controls.Add(this.txtStudentNo);
            this.Controls.Add(this.lblStudentNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStatementOfAccountParameters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statement Of Account Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnStudentIDLookup;
        private System.Windows.Forms.TextBox txtStudentNo;
        private System.Windows.Forms.Label lblStudentNo;
    }
}