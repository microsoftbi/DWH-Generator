namespace Generator
{
    partial class Verify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Verify));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mETADataSet = new Generator.METADataSet();
            this.cONFIGVERIFYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cONFIG_VERIFYTableAdapter = new Generator.METADataSetTableAdapters.CONFIG_VERIFYTableAdapter();
            this.rESULTCONTENTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rESULTTYPEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mETADataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cONFIGVERIFYBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rESULTCONTENTDataGridViewTextBoxColumn,
            this.rESULTTYPEDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.cONFIGVERIFYBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(922, 567);
            this.dataGridView1.TabIndex = 0;
            // 
            // mETADataSet
            // 
            this.mETADataSet.DataSetName = "METADataSet";
            this.mETADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cONFIGVERIFYBindingSource
            // 
            this.cONFIGVERIFYBindingSource.DataMember = "CONFIG_VERIFY";
            this.cONFIGVERIFYBindingSource.DataSource = this.mETADataSet;
            // 
            // cONFIG_VERIFYTableAdapter
            // 
            this.cONFIG_VERIFYTableAdapter.ClearBeforeFill = true;
            // 
            // rESULTCONTENTDataGridViewTextBoxColumn
            // 
            this.rESULTCONTENTDataGridViewTextBoxColumn.DataPropertyName = "RESULTCONTENT";
            this.rESULTCONTENTDataGridViewTextBoxColumn.HeaderText = "RESULTCONTENT";
            this.rESULTCONTENTDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.rESULTCONTENTDataGridViewTextBoxColumn.Name = "rESULTCONTENTDataGridViewTextBoxColumn";
            this.rESULTCONTENTDataGridViewTextBoxColumn.ReadOnly = true;
            this.rESULTCONTENTDataGridViewTextBoxColumn.Width = 500;
            // 
            // rESULTTYPEDataGridViewTextBoxColumn
            // 
            this.rESULTTYPEDataGridViewTextBoxColumn.DataPropertyName = "RESULTTYPE";
            this.rESULTTYPEDataGridViewTextBoxColumn.HeaderText = "RESULTTYPE";
            this.rESULTTYPEDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.rESULTTYPEDataGridViewTextBoxColumn.Name = "rESULTTYPEDataGridViewTextBoxColumn";
            this.rESULTTYPEDataGridViewTextBoxColumn.ReadOnly = true;
            this.rESULTTYPEDataGridViewTextBoxColumn.Width = 125;
            // 
            // Verify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 567);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Verify";
            this.Text = "Verify";
            this.Load += new System.EventHandler(this.Verify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mETADataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cONFIGVERIFYBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private METADataSet mETADataSet;
        private System.Windows.Forms.BindingSource cONFIGVERIFYBindingSource;
        private METADataSetTableAdapters.CONFIG_VERIFYTableAdapter cONFIG_VERIFYTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn rESULTCONTENTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rESULTTYPEDataGridViewTextBoxColumn;
    }
}