namespace MechTech.UI.Cadastros
{
    partial class frmGridCliente
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGridCliente));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.dgdClientes = new DevExpress.XtraGrid.GridControl();
            this.ClienteDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCpf_Cnpj = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.imageCollectionBase = new DevExpress.Utils.ImageCollection(this.components);
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barOpcoes = new DevExpress.XtraBars.Bar();
            this.btnInserir = new DevExpress.XtraBars.BarButtonItem();
            this.btnAlterar = new DevExpress.XtraBars.BarButtonItem();
            this.btnExcluir = new DevExpress.XtraBars.BarButtonItem();
            this.btnVisualizar = new DevExpress.XtraBars.BarButtonItem();
            this.btnSelecionar = new DevExpress.XtraBars.BarButtonItem();
            this.btnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.barPesquisa = new DevExpress.XtraBars.Bar();
            this.lblPesquisar = new DevExpress.XtraBars.BarStaticItem();
            this.Filtro = new DevExpress.XtraBars.BarEditItem();
            this.btnFiltro = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.txtConsulta = new DevExpress.XtraBars.BarEditItem();
            this.btnPesquisar = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClienteDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFiltro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgdClientes
            // 
            this.dgdClientes.DataSource = this.ClienteDTOBindingSource;
            this.dgdClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.dgdClientes.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.dgdClientes.Location = new System.Drawing.Point(0, 31);
            this.dgdClientes.MainView = this.grdView;
            this.dgdClientes.Name = "dgdClientes";
            this.dgdClientes.Size = new System.Drawing.Size(871, 419);
            this.dgdClientes.TabIndex = 5;
            this.dgdClientes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdView});
            this.dgdClientes.DoubleClick += new System.EventHandler(this.dgdClientes_DoubleClick);
            // 
            // ClienteDTOBindingSource
            // 
            this.ClienteDTOBindingSource.DataSource = typeof(MechTech.Entities.ClienteDTO);
            // 
            // grdView
            // 
            this.grdView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colNome,
            this.colCpf_Cnpj});
            this.grdView.GridControl = this.dgdClientes;
            this.grdView.Name = "grdView";
            this.grdView.OptionsBehavior.AllowIncrementalSearch = true;
            this.grdView.OptionsBehavior.Editable = false;
            this.grdView.OptionsCustomization.AllowColumnResizing = false;
            this.grdView.OptionsCustomization.AllowFilter = false;
            this.grdView.OptionsDetail.EnableMasterViewMode = false;
            this.grdView.OptionsMenu.EnableColumnMenu = false;
            this.grdView.OptionsMenu.EnableFooterMenu = false;
            this.grdView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdView.OptionsNavigation.EnterMoveNextColumn = true;
            this.grdView.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.grdView_CustomColumnDisplayText);
            this.grdView.RowCountChanged += new System.EventHandler(this.grdView_RowCountChanged);
            // 
            // colId
            // 
            this.colId.AppearanceHeader.Options.UseTextOptions = true;
            this.colId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colId.Caption = "Código";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 72;
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
            this.colNome.Width = 242;
            // 
            // colCpf_Cnpj
            // 
            this.colCpf_Cnpj.AppearanceCell.Options.UseTextOptions = true;
            this.colCpf_Cnpj.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCpf_Cnpj.AppearanceHeader.Options.UseTextOptions = true;
            this.colCpf_Cnpj.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCpf_Cnpj.Caption = "CNPJ/CPF";
            this.colCpf_Cnpj.FieldName = "Cpf_Cnpj";
            this.colCpf_Cnpj.Name = "colCpf_Cnpj";
            this.colCpf_Cnpj.Visible = true;
            this.colCpf_Cnpj.VisibleIndex = 2;
            this.colCpf_Cnpj.Width = 150;
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // imageCollectionBase
            // 
            this.imageCollectionBase.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionBase.ImageStream")));
            this.imageCollectionBase.Images.SetKeyName(0, "form_add_16.png");
            this.imageCollectionBase.Images.SetKeyName(1, "form_ok_16.png");
            this.imageCollectionBase.Images.SetKeyName(2, "form_remove_16.png");
            this.imageCollectionBase.Images.SetKeyName(3, "form_write_16.png");
            this.imageCollectionBase.Images.SetKeyName(4, "form_zoom_16.png");
            this.imageCollectionBase.Images.SetKeyName(5, "printer_16.png");
            this.imageCollectionBase.Images.SetKeyName(6, "zoom_16.png");
            this.imageCollectionBase.Images.SetKeyName(7, "always_on_top_16.png");
            this.imageCollectionBase.Images.SetKeyName(8, "always_on_top_close_16.png");
            this.imageCollectionBase.Images.SetKeyName(9, "amarelo.gif");
            this.imageCollectionBase.Images.SetKeyName(10, "error.png");
            this.imageCollectionBase.Images.SetKeyName(11, "forward.png");
            this.imageCollectionBase.Images.SetKeyName(12, "loading.gif");
            this.imageCollectionBase.Images.SetKeyName(13, "ok_16.png");
            this.imageCollectionBase.Images.SetKeyName(14, "verde.gif");
            this.imageCollectionBase.Images.SetKeyName(15, "vermelho.gif");
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
            this.btnAlterar,
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
            this.btnPesquisar,
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAlterar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
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
            // btnAlterar
            // 
            this.btnAlterar.Caption = "&Alterar";
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Glyph")));
            this.btnAlterar.Hint = "Atualização de registro";
            this.btnAlterar.Id = 2;
            this.btnAlterar.ImageIndex = 2;
            this.btnAlterar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAlterar.LargeGlyph")));
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAlterar_ItemClick);
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
            this.Filtro.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Filtro_ItemClick);
            // 
            // btnFiltro
            // 
            this.btnFiltro.AutoHeight = false;
            this.btnFiltro.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.btnFiltro.Items.AddRange(new object[] {
            "Nome",
            "Código"});
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // txtConsulta
            // 
            this.txtConsulta.AutoFillWidth = true;
            this.txtConsulta.Edit = this.btnPesquisar;
            this.txtConsulta.Hint = "Conteúdo a ser pesquisado";
            this.txtConsulta.Id = 10;
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.txtConsulta_ItemClick);
            this.txtConsulta.ItemDoubleClick += new DevExpress.XtraBars.ItemClickEventHandler(this.txtConsulta_ItemDoubleClick);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.AutoHeight = false;
            this.btnPesquisar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnPesquisar_ButtonClick);
            this.btnPesquisar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnPesquisar_KeyDown);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(871, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 450);
            this.barDockControlBottom.Size = new System.Drawing.Size(871, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 419);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(871, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 419);
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
            // frmGridCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 450);
            this.Controls.Add(this.dgdClientes);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmGridCliente";
            this.Text = "Cadastro de Clientes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGridCliente_FormClosed);
            this.Load += new System.EventHandler(this.frmGridCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgdClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClienteDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFiltro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgdClientes;
        private DevExpress.XtraGrid.Views.Grid.GridView grdView;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.Utils.ImageCollection imageCollectionBase;
        private System.Windows.Forms.BindingSource ClienteDTOBindingSource;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barOpcoes;
        private DevExpress.XtraBars.BarButtonItem btnInserir;
        private DevExpress.XtraBars.BarButtonItem btnAlterar;
        private DevExpress.XtraBars.BarButtonItem btnExcluir;
        private DevExpress.XtraBars.BarButtonItem btnVisualizar;
        private DevExpress.XtraBars.BarButtonItem btnSelecionar;
        private DevExpress.XtraBars.BarButtonItem btnImprimir;
        private DevExpress.XtraBars.Bar barPesquisa;
        private DevExpress.XtraBars.BarStaticItem lblPesquisar;
        private DevExpress.XtraBars.BarEditItem Filtro;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox btnFiltro;
        private DevExpress.XtraBars.BarEditItem txtConsulta;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnPesquisar;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colNome;
        private DevExpress.XtraGrid.Columns.GridColumn colCpf_Cnpj;
    
    }
}