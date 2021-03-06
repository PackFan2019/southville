﻿namespace StudentInformation.Forms
{
    partial class TextViewer
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
            this.txtMainArea = new System.Windows.Forms.TextBox();
            this.btnCopyClipboard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMainArea
            // 
            this.txtMainArea.Location = new System.Drawing.Point(10, 12);
            this.txtMainArea.Multiline = true;
            this.txtMainArea.Name = "txtMainArea";
            this.txtMainArea.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMainArea.Size = new System.Drawing.Size(809, 341);
            this.txtMainArea.TabIndex = 0;
            // 
            // btnCopyClipboard
            // 
            this.btnCopyClipboard.Location = new System.Drawing.Point(641, 357);
            this.btnCopyClipboard.Name = "btnCopyClipboard";
            this.btnCopyClipboard.Size = new System.Drawing.Size(112, 23);
            this.btnCopyClipboard.TabIndex = 1;
            this.btnCopyClipboard.Text = "Copy to Clipboard";
            this.btnCopyClipboard.UseVisualStyleBackColor = true;
            this.btnCopyClipboard.Click += new System.EventHandler(this.btnCopyClipboard_Click);
            // 
            // TextViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 392);
            this.Controls.Add(this.btnCopyClipboard);
            this.Controls.Add(this.txtMainArea);
            this.Name = "TextViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TextViewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMainArea;
        private System.Windows.Forms.Button btnCopyClipboard;
    }
}