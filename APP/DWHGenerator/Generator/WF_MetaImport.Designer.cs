namespace Generator
{
    partial class WF_MetaImport
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbTableName = new System.Windows.Forms.TextBox();
            this.dgvMETA = new System.Windows.Forms.DataGridView();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMETA)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Provide table name, to import to META database.";
            // 
            // tbTableName
            // 
            this.tbTableName.Location = new System.Drawing.Point(12, 60);
            this.tbTableName.Name = "tbTableName";
            this.tbTableName.Size = new System.Drawing.Size(286, 21);
            this.tbTableName.TabIndex = 1;
            // 
            // dgvMETA
            // 
            this.dgvMETA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMETA.Location = new System.Drawing.Point(13, 107);
            this.dgvMETA.Name = "dgvMETA";
            this.dgvMETA.ReadOnly = true;
            this.dgvMETA.RowTemplate.Height = 23;
            this.dgvMETA.Size = new System.Drawing.Size(826, 463);
            this.dgvMETA.TabIndex = 2;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(469, 12);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(147, 77);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Text = "Check table meta";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Enabled = false;
            this.btnLoad.Location = new System.Drawing.Point(692, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(147, 77);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load to META.";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // WF_MetaImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 582);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.dgvMETA);
            this.Controls.Add(this.tbTableName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WF_MetaImport";
            this.Text = "WF_MetaImport";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMETA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTableName;
        private System.Windows.Forms.DataGridView dgvMETA;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnLoad;
    }
}