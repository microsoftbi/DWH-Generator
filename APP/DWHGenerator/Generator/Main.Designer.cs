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
            this.lbType1 = new System.Windows.Forms.ListBox();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.btnShowMETA = new System.Windows.Forms.Button();
            this.btnDeploy = new System.Windows.Forms.Button();
            this.lbType2 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbType1
            // 
            this.lbType1.FormattingEnabled = true;
            this.lbType1.ItemHeight = 15;
            this.lbType1.Items.AddRange(new object[] {
            "Table Landing Zone",
            "USP Stage",
            "Table Stage",
            "USP HIS",
            "Table HIS"});
            this.lbType1.Location = new System.Drawing.Point(1, 25);
            this.lbType1.Name = "lbType1";
            this.lbType1.Size = new System.Drawing.Size(159, 79);
            this.lbType1.TabIndex = 0;
            this.lbType1.SelectedIndexChanged += new System.EventHandler(this.lbType_SelectedIndexChanged);
            // 
            // rtbContent
            // 
            this.rtbContent.Location = new System.Drawing.Point(164, 5);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Size = new System.Drawing.Size(1186, 864);
            this.rtbContent.TabIndex = 1;
            this.rtbContent.Text = "";
            // 
            // btnShowMETA
            // 
            this.btnShowMETA.Location = new System.Drawing.Point(1, 282);
            this.btnShowMETA.Name = "btnShowMETA";
            this.btnShowMETA.Size = new System.Drawing.Size(148, 34);
            this.btnShowMETA.TabIndex = 2;
            this.btnShowMETA.Text = "Show META data";
            this.btnShowMETA.UseVisualStyleBackColor = true;
            this.btnShowMETA.Click += new System.EventHandler(this.btnShowMETA_Click);
            // 
            // btnDeploy
            // 
            this.btnDeploy.Enabled = false;
            this.btnDeploy.Location = new System.Drawing.Point(1, 322);
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Size = new System.Drawing.Size(148, 34);
            this.btnDeploy.TabIndex = 3;
            this.btnDeploy.Text = "Deploy";
            this.btnDeploy.UseVisualStyleBackColor = true;
            // 
            // lbType2
            // 
            this.lbType2.FormattingEnabled = true;
            this.lbType2.ItemHeight = 15;
            this.lbType2.Items.AddRange(new object[] {
            "Table STG",
            "View MTA",
            "USP CDC",
            "Table CDC",
            "USP LOG",
            "Table LOG",
            "View Current"});
            this.lbType2.Location = new System.Drawing.Point(1, 154);
            this.lbType2.Name = "lbType2";
            this.lbType2.Size = new System.Drawing.Size(159, 109);
            this.lbType2.TabIndex = 4;
            this.lbType2.SelectedIndexChanged += new System.EventHandler(this.lbType2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "PSA Type 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-2, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "PSA Type 2";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 869);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbType2);
            this.Controls.Add(this.btnDeploy);
            this.Controls.Add(this.btnShowMETA);
            this.Controls.Add(this.rtbContent);
            this.Controls.Add(this.lbType1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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
    }
}

