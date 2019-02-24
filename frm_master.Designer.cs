namespace GasBottle_Application
{
    partial class frm_master
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::GasBottle_Application.mysplashscreen), true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_master));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.companyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companyInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.financialYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initialRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creatVendorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendorListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coustmerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creatCoustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coustomerListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottleTypeListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatePurchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignBottleNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acountStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottleStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coustomerStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initialRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companyToolStripMenuItem,
            this.initialRecordToolStripMenuItem,
            this.transactionToolStripMenuItem,
            this.acountStatementToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.windowsMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // companyToolStripMenuItem
            // 
            this.companyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companyInformationToolStripMenuItem,
            this.financialYearToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.companyToolStripMenuItem.Name = "companyToolStripMenuItem";
            this.companyToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.companyToolStripMenuItem.Text = "Company";
            // 
            // companyInformationToolStripMenuItem
            // 
            this.companyInformationToolStripMenuItem.Name = "companyInformationToolStripMenuItem";
            this.companyInformationToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.companyInformationToolStripMenuItem.Text = "Company Information";
            this.companyInformationToolStripMenuItem.Click += new System.EventHandler(this.companyInformationToolStripMenuItem_Click);
            // 
            // financialYearToolStripMenuItem
            // 
            this.financialYearToolStripMenuItem.Name = "financialYearToolStripMenuItem";
            this.financialYearToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.financialYearToolStripMenuItem.Text = "Financial Year";
            this.financialYearToolStripMenuItem.Click += new System.EventHandler(this.financialYearToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // initialRecordToolStripMenuItem
            // 
            this.initialRecordToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vendorToolStripMenuItem,
            this.coustmerToolStripMenuItem,
            this.bottleTypeListToolStripMenuItem});
            this.initialRecordToolStripMenuItem.Name = "initialRecordToolStripMenuItem";
            this.initialRecordToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.initialRecordToolStripMenuItem.Text = "Initial Record";
            this.initialRecordToolStripMenuItem.Click += new System.EventHandler(this.initialRecordToolStripMenuItem_Click);
            // 
            // vendorToolStripMenuItem
            // 
            this.vendorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creatVendorToolStripMenuItem,
            this.vendorListToolStripMenuItem});
            this.vendorToolStripMenuItem.Name = "vendorToolStripMenuItem";
            this.vendorToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.vendorToolStripMenuItem.Text = "Vendor";
            this.vendorToolStripMenuItem.Visible = false;
            this.vendorToolStripMenuItem.Click += new System.EventHandler(this.vendorToolStripMenuItem_Click);
            // 
            // creatVendorToolStripMenuItem
            // 
            this.creatVendorToolStripMenuItem.Name = "creatVendorToolStripMenuItem";
            this.creatVendorToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.creatVendorToolStripMenuItem.Text = "Creat Vendor";
            // 
            // vendorListToolStripMenuItem
            // 
            this.vendorListToolStripMenuItem.Name = "vendorListToolStripMenuItem";
            this.vendorListToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.vendorListToolStripMenuItem.Text = "Vendor List";
            // 
            // coustmerToolStripMenuItem
            // 
            this.coustmerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creatCoustomerToolStripMenuItem,
            this.coustomerListToolStripMenuItem});
            this.coustmerToolStripMenuItem.Name = "coustmerToolStripMenuItem";
            this.coustmerToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.coustmerToolStripMenuItem.Text = "Party";
            // 
            // creatCoustomerToolStripMenuItem
            // 
            this.creatCoustomerToolStripMenuItem.Name = "creatCoustomerToolStripMenuItem";
            this.creatCoustomerToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.creatCoustomerToolStripMenuItem.Text = "Creat party";
            this.creatCoustomerToolStripMenuItem.Click += new System.EventHandler(this.creatCoustomerToolStripMenuItem_Click);
            // 
            // coustomerListToolStripMenuItem
            // 
            this.coustomerListToolStripMenuItem.Name = "coustomerListToolStripMenuItem";
            this.coustomerListToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.coustomerListToolStripMenuItem.Text = "Party List";
            this.coustomerListToolStripMenuItem.Click += new System.EventHandler(this.coustomerListToolStripMenuItem_Click);
            // 
            // bottleTypeListToolStripMenuItem
            // 
            this.bottleTypeListToolStripMenuItem.Name = "bottleTypeListToolStripMenuItem";
            this.bottleTypeListToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.bottleTypeListToolStripMenuItem.Text = "Bottle Type List";
            this.bottleTypeListToolStripMenuItem.Click += new System.EventHandler(this.bottleTypeListToolStripMenuItem_Click);
            // 
            // transactionToolStripMenuItem
            // 
            this.transactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesToolStripMenuItem,
            this.purchaseToolStripMenuItem});
            this.transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
            this.transactionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.transactionToolStripMenuItem.Text = "Transaction";
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateSalesToolStripMenuItem,
            this.salesListToolStripMenuItem,
            this.salesDetailToolStripMenuItem});
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.salesToolStripMenuItem.Text = "Sales";
            // 
            // generateSalesToolStripMenuItem
            // 
            this.generateSalesToolStripMenuItem.Name = "generateSalesToolStripMenuItem";
            this.generateSalesToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.generateSalesToolStripMenuItem.Text = "New Chalan";
            this.generateSalesToolStripMenuItem.Click += new System.EventHandler(this.generateSalesToolStripMenuItem_Click);
            // 
            // salesListToolStripMenuItem
            // 
            this.salesListToolStripMenuItem.Name = "salesListToolStripMenuItem";
            this.salesListToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.salesListToolStripMenuItem.Text = "List Of Chalan";
            this.salesListToolStripMenuItem.Click += new System.EventHandler(this.salesListToolStripMenuItem_Click);
            // 
            // salesDetailToolStripMenuItem
            // 
            this.salesDetailToolStripMenuItem.Name = "salesDetailToolStripMenuItem";
            this.salesDetailToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.salesDetailToolStripMenuItem.Text = "Sales Detail";
            this.salesDetailToolStripMenuItem.Click += new System.EventHandler(this.salesDetailToolStripMenuItem_Click);
            // 
            // purchaseToolStripMenuItem
            // 
            this.purchaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generatePurchaseToolStripMenuItem,
            this.purchaseListToolStripMenuItem,
            this.assignBottleNumberToolStripMenuItem});
            this.purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
            this.purchaseToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.purchaseToolStripMenuItem.Text = "Purchase";
            this.purchaseToolStripMenuItem.Visible = false;
            // 
            // generatePurchaseToolStripMenuItem
            // 
            this.generatePurchaseToolStripMenuItem.Name = "generatePurchaseToolStripMenuItem";
            this.generatePurchaseToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.generatePurchaseToolStripMenuItem.Text = "Generate Purchase";
            // 
            // purchaseListToolStripMenuItem
            // 
            this.purchaseListToolStripMenuItem.Name = "purchaseListToolStripMenuItem";
            this.purchaseListToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.purchaseListToolStripMenuItem.Text = "Purchase List";
            // 
            // assignBottleNumberToolStripMenuItem
            // 
            this.assignBottleNumberToolStripMenuItem.Name = "assignBottleNumberToolStripMenuItem";
            this.assignBottleNumberToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.assignBottleNumberToolStripMenuItem.Text = "Assign Bottle Number";
            // 
            // acountStatementToolStripMenuItem
            // 
            this.acountStatementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bottleStatementToolStripMenuItem,
            this.coustomerStatementToolStripMenuItem});
            this.acountStatementToolStripMenuItem.Name = "acountStatementToolStripMenuItem";
            this.acountStatementToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.acountStatementToolStripMenuItem.Text = "Acount Statement";
            // 
            // bottleStatementToolStripMenuItem
            // 
            this.bottleStatementToolStripMenuItem.Name = "bottleStatementToolStripMenuItem";
            this.bottleStatementToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.bottleStatementToolStripMenuItem.Text = "Bottle Statement";
            this.bottleStatementToolStripMenuItem.Click += new System.EventHandler(this.bottleStatementToolStripMenuItem_Click);
            // 
            // coustomerStatementToolStripMenuItem
            // 
            this.coustomerStatementToolStripMenuItem.Name = "coustomerStatementToolStripMenuItem";
            this.coustomerStatementToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.coustomerStatementToolStripMenuItem.Text = "Party Statement";
            this.coustomerStatementToolStripMenuItem.Click += new System.EventHandler(this.coustomerStatementToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initialRecordsToolStripMenuItem,
            this.transactionToolStripMenuItem1});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // initialRecordsToolStripMenuItem
            // 
            this.initialRecordsToolStripMenuItem.Name = "initialRecordsToolStripMenuItem";
            this.initialRecordsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.initialRecordsToolStripMenuItem.Text = "Initial Records";
            // 
            // transactionToolStripMenuItem1
            // 
            this.transactionToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesToolStripMenuItem1,
            this.purchaseToolStripMenuItem1});
            this.transactionToolStripMenuItem1.Name = "transactionToolStripMenuItem1";
            this.transactionToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.transactionToolStripMenuItem1.Text = "Transaction";
            // 
            // salesToolStripMenuItem1
            // 
            this.salesToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dailyToolStripMenuItem,
            this.monthlyToolStripMenuItem});
            this.salesToolStripMenuItem1.Name = "salesToolStripMenuItem1";
            this.salesToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.salesToolStripMenuItem1.Text = "Party ";
            // 
            // dailyToolStripMenuItem
            // 
            this.dailyToolStripMenuItem.Name = "dailyToolStripMenuItem";
            this.dailyToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.dailyToolStripMenuItem.Text = "Daily";
            // 
            // monthlyToolStripMenuItem
            // 
            this.monthlyToolStripMenuItem.Name = "monthlyToolStripMenuItem";
            this.monthlyToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.monthlyToolStripMenuItem.Text = "Monthly";
            this.monthlyToolStripMenuItem.Click += new System.EventHandler(this.monthlyToolStripMenuItem_Click);
            // 
            // purchaseToolStripMenuItem1
            // 
            this.purchaseToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dailyToolStripMenuItem1,
            this.monthlyToolStripMenuItem1});
            this.purchaseToolStripMenuItem1.Name = "purchaseToolStripMenuItem1";
            this.purchaseToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.purchaseToolStripMenuItem1.Text = "Purchase";
            // 
            // dailyToolStripMenuItem1
            // 
            this.dailyToolStripMenuItem1.Name = "dailyToolStripMenuItem1";
            this.dailyToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.dailyToolStripMenuItem1.Text = "Daily";
            // 
            // monthlyToolStripMenuItem1
            // 
            this.monthlyToolStripMenuItem1.Name = "monthlyToolStripMenuItem1";
            this.monthlyToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.monthlyToolStripMenuItem1.Text = "Monthly";
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowToolStripMenuItem,
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem});
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(68, 20);
            this.windowsMenu.Text = "&Windows";
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.newWindowToolStripMenuItem.Text = "&New Window";
            this.newWindowToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.cascadeToolStripMenuItem.Text = "&Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.closeAllToolStripMenuItem.Text = "C&lose All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.arrangeIconsToolStripMenuItem.Text = "&Arrange Icons";
            this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.ArrangeIconsToolStripMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator8,
            this.aboutToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(44, 20);
            this.helpMenu.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("indexToolStripMenuItem.Image")));
            this.indexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripMenuItem.Image")));
            this.searchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(165, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.aboutToolStripMenuItem.Text = "&About ... ...";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 425);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 309);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 116);
            this.panel1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pname,
            this.chno,
            this.pcode});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(632, 116);
            this.dataGridView1.TabIndex = 0;
            // 
            // pname
            // 
            this.pname.DataPropertyName = "party_name";
            this.pname.HeaderText = "Party Name";
            this.pname.Name = "pname";
            this.pname.ReadOnly = true;
            // 
            // chno
            // 
            this.chno.DataPropertyName = "chalan_no";
            this.chno.HeaderText = "Chalan Number";
            this.chno.Name = "chno";
            this.chno.ReadOnly = true;
            // 
            // pcode
            // 
            this.pcode.DataPropertyName = "_party_id";
            this.pcode.HeaderText = "Party Code";
            this.pcode.Name = "pcode";
            this.pcode.ReadOnly = true;
            // 
            // frm_master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GasBottle_Application.Properties.Resources.Cylinder_Manegment_System;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(632, 447);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frm_master";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gas Bottle Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_master_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem companyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companyInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem initialRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creatVendorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendorListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coustmerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creatCoustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coustomerListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateSalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatePurchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignBottleNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acountStatementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bottleStatementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coustomerStatementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem initialRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dailyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dailyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem monthlyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bottleTypeListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem financialYearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesDetailToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname;
        private System.Windows.Forms.DataGridViewTextBoxColumn chno;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcode;
    }
}



