using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Generator
{
    public partial class METAScript : Form
    {
        public METAScript()
        {
            InitializeComponent();

            string strContent = File.ReadAllText(@"DEPLOY\METADB.sql");
            rtbScript.Text = strContent;
        }
    }
}
