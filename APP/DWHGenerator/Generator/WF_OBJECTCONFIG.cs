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
    public partial class WF_OBJECTCONFIG : Form
    {
        SqlDataAdapter adapter = null;
        private static string strConn = ConfigurationManager.ConnectionStrings["Generator.Properties.Settings.METAConnectionString"].ConnectionString;
        DataSet dSet = null;


        public WF_OBJECTCONFIG()
        {
            InitializeComponent();
        }

        private void WF_OBJECTCONFIG_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("select * from GEN_LIST", strConn);
            dSet = new DataSet();
            adapter.Fill(dSet);

            dataGridView1.DataSource = dSet.Tables[0];
        }

        private void UPDATEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(adapter);

            try
            {
                adapter.Update(dSet);

                MessageBox.Show("Update done.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Update failed." + ex.Message);
            }
        }
    }
}
