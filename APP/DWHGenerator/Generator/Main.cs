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
                switch (lbType.SelectedIndex)
                {
                    case 0:
                        rtbContent.Text = PSA.GenerateLandingZone();
                        break;
                    case 1:
                        rtbContent.Text = PSA.GenerateUSPSTG();
                        break;
                    case 2:
                        rtbContent.Text = PSA.GenerateSTG();
                        break;
                    case 3:
                        rtbContent.Text = PSA.GenerateUSPHIS();
                        break;
                    case 4:
                        rtbContent.Text = PSA.GenerateHIS();
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
    }
}
