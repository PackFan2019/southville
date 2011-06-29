namespace StudentAssessment
{
    partial class frmViewDiscountDetails
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
            this.txtDiscountTotal = new System.Windows.Forms.TextBox();
            this.lblTotalDiscount = new System.Windows.Forms.Label();
            this.lstDiscounts = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(5, 177);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtDiscountTotal
            // 
            this.txtDiscountTotal.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountTotal.Location = new System.Drawing.Point(393, 179);
            this.txtDiscountTotal.Name = "txtDiscountTotal";
            this.txtDiscountTotal.ReadOnly = true;
            this.txtDiscountTotal.Size = new System.Drawing.Size(74, 21);
            this.txtDiscountTotal.TabIndex = 8;
            this.txtDiscountTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalDiscount
            // 
            this.lblTotalDiscount.AutoSize = true;
            this.lblTotalDiscount.Location = new System.Drawing.Point(308, 182);
            this.lblTotalDiscount.Name = "lblTotalDiscount";
            this.lblTotalDiscount.Size = new System.Drawing.Size(79, 13);
            this.lblTotalDiscount.TabIndex = 11;
            this.lblTotalDiscount.Text = "Total Discount:";
            // 
            // lstDiscounts
            // 
            this.lstDiscounts.FullRowSelect = true;
            this.lstDiscounts.Location = new System.Drawing.Point(5, 5);
            this.lstDiscounts.MultiSelect = false;
            this.lstDiscounts.Name = "lstDiscounts";
            this.lstDiscounts.Size = new System.Drawing.Size(462, 168);
            this.lstDiscounts.TabIndex = 9;
            this.lstDiscounts.UseCompatibleStateImageBehavior = false;
            this.lstDiscounts.View = System.Windows.Forms.View.Details;
            // 
            // frmViewDiscountDetails
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(471, 205);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtDiscountTotal);
            this.Controls.Add(this.lblTotalDiscount);
            this.Controls.Add(this.lstDiscounts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmViewDiscountDetails";
            this.Text = "Discount Details";
            this.Load += new System.EventHandler(this.frmViewDiscountDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtDiscountTotal;
        private System.Windows.Forms.Label lblTotalDiscount;
        private System.Windows.Forms.ListView lstDiscounts;
    }
}