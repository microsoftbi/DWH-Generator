using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeGenerator;

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
            META winMeta = new META();
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
    }
}
