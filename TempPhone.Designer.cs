namespace TempPhone
{
    partial class TempPhone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TempPhone));
            this.cbNumbersList = new System.Windows.Forms.ComboBox();
            this.lvMessages = new System.Windows.Forms.ListView();
            this.colTimestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.numberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshNumbersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byNumbersjsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshIntervalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbRefreshInterval = new System.Windows.Forms.ToolStripComboBox();
            this.startWithWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startMinimizedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.favoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copySenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.trayMenu.SuspendLayout();
            this.copyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbNumbersList
            // 
            this.cbNumbersList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbNumbersList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNumbersList.FormattingEnabled = true;
            this.cbNumbersList.Location = new System.Drawing.Point(12, 27);
            this.cbNumbersList.Name = "cbNumbersList";
            this.cbNumbersList.Size = new System.Drawing.Size(570, 21);
            this.cbNumbersList.TabIndex = 0;
            this.cbNumbersList.SelectedIndexChanged += new System.EventHandler(this.cbNumbersList_SelectedIndexChanged);
            // 
            // lvMessages
            // 
            this.lvMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTimestamp,
            this.colSender,
            this.colMessage});
            this.lvMessages.FullRowSelect = true;
            this.lvMessages.HideSelection = false;
            this.lvMessages.Location = new System.Drawing.Point(12, 54);
            this.lvMessages.Name = "lvMessages";
            this.lvMessages.Size = new System.Drawing.Size(570, 312);
            this.lvMessages.TabIndex = 1;
            this.lvMessages.UseCompatibleStateImageBehavior = false;
            this.lvMessages.View = System.Windows.Forms.View.Details;
            this.lvMessages.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvMessages_MouseClick);
            // 
            // colTimestamp
            // 
            this.colTimestamp.Tag = "";
            this.colTimestamp.Text = "Recieved";
            this.colTimestamp.Width = 150;
            // 
            // colSender
            // 
            this.colSender.Tag = "";
            this.colSender.Text = "Sender";
            this.colSender.Width = 100;
            // 
            // colMessage
            // 
            this.colMessage.Tag = "";
            this.colMessage.Text = "Message";
            this.colMessage.Width = 1000;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.numberToolStripMenuItem,
            this.selectedToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(594, 24);
            this.menu.TabIndex = 2;
            this.menu.Text = "Menu";
            // 
            // numberToolStripMenuItem
            // 
            this.numberToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.numberToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshNumbersToolStripMenuItem,
            this.refreshIntervalToolStripMenuItem,
            this.startWithWindowsToolStripMenuItem,
            this.startMinimizedToolStripMenuItem});
            this.numberToolStripMenuItem.Name = "numberToolStripMenuItem";
            this.numberToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.numberToolStripMenuItem.Text = "Main";
            // 
            // refreshNumbersToolStripMenuItem
            // 
            this.refreshNumbersToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.refreshNumbersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byAPIToolStripMenuItem,
            this.byNumbersjsonToolStripMenuItem});
            this.refreshNumbersToolStripMenuItem.Name = "refreshNumbersToolStripMenuItem";
            this.refreshNumbersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.refreshNumbersToolStripMenuItem.Text = "Refresh Numbers";
            // 
            // byAPIToolStripMenuItem
            // 
            this.byAPIToolStripMenuItem.Name = "byAPIToolStripMenuItem";
            this.byAPIToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.byAPIToolStripMenuItem.Text = "By API";
            this.byAPIToolStripMenuItem.Click += new System.EventHandler(this.byAPIToolStripMenuItem_Click);
            // 
            // byNumbersjsonToolStripMenuItem
            // 
            this.byNumbersjsonToolStripMenuItem.Name = "byNumbersjsonToolStripMenuItem";
            this.byNumbersjsonToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.byNumbersjsonToolStripMenuItem.Text = "By Numbers.json";
            this.byNumbersjsonToolStripMenuItem.Click += new System.EventHandler(this.byNumbersjsonToolStripMenuItem_Click);
            // 
            // refreshIntervalToolStripMenuItem
            // 
            this.refreshIntervalToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.refreshIntervalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbRefreshInterval});
            this.refreshIntervalToolStripMenuItem.Name = "refreshIntervalToolStripMenuItem";
            this.refreshIntervalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.refreshIntervalToolStripMenuItem.Text = "Refresh Interval";
            // 
            // cbRefreshInterval
            // 
            this.cbRefreshInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRefreshInterval.Items.AddRange(new object[] {
            "1 second",
            "5 seconds",
            "10 seconds",
            "20 seconds",
            "30 seconds",
            "60 seconds",
            "120 seconds",
            "300 seconds"});
            this.cbRefreshInterval.Name = "cbRefreshInterval";
            this.cbRefreshInterval.Size = new System.Drawing.Size(121, 23);
            this.cbRefreshInterval.SelectedIndexChanged += new System.EventHandler(this.cbRefreshInterval_SelectedIndexChanged);
            // 
            // startWithWindowsToolStripMenuItem
            // 
            this.startWithWindowsToolStripMenuItem.CheckOnClick = true;
            this.startWithWindowsToolStripMenuItem.Name = "startWithWindowsToolStripMenuItem";
            this.startWithWindowsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startWithWindowsToolStripMenuItem.Text = "Start with Windows";
            this.startWithWindowsToolStripMenuItem.Click += new System.EventHandler(this.startWithWindowsToolStripMenuItem_Click);
            // 
            // startMinimizedToolStripMenuItem
            // 
            this.startMinimizedToolStripMenuItem.CheckOnClick = true;
            this.startMinimizedToolStripMenuItem.Enabled = false;
            this.startMinimizedToolStripMenuItem.Name = "startMinimizedToolStripMenuItem";
            this.startMinimizedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startMinimizedToolStripMenuItem.Text = "Start Minimized";
            this.startMinimizedToolStripMenuItem.Click += new System.EventHandler(this.startMinimizedToolStripMenuItem_Click);
            // 
            // selectedToolStripMenuItem
            // 
            this.selectedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.favoriteToolStripMenuItem,
            this.logMessagesToolStripMenuItem,
            this.copyNumberToolStripMenuItem});
            this.selectedToolStripMenuItem.Enabled = false;
            this.selectedToolStripMenuItem.Name = "selectedToolStripMenuItem";
            this.selectedToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.selectedToolStripMenuItem.Text = "Number";
            // 
            // favoriteToolStripMenuItem
            // 
            this.favoriteToolStripMenuItem.CheckOnClick = true;
            this.favoriteToolStripMenuItem.Name = "favoriteToolStripMenuItem";
            this.favoriteToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.favoriteToolStripMenuItem.Text = "Favorite";
            this.favoriteToolStripMenuItem.Click += new System.EventHandler(this.favoriteToolStripMenuItem_Click);
            // 
            // logMessagesToolStripMenuItem
            // 
            this.logMessagesToolStripMenuItem.CheckOnClick = true;
            this.logMessagesToolStripMenuItem.Name = "logMessagesToolStripMenuItem";
            this.logMessagesToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.logMessagesToolStripMenuItem.Text = "Log Messages";
            this.logMessagesToolStripMenuItem.Click += new System.EventHandler(this.logMessagesToolStripMenuItem_Click);
            // 
            // copyNumberToolStripMenuItem
            // 
            this.copyNumberToolStripMenuItem.Name = "copyNumberToolStripMenuItem";
            this.copyNumberToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.copyNumberToolStripMenuItem.Text = "Copy Number";
            this.copyNumberToolStripMenuItem.Click += new System.EventHandler(this.copyNumberToolStripMenuItem_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "TempPhone";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(94, 26);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.quitToolStripMenuItem.Text = "Exit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // copyMenu
            // 
            this.copyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copySenderToolStripMenuItem,
            this.copyMessageToolStripMenuItem});
            this.copyMenu.Name = "contextMenuStrip1";
            this.copyMenu.ShowImageMargin = false;
            this.copyMenu.Size = new System.Drawing.Size(127, 48);
            // 
            // copySenderToolStripMenuItem
            // 
            this.copySenderToolStripMenuItem.Name = "copySenderToolStripMenuItem";
            this.copySenderToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.copySenderToolStripMenuItem.Text = "Copy Sender";
            this.copySenderToolStripMenuItem.Click += new System.EventHandler(this.copySenderToolStripMenuItem_Click);
            // 
            // copyMessageToolStripMenuItem
            // 
            this.copyMessageToolStripMenuItem.Name = "copyMessageToolStripMenuItem";
            this.copyMessageToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.copyMessageToolStripMenuItem.Text = "Copy Message";
            this.copyMessageToolStripMenuItem.Click += new System.EventHandler(this.copyMessageToolStripMenuItem_Click);
            // 
            // TempPhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 378);
            this.Controls.Add(this.lvMessages);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.cbNumbersList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "TempPhone";
            this.Text = "TempPhone";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TempPhone_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.TempPhone_Resize);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.trayMenu.ResumeLayout(false);
            this.copyMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbNumbersList;
        private System.Windows.Forms.ListView lvMessages;
        private System.Windows.Forms.ColumnHeader colTimestamp;
        private System.Windows.Forms.ColumnHeader colSender;
        private System.Windows.Forms.ColumnHeader colMessage;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem numberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshNumbersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byAPIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byNumbersjsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem favoriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logMessagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyNumberToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip copyMenu;
        private System.Windows.Forms.ToolStripMenuItem copySenderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshIntervalToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cbRefreshInterval;
        private System.Windows.Forms.ToolStripMenuItem startWithWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startMinimizedToolStripMenuItem;
    }
}

