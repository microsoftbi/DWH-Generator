using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Generator
{
    public partial class WF_LAYERS : Form
    {
        public WF_LAYERS()
        {
            InitializeComponent();

            
        }

        private void LAYERS_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“mETADataSet.Layers”中。您可以根据需要移动或删除它。
            //this.layersTableAdapter.Fill(this.mETADataSet.Layers);

            tbPSA.Text = ConfigurationManager.AppSettings["PSA"];
            tbDV.Text = ConfigurationManager.AppSettings["DV"];

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings["PSA"] = tbPSA.Text;
            ConfigurationManager.AppSettings["DV"] = tbDV.Text;

            MessageBox.Show("Done");

            this.Close();
        }
    }
}
