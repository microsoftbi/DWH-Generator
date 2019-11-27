namespace Generator
{
    partial class WF_META
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WF_META));
            this.vATTRIBUTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mETADataSet = new Generator.METADataSet();
            this.aTTRIBUTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aTTRIBUTETableAdapter = new Generator.METADataSetTableAdapters.V_ATTRIBUTETableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.showLayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showRecordSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.showwMETAResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.vATTRIBUTEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mETADataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aTTRIBUTEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            // aTTRIBUTEBindingSource
            // 
            this.aTTRIBUTEBindingSource.DataMember = "V_ATTRIBUTE";
            this.aTTRIBUTEBindingSource.DataSource = this.mETADataSet;
            // 
            // aTTRIBUTETableAdapter
            // 
            this.aTTRIBUTETableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1578, 784);
            this.dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1578, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.toolStripMenuItem2,
            this.showLayersToolStripMenuItem,
            this.showRecordSourceToolStripMenuItem,
            this.showDVToolStripMenuItem,
            this.toolStripMenuItem3,
            this.showwMETAResultToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(95, 24);
            this.toolStripMenuItem1.Text = "META data";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.UpdateToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(225, 6);
            // 
            // showLayersToolStripMenuItem
            // 
            this.showLayersToolStripMenuItem.Name = "showLayersToolStripMenuItem";
            this.showLayersToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.showLayersToolStripMenuItem.Text = "Show Layers";
            this.showLayersToolStripMenuItem.Click += new System.EventHandler(this.ShowLayersToolStripMenuItem_Click);
            // 
            // showRecordSourceToolStripMenuItem
            // 
            this.showRecordSourceToolStripMenuItem.Name = "showRecordSourceToolStripMenuItem";
            this.showRecordSourceToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.showRecordSourceToolStripMenuItem.Text = "Show Record Source";
            this.showRecordSourceToolStripMenuItem.Click += new System.EventHandler(this.ShowRecordSourceToolStripMenuItem_Click);
            // 
            // showDVToolStripMenuItem
            // 
            this.showDVToolStripMenuItem.Name = "showDVToolStripMenuItem";
            this.showDVToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.showDVToolStripMenuItem.Text = "Show DV";
            this.showDVToolStripMenuItem.Click += new System.EventHandler(this.ShowDVToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(225, 6);
            // 
            // showwMETAResultToolStripMenuItem
            // 
            this.showwMETAResultToolStripMenuItem.Name = "showwMETAResultToolStripMenuItem";
            this.showwMETAResultToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.showwMETAResultToolStripMenuItem.Text = "Showw META result";
            this.showwMETAResultToolStripMenuItem.Click += new System.EventHandler(this.ShowwMETAResultToolStripMenuItem_Click);
            // 
            // WF_META
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1578, 812);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WF_META";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "META";
            this.Load += new System.EventHandler(this.META_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vATTRIBUTEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mETADataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aTTRIBUTEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private METADataSet mETADataSet;
        private System.Windows.Forms.BindingSource aTTRIBUTEBindingSource;
        private METADataSetTableAdapters.V_ATTRIBUTETableAdapter aTTRIBUTETableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECORDSOURCE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dVIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource vATTRIBUTEBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem showLayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showRecordSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDVToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem showwMETAResultToolStripMenuItem;
    }
}