namespace StudentAssessment
{
    partial class frmDiscountDetails
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
            this.lstDiscounts = new System.Windows.Forms.ListView();
            this.txtPercentage = new System.Windows.Forms.TextBox();
            this.txtDiscountTotal = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.cboItemsToApplyTo = new System.Windows.Forms.ComboBox();
            this.txtDiscountID = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.chkValidate = new System.Windows.Forms.CheckBox();
            this.txtDiscountDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstDiscounts
            // 
            this.lstDiscounts.BackColor = System.Drawing.SystemColors.Window;
            this.lstDiscounts.FullRowSelect = true;
            this.lstDiscounts.Location = new System.Drawing.Point(7, 30);
            this.lstDiscounts.MultiSelect = false;
            this.lstDiscounts.Name = "lstDiscounts";
            this.lstDiscounts.Size = new System.Drawing.Size(462, 168);
            this.lstDiscounts.TabIndex = 3;
            this.lstDiscounts.UseCompatibleStateImageBehavior = false;
            this.lstDiscounts.View = System.Windows.Forms.View.Details;
            this.lstDiscounts.SelectedIndexChanged += new System.EventHandler(this.lstAppliedDiscounts_SelectedIndexChanged);
            // 
            // txtPercentage
            // 
            this.txtPercentage.Location = new System.Drawing.Point(279, 7);
            this.txtPercentage.MaxLength = 5;
            this.txtPercentage.Name = "txtPercentage";
            this.txtPercentage.ReadOnly = true;
            this.txtPercentage.Size = new System.Drawing.Size(52, 20);
            this.txtPercentage.TabIndex = 2;
            // 
            // txtDiscountTotal
            // 
            this.txtDiscountTotal.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountTotal.ForeColor = System.Drawing.Color.Black;
            this.txtDiscountTotal.Location = new System.Drawing.Point(394, 203);
            this.txtDiscountTotal.Name = "txtDiscountTotal";
            this.txtDiscountTotal.ReadOnly = true;
            this.txtDiscountTotal.Size = new System.Drawing.Size(74, 21);
            this.txtDiscountTotal.TabIndex = 8;
            this.txtDiscountTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(394, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "&Close";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cboItemsToApplyTo
            // 
            this.cboItemsToApplyTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItemsToApplyTo.Enabled = false;
            this.cboItemsToApplyTo.FormattingEnabled = true;
            this.cboItemsToApplyTo.Location = new System.Drawing.Point(73, 205);
            this.cboItemsToApplyTo.Name = "cboItemsToApplyTo";
            this.cboItemsToApplyTo.Size = new System.Drawing.Size(135, 21);
            this.cboItemsToApplyTo.TabIndex = 5;
            // 
            // txtDiscountID
            // 
            this.txtDiscountID.Location = new System.Drawing.Point(7, 7);
            this.txtDiscountID.Name = "txtDiscountID";
            this.txtDiscountID.ReadOnly = true;
            this.txtDiscountID.Size = new System.Drawing.Size(90, 20);
            this.txtDiscountID.TabIndex = 0;
            // 
            // btnInsert
            // 
            this.btnInsert.Enabled = false;
            this.btnInsert.Location = new System.Drawing.Point(211, 203);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 6;
            this.btnInsert.Text = "&Apply";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(292, 203);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "&Unnapply";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // chkValidate
            // 
            this.chkValidate.AutoSize = true;
            this.chkValidate.Checked = true;
            this.chkValidate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkValidate.Location = new System.Drawing.Point(7, 207);
            this.chkValidate.Name = "chkValidate";
            this.chkValidate.Size = new System.Drawing.Size(64, 17);
            this.chkValidate.TabIndex = 4;
            this.chkValidate.Text = "Validate";
            this.chkValidate.UseVisualStyleBackColor = true;
            this.chkValidate.CheckedChanged += new System.EventHandler(this.chkValidate_CheckedChanged);
            // 
            // txtDiscountDescription
            // 
            this.txtDiscountDescription.Location = new System.Drawing.Point(98, 7);
            this.txtDiscountDescription.Name = "txtDiscountDescription";
            this.txtDiscountDescription.ReadOnly = true;
            this.txtDiscountDescription.Size = new System.Drawing.Size(179, 20);
            this.txtDiscountDescription.TabIndex = 1;
            // 
            // frmDiscountDetails
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(476, 231);
            this.Controls.Add(this.txtDiscountDescription);
            this.Controls.Add(this.chkValidate);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.cboItemsToApplyTo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtDiscountTotal);
            this.Controls.Add(this.txtPercentage);
            this.Controls.Add(this.txtDiscountID);
            this.Controls.Add(this.lstDiscounts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDiscountDetails";
            this.Text = "Discount Details";
            this.Load += new System.EventHandler(this.frmDiscountDetails_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDiscountDetails_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstDiscounts;
        private System.Windows.Forms.TextBox txtPercentage;
        private System.Windows.Forms.TextBox txtDiscountTotal;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cboItemsToApplyTo;
        private System.Windows.Forms.TextBox txtDiscountID;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.CheckBox chkValidate;
        private System.Windows.Forms.TextBox txtDiscountDescription;
    }
}