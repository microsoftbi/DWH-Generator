using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Generator
{
    public partial class WF_DATAVAULT : Form
    {
        public WF_DATAVAULT()
        {
            InitializeComponent();
        }

        private void WF_DATAVAULT_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mETADataSet.DV_LINK' table. You can move, or remove it, as needed.
            this.dV_LINKTableAdapter.Fill(this.mETADataSet.DV_LINK);
            // TODO: This line of code loads data into the 'mETADataSet.DV_HUB' table. You can move, or remove it, as needed.
            this.dV_HUBTableAdapter.Fill(this.mETADataSet.DV_HUB);
            // TODO: This line of code loads data into the 'mETADataSet.DV_SAT' table. You can move, or remove it, as needed.
            this.dV_SATTableAdapter.Fill(this.mETADataSet.DV_SAT);

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dV_HUBTableAdapter.Update(this.mETADataSet.DV_HUB);
            this.dV_SATTableAdapter.Update(this.mETADataSet.DV_SAT);

            MessageBox.Show("Done");
        }
    }
}
