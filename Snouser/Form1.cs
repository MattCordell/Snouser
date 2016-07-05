using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            }
            else
            {
                btn_Update.Text = "Update Available";
                btn_Update.Enabled = true;
                btn_Update.BackColor = Color.OrangeRed;
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
            }

        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            SnouserDatabase sdb = new SnouserDatabase();
            SCTsyndication synd = new SCTsyndication();
            
            btn_Update.Text = "Updating...";
            btn_Update.Enabled = false;
            btn_Update.BackColor = Color.Cornsilk;
            UseWaitCursor = true;
            this.Refresh();
            string zipurl = synd.FetchDeltaURL(sdb.GetCurrentTerminologyVersionUsed());
            string zipversion = synd.FetchDeltaVersion(sdb.GetCurrentTerminologyVersionUsed());
            sdb.ImportZip(zipurl, zipversion);
            btn_Update.Text = "Update done";
            System.Threading.Thread.Sleep(10000);
            UseWaitCursor = false;
            UpdateUIelements();
            this.Refresh();                                 
        }
    }
}
