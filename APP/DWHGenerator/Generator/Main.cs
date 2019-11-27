using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Generator
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void lbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (lbType1.SelectedIndex)
                {
                    case 0:
                        rtbContent.Text = PSA_TYPE1.GenerateLandingZone();
                        break;
                    case 1:
                        rtbContent.Text = PSA_TYPE1.GenerateUSPSTG();
                        break;
                    case 2:
                        rtbContent.Text = PSA_TYPE1.GenerateSTG();
                        break;
                    case 3:
                        rtbContent.Text = PSA_TYPE1.GenerateUSPHIS();
                        break;
                    case 4:
                        rtbContent.Text = PSA_TYPE1.GenerateHIS();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowMETA_Click(object sender, EventArgs e)
        {
            WF_META winMeta = new WF_META();
            winMeta.ShowDialog();
        }

        private void lbType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (lbType2.SelectedIndex)
                {
                    case 0:
                        rtbContent.Text = PSA_TYPE2.GenerateTableSTG();
                        break;
                    case 1:
                        rtbContent.Text = PSA_TYPE2.GenerateVIEWMTA();
                        break;
                    case 2:
                        rtbContent.Text = PSA_TYPE2.GenerateUSPCDC();
                        break;
                    case 3:
                        rtbContent.Text = PSA_TYPE2.GenerateTableCDC();
                        break;
                    case 4:
                        rtbContent.Text = PSA_TYPE2.GenerateUSPLOG();
                        break;
                    case 5:
                        rtbContent.Text = PSA_TYPE2.GenerateTableLOG();
                        break;
                    case 6:
                        rtbContent.Text = PSA_TYPE2.GenerateVIECURRENT();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            WF_LAYERS frmLayers = new WF_LAYERS();
            frmLayers.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WF_RECORDSOURCE frmRS = new WF_RECORDSOURCE();
            frmRS.ShowDialog();
        }

        private void btnDeploy_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlConnection conn = new SqlConnection();
                //conn.ConnectionString = ConfigurationManager.ConnectionStrings["Generator.Properties.Settings.METAConnectionString"].ConnectionString;
                //conn.Open();

                //SqlCommand comm = new SqlCommand(rtbContent.Text, conn);
                //comm.ExecuteNonQuery();

                Common.ExecuteNonQueryWithGo(rtbContent.Text);

                MessageBox.Show("Script deployed successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Deploy Failed!\n" + ex.Message);
            }
        }

        private void LbDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
                switch (lbDV.SelectedIndex)
                {
                    case 0:
                        rtbContent.Text = DATAVAULT.GenerateTableSAT();
                        break;
                    case 1:
                        rtbContent.Text = DATAVAULT.GenerateUSPSAT();
                        break;
                    case 2:
                        rtbContent.Text = DATAVAULT.GenerateTableHUB();
                        break;
                    case 3:
                        rtbContent.Text = DATAVAULT.GenerateUSPHUB();
                        break;
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void BtnGenerateMETADB_Click(object sender, EventArgs e)
        {
            WF_METAScript frmMETA = new WF_METAScript();

            frmMETA.ShowDialog();
        }

        private void BtnVerify_Click(object sender, EventArgs e)
        {
            WF_Verify frmVerify = new WF_Verify();
            frmVerify.ShowDialog();
        }

        private void BtnGenList_Click(object sender, EventArgs e)
        {
            DataClassesDataContext dc = new DataClassesDataContext();

            try
            {
                dc.ExecuteCommand("EXEC  META.dbo.USP_INIT_LIST");
                MessageBox.Show("Done.\n");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed!\n" + ex.Message);
            }
        }

        private void FULLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataClassesDataContext dc = new DataClassesDataContext();

            try
            {
                dc.ExecuteCommand("EXEC  META.dbo.USP_INIT_LIST");
                MessageBox.Show("Done.\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed!\n" + ex.Message);
            }
        }

        private void ConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WF_OBJECTCONFIG frmOC = new WF_OBJECTCONFIG();

            frmOC.ShowDialog();
        }
    }
}
