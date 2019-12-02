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
            this.btnDeploy = new System.Windows.Forms.Button();
            this.lbType2 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbDV = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.objectListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fULLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mETADataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.showMETADBScriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deployToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptInWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pSAType1FlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pSAType2FlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.otherScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executePSA1DataFlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executePSA2DataFlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.iMPORTSCHEMAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
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
            this.lbType1.Location = new System.Drawing.Point(1, 88);
            this.lbType1.Name = "lbType1";
            this.lbType1.Size = new System.Drawing.Size(159, 84);
            this.lbType1.TabIndex = 0;
            this.lbType1.SelectedIndexChanged += new System.EventHandler(this.lbType_SelectedIndexChanged);
            // 
            // rtbContent
            // 
            this.rtbContent.Location = new System.Drawing.Point(164, 31);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Size = new System.Drawing.Size(1185, 927);
            this.rtbContent.TabIndex = 1;
            this.rtbContent.Text = "--Welcome to use PSA generator\n--Ver 1202a\n";
            // 
            // btnDeploy
            // 
            this.btnDeploy.Location = new System.Drawing.Point(0, 824);
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Size = new System.Drawing.Size(157, 36);
            this.btnDeploy.TabIndex = 3;
            this.btnDeploy.Text = "Deploy the script";
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
            this.lbType2.Location = new System.Drawing.Point(1, 224);
            this.lbType2.Name = "lbType2";
            this.lbType2.Size = new System.Drawing.Size(159, 116);
            this.lbType2.TabIndex = 4;
            this.lbType2.SelectedIndexChanged += new System.EventHandler(this.lbType2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "PSA Type 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-3, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "PSA Type 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 381);
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
            this.lbDV.Location = new System.Drawing.Point(3, 403);
            this.lbDV.Name = "lbDV";
            this.lbDV.Size = new System.Drawing.Size(156, 84);
            this.lbDV.TabIndex = 12;
            this.lbDV.SelectedIndexChanged += new System.EventHandler(this.LbDV_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.objectListToolStripMenuItem,
            this.mETADataToolStripMenuItem,
            this.deployToolStripMenuItem,
            this.scriptsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1353, 30);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // objectListToolStripMenuItem
            // 
            this.objectListToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fULLToolStripMenuItem,
            this.configToolStripMenuItem});
            this.objectListToolStripMenuItem.Name = "objectListToolStripMenuItem";
            this.objectListToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.objectListToolStripMenuItem.Text = "Object list";
            // 
            // fULLToolStripMenuItem
            // 
            this.fULLToolStripMenuItem.Name = "fULLToolStripMenuItem";
            this.fULLToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.fULLToolStripMenuItem.Text = "FULL";
            this.fULLToolStripMenuItem.Click += new System.EventHandler(this.FULLToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.configToolStripMenuItem.Text = "Config...";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.ConfigToolStripMenuItem_Click);
            // 
            // mETADataToolStripMenuItem
            // 
            this.mETADataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem,
            this.verifyToolStripMenuItem,
            this.toolStripMenuItem2,
            this.showMETADBScriptsToolStripMenuItem});
            this.mETADataToolStripMenuItem.Name = "mETADataToolStripMenuItem";
            this.mETADataToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.mETADataToolStripMenuItem.Text = "META data";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.configurationToolStripMenuItem.Text = "Configuration";
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem_Click);
            // 
            // verifyToolStripMenuItem
            // 
            this.verifyToolStripMenuItem.Name = "verifyToolStripMenuItem";
            this.verifyToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.verifyToolStripMenuItem.Text = "Verify";
            this.verifyToolStripMenuItem.Click += new System.EventHandler(this.verifyToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(237, 6);
            // 
            // showMETADBScriptsToolStripMenuItem
            // 
            this.showMETADBScriptsToolStripMenuItem.Name = "showMETADBScriptsToolStripMenuItem";
            this.showMETADBScriptsToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.showMETADBScriptsToolStripMenuItem.Text = "Show META DB scripts";
            this.showMETADBScriptsToolStripMenuItem.Click += new System.EventHandler(this.showMETADBScriptsToolStripMenuItem_Click);
            // 
            // deployToolStripMenuItem
            // 
            this.deployToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scriptInWindowToolStripMenuItem,
            this.pSAType1FlowToolStripMenuItem,
            this.pSAType2FlowToolStripMenuItem,
            this.toolStripMenuItem1,
            this.otherScriptToolStripMenuItem});
            this.deployToolStripMenuItem.Name = "deployToolStripMenuItem";
            this.deployToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.deployToolStripMenuItem.Text = "Deploy";
            // 
            // scriptInWindowToolStripMenuItem
            // 
            this.scriptInWindowToolStripMenuItem.Name = "scriptInWindowToolStripMenuItem";
            this.scriptInWindowToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.scriptInWindowToolStripMenuItem.Text = "Script in window";
            this.scriptInWindowToolStripMenuItem.Click += new System.EventHandler(this.scriptInWindowToolStripMenuItem_Click);
            // 
            // pSAType1FlowToolStripMenuItem
            // 
            this.pSAType1FlowToolStripMenuItem.Name = "pSAType1FlowToolStripMenuItem";
            this.pSAType1FlowToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.pSAType1FlowToolStripMenuItem.Text = "PSA Type1 flow";
            // 
            // pSAType2FlowToolStripMenuItem
            // 
            this.pSAType2FlowToolStripMenuItem.Name = "pSAType2FlowToolStripMenuItem";
            this.pSAType2FlowToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.pSAType2FlowToolStripMenuItem.Text = "PSA Type2 flow";
            this.pSAType2FlowToolStripMenuItem.Click += new System.EventHandler(this.pSAType2FlowToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(199, 6);
            // 
            // otherScriptToolStripMenuItem
            // 
            this.otherScriptToolStripMenuItem.Name = "otherScriptToolStripMenuItem";
            this.otherScriptToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.otherScriptToolStripMenuItem.Text = "Other script";
            this.otherScriptToolStripMenuItem.Click += new System.EventHandler(this.otherScriptToolStripMenuItem_Click);
            // 
            // scriptsToolStripMenuItem
            // 
            this.scriptsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executePSA1DataFlowToolStripMenuItem,
            this.executePSA2DataFlowToolStripMenuItem,
            this.toolStripMenuItem3,
            this.iMPORTSCHEMAToolStripMenuItem});
            this.scriptsToolStripMenuItem.Name = "scriptsToolStripMenuItem";
            this.scriptsToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.scriptsToolStripMenuItem.Text = "Scripts";
            // 
            // executePSA1DataFlowToolStripMenuItem
            // 
            this.executePSA1DataFlowToolStripMenuItem.Name = "executePSA1DataFlowToolStripMenuItem";
            this.executePSA1DataFlowToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.executePSA1DataFlowToolStripMenuItem.Text = "PSA1 data flow";
            this.executePSA1DataFlowToolStripMenuItem.Click += new System.EventHandler(this.executePSA1DataFlowToolStripMenuItem_Click);
            // 
            // executePSA2DataFlowToolStripMenuItem
            // 
            this.executePSA2DataFlowToolStripMenuItem.Name = "executePSA2DataFlowToolStripMenuItem";
            this.executePSA2DataFlowToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.executePSA2DataFlowToolStripMenuItem.Text = "PSA2 data flow";
            this.executePSA2DataFlowToolStripMenuItem.Click += new System.EventHandler(this.executePSA2DataFlowToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(204, 6);
            // 
            // iMPORTSCHEMAToolStripMenuItem
            // 
            this.iMPORTSCHEMAToolStripMenuItem.Name = "iMPORTSCHEMAToolStripMenuItem";
            this.iMPORTSCHEMAToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.iMPORTSCHEMAToolStripMenuItem.Text = "IMPORT SCHEMA";
            this.iMPORTSCHEMAToolStripMenuItem.Click += new System.EventHandler(this.iMPORTSCHEMAToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 964);
            this.Controls.Add(this.lbDV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbType2);
            this.Controls.Add(this.btnDeploy);
            this.Controls.Add(this.rtbContent);
            this.Controls.Add(this.lbType1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PSA Generator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbType1;
        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.Button btnDeploy;
        private System.Windows.Forms.ListBox lbType2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbDV;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem objectListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fULLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mETADataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deployToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptInWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pSAType1FlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pSAType2FlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem otherScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem showMETADBScriptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executePSA1DataFlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executePSA2DataFlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem iMPORTSCHEMAToolStripMenuItem;
    }
}

