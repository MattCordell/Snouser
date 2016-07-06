using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Snouser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.searchBox.Text = "search for something...";            
            UpdateUIelements();
        }

        private void UpdateUIelements()
        {
            SnouserDatabase s = new SnouserDatabase();
            SCTsyndication synd = new SCTsyndication();

            if (synd.IsUpToDate(s.GetCurrentTerminologyVersionUsed()))
            {
                btn_Update.Text = "All good!";
                btn_Update.Enabled = false;               
                btn_Update.BackColor = Color.LawnGreen;
                checkbox_TotalUpdate.Checked = false;
                checkbox_TotalUpdate.Enabled = false;
            }
            else
            {
                btn_Update.Text = "Update Available";
                btn_Update.Enabled = true;
                btn_Update.BackColor = Color.OrangeRed;
                checkbox_TotalUpdate.Enabled = true;
            }

            this.label_version.Text = s.GetCurrentTerminologyVersionUsed();
            this.label_lastupdated.Text = s.GetLastUpdateTime();

            this.Refresh();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            //searches only execute for 3 or more characters
            if (searchBox.Text.Length > 2)
            {
                SnouserDatabase s = new SnouserDatabase();
                DataView searchResults = new DataView(s.PerformSearch(searchBox.Text.Trim()));
                dataGridView1.DataSource = searchResults;
                //hide everything by default               
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.Visible = false;
                }
                //show the desired
                dataGridView1.Columns["term"].Visible = true;
                Console.WriteLine("searched");
                
            }

        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            SnouserDatabase sdb = new SnouserDatabase();
            SCTsyndication synd = new SCTsyndication();
            
            btn_Update.Text = "Updating...";
            btn_Update.Enabled = false;
            btn_Update.BackColor = Color.Cornsilk;
            this.UseWaitCursor = true;
            this.Refresh();            

            // perform a delta patch (inside the do)
            // keep doing this while not up to date, and checkbox marked
            do
            {
                string zipurl = synd.FetchDeltaURL(sdb.GetCurrentTerminologyVersionUsed());
                string zipversion = synd.FetchDeltaVersion(sdb.GetCurrentTerminologyVersionUsed());
                sdb.ImportZip(zipurl, zipversion);
            } while (!synd.IsUpToDate(sdb.GetCurrentTerminologyVersionUsed()) && checkbox_TotalUpdate.Checked);
                       
            this.UseWaitCursor = false;
            UpdateUIelements();
            this.Refresh();                                 
        }
    }
}
