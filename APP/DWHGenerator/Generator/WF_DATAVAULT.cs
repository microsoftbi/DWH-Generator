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
    public partial class WF_DATAVAULT : Form
    {
        
        private static string strConn = ConfigurationManager.ConnectionStrings["Generator.Properties.Settings.METAConnectionString"].ConnectionString;
        DataSet dSetSAT = null;
        SqlDataAdapter adapterSAT = null;
        DataSet dSetHUB = null;
        SqlDataAdapter adapterHUB = null;
        DataSet dSetLINK = null;
        SqlDataAdapter adapterLINK = null;


        public WF_DATAVAULT()
        {
            InitializeComponent();
        }

        private void WF_DATAVAULT_Load(object sender, EventArgs e)
        {
            adapterSAT = new SqlDataAdapter("select * from DV_SAT", strConn);
            dSetSAT = new DataSet();
            adapterSAT.Fill(dSetSAT);
            adapterHUB = new SqlDataAdapter("select * from DV_HUB", strConn);
            dSetHUB = new DataSet();
            adapterHUB.Fill(dSetHUB);
            adapterLINK = new SqlDataAdapter("select * from DV_LINK", strConn);
            dSetLINK = new DataSet();
            adapterLINK.Fill(dSetLINK);

            dataGridView1.DataSource = dSetSAT.Tables[0];
            dataGridView2.DataSource = dSetHUB.Tables[0];
            dataGridView3.DataSource = dSetLINK.Tables[0];

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder scbSAT = new SqlCommandBuilder(adapterSAT);
            SqlCommandBuilder scbHUB = new SqlCommandBuilder(adapterHUB);
            SqlCommandBuilder scbLINK = new SqlCommandBuilder(adapterLINK);

            try
            {
                adapterSAT.Update(dSetSAT);
                adapterHUB.Update(dSetHUB);
                adapterLINK.Update(dSetLINK);

                MessageBox.Show("Done");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Failed." + ex.Message);
            }

            
        }
    }
}
