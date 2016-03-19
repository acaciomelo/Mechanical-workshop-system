namespace MechTech.UI.Cadastros
{
    partial class frmUpdateVeiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateVeiculo));
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.b = new DevExpress.XtraBars.BarButtonItem();
            this.BtnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnPrimeiro = new DevExpress.XtraBars.BarButtonItem();
            this.BtnAnterior = new DevExpress.XtraBars.BarButtonItem();
            this.BtnProximo = new DevExpress.XtraBars.BarButtonItem();
            this.BtnUltimo = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.grpVeiculos = new DevExpress.XtraEditors.GroupControl();
            this.xtraTabControl = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.lookUpTipo = new DevExpress.XtraEditors.LookUpEdit();
            this.VeiculoDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TipoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpMarca = new DevExpress.XtraEditors.LookUpEdit();
            this.MarcaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtVeiculo = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpVeiculos)).BeginInit();
            this.grpVeiculos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).BeginInit();
            this.xtraTabControl.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpTipo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VeiculoDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpMarca.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MarcaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVeiculo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(803, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 327);
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControl1);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.b,
            this.BtnCancelar,
            this.BtnPrimeiro,
            this.BtnAnterior,
            this.BtnProximo,
            this.BtnUltimo});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.b, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BtnCancelar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BtnPrimeiro, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BtnAnterior, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BtnProximo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BtnUltimo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menu principal";
            // 
            // b
            // 
            this.b.Caption = "&Salvar";
            this.b.Glyph = ((System.Drawing.Image)(resources.GetObject("b.Glyph")));
            this.b.Id = 0;
            this.b.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("b.LargeGlyph")));
            this.b.Name = "b";
            this.b.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnSalvar_ItemClick);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Caption = "&Cancelar";
            this.BtnCancelar.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnCancelar.Glyph")));
            this.BtnCancelar.Id = 1;
            this.BtnCancelar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BtnCancelar.LargeGlyph")));
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnCancelar_ItemClick);
            // 
            // BtnPrimeiro
            // 
            this.BtnPrimeiro.Caption = "&Primeiro";
            this.BtnPrimeiro.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnPrimeiro.Glyph")));
            this.BtnPrimeiro.Id = 2;
            this.BtnPrimeiro.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BtnPrimeiro.LargeGlyph")));
            this.BtnPrimeiro.Name = "BtnPrimeiro";
            this.BtnPrimeiro.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnPrimeiro_ItemClick);
            // 
            // BtnAnterior
            // 
            this.BtnAnterior.Caption = "&Anterior";
            this.BtnAnterior.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnAnterior.Glyph")));
            this.BtnAnterior.Id = 3;
            this.BtnAnterior.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BtnAnterior.LargeGlyph")));
            this.BtnAnterior.Name = "BtnAnterior";
            this.BtnAnterior.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAnterior_ItemClick);
            // 
            // BtnProximo
            // 
            this.BtnProximo.Caption = "P&róximo";
            this.BtnProximo.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnProximo.Glyph")));
            this.BtnProximo.Id = 4;
            this.BtnProximo.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BtnProximo.LargeGlyph")));
            this.BtnProximo.Name = "BtnProximo";
            this.BtnProximo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnProximo_ItemClick);
            // 
            // BtnUltimo
            // 
            this.BtnUltimo.Caption = "&Último";
            this.BtnUltimo.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnUltimo.Glyph")));
            this.BtnUltimo.Id = 5;
            this.BtnUltimo.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BtnUltimo.LargeGlyph")));
            this.BtnUltimo.Name = "BtnUltimo";
            this.BtnUltimo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnUltimo_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(803, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 351);
            this.barDockControlBottom.Size = new System.Drawing.Size(803, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 327);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl1.Location = new System.Drawing.Point(803, 24);
            this.barDockControl1.Size = new System.Drawing.Size(0, 327);
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // grpVeiculos
            // 
            this.grpVeiculos.AppearanceCaption.Options.UseTextOptions = true;
            this.grpVeiculos.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grpVeiculos.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.grpVeiculos.Controls.Add(this.xtraTabControl);
            this.grpVeiculos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpVeiculos.Location = new System.Drawing.Point(0, 24);
            this.grpVeiculos.Name = "grpVeiculos";
            this.grpVeiculos.Size = new System.Drawing.Size(803, 327);
            this.grpVeiculos.TabIndex = 14;
            this.grpVeiculos.Text = "Veículos";
            // 
            // xtraTabControl
            // 
            this.xtraTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl.Location = new System.Drawing.Point(21, 2);
            this.xtraTabControl.Name = "xtraTabControl";
            this.xtraTabControl.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl.Size = new System.Drawing.Size(780, 323);
            this.xtraTabControl.TabIndex = 9;
            this.xtraTabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.AutoScroll = true;
            this.xtraTabPage1.Controls.Add(this.lookUpTipo);
            this.xtraTabPage1.Controls.Add(this.label1);
            this.xtraTabPage1.Controls.Add(this.lookUpMarca);
            this.xtraTabPage1.Controls.Add(this.txtVeiculo);
            this.xtraTabPage1.Controls.Add(this.label10);
            this.xtraTabPage1.Controls.Add(this.txtId);
            this.xtraTabPage1.Controls.Add(this.label7);
            this.xtraTabPage1.Controls.Add(this.label2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(774, 295);
            this.xtraTabPage1.Text = "Básico";
            //this.xtraTabPage1.Paint += new System.Windows.Forms.PaintEventHandler(this.xtraTabPage1_Paint);
            // 
            // lookUpTipo
            // 
            this.lookUpTipo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.VeiculoDTOBindingSource, "Tipo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lookUpTipo.EnterMoveNextControl = true;
            this.lookUpTipo.Location = new System.Drawing.Point(80, 66);
            this.lookUpTipo.MenuManager = this.barManager;
            this.lookUpTipo.Name = "lookUpTipo";
            this.lookUpTipo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpTipo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descricao", 50, "Descrição")});
            this.lookUpTipo.Properties.DataSource = this.TipoBindingSource;
            this.lookUpTipo.Properties.DisplayMember = "Descricao";
            this.lookUpTipo.Properties.ValueMember = "Id";
            this.lookUpTipo.Size = new System.Drawing.Size(240, 20);
            this.lookUpTipo.TabIndex = 1;
            this.lookUpTipo.EditValueChanged += new System.EventHandler(this.lookUpTipo_EditValueChanged);
            // 
            // VeiculoDTOBindingSource
            // 
            this.VeiculoDTOBindingSource.DataSource = typeof(MechTech.Entities.VeiculoDTO);
            // 
            // TipoBindingSource
            // 
            this.TipoBindingSource.DataSource = typeof(MechTech.Util.Rotina);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Tipo:";
            // 
            // lookUpMarca
            // 
            this.lookUpMarca.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.VeiculoDTOBindingSource, "Id_Marca", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lookUpMarca.EnterMoveNextControl = true;
            this.lookUpMarca.Location = new System.Drawing.Point(80, 92);
            this.lookUpMarca.MenuManager = this.barManager;
            this.lookUpMarca.Name = "lookUpMarca";
            this.lookUpMarca.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpMarca.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descricao", 50, "Descrição")});
            this.lookUpMarca.Properties.DataSource = this.MarcaBindingSource;
            this.lookUpMarca.Properties.DisplayMember = "Descricao";
            this.lookUpMarca.Properties.ValueMember = "Id";
            this.lookUpMarca.Size = new System.Drawing.Size(240, 20);
            this.lookUpMarca.TabIndex = 2;
            // 
            // MarcaBindingSource
            // 
            this.MarcaBindingSource.DataSource = typeof(MechTech.Util.Rotina);
            // 
            // txtVeiculo
            // 
            this.txtVeiculo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.VeiculoDTOBindingSource, "Veiculo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtVeiculo.EnterMoveNextControl = true;
            this.txtVeiculo.Location = new System.Drawing.Point(80, 40);
            this.txtVeiculo.Name = "txtVeiculo";
            this.txtVeiculo.Properties.Mask.EditMask = "(\\d?\\d?\\d?)\\d\\d\\d-\\d\\d\\d\\d";
            this.txtVeiculo.Properties.Mask.SaveLiteral = false;
            this.txtVeiculo.Properties.MaxLength = 50;
            this.txtVeiculo.Size = new System.Drawing.Size(240, 20);
            this.txtVeiculo.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 50;
            this.label10.Text = "Código:";
            // 
            // txtId
            // 
            this.txtId.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.VeiculoDTOBindingSource, "Id", true));
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(80, 13);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(60, 20);
            this.txtId.TabIndex = 30;
            this.txtId.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Marca:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Veículo:";
            // 
            // frmUpdateVeiculo
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 351);
            this.Controls.Add(this.grpVeiculos);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmUpdateVeiculo";
            this.Text = "Cadastro de Veículos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUpdateVeiculo_FormClosed);
            this.Load += new System.EventHandler(this.frmUpdateVeiculo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpVeiculos)).EndInit();
            this.grpVeiculos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).EndInit();
            this.xtraTabControl.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpTipo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VeiculoDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpMarca.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MarcaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVeiculo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem b;
        private DevExpress.XtraBars.BarButtonItem BtnCancelar;
        private DevExpress.XtraBars.BarButtonItem BtnPrimeiro;
        private DevExpress.XtraBars.BarButtonItem BtnAnterior;
        private DevExpress.XtraBars.BarButtonItem BtnProximo;
        private DevExpress.XtraBars.BarButtonItem BtnUltimo;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.GroupControl grpVeiculos;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource VeiculoDTOBindingSource;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraEditors.TextEdit txtVeiculo;
        private System.Windows.Forms.BindingSource MarcaBindingSource;
        private DevExpress.XtraEditors.LookUpEdit lookUpMarca;
        private DevExpress.XtraEditors.LookUpEdit lookUpTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource TipoBindingSource;
    }
}