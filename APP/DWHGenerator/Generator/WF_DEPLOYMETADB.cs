using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generator
{
    public partial class WF_DEPLOYMETADB : Form
    {
        public WF_DEPLOYMETADB()
        {
            InitializeComponent();

            richTextBox1.Text = File.ReadAllText(@"DEPLOY\METADB.sql");
        }

        private void deployToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Start to deploy META database?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    
                    Common.ExecuteNonQueryWithGo(PSA_TYPE2.GenerateUSPLOG());

                    MessageBox.Show("META database deploy done!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("META databse deploy Failed!\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
