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
            this.lbType = new System.Windows.Forms.ListBox();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.btnShowMETA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbType
            // 
            this.lbType.FormattingEnabled = true;
            this.lbType.ItemHeight = 15;
            this.lbType.Items.AddRange(new object[] {
            "Landing zone table",
            "USP Stage",
            "Stage table",
            "USP HIS",
            "HIS table"});
            this.lbType.Location = new System.Drawing.Point(12, 12);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(292, 79);
            this.lbType.TabIndex = 0;
            this.lbType.SelectedIndexChanged += new System.EventHandler(this.lbType_SelectedIndexChanged);
            // 
            // rtbContent
            // 
            this.rtbContent.Location = new System.Drawing.Point(10, 110);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Size = new System.Drawing.Size(1017, 600);
            this.rtbContent.TabIndex = 1;
            this.rtbContent.Text = "";
            // 
            // btnShowMETA
            // 
            this.btnShowMETA.Location = new System.Drawing.Point(688, 12);
            this.btnShowMETA.Name = "btnShowMETA";
            this.btnShowMETA.Size = new System.Drawing.Size(279, 34);
            this.btnShowMETA.TabIndex = 2;
            this.btnShowMETA.Text = "Show META";
            this.btnShowMETA.UseVisualStyleBackColor = true;
            this.btnShowMETA.Click += new System.EventHandler(this.btnShowMETA_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 722);
            this.Controls.Add(this.btnShowMETA);
            this.Controls.Add(this.rtbContent);
            this.Controls.Add(this.lbType);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbType;
        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.Button btnShowMETA;
    }
}

