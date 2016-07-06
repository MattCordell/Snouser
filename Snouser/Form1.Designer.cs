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
            this.label_version = new System.Windows.Forms.Label();
            this.label_lastupdated = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_Update = new System.Windows.Forms.Button();
            this.checkbox_TotalUpdate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_version
            // 
            this.label_version.AutoSize = true;
            this.label_version.Location = new System.Drawing.Point(182, 556);
            this.label_version.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(140, 25);
            this.label_version.TabIndex = 2;
            this.label_version.Text = "version_label";
            // 
            // label_lastupdated
            // 
            this.label_lastupdated.AutoSize = true;
            this.label_lastupdated.Location = new System.Drawing.Point(182, 600);
            this.label_lastupdated.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_lastupdated.Name = "label_lastupdated";
            this.label_lastupdated.Size = new System.Drawing.Size(218, 25);
            this.label_lastupdated.TabIndex = 3;
            this.label_lastupdated.Text = "last_updated_version";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 556);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "current version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 600);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "last updated :  ";
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(24, 23);
            this.searchBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(904, 31);
            this.searchBox.TabIndex = 0;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Location = new System.Drawing.Point(24, 66);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.Size = new System.Drawing.Size(904, 451);
            this.dataGridView1.TabIndex = 6;
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(450, 590);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(302, 44);
            this.btn_Update.TabIndex = 7;
            this.btn_Update.Text = "button1";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // checkbox_TotalUpdate
            // 
            this.checkbox_TotalUpdate.AutoSize = true;
            this.checkbox_TotalUpdate.Location = new System.Drawing.Point(761, 599);
            this.checkbox_TotalUpdate.Name = "checkbox_TotalUpdate";
            this.checkbox_TotalUpdate.Size = new System.Drawing.Size(167, 29);
            this.checkbox_TotalUpdate.TabIndex = 8;
            this.checkbox_TotalUpdate.Text = "Total Update";
            this.checkbox_TotalUpdate.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 677);
            this.Controls.Add(this.checkbox_TotalUpdate);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_lastupdated);
            this.Controls.Add(this.label_version);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Snouser";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_version;
        private System.Windows.Forms.Label label_lastupdated;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.CheckBox checkbox_TotalUpdate;
    }
}

