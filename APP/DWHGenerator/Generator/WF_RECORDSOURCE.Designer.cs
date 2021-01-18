namespace Generator
{
    partial class WF_RECORDSOURCE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WF_RECORDSOURCE));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordSourceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.databaseNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordSourceDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordSourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mETADataSet = new Generator.METADataSet();
            this.recordSourceTableAdapter = new Generator.METADataSetTableAdapters.RecordSourceTableAdapter();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.recordSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordSourceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mETADataSet)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.recordSourceNameDataGridViewTextBoxColumn,
            this.databaseNameDataGridViewTextBoxColumn,
            this.recordSourceDescDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.recordSourceBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(900, 516);
            this.dataGridView1.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 125;
            // 
            // recordSourceNameDataGridViewTextBoxColumn
            // 
            this.recordSourceNameDataGridViewTextBoxColumn.DataPropertyName = "RecordSourceName";
            this.recordSourceNameDataGridViewTextBoxColumn.HeaderText = "RecordSourceName";
            this.recordSourceNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.recordSourceNameDataGridViewTextBoxColumn.Name = "recordSourceNameDataGridViewTextBoxColumn";
            this.recordSourceNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // databaseNameDataGridViewTextBoxColumn
            // 
            this.databaseNameDataGridViewTextBoxColumn.DataPropertyName = "DatabaseName";
            this.databaseNameDataGridViewTextBoxColumn.HeaderText = "DatabaseName";
            this.databaseNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.databaseNameDataGridViewTextBoxColumn.Name = "databaseNameDataGridViewTextBoxColumn";
            this.databaseNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // recordSourceDescDataGridViewTextBoxColumn
            // 
            this.recordSourceDescDataGridViewTextBoxColumn.DataPropertyName = "RecordSourceDesc";
            this.recordSourceDescDataGridViewTextBoxColumn.HeaderText = "RecordSourceDesc";
            this.recordSourceDescDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.recordSourceDescDataGridViewTextBoxColumn.Name = "recordSourceDescDataGridViewTextBoxColumn";
            this.recordSourceDescDataGridViewTextBoxColumn.Width = 125;
            // 
            // recordSourceBindingSource
            // 
            this.recordSourceBindingSource.DataMember = "RecordSource";
            this.recordSourceBindingSource.DataSource = this.mETADataSet;
            // 
            // mETADataSet
            // 
            this.mETADataSet.DataSetName = "METADataSet";
            this.mETADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // recordSourceTableAdapter
            // 
            this.recordSourceTableAdapter.ClearBeforeFill = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recordSourceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(900, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // recordSourceToolStripMenuItem
            // 
            this.recordSourceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem});
            this.recordSourceToolStripMenuItem.Name = "recordSourceToolStripMenuItem";
            this.recordSourceToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.recordSourceToolStripMenuItem.Text = "Record Source";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // WF_RECORDSOURCE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 540);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WF_RECORDSOURCE";
            this.Text = "RECORDSOURCE";
            this.Load += new System.EventHandler(this.RECORDSOURCE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordSourceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mETADataSet)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private METADataSet mETADataSet;
        private System.Windows.Forms.BindingSource recordSourceBindingSource;
        private METADataSetTableAdapters.RecordSourceTableAdapter recordSourceTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordSourceNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn databaseNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordSourceDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem recordSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
    }
}