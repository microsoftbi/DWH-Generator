namespace Generator
{
    partial class META
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tABLECATALOGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tABLENAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOLUMNNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dATATYPEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nUMERICPRECISIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nUMERICSCALEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dVIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aTTRIBUTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mETADataSet = new Generator.METADataSet();
            this.aTTRIBUTETableAdapter = new Generator.METADataSetTableAdapters.V_ATTRIBUTETableAdapter();
            this.vATTRIBUTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aTTRIBUTEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mETADataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vATTRIBUTEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.tABLECATALOGDataGridViewTextBoxColumn,
            this.tABLENAMEDataGridViewTextBoxColumn,
            this.cOLUMNNAMEDataGridViewTextBoxColumn,
            this.dATATYPEDataGridViewTextBoxColumn,
            this.cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn,
            this.nUMERICPRECISIONDataGridViewTextBoxColumn,
            this.nUMERICSCALEDataGridViewTextBoxColumn,
            this.bKDataGridViewTextBoxColumn,
            this.pKDataGridViewTextBoxColumn,
            this.dIDataGridViewTextBoxColumn,
            this.dVIDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.vATTRIBUTEBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1112, 812);
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
            // tABLECATALOGDataGridViewTextBoxColumn
            // 
            this.tABLECATALOGDataGridViewTextBoxColumn.DataPropertyName = "TABLE_CATALOG";
            this.tABLECATALOGDataGridViewTextBoxColumn.HeaderText = "TABLE_CATALOG";
            this.tABLECATALOGDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tABLECATALOGDataGridViewTextBoxColumn.Name = "tABLECATALOGDataGridViewTextBoxColumn";
            this.tABLECATALOGDataGridViewTextBoxColumn.Width = 125;
            // 
            // tABLENAMEDataGridViewTextBoxColumn
            // 
            this.tABLENAMEDataGridViewTextBoxColumn.DataPropertyName = "TABLE_NAME";
            this.tABLENAMEDataGridViewTextBoxColumn.HeaderText = "TABLE_NAME";
            this.tABLENAMEDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tABLENAMEDataGridViewTextBoxColumn.Name = "tABLENAMEDataGridViewTextBoxColumn";
            this.tABLENAMEDataGridViewTextBoxColumn.Width = 125;
            // 
            // cOLUMNNAMEDataGridViewTextBoxColumn
            // 
            this.cOLUMNNAMEDataGridViewTextBoxColumn.DataPropertyName = "COLUMN_NAME";
            this.cOLUMNNAMEDataGridViewTextBoxColumn.HeaderText = "COLUMN_NAME";
            this.cOLUMNNAMEDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cOLUMNNAMEDataGridViewTextBoxColumn.Name = "cOLUMNNAMEDataGridViewTextBoxColumn";
            this.cOLUMNNAMEDataGridViewTextBoxColumn.Width = 125;
            // 
            // dATATYPEDataGridViewTextBoxColumn
            // 
            this.dATATYPEDataGridViewTextBoxColumn.DataPropertyName = "DATA_TYPE";
            this.dATATYPEDataGridViewTextBoxColumn.HeaderText = "DATA_TYPE";
            this.dATATYPEDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dATATYPEDataGridViewTextBoxColumn.Name = "dATATYPEDataGridViewTextBoxColumn";
            this.dATATYPEDataGridViewTextBoxColumn.Width = 125;
            // 
            // cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn
            // 
            this.cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn.DataPropertyName = "CHARACTER_MAXIMUM_LENGTH";
            this.cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn.HeaderText = "CHARACTER_MAXIMUM_LENGTH";
            this.cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn.Name = "cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn";
            this.cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn.Width = 125;
            // 
            // nUMERICPRECISIONDataGridViewTextBoxColumn
            // 
            this.nUMERICPRECISIONDataGridViewTextBoxColumn.DataPropertyName = "NUMERIC_PRECISION";
            this.nUMERICPRECISIONDataGridViewTextBoxColumn.HeaderText = "NUMERIC_PRECISION";
            this.nUMERICPRECISIONDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nUMERICPRECISIONDataGridViewTextBoxColumn.Name = "nUMERICPRECISIONDataGridViewTextBoxColumn";
            this.nUMERICPRECISIONDataGridViewTextBoxColumn.Width = 125;
            // 
            // nUMERICSCALEDataGridViewTextBoxColumn
            // 
            this.nUMERICSCALEDataGridViewTextBoxColumn.DataPropertyName = "NUMERIC_SCALE";
            this.nUMERICSCALEDataGridViewTextBoxColumn.HeaderText = "NUMERIC_SCALE";
            this.nUMERICSCALEDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nUMERICSCALEDataGridViewTextBoxColumn.Name = "nUMERICSCALEDataGridViewTextBoxColumn";
            this.nUMERICSCALEDataGridViewTextBoxColumn.Width = 125;
            // 
            // bKDataGridViewTextBoxColumn
            // 
            this.bKDataGridViewTextBoxColumn.DataPropertyName = "BK";
            this.bKDataGridViewTextBoxColumn.HeaderText = "BK";
            this.bKDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.bKDataGridViewTextBoxColumn.Name = "bKDataGridViewTextBoxColumn";
            this.bKDataGridViewTextBoxColumn.Width = 125;
            // 
            // pKDataGridViewTextBoxColumn
            // 
            this.pKDataGridViewTextBoxColumn.DataPropertyName = "PK";
            this.pKDataGridViewTextBoxColumn.HeaderText = "PK";
            this.pKDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pKDataGridViewTextBoxColumn.Name = "pKDataGridViewTextBoxColumn";
            this.pKDataGridViewTextBoxColumn.Width = 125;
            // 
            // dIDataGridViewTextBoxColumn
            // 
            this.dIDataGridViewTextBoxColumn.DataPropertyName = "DI";
            this.dIDataGridViewTextBoxColumn.HeaderText = "DI";
            this.dIDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dIDataGridViewTextBoxColumn.Name = "dIDataGridViewTextBoxColumn";
            this.dIDataGridViewTextBoxColumn.Width = 125;
            // 
            // dVIDDataGridViewTextBoxColumn
            // 
            this.dVIDDataGridViewTextBoxColumn.DataPropertyName = "DVID";
            this.dVIDDataGridViewTextBoxColumn.HeaderText = "DVID";
            this.dVIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dVIDDataGridViewTextBoxColumn.Name = "dVIDDataGridViewTextBoxColumn";
            this.dVIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // aTTRIBUTEBindingSource
            // 
            this.aTTRIBUTEBindingSource.DataMember = "V_ATTRIBUTE";
            this.aTTRIBUTEBindingSource.DataSource = this.mETADataSet;
            // 
            // mETADataSet
            // 
            this.mETADataSet.DataSetName = "METADataSet";
            this.mETADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aTTRIBUTETableAdapter
            // 
            this.aTTRIBUTETableAdapter.ClearBeforeFill = true;
            // 
            // vATTRIBUTEBindingSource
            // 
            this.vATTRIBUTEBindingSource.DataMember = "V_ATTRIBUTE";
            this.vATTRIBUTEBindingSource.DataSource = this.mETADataSet;
            // 
            // META
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 812);
            this.Controls.Add(this.dataGridView1);
            this.Name = "META";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "META";
            this.Load += new System.EventHandler(this.META_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aTTRIBUTEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mETADataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vATTRIBUTEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private METADataSet mETADataSet;
        private System.Windows.Forms.BindingSource aTTRIBUTEBindingSource;
        private METADataSetTableAdapters.V_ATTRIBUTETableAdapter aTTRIBUTETableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tABLECATALOGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tABLENAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOLUMNNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATATYPEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHARACTERMAXIMUMLENGTHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nUMERICPRECISIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nUMERICSCALEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECORDSOURCE;
        private System.Windows.Forms.DataGridViewTextBoxColumn bKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dVIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource vATTRIBUTEBindingSource;
    }
}