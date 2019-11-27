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
    public partial class WF_METAResult : Form
    {
        public WF_METAResult()
        {
            InitializeComponent();
        }

        private void WF_METAResult_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mETADataSet.V_ATTRIBUTE' table. You can move, or remove it, as needed.
            this.v_ATTRIBUTETableAdapter.Fill(this.mETADataSet.V_ATTRIBUTE);

        }
    }
}
