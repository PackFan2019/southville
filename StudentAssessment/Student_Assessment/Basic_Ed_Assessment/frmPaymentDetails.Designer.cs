namespace StudentAssessment
{
    partial class frmPaymentDetails
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
            this.lstPaymentSchedule = new System.Windows.Forms.ListView();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnSaveDate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstPaymentSchedule
            // 
            this.lstPaymentSchedule.FullRowSelect = true;
            this.lstPaymentSchedule.Location = new System.Drawing.Point(3, 31);
            this.lstPaymentSchedule.MultiSelect = false;
            this.lstPaymentSchedule.Name = "lstPaymentSchedule";
            this.lstPaymentSchedule.Size = new System.Drawing.Size(210, 124);
            this.lstPaymentSchedule.TabIndex = 3;
            this.lstPaymentSchedule.UseCompatibleStateImageBehavior = false;
            this.lstPaymentSchedule.View = System.Windows.Forms.View.Details;
            this.lstPaymentSchedule.SelectedIndexChanged += new System.EventHandler(this.lstPaymentSchedule_SelectedIndexChanged);
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(139, 161);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(74, 20);
            this.txtTotal.TabIndex = 6;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(99, 164);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Total:";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(3, 159);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Enabled = false;
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(6, 6);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(100, 20);
            this.dtpDueDate.TabIndex = 0;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(112, 7);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(74, 20);
            this.txtAmount.TabIndex = 1;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSaveDate
            // 
            this.btnSaveDate.Enabled = false;
            this.btnSaveDate.Image = global::StudentAssessment.Properties.Resources.Toolbar_Save;
            this.btnSaveDate.Location = new System.Drawing.Point(192, 5);
            this.btnSaveDate.Name = "btnSaveDate";
            this.btnSaveDate.Size = new System.Drawing.Size(21, 23);
            this.btnSaveDate.TabIndex = 2;
            this.btnSaveDate.TabStop = false;
            this.btnSaveDate.UseVisualStyleBackColor = true;
            this.btnSaveDate.Click += new System.EventHandler(this.btnSaveDate_Click);
            // 
            // frmPaymentDetails
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(216, 191);
            this.Controls.Add(this.btnSaveDate);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lstPaymentSchedule);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPaymentDetails";
            this.Text = "Payment Details";
            this.Load += new System.EventHandler(this.frmPaymentDetails_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPaymentDetails_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstPaymentSchedule;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnSaveDate;
    }
}