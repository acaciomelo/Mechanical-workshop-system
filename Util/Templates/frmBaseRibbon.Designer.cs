namespace MechTech.Util.Templates
{
    partial class frmBaseRibbon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseRibbon));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu = new DevExpress.XtraBars.Ribbon.ApplicationMenu();
            this.barButtonItemCloseScreen = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItemPaint = new DevExpress.XtraBars.BarSubItem();
            this.barCheckItemPadrao = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItemCinza = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItemPreto = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItemAzul = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItemVerde = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItemSeven = new DevExpress.XtraBars.BarCheckItem();
            this.ribbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeelBase = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = this.applicationMenu;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barButtonItemCloseScreen,
            this.barSubItemPaint,
            this.barCheckItemPadrao,
            this.barCheckItemCinza,
            this.barCheckItemPreto,
            this.barCheckItemVerde,
            this.barCheckItemSeven,
            this.barCheckItemAzul});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 12;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(442, 147);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ItemLinks.Add(this.barButtonItemCloseScreen);
            this.ribbon.Toolbar.ItemLinks.Add(this.barSubItemPaint);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // applicationMenu
            // 
            this.applicationMenu.Name = "applicationMenu";
            this.applicationMenu.Ribbon = this.ribbon;
            // 
            // barButtonItemCloseScreen
            // 
            this.barButtonItemCloseScreen.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barButtonItemCloseScreen.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItemCloseScreen.Glyph")));
            this.barButtonItemCloseScreen.Id = 1;
            this.barButtonItemCloseScreen.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItemCloseScreen.LargeGlyph")));
            this.barButtonItemCloseScreen.Name = "barButtonItemCloseScreen";
            this.barButtonItemCloseScreen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCloseScreen_ItemClick);
            // 
            // barSubItemPaint
            // 
            this.barSubItemPaint.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barSubItemPaint.Glyph = ((System.Drawing.Image)(resources.GetObject("barSubItemPaint.Glyph")));
            this.barSubItemPaint.Hint = "Esquema de cores";
            this.barSubItemPaint.Id = 3;
            this.barSubItemPaint.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barSubItemPaint.LargeGlyph")));
            this.barSubItemPaint.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItemPadrao),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItemCinza),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItemPreto),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItemAzul),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItemVerde),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItemSeven)});
            this.barSubItemPaint.Name = "barSubItemPaint";
            // 
            // barCheckItemPadrao
            // 
            this.barCheckItemPadrao.Caption = "Padrão";
            this.barCheckItemPadrao.Id = 6;
            this.barCheckItemPadrao.Name = "barCheckItemPadrao";
            this.barCheckItemPadrao.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItemPadrao_ItemClick);
            // 
            // barCheckItemCinza
            // 
            this.barCheckItemCinza.Caption = "Cinza";
            this.barCheckItemCinza.Id = 7;
            this.barCheckItemCinza.Name = "barCheckItemCinza";
            this.barCheckItemCinza.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItemCinza_ItemClick);
            // 
            // barCheckItemPreto
            // 
            this.barCheckItemPreto.Caption = "Preto";
            this.barCheckItemPreto.Id = 8;
            this.barCheckItemPreto.Name = "barCheckItemPreto";
            this.barCheckItemPreto.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItemPreto_ItemClick);
            // 
            // barCheckItemAzul
            // 
            this.barCheckItemAzul.Caption = "Azul";
            this.barCheckItemAzul.Id = 11;
            this.barCheckItemAzul.Name = "barCheckItemAzul";
            this.barCheckItemAzul.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItemAzul_ItemClick);
            // 
            // barCheckItemVerde
            // 
            this.barCheckItemVerde.Caption = "Verde";
            this.barCheckItemVerde.Id = 9;
            this.barCheckItemVerde.Name = "barCheckItemVerde";
            this.barCheckItemVerde.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItemVerde_CheckedChanged);
            this.barCheckItemVerde.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItemVerde_ItemClick);
            // 
            // barCheckItemSeven
            // 
            this.barCheckItemSeven.Caption = "Windows 7";
            this.barCheckItemSeven.Id = 10;
            this.barCheckItemSeven.Name = "barCheckItemSeven";
            this.barCheckItemSeven.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItemSeven_ItemClick);
            // 
            // ribbonPage
            // 
            this.ribbonPage.Name = "ribbonPage";
            this.ribbonPage.Visible = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 426);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(442, 23);
            // 
            // defaultLookAndFeelBase
            // 
            this.defaultLookAndFeelBase.LookAndFeel.SkinName = "Blue";
            // 
            // frmBaseRibbon
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(442, 449);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmBaseRibbon";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem barButtonItemCloseScreen;
        private DevExpress.XtraBars.BarSubItem barSubItemPaint;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeelBase;
        private DevExpress.XtraBars.BarCheckItem barCheckItemPadrao;
        private DevExpress.XtraBars.BarCheckItem barCheckItemCinza;
        private DevExpress.XtraBars.BarCheckItem barCheckItemPreto;
        private DevExpress.XtraBars.BarCheckItem barCheckItemVerde;
        private DevExpress.XtraBars.BarCheckItem barCheckItemSeven;
        private DevExpress.XtraBars.BarCheckItem barCheckItemAzul;
        protected DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        protected DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        internal DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage;
    }
}