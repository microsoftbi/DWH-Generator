using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Generator
{
    public partial class Verify : Form
    {
        public Verify()
        {
            InitializeComponent();
        }

        private void Verify_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Generator.Properties.Settings.METAConnectionString"].ConnectionString;
                conn.Open();

                SqlCommand comm = new SqlCommand(File.ReadAllText(@"DEPLOY\CONFIGVERIFY.sql"), conn);
                comm.ExecuteNonQuery();

                //MessageBox.Show("Script deployed successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verify failed to be executed!\n" + ex.Message);
            }


            // TODO: This line of code loads data into the 'mETADataSet.CONFIG_VERIFY' table. You can move, or remove it, as needed.
            this.cONFIG_VERIFYTableAdapter.Fill(this.mETADataSet.CONFIG_VERIFY);

        }
    }
}
