namespace DSAS
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.tb_webhookurl = new System.Windows.Forms.TextBox();
            this.tb_scrfolder = new System.Windows.Forms.TextBox();
            this.l_webhookurl = new System.Windows.Forms.Label();
            this.l_scrfolder = new System.Windows.Forms.Label();
            this.b_browse = new System.Windows.Forms.Button();
            this.b_startstop = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trayMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.b_test = new System.Windows.Forms.Button();
            this.l_filter = new System.Windows.Forms.Label();
            this.tb_filter = new System.Windows.Forms.TextBox();
            this.trayMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_webhookurl
            // 
            resources.ApplyResources(this.tb_webhookurl, "tb_webhookurl");
            this.tb_webhookurl.Name = "tb_webhookurl";
            // 
            // tb_scrfolder
            // 
            resources.ApplyResources(this.tb_scrfolder, "tb_scrfolder");
            this.tb_scrfolder.Name = "tb_scrfolder";
            // 
            // l_webhookurl
            // 
            resources.ApplyResources(this.l_webhookurl, "l_webhookurl");
            this.l_webhookurl.Name = "l_webhookurl";
            // 
            // l_scrfolder
            // 
            resources.ApplyResources(this.l_scrfolder, "l_scrfolder");
            this.l_scrfolder.Name = "l_scrfolder";
            // 
            // b_browse
            // 
            resources.ApplyResources(this.b_browse, "b_browse");
            this.b_browse.Name = "b_browse";
            this.b_browse.UseVisualStyleBackColor = true;
            this.b_browse.Click += new System.EventHandler(this.b_browse_Click);
            // 
            // b_startstop
            // 
            resources.ApplyResources(this.b_startstop, "b_startstop");
            this.b_startstop.Name = "b_startstop";
            this.b_startstop.UseVisualStyleBackColor = true;
            this.b_startstop.Click += new System.EventHandler(this.b_startstop_Click);
            // 
            // folderBrowserDialog1
            // 
            resources.ApplyResources(this.folderBrowserDialog1, "folderBrowserDialog1");
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayMenuStrip;
            resources.ApplyResources(this.trayIcon, "trayIcon");
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // trayMenuStrip
            // 
            this.trayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuItem1,
            this.trayMenuItem2});
            this.trayMenuStrip.Name = "contextMenuStrip1";
            resources.ApplyResources(this.trayMenuStrip, "trayMenuStrip");
            // 
            // trayMenuItem1
            // 
            this.trayMenuItem1.Name = "trayMenuItem1";
            resources.ApplyResources(this.trayMenuItem1, "trayMenuItem1");
            this.trayMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // trayMenuItem2
            // 
            this.trayMenuItem2.Name = "trayMenuItem2";
            resources.ApplyResources(this.trayMenuItem2, "trayMenuItem2");
            this.trayMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // b_test
            // 
            resources.ApplyResources(this.b_test, "b_test");
            this.b_test.Name = "b_test";
            this.b_test.UseVisualStyleBackColor = true;
            this.b_test.Click += new System.EventHandler(this.b_test_Click);
            // 
            // l_filter
            // 
            resources.ApplyResources(this.l_filter, "l_filter");
            this.l_filter.Name = "l_filter";
            // 
            // tb_filter
            // 
            resources.ApplyResources(this.tb_filter, "tb_filter");
            this.tb_filter.Name = "tb_filter";
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tb_filter);
            this.Controls.Add(this.l_filter);
            this.Controls.Add(this.b_test);
            this.Controls.Add(this.b_startstop);
            this.Controls.Add(this.b_browse);
            this.Controls.Add(this.l_scrfolder);
            this.Controls.Add(this.l_webhookurl);
            this.Controls.Add(this.tb_scrfolder);
            this.Controls.Add(this.tb_webhookurl);
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.trayMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_webhookurl;
        private System.Windows.Forms.TextBox tb_scrfolder;
        private System.Windows.Forms.Label l_webhookurl;
        private System.Windows.Forms.Label l_scrfolder;
        private System.Windows.Forms.Button b_browse;
        private System.Windows.Forms.Button b_startstop;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem trayMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem trayMenuItem2;
        private System.Windows.Forms.Button b_test;
        private System.Windows.Forms.Label l_filter;
        private System.Windows.Forms.TextBox tb_filter;
    }
}

