namespace StudentInformation.Forms
{
    partial class EnrollmentReportDialog
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
            this.comboBoxEnrollment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxLevel = new System.Windows.Forms.CheckBox();
            this.checkBoxSection = new System.Windows.Forms.CheckBox();
            this.textBoxLevel = new System.Windows.Forms.TextBox();
            this.textBoxSection = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxEnrollment
            // 
            this.comboBoxEnrollment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEnrollment.FormattingEnabled = true;
            this.comboBoxEnrollment.Items.AddRange(new object[] {
            "All",
            "Enrolled",
            "Assessed",
            "Not enrolled",
            "Not applicable"});
            this.comboBoxEnrollment.Location = new System.Drawing.Point(140, 17);
            this.comboBoxEnrollment.Name = "comboBoxEnrollment";
            this.comboBoxEnrollment.Size = new System.Drawing.Size(199, 21);
            this.comboBoxEnrollment.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enrollment Status:";
            // 
            // checkBoxLevel
            // 
            this.checkBoxLevel.AutoSize = true;
            this.checkBoxLevel.Location = new System.Drawing.Point(15, 49);
            this.checkBoxLevel.Name = "checkBoxLevel";
            this.checkBoxLevel.Size = new System.Drawing.Size(52, 17);
            this.checkBoxLevel.TabIndex = 3;
            this.checkBoxLevel.Text = "Level";
            this.checkBoxLevel.UseVisualStyleBackColor = true;
            this.checkBoxLevel.CheckedChanged += new System.EventHandler(this.checkBoxLevel_CheckedChanged);
            // 
            // checkBoxSection
            // 
            this.checkBoxSection.AutoSize = true;
            this.checkBoxSection.Location = new System.Drawing.Point(15, 76);
            this.checkBoxSection.Name = "checkBoxSection";
            this.checkBoxSection.Size = new System.Drawing.Size(62, 17);
            this.checkBoxSection.TabIndex = 4;
            this.checkBoxSection.Text = "Section";
            this.checkBoxSection.UseVisualStyleBackColor = true;
            this.checkBoxSection.CheckedChanged += new System.EventHandler(this.checkBoxSection_CheckedChanged);
            // 
            // textBoxLevel
            // 
            this.textBoxLevel.Enabled = false;
            this.textBoxLevel.Location = new System.Drawing.Point(140, 46);
            this.textBoxLevel.Name = "textBoxLevel";
            this.textBoxLevel.Size = new System.Drawing.Size(199, 20);
            this.textBoxLevel.TabIndex = 5;
            this.textBoxLevel.Text = "Any level";
            // 
            // textBoxSection
            // 
            this.textBoxSection.Enabled = false;
            this.textBoxSection.Location = new System.Drawing.Point(140, 73);
            this.textBoxSection.Name = "textBoxSection";
            this.textBoxSection.Size = new System.Drawing.Size(199, 20);
            this.textBoxSection.TabIndex = 6;
            this.textBoxSection.Text = "Any section";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(208, 105);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(50, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(264, 104);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // EnrollmentReportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 136);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxSection);
            this.Controls.Add(this.textBoxLevel);
            this.Controls.Add(this.checkBoxSection);
            this.Controls.Add(this.checkBoxLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxEnrollment);
            this.Name = "EnrollmentReportDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Report Options";
            this.Load += new System.EventHandler(this.EnrollmentReportDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxEnrollment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxLevel;
        private System.Windows.Forms.CheckBox checkBoxSection;
        private System.Windows.Forms.TextBox textBoxLevel;
        private System.Windows.Forms.TextBox textBoxSection;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}