namespace StuffshopPOS
{
    partial class Print_Option
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
            this.PnSbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PnSbtn
            // 
            this.PnSbtn.Location = new System.Drawing.Point(26, 39);
            this.PnSbtn.Name = "PnSbtn";
            this.PnSbtn.Size = new System.Drawing.Size(75, 53);
            this.PnSbtn.TabIndex = 0;
            this.PnSbtn.Text = "Print && Save";
            this.PnSbtn.UseVisualStyleBackColor = true;
            this.PnSbtn.Click += new System.EventHandler(this.PnSbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(107, 39);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 53);
            this.savebtn.TabIndex = 1;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(188, 39);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 53);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // Print_Option
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 130);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.PnSbtn);
            this.Name = "Print_Option";
            this.Text = "Print_Option";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PnSbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}