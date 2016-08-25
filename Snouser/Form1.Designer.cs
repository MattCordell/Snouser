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
            this.btn_Update = new System.Windows.Forms.Button();
            this.checkbox_TotalUpdate = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_version
            // 
            this.label_version.AutoSize = true;
            this.label_version.Location = new System.Drawing.Point(91, 289);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(69, 13);
            this.label_version.TabIndex = 2;
            this.label_version.Text = "version_label";
            // 
            // label_lastupdated
            // 
            this.label_lastupdated.AutoSize = true;
            this.label_lastupdated.Location = new System.Drawing.Point(91, 312);
            this.label_lastupdated.Name = "label_lastupdated";
            this.label_lastupdated.Size = new System.Drawing.Size(108, 13);
            this.label_lastupdated.TabIndex = 3;
            this.label_lastupdated.Text = "last_updated_version";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "current version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "last updated :  ";
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(12, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(454, 20);
            this.searchBox.TabIndex = 0;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            this.searchBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.searchBox_MouseDown);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(225, 307);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(151, 23);
            this.btn_Update.TabIndex = 7;
            this.btn_Update.Text = "button1";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // checkbox_TotalUpdate
            // 
            this.checkbox_TotalUpdate.AutoSize = true;
            this.checkbox_TotalUpdate.Location = new System.Drawing.Point(380, 311);
            this.checkbox_TotalUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkbox_TotalUpdate.Name = "checkbox_TotalUpdate";
            this.checkbox_TotalUpdate.Size = new System.Drawing.Size(88, 17);
            this.checkbox_TotalUpdate.TabIndex = 8;
            this.checkbox_TotalUpdate.Text = "Total Update";
            this.checkbox_TotalUpdate.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Location = new System.Drawing.Point(14, 40);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(450, 239);
            this.dataGridView1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 352);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.checkbox_TotalUpdate);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_lastupdated);
            this.Controls.Add(this.label_version);
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
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.CheckBox checkbox_TotalUpdate;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

