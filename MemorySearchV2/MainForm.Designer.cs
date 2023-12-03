
namespace MemorySearchV2
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.AppMenuPopup = new DevExpress.XtraBars.PopupMenu(this.components);
            this.SaveCheatTableButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.LoadCheatTableMenuItem = new DevExpress.XtraBars.BarButtonItem();
            this.ConnectButton = new DevExpress.XtraBars.BarButtonItem();
            this.AddToTableButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.ChangeValueButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.RemoveEntryButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.ClearResultsListButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.SaveShortListToJsonButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.SaveLongResultsListButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.ChangeValueTableMenuItem = new DevExpress.XtraBars.BarButtonItem();
            this.EditEntryTableMenuitem = new DevExpress.XtraBars.BarButtonItem();
            this.RemoveTableEntryMenuItem = new DevExpress.XtraBars.BarButtonItem();
            this.ClearCheatTableMenuItem = new DevExpress.XtraBars.BarButtonItem();
            this.ManuallyAddEntryMenuItem = new DevExpress.XtraBars.BarButtonItem();
            this.SaveTableButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.LoadTableButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.AutoConnect = new DevExpress.XtraBars.BarCheckItem();
            this.resultList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.resultListMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.tableList = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableListMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.RefreshValuesBox = new DevExpress.XtraEditors.CheckEdit();
            this.RefreshIntervalEdit = new DevExpress.XtraEditors.SpinEdit();
            this.LittleEndianBox = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pause = new DevExpress.XtraEditors.CheckEdit();
            this.isHex = new DevExpress.XtraEditors.CheckEdit();
            this.NextButton = new DevExpress.XtraEditors.SimpleButton();
            this.SearchButton = new DevExpress.XtraEditors.SimpleButton();
            this.dataType_ = new DevExpress.XtraEditors.ComboBoxEdit();
            this.valBox = new DevExpress.XtraEditors.TextEdit();
            this.sizeBox = new DevExpress.XtraEditors.TextEdit();
            this.addrBox = new DevExpress.XtraEditors.TextEdit();
            this.ResultsToDisplayInput = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::MemorySearchV2.WaitForm1), false, false);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppMenuPopup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultListMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableListMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshValuesBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshIntervalEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LittleEndianBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pause.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.isHex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataType_.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addrBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsToDisplayInput.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonDropDownControl = this.AppMenuPopup;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.ConnectButton,
            this.AddToTableButtonItem,
            this.ChangeValueButtonItem,
            this.RemoveEntryButtonItem,
            this.ClearResultsListButtonItem,
            this.SaveShortListToJsonButtonItem,
            this.SaveLongResultsListButtonItem,
            this.SaveCheatTableButtonItem,
            this.LoadCheatTableMenuItem,
            this.ChangeValueTableMenuItem,
            this.EditEntryTableMenuitem,
            this.RemoveTableEntryMenuItem,
            this.ClearCheatTableMenuItem,
            this.ManuallyAddEntryMenuItem,
            this.SaveTableButtonItem,
            this.LoadTableButtonItem,
            this.AutoConnect});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 18;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageHeaderItemLinks.Add(this.ConnectButton);
            this.ribbonControl1.PageHeaderItemLinks.Add(this.SaveTableButtonItem);
            this.ribbonControl1.PageHeaderItemLinks.Add(this.LoadTableButtonItem);
            this.ribbonControl1.PageHeaderItemLinks.Add(this.AutoConnect);
            this.ribbonControl1.Size = new System.Drawing.Size(580, 62);
            // 
            // AppMenuPopup
            // 
            this.AppMenuPopup.ItemLinks.Add(this.SaveCheatTableButtonItem);
            this.AppMenuPopup.ItemLinks.Add(this.LoadCheatTableMenuItem);
            this.AppMenuPopup.Name = "AppMenuPopup";
            this.AppMenuPopup.Ribbon = this.ribbonControl1;
            // 
            // SaveCheatTableButtonItem
            // 
            this.SaveCheatTableButtonItem.Caption = "Save Cheat Table";
            this.SaveCheatTableButtonItem.Id = 8;
            this.SaveCheatTableButtonItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SaveCheatTableButtonItem.ImageOptions.SvgImage")));
            this.SaveCheatTableButtonItem.Name = "SaveCheatTableButtonItem";
            this.SaveCheatTableButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SaveCheatTableButtonItem_ItemClick);
            // 
            // LoadCheatTableMenuItem
            // 
            this.LoadCheatTableMenuItem.Caption = "Load Cheat Table";
            this.LoadCheatTableMenuItem.Id = 9;
            this.LoadCheatTableMenuItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("LoadCheatTableMenuItem.ImageOptions.SvgImage")));
            this.LoadCheatTableMenuItem.Name = "LoadCheatTableMenuItem";
            this.LoadCheatTableMenuItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.LoadCheatTableMenuItem_ItemClick);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Caption = "Connect";
            this.ConnectButton.Id = 1;
            this.ConnectButton.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ConnectButton.ImageOptions.SvgImage")));
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ConnectButton_ItemClick);
            // 
            // AddToTableButtonItem
            // 
            this.AddToTableButtonItem.Caption = "Add To Table";
            this.AddToTableButtonItem.Id = 2;
            this.AddToTableButtonItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("AddToTableButtonItem.ImageOptions.SvgImage")));
            this.AddToTableButtonItem.Name = "AddToTableButtonItem";
            this.AddToTableButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.AddToTableButtonItem_ItemClick);
            // 
            // ChangeValueButtonItem
            // 
            this.ChangeValueButtonItem.Caption = "Change Value";
            this.ChangeValueButtonItem.Id = 3;
            this.ChangeValueButtonItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ChangeValueButtonItem.ImageOptions.SvgImage")));
            this.ChangeValueButtonItem.Name = "ChangeValueButtonItem";
            this.ChangeValueButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ChangeValueButtonItem_ItemClick);
            // 
            // RemoveEntryButtonItem
            // 
            this.RemoveEntryButtonItem.Caption = "Remove Entry";
            this.RemoveEntryButtonItem.Id = 4;
            this.RemoveEntryButtonItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("RemoveEntryButtonItem.ImageOptions.SvgImage")));
            this.RemoveEntryButtonItem.Name = "RemoveEntryButtonItem";
            this.RemoveEntryButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RemoveEntryButtonItem_ItemClick);
            // 
            // ClearResultsListButtonItem
            // 
            this.ClearResultsListButtonItem.Caption = "Clear List";
            this.ClearResultsListButtonItem.Id = 5;
            this.ClearResultsListButtonItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ClearResultsListButtonItem.ImageOptions.SvgImage")));
            this.ClearResultsListButtonItem.Name = "ClearResultsListButtonItem";
            this.ClearResultsListButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ClearResultsListButtonItem_ItemClick);
            // 
            // SaveShortListToJsonButtonItem
            // 
            this.SaveShortListToJsonButtonItem.Caption = "Save Displayed Results";
            this.SaveShortListToJsonButtonItem.Id = 6;
            this.SaveShortListToJsonButtonItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SaveShortListToJsonButtonItem.ImageOptions.SvgImage")));
            this.SaveShortListToJsonButtonItem.Name = "SaveShortListToJsonButtonItem";
            this.SaveShortListToJsonButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SaveShortListToJsonButtonItem_ItemClick);
            // 
            // SaveLongResultsListButtonItem
            // 
            this.SaveLongResultsListButtonItem.Caption = "Save Full Results List";
            this.SaveLongResultsListButtonItem.Id = 7;
            this.SaveLongResultsListButtonItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SaveLongResultsListButtonItem.ImageOptions.SvgImage")));
            this.SaveLongResultsListButtonItem.Name = "SaveLongResultsListButtonItem";
            this.SaveLongResultsListButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SaveLongResultsListButtonItem_ItemClick);
            // 
            // ChangeValueTableMenuItem
            // 
            this.ChangeValueTableMenuItem.Caption = "Change Value";
            this.ChangeValueTableMenuItem.Id = 10;
            this.ChangeValueTableMenuItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ChangeValueTableMenuItem.ImageOptions.SvgImage")));
            this.ChangeValueTableMenuItem.Name = "ChangeValueTableMenuItem";
            this.ChangeValueTableMenuItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ChangeValueTableMenuItem_ItemClick);
            // 
            // EditEntryTableMenuitem
            // 
            this.EditEntryTableMenuitem.Caption = "Edit Entry";
            this.EditEntryTableMenuitem.Id = 11;
            this.EditEntryTableMenuitem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("EditEntryTableMenuitem.ImageOptions.SvgImage")));
            this.EditEntryTableMenuitem.Name = "EditEntryTableMenuitem";
            this.EditEntryTableMenuitem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.EditEntryTableMenuitem_ItemClick);
            // 
            // RemoveTableEntryMenuItem
            // 
            this.RemoveTableEntryMenuItem.Caption = "Remove Entry";
            this.RemoveTableEntryMenuItem.Id = 12;
            this.RemoveTableEntryMenuItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("RemoveTableEntryMenuItem.ImageOptions.SvgImage")));
            this.RemoveTableEntryMenuItem.Name = "RemoveTableEntryMenuItem";
            this.RemoveTableEntryMenuItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RemoveTableEntryMenuItem_ItemClick);
            // 
            // ClearCheatTableMenuItem
            // 
            this.ClearCheatTableMenuItem.Caption = "Clear Cheat Table";
            this.ClearCheatTableMenuItem.Id = 13;
            this.ClearCheatTableMenuItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ClearCheatTableMenuItem.ImageOptions.SvgImage")));
            this.ClearCheatTableMenuItem.Name = "ClearCheatTableMenuItem";
            this.ClearCheatTableMenuItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ClearCheatTableMenuItem_ItemClick);
            // 
            // ManuallyAddEntryMenuItem
            // 
            this.ManuallyAddEntryMenuItem.Caption = "Manually Add Entry";
            this.ManuallyAddEntryMenuItem.Id = 14;
            this.ManuallyAddEntryMenuItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ManuallyAddEntryMenuItem.ImageOptions.SvgImage")));
            this.ManuallyAddEntryMenuItem.Name = "ManuallyAddEntryMenuItem";
            this.ManuallyAddEntryMenuItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ManuallyAddEntryMenuItem_ItemClick);
            // 
            // SaveTableButtonItem
            // 
            this.SaveTableButtonItem.Caption = "Save Cheat Table";
            this.SaveTableButtonItem.Id = 15;
            this.SaveTableButtonItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SaveTableButtonItem.ImageOptions.SvgImage")));
            this.SaveTableButtonItem.Name = "SaveTableButtonItem";
            this.SaveTableButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SaveTableButtonItem_ItemClick);
            // 
            // LoadTableButtonItem
            // 
            this.LoadTableButtonItem.Caption = "Load Cheat Table";
            this.LoadTableButtonItem.Id = 16;
            this.LoadTableButtonItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("LoadTableButtonItem.ImageOptions.SvgImage")));
            this.LoadTableButtonItem.Name = "LoadTableButtonItem";
            this.LoadTableButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.LoadTableButtonItem_ItemClick);
            // 
            // AutoConnect
            // 
            this.AutoConnect.Caption = "Toggle Auto Connect";
            this.AutoConnect.Id = 17;
            this.AutoConnect.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("AutoConnect.ImageOptions.SvgImage")));
            this.AutoConnect.Name = "AutoConnect";
            this.AutoConnect.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.AutoConnect_CheckedChanged);
            // 
            // resultList
            // 
            this.resultList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.resultList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.resultList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultList.ForeColor = System.Drawing.Color.Silver;
            this.resultList.FullRowSelect = true;
            this.resultList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.resultList.HideSelection = false;
            this.resultList.Location = new System.Drawing.Point(2, 2);
            this.resultList.Name = "resultList";
            this.ribbonControl1.SetPopupContextMenu(this.resultList, this.resultListMenu);
            this.resultList.Size = new System.Drawing.Size(302, 230);
            this.resultList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.resultList.TabIndex = 1;
            this.resultList.UseCompatibleStateImageBehavior = false;
            this.resultList.View = System.Windows.Forms.View.Details;
            this.resultList.DoubleClick += new System.EventHandler(this.resultList_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Address";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 101;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Previous";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 100;
            // 
            // resultListMenu
            // 
            this.resultListMenu.ItemLinks.Add(this.AddToTableButtonItem);
            this.resultListMenu.ItemLinks.Add(this.ChangeValueButtonItem);
            this.resultListMenu.ItemLinks.Add(this.RemoveEntryButtonItem);
            this.resultListMenu.ItemLinks.Add(this.ClearResultsListButtonItem);
            this.resultListMenu.ItemLinks.Add(this.SaveShortListToJsonButtonItem);
            this.resultListMenu.ItemLinks.Add(this.SaveLongResultsListButtonItem);
            this.resultListMenu.Name = "resultListMenu";
            this.resultListMenu.Ribbon = this.ribbonControl1;
            // 
            // tableList
            // 
            this.tableList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.tableList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.tableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableList.ForeColor = System.Drawing.Color.Silver;
            this.tableList.FullRowSelect = true;
            this.tableList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.tableList.HideSelection = false;
            this.tableList.Location = new System.Drawing.Point(2, 2);
            this.tableList.Name = "tableList";
            this.ribbonControl1.SetPopupContextMenu(this.tableList, this.tableListMenu);
            this.tableList.Size = new System.Drawing.Size(551, 161);
            this.tableList.TabIndex = 0;
            this.tableList.UseCompatibleStateImageBehavior = false;
            this.tableList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Address";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Description";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 250;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Type";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 100;
            // 
            // tableListMenu
            // 
            this.tableListMenu.ItemLinks.Add(this.ChangeValueTableMenuItem);
            this.tableListMenu.ItemLinks.Add(this.EditEntryTableMenuitem);
            this.tableListMenu.ItemLinks.Add(this.RemoveTableEntryMenuItem);
            this.tableListMenu.ItemLinks.Add(this.ClearCheatTableMenuItem);
            this.tableListMenu.ItemLinks.Add(this.ManuallyAddEntryMenuItem);
            this.tableListMenu.Name = "tableListMenu";
            this.tableListMenu.Ribbon = this.ribbonControl1;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Black";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.resultList);
            this.panelControl1.Location = new System.Drawing.Point(12, 133);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(306, 234);
            this.panelControl1.TabIndex = 1;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.tableList);
            this.panelControl3.Location = new System.Drawing.Point(12, 407);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(555, 165);
            this.panelControl3.TabIndex = 37;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.labelControl13);
            this.panelControl5.Controls.Add(this.labelControl8);
            this.panelControl5.Controls.Add(this.labelControl9);
            this.panelControl5.Controls.Add(this.labelControl10);
            this.panelControl5.Location = new System.Drawing.Point(12, 376);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(555, 31);
            this.panelControl5.TabIndex = 39;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(484, 8);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(26, 13);
            this.labelControl13.TabIndex = 19;
            this.labelControl13.Text = "Value";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(386, 8);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(24, 13);
            this.labelControl8.TabIndex = 18;
            this.labelControl8.Text = "Type";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(197, 8);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(53, 13);
            this.labelControl9.TabIndex = 17;
            this.labelControl9.Text = "Description";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(32, 8);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(39, 13);
            this.labelControl10.TabIndex = 16;
            this.labelControl10.Text = "Address";
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.labelControl7);
            this.panelControl4.Controls.Add(this.labelControl6);
            this.panelControl4.Controls.Add(this.labelControl5);
            this.panelControl4.Location = new System.Drawing.Point(12, 101);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(306, 32);
            this.panelControl4.TabIndex = 40;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(230, 10);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(41, 13);
            this.labelControl7.TabIndex = 18;
            this.labelControl7.Text = "Previous";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(138, 10);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(26, 13);
            this.labelControl6.TabIndex = 17;
            this.labelControl6.Text = "Value";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(32, 10);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(39, 13);
            this.labelControl5.TabIndex = 16;
            this.labelControl5.Text = "Address";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.RefreshValuesBox);
            this.panelControl2.Controls.Add(this.RefreshIntervalEdit);
            this.panelControl2.Controls.Add(this.LittleEndianBox);
            this.panelControl2.Controls.Add(this.labelControl12);
            this.panelControl2.Controls.Add(this.labelControl11);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.pause);
            this.panelControl2.Controls.Add(this.isHex);
            this.panelControl2.Controls.Add(this.NextButton);
            this.panelControl2.Controls.Add(this.SearchButton);
            this.panelControl2.Controls.Add(this.dataType_);
            this.panelControl2.Controls.Add(this.valBox);
            this.panelControl2.Controls.Add(this.sizeBox);
            this.panelControl2.Controls.Add(this.addrBox);
            this.panelControl2.Location = new System.Drawing.Point(322, 101);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(245, 266);
            this.panelControl2.TabIndex = 41;
            // 
            // RefreshValuesBox
            // 
            this.RefreshValuesBox.Location = new System.Drawing.Point(38, 230);
            this.RefreshValuesBox.Name = "RefreshValuesBox";
            this.RefreshValuesBox.Properties.Caption = "Refresh Interval";
            this.RefreshValuesBox.Size = new System.Drawing.Size(101, 19);
            toolTipTitleItem1.Text = "Refresh Interval Seconds";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "This will update the current values in the cheat table similar to cheat engine. ";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.RefreshValuesBox.SuperTip = superToolTip1;
            this.RefreshValuesBox.TabIndex = 46;
            this.RefreshValuesBox.CheckedChanged += new System.EventHandler(this.RefreshValuesBox_CheckedChanged);
            // 
            // RefreshIntervalEdit
            // 
            this.RefreshIntervalEdit.EditValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.RefreshIntervalEdit.Location = new System.Drawing.Point(145, 229);
            this.RefreshIntervalEdit.MenuManager = this.ribbonControl1;
            this.RefreshIntervalEdit.Name = "RefreshIntervalEdit";
            this.RefreshIntervalEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.RefreshIntervalEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RefreshIntervalEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RefreshIntervalEdit.Properties.MaxValue = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.RefreshIntervalEdit.Properties.MinValue = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.RefreshIntervalEdit.Size = new System.Drawing.Size(76, 20);
            this.RefreshIntervalEdit.TabIndex = 45;
            // 
            // LittleEndianBox
            // 
            this.LittleEndianBox.Location = new System.Drawing.Point(141, 141);
            this.LittleEndianBox.Name = "LittleEndianBox";
            this.LittleEndianBox.Properties.Caption = "Little Endian";
            this.LittleEndianBox.Size = new System.Drawing.Size(80, 19);
            this.LittleEndianBox.TabIndex = 28;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(156, 96);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(50, 13);
            this.labelControl12.TabIndex = 27;
            this.labelControl12.Text = "Data Type";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(45, 96);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(62, 13);
            this.labelControl11.TabIndex = 26;
            this.labelControl11.Text = "Search Value";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(150, 48);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 13);
            this.labelControl4.TabIndex = 25;
            this.labelControl4.Text = "End Address";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(45, 48);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(66, 13);
            this.labelControl3.TabIndex = 24;
            this.labelControl3.Text = "Start Address";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(124, 70);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 13);
            this.labelControl2.TabIndex = 23;
            this.labelControl2.Text = "0x";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 70);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 13);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "0x";
            // 
            // pause
            // 
            this.pause.Location = new System.Drawing.Point(38, 200);
            this.pause.Name = "pause";
            this.pause.Properties.Caption = "Pause While Searching";
            this.pause.Size = new System.Drawing.Size(141, 19);
            this.pause.TabIndex = 21;
            // 
            // isHex
            // 
            this.isHex.Location = new System.Drawing.Point(38, 141);
            this.isHex.Name = "isHex";
            this.isHex.Properties.Caption = "Search Hex";
            this.isHex.Size = new System.Drawing.Size(75, 19);
            this.isHex.TabIndex = 18;
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(145, 171);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(76, 23);
            this.NextButton.TabIndex = 20;
            this.NextButton.Text = "Next";
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(38, 171);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(80, 23);
            this.SearchButton.TabIndex = 19;
            this.SearchButton.Text = "Search";
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // dataType_
            // 
            this.dataType_.Location = new System.Drawing.Point(141, 115);
            this.dataType_.Name = "dataType_";
            this.dataType_.Properties.Appearance.Options.UseTextOptions = true;
            this.dataType_.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dataType_.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dataType_.Properties.Items.AddRange(new object[] {
            "Byte",
            "UShort",
            "UInt",
            "ULong",
            "Float",
            "String"});
            this.dataType_.Size = new System.Drawing.Size(80, 20);
            this.dataType_.TabIndex = 17;
            // 
            // valBox
            // 
            this.valBox.Location = new System.Drawing.Point(38, 115);
            this.valBox.Name = "valBox";
            this.valBox.Properties.Appearance.Options.UseTextOptions = true;
            this.valBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.valBox.Size = new System.Drawing.Size(80, 20);
            this.valBox.TabIndex = 16;
            // 
            // sizeBox
            // 
            this.sizeBox.Location = new System.Drawing.Point(141, 67);
            this.sizeBox.Name = "sizeBox";
            this.sizeBox.Properties.Appearance.Options.UseTextOptions = true;
            this.sizeBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.sizeBox.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sizeBox.Properties.MaxLength = 8;
            this.sizeBox.Size = new System.Drawing.Size(80, 20);
            this.sizeBox.TabIndex = 15;
            // 
            // addrBox
            // 
            this.addrBox.Location = new System.Drawing.Point(38, 67);
            this.addrBox.Name = "addrBox";
            this.addrBox.Properties.Appearance.Options.UseTextOptions = true;
            this.addrBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.addrBox.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.addrBox.Properties.MaxLength = 8;
            this.addrBox.Size = new System.Drawing.Size(80, 20);
            this.addrBox.TabIndex = 14;
            // 
            // ResultsToDisplayInput
            // 
            this.ResultsToDisplayInput.EditValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ResultsToDisplayInput.Location = new System.Drawing.Point(104, 75);
            this.ResultsToDisplayInput.MenuManager = this.ribbonControl1;
            this.ResultsToDisplayInput.Name = "ResultsToDisplayInput";
            this.ResultsToDisplayInput.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ResultsToDisplayInput.Properties.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ResultsToDisplayInput.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ResultsToDisplayInput.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ResultsToDisplayInput.Size = new System.Drawing.Size(55, 20);
            this.ResultsToDisplayInput.TabIndex = 29;
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(14, 78);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(84, 13);
            this.labelControl14.TabIndex = 42;
            this.labelControl14.Text = "Results to display";
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 250;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AcceptButton = this.SearchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 584);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.ResultsToDisplayInput);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.panelControl5);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("MainForm.IconOptions.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xbox 360 Cheat Engine by XeClutch (edited by XeCrippy)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppMenuPopup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultListMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableListMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.panelControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshValuesBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshIntervalEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LittleEndianBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pause.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.isHex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataType_.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addrBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsToDisplayInput.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem ConnectButton;
        private DevExpress.XtraBars.BarButtonItem AddToTableButtonItem;
        private DevExpress.XtraBars.BarButtonItem ChangeValueButtonItem;
        private DevExpress.XtraBars.BarButtonItem RemoveEntryButtonItem;
        private DevExpress.XtraBars.BarButtonItem ClearResultsListButtonItem;
        private DevExpress.XtraBars.BarButtonItem SaveShortListToJsonButtonItem;
        private DevExpress.XtraBars.BarButtonItem SaveLongResultsListButtonItem;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ListView resultList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.ListView tableList;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.CheckEdit LittleEndianBox;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit pause;
        private DevExpress.XtraEditors.CheckEdit isHex;
        private DevExpress.XtraEditors.SimpleButton NextButton;
        private DevExpress.XtraEditors.SimpleButton SearchButton;
        private DevExpress.XtraEditors.ComboBoxEdit dataType_;
        private DevExpress.XtraEditors.TextEdit valBox;
        private DevExpress.XtraEditors.TextEdit sizeBox;
        private DevExpress.XtraEditors.TextEdit addrBox;
        private DevExpress.XtraBars.PopupMenu resultListMenu;
        private DevExpress.XtraEditors.SpinEdit ResultsToDisplayInput;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraBars.BarButtonItem SaveCheatTableButtonItem;
        private DevExpress.XtraBars.PopupMenu AppMenuPopup;
        private DevExpress.XtraEditors.SpinEdit RefreshIntervalEdit;
        private DevExpress.XtraBars.PopupMenu tableListMenu;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraBars.BarButtonItem LoadCheatTableMenuItem;
        private DevExpress.XtraBars.BarButtonItem ChangeValueTableMenuItem;
        private DevExpress.XtraBars.BarButtonItem EditEntryTableMenuitem;
        private DevExpress.XtraBars.BarButtonItem RemoveTableEntryMenuItem;
        private DevExpress.XtraBars.BarButtonItem ClearCheatTableMenuItem;
        private DevExpress.XtraBars.BarButtonItem ManuallyAddEntryMenuItem;
        private DevExpress.XtraEditors.CheckEdit RefreshValuesBox;
        private DevExpress.XtraBars.BarButtonItem SaveTableButtonItem;
        private DevExpress.XtraBars.BarButtonItem LoadTableButtonItem;
        private DevExpress.XtraBars.BarCheckItem AutoConnect;
        private System.Windows.Forms.Timer timer1;
    }
}

