namespace MechTech.UI.Utilitarios
{
    partial class frmUpdateUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateUsuario));
            this.UsuarioDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PerfilDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RotinaDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnSalvar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.grpPrincipal = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.UncheckButton = new DevExpress.XtraEditors.SimpleButton();
            this.checkButton = new DevExpress.XtraEditors.SimpleButton();
            this.DesmarcaButton = new DevExpress.XtraEditors.SimpleButton();
            this.MarcaButton = new DevExpress.XtraEditors.SimpleButton();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colSelecao = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemCheckEditSelecao = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colId = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDescricao = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.btnTrocaSenha = new DevExpress.XtraEditors.SimpleButton();
            this.SupervisorCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.LoginTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.NomeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.CodigoTextEdit = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.UsuarioDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PerfilDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotinaDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPrincipal)).BeginInit();
            this.grpPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditSelecao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupervisorCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NomeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodigoTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // UsuarioDTOBindingSource
            // 
            this.UsuarioDTOBindingSource.DataSource = typeof(MechTech.Entities.UsuarioDTO);
            // 
            // PerfilDTOBindingSource
            // 
            this.PerfilDTOBindingSource.DataSource = typeof(MechTech.Entities.PerfilDTO);
            // 
            // RotinaDTOBindingSource
            // 
            this.RotinaDTOBindingSource.DataSource = typeof(MechTech.Entities.RotinaDTO);
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSalvar,
            this.btnCancelar});
            this.barManager.MainMenu = this.bar2;
            this.barManager.MaxItemId = 6;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSalvar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCancelar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menu principal";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Caption = "&Salvar";
            this.btnSalvar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Glyph")));
            this.btnSalvar.Id = 0;
            this.btnSalvar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSalvar.LargeGlyph")));
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalvar_ItemClick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Caption = "&Cancelar";
            this.btnCancelar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Glyph")));
            this.btnCancelar.Id = 1;
            this.btnCancelar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCancelar.LargeGlyph")));
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancelar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(794, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 627);
            this.barDockControlBottom.Size = new System.Drawing.Size(794, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 603);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(794, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 603);
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // grpPrincipal
            // 
            this.grpPrincipal.AppearanceCaption.Options.UseTextOptions = true;
            this.grpPrincipal.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grpPrincipal.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.grpPrincipal.Controls.Add(this.groupControl2);
            this.grpPrincipal.Controls.Add(this.btnTrocaSenha);
            this.grpPrincipal.Controls.Add(this.SupervisorCheckEdit);
            this.grpPrincipal.Controls.Add(this.labelControl3);
            this.grpPrincipal.Controls.Add(this.labelControl2);
            this.grpPrincipal.Controls.Add(this.LoginTextEdit);
            this.grpPrincipal.Controls.Add(this.NomeTextEdit);
            this.grpPrincipal.Controls.Add(this.labelControl1);
            this.grpPrincipal.Controls.Add(this.CodigoTextEdit);
            this.grpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPrincipal.Location = new System.Drawing.Point(0, 24);
            this.grpPrincipal.Name = "grpPrincipal";
            this.grpPrincipal.Size = new System.Drawing.Size(794, 603);
            this.grpPrincipal.TabIndex = 4;
            this.grpPrincipal.Text = "Usuários";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.UncheckButton);
            this.groupControl2.Controls.Add(this.checkButton);
            this.groupControl2.Controls.Add(this.DesmarcaButton);
            this.groupControl2.Controls.Add(this.MarcaButton);
            this.groupControl2.Controls.Add(this.treeList1);
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Location = new System.Drawing.Point(30, 109);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(759, 380);
            this.groupControl2.TabIndex = 7;
            this.groupControl2.Text = "Acessos";
            this.groupControl2.Visible = false;
            // 
            // UncheckButton
            // 
            this.UncheckButton.Image = ((System.Drawing.Image)(resources.GetObject("UncheckButton.Image")));
            this.UncheckButton.ImageIndex = 14;
            this.UncheckButton.Location = new System.Drawing.Point(503, 25);
            this.UncheckButton.Name = "UncheckButton";
            this.UncheckButton.Size = new System.Drawing.Size(115, 23);
            this.UncheckButton.TabIndex = 4;
            this.UncheckButton.TabStop = false;
            this.UncheckButton.Text = "Desmarcar todos";
            this.UncheckButton.Click += new System.EventHandler(this.UncheckButton_Click);
            // 
            // checkButton
            // 
            this.checkButton.Image = ((System.Drawing.Image)(resources.GetObject("checkButton.Image")));
            this.checkButton.ImageIndex = 13;
            this.checkButton.Location = new System.Drawing.Point(382, 25);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(115, 23);
            this.checkButton.TabIndex = 3;
            this.checkButton.TabStop = false;
            this.checkButton.Text = "Marcar todos";
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // DesmarcaButton
            // 
            this.DesmarcaButton.Image = ((System.Drawing.Image)(resources.GetObject("DesmarcaButton.Image")));
            this.DesmarcaButton.ImageIndex = 14;
            this.DesmarcaButton.Location = new System.Drawing.Point(126, 25);
            this.DesmarcaButton.Name = "DesmarcaButton";
            this.DesmarcaButton.Size = new System.Drawing.Size(115, 23);
            this.DesmarcaButton.TabIndex = 1;
            this.DesmarcaButton.TabStop = false;
            this.DesmarcaButton.Text = "Desmarcar todos";
            this.DesmarcaButton.Click += new System.EventHandler(this.DesmarcaButton_Click);
            // 
            // MarcaButton
            // 
            this.MarcaButton.Image = ((System.Drawing.Image)(resources.GetObject("MarcaButton.Image")));
            this.MarcaButton.ImageIndex = 13;
            this.MarcaButton.Location = new System.Drawing.Point(5, 25);
            this.MarcaButton.Name = "MarcaButton";
            this.MarcaButton.Size = new System.Drawing.Size(115, 23);
            this.MarcaButton.TabIndex = 0;
            this.MarcaButton.TabStop = false;
            this.MarcaButton.Text = "Marcar todos";
            this.MarcaButton.Click += new System.EventHandler(this.MarcaButton_Click);
            // 
            // treeList1
            // 
            this.treeList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treeList1.DataSource = this.RotinaDTOBindingSource;
            this.treeList1.ImageIndexFieldName = "IndiceImagem";
            this.treeList1.KeyFieldName = "Nivel";
            this.treeList1.Location = new System.Drawing.Point(382, 52);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsBehavior.ImmediateEditor = false;
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.OptionsBehavior.ResizeNodes = false;
            this.treeList1.OptionsMenu.EnableColumnMenu = false;
            this.treeList1.OptionsMenu.EnableFooterMenu = false;
            this.treeList1.OptionsView.ShowCheckBoxes = true;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.ParentFieldName = "ParentNivel";
            this.treeList1.Size = new System.Drawing.Size(372, 323);
            this.treeList1.TabIndex = 7;
            this.treeList1.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
            this.treeList1.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeList1_NodeCellStyle);
            this.treeList1.BeforeCheckNode += new DevExpress.XtraTreeList.CheckNodeEventHandler(this.treeList1_BeforeCheckNode);
            this.treeList1.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeList1_AfterCheckNode);
            this.treeList1.CustomDrawNodeCheckBox += new DevExpress.XtraTreeList.CustomDrawNodeCheckBoxEventHandler(this.treeList1_CustomDrawNodeCheckBox);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Módulos de Acesso";
            this.treeListColumn1.FieldName = "Descricao";
            this.treeListColumn1.MinWidth = 64;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.AllowMove = false;
            this.treeListColumn1.OptionsColumn.AllowSize = false;
            this.treeListColumn1.OptionsColumn.AllowSort = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 545;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "colId";
            this.treeListColumn2.FieldName = "Id";
            this.treeListColumn2.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColumn2.Name = "treeListColumn2";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridControl1.DataSource = this.PerfilDTOBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(5, 52);
            this.gridControl1.MainView = this.bandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEditSelecao});
            this.gridControl1.Size = new System.Drawing.Size(372, 323);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.bandedGridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colSelecao,
            this.colId,
            this.colDescricao});
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.bandedGridView1.OptionsCustomization.AllowColumnMoving = false;
            this.bandedGridView1.OptionsCustomization.AllowColumnResizing = false;
            this.bandedGridView1.OptionsCustomization.AllowFilter = false;
            this.bandedGridView1.OptionsCustomization.AllowGroup = false;
            this.bandedGridView1.OptionsCustomization.AllowSort = false;
            this.bandedGridView1.OptionsDetail.EnableMasterViewMode = false;
            this.bandedGridView1.OptionsMenu.EnableColumnMenu = false;
            this.bandedGridView1.OptionsMenu.EnableFooterMenu = false;
            this.bandedGridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.bandedGridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            this.bandedGridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridView1.OptionsView.ShowIndicator = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Perfis de Acesso";
            this.gridBand1.Columns.Add(this.colSelecao);
            this.gridBand1.Columns.Add(this.colId);
            this.gridBand1.Columns.Add(this.colDescricao);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.OptionsBand.AllowHotTrack = false;
            this.gridBand1.OptionsBand.AllowMove = false;
            this.gridBand1.OptionsBand.AllowSize = false;
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 368;
            // 
            // colSelecao
            // 
            this.colSelecao.Caption = " ";
            this.colSelecao.ColumnEdit = this.repositoryItemCheckEditSelecao;
            this.colSelecao.FieldName = "Selecao";
            this.colSelecao.Name = "colSelecao";
            this.colSelecao.OptionsColumn.FixedWidth = true;
            this.colSelecao.Visible = true;
            this.colSelecao.Width = 25;
            // 
            // repositoryItemCheckEditSelecao
            // 
            this.repositoryItemCheckEditSelecao.AutoHeight = false;
            this.repositoryItemCheckEditSelecao.Caption = "Check";
            this.repositoryItemCheckEditSelecao.Name = "repositoryItemCheckEditSelecao";
            this.repositoryItemCheckEditSelecao.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repositoryItemCheckEditSelecao.CheckedChanged += new System.EventHandler(this.repositoryItemCheckEditSelecao_CheckedChanged);
            // 
            // colId
            // 
            this.colId.AppearanceHeader.Options.UseTextOptions = true;
            this.colId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colId.Caption = "Código";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.FixedWidth = true;
            this.colId.Visible = true;
            this.colId.Width = 50;
            // 
            // colDescricao
            // 
            this.colDescricao.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescricao.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescricao.Caption = "Descrição";
            this.colDescricao.FieldName = "Descricao";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.OptionsColumn.AllowEdit = false;
            this.colDescricao.Visible = true;
            this.colDescricao.Width = 293;
            // 
            // btnTrocaSenha
            // 
            this.btnTrocaSenha.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnTrocaSenha.Appearance.Options.UseBackColor = true;
            this.btnTrocaSenha.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnTrocaSenha.Enabled = false;
            this.btnTrocaSenha.Image = ((System.Drawing.Image)(resources.GetObject("btnTrocaSenha.Image")));
            this.btnTrocaSenha.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnTrocaSenha.Location = new System.Drawing.Point(760, 56);
            this.btnTrocaSenha.Name = "btnTrocaSenha";
            this.btnTrocaSenha.Size = new System.Drawing.Size(24, 23);
            this.btnTrocaSenha.TabIndex = 3;
            this.btnTrocaSenha.TabStop = false;
            this.btnTrocaSenha.ToolTip = "Trocar senha de acesso";
            this.btnTrocaSenha.Click += new System.EventHandler(this.btnTrocaSenha_Click);
            // 
            // SupervisorCheckEdit
            // 
            this.SupervisorCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.UsuarioDTOBindingSource, "Supervisor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SupervisorCheckEdit.Location = new System.Drawing.Point(28, 84);
            this.SupervisorCheckEdit.Name = "SupervisorCheckEdit";
            this.SupervisorCheckEdit.Properties.Caption = "Supervisor";
            this.SupervisorCheckEdit.Size = new System.Drawing.Size(761, 19);
            this.SupervisorCheckEdit.TabIndex = 4;
            this.SupervisorCheckEdit.TabStop = false;
            this.SupervisorCheckEdit.CheckedChanged += new System.EventHandler(this.SupervisorCheckEdit_CheckedChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(30, 61);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(29, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Login:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(30, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(31, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Nome:";
            // 
            // LoginTextEdit
            // 
            this.LoginTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.UsuarioDTOBindingSource, "Login", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.LoginTextEdit.EnterMoveNextControl = true;
            this.LoginTextEdit.Location = new System.Drawing.Point(73, 58);
            this.LoginTextEdit.Name = "LoginTextEdit";
            this.LoginTextEdit.Properties.MaxLength = 15;
            this.LoginTextEdit.Size = new System.Drawing.Size(686, 20);
            this.LoginTextEdit.TabIndex = 2;
            // 
            // NomeTextEdit
            // 
            this.NomeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.UsuarioDTOBindingSource, "Nome", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NomeTextEdit.EnterMoveNextControl = true;
            this.NomeTextEdit.Location = new System.Drawing.Point(73, 32);
            this.NomeTextEdit.Name = "NomeTextEdit";
            this.NomeTextEdit.Properties.MaxLength = 40;
            this.NomeTextEdit.Size = new System.Drawing.Size(716, 20);
            this.NomeTextEdit.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Código:";
            // 
            // CodigoTextEdit
            // 
            this.CodigoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.UsuarioDTOBindingSource, "Id", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CodigoTextEdit.EnterMoveNextControl = true;
            this.CodigoTextEdit.Location = new System.Drawing.Point(73, 6);
            this.CodigoTextEdit.Name = "CodigoTextEdit";
            this.CodigoTextEdit.Properties.ReadOnly = true;
            this.CodigoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.CodigoTextEdit.TabIndex = 0;
            this.CodigoTextEdit.TabStop = false;
            // 
            // frmUpdateUsuario
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 627);
            this.Controls.Add(this.grpPrincipal);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmUpdateUsuario";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUpdateUsuario_FormClosed);
            this.Load += new System.EventHandler(this.frmUpdateUsuario_Load);
            this.Shown += new System.EventHandler(this.frmUpdateUsuario_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.UsuarioDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PerfilDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotinaDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPrincipal)).EndInit();
            this.grpPrincipal.ResumeLayout(false);
            this.grpPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditSelecao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupervisorCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NomeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodigoTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.BindingSource UsuarioDTOBindingSource;
        public System.Windows.Forms.BindingSource PerfilDTOBindingSource;
        public System.Windows.Forms.BindingSource RotinaDTOBindingSource;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnSalvar;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.GroupControl grpPrincipal;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        public DevExpress.XtraEditors.SimpleButton UncheckButton;
        public DevExpress.XtraEditors.SimpleButton checkButton;
        public DevExpress.XtraEditors.SimpleButton DesmarcaButton;
        public DevExpress.XtraEditors.SimpleButton MarcaButton;
        public DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        public DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        public DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSelecao;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditSelecao;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colId;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDescricao;
        private DevExpress.XtraEditors.SimpleButton btnTrocaSenha;
        private DevExpress.XtraEditors.CheckEdit SupervisorCheckEdit;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit LoginTextEdit;
        private DevExpress.XtraEditors.TextEdit NomeTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit CodigoTextEdit;
    }
}