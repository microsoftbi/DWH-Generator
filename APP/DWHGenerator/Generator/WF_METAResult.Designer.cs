﻿namespace Generator
{
    partial class WF_METAResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WF_METAResult));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.vATTRIBUTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mETADataSet = new Generator.METADataSet();
            //this.v_ATTRIBUTETableAdapter = new Generator.METADataSetTableAdapters.V_ATTRIBUTETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vATTRIBUTEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mETADataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1196, 533);
            this.dataGridView1.TabIndex = 0;
            // 
            // vATTRIBUTEBindingSource
            // 
            this.vATTRIBUTEBindingSource.DataMember = "V_ATTRIBUTE";
            this.vATTRIBUTEBindingSource.DataSource = this.mETADataSet;
            // 
            // mETADataSet
            // 
            this.mETADataSet.DataSetName = "METADataSet";
            this.mETADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // v_ATTRIBUTETableAdapter
            // 
            //this.v_ATTRIBUTETableAdapter.ClearBeforeFill = true;
            // 
            // WF_METAResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 533);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "WF_METAResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "META config result";
            this.Load += new System.EventHandler(this.WF_METAResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vATTRIBUTEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mETADataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private METADataSet mETADataSet;
        private System.Windows.Forms.BindingSource vATTRIBUTEBindingSource;
        //private METADataSetTableAdapters.V_ATTRIBUTETableAdapter v_ATTRIBUTETableAdapter;
    }
}