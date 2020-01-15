using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Generator
{
    public partial class WF_METAResult : Form
    {
        SqlDataAdapter adapter = null;
        private static string strConn = ConfigurationManager.ConnectionStrings["Generator.Properties.Settings.METAConnectionString"].ConnectionString;
        DataSet dSet = null;

        public WF_METAResult()
        {
            InitializeComponent();
        }

        private void WF_METAResult_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mETADataSet.V_ATTRIBUTE' table. You can move, or remove it, as needed.
            //this.v_ATTRIBUTETableAdapter.Fill(this.mETADataSet.V_ATTRIBUTE);

            adapter = new SqlDataAdapter("select * from V_ATTRIBUTE", strConn);
            dSet = new DataSet();
            adapter.Fill(dSet);

            dataGridView1.DataSource = dSet.Tables[0];

        }
    }
}
