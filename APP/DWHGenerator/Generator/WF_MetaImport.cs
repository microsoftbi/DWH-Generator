using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generator
{
    public partial class WF_MetaImport : Form
    {
        private string PSAName = "";
        
        public WF_MetaImport()
        {
            InitializeComponent();

            PSAName = Common.GetPSADatabaseName();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            btnLoad.Enabled = false;

            string strSchemaName = "";
            string strTableName = "";

            //Check input
            if (tbTableName.Text.Contains(".") == false)
            {
                MessageBox.Show("Format is not correct!");
                return;
            }

            strSchemaName = tbTableName.Text.Split('.')[0].Replace("[", "").Replace("]", "");
            strTableName = tbTableName.Text.Split('.')[1].Replace("[", "").Replace("]", "");

            StringBuilder sbsql = new StringBuilder();
            sbsql.AppendLine("SELECT");
            sbsql.AppendLine("'"+strSchemaName+"' AS TABLE_CATALOG,TABLE_NAME,COLUMN_NAME,DATA_TYPE,");
            sbsql.AppendLine("CHARACTER_MAXIMUM_LENGTH,NUMERIC_PRECISION,NUMERIC_SCALE");
            sbsql.AppendLine("FROM "+PSAName+".INFORMATION_SCHEMA.COLUMNS");
            sbsql.AppendLine("WHERE TABLE_NAME IN ('"+strTableName+"') --AND COLUMN_NAME NOT IN ('FULLY_QUALIFIED_FILE_NAME','FILE_TRANSFER_DTS','LOAD_DTS','REC_SRC')");

            StringBuilder sbsqlverify = new StringBuilder();
            sbsqlverify.AppendLine("SELECT COUNT(1)");
            sbsqlverify.AppendLine("FROM " + PSAName + ".INFORMATION_SCHEMA.COLUMNS");
            sbsqlverify.AppendLine("WHERE TABLE_SCHEMA='"+strSchemaName+"' AND TABLE_NAME IN ('" + strTableName + "') AND COLUMN_NAME IN ('FULLY_QUALIFIED_FILE_NAME','FILE_TRANSFER_DTS','LOAD_DTS','REC_SRC')");

            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Generator.Properties.Settings.METAConnectionString"].ConnectionString;
                conn.Open();

                //Check if already exist in META
                SqlCommand commverifyexist = new SqlCommand("SELECT COUNT(1) FROM META.DBO.ATTRIBUTE WHERE TABLE_CATALOG='"+strSchemaName+"' AND TABLE_NAME='"+strTableName+"'", conn);
                int i = (int)commverifyexist.ExecuteScalar();
                if (i > 0)
                {
                    MessageBox.Show(strTableName+" already existed in current META database.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Load schame to datagridview
                SqlCommand comm = new SqlCommand(sbsql.ToString(), conn);
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(comm);
                sda.Fill(ds);  //ds=sda.Fill(ds);
                dgvMETA.DataSource = ds.Tables[0];

                //Verify PSA fields
                SqlCommand commverify = new SqlCommand(sbsqlverify.ToString(), conn);
                i = (int)commverify.ExecuteScalar();

                if (i != 4)
                {
                    MessageBox.Show("Table verify failed! Check if PSA fieds created.","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Table verified! you can proceed to import.","OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnLoad.Enabled = true;
                tbTableName.Enabled = false;

                //MessageBox.Show("Script deployed successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verify failed to be executed!\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string strSchemaName = "";
            string strTableName = "";

            strSchemaName = tbTableName.Text.Split('.')[0].Replace("[", "").Replace("]", "");
            strTableName = tbTableName.Text.Split('.')[1].Replace("[", "").Replace("]", "");

            StringBuilder sbsql = new StringBuilder();
            sbsql.AppendLine("INSERT INTO META.DBO.ATTRIBUTE");
            sbsql.AppendLine("(TABLE_CATALOG,TABLE_NAME,COLUMN_NAME,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,NUMERIC_PRECISION,NUMERIC_SCALE,DI)");
            sbsql.AppendLine("SELECT");
            sbsql.AppendLine("'" + strSchemaName + "' AS TABLE_CATALOG,TABLE_NAME,COLUMN_NAME,DATA_TYPE,");
            sbsql.AppendLine("CHARACTER_MAXIMUM_LENGTH,NUMERIC_PRECISION,NUMERIC_SCALE,1");
            sbsql.AppendLine("FROM " + PSAName + ".INFORMATION_SCHEMA.COLUMNS");
            sbsql.AppendLine("WHERE TABLE_NAME IN ('" + strTableName + "') AND COLUMN_NAME NOT IN ('FULLY_QUALIFIED_FILE_NAME','FILE_TRANSFER_DTS','LOAD_DTS','REC_SRC')");

            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Generator.Properties.Settings.METAConnectionString"].ConnectionString;
                conn.Open();

                SqlCommand comm = new SqlCommand(sbsql.ToString(), conn);
                comm.ExecuteNonQuery();

                MessageBox.Show(strTableName+" meta data imported!", "DONE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Verify failed to be executed!\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
