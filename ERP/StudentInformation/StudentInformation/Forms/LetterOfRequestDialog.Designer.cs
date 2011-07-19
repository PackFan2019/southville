namespace StudentInformation.Forms
{
    partial class LetterOfRequestDialog
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
            this.schoolNameTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.schoolAddressTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.attainmentComboBox = new System.Windows.Forms.ComboBox();
            this.schoolYearComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // schoolNameTextbox
            // 
            this.schoolNameTextbox.Location = new System.Drawing.Point(97, 21);
            this.schoolNameTextbox.Name = "schoolNameTextbox";
            this.schoolNameTextbox.ReadOnly = true;
            this.schoolNameTextbox.Size = new System.Drawing.Size(448, 20);
            this.schoolNameTextbox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "School Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "School Address:";
            // 
            // schoolAddressTextbox
            // 
            this.schoolAddressTextbox.Location = new System.Drawing.Point(97, 56);
            this.schoolAddressTextbox.Name = "schoolAddressTextbox";
            this.schoolAddressTextbox.Size = new System.Drawing.Size(448, 20);
            this.schoolAddressTextbox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Last Attainment:";
            // 
            // attainmentComboBox
            // 
            this.attainmentComboBox.FormattingEnabled = true;
            this.attainmentComboBox.Items.AddRange(new object[] {
            "Not applicable",
            "Toddlers",
            "Nursery",
            "Kinder",
            "Junior Prep",
            "Senior Prep",
            "Grade 1",
            "Grade 2",
            "Grade 3",
            "Grade 4",
            "Grade 5",
            "Grade 6",
            "Grade 7",
            "1st Year",
            "2nd Year",
            "3rd Year",
            "4th Year"});
            this.attainmentComboBox.Location = new System.Drawing.Point(97, 91);
            this.attainmentComboBox.Name = "attainmentComboBox";
            this.attainmentComboBox.Size = new System.Drawing.Size(129, 21);
            this.attainmentComboBox.TabIndex = 6;
            // 
            // schoolYearComboBox
            // 
            this.schoolYearComboBox.FormattingEnabled = true;
            this.schoolYearComboBox.Location = new System.Drawing.Point(97, 127);
            this.schoolYearComboBox.Name = "schoolYearComboBox";
            this.schoolYearComboBox.Size = new System.Drawing.Size(129, 21);
            this.schoolYearComboBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "School Year:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(-6, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(651, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "_________________________________________________________________________________" +
                "___________";
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Image = global::StudentInformation.Properties.Resources.yes;
            this.OkButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OkButton.Location = new System.Drawing.Point(408, 174);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(47, 23);
            this.OkButton.TabIndex = 10;
            this.OkButton.Text = "OK";
            this.OkButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Image = global::StudentInformation.Properties.Resources.cancel;
            this.cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelButton.Location = new System.Drawing.Point(470, 174);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // LetterOfRequestDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 200);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.schoolYearComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.attainmentComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.schoolAddressTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.schoolNameTextbox);
            this.Name = "LetterOfRequestDialog";
            this.Text = "LetterOfRequestDialog";
            this.Load += new System.EventHandler(this.LetterOfRequestDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox schoolNameTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox schoolAddressTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox attainmentComboBox;
        private System.Windows.Forms.ComboBox schoolYearComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button cancelButton;
    }
}