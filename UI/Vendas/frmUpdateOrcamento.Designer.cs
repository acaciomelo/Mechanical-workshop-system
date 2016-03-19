namespace MechTech.UI.Vendas
{
    partial class frmUpdateOrcamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateOrcamento));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.grpPrincipal = new DevExpress.XtraEditors.GroupControl();
            this.xtraTabControlDetalhesOrcamento = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageItensOrcamento = new DevExpress.XtraTab.XtraTabPage();
            this.btnGerarOS = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.ValorLiquidoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.OrcamentoDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.OrcamentoGridControl = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStripOrcamento = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DigitarOrcamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AlterarOrcamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExcluirOrcamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExcluirTudoOrcamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrcamentoProdutoServicoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdutoServid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdServdescricao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVlrUnitario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVlrTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVlrDesconto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVlrLiquido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRecalculo = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcluirProdServ = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditarProdServ = new DevExpress.XtraEditors.SimpleButton();
            this.btnInserirProdServ = new DevExpress.XtraEditors.SimpleButton();
            this.pgDetalhesOrcamento = new DevExpress.XtraTab.XtraTabPage();
            this.lblDiferencaValor = new DevExpress.XtraEditors.LabelControl();
            this.lblDiferencaRecebimento = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditFormaRecebimento = new DevExpress.XtraEditors.LookUpEdit();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnSalvar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrimeiro = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnterior = new DevExpress.XtraBars.BarButtonItem();
            this.btnProximo = new DevExpress.XtraBars.BarButtonItem();
            this.btnUltimo = new DevExpress.XtraBars.BarButtonItem();
            this.btnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.FormaRecebimentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.groupBoxFormaRecebimentoNormal = new System.Windows.Forms.GroupBox();
            this.txtValorRecebimento = new DevExpress.XtraEditors.TextEdit();
            this.lookUpEditParcelasRecebimento = new DevExpress.XtraEditors.LookUpEdit();
            this.ParcelasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.gridControlResumoRecebimento = new DevExpress.XtraGrid.GridControl();
            this.DetalheParcelaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPageDadosFiscais = new DevExpress.XtraTab.XtraTabPage();
            this.txtNotaFiscalServicos = new DevExpress.XtraEditors.TextEdit();
            this.txtNotaFiscalProdutos = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.ClientesButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.dataOrcamentodateEdit = new DevExpress.XtraEditors.DateEdit();
            this.cmbFuncionarios = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lookUpEditPosicao = new DevExpress.XtraEditors.LookUpEdit();
            this.PosicaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookUpEditVeiculo = new DevExpress.XtraEditors.LookUpEdit();
            this.PlacasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtCPFCNPJ = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtCodOrcamento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ClienteDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPrincipal)).BeginInit();
            this.grpPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDetalhesOrcamento)).BeginInit();
            this.xtraTabControlDetalhesOrcamento.SuspendLayout();
            this.xtraTabPageItensOrcamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValorLiquidoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrcamentoDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrcamentoGridControl)).BeginInit();
            this.contextMenuStripOrcamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrcamentoProdutoServicoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.pgDetalhesOrcamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditFormaRecebimento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormaRecebimentoBindingSource)).BeginInit();
            this.groupBoxFormaRecebimentoNormal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorRecebimento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditParcelasRecebimento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParcelasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlResumoRecebimento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetalheParcelaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.xtraTabPageDadosFiscais.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotaFiscalServicos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotaFiscalProdutos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesButtonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataOrcamentodateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataOrcamentodateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFuncionarios.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPosicao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosicaoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditVeiculo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlacasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCPFCNPJ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodOrcamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClienteDTOBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.grpPrincipal.Controls.Add(this.xtraTabControlDetalhesOrcamento);
            this.grpPrincipal.Controls.Add(this.ClientesButtonEdit);
            this.grpPrincipal.Controls.Add(this.dataOrcamentodateEdit);
            this.grpPrincipal.Controls.Add(this.cmbFuncionarios);
            this.grpPrincipal.Controls.Add(this.lookUpEditPosicao);
            this.grpPrincipal.Controls.Add(this.lookUpEditVeiculo);
            this.grpPrincipal.Controls.Add(this.labelControl7);
            this.grpPrincipal.Controls.Add(this.labelControl6);
            this.grpPrincipal.Controls.Add(this.txtCPFCNPJ);
            this.grpPrincipal.Controls.Add(this.labelControl5);
            this.grpPrincipal.Controls.Add(this.labelControl4);
            this.grpPrincipal.Controls.Add(this.labelControl3);
            this.grpPrincipal.Controls.Add(this.txtCodOrcamento);
            this.grpPrincipal.Controls.Add(this.labelControl2);
            this.grpPrincipal.Controls.Add(this.labelControl1);
            this.grpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPrincipal.Location = new System.Drawing.Point(0, 24);
            this.grpPrincipal.Name = "grpPrincipal";
            this.grpPrincipal.Size = new System.Drawing.Size(1199, 550);
            this.grpPrincipal.TabIndex = 7;
            this.grpPrincipal.Text = "Orçamento";
            // 
            // xtraTabControlDetalhesOrcamento
            // 
            this.xtraTabControlDetalhesOrcamento.Location = new System.Drawing.Point(24, 58);
            this.xtraTabControlDetalhesOrcamento.Name = "xtraTabControlDetalhesOrcamento";
            this.xtraTabControlDetalhesOrcamento.SelectedTabPage = this.xtraTabPageItensOrcamento;
            this.xtraTabControlDetalhesOrcamento.Size = new System.Drawing.Size(931, 487);
            this.xtraTabControlDetalhesOrcamento.TabIndex = 53;
            this.xtraTabControlDetalhesOrcamento.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageItensOrcamento,
            this.pgDetalhesOrcamento,
            this.xtraTabPageDadosFiscais});
            // 
            // xtraTabPageItensOrcamento
            // 
            this.xtraTabPageItensOrcamento.Controls.Add(this.btnGerarOS);
            this.xtraTabPageItensOrcamento.Controls.Add(this.ValorLiquidoTextEdit);
            this.xtraTabPageItensOrcamento.Controls.Add(this.labelControl11);
            this.xtraTabPageItensOrcamento.Controls.Add(this.labelControl9);
            this.xtraTabPageItensOrcamento.Controls.Add(this.labelControl14);
            this.xtraTabPageItensOrcamento.Controls.Add(this.OrcamentoGridControl);
            this.xtraTabPageItensOrcamento.Controls.Add(this.btnRecalculo);
            this.xtraTabPageItensOrcamento.Controls.Add(this.btnExcluirProdServ);
            this.xtraTabPageItensOrcamento.Controls.Add(this.btnEditarProdServ);
            this.xtraTabPageItensOrcamento.Controls.Add(this.btnInserirProdServ);
            this.xtraTabPageItensOrcamento.Name = "xtraTabPageItensOrcamento";
            this.xtraTabPageItensOrcamento.Size = new System.Drawing.Size(925, 459);
            this.xtraTabPageItensOrcamento.Text = "Itens Orçamento";
            // 
            // btnGerarOS
            // 
            this.btnGerarOS.Image = ((System.Drawing.Image)(resources.GetObject("btnGerarOS.Image")));
            this.btnGerarOS.ImageList = this.imageCollection;
            this.btnGerarOS.Location = new System.Drawing.Point(675, 3);
            this.btnGerarOS.Name = "btnGerarOS";
            this.btnGerarOS.Size = new System.Drawing.Size(127, 23);
            this.btnGerarOS.TabIndex = 11;
            this.btnGerarOS.Text = "Gerar O&rdem Serviço";
            this.btnGerarOS.ToolTip = "Gerar a Ordem de Serviço";
            this.btnGerarOS.Click += new System.EventHandler(this.btnGerarOS_Click);
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.Images.SetKeyName(0, "images.jpg");
            // 
            // ValorLiquidoTextEdit
            // 
            this.ValorLiquidoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrcamentoDTOBindingSource, "ValorLiquido", true));
            this.ValorLiquidoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OrcamentoDTOBindingSource, "ValorLiquido", true));
            this.ValorLiquidoTextEdit.EditValue = "t";
            this.ValorLiquidoTextEdit.Location = new System.Drawing.Point(799, 310);
            this.ValorLiquidoTextEdit.Name = "ValorLiquidoTextEdit";
            this.ValorLiquidoTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ValorLiquidoTextEdit.Properties.Appearance.Options.UseFont = true;
            this.ValorLiquidoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.ValorLiquidoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ValorLiquidoTextEdit.Properties.DisplayFormat.FormatString = "c";
            this.ValorLiquidoTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ValorLiquidoTextEdit.Properties.Mask.EditMask = "c2";
            this.ValorLiquidoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ValorLiquidoTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.ValorLiquidoTextEdit.Properties.ReadOnly = true;
            this.ValorLiquidoTextEdit.Size = new System.Drawing.Size(120, 22);
            this.ValorLiquidoTextEdit.TabIndex = 90;
            this.ValorLiquidoTextEdit.TabStop = false;
            // 
            // OrcamentoDTOBindingSource
            // 
            this.OrcamentoDTOBindingSource.DataSource = typeof(MechTech.Entities.OrcamentoDTO);
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl11.Location = new System.Drawing.Point(748, 313);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(45, 16);
            this.labelControl11.TabIndex = 89;
            this.labelControl11.Text = "TOTAL:";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Location = new System.Drawing.Point(3, 330);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(77, 14);
            this.labelControl9.TabIndex = 92;
            this.labelControl9.Text = "S = SERVIÇO";
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl14.Location = new System.Drawing.Point(3, 310);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(77, 14);
            this.labelControl14.TabIndex = 91;
            this.labelControl14.Text = "P = PRODUTO";
            // 
            // OrcamentoGridControl
            // 
            this.OrcamentoGridControl.ContextMenuStrip = this.contextMenuStripOrcamento;
            this.OrcamentoGridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.OrcamentoGridControl.DataSource = this.OrcamentoProdutoServicoBindingSource;
            this.OrcamentoGridControl.Location = new System.Drawing.Point(3, 32);
            this.OrcamentoGridControl.MainView = this.gridView;
            this.OrcamentoGridControl.Name = "OrcamentoGridControl";
            this.OrcamentoGridControl.Size = new System.Drawing.Size(918, 272);
            this.OrcamentoGridControl.TabIndex = 88;
            this.OrcamentoGridControl.TabStop = false;
            this.OrcamentoGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // contextMenuStripOrcamento
            // 
            this.contextMenuStripOrcamento.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DigitarOrcamentoToolStripMenuItem,
            this.AlterarOrcamentoToolStripMenuItem,
            this.ExcluirOrcamentoToolStripMenuItem,
            this.ExcluirTudoOrcamentoToolStripMenuItem});
            this.contextMenuStripOrcamento.Name = "contextMenuStripRescisao";
            this.contextMenuStripOrcamento.Size = new System.Drawing.Size(137, 92);
            // 
            // DigitarOrcamentoToolStripMenuItem
            // 
            this.DigitarOrcamentoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DigitarOrcamentoToolStripMenuItem.Image")));
            this.DigitarOrcamentoToolStripMenuItem.Name = "DigitarOrcamentoToolStripMenuItem";
            this.DigitarOrcamentoToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.DigitarOrcamentoToolStripMenuItem.Text = "I&nserir";
            this.DigitarOrcamentoToolStripMenuItem.Click += new System.EventHandler(this.DigitarAjusteToolStripMenuItem_Click);
            // 
            // AlterarOrcamentoToolStripMenuItem
            // 
            this.AlterarOrcamentoToolStripMenuItem.Enabled = false;
            this.AlterarOrcamentoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("AlterarOrcamentoToolStripMenuItem.Image")));
            this.AlterarOrcamentoToolStripMenuItem.Name = "AlterarOrcamentoToolStripMenuItem";
            this.AlterarOrcamentoToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.AlterarOrcamentoToolStripMenuItem.Text = "&Alterar";
            this.AlterarOrcamentoToolStripMenuItem.Click += new System.EventHandler(this.AlterarAjusteToolStripMenuItem_Click);
            // 
            // ExcluirOrcamentoToolStripMenuItem
            // 
            this.ExcluirOrcamentoToolStripMenuItem.Enabled = false;
            this.ExcluirOrcamentoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ExcluirOrcamentoToolStripMenuItem.Image")));
            this.ExcluirOrcamentoToolStripMenuItem.Name = "ExcluirOrcamentoToolStripMenuItem";
            this.ExcluirOrcamentoToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.ExcluirOrcamentoToolStripMenuItem.Text = "&Excluir";
            this.ExcluirOrcamentoToolStripMenuItem.Click += new System.EventHandler(this.ExcluirAjusteToolStripMenuItem_Click);
            // 
            // ExcluirTudoOrcamentoToolStripMenuItem
            // 
            this.ExcluirTudoOrcamentoToolStripMenuItem.Enabled = false;
            this.ExcluirTudoOrcamentoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ExcluirTudoOrcamentoToolStripMenuItem.Image")));
            this.ExcluirTudoOrcamentoToolStripMenuItem.Name = "ExcluirTudoOrcamentoToolStripMenuItem";
            this.ExcluirTudoOrcamentoToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.ExcluirTudoOrcamentoToolStripMenuItem.Text = "Excluir &tudo";
            this.ExcluirTudoOrcamentoToolStripMenuItem.Click += new System.EventHandler(this.ExcluirTudoAjusteToolStripMenuItem_Click);
            // 
            // OrcamentoProdutoServicoBindingSource
            // 
            this.OrcamentoProdutoServicoBindingSource.DataMember = "Produtoservico";
            this.OrcamentoProdutoServicoBindingSource.DataSource = this.OrcamentoDTOBindingSource;
            // 
            // gridView
            // 
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTipo,
            this.colProdutoServid,
            this.colProdServdescricao,
            this.colQtde,
            this.colVlrUnitario,
            this.colVlrTotal,
            this.colVlrDesconto,
            this.colVlrLiquido});
            this.gridView.GridControl = this.OrcamentoGridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsCustomization.AllowColumnMoving = false;
            this.gridView.OptionsCustomization.AllowColumnResizing = false;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsCustomization.AllowSort = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsMenu.EnableFooterMenu = false;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // colTipo
            // 
            this.colTipo.AppearanceCell.Options.UseTextOptions = true;
            this.colTipo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTipo.AppearanceHeader.Options.UseTextOptions = true;
            this.colTipo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTipo.Caption = "Tipo";
            this.colTipo.FieldName = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.Visible = true;
            this.colTipo.VisibleIndex = 0;
            this.colTipo.Width = 35;
            // 
            // colProdutoServid
            // 
            this.colProdutoServid.AppearanceCell.Options.UseTextOptions = true;
            this.colProdutoServid.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProdutoServid.AppearanceHeader.Options.UseTextOptions = true;
            this.colProdutoServid.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProdutoServid.Caption = "Código";
            this.colProdutoServid.FieldName = "Produto.Id";
            this.colProdutoServid.Name = "colProdutoServid";
            this.colProdutoServid.Visible = true;
            this.colProdutoServid.VisibleIndex = 1;
            this.colProdutoServid.Width = 70;
            // 
            // colProdServdescricao
            // 
            this.colProdServdescricao.AppearanceHeader.Options.UseTextOptions = true;
            this.colProdServdescricao.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProdServdescricao.Caption = "Descrição";
            this.colProdServdescricao.FieldName = "Produto.Descricao";
            this.colProdServdescricao.Name = "colProdServdescricao";
            this.colProdServdescricao.Visible = true;
            this.colProdServdescricao.VisibleIndex = 2;
            this.colProdServdescricao.Width = 239;
            // 
            // colQtde
            // 
            this.colQtde.AppearanceCell.Options.UseTextOptions = true;
            this.colQtde.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQtde.AppearanceHeader.Options.UseTextOptions = true;
            this.colQtde.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQtde.Caption = "Quantidade";
            this.colQtde.FieldName = "Quantidade";
            this.colQtde.Name = "colQtde";
            this.colQtde.Visible = true;
            this.colQtde.VisibleIndex = 3;
            this.colQtde.Width = 70;
            // 
            // colVlrUnitario
            // 
            this.colVlrUnitario.AppearanceCell.Options.UseTextOptions = true;
            this.colVlrUnitario.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVlrUnitario.AppearanceHeader.Options.UseTextOptions = true;
            this.colVlrUnitario.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVlrUnitario.Caption = "Valor Unitário";
            this.colVlrUnitario.DisplayFormat.FormatString = "{0:c2}";
            this.colVlrUnitario.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVlrUnitario.FieldName = "ValorUnitario";
            this.colVlrUnitario.Name = "colVlrUnitario";
            this.colVlrUnitario.Visible = true;
            this.colVlrUnitario.VisibleIndex = 4;
            this.colVlrUnitario.Width = 80;
            // 
            // colVlrTotal
            // 
            this.colVlrTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colVlrTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVlrTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colVlrTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVlrTotal.Caption = "Valor Total";
            this.colVlrTotal.DisplayFormat.FormatString = "{0:c2}";
            this.colVlrTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVlrTotal.FieldName = "ValorTotal";
            this.colVlrTotal.Name = "colVlrTotal";
            this.colVlrTotal.Visible = true;
            this.colVlrTotal.VisibleIndex = 5;
            this.colVlrTotal.Width = 80;
            // 
            // colVlrDesconto
            // 
            this.colVlrDesconto.AppearanceCell.Options.UseTextOptions = true;
            this.colVlrDesconto.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVlrDesconto.AppearanceHeader.Options.UseTextOptions = true;
            this.colVlrDesconto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVlrDesconto.Caption = "Valor Desconto";
            this.colVlrDesconto.DisplayFormat.FormatString = "{0:c2}";
            this.colVlrDesconto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVlrDesconto.FieldName = "ValorDesconto";
            this.colVlrDesconto.Name = "colVlrDesconto";
            this.colVlrDesconto.Visible = true;
            this.colVlrDesconto.VisibleIndex = 6;
            this.colVlrDesconto.Width = 80;
            // 
            // colVlrLiquido
            // 
            this.colVlrLiquido.AppearanceCell.Options.UseTextOptions = true;
            this.colVlrLiquido.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVlrLiquido.AppearanceHeader.Options.UseTextOptions = true;
            this.colVlrLiquido.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVlrLiquido.Caption = "Valor Líquido";
            this.colVlrLiquido.DisplayFormat.FormatString = "{0:c2}";
            this.colVlrLiquido.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVlrLiquido.FieldName = "ValorLiquido";
            this.colVlrLiquido.Name = "colVlrLiquido";
            this.colVlrLiquido.Visible = true;
            this.colVlrLiquido.VisibleIndex = 7;
            this.colVlrLiquido.Width = 80;
            // 
            // btnRecalculo
            // 
            this.btnRecalculo.ImageIndex = 0;
            this.btnRecalculo.ImageList = this.imageCollection;
            this.btnRecalculo.Location = new System.Drawing.Point(808, 3);
            this.btnRecalculo.Name = "btnRecalculo";
            this.btnRecalculo.Size = new System.Drawing.Size(111, 23);
            this.btnRecalculo.TabIndex = 12;
            this.btnRecalculo.Text = "Recálcul&o";
            this.btnRecalculo.ToolTip = "Recalcular o orçamento. Caso haja diferenças de valores após o recálculo, é neces" +
    "sário salvar a operação novamente para que os valores recalculados sejam válidos" +
    ".";
            this.btnRecalculo.Click += new System.EventHandler(this.btnRecalculo_Click);
            // 
            // btnExcluirProdServ
            // 
            this.btnExcluirProdServ.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirProdServ.Image")));
            this.btnExcluirProdServ.ImageIndex = 4;
            this.btnExcluirProdServ.Location = new System.Drawing.Point(163, 3);
            this.btnExcluirProdServ.Name = "btnExcluirProdServ";
            this.btnExcluirProdServ.Size = new System.Drawing.Size(75, 23);
            this.btnExcluirProdServ.TabIndex = 10;
            this.btnExcluirProdServ.Text = "&Excluir";
            this.btnExcluirProdServ.ToolTip = "Excluir Produto ou Serviço";
            this.btnExcluirProdServ.Click += new System.EventHandler(this.btnExcluirProdServ_Click);
            // 
            // btnEditarProdServ
            // 
            this.btnEditarProdServ.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarProdServ.Image")));
            this.btnEditarProdServ.ImageIndex = 2;
            this.btnEditarProdServ.Location = new System.Drawing.Point(82, 3);
            this.btnEditarProdServ.Name = "btnEditarProdServ";
            this.btnEditarProdServ.Size = new System.Drawing.Size(75, 23);
            this.btnEditarProdServ.TabIndex = 9;
            this.btnEditarProdServ.Text = "&Alterar";
            this.btnEditarProdServ.ToolTip = "Alterar Produto ou Serviço";
            this.btnEditarProdServ.Click += new System.EventHandler(this.btnEditarProdServ_Click);
            // 
            // btnInserirProdServ
            // 
            this.btnInserirProdServ.Image = ((System.Drawing.Image)(resources.GetObject("btnInserirProdServ.Image")));
            this.btnInserirProdServ.ImageIndex = 6;
            this.btnInserirProdServ.Location = new System.Drawing.Point(3, 3);
            this.btnInserirProdServ.Name = "btnInserirProdServ";
            this.btnInserirProdServ.Size = new System.Drawing.Size(75, 23);
            this.btnInserirProdServ.TabIndex = 8;
            this.btnInserirProdServ.Text = "I&nserir";
            this.btnInserirProdServ.ToolTip = "Inserir Produto ou Serviço";
            this.btnInserirProdServ.Click += new System.EventHandler(this.btnInserirProdServ_Click);
            // 
            // pgDetalhesOrcamento
            // 
            this.pgDetalhesOrcamento.Controls.Add(this.lblDiferencaValor);
            this.pgDetalhesOrcamento.Controls.Add(this.lblDiferencaRecebimento);
            this.pgDetalhesOrcamento.Controls.Add(this.lookUpEditFormaRecebimento);
            this.pgDetalhesOrcamento.Controls.Add(this.labelControl15);
            this.pgDetalhesOrcamento.Controls.Add(this.groupBoxFormaRecebimentoNormal);
            this.pgDetalhesOrcamento.Controls.Add(this.gridControlResumoRecebimento);
            this.pgDetalhesOrcamento.Name = "pgDetalhesOrcamento";
            this.pgDetalhesOrcamento.Size = new System.Drawing.Size(925, 459);
            this.pgDetalhesOrcamento.Text = "Forma de Recebimento";
            // 
            // lblDiferencaValor
            // 
            this.lblDiferencaValor.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDiferencaValor.Location = new System.Drawing.Point(311, 78);
            this.lblDiferencaValor.Name = "lblDiferencaValor";
            this.lblDiferencaValor.Size = new System.Drawing.Size(7, 13);
            this.lblDiferencaValor.TabIndex = 66;
            this.lblDiferencaValor.Text = "0";
            // 
            // lblDiferencaRecebimento
            // 
            this.lblDiferencaRecebimento.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDiferencaRecebimento.Location = new System.Drawing.Point(231, 78);
            this.lblDiferencaRecebimento.Name = "lblDiferencaRecebimento";
            this.lblDiferencaRecebimento.Size = new System.Drawing.Size(74, 13);
            this.lblDiferencaRecebimento.TabIndex = 65;
            this.lblDiferencaRecebimento.Text = "Diferença de:";
            // 
            // lookUpEditFormaRecebimento
            // 
            this.lookUpEditFormaRecebimento.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrcamentoDTOBindingSource, "IdEspecieRecebimento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lookUpEditFormaRecebimento.EnterMoveNextControl = true;
            this.lookUpEditFormaRecebimento.Location = new System.Drawing.Point(3, 22);
            this.lookUpEditFormaRecebimento.MenuManager = this.barManager;
            this.lookUpEditFormaRecebimento.Name = "lookUpEditFormaRecebimento";
            this.lookUpEditFormaRecebimento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditFormaRecebimento.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descricao", "Forma", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.lookUpEditFormaRecebimento.Properties.DataSource = this.FormaRecebimentoBindingSource;
            this.lookUpEditFormaRecebimento.Properties.DisplayMember = "Descricao";
            this.lookUpEditFormaRecebimento.Properties.MaxLength = 8;
            this.lookUpEditFormaRecebimento.Properties.NullText = "";
            this.lookUpEditFormaRecebimento.Properties.ValueMember = "Id";
            this.lookUpEditFormaRecebimento.Size = new System.Drawing.Size(551, 20);
            this.lookUpEditFormaRecebimento.TabIndex = 13;
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
            this.btnCancelar,
            this.btnPrimeiro,
            this.btnAnterior,
            this.btnProximo,
            this.btnUltimo,
            this.btnImprimir});
            this.barManager.MainMenu = this.bar2;
            this.barManager.MaxItemId = 7;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSalvar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCancelar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrimeiro, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAnterior, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnProximo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUltimo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnImprimir, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            // btnPrimeiro
            // 
            this.btnPrimeiro.Caption = "&Primeiro";
            this.btnPrimeiro.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPrimeiro.Glyph")));
            this.btnPrimeiro.Id = 2;
            this.btnPrimeiro.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPrimeiro.LargeGlyph")));
            this.btnPrimeiro.Name = "btnPrimeiro";
            this.btnPrimeiro.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrimeiro_ItemClick);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Caption = "&Anterior";
            this.btnAnterior.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAnterior.Glyph")));
            this.btnAnterior.Id = 3;
            this.btnAnterior.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAnterior.LargeGlyph")));
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAnterior_ItemClick);
            // 
            // btnProximo
            // 
            this.btnProximo.Caption = "P&róximo";
            this.btnProximo.Glyph = ((System.Drawing.Image)(resources.GetObject("btnProximo.Glyph")));
            this.btnProximo.Id = 4;
            this.btnProximo.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnProximo.LargeGlyph")));
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProximo_ItemClick);
            // 
            // btnUltimo
            // 
            this.btnUltimo.Caption = "&Último";
            this.btnUltimo.Glyph = ((System.Drawing.Image)(resources.GetObject("btnUltimo.Glyph")));
            this.btnUltimo.Id = 5;
            this.btnUltimo.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnUltimo.LargeGlyph")));
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUltimo_ItemClick);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Caption = "&Imprimir";
            this.btnImprimir.Glyph = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Glyph")));
            this.btnImprimir.Id = 6;
            this.btnImprimir.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnImprimir.LargeGlyph")));
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImprimir_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1199, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 574);
            this.barDockControlBottom.Size = new System.Drawing.Size(1199, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 550);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1199, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 550);
            // 
            // FormaRecebimentoBindingSource
            // 
            this.FormaRecebimentoBindingSource.AllowNew = false;
            this.FormaRecebimentoBindingSource.DataSource = typeof(MechTech.Util.Rotina);
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(3, 3);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(114, 13);
            this.labelControl15.TabIndex = 62;
            this.labelControl15.Text = "Forma de Recebimento:";
            // 
            // groupBoxFormaRecebimentoNormal
            // 
            this.groupBoxFormaRecebimentoNormal.Controls.Add(this.txtValorRecebimento);
            this.groupBoxFormaRecebimentoNormal.Controls.Add(this.lookUpEditParcelasRecebimento);
            this.groupBoxFormaRecebimentoNormal.Controls.Add(this.labelControl12);
            this.groupBoxFormaRecebimentoNormal.Controls.Add(this.labelControl13);
            this.groupBoxFormaRecebimentoNormal.Location = new System.Drawing.Point(3, 44);
            this.groupBoxFormaRecebimentoNormal.Name = "groupBoxFormaRecebimentoNormal";
            this.groupBoxFormaRecebimentoNormal.Size = new System.Drawing.Size(220, 60);
            this.groupBoxFormaRecebimentoNormal.TabIndex = 60;
            this.groupBoxFormaRecebimentoNormal.TabStop = false;
            // 
            // txtValorRecebimento
            // 
            this.txtValorRecebimento.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrcamentoDTOBindingSource, "ValorEspecieRecebimento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtValorRecebimento.Location = new System.Drawing.Point(7, 31);
            this.txtValorRecebimento.MenuManager = this.barManager;
            this.txtValorRecebimento.Name = "txtValorRecebimento";
            this.txtValorRecebimento.Properties.DisplayFormat.FormatString = "{0:c2}";
            this.txtValorRecebimento.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtValorRecebimento.Size = new System.Drawing.Size(100, 20);
            this.txtValorRecebimento.TabIndex = 14;
            // 
            // lookUpEditParcelasRecebimento
            // 
            this.lookUpEditParcelasRecebimento.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrcamentoDTOBindingSource, "QuantidadeParcelas", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lookUpEditParcelasRecebimento.EnterMoveNextControl = true;
            this.lookUpEditParcelasRecebimento.Location = new System.Drawing.Point(113, 31);
            this.lookUpEditParcelasRecebimento.MenuManager = this.barManager;
            this.lookUpEditParcelasRecebimento.Name = "lookUpEditParcelasRecebimento";
            this.lookUpEditParcelasRecebimento.Properties.Appearance.Options.UseTextOptions = true;
            this.lookUpEditParcelasRecebimento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditParcelasRecebimento.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descricao", 150, "Parcela")});
            this.lookUpEditParcelasRecebimento.Properties.DataSource = this.ParcelasBindingSource;
            this.lookUpEditParcelasRecebimento.Properties.DisplayMember = "Descricao";
            this.lookUpEditParcelasRecebimento.Properties.MaxLength = 8;
            this.lookUpEditParcelasRecebimento.Properties.NullText = "";
            this.lookUpEditParcelasRecebimento.Properties.ValueMember = "Id";
            this.lookUpEditParcelasRecebimento.Size = new System.Drawing.Size(101, 20);
            this.lookUpEditParcelasRecebimento.TabIndex = 15;
            this.lookUpEditParcelasRecebimento.Leave += new System.EventHandler(this.lookUpEditParcelasRecebimento_Leave);
            // 
            // ParcelasBindingSource
            // 
            this.ParcelasBindingSource.AllowNew = false;
            this.ParcelasBindingSource.DataSource = typeof(MechTech.Util.Rotina);
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(6, 12);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(28, 13);
            this.labelControl12.TabIndex = 6;
            this.labelControl12.Text = "Valor:";
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(113, 12);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(69, 13);
            this.labelControl13.TabIndex = 7;
            this.labelControl13.Text = "Parcelamento:";
            // 
            // gridControlResumoRecebimento
            // 
            this.gridControlResumoRecebimento.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControlResumoRecebimento.DataSource = this.DetalheParcelaBindingSource;
            this.gridControlResumoRecebimento.Location = new System.Drawing.Point(3, 110);
            this.gridControlResumoRecebimento.MainView = this.gridView1;
            this.gridControlResumoRecebimento.Name = "gridControlResumoRecebimento";
            this.gridControlResumoRecebimento.Size = new System.Drawing.Size(551, 272);
            this.gridControlResumoRecebimento.TabIndex = 59;
            this.gridControlResumoRecebimento.TabStop = false;
            this.gridControlResumoRecebimento.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // DetalheParcelaBindingSource
            // 
            this.DetalheParcelaBindingSource.DataMember = "DetalhesFormaRecebimento";
            this.DetalheParcelaBindingSource.DataSource = typeof(MechTech.Entities.OrcamentoDTO);
            // 
            // gridView1
            // 
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControlResumoRecebimento;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowColumnResizing = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Parcela/Espécie";
            this.gridColumn1.FieldName = "ParcelaEspecie";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 300;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Valor";
            this.gridColumn2.DisplayFormat.FormatString = "{0:C2}";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "ValorParcela";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 216;
            // 
            // xtraTabPageDadosFiscais
            // 
            this.xtraTabPageDadosFiscais.Controls.Add(this.txtNotaFiscalServicos);
            this.xtraTabPageDadosFiscais.Controls.Add(this.txtNotaFiscalProdutos);
            this.xtraTabPageDadosFiscais.Controls.Add(this.labelControl10);
            this.xtraTabPageDadosFiscais.Controls.Add(this.labelControl8);
            this.xtraTabPageDadosFiscais.Name = "xtraTabPageDadosFiscais";
            this.xtraTabPageDadosFiscais.Size = new System.Drawing.Size(925, 459);
            this.xtraTabPageDadosFiscais.Text = "Dados Fiscais";
            // 
            // txtNotaFiscalServicos
            // 
            this.txtNotaFiscalServicos.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrcamentoDTOBindingSource, "NotaFiscalServicos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtNotaFiscalServicos.EnterMoveNextControl = true;
            this.txtNotaFiscalServicos.Location = new System.Drawing.Point(111, 37);
            this.txtNotaFiscalServicos.Name = "txtNotaFiscalServicos";
            this.txtNotaFiscalServicos.Properties.MaxLength = 200;
            this.txtNotaFiscalServicos.Size = new System.Drawing.Size(800, 20);
            this.txtNotaFiscalServicos.TabIndex = 17;
            // 
            // txtNotaFiscalProdutos
            // 
            this.txtNotaFiscalProdutos.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrcamentoDTOBindingSource, "NotaFiscalProdutos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtNotaFiscalProdutos.EnterMoveNextControl = true;
            this.txtNotaFiscalProdutos.Location = new System.Drawing.Point(111, 11);
            this.txtNotaFiscalProdutos.Name = "txtNotaFiscalProdutos";
            this.txtNotaFiscalProdutos.Properties.MaxLength = 200;
            this.txtNotaFiscalProdutos.Size = new System.Drawing.Size(800, 20);
            this.txtNotaFiscalProdutos.TabIndex = 16;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(3, 40);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(99, 13);
            this.labelControl10.TabIndex = 20;
            this.labelControl10.Text = "Nota Fiscal Serviços:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(3, 14);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(102, 13);
            this.labelControl8.TabIndex = 19;
            this.labelControl8.Text = "Nota Fiscal Produtos:";
            // 
            // ClientesButtonEdit
            // 
            this.ClientesButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrcamentoDTOBindingSource, "Cliente.Nome", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ClientesButtonEdit.EnterMoveNextControl = true;
            this.ClientesButtonEdit.Location = new System.Drawing.Point(91, 30);
            this.ClientesButtonEdit.Name = "ClientesButtonEdit";
            this.ClientesButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("ClientesButtonEdit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, false)});
            this.ClientesButtonEdit.Properties.MaxLength = 150;
            this.ClientesButtonEdit.Size = new System.Drawing.Size(239, 22);
            this.ClientesButtonEdit.TabIndex = 5;
            this.ClientesButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ClientesButtonEdit_ButtonClick);
            // 
            // dataOrcamentodateEdit
            // 
            this.dataOrcamentodateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrcamentoDTOBindingSource, "DataOrcamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataOrcamentodateEdit.EditValue = null;
            this.dataOrcamentodateEdit.Location = new System.Drawing.Point(230, 6);
            this.dataOrcamentodateEdit.MenuManager = this.barManager;
            this.dataOrcamentodateEdit.Name = "dataOrcamentodateEdit";
            this.dataOrcamentodateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dataOrcamentodateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dataOrcamentodateEdit.Size = new System.Drawing.Size(100, 20);
            this.dataOrcamentodateEdit.TabIndex = 2;
            // 
            // cmbFuncionarios
            // 
            this.cmbFuncionarios.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrcamentoDTOBindingSource, "AtendidoPor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbFuncionarios.EnterMoveNextControl = true;
            this.cmbFuncionarios.Location = new System.Drawing.Point(409, 6);
            this.cmbFuncionarios.MenuManager = this.barManager;
            this.cmbFuncionarios.Name = "cmbFuncionarios";
            this.cmbFuncionarios.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFuncionarios.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbFuncionarios.Size = new System.Drawing.Size(290, 20);
            this.cmbFuncionarios.TabIndex = 3;
            // 
            // lookUpEditPosicao
            // 
            this.lookUpEditPosicao.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrcamentoDTOBindingSource, "PosicaoOrcamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lookUpEditPosicao.EnterMoveNextControl = true;
            this.lookUpEditPosicao.Location = new System.Drawing.Point(751, 6);
            this.lookUpEditPosicao.MenuManager = this.barManager;
            this.lookUpEditPosicao.Name = "lookUpEditPosicao";
            this.lookUpEditPosicao.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPosicao.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descricao", "Descricao")});
            this.lookUpEditPosicao.Properties.DataSource = this.PosicaoBindingSource;
            this.lookUpEditPosicao.Properties.DisplayMember = "Descricao";
            this.lookUpEditPosicao.Properties.NullText = "";
            this.lookUpEditPosicao.Properties.ValueMember = "Id";
            this.lookUpEditPosicao.Size = new System.Drawing.Size(191, 20);
            this.lookUpEditPosicao.TabIndex = 4;
            // 
            // PosicaoBindingSource
            // 
            this.PosicaoBindingSource.AllowNew = false;
            this.PosicaoBindingSource.DataSource = typeof(MechTech.Util.Rotina);
            // 
            // lookUpEditVeiculo
            // 
            this.lookUpEditVeiculo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrcamentoDTOBindingSource, "PlacaVeiculo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lookUpEditVeiculo.EnterMoveNextControl = true;
            this.lookUpEditVeiculo.Location = new System.Drawing.Point(603, 32);
            this.lookUpEditVeiculo.MenuManager = this.barManager;
            this.lookUpEditVeiculo.Name = "lookUpEditVeiculo";
            this.lookUpEditVeiculo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditVeiculo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Placa", 60, "Placa"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Veiculo", 150, "Veículo")});
            this.lookUpEditVeiculo.Properties.DataSource = this.PlacasBindingSource;
            this.lookUpEditVeiculo.Properties.DisplayMember = "Placa";
            this.lookUpEditVeiculo.Properties.MaxLength = 8;
            this.lookUpEditVeiculo.Properties.NullText = "";
            this.lookUpEditVeiculo.Properties.ValueMember = "Placa";
            this.lookUpEditVeiculo.Size = new System.Drawing.Size(339, 20);
            this.lookUpEditVeiculo.TabIndex = 7;
            // 
            // PlacasBindingSource
            // 
            this.PlacasBindingSource.DataSource = typeof(MechTech.UI.Vendas.PlacaVeiculoDTO);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(705, 9);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(40, 13);
            this.labelControl7.TabIndex = 16;
            this.labelControl7.Text = "Posição:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(560, 35);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(37, 13);
            this.labelControl6.TabIndex = 15;
            this.labelControl6.Text = "Veículo:";
            // 
            // txtCPFCNPJ
            // 
            this.txtCPFCNPJ.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrcamentoDTOBindingSource, "Cliente.Cpf_Cnpj", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCPFCNPJ.Enabled = false;
            this.txtCPFCNPJ.EnterMoveNextControl = true;
            this.txtCPFCNPJ.Location = new System.Drawing.Point(409, 32);
            this.txtCPFCNPJ.Name = "txtCPFCNPJ";
            this.txtCPFCNPJ.Properties.Mask.EditMask = "99.999.999/9999-99";
            this.txtCPFCNPJ.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtCPFCNPJ.Properties.Mask.SaveLiteral = false;
            this.txtCPFCNPJ.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtCPFCNPJ.Properties.MaxLength = 14;
            this.txtCPFCNPJ.Size = new System.Drawing.Size(146, 20);
            this.txtCPFCNPJ.TabIndex = 6;
            this.txtCPFCNPJ.EditValueChanged += new System.EventHandler(this.txtCPFCNPJ_EditValueChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(336, 35);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(52, 13);
            this.labelControl5.TabIndex = 13;
            this.labelControl5.Text = "CPF/CNPJ:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(336, 9);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(66, 13);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Atendido por:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(197, 6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(27, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Data:";
            // 
            // txtCodOrcamento
            // 
            this.txtCodOrcamento.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrcamentoDTOBindingSource, "Id", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCodOrcamento.Enabled = false;
            this.txtCodOrcamento.Location = new System.Drawing.Point(91, 6);
            this.txtCodOrcamento.Name = "txtCodOrcamento";
            this.txtCodOrcamento.Size = new System.Drawing.Size(100, 20);
            this.txtCodOrcamento.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(24, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Cliente:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Código Orc.:";
            // 
            // ClienteDTOBindingSource
            // 
            this.ClienteDTOBindingSource.DataSource = typeof(MechTech.Entities.ClienteDTO);
            // 
            // frmUpdateOrcamento
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 574);
            this.Controls.Add(this.grpPrincipal);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmUpdateOrcamento";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUpdateOrcamento_FormClosed);
            this.Load += new System.EventHandler(this.frmUpdateOrcamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPrincipal)).EndInit();
            this.grpPrincipal.ResumeLayout(false);
            this.grpPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDetalhesOrcamento)).EndInit();
            this.xtraTabControlDetalhesOrcamento.ResumeLayout(false);
            this.xtraTabPageItensOrcamento.ResumeLayout(false);
            this.xtraTabPageItensOrcamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValorLiquidoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrcamentoDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrcamentoGridControl)).EndInit();
            this.contextMenuStripOrcamento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OrcamentoProdutoServicoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.pgDetalhesOrcamento.ResumeLayout(false);
            this.pgDetalhesOrcamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditFormaRecebimento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormaRecebimentoBindingSource)).EndInit();
            this.groupBoxFormaRecebimentoNormal.ResumeLayout(false);
            this.groupBoxFormaRecebimentoNormal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorRecebimento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditParcelasRecebimento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParcelasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlResumoRecebimento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetalheParcelaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.xtraTabPageDadosFiscais.ResumeLayout(false);
            this.xtraTabPageDadosFiscais.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotaFiscalServicos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotaFiscalProdutos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesButtonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataOrcamentodateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataOrcamentodateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFuncionarios.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPosicao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosicaoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditVeiculo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlacasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCPFCNPJ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodOrcamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClienteDTOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.GroupControl grpPrincipal;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtCPFCNPJ;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtCodOrcamento;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnSalvar;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
        private DevExpress.XtraBars.BarButtonItem btnPrimeiro;
        private DevExpress.XtraBars.BarButtonItem btnAnterior;
        private DevExpress.XtraBars.BarButtonItem btnProximo;
        private DevExpress.XtraBars.BarButtonItem btnUltimo;
        private System.Windows.Forms.BindingSource ClienteDTOBindingSource;
        private System.Windows.Forms.BindingSource PosicaoBindingSource;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPosicao;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditVeiculo;
        private DevExpress.XtraEditors.ComboBoxEdit cmbFuncionarios;
        private System.Windows.Forms.BindingSource OrcamentoDTOBindingSource;
        private DevExpress.XtraEditors.DateEdit dataOrcamentodateEdit;
        private DevExpress.XtraEditors.ButtonEdit ClientesButtonEdit;
        private System.Windows.Forms.BindingSource OrcamentoProdutoServicoBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripOrcamento;
        private System.Windows.Forms.ToolStripMenuItem DigitarOrcamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AlterarOrcamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExcluirOrcamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExcluirTudoOrcamentoToolStripMenuItem;
        private DevExpress.XtraBars.BarButtonItem btnImprimir;
        private System.Windows.Forms.BindingSource PlacasBindingSource;
        private DevExpress.XtraTab.XtraTabControl xtraTabControlDetalhesOrcamento;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageItensOrcamento;
        private DevExpress.XtraTab.XtraTabPage pgDetalhesOrcamento;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditFormaRecebimento;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private System.Windows.Forms.GroupBox groupBoxFormaRecebimentoNormal;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraGrid.GridControl gridControlResumoRecebimento;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditParcelasRecebimento;
        private System.Windows.Forms.BindingSource ParcelasBindingSource;
        private DevExpress.XtraEditors.TextEdit txtValorRecebimento;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageDadosFiscais;
        private DevExpress.XtraEditors.TextEdit txtNotaFiscalServicos;
        private DevExpress.XtraEditors.TextEdit txtNotaFiscalProdutos;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SimpleButton btnGerarOS;
        private DevExpress.XtraEditors.TextEdit ValorLiquidoTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraGrid.GridControl OrcamentoGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colTipo;
        private DevExpress.XtraGrid.Columns.GridColumn colProdutoServid;
        private DevExpress.XtraGrid.Columns.GridColumn colProdServdescricao;
        private DevExpress.XtraGrid.Columns.GridColumn colQtde;
        private DevExpress.XtraGrid.Columns.GridColumn colVlrUnitario;
        private DevExpress.XtraGrid.Columns.GridColumn colVlrTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colVlrDesconto;
        private DevExpress.XtraGrid.Columns.GridColumn colVlrLiquido;
        private DevExpress.XtraEditors.SimpleButton btnRecalculo;
        private DevExpress.XtraEditors.SimpleButton btnExcluirProdServ;
        private DevExpress.XtraEditors.SimpleButton btnEditarProdServ;
        private DevExpress.XtraEditors.SimpleButton btnInserirProdServ;
        private System.Windows.Forms.BindingSource FormaRecebimentoBindingSource;
        private DevExpress.XtraEditors.LabelControl lblDiferencaRecebimento;
        private DevExpress.XtraEditors.LabelControl lblDiferencaValor;
        private System.Windows.Forms.BindingSource DetalheParcelaBindingSource;
    }
}