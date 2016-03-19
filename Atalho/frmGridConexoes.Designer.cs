namespace MechTech
{
    partial class frmGridConexoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGridConexoes));
            this.ConexoesDTOBindingSource = new System.Windows.Forms.BindingSource();
            this.barManager = new DevExpress.XtraBars.BarManager();
            this.barOpções = new DevExpress.XtraBars.Bar();
            this.btnNovo = new DevExpress.XtraBars.BarButtonItem();
            this.btnAlterar = new DevExpress.XtraBars.BarButtonItem();
            this.btnExcluir = new DevExpress.XtraBars.BarButtonItem();
            this.btnVisualizar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection = new DevExpress.Utils.ImageCollection();
            this.grdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServidor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBanco = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdConexoes = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.ConexoesDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdConexoes)).BeginInit();
            this.SuspendLayout();
            // 
            // ConexoesDTOBindingSource
            // 
            this.ConexoesDTOBindingSource.DataSource = typeof(MechTech.Entities.ConexoesDTO);
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barOpções});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNovo,
            this.btnAlterar,
            this.btnExcluir,
            this.btnVisualizar});
            this.barManager.MainMenu = this.barOpções;
            this.barManager.MaxItemId = 5;
            // 
            // barOpções
            // 
            this.barOpções.BarName = "Main menu";
            this.barOpções.DockCol = 0;
            this.barOpções.DockRow = 0;
            this.barOpções.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barOpções.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnNovo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAlterar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExcluir, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnVisualizar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barOpções.OptionsBar.AllowQuickCustomization = false;
            this.barOpções.OptionsBar.DrawDragBorder = false;
            this.barOpções.OptionsBar.UseWholeRow = true;
            this.barOpções.Text = "Opções";
            // 
            // btnNovo
            // 
            this.btnNovo.Caption = "&Novo";
            this.btnNovo.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNovo.Glyph")));
            this.btnNovo.Hint = "Inserir Registro";
            this.btnNovo.Id = 0;
            this.btnNovo.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnNovo.LargeGlyph")));
            this.btnNovo.LargeGlyphDisabled = ((System.Drawing.Image)(resources.GetObject("btnNovo.LargeGlyphDisabled")));
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNovo_ItemClick);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Caption = "&Alterar";
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Glyph")));
            this.btnAlterar.Hint = "Alterar Registro";
            this.btnAlterar.Id = 1;
            this.btnAlterar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAlterar.LargeGlyph")));
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAlterar_ItemClick);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Caption = "&Excluir";
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Glyph")));
            this.btnExcluir.Hint = "Excluir Registro";
            this.btnExcluir.Id = 2;
            this.btnExcluir.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExcluir.LargeGlyph")));
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExcluir_ItemClick);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Caption = "&Visualizar";
            this.btnVisualizar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnVisualizar.Glyph")));
            this.btnVisualizar.Id = 3;
            this.btnVisualizar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnVisualizar.LargeGlyph")));
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVisualizar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(644, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 420);
            this.barDockControlBottom.Size = new System.Drawing.Size(644, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 396);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(644, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 396);
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.Images.SetKeyName(0, "Calendar_16x16.png");
            this.imageCollection.Images.SetKeyName(1, "Drafts_16x16.png");
            this.imageCollection.Images.SetKeyName(2, "Inbox_16x16.png");
            this.imageCollection.Images.SetKeyName(3, "Mail_16x16.png");
            this.imageCollection.Images.SetKeyName(4, "Organizer_16x16.png");
            this.imageCollection.Images.SetKeyName(5, "Outbox_16x16.png");
            this.imageCollection.Images.SetKeyName(6, "Ribbon_AlignCenter_16x16.png");
            this.imageCollection.Images.SetKeyName(7, "Ribbon_AlignLeft_16x16.png");
            this.imageCollection.Images.SetKeyName(8, "Ribbon_AlignRight_16x16.png");
            this.imageCollection.Images.SetKeyName(9, "Ribbon_Bold_16x16.png");
            this.imageCollection.Images.SetKeyName(10, "Ribbon_Close_16x16.png");
            this.imageCollection.Images.SetKeyName(11, "Ribbon_Close_32x32.png");
            this.imageCollection.Images.SetKeyName(12, "Ribbon_Content_16x16.png");
            this.imageCollection.Images.SetKeyName(13, "Ribbon_Content_32x32.png");
            this.imageCollection.Images.SetKeyName(14, "Ribbon_Exit_16x16.png");
            this.imageCollection.Images.SetKeyName(15, "Ribbon_Exit_32x32.png");
            this.imageCollection.Images.SetKeyName(16, "Ribbon_Find_16x16.png");
            this.imageCollection.Images.SetKeyName(17, "Ribbon_Find_32x32.png");
            this.imageCollection.Images.SetKeyName(18, "Ribbon_Info_16x16.png");
            this.imageCollection.Images.SetKeyName(19, "Ribbon_Info_32x32.png");
            this.imageCollection.Images.SetKeyName(20, "Ribbon_Italic_16x16.png");
            this.imageCollection.Images.SetKeyName(21, "Ribbon_New_16x16.png");
            this.imageCollection.Images.SetKeyName(22, "Ribbon_New_32x32.png");
            this.imageCollection.Images.SetKeyName(23, "Ribbon_Open_16x16.png");
            this.imageCollection.Images.SetKeyName(24, "Ribbon_Open_32x32.png");
            this.imageCollection.Images.SetKeyName(25, "Ribbon_Save_16x16.png");
            this.imageCollection.Images.SetKeyName(26, "Ribbon_Save_32x32.png");
            this.imageCollection.Images.SetKeyName(27, "Ribbon_SaveAs_16x16.png");
            this.imageCollection.Images.SetKeyName(28, "Ribbon_SaveAs_32x32.png");
            this.imageCollection.Images.SetKeyName(29, "Ribbon_Underline_16x16.png");
            this.imageCollection.Images.SetKeyName(30, "Tasks_16x16.png");
            this.imageCollection.Images.SetKeyName(31, "Trash_16x16.png");
            // 
            // grdView
            // 
            this.grdView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmpresa,
            this.colServidor,
            this.colBanco});
            this.grdView.GridControl = this.grdConexoes;
            this.grdView.Name = "grdView";
            this.grdView.OptionsBehavior.Editable = false;
            this.grdView.OptionsCustomization.AllowColumnMoving = false;
            this.grdView.OptionsCustomization.AllowColumnResizing = false;
            this.grdView.OptionsCustomization.AllowFilter = false;
            this.grdView.OptionsCustomization.AllowGroup = false;
            this.grdView.OptionsCustomization.AllowSort = false;
            this.grdView.OptionsDetail.EnableMasterViewMode = false;
            this.grdView.OptionsMenu.EnableColumnMenu = false;
            this.grdView.OptionsMenu.EnableFooterMenu = false;
            this.grdView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdView.OptionsNavigation.EnterMoveNextColumn = true;
            this.grdView.OptionsView.ColumnAutoWidth = false;
            this.grdView.OptionsView.ShowGroupPanel = false;
            this.grdView.RowCountChanged += new System.EventHandler(this.grdView_RowCountChanged);
            // 
            // colEmpresa
            // 
            this.colEmpresa.AppearanceHeader.Options.UseTextOptions = true;
            this.colEmpresa.FieldName = "Empresa";
            this.colEmpresa.Name = "colEmpresa";
            this.colEmpresa.Visible = true;
            this.colEmpresa.VisibleIndex = 0;
            this.colEmpresa.Width = 300;
            // 
            // colServidor
            // 
            this.colServidor.AppearanceHeader.Options.UseTextOptions = true;
            this.colServidor.FieldName = "Servidor";
            this.colServidor.Name = "colServidor";
            this.colServidor.Visible = true;
            this.colServidor.VisibleIndex = 1;
            this.colServidor.Width = 150;
            // 
            // colBanco
            // 
            this.colBanco.AppearanceHeader.Options.UseTextOptions = true;
            this.colBanco.FieldName = "Banco";
            this.colBanco.Name = "colBanco";
            this.colBanco.Visible = true;
            this.colBanco.VisibleIndex = 2;
            this.colBanco.Width = 150;
            // 
            // grdConexoes
            // 
            this.grdConexoes.DataSource = this.ConexoesDTOBindingSource;
            this.grdConexoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdConexoes.Location = new System.Drawing.Point(0, 24);
            this.grdConexoes.MainView = this.grdView;
            this.grdConexoes.Name = "grdConexoes";
            this.grdConexoes.Size = new System.Drawing.Size(644, 396);
            this.grdConexoes.TabIndex = 5;
            this.grdConexoes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdView});
            this.grdConexoes.DoubleClick += new System.EventHandler(this.grdConexoes_DoubleClick);
            // 
            // frmGridConexoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 420);
            this.Controls.Add(this.grdConexoes);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmGridConexoes";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciador de Conexões";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGridConexoes_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ConexoesDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdConexoes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barOpções;
        private DevExpress.XtraBars.BarButtonItem btnNovo;
        private DevExpress.XtraBars.BarButtonItem btnAlterar;
        private DevExpress.XtraBars.BarButtonItem btnExcluir;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraBars.BarButtonItem btnVisualizar;
        private System.Windows.Forms.BindingSource ConexoesDTOBindingSource;
        private DevExpress.XtraGrid.GridControl grdConexoes;
        private DevExpress.XtraGrid.Views.Grid.GridView grdView;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn colServidor;
        private DevExpress.XtraGrid.Columns.GridColumn colBanco;

    }
}