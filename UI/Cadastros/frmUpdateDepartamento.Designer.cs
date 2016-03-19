namespace MechTech.UI.Cadastros
{
    partial class frmUpdateDepartamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateDepartamento));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnSalvar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.grpPrincipal = new DevExpress.XtraEditors.GroupControl();
            this.cepTextEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.DepartamentoDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.UFTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.municipioTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.codigoibgeButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.bairroTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.complementoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.numeroTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.enderecoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.nomeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.codigoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPrincipal)).BeginInit();
            this.grpPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cepTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartamentoDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UFTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.municipioTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoibgeButtonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bairroTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complementoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeroTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enderecoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(820, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 437);
            this.barDockControlBottom.Size = new System.Drawing.Size(820, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 413);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(820, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 413);
            // 
            // grpPrincipal
            // 
            this.grpPrincipal.AppearanceCaption.Options.UseTextOptions = true;
            this.grpPrincipal.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grpPrincipal.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.grpPrincipal.Controls.Add(this.cepTextEdit);
            this.grpPrincipal.Controls.Add(this.labelControl10);
            this.grpPrincipal.Controls.Add(this.UFTextEdit);
            this.grpPrincipal.Controls.Add(this.labelControl9);
            this.grpPrincipal.Controls.Add(this.municipioTextEdit);
            this.grpPrincipal.Controls.Add(this.labelControl8);
            this.grpPrincipal.Controls.Add(this.codigoibgeButtonEdit);
            this.grpPrincipal.Controls.Add(this.labelControl7);
            this.grpPrincipal.Controls.Add(this.labelControl6);
            this.grpPrincipal.Controls.Add(this.labelControl5);
            this.grpPrincipal.Controls.Add(this.bairroTextEdit);
            this.grpPrincipal.Controls.Add(this.complementoTextEdit);
            this.grpPrincipal.Controls.Add(this.labelControl4);
            this.grpPrincipal.Controls.Add(this.labelControl3);
            this.grpPrincipal.Controls.Add(this.labelControl2);
            this.grpPrincipal.Controls.Add(this.numeroTextEdit);
            this.grpPrincipal.Controls.Add(this.enderecoTextEdit);
            this.grpPrincipal.Controls.Add(this.nomeTextEdit);
            this.grpPrincipal.Controls.Add(this.labelControl1);
            this.grpPrincipal.Controls.Add(this.codigoTextEdit);
            this.grpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPrincipal.Location = new System.Drawing.Point(0, 24);
            this.grpPrincipal.Name = "grpPrincipal";
            this.grpPrincipal.Size = new System.Drawing.Size(820, 413);
            this.grpPrincipal.TabIndex = 4;
            this.grpPrincipal.Text = "Departamentos";
            // 
            // cepTextEdit
            // 
            this.cepTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DepartamentoDTOBindingSource, "Cep", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cepTextEdit.EnterMoveNextControl = true;
            this.cepTextEdit.Location = new System.Drawing.Point(105, 56);
            this.cepTextEdit.Name = "cepTextEdit";
            this.cepTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("cepTextEdit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, false)});
            this.cepTextEdit.Properties.Mask.EditMask = "99.999-999";
            this.cepTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.cepTextEdit.Properties.Mask.SaveLiteral = false;
            this.cepTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.cepTextEdit.Properties.MaxLength = 8;
            this.cepTextEdit.Size = new System.Drawing.Size(100, 22);
            this.cepTextEdit.TabIndex = 3;
            this.cepTextEdit.ToolTip = "Código de endereçamento postal fornecido pelos CORREIOS";
            this.cepTextEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cepTextEdit_ButtonClick);
            this.cepTextEdit.Validated += new System.EventHandler(this.cepTextEdit_Validated);
            // 
            // DepartamentoDTOBindingSource
            // 
            this.DepartamentoDTOBindingSource.DataSource = typeof(MechTech.Entities.DepartamentoDTO);
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(211, 60);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(17, 13);
            this.labelControl10.TabIndex = 22;
            this.labelControl10.Text = "UF:";
            // 
            // UFTextEdit
            // 
            this.UFTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DepartamentoDTOBindingSource, "Municipio.UF.Codigo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.UFTextEdit.EnterMoveNextControl = true;
            this.UFTextEdit.Location = new System.Drawing.Point(234, 56);
            this.UFTextEdit.Name = "UFTextEdit";
            this.UFTextEdit.Size = new System.Drawing.Size(36, 20);
            this.UFTextEdit.TabIndex = 4;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(496, 60);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(47, 13);
            this.labelControl9.TabIndex = 20;
            this.labelControl9.Text = "Município:";
            // 
            // municipioTextEdit
            // 
            this.municipioTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DepartamentoDTOBindingSource, "Municipio.Nome", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.municipioTextEdit.EnterMoveNextControl = true;
            this.municipioTextEdit.Location = new System.Drawing.Point(549, 56);
            this.municipioTextEdit.Name = "municipioTextEdit";
            this.municipioTextEdit.Properties.ReadOnly = true;
            this.municipioTextEdit.Size = new System.Drawing.Size(136, 20);
            this.municipioTextEdit.TabIndex = 6;
            this.municipioTextEdit.TabStop = false;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(282, 60);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(54, 13);
            this.labelControl8.TabIndex = 18;
            this.labelControl8.Text = "Cód. Mun.:";
            // 
            // codigoibgeButtonEdit
            // 
            this.codigoibgeButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DepartamentoDTOBindingSource, "Municipio.Codigoibge", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.codigoibgeButtonEdit.EnterMoveNextControl = true;
            this.codigoibgeButtonEdit.Location = new System.Drawing.Point(357, 56);
            this.codigoibgeButtonEdit.Name = "codigoibgeButtonEdit";
            this.codigoibgeButtonEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.codigoibgeButtonEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.codigoibgeButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("codigoibgeButtonEdit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.codigoibgeButtonEdit.Properties.Mask.EditMask = "d";
            this.codigoibgeButtonEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.codigoibgeButtonEdit.Size = new System.Drawing.Size(133, 22);
            this.codigoibgeButtonEdit.TabIndex = 5;
            this.codigoibgeButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.codigoibgeButtonEdit_ButtonClick);
            this.codigoibgeButtonEdit.Validated += new System.EventHandler(this.codigoibgeButtonEdit_Validated);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(30, 60);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(23, 13);
            this.labelControl7.TabIndex = 16;
            this.labelControl7.Text = "Cep:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(30, 109);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(32, 13);
            this.labelControl6.TabIndex = 15;
            this.labelControl6.Text = "Bairro:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(282, 109);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(69, 13);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "Complemento:";
            // 
            // bairroTextEdit
            // 
            this.bairroTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DepartamentoDTOBindingSource, "Bairro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.bairroTextEdit.EnterMoveNextControl = true;
            this.bairroTextEdit.Location = new System.Drawing.Point(105, 106);
            this.bairroTextEdit.Name = "bairroTextEdit";
            this.bairroTextEdit.Properties.MaxLength = 20;
            this.bairroTextEdit.Size = new System.Drawing.Size(165, 20);
            this.bairroTextEdit.TabIndex = 9;
            // 
            // complementoTextEdit
            // 
            this.complementoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DepartamentoDTOBindingSource, "Complemento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.complementoTextEdit.EnterMoveNextControl = true;
            this.complementoTextEdit.Location = new System.Drawing.Point(357, 106);
            this.complementoTextEdit.Name = "complementoTextEdit";
            this.complementoTextEdit.Properties.MaxLength = 20;
            this.complementoTextEdit.Size = new System.Drawing.Size(328, 20);
            this.complementoTextEdit.TabIndex = 10;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(496, 85);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(41, 13);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "Número:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(30, 85);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 13);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "Endereço:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(30, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(31, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Nome:";
            // 
            // numeroTextEdit
            // 
            this.numeroTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DepartamentoDTOBindingSource, "Numero", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numeroTextEdit.EnterMoveNextControl = true;
            this.numeroTextEdit.Location = new System.Drawing.Point(549, 82);
            this.numeroTextEdit.Name = "numeroTextEdit";
            this.numeroTextEdit.Properties.MaxLength = 6;
            this.numeroTextEdit.Size = new System.Drawing.Size(136, 20);
            this.numeroTextEdit.TabIndex = 8;
            // 
            // enderecoTextEdit
            // 
            this.enderecoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DepartamentoDTOBindingSource, "Endereco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.enderecoTextEdit.EnterMoveNextControl = true;
            this.enderecoTextEdit.Location = new System.Drawing.Point(105, 82);
            this.enderecoTextEdit.Name = "enderecoTextEdit";
            this.enderecoTextEdit.Properties.MaxLength = 40;
            this.enderecoTextEdit.Size = new System.Drawing.Size(385, 20);
            this.enderecoTextEdit.TabIndex = 7;
            // 
            // nomeTextEdit
            // 
            this.nomeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DepartamentoDTOBindingSource, "Nome", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nomeTextEdit.EnterMoveNextControl = true;
            this.nomeTextEdit.Location = new System.Drawing.Point(105, 32);
            this.nomeTextEdit.Name = "nomeTextEdit";
            this.nomeTextEdit.Properties.MaxLength = 40;
            this.nomeTextEdit.Size = new System.Drawing.Size(580, 20);
            this.nomeTextEdit.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Código:";
            // 
            // codigoTextEdit
            // 
            this.codigoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DepartamentoDTOBindingSource, "Codigo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.codigoTextEdit.EnterMoveNextControl = true;
            this.codigoTextEdit.Location = new System.Drawing.Point(105, 6);
            this.codigoTextEdit.Name = "codigoTextEdit";
            this.codigoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.codigoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.codigoTextEdit.Properties.Mask.EditMask = "d";
            this.codigoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.codigoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.codigoTextEdit.TabIndex = 1;
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // frmUpdateDepartamento
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 437);
            this.Controls.Add(this.grpPrincipal);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmUpdateDepartamento";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUpdateDepartamento_FormClosed);
            this.Load += new System.EventHandler(this.frmUpdateDepartamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPrincipal)).EndInit();
            this.grpPrincipal.ResumeLayout(false);
            this.grpPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cepTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartamentoDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UFTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.municipioTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoibgeButtonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bairroTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complementoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeroTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enderecoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
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
        private DevExpress.XtraEditors.GroupControl grpPrincipal;
        private DevExpress.XtraEditors.ButtonEdit cepTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit UFTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit municipioTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ButtonEdit codigoibgeButtonEdit;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit bairroTextEdit;
        private DevExpress.XtraEditors.TextEdit complementoTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit numeroTextEdit;
        private DevExpress.XtraEditors.TextEdit enderecoTextEdit;
        private DevExpress.XtraEditors.TextEdit nomeTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit codigoTextEdit;
        private System.Windows.Forms.BindingSource DepartamentoDTOBindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
    }
}