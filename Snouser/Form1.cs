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
            this.searchBox.Text = "search for something...";
            this.label_version.Text = s.GetCurrentTerminologyVersionUsed();
            this.label_lastupdated.Text = s.GetLastUpdateTime();
            
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
        
    }
}
