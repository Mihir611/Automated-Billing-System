namespace Hi_Tech
{
    partial class VideoTur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoTur));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.nextVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastReverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.openVideoToolStripMenuItem,
            this.nextVideoToolStripMenuItem,
            this.previousVideoToolStripMenuItem,
            this.fastForwardToolStripMenuItem,
            this.fastReverseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(688, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Visible = false;
            // 
            // openVideoToolStripMenuItem
            // 
            this.openVideoToolStripMenuItem.Name = "openVideoToolStripMenuItem";
            this.openVideoToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.openVideoToolStripMenuItem.Text = "Open Video";
            this.openVideoToolStripMenuItem.Click += new System.EventHandler(this.openVideoToolStripMenuItem_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.AllowDrop = true;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 24);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(800, 425);
            this.axWindowsMediaPlayer1.TabIndex = 3;
            // 
            // nextVideoToolStripMenuItem
            // 
            this.nextVideoToolStripMenuItem.Name = "nextVideoToolStripMenuItem";
            this.nextVideoToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.nextVideoToolStripMenuItem.Text = "Next Video";
            this.nextVideoToolStripMenuItem.Click += new System.EventHandler(this.nextVideoToolStripMenuItem_Click);
            // 
            // previousVideoToolStripMenuItem
            // 
            this.previousVideoToolStripMenuItem.Name = "previousVideoToolStripMenuItem";
            this.previousVideoToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.previousVideoToolStripMenuItem.Text = "Previous video";
            this.previousVideoToolStripMenuItem.Click += new System.EventHandler(this.previousVideoToolStripMenuItem_Click);
            // 
            // fastForwardToolStripMenuItem
            // 
            this.fastForwardToolStripMenuItem.Name = "fastForwardToolStripMenuItem";
            this.fastForwardToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.fastForwardToolStripMenuItem.Text = "Fast Forward";
            this.fastForwardToolStripMenuItem.Click += new System.EventHandler(this.fastForwardToolStripMenuItem_Click);
            // 
            // fastReverseToolStripMenuItem
            // 
            this.fastReverseToolStripMenuItem.Name = "fastReverseToolStripMenuItem";
            this.fastReverseToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.fastReverseToolStripMenuItem.Text = "Fast Reverse";
            this.fastReverseToolStripMenuItem.Click += new System.EventHandler(this.fastReverseToolStripMenuItem_Click);
            // 
            // VideoTur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VideoTur";
            this.Text = "VideoTur";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openVideoToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.ToolStripMenuItem nextVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previousVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fastForwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fastReverseToolStripMenuItem;
    }
}