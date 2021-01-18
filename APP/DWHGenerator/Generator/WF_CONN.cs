using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Generator
{
    public partial class WF_CONN : Form
    {
        public WF_CONN()
        {
            InitializeComponent();
        }

        private void WF_CONN_Load(object sender, EventArgs e)
        {
            tbConnstr.Text = ConfigurationManager.ConnectionStrings["Generator.Properties.Settings.METAConnectionString"].ConnectionString;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //ConfigurationManager.ConnectionStrings["Generator.Properties.Settings.METAConnectionString"].ConnectionString = tbConnstr.Text;

            //MessageBox.Show("Done");
        }
    }
}
