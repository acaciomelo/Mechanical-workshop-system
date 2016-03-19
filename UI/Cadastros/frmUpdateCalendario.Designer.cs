namespace MechTech.UI.Cadastros
{
    partial class frmUpdateCalendario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateCalendario));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnSalvar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.grpPrincipal = new DevExpress.XtraEditors.GroupControl();
            this.TerminaAnospinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.FeriadoDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RepetircheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.textEditObservacao = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.municipioTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.codigoIBGEButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.labelEstado = new DevExpress.XtraEditors.LabelControl();
            this.uFLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.UFDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelMunicipio = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tipoComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.especieComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEditFeriado = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.TerminaradioGroup = new DevExpress.XtraEditors.RadioGroup();
            this.MunicipioDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPrincipal)).BeginInit();
            this.grpPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TerminaAnospinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeriadoDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepetircheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditObservacao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.municipioTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoIBGEButtonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uFLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UFDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.especieComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFeriado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerminaradioGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MunicipioDTOBindingSource)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(444, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 253);
            this.barDockControlBottom.Size = new System.Drawing.Size(444, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 229);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(444, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 229);
            // 
            // grpPrincipal
            // 
            this.grpPrincipal.AppearanceCaption.Options.UseTextOptions = true;
            this.grpPrincipal.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grpPrincipal.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.grpPrincipal.Controls.Add(this.TerminaAnospinEdit);
            this.grpPrincipal.Controls.Add(this.RepetircheckEdit);
            this.grpPrincipal.Controls.Add(this.textEditObservacao);
            this.grpPrincipal.Controls.Add(this.labelControl4);
            this.grpPrincipal.Controls.Add(this.municipioTextEdit);
            this.grpPrincipal.Controls.Add(this.codigoIBGEButtonEdit);
            this.grpPrincipal.Controls.Add(this.labelEstado);
            this.grpPrincipal.Controls.Add(this.uFLookUpEdit);
            this.grpPrincipal.Controls.Add(this.labelMunicipio);
            this.grpPrincipal.Controls.Add(this.labelControl3);
            this.grpPrincipal.Controls.Add(this.tipoComboBoxEdit);
            this.grpPrincipal.Controls.Add(this.especieComboBoxEdit);
            this.grpPrincipal.Controls.Add(this.labelControl2);
            this.grpPrincipal.Controls.Add(this.textEditFeriado);
            this.grpPrincipal.Controls.Add(this.labelControl1);
            this.grpPrincipal.Controls.Add(this.TerminaradioGroup);
            this.grpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPrincipal.Location = new System.Drawing.Point(0, 24);
            this.grpPrincipal.Name = "grpPrincipal";
            this.grpPrincipal.Size = new System.Drawing.Size(444, 229);
            this.grpPrincipal.TabIndex = 6;
            this.grpPrincipal.Text = "Feriado";
            // 
            // TerminaAnospinEdit
            // 
            this.TerminaAnospinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FeriadoDTOBindingSource, "TerminaAno", true));
            this.TerminaAnospinEdit.EditValue = new decimal(new int[] {
            2013,
            0,
            0,
            0});
            this.TerminaAnospinEdit.Enabled = false;
            this.TerminaAnospinEdit.Location = new System.Drawing.Point(132, 193);
            this.TerminaAnospinEdit.MenuManager = this.barManager;
            this.TerminaAnospinEdit.Name = "TerminaAnospinEdit";
            this.TerminaAnospinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TerminaAnospinEdit.Properties.Mask.EditMask = "0000";
            this.TerminaAnospinEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.TerminaAnospinEdit.Properties.Mask.PlaceHolder = ' ';
            this.TerminaAnospinEdit.Properties.Mask.SaveLiteral = false;
            this.TerminaAnospinEdit.Properties.MaxValue = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.TerminaAnospinEdit.Properties.MinValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.TerminaAnospinEdit.Size = new System.Drawing.Size(100, 20);
            this.TerminaAnospinEdit.TabIndex = 17;
            // 
            // FeriadoDTOBindingSource
            // 
            this.FeriadoDTOBindingSource.DataSource = typeof(MechTech.Entities.FeriadoDTO);
            // 
            // RepetircheckEdit
            // 
            this.RepetircheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FeriadoDTOBindingSource, "Repete", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RepetircheckEdit.Enabled = false;
            this.RepetircheckEdit.Location = new System.Drawing.Point(28, 137);
            this.RepetircheckEdit.MenuManager = this.barManager;
            this.RepetircheckEdit.Name = "RepetircheckEdit";
            this.RepetircheckEdit.Properties.Caption = "Repetir feriado";
            this.RepetircheckEdit.Size = new System.Drawing.Size(122, 19);
            this.RepetircheckEdit.TabIndex = 15;
            this.RepetircheckEdit.CheckedChanged += new System.EventHandler(this.RepetircheckEdit_CheckedChanged);
            // 
            // textEditObservacao
            // 
            this.textEditObservacao.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FeriadoDTOBindingSource, "Observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textEditObservacao.EnterMoveNextControl = true;
            this.textEditObservacao.Location = new System.Drawing.Point(132, 111);
            this.textEditObservacao.Name = "textEditObservacao";
            this.textEditObservacao.Size = new System.Drawing.Size(300, 20);
            this.textEditObservacao.TabIndex = 14;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(30, 114);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(67, 13);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = "Observações:";
            // 
            // municipioTextEdit
            // 
            this.municipioTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FeriadoDTOBindingSource, "Municipio.Nome", true));
            this.municipioTextEdit.Location = new System.Drawing.Point(238, 60);
            this.municipioTextEdit.Name = "municipioTextEdit";
            this.municipioTextEdit.Properties.ReadOnly = true;
            this.municipioTextEdit.Size = new System.Drawing.Size(194, 20);
            this.municipioTextEdit.TabIndex = 12;
            this.municipioTextEdit.TabStop = false;
            // 
            // codigoIBGEButtonEdit
            // 
            this.codigoIBGEButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FeriadoDTOBindingSource, "Municipio.CodigoIBGE", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.codigoIBGEButtonEdit.Enabled = false;
            this.codigoIBGEButtonEdit.EnterMoveNextControl = true;
            this.codigoIBGEButtonEdit.Location = new System.Drawing.Point(132, 59);
            this.codigoIBGEButtonEdit.Name = "codigoIBGEButtonEdit";
            this.codigoIBGEButtonEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.codigoIBGEButtonEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.codigoIBGEButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("codigoIBGEButtonEdit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.codigoIBGEButtonEdit.Properties.Mask.EditMask = "d";
            this.codigoIBGEButtonEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.codigoIBGEButtonEdit.Size = new System.Drawing.Size(100, 22);
            this.codigoIBGEButtonEdit.TabIndex = 3;
            this.codigoIBGEButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.codigoIBGEButtonEdit_ButtonClick);
            this.codigoIBGEButtonEdit.Validated += new System.EventHandler(this.codigoIBGEButtonEdit_Validated);
            // 
            // labelEstado
            // 
            this.labelEstado.Enabled = false;
            this.labelEstado.Location = new System.Drawing.Point(30, 88);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(61, 13);
            this.labelEstado.TabIndex = 10;
            this.labelEstado.Text = "Estado (UF):";
            // 
            // uFLookUpEdit
            // 
            this.uFLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FeriadoDTOBindingSource, "UF.Id", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.uFLookUpEdit.Enabled = false;
            this.uFLookUpEdit.EnterMoveNextControl = true;
            this.uFLookUpEdit.Location = new System.Drawing.Point(132, 85);
            this.uFLookUpEdit.Name = "uFLookUpEdit";
            this.uFLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uFLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Codigo", "Sigla", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descricao", 30, "Descrição")});
            this.uFLookUpEdit.Properties.DataSource = this.UFDTOBindingSource;
            this.uFLookUpEdit.Properties.DisplayMember = "Codigo";
            this.uFLookUpEdit.Properties.NullText = "";
            this.uFLookUpEdit.Properties.ValueMember = "Id";
            this.uFLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.uFLookUpEdit.TabIndex = 4;
            // 
            // UFDTOBindingSource
            // 
            this.UFDTOBindingSource.DataSource = typeof(MechTech.Entities.UFDTO);
            // 
            // labelMunicipio
            // 
            this.labelMunicipio.Enabled = false;
            this.labelMunicipio.Location = new System.Drawing.Point(30, 63);
            this.labelMunicipio.Name = "labelMunicipio";
            this.labelMunicipio.Size = new System.Drawing.Size(47, 13);
            this.labelMunicipio.TabIndex = 8;
            this.labelMunicipio.Text = "Município:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(30, 36);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Tipo:";
            // 
            // tipoComboBoxEdit
            // 
            this.tipoComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FeriadoDTOBindingSource, "Tipo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tipoComboBoxEdit.EditValue = "Federal";
            this.tipoComboBoxEdit.EnterMoveNextControl = true;
            this.tipoComboBoxEdit.Location = new System.Drawing.Point(132, 33);
            this.tipoComboBoxEdit.Name = "tipoComboBoxEdit";
            this.tipoComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tipoComboBoxEdit.Properties.Items.AddRange(new object[] {
            "Federal",
            "Estadual",
            "Municipal"});
            this.tipoComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.tipoComboBoxEdit.Size = new System.Drawing.Size(100, 20);
            this.tipoComboBoxEdit.TabIndex = 1;
            this.tipoComboBoxEdit.SelectedIndexChanged += new System.EventHandler(this.tipoComboBoxEdit_SelectedIndexChanged);
            // 
            // especieComboBoxEdit
            // 
            this.especieComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FeriadoDTOBindingSource, "Especie", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.especieComboBoxEdit.EditValue = "Móvel";
            this.especieComboBoxEdit.EnterMoveNextControl = true;
            this.especieComboBoxEdit.Location = new System.Drawing.Point(293, 33);
            this.especieComboBoxEdit.Name = "especieComboBoxEdit";
            this.especieComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.especieComboBoxEdit.Properties.Items.AddRange(new object[] {
            "Fixo",
            "Móvel"});
            this.especieComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.especieComboBoxEdit.Size = new System.Drawing.Size(139, 20);
            this.especieComboBoxEdit.TabIndex = 2;
            this.especieComboBoxEdit.SelectedIndexChanged += new System.EventHandler(this.especieComboBoxEdit_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(238, 36);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Espécie:";
            // 
            // textEditFeriado
            // 
            this.textEditFeriado.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FeriadoDTOBindingSource, "Descricao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textEditFeriado.EnterMoveNextControl = true;
            this.textEditFeriado.Location = new System.Drawing.Point(132, 6);
            this.textEditFeriado.Name = "textEditFeriado";
            this.textEditFeriado.Size = new System.Drawing.Size(300, 20);
            this.textEditFeriado.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Feriado:";
            // 
            // TerminaradioGroup
            // 
            this.TerminaradioGroup.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FeriadoDTOBindingSource, "Termina", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TerminaradioGroup.Enabled = false;
            this.TerminaradioGroup.Location = new System.Drawing.Point(30, 162);
            this.TerminaradioGroup.MenuManager = this.barManager;
            this.TerminaradioGroup.Name = "TerminaradioGroup";
            this.TerminaradioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Repetir sempre"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Repetir até:")});
            this.TerminaradioGroup.Size = new System.Drawing.Size(202, 60);
            this.TerminaradioGroup.TabIndex = 18;
            this.TerminaradioGroup.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.TerminaradioGroup_EditValueChanging);
            // 
            // MunicipioDTOBindingSource
            // 
            this.MunicipioDTOBindingSource.DataSource = typeof(MechTech.Entities.MunicipioDTO);
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // frmUpdateCalendario
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 253);
            this.Controls.Add(this.grpPrincipal);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmUpdateCalendario";
            this.ShowInTaskbar = false;
            this.Text = "Feriado";
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPrincipal)).EndInit();
            this.grpPrincipal.ResumeLayout(false);
            this.grpPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TerminaAnospinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeriadoDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepetircheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditObservacao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.municipioTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoIBGEButtonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uFLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UFDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.especieComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFeriado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TerminaradioGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MunicipioDTOBindingSource)).EndInit();
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
        private DevExpress.XtraEditors.SpinEdit TerminaAnospinEdit;
        private DevExpress.XtraEditors.CheckEdit RepetircheckEdit;
        private DevExpress.XtraEditors.TextEdit textEditObservacao;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit municipioTextEdit;
        private DevExpress.XtraEditors.ButtonEdit codigoIBGEButtonEdit;
        private DevExpress.XtraEditors.LabelControl labelEstado;
        private DevExpress.XtraEditors.LookUpEdit uFLookUpEdit;
        private DevExpress.XtraEditors.LabelControl labelMunicipio;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit tipoComboBoxEdit;
        private DevExpress.XtraEditors.ComboBoxEdit especieComboBoxEdit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEditFeriado;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.RadioGroup TerminaradioGroup;
        private System.Windows.Forms.BindingSource FeriadoDTOBindingSource;
        private System.Windows.Forms.BindingSource UFDTOBindingSource;
        private System.Windows.Forms.BindingSource MunicipioDTOBindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
    }
}