namespace Snouser
{
    partial class Form1
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
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchResults = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(13, 13);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(241, 20);
            this.searchBox.TabIndex = 0;
            // 
            // searchResults
            // 
            this.searchResults.Location = new System.Drawing.Point(13, 40);
            this.searchResults.Name = "searchResults";
            this.searchResults.Size = new System.Drawing.Size(241, 198);
            this.searchResults.TabIndex = 1;
            this.searchResults.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 523);
            this.Controls.Add(this.searchResults);
            this.Controls.Add(this.searchBox);
            this.Name = "Form1";
            this.Text = "Snouser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ListView searchResults;
    }
}

