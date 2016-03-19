namespace MechTech.UI.Cadastros
{
    partial class frmGridCategoriaProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGridCategoriaProduto));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barOpcoes = new DevExpress.XtraBars.Bar();
            this.btnInserir = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditar = new DevExpress.XtraBars.BarButtonItem();
            this.btnExcluir = new DevExpress.XtraBars.BarButtonItem();
            this.btnVisualizar = new DevExpress.XtraBars.BarButtonItem();
            this.btnSelecionar = new DevExpress.XtraBars.BarButtonItem();
            this.btnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.barPesquisa = new DevExpress.XtraBars.Bar();
            this.lblPesquisar = new DevExpress.XtraBars.BarStaticItem();
            this.Filtro = new DevExpress.XtraBars.BarEditItem();
            this.btnFiltro = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.txtConsulta = new DevExpress.XtraBars.BarEditItem();
            this.btnPesquisa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.CategoriaProdutoDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgdTabela = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNome = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFiltro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoriaProdutoDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdTabela)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.AllowCustomization = false;
            this.barManager.AllowMoveBarOnToolbar = false;
            this.barManager.AllowQuickCustomization = false;
            this.barManager.AllowShowToolbarsPopup = false;
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barOpcoes,
            this.barPesquisa});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnInserir,
            this.btnEditar,
            this.btnExcluir,
            this.btnVisualizar,
            this.btnSelecionar,
            this.btnImprimir,
            this.lblPesquisar,
            this.Filtro,
            this.barEditItem1,
            this.txtConsulta});
            this.barManager.MaxItemId = 11;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemTextEdit1,
            this.btnPesquisa,
            this.btnFiltro});
            // 
            // barOpcoes
            // 
            this.barOpcoes.BarName = "Opções";
            this.barOpcoes.DockCol = 0;
            this.barOpcoes.DockRow = 0;
            this.barOpcoes.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barOpcoes.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnInserir, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEditar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExcluir, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnVisualizar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSelecionar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnImprimir, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barOpcoes.OptionsBar.AllowQuickCustomization = false;
            this.barOpcoes.OptionsBar.DrawDragBorder = false;
            this.barOpcoes.Text = "Opções";
            // 
            // btnInserir
            // 
            this.btnInserir.Caption = "&Novo";
            this.btnInserir.Glyph = ((System.Drawing.Image)(resources.GetObject("btnInserir.Glyph")));
            this.btnInserir.Hint = "Inserção de registro";
            this.btnInserir.Id = 0;
            this.btnInserir.ImageIndex = 6;
            this.btnInserir.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnInserir.LargeGlyph")));
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInserir_ItemClick);
            // 
            // btnEditar
            // 
            this.btnEditar.Caption = "&Alterar";
            this.btnEditar.Enabled = false;
            this.btnEditar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnEditar.Glyph")));
            this.btnEditar.Hint = "Atualização de registro";
            this.btnEditar.Id = 2;
            this.btnEditar.ImageIndex = 2;
            this.btnEditar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnEditar.LargeGlyph")));
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEditar_ItemClick);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Caption = "&Excluir";
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Glyph")));
            this.btnExcluir.Hint = "Exclusão de registro";
            this.btnExcluir.Id = 3;
            this.btnExcluir.ImageIndex = 4;
            this.btnExcluir.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExcluir.LargeGlyph")));
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExcluir_ItemClick);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Caption = "&Visualizar";
            this.btnVisualizar.Enabled = false;
            this.btnVisualizar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnVisualizar.Glyph")));
            this.btnVisualizar.Hint = "Visualização";
            this.btnVisualizar.Id = 4;
            this.btnVisualizar.ImageIndex = 0;
            this.btnVisualizar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnVisualizar.LargeGlyph")));
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVisualizar_ItemClick);
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Caption = "&Selecionar";
            this.btnSelecionar.Enabled = false;
            this.btnSelecionar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSelecionar.Glyph")));
            this.btnSelecionar.Hint = "Seleção";
            this.btnSelecionar.Id = 5;
            this.btnSelecionar.ImageIndex = 9;
            this.btnSelecionar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSelecionar.LargeGlyph")));
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelecionar_ItemClick);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Caption = "&Imprimir";
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Glyph = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Glyph")));
            this.btnImprimir.Hint = "Impressão";
            this.btnImprimir.Id = 6;
            this.btnImprimir.ImageIndex = 5;
            this.btnImprimir.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnImprimir.LargeGlyph")));
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImprimir_ItemClick);
            // 
            // barPesquisa
            // 
            this.barPesquisa.BarName = "Pesquisa";
            this.barPesquisa.DockCol = 1;
            this.barPesquisa.DockRow = 0;
            this.barPesquisa.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barPesquisa.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblPesquisar),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.Filtro, "", false, true, true, 124),
            new DevExpress.XtraBars.LinkPersistInfo(this.txtConsulta)});
            this.barPesquisa.OptionsBar.AllowQuickCustomization = false;
            this.barPesquisa.OptionsBar.DrawDragBorder = false;
            this.barPesquisa.Text = "Pesquisa";
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblPesquisar.Caption = "Pesquisar por:";
            this.lblPesquisar.Id = 7;
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // Filtro
            // 
            this.Filtro.Edit = this.btnFiltro;
            this.Filtro.EditValue = "Nome";
            this.Filtro.Hint = "Campo a ser pesquisado";
            this.Filtro.Id = 8;
            this.Filtro.Name = "Filtro";
            this.Filtro.EditValueChanged += new System.EventHandler(this.Filtro_EditValueChanged);
            // 
            // btnFiltro
            // 
            this.btnFiltro.AutoHeight = false;
            this.btnFiltro.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.btnFiltro.Items.AddRange(new object[] {
            "Código",
            "Nome"});
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // txtConsulta
            // 
            this.txtConsulta.AutoFillWidth = true;
            this.txtConsulta.Edit = this.btnPesquisa;
            this.txtConsulta.Hint = "Conteúdo a ser pesquisado";
            this.txtConsulta.Id = 10;
            this.txtConsulta.Name = "txtConsulta";
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.AutoHeight = false;
            this.btnPesquisa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("btnPesquisa.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnPesquisa_ButtonClick);
            this.btnPesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnPesquisa_KeyDown);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(794, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 574);
            this.barDockControlBottom.Size = new System.Drawing.Size(794, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 543);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(794, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 543);
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemTextEdit1;
            this.barEditItem1.Id = 9;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // CategoriaProdutoDTOBindingSource
            // 
            this.CategoriaProdutoDTOBindingSource.DataSource = typeof(MechTech.Entities.CategoriaProdutoDTO);
            // 
            // dgdTabela
            // 
            this.dgdTabela.DataSource = this.CategoriaProdutoDTOBindingSource;
            this.dgdTabela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgdTabela.Location = new System.Drawing.Point(0, 31);
            this.dgdTabela.MainView = this.gridView;
            this.dgdTabela.Name = "dgdTabela";
            this.dgdTabela.Size = new System.Drawing.Size(794, 543);
            this.dgdTabela.TabIndex = 17;
            this.dgdTabela.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.dgdTabela.DoubleClick += new System.EventHandler(this.dgdTabela_DoubleClick);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodigo,
            this.colNome});
            this.gridView.GridControl = this.dgdTabela;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsCustomization.AllowColumnResizing = false;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsMenu.EnableFooterMenu = false;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView.RowCountChanged += new System.EventHandler(this.gridView_RowCountChanged);
            // 
            // colCodigo
            // 
            this.colCodigo.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodigo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodigo.Caption = "Código";
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 0;
            this.colCodigo.Width = 70;
            // 
            // colNome
            // 
            this.colNome.AppearanceHeader.Options.UseTextOptions = true;
            this.colNome.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNome.Caption = "Nome";
            this.colNome.FieldName = "Nome";
            this.colNome.Name = "colNome";
            this.colNome.Visible = true;
            this.colNome.VisibleIndex = 1;
            this.colNome.Width = 576;
            // 
            // frmGridCategoriaProduto
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 574);
            this.Controls.Add(this.dgdTabela);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmGridCategoriaProduto";
            this.Text = "Cadastro de Categoria de Produtos e Serviços";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGridDepartamento_FormClosed);
            this.Load += new System.EventHandler(this.frmGridDepartamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFiltro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoriaProdutoDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdTabela)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barOpcoes;
        private DevExpress.XtraBars.BarButtonItem btnInserir;
        private DevExpress.XtraBars.BarButtonItem btnEditar;
        private DevExpress.XtraBars.BarButtonItem btnExcluir;
        private DevExpress.XtraBars.BarButtonItem btnVisualizar;
        private DevExpress.XtraBars.BarButtonItem btnSelecionar;
        private DevExpress.XtraBars.BarButtonItem btnImprimir;
        private DevExpress.XtraBars.Bar barPesquisa;
        private DevExpress.XtraBars.BarStaticItem lblPesquisar;
        private DevExpress.XtraBars.BarEditItem Filtro;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox btnFiltro;
        private DevExpress.XtraBars.BarEditItem txtConsulta;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnPesquisa;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private System.Windows.Forms.BindingSource CategoriaProdutoDTOBindingSource;
        private DevExpress.XtraGrid.GridControl dgdTabela;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colNome;
    }
}