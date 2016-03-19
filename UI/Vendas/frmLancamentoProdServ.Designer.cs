namespace MechTech.UI.Vendas
{
    partial class frmLancamentoProdServ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLancamentoProdServ));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnSalvar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.ProdutoServicoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpPrincipal = new DevExpress.XtraEditors.GroupControl();
            this.calcEditValorDesconto = new DevExpress.XtraEditors.CalcEdit();
            this.OrcamentoProdutoServicoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrcamentoDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.calcEditValorUnitario = new DevExpress.XtraEditors.CalcEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtQuantidade = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblProdutoServico = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditProdutoServico = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProdutoServicoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPrincipal)).BeginInit();
            this.grpPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calcEditValorDesconto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrcamentoProdutoServicoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrcamentoDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcEditValorUnitario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantidade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditProdutoServico.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.barDockControlTop.Size = new System.Drawing.Size(447, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 150);
            this.barDockControlBottom.Size = new System.Drawing.Size(447, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 126);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(447, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 126);
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // ProdutoServicoBindingSource
            // 
            this.ProdutoServicoBindingSource.DataSource = typeof(MechTech.Entities.ProdutoServicoDTO);
            // 
            // grpPrincipal
            // 
            this.grpPrincipal.AppearanceCaption.Options.UseTextOptions = true;
            this.grpPrincipal.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grpPrincipal.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.grpPrincipal.Controls.Add(this.calcEditValorDesconto);
            this.grpPrincipal.Controls.Add(this.calcEditValorUnitario);
            this.grpPrincipal.Controls.Add(this.labelControl4);
            this.grpPrincipal.Controls.Add(this.labelControl3);
            this.grpPrincipal.Controls.Add(this.txtQuantidade);
            this.grpPrincipal.Controls.Add(this.labelControl2);
            this.grpPrincipal.Controls.Add(this.lblProdutoServico);
            this.grpPrincipal.Controls.Add(this.lookUpEditProdutoServico);
            this.grpPrincipal.Controls.Add(this.labelControl1);
            this.grpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPrincipal.Location = new System.Drawing.Point(0, 24);
            this.grpPrincipal.Name = "grpPrincipal";
            this.grpPrincipal.Size = new System.Drawing.Size(447, 126);
            this.grpPrincipal.TabIndex = 7;
            this.grpPrincipal.Text = "Produtos e Serviços";
            // 
            // calcEditValorDesconto
            // 
            this.calcEditValorDesconto.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrcamentoProdutoServicoBindingSource, "ValorDesconto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.calcEditValorDesconto.EnterMoveNextControl = true;
            this.calcEditValorDesconto.Location = new System.Drawing.Point(111, 97);
            this.calcEditValorDesconto.MenuManager = this.barManager;
            this.calcEditValorDesconto.Name = "calcEditValorDesconto";
            this.calcEditValorDesconto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcEditValorDesconto.Properties.DisplayFormat.FormatString = "c";
            this.calcEditValorDesconto.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcEditValorDesconto.Size = new System.Drawing.Size(125, 20);
            this.calcEditValorDesconto.TabIndex = 4;
            // 
            // OrcamentoProdutoServicoBindingSource
            // 
            this.OrcamentoProdutoServicoBindingSource.DataMember = "Produtoservico";
            this.OrcamentoProdutoServicoBindingSource.DataSource = this.OrcamentoDTOBindingSource;
            // 
            // OrcamentoDTOBindingSource
            // 
            this.OrcamentoDTOBindingSource.DataSource = typeof(MechTech.Entities.OrcamentoDTO);
            // 
            // calcEditValorUnitario
            // 
            this.calcEditValorUnitario.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrcamentoProdutoServicoBindingSource, "ValorUnitario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.calcEditValorUnitario.EnterMoveNextControl = true;
            this.calcEditValorUnitario.Location = new System.Drawing.Point(111, 71);
            this.calcEditValorUnitario.MenuManager = this.barManager;
            this.calcEditValorUnitario.Name = "calcEditValorUnitario";
            this.calcEditValorUnitario.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcEditValorUnitario.Properties.DisplayFormat.FormatString = "c";
            this.calcEditValorUnitario.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcEditValorUnitario.Size = new System.Drawing.Size(125, 20);
            this.calcEditValorUnitario.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(24, 101);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(76, 13);
            this.labelControl4.TabIndex = 26;
            this.labelControl4.Text = "Valor Desconto:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(24, 74);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(68, 13);
            this.labelControl3.TabIndex = 24;
            this.labelControl3.Text = "Valor Unitário:";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrcamentoProdutoServicoBindingSource, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtQuantidade.EnterMoveNextControl = true;
            this.txtQuantidade.Location = new System.Drawing.Point(111, 44);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Properties.Appearance.Options.UseTextOptions = true;
            this.txtQuantidade.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtQuantidade.Size = new System.Drawing.Size(125, 20);
            this.txtQuantidade.TabIndex = 2;
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidade_KeyPress);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(24, 47);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 13);
            this.labelControl2.TabIndex = 22;
            this.labelControl2.Text = "Quantidade:";
            // 
            // lblProdutoServico
            // 
            this.lblProdutoServico.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdutoServico.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblProdutoServico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OrcamentoProdutoServicoBindingSource, "Produto.Descricao", true));
            this.lblProdutoServico.Location = new System.Drawing.Point(24, 28);
            this.lblProdutoServico.Name = "lblProdutoServico";
            this.lblProdutoServico.Size = new System.Drawing.Size(418, 13);
            this.lblProdutoServico.TabIndex = 21;
            this.lblProdutoServico.Text = "[]";
            // 
            // lookUpEditProdutoServico
            // 
            this.lookUpEditProdutoServico.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.OrcamentoProdutoServicoBindingSource, "Produto.Descricao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lookUpEditProdutoServico.EnterMoveNextControl = true;
            this.lookUpEditProdutoServico.Location = new System.Drawing.Point(111, 5);
            this.lookUpEditProdutoServico.MenuManager = this.barManager;
            this.lookUpEditProdutoServico.Name = "lookUpEditProdutoServico";
            this.lookUpEditProdutoServico.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditProdutoServico.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "CÓDIGO"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descricao", "DESCRIÇÃO", 56, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpEditProdutoServico.Properties.DataSource = this.ProdutoServicoBindingSource;
            this.lookUpEditProdutoServico.Properties.DisplayMember = "Descricao";
            this.lookUpEditProdutoServico.Properties.NullText = "";
            this.lookUpEditProdutoServico.Properties.ValueMember = "Descricao";
            this.lookUpEditProdutoServico.Size = new System.Drawing.Size(331, 20);
            this.lookUpEditProdutoServico.TabIndex = 1;
            this.lookUpEditProdutoServico.EditValueChanged += new System.EventHandler(this.lookUpEditProdutoServico_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(81, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Produto/Serviço:";
            // 
            // frmLancamentoProdServ
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 150);
            this.Controls.Add(this.grpPrincipal);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmLancamentoProdServ";
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProdutoServicoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPrincipal)).EndInit();
            this.grpPrincipal.ResumeLayout(false);
            this.grpPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calcEditValorDesconto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrcamentoProdutoServicoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrcamentoDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcEditValorUnitario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantidade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditProdutoServico.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnSalvar;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private System.Windows.Forms.BindingSource ProdutoServicoBindingSource;
        private DevExpress.XtraEditors.GroupControl grpPrincipal;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditProdutoServico;
        private DevExpress.XtraEditors.LabelControl lblProdutoServico;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtQuantidade;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CalcEdit calcEditValorDesconto;
        private DevExpress.XtraEditors.CalcEdit calcEditValorUnitario;
        private System.Windows.Forms.BindingSource OrcamentoDTOBindingSource;
        private System.Windows.Forms.BindingSource OrcamentoProdutoServicoBindingSource;
    }
}