namespace ReportCardGenerator.Views
{
    partial class ReportCardOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportCardOption));
            this.rptCardcb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Confirmbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rptCardcb
            // 
            this.rptCardcb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rptCardcb.FormattingEnabled = true;
            this.rptCardcb.Items.AddRange(new object[] {
            "crystal",
            "Grade 1",
            "Grade 2",
            "Grade 3",
            "Grade 3-ILC",
            "Grade 4",
            "Grade 4-ILC",
            "Grade 5",
            "Grade 5-ILC",
            "Grade 6",
            "Grade 6-ILC",
            "Grade 7",
            "Grade 7-ILC",
            "Upper School I",
            "Upper School I-ILC",
            "Upper School II",
            "Upper School II-ILC",
            "Upper School III",
            "Upper School III-ILC",
            "Upper School IV",
            "Upper School IV-ILC"});
            this.rptCardcb.Location = new System.Drawing.Point(54, 35);
            this.rptCardcb.Name = "rptCardcb";
            this.rptCardcb.Size = new System.Drawing.Size(196, 21);
            this.rptCardcb.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose ReportCard to view:";
            // 
            // Confirmbtn
            // 
            this.Confirmbtn.Image = global::ReportCardGenerator.Properties.Resources.confirm;
            this.Confirmbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Confirmbtn.Location = new System.Drawing.Point(115, 75);
            this.Confirmbtn.Name = "Confirmbtn";
            this.Confirmbtn.Size = new System.Drawing.Size(68, 23);
            this.Confirmbtn.TabIndex = 1;
            this.Confirmbtn.Text = "Confirm";
            this.Confirmbtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Confirmbtn.UseVisualStyleBackColor = true;
            this.Confirmbtn.Click += new System.EventHandler(this.Confirmbtn_Click);
            // 
            // ReportCardOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 106);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Confirmbtn);
            this.Controls.Add(this.rptCardcb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportCardOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportCardOption";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox rptCardcb;
        private System.Windows.Forms.Button Confirmbtn;
        private System.Windows.Forms.Label label1;
    }
}