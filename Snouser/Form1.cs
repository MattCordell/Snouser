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

            SnouserDatabase s = new SnouserDatabase();
            SCTsyndication synd = new SCTsyndication();

            this.searchBox.Text = "search for something...";
            this.label_version.Text = s.GetCurrentTerminologyVersionUsed();
            this.label_lastupdated.Text = s.GetLastUpdateTime();
            

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
            SnouserDatabase s = new SnouserDatabase();
            SCTsyndication synd = new SCTsyndication();
            try
            {
                this.Text = "Updating...";
                string zipurl = synd.FetchDeltaURL(s.GetCurrentTerminologyVersionUsed());
                string zipversion = synd.FetchDeltaVersion(s.GetCurrentTerminologyVersionUsed());
                s.ImportZip(zipurl, zipversion);
            }
            catch (Exception)
            {

                throw;
            }
            
            this.Parent.Refresh();
        }
    }
}
