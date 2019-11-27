namespace Generator
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lbType1 = new System.Windows.Forms.ListBox();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.btnShowMETA = new System.Windows.Forms.Button();
            this.btnDeploy = new System.Windows.Forms.Button();
            this.lbType2 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblVer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbDV = new System.Windows.Forms.ListBox();
            this.btnGenerateMETADB = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbType1
            // 
            this.lbType1.FormattingEnabled = true;
            this.lbType1.ItemHeight = 16;
            this.lbType1.Items.AddRange(new object[] {
            "Table Landing Zone",
            "USP Stage",
            "Table Stage",
            "USP HIS",
            "Table HIS"});
            this.lbType1.Location = new System.Drawing.Point(1, 27);
            this.lbType1.Name = "lbType1";
            this.lbType1.Size = new System.Drawing.Size(159, 84);
            this.lbType1.TabIndex = 0;
            this.lbType1.SelectedIndexChanged += new System.EventHandler(this.lbType_SelectedIndexChanged);
            // 
            // rtbContent
            // 
            this.rtbContent.Location = new System.Drawing.Point(164, 5);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Size = new System.Drawing.Size(1185, 953);
            this.rtbContent.TabIndex = 1;
            this.rtbContent.Text = "";
            // 
            // btnShowMETA
            // 
            this.btnShowMETA.Location = new System.Drawing.Point(1, 449);
            this.btnShowMETA.Name = "btnShowMETA";
            this.btnShowMETA.Size = new System.Drawing.Size(159, 36);
            this.btnShowMETA.TabIndex = 2;
            this.btnShowMETA.Text = "Show META data";
            this.btnShowMETA.UseVisualStyleBackColor = true;
            this.btnShowMETA.Click += new System.EventHandler(this.btnShowMETA_Click);
            // 
            // btnDeploy
            // 
            this.btnDeploy.Location = new System.Drawing.Point(0, 824);
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Size = new System.Drawing.Size(157, 36);
            this.btnDeploy.TabIndex = 3;
            this.btnDeploy.Text = "Deploy";
            this.btnDeploy.UseVisualStyleBackColor = true;
            this.btnDeploy.Click += new System.EventHandler(this.btnDeploy_Click);
            // 
            // lbType2
            // 
            this.lbType2.FormattingEnabled = true;
            this.lbType2.ItemHeight = 16;
            this.lbType2.Items.AddRange(new object[] {
            "Table STG",
            "View MTA",
            "USP CDC",
            "Table CDC",
            "USP LOG",
            "Table LOG",
            "View Current"});
            this.lbType2.Location = new System.Drawing.Point(1, 164);
            this.lbType2.Name = "lbType2";
            this.lbType2.Size = new System.Drawing.Size(159, 116);
            this.lbType2.TabIndex = 4;
            this.lbType2.SelectedIndexChanged += new System.EventHandler(this.lbType2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "PSA Type 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-3, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "PSA Type 2";
            // 
            // lblVer
            // 
            this.lblVer.AutoSize = true;
            this.lblVer.Location = new System.Drawing.Point(2, 934);
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new System.Drawing.Size(48, 17);
            this.lblVer.TabIndex = 9;
            this.lblVer.Text = "1127a";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Data Vault";
            // 
            // lbDV
            // 
            this.lbDV.FormattingEnabled = true;
            this.lbDV.ItemHeight = 16;
            this.lbDV.Items.AddRange(new object[] {
            "Table SAT",
            "USP SAT",
            "Table HUB",
            "USP HUB"});
            this.lbDV.Location = new System.Drawing.Point(2, 342);
            this.lbDV.Name = "lbDV";
            this.lbDV.Size = new System.Drawing.Size(156, 84);
            this.lbDV.TabIndex = 12;
            this.lbDV.SelectedIndexChanged += new System.EventHandler(this.LbDV_SelectedIndexChanged);
            // 
            // btnGenerateMETADB
            // 
            this.btnGenerateMETADB.Location = new System.Drawing.Point(2, 728);
            this.btnGenerateMETADB.Name = "btnGenerateMETADB";
            this.btnGenerateMETADB.Size = new System.Drawing.Size(154, 37);
            this.btnGenerateMETADB.TabIndex = 13;
            this.btnGenerateMETADB.Text = "Generate META DB";
            this.btnGenerateMETADB.UseVisualStyleBackColor = true;
            this.btnGenerateMETADB.Click += new System.EventHandler(this.BtnGenerateMETADB_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(1, 688);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(155, 34);
            this.btnVerify.TabIndex = 14;
            this.btnVerify.Text = "CONFIG verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.BtnVerify_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 960);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.btnGenerateMETADB);
            this.Controls.Add(this.lbDV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblVer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbType2);
            this.Controls.Add(this.btnDeploy);
            this.Controls.Add(this.btnShowMETA);
            this.Controls.Add(this.rtbContent);
            this.Controls.Add(this.lbType1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PSA Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbType1;
        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.Button btnShowMETA;
        private System.Windows.Forms.Button btnDeploy;
        private System.Windows.Forms.ListBox lbType2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbDV;
        private System.Windows.Forms.Button btnGenerateMETADB;
        private System.Windows.Forms.Button btnVerify;
    }
}

