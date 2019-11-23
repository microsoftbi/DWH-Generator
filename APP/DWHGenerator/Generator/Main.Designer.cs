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
            this.btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbType1
            // 
            this.lbType1.FormattingEnabled = true;
            this.lbType1.ItemHeight = 12;
            this.lbType1.Items.AddRange(new object[] {
            "Table Landing Zone",
            "USP Stage",
            "Table Stage",
            "USP HIS",
            "Table HIS"});
            this.lbType1.Location = new System.Drawing.Point(1, 20);
            this.lbType1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbType1.Name = "lbType1";
            this.lbType1.Size = new System.Drawing.Size(120, 64);
            this.lbType1.TabIndex = 0;
            this.lbType1.SelectedIndexChanged += new System.EventHandler(this.lbType_SelectedIndexChanged);
            // 
            // rtbContent
            // 
            this.rtbContent.Location = new System.Drawing.Point(123, 4);
            this.rtbContent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Size = new System.Drawing.Size(890, 692);
            this.rtbContent.TabIndex = 1;
            this.rtbContent.Text = "";
            // 
            // btnShowMETA
            // 
            this.btnShowMETA.Location = new System.Drawing.Point(1, 226);
            this.btnShowMETA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnShowMETA.Name = "btnShowMETA";
            this.btnShowMETA.Size = new System.Drawing.Size(119, 27);
            this.btnShowMETA.TabIndex = 2;
            this.btnShowMETA.Text = "Show META data";
            this.btnShowMETA.UseVisualStyleBackColor = true;
            this.btnShowMETA.Click += new System.EventHandler(this.btnShowMETA_Click);
            // 
            // btnDeploy
            // 
            this.btnDeploy.Location = new System.Drawing.Point(1, 486);
            this.btnDeploy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Size = new System.Drawing.Size(118, 27);
            this.btnDeploy.TabIndex = 3;
            this.btnDeploy.Text = "Deploy";
            this.btnDeploy.UseVisualStyleBackColor = true;
            this.btnDeploy.Click += new System.EventHandler(this.btnDeploy_Click);
            // 
            // lbType2
            // 
            this.lbType2.FormattingEnabled = true;
            this.lbType2.ItemHeight = 12;
            this.lbType2.Items.AddRange(new object[] {
            "Table STG",
            "View MTA",
            "USP CDC",
            "Table CDC",
            "USP LOG",
            "Table LOG",
            "View Current"});
            this.lbType2.Location = new System.Drawing.Point(1, 123);
            this.lbType2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbType2.Name = "lbType2";
            this.lbType2.Size = new System.Drawing.Size(120, 88);
            this.lbType2.TabIndex = 4;
            this.lbType2.SelectedIndexChanged += new System.EventHandler(this.lbType2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "PSA Type 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-2, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "PSA Type 2";
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(1, 258);
            this.btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(119, 29);
            this.btn.TabIndex = 7;
            this.btn.Text = "Show Layers";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1, 292);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "Show RecordSource";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 676);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbType2);
            this.Controls.Add(this.btnDeploy);
            this.Controls.Add(this.btnShowMETA);
            this.Controls.Add(this.rtbContent);
            this.Controls.Add(this.lbType1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button button1;
    }
}

