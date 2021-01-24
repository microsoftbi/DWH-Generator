namespace Generator
{
    partial class WF_METAScript
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WF_METAScript));
            this.rtbScript = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbScript
            // 
            this.rtbScript.BackColor = System.Drawing.Color.Black;
            this.rtbScript.ForeColor = System.Drawing.Color.ForestGreen;
            this.rtbScript.Location = new System.Drawing.Point(0, -1);
            this.rtbScript.Margin = new System.Windows.Forms.Padding(2);
            this.rtbScript.Name = "rtbScript";
            this.rtbScript.Size = new System.Drawing.Size(632, 713);
            this.rtbScript.TabIndex = 0;
            this.rtbScript.Text = "";
            // 
            // WF_METAScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 256);
            this.Controls.Add(this.rtbScript);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WF_METAScript";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "METAScript";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbScript;
    }
}