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
    public partial class WF_RECORDSOURCE : Form
    {
        public WF_RECORDSOURCE()
        {
            InitializeComponent();
        }

        private void RECORDSOURCE_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“mETADataSet.RecordSource”中。您可以根据需要移动或删除它。
            this.recordSourceTableAdapter.Fill(this.mETADataSet.RecordSource);

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.recordSourceTableAdapter.Update(this.mETADataSet.RecordSource); ;

            MessageBox.Show("Done");
        }
    }
}
