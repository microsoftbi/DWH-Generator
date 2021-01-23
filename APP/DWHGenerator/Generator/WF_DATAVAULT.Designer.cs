namespace Generator
{
    partial class WF_DATAVAULT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WF_DATAVAULT));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dVSATBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mETADataSet = new Generator.METADataSet();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataVaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bKNAMEASDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dVHUBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dV_SATTableAdapter = new Generator.METADataSetTableAdapters.DV_SATTableAdapter();
            this.dV_HUBTableAdapter = new Generator.METADataSetTableAdapters.DV_HUBTableAdapter();
            this.dVLINKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dV_LINKTableAdapter = new Generator.METADataSetTableAdapters.DV_LINKTableAdapter();
            this.iDDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableNameDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dVSATBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mETADataSet)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dVHUBBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dVLINKBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(1039, 526);
            this.splitContainer1.SplitterDistance = 498;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.tableNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dVSATBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(309, 474);
            this.dataGridView1.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Width = 125;
            // 
            // tableNameDataGridViewTextBoxColumn
            // 
            this.tableNameDataGridViewTextBoxColumn.DataPropertyName = "TableName";
            this.tableNameDataGridViewTextBoxColumn.HeaderText = "TableName";
            this.tableNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tableNameDataGridViewTextBoxColumn.Name = "tableNameDataGridViewTextBoxColumn";
            this.tableNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // dVSATBindingSource
            // 
            this.dVSATBindingSource.DataMember = "DV_SAT";
            this.dVSATBindingSource.DataSource = this.mETADataSet;
            // 
            // mETADataSet
            // 
            this.mETADataSet.DataSetName = "METADataSet";
            this.mETADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataVaultToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1039, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataVaultToolStripMenuItem
            // 
            this.dataVaultToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem});
            this.dataVaultToolStripMenuItem.Name = "dataVaultToolStripMenuItem";
            this.dataVaultToolStripMenuItem.Size = new System.Drawing.Size(72, 22);
            this.dataVaultToolStripMenuItem.Text = "Data Vault";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn1,
            this.tableNameDataGridViewTextBoxColumn1,
            this.bKNAMEASDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.dVHUBBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(467, 474);
            this.dataGridView2.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn1
            // 
            this.iDDataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn1.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn1.Name = "iDDataGridViewTextBoxColumn1";
            this.iDDataGridViewTextBoxColumn1.Width = 125;
            // 
            // tableNameDataGridViewTextBoxColumn1
            // 
            this.tableNameDataGridViewTextBoxColumn1.DataPropertyName = "TableName";
            this.tableNameDataGridViewTextBoxColumn1.HeaderText = "TableName";
            this.tableNameDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.tableNameDataGridViewTextBoxColumn1.Name = "tableNameDataGridViewTextBoxColumn1";
            this.tableNameDataGridViewTextBoxColumn1.Width = 125;
            // 
            // bKNAMEASDataGridViewTextBoxColumn
            // 
            this.bKNAMEASDataGridViewTextBoxColumn.DataPropertyName = "BKNAMEAS";
            this.bKNAMEASDataGridViewTextBoxColumn.HeaderText = "BKNAMEAS";
            this.bKNAMEASDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.bKNAMEASDataGridViewTextBoxColumn.Name = "bKNAMEASDataGridViewTextBoxColumn";
            this.bKNAMEASDataGridViewTextBoxColumn.Width = 125;
            // 
            // dVHUBBindingSource
            // 
            this.dVHUBBindingSource.DataMember = "DV_HUB";
            this.dVHUBBindingSource.DataSource = this.mETADataSet;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn2,
            this.tableNameDataGridViewTextBoxColumn2});
            this.dataGridView3.DataSource = this.dVLINKBindingSource;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(0, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 23;
            this.dataGridView3.Size = new System.Drawing.Size(255, 474);
            this.dataGridView3.TabIndex = 0;
            // 
            // dV_SATTableAdapter
            // 
            this.dV_SATTableAdapter.ClearBeforeFill = true;
            // 
            // dV_HUBTableAdapter
            // 
            this.dV_HUBTableAdapter.ClearBeforeFill = true;
            // 
            // dVLINKBindingSource
            // 
            this.dVLINKBindingSource.DataMember = "DV_LINK";
            this.dVLINKBindingSource.DataSource = this.mETADataSet;
            // 
            // dV_LINKTableAdapter
            // 
            this.dV_LINKTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn2
            // 
            this.iDDataGridViewTextBoxColumn2.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn2.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn2.Name = "iDDataGridViewTextBoxColumn2";
            // 
            // tableNameDataGridViewTextBoxColumn2
            // 
            this.tableNameDataGridViewTextBoxColumn2.DataPropertyName = "TableName";
            this.tableNameDataGridViewTextBoxColumn2.HeaderText = "TableName";
            this.tableNameDataGridViewTextBoxColumn2.Name = "tableNameDataGridViewTextBoxColumn2";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 24);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(1039, 474);
            this.splitContainer3.SplitterDistance = 309;
            this.splitContainer3.TabIndex = 2;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.dataGridView2);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dataGridView3);
            this.splitContainer4.Size = new System.Drawing.Size(726, 474);
            this.splitContainer4.SplitterDistance = 467;
            this.splitContainer4.TabIndex = 0;
            // 
            // WF_DATAVAULT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 526);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WF_DATAVAULT";
            this.Text = "DATAVAULT";
            this.Load += new System.EventHandler(this.WF_DATAVAULT_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dVSATBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mETADataSet)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dVHUBBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dVLINKBindingSource)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private METADataSet mETADataSet;
        private System.Windows.Forms.BindingSource dVSATBindingSource;
        private METADataSetTableAdapters.DV_SATTableAdapter dV_SATTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource dVHUBBindingSource;
        private METADataSetTableAdapters.DV_HUBTableAdapter dV_HUBTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn bKNAMEASDataGridViewTextBoxColumn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataVaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.BindingSource dVLINKBindingSource;
        private METADataSetTableAdapters.DV_LINKTableAdapter dV_LINKTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableNameDataGridViewTextBoxColumn2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
    }
}