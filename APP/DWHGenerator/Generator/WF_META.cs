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
    public partial class WF_META : Form
    {
        SqlDataAdapter adapter = null;
        private static string strConn = ConfigurationManager.ConnectionStrings["Generator.Properties.Settings.METAConnectionString"].ConnectionString;
        DataSet dSet = null;

        public WF_META()
        {
            InitializeComponent();
        }

        private void META_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“mETADataSet.ATTRIBUTE”中。您可以根据需要移动或删除它。
            //this.aTTRIBUTETableAdapter.Fill(this.mETADataSet.V_ATTRIBUTE);


            adapter = new SqlDataAdapter("select * from ATTRIBUTE ATT WHERE ATT.[TABLE_CATALOG]+ATT.[TABLE_NAME] IN (SELECT  GEN.[TABLE_CATALOG]+GEN.[TABLE_NAME] FROM [META].[dbo].GEN_LIST GEN WHERE IS_GEN=1)", strConn);
            dSet = new DataSet();
            adapter.Fill(dSet);

            dataGridView1.DataSource = dSet.Tables[0];
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(adapter);

            try
            {
                adapter.Update(dSet);

                MessageBox.Show("META Update done.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("META Update failed." + ex.Message);
            }
        }

        private void ShowLayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WF_LAYERS frmLayers = new WF_LAYERS();
            frmLayers.ShowDialog();
        }

        private void ShowRecordSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WF_RECORDSOURCE frmRS = new WF_RECORDSOURCE();
            frmRS.ShowDialog();
        }

        private void ShowDVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WF_DATAVAULT frmDV = new WF_DATAVAULT();
            frmDV.ShowDialog();
        }

        private void ShowwMETAResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WF_METAResult frmMETAR = new WF_METAResult();
            frmMETAR.ShowDialog();
        }
    }
}
