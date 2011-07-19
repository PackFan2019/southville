namespace StudentInformation.Forms
{
    partial class StudentType
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
            this.studTypeCb = new System.Windows.Forms.ComboBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.yearCb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // studTypeCb
            // 
            this.studTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.studTypeCb.FormattingEnabled = true;
            this.studTypeCb.Items.AddRange(new object[] {
            "Basic Education",
            "International Baccalaureate",
            "College",
            "Innove",
            "Other"});
            this.studTypeCb.Location = new System.Drawing.Point(12, 30);
            this.studTypeCb.Name = "studTypeCb";
            this.studTypeCb.Size = new System.Drawing.Size(153, 21);
            this.studTypeCb.TabIndex = 0;
            this.studTypeCb.SelectedIndexChanged += new System.EventHandler(this.studTypeCb_SelectedIndexChanged);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Image = global::StudentInformation.Properties.Resources.cancel;
            this.cancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelBtn.Location = new System.Drawing.Point(81, 117);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(73, 23);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Image = global::StudentInformation.Properties.Resources.yes;
            this.okBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okBtn.Location = new System.Drawing.Point(23, 117);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(52, 23);
            this.okBtn.TabIndex = 4;
            this.okBtn.Text = "OK";
            this.okBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select Student Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select Year";
            // 
            // yearCb
            // 
            this.yearCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearCb.FormattingEnabled = true;
            this.yearCb.Location = new System.Drawing.Point(12, 81);
            this.yearCb.Name = "yearCb";
            this.yearCb.Size = new System.Drawing.Size(153, 21);
            this.yearCb.TabIndex = 7;
            // 
            // StudentType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 153);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.yearCb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.studTypeCb);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(184, 180);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(184, 180);
            this.Name = "StudentType";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Student Type and Year";
            this.Load += new System.EventHandler(this.StudentType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox studTypeCb;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox yearCb;
    }
}