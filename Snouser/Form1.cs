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
            s.CreateNewDb();
            s.ImportData(@"C:\Users\MatthewCordell\Downloads\NCTS_SCT_RF2_DISTRIBUTION_32506021000036107-20160229-DELTA (1).zip");
            this.searchBox.Text = "import complete apparently";
        }
    }
}
