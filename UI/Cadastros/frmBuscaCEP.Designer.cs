namespace MechTech.UI.Cadastros
{
    partial class frmBuscaCEP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscaCEP));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.MunicipiobindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UFbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EnderecotextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.UFlookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.Município = new DevExpress.XtraEditors.LabelControl();
            this.dgdTabela = new DevExpress.XtraGrid.GridControl();
            this.BuscaCEPbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNomefantasia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRazaosocial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCnpj = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBairro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MunicipiolookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barOpcoes = new DevExpress.XtraBars.Bar();
            this.btnPesquisar = new DevExpress.XtraBars.BarButtonItem();
            this.btnSelecionar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnPesquisa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnFiltro = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MunicipiobindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UFbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnderecotextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UFlookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdTabela)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuscaCEPbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MunicipiolookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFiltro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // MunicipiobindingSource
            // 
            this.MunicipiobindingSource.DataSource = typeof(MechTech.Entities.MunicipioDTO);
            // 
            // UFbindingSource
            // 
            this.UFbindingSource.DataSource = typeof(MechTech.Entities.UFDTO);
            // 
            // EnderecotextEdit
            // 
            this.EnderecotextEdit.Location = new System.Drawing.Point(61, 67);
            this.EnderecotextEdit.Name = "EnderecotextEdit";
            this.EnderecotextEdit.Size = new System.Drawing.Size(351, 20);
            this.EnderecotextEdit.TabIndex = 31;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 70);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 13);
            this.labelControl2.TabIndex = 30;
            this.labelControl2.Text = "Endereço:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(330, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(17, 13);
            this.labelControl1.TabIndex = 28;
            this.labelControl1.Text = "UF:";
            // 
            // UFlookUpEdit
            // 
            this.UFlookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.UFbindingSource, "Codigo", true));
            this.UFlookUpEdit.Location = new System.Drawing.Point(349, 33);
            this.UFlookUpEdit.Name = "UFlookUpEdit";
            this.UFlookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UFlookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Codigo", "UF")});
            this.UFlookUpEdit.Properties.DataSource = this.UFbindingSource;
            this.UFlookUpEdit.Properties.DisplayMember = "Codigo";
            this.UFlookUpEdit.Properties.NullText = "";
            this.UFlookUpEdit.Properties.ValueMember = "Codigo";
            this.UFlookUpEdit.Size = new System.Drawing.Size(63, 20);
            this.UFlookUpEdit.TabIndex = 29;
            // 
            // Município
            // 
            this.Município.Location = new System.Drawing.Point(12, 36);
            this.Município.Name = "Município";
            this.Município.Size = new System.Drawing.Size(47, 13);
            this.Município.TabIndex = 26;
            this.Município.Text = "Município:";
            // 
            // dgdTabela
            // 
            this.dgdTabela.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgdTabela.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgdTabela.DataSource = this.BuscaCEPbindingSource;
            this.dgdTabela.Location = new System.Drawing.Point(0, 93);
            this.dgdTabela.MainView = this.gridView;
            this.dgdTabela.Name = "dgdTabela";
            this.dgdTabela.Size = new System.Drawing.Size(850, 309);
            this.dgdTabela.TabIndex = 25;
            this.dgdTabela.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // BuscaCEPbindingSource
            // 
            this.BuscaCEPbindingSource.DataSource = typeof(MechTech.Entities.BuscaCEPDTO);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colNomefantasia,
            this.colRazaosocial,
            this.colCnpj,
            this.colEnd,
            this.colBairro});
            this.gridView.GridControl = this.dgdTabela;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsCustomization.AllowColumnResizing = false;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsDetail.EnableMasterViewMode = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsMenu.EnableFooterMenu = false;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView.RowCountChanged += new System.EventHandler(this.gridView_RowCountChanged);
            // 
            // colId
            // 
            this.colId.AppearanceHeader.Options.UseTextOptions = true;
            this.colId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colId.Caption = "Cód. Município";
            this.colId.FieldName = "CodMun";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 69;
            // 
            // colNomefantasia
            // 
            this.colNomefantasia.AppearanceHeader.Options.UseTextOptions = true;
            this.colNomefantasia.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNomefantasia.Caption = "Município";
            this.colNomefantasia.FieldName = "Municipio";
            this.colNomefantasia.Name = "colNomefantasia";
            this.colNomefantasia.Visible = true;
            this.colNomefantasia.VisibleIndex = 1;
            this.colNomefantasia.Width = 235;
            // 
            // colRazaosocial
            // 
            this.colRazaosocial.AppearanceHeader.Options.UseTextOptions = true;
            this.colRazaosocial.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRazaosocial.Caption = "UF";
            this.colRazaosocial.FieldName = "Uf";
            this.colRazaosocial.Name = "colRazaosocial";
            this.colRazaosocial.Visible = true;
            this.colRazaosocial.VisibleIndex = 2;
            this.colRazaosocial.Width = 30;
            // 
            // colCnpj
            // 
            this.colCnpj.AppearanceCell.Options.UseTextOptions = true;
            this.colCnpj.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCnpj.AppearanceHeader.Options.UseTextOptions = true;
            this.colCnpj.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCnpj.Caption = "CEP";
            this.colCnpj.FieldName = "Cep";
            this.colCnpj.Name = "colCnpj";
            this.colCnpj.Visible = true;
            this.colCnpj.VisibleIndex = 3;
            this.colCnpj.Width = 90;
            // 
            // colEnd
            // 
            this.colEnd.Caption = "Endereço";
            this.colEnd.FieldName = "Endereco";
            this.colEnd.Name = "colEnd";
            this.colEnd.Visible = true;
            this.colEnd.VisibleIndex = 4;
            this.colEnd.Width = 300;
            // 
            // colBairro
            // 
            this.colBairro.Caption = "Bairro";
            this.colBairro.FieldName = "Bairro";
            this.colBairro.Name = "colBairro";
            this.colBairro.Visible = true;
            this.colBairro.VisibleIndex = 5;
            this.colBairro.Width = 150;
            // 
            // MunicipiolookUpEdit
            // 
            this.MunicipiolookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MunicipiobindingSource, "Nome", true));
            this.MunicipiolookUpEdit.Location = new System.Drawing.Point(61, 33);
            this.MunicipiolookUpEdit.Name = "MunicipiolookUpEdit";
            this.MunicipiolookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.MunicipiolookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nome", "Municipio")});
            this.MunicipiolookUpEdit.Properties.DataSource = this.MunicipiobindingSource;
            this.MunicipiolookUpEdit.Properties.DisplayMember = "Nome";
            this.MunicipiolookUpEdit.Properties.NullText = "";
            this.MunicipiolookUpEdit.Properties.ValueMember = "Nome";
            this.MunicipiolookUpEdit.Size = new System.Drawing.Size(263, 20);
            this.MunicipiolookUpEdit.TabIndex = 27;
            // 
            // barManager
            // 
            this.barManager.AllowCustomization = false;
            this.barManager.AllowMoveBarOnToolbar = false;
            this.barManager.AllowQuickCustomization = false;
            this.barManager.AllowShowToolbarsPopup = false;
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barOpcoes});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSelecionar,
            this.barEditItem1,
            this.btnPesquisar,
            this.btnCancelar});
            this.barManager.MaxItemId = 13;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPesquisar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSelecionar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCancelar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barOpcoes.OptionsBar.AllowQuickCustomization = false;
            this.barOpcoes.OptionsBar.DrawDragBorder = false;
            this.barOpcoes.OptionsBar.UseWholeRow = true;
            this.barOpcoes.Text = "Opções";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Caption = "&Pesquisar";
            this.btnPesquisar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Glyph")));
            this.btnPesquisar.Id = 11;
            this.btnPesquisar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.LargeGlyph")));
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPesquisar_ItemClick);
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
            // btnCancelar
            // 
            this.btnCancelar.Caption = "&Cancelar";
            this.btnCancelar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Glyph")));
            this.btnCancelar.Id = 12;
            this.btnCancelar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCancelar.LargeGlyph")));
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancelar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(850, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 401);
            this.barDockControlBottom.Size = new System.Drawing.Size(850, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 370);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(850, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 370);
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
            // btnPesquisa
            // 
            this.btnPesquisa.AutoHeight = false;
            this.btnPesquisa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("btnPesquisa.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.btnPesquisa.Name = "btnPesquisa";
            // 
            // btnFiltro
            // 
            this.btnFiltro.AutoHeight = false;
            this.btnFiltro.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.btnFiltro.Items.AddRange(new object[] {
            "Código IBGE",
            "Nome"});
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // frmBuscaCEP
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 401);
            this.Controls.Add(this.EnderecotextEdit);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.UFlookUpEdit);
            this.Controls.Add(this.Município);
            this.Controls.Add(this.dgdTabela);
            this.Controls.Add(this.MunicipiolookUpEdit);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmBuscaCEP";
            this.Text = "Busca CEP";
            this.Load += new System.EventHandler(this.frmBuscaCEP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MunicipiobindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UFbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnderecotextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UFlookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdTabela)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuscaCEPbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MunicipiolookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFiltro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource MunicipiobindingSource;
        private System.Windows.Forms.BindingSource UFbindingSource;
        private DevExpress.XtraEditors.TextEdit EnderecotextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit UFlookUpEdit;
        private DevExpress.XtraEditors.LabelControl Município;
        private DevExpress.XtraGrid.GridControl dgdTabela;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colNomefantasia;
        private DevExpress.XtraGrid.Columns.GridColumn colRazaosocial;
        private DevExpress.XtraGrid.Columns.GridColumn colCnpj;
        private DevExpress.XtraGrid.Columns.GridColumn colEnd;
        private DevExpress.XtraGrid.Columns.GridColumn colBairro;
        private DevExpress.XtraEditors.LookUpEdit MunicipiolookUpEdit;
        private System.Windows.Forms.BindingSource BuscaCEPbindingSource;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barOpcoes;
        private DevExpress.XtraBars.BarButtonItem btnPesquisar;
        private DevExpress.XtraBars.BarButtonItem btnSelecionar;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnPesquisa;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox btnFiltro;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
    }
}