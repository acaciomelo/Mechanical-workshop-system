namespace MechTech.UI.Cadastros
{
    partial class frmUpdateFuncao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateFuncao));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.FuncaoDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SalarioTipoDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.CalculoHorasCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.horasTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.salariotipoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.salariofuncaoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.descricaocboTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.codigocboButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.nomeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.codigofuncaoTextEdit = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.FuncaoDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalarioTipoDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPrincipal)).BeginInit();
            this.grpPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CalculoHorasCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horasTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salariotipoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salariofuncaoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descricaocboTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigocboButtonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigofuncaoTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // FuncaoDTOBindingSource
            // 
            this.FuncaoDTOBindingSource.DataSource = typeof(MechTech.Entities.FuncaoDTO);
            // 
            // SalarioTipoDTOBindingSource
            // 
            this.SalarioTipoDTOBindingSource.DataSource = typeof(MechTech.Entities.SalarioTipoDTO);
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 558);
            this.barDockControlBottom.Size = new System.Drawing.Size(794, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 534);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(794, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 534);
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
            this.grpPrincipal.Controls.Add(this.CalculoHorasCheckEdit);
            this.grpPrincipal.Controls.Add(this.labelControl7);
            this.grpPrincipal.Controls.Add(this.horasTextEdit);
            this.grpPrincipal.Controls.Add(this.labelControl6);
            this.grpPrincipal.Controls.Add(this.salariotipoLookUpEdit);
            this.grpPrincipal.Controls.Add(this.labelControl5);
            this.grpPrincipal.Controls.Add(this.salariofuncaoTextEdit);
            this.grpPrincipal.Controls.Add(this.labelControl4);
            this.grpPrincipal.Controls.Add(this.descricaocboTextEdit);
            this.grpPrincipal.Controls.Add(this.labelControl3);
            this.grpPrincipal.Controls.Add(this.codigocboButtonEdit);
            this.grpPrincipal.Controls.Add(this.labelControl2);
            this.grpPrincipal.Controls.Add(this.nomeTextEdit);
            this.grpPrincipal.Controls.Add(this.labelControl1);
            this.grpPrincipal.Controls.Add(this.codigofuncaoTextEdit);
            this.grpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPrincipal.Location = new System.Drawing.Point(0, 24);
            this.grpPrincipal.Name = "grpPrincipal";
            this.grpPrincipal.Size = new System.Drawing.Size(794, 534);
            this.grpPrincipal.TabIndex = 6;
            this.grpPrincipal.Text = "Cargos";
            // 
            // CalculoHorasCheckEdit
            // 
            this.CalculoHorasCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FuncaoDTOBindingSource, "CalculoHoras", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CalculoHorasCheckEdit.EnterMoveNextControl = true;
            this.CalculoHorasCheckEdit.Location = new System.Drawing.Point(514, 58);
            this.CalculoHorasCheckEdit.MenuManager = this.barManager;
            this.CalculoHorasCheckEdit.Name = "CalculoHorasCheckEdit";
            this.CalculoHorasCheckEdit.Properties.Caption = "Cálculo em horas";
            this.CalculoHorasCheckEdit.Size = new System.Drawing.Size(129, 19);
            this.CalculoHorasCheckEdit.TabIndex = 7;
            this.CalculoHorasCheckEdit.Visible = false;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(341, 61);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(61, 13);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "Nº de horas:";
            // 
            // horasTextEdit
            // 
            this.horasTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FuncaoDTOBindingSource, "Horas", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.horasTextEdit.EnterMoveNextControl = true;
            this.horasTextEdit.Location = new System.Drawing.Point(408, 58);
            this.horasTextEdit.Name = "horasTextEdit";
            this.horasTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.horasTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.horasTextEdit.Properties.Mask.EditMask = "d";
            this.horasTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.horasTextEdit.Size = new System.Drawing.Size(100, 20);
            this.horasTextEdit.TabIndex = 6;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(179, 61);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(24, 13);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "Tipo:";
            // 
            // salariotipoLookUpEdit
            // 
            this.salariotipoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FuncaoDTOBindingSource, "Salariotipo.Id", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.salariotipoLookUpEdit.EnterMoveNextControl = true;
            this.salariotipoLookUpEdit.Location = new System.Drawing.Point(235, 58);
            this.salariotipoLookUpEdit.Name = "salariotipoLookUpEdit";
            this.salariotipoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.salariotipoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descricao", "Descrição")});
            this.salariotipoLookUpEdit.Properties.DataSource = this.SalarioTipoDTOBindingSource;
            this.salariotipoLookUpEdit.Properties.DisplayMember = "Descricao";
            this.salariotipoLookUpEdit.Properties.NullText = "";
            this.salariotipoLookUpEdit.Properties.ValueMember = "Id";
            this.salariotipoLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.salariotipoLookUpEdit.TabIndex = 5;
            this.salariotipoLookUpEdit.TextChanged += new System.EventHandler(this.salariotipoLookUpEdit_TextChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(30, 63);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 13);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "Salário:";
            // 
            // salariofuncaoTextEdit
            // 
            this.salariofuncaoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FuncaoDTOBindingSource, "Salariofuncao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.salariofuncaoTextEdit.EnterMoveNextControl = true;
            this.salariofuncaoTextEdit.Location = new System.Drawing.Point(73, 58);
            this.salariofuncaoTextEdit.Name = "salariofuncaoTextEdit";
            this.salariofuncaoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.salariofuncaoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.salariofuncaoTextEdit.Properties.Mask.EditMask = "c2";
            this.salariofuncaoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.salariofuncaoTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.salariofuncaoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.salariofuncaoTextEdit.TabIndex = 4;
            this.salariofuncaoTextEdit.ToolTip = "Valor do salário para a função";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(179, 35);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(50, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Descrição:";
            // 
            // descricaocboTextEdit
            // 
            this.descricaocboTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FuncaoDTOBindingSource, "CBO.Descricao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.descricaocboTextEdit.EnterMoveNextControl = true;
            this.descricaocboTextEdit.Location = new System.Drawing.Point(235, 32);
            this.descricaocboTextEdit.Name = "descricaocboTextEdit";
            this.descricaocboTextEdit.Properties.ReadOnly = true;
            this.descricaocboTextEdit.Size = new System.Drawing.Size(408, 20);
            this.descricaocboTextEdit.TabIndex = 3;
            this.descricaocboTextEdit.TabStop = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(30, 36);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(25, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "CBO:";
            // 
            // codigocboButtonEdit
            // 
            this.codigocboButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FuncaoDTOBindingSource, "CBO.Codigo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.codigocboButtonEdit.EnterMoveNextControl = true;
            this.codigocboButtonEdit.Location = new System.Drawing.Point(73, 32);
            this.codigocboButtonEdit.Name = "codigocboButtonEdit";
            this.codigocboButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("codigocboButtonEdit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.codigocboButtonEdit.Properties.MaxLength = 6;
            this.codigocboButtonEdit.Size = new System.Drawing.Size(100, 22);
            this.codigocboButtonEdit.TabIndex = 2;
            this.codigocboButtonEdit.ToolTip = "CBO da função";
            this.codigocboButtonEdit.Click += new System.EventHandler(this.codigocboButtonEdit_Click);
            this.codigocboButtonEdit.Validated += new System.EventHandler(this.codigocboButtonEdit_Validated);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(179, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(31, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Nome:";
            // 
            // nomeTextEdit
            // 
            this.nomeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FuncaoDTOBindingSource, "Nome", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nomeTextEdit.EnterMoveNextControl = true;
            this.nomeTextEdit.Location = new System.Drawing.Point(235, 6);
            this.nomeTextEdit.Name = "nomeTextEdit";
            this.nomeTextEdit.Properties.MaxLength = 30;
            this.nomeTextEdit.Size = new System.Drawing.Size(408, 20);
            this.nomeTextEdit.TabIndex = 1;
            this.nomeTextEdit.ToolTip = "Nome da função";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Código:";
            // 
            // codigofuncaoTextEdit
            // 
            this.codigofuncaoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FuncaoDTOBindingSource, "Id", true));
            this.codigofuncaoTextEdit.EnterMoveNextControl = true;
            this.codigofuncaoTextEdit.Location = new System.Drawing.Point(73, 6);
            this.codigofuncaoTextEdit.Name = "codigofuncaoTextEdit";
            this.codigofuncaoTextEdit.Properties.ReadOnly = true;
            this.codigofuncaoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.codigofuncaoTextEdit.TabIndex = 0;
            this.codigofuncaoTextEdit.TabStop = false;
            // 
            // frmUpdateFuncao
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 558);
            this.Controls.Add(this.grpPrincipal);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmUpdateFuncao";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUpdateFuncao_FormClosed);
            this.Load += new System.EventHandler(this.frmUpdateFuncao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FuncaoDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalarioTipoDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPrincipal)).EndInit();
            this.grpPrincipal.ResumeLayout(false);
            this.grpPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CalculoHorasCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horasTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salariotipoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salariofuncaoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descricaocboTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigocboButtonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigofuncaoTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource FuncaoDTOBindingSource;
        private System.Windows.Forms.BindingSource SalarioTipoDTOBindingSource;
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
        private DevExpress.XtraEditors.CheckEdit CalculoHorasCheckEdit;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit horasTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LookUpEdit salariotipoLookUpEdit;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit salariofuncaoTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit descricaocboTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ButtonEdit codigocboButtonEdit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit nomeTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit codigofuncaoTextEdit;
    }
}