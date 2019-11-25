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
    public partial class META : Form
    {
        public META()
        {
            InitializeComponent();
        }

        private void META_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“mETADataSet.ATTRIBUTE”中。您可以根据需要移动或删除它。
            this.aTTRIBUTETableAdapter.Fill(this.mETADataSet.V_ATTRIBUTE);

        }
    }
}
