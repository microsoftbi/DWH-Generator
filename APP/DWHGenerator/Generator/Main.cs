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
using System.IO;
using System.Threading;

namespace Generator
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            //Generate();
        }



        private void btnShowMETA_Click(object sender, EventArgs e)
        {
            WF_META winMeta = new WF_META();
            winMeta.ShowDialog();
        }





        //private void btnDeploy_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Common.ExecuteNonQueryWithGo(rtbContent.Text);

        //        MessageBox.Show("Script deployed successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Deploy Failed!\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void LbDV_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        switch (lbDV.SelectedIndex)
        //        {
        //            case 0:
        //                rtbContent.Text = DATAVAULT.GenerateTableSAT();
        //                break;
        //            case 1:
        //                rtbContent.Text = DATAVAULT.GenerateUSPSAT();
        //                break;
        //            case 2:
        //                rtbContent.Text = DATAVAULT.GenerateTableHUB();
        //                break;
        //            case 3:
        //                rtbContent.Text = DATAVAULT.GenerateUSPHUB();
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}





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
                MessageBox.Show("Failed!\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FULLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will make all new and existing table to be configed, are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataClassesDataContext dc = new DataClassesDataContext();

                try
                {
                    dc.ExecuteCommand("EXEC  META.dbo.USP_INIT_LIST");
                    MessageBox.Show("Done.\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed!\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WF_OBJECTCONFIG frmOC = new WF_OBJECTCONFIG();

            frmOC.ShowDialog();
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WF_META winMeta = new WF_META();
            winMeta.ShowDialog();
        }

        private void verifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WF_Verify frmVerify = new WF_Verify();
            frmVerify.ShowDialog();
        }

        private void showMETADBScriptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WF_METAScript frmMETA = new WF_METAScript();

            frmMETA.ShowDialog();
        }

        private void scriptInWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Common.ExecuteNonQueryWithGo(rtbContent.Text);

                MessageBox.Show("Script deployed successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Deploy Failed!\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pSAType2FlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm to deploy PSA Type 2 data flow?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    //Common.ExecuteNonQueryWithGo(PSA_TYPE2.GenerateTableSTG());
                    Common.ExecuteNonQueryWithGo(PSA_TYPE2.GenerateVIEWMTA());
                    Common.ExecuteNonQueryWithGo(PSA_TYPE2.GenerateTableCDC());
                    Common.ExecuteNonQueryWithGo(PSA_TYPE2.GenerateUSPCDC());
                    Common.ExecuteNonQueryWithGo(PSA_TYPE2.GenerateTableLOG());
                    Common.ExecuteNonQueryWithGo(PSA_TYPE2.GenerateVIECURRENT());
                    Common.ExecuteNonQueryWithGo(PSA_TYPE2.GenerateUSPLOG());

                    MessageBox.Show("PSA type 2 Data flow deploy done.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("PSA type 2 Data flow deploy Failed!\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void otherScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void executePSA1DataFlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strContent = "TBD";
            //rtbContent.Text = strContent;
        }

        private void executePSA2DataFlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string strContent = PSA_TYPE2.GenerateExecuteFlow();
            //rtbContent.Text = strContent;

            WF_METAScript frmScript = new WF_METAScript();
            frmScript.Script = PSA_TYPE2.GenerateExecuteFlow();
            frmScript.ShowDialog();
            
        }

        private void iMPORTSCHEMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //string strContent = File.ReadAllText(@"DEPLOY\IMPORT_SCHEMA.sql");
                //rtbContent.Text = strContent;

                WF_METAScript frmScript = new WF_METAScript();
                frmScript.Script = File.ReadAllText(@"DEPLOY\IMPORT_SCHEMA.sql");
                frmScript.ShowDialog();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Generate()
        {
            rtbT2ViewMETA.Text = PSA_TYPE2.GenerateVIEWMTA();
            rtbT2USPCDC.Text = PSA_TYPE2.GenerateUSPCDC();
            rtbT2TableCDC.Text = PSA_TYPE2.GenerateTableCDC();
            rtbT2TableLOG.Text = PSA_TYPE2.GenerateTableLOG();
            rtbT2USPLOG.Text = PSA_TYPE2.GenerateUSPLOG();
            rtbT2ViewCurrent.Text = PSA_TYPE2.GenerateVIECURRENT();

            rtbT1TableLanding.Text = PSA_TYPE1.GenerateLandingZone();
            rtbT1TableStage.Text = PSA_TYPE1.GenerateSTG();
            rtbT1USPStage.Text = PSA_TYPE1.GenerateUSPSTG();
            rtbT1TableHIS.Text = PSA_TYPE1.GenerateHIS();
            rtbT1USPHIS.Text = PSA_TYPE1.GenerateUSPHIS();
        }

        private void reGenerateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Thread.Sleep(2000);
            Generate();
            this.Enabled = true;

            MessageBox.Show("Done!");
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WF_METAScript frmScript = new WF_METAScript();
            frmScript.Script = "1219a";
            frmScript.ShowDialog();
        }

        private void gITURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WF_METAScript frmScript = new WF_METAScript();
            frmScript.Script = "https://github.com/microsoftbi/generator";
            frmScript.ShowDialog();
        }
    }
}
