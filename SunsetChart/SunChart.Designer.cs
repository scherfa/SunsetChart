namespace SunsetChart
{
    partial class SunChart
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            SunsetChart.CityPosition cityPosition1 = new SunsetChart.CityPosition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SunChart));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.sunsetPage = new System.Windows.Forms.TabPage();
            this.riseFallSunChartControl = new SunsetChart.SunChartControl();
            this.hoursPage = new System.Windows.Forms.TabPage();
            this.timeSunChartControl = new SunsetChart.SunChartControl();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileItems = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extraItems = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSummerTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemShowCurrentDay = new System.Windows.Forms.ToolStripMenuItem();
            this.helpItems = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCities = new System.Windows.Forms.ToolStripComboBox();
            this.mainPanel.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.sunsetPage.SuspendLayout();
            this.hoursPage.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainPanel.Controls.Add(this.mainTabControl);
            this.mainPanel.Controls.Add(this.menuStrip);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(620, 389);
            this.mainPanel.TabIndex = 1;
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.sunsetPage);
            this.mainTabControl.Controls.Add(this.hoursPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.ItemSize = new System.Drawing.Size(120, 24);
            this.mainTabControl.Location = new System.Drawing.Point(0, 27);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(620, 362);
            this.mainTabControl.TabIndex = 2;
            // 
            // sunsetPage
            // 
            this.sunsetPage.Controls.Add(this.riseFallSunChartControl);
            this.sunsetPage.Location = new System.Drawing.Point(4, 28);
            this.sunsetPage.Name = "sunsetPage";
            this.sunsetPage.Padding = new System.Windows.Forms.Padding(3);
            this.sunsetPage.Size = new System.Drawing.Size(612, 330);
            this.sunsetPage.TabIndex = 0;
            this.sunsetPage.Text = "Auf- & Untergang";
            this.sunsetPage.UseVisualStyleBackColor = true;
            // 
            // riseFallSunChartControl
            // 
            this.riseFallSunChartControl.CurrentDayColor = System.Drawing.Color.CadetBlue;
            this.riseFallSunChartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.riseFallSunChartControl.Location = new System.Drawing.Point(3, 3);
            this.riseFallSunChartControl.Name = "riseFallSunChartControl";
            cityPosition1.Caption = "";
            cityPosition1.Latitude = 0D;
            cityPosition1.Longitude = 0D;
            this.riseFallSunChartControl.Position = cityPosition1;
            this.riseFallSunChartControl.ShowCurrentDay = false;
            this.riseFallSunChartControl.ShowSunTime = false;
            this.riseFallSunChartControl.Size = new System.Drawing.Size(606, 324);
            this.riseFallSunChartControl.SummerWinterTime = false;
            this.riseFallSunChartControl.TabIndex = 0;
            // 
            // hoursPage
            // 
            this.hoursPage.Controls.Add(this.timeSunChartControl);
            this.hoursPage.Location = new System.Drawing.Point(4, 28);
            this.hoursPage.Name = "hoursPage";
            this.hoursPage.Padding = new System.Windows.Forms.Padding(3);
            this.hoursPage.Size = new System.Drawing.Size(612, 330);
            this.hoursPage.TabIndex = 1;
            this.hoursPage.Text = "Stunden";
            this.hoursPage.UseVisualStyleBackColor = true;
            // 
            // timeSunChartControl
            // 
            this.timeSunChartControl.CurrentDayColor = System.Drawing.Color.CadetBlue;
            this.timeSunChartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeSunChartControl.Location = new System.Drawing.Point(3, 3);
            this.timeSunChartControl.Name = "timeSunChartControl";
            this.timeSunChartControl.Position = null;
            this.timeSunChartControl.ShowCurrentDay = false;
            this.timeSunChartControl.ShowSunTime = false;
            this.timeSunChartControl.Size = new System.Drawing.Size(606, 324);
            this.timeSunChartControl.SummerWinterTime = false;
            this.timeSunChartControl.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileItems,
            this.extraItems,
            this.helpItems,
            this.toolStripCities});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(620, 27);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileItems
            // 
            this.fileItems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beendenToolStripMenuItem});
            this.fileItems.Name = "fileItems";
            this.fileItems.Size = new System.Drawing.Size(46, 23);
            this.fileItems.Text = "Datei";
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenMenuItem_Click);
            // 
            // extraItems
            // 
            this.extraItems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSummerTime,
            this.toolStripSeparator1,
            this.menuItemShowCurrentDay});
            this.extraItems.Name = "extraItems";
            this.extraItems.Size = new System.Drawing.Size(49, 23);
            this.extraItems.Text = "Extras";
            // 
            // menuItemSummerTime
            // 
            this.menuItemSummerTime.Name = "menuItemSummerTime";
            this.menuItemSummerTime.Size = new System.Drawing.Size(234, 22);
            this.menuItemSummerTime.Text = "Sommer-/Winterzeit beachten";
            this.menuItemSummerTime.Click += new System.EventHandler(this.menuItemSummerTime_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(231, 6);
            // 
            // menuItemShowCurrentDay
            // 
            this.menuItemShowCurrentDay.Name = "menuItemShowCurrentDay";
            this.menuItemShowCurrentDay.Size = new System.Drawing.Size(234, 22);
            this.menuItemShowCurrentDay.Text = "Aktuellen Tag anzeigen";
            this.menuItemShowCurrentDay.Click += new System.EventHandler(this.menuItemShowCurrentDay_Click);
            // 
            // helpItems
            // 
            this.helpItems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpItems.Name = "helpItems";
            this.helpItems.Size = new System.Drawing.Size(44, 23);
            this.helpItems.Text = "Hilfe";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(99, 22);
            this.aboutMenuItem.Text = "Über";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // toolStripCities
            // 
            this.toolStripCities.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripCities.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.toolStripCities.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.toolStripCities.Name = "toolStripCities";
            this.toolStripCities.Size = new System.Drawing.Size(121, 23);
            this.toolStripCities.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox_SelectedIndexChanged);
            // 
            // SunChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 389);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "SunChart";
            this.Text = "Sonnenzeiten";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SunChart_FormClosing);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.sunsetPage.ResumeLayout(false);
            this.hoursPage.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      
        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripComboBox toolStripCities;
        private System.Windows.Forms.ToolStripMenuItem extraItems;
        private System.Windows.Forms.ToolStripMenuItem helpItems;
        private System.Windows.Forms.ToolStripMenuItem menuItemSummerTime;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemShowCurrentDay;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage sunsetPage;
        private System.Windows.Forms.TabPage hoursPage;
        private SunChartControl timeSunChartControl;
        private SunChartControl riseFallSunChartControl;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileItems;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
    }
}

