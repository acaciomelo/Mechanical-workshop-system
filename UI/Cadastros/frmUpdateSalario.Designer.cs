namespace MechTech.UI.Cadastros
{
    partial class frmUpdateSalario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateSalario));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.FuncaoDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FuncSalarioDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnSalvar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.grpPrincipal = new DevExpress.XtraEditors.GroupControl();
            this.DissidioDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.lblDissidio = new DevExpress.XtraEditors.LabelControl();
            this.motivoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblSecao = new DevExpress.XtraEditors.LabelControl();
            this.lblSetor = new DevExpress.XtraEditors.LabelControl();
            this.lblDepto = new DevExpress.XtraEditors.LabelControl();
            this.lblSiglaSalario = new DevExpress.XtraEditors.LabelControl();
            this.lblSalario = new DevExpress.XtraEditors.LabelControl();
            this.salarioTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.funcaoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.codigosecaoButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.codigosetorButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.codigodeptoButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dataDateEdit = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.FuncaoDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuncSalarioDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPrincipal)).BeginInit();
            this.grpPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DissidioDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DissidioDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.motivoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salarioTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcaoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigosecaoButtonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigosetorButtonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigodeptoButtonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDateEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // FuncaoDTOBindingSource
            // 
            this.FuncaoDTOBindingSource.DataSource = typeof(MechTech.Entities.FuncaoDTO);
            // 
            // FuncSalarioDTOBindingSource
            // 
            this.FuncSalarioDTOBindingSource.DataSource = typeof(MechTech.Entities.FuncSalarioDTO);
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
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
            this.barDockControlTop.Size = new System.Drawing.Size(501, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 188);
            this.barDockControlBottom.Size = new System.Drawing.Size(501, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 164);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(501, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 164);
            // 
            // grpPrincipal
            // 
            this.grpPrincipal.AppearanceCaption.Options.UseTextOptions = true;
            this.grpPrincipal.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grpPrincipal.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.grpPrincipal.Controls.Add(this.DissidioDateEdit);
            this.grpPrincipal.Controls.Add(this.lblDissidio);
            this.grpPrincipal.Controls.Add(this.motivoTextEdit);
            this.grpPrincipal.Controls.Add(this.labelControl1);
            this.grpPrincipal.Controls.Add(this.lblSecao);
            this.grpPrincipal.Controls.Add(this.lblSetor);
            this.grpPrincipal.Controls.Add(this.lblDepto);
            this.grpPrincipal.Controls.Add(this.lblSiglaSalario);
            this.grpPrincipal.Controls.Add(this.lblSalario);
            this.grpPrincipal.Controls.Add(this.salarioTextEdit);
            this.grpPrincipal.Controls.Add(this.labelControl6);
            this.grpPrincipal.Controls.Add(this.funcaoLookUpEdit);
            this.grpPrincipal.Controls.Add(this.labelControl5);
            this.grpPrincipal.Controls.Add(this.labelControl4);
            this.grpPrincipal.Controls.Add(this.codigosecaoButtonEdit);
            this.grpPrincipal.Controls.Add(this.codigosetorButtonEdit);
            this.grpPrincipal.Controls.Add(this.labelControl3);
            this.grpPrincipal.Controls.Add(this.codigodeptoButtonEdit);
            this.grpPrincipal.Controls.Add(this.labelControl2);
            this.grpPrincipal.Controls.Add(this.dataDateEdit);
            this.grpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPrincipal.Location = new System.Drawing.Point(0, 24);
            this.grpPrincipal.Name = "grpPrincipal";
            this.grpPrincipal.Size = new System.Drawing.Size(501, 164);
            this.grpPrincipal.TabIndex = 4;
            this.grpPrincipal.Text = "Salários";
            // 
            // DissidioDateEdit
            // 
            this.DissidioDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FuncSalarioDTOBindingSource, "DataReajuste", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DissidioDateEdit.EditValue = null;
            this.DissidioDateEdit.EnterMoveNextControl = true;
            this.DissidioDateEdit.Location = new System.Drawing.Point(280, 6);
            this.DissidioDateEdit.Name = "DissidioDateEdit";
            this.DissidioDateEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.DissidioDateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.DissidioDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DissidioDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DissidioDateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.DissidioDateEdit.Size = new System.Drawing.Size(100, 20);
            this.DissidioDateEdit.TabIndex = 2;
            this.DissidioDateEdit.ToolTip = "Data de dissídio (Reajuste Salarial)";
            // 
            // lblDissidio
            // 
            this.lblDissidio.Location = new System.Drawing.Point(218, 9);
            this.lblDissidio.Name = "lblDissidio";
            this.lblDissidio.Size = new System.Drawing.Size(56, 13);
            this.lblDissidio.TabIndex = 23;
            this.lblDissidio.Text = "Dissídio em:";
            // 
            // motivoTextEdit
            // 
            this.motivoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FuncSalarioDTOBindingSource, "Motivo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.motivoTextEdit.EnterMoveNextControl = true;
            this.motivoTextEdit.Location = new System.Drawing.Point(103, 32);
            this.motivoTextEdit.MenuManager = this.barManager;
            this.motivoTextEdit.Name = "motivoTextEdit";
            this.motivoTextEdit.Properties.MaxLength = 100;
            this.motivoTextEdit.Size = new System.Drawing.Size(387, 20);
            this.motivoTextEdit.TabIndex = 3;
            this.motivoTextEdit.ToolTip = "Motivo da alteração de salário";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "Motivo:";
            // 
            // lblSecao
            // 
            this.lblSecao.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecao.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblSecao.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSecao.Location = new System.Drawing.Point(351, 90);
            this.lblSecao.Name = "lblSecao";
            this.lblSecao.Size = new System.Drawing.Size(139, 13);
            this.lblSecao.TabIndex = 21;
            this.lblSecao.Text = "[]";
            this.lblSecao.Visible = false;
            // 
            // lblSetor
            // 
            this.lblSetor.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetor.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblSetor.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSetor.Location = new System.Drawing.Point(209, 90);
            this.lblSetor.Name = "lblSetor";
            this.lblSetor.Size = new System.Drawing.Size(136, 13);
            this.lblSetor.TabIndex = 20;
            this.lblSetor.Text = "[]";
            this.lblSetor.Visible = false;
            // 
            // lblDepto
            // 
            this.lblDepto.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepto.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblDepto.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDepto.Location = new System.Drawing.Point(30, 90);
            this.lblDepto.Name = "lblDepto";
            this.lblDepto.Size = new System.Drawing.Size(173, 13);
            this.lblDepto.TabIndex = 19;
            this.lblDepto.Text = "[]";
            // 
            // lblSiglaSalario
            // 
            this.lblSiglaSalario.Location = new System.Drawing.Point(209, 138);
            this.lblSiglaSalario.Name = "lblSiglaSalario";
            this.lblSiglaSalario.Size = new System.Drawing.Size(0, 13);
            this.lblSiglaSalario.TabIndex = 16;
            // 
            // lblSalario
            // 
            this.lblSalario.Location = new System.Drawing.Point(30, 138);
            this.lblSalario.Name = "lblSalario";
            this.lblSalario.Size = new System.Drawing.Size(36, 13);
            this.lblSalario.TabIndex = 15;
            this.lblSalario.Text = "Salário:";
            // 
            // salarioTextEdit
            // 
            this.salarioTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FuncSalarioDTOBindingSource, "Salario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.salarioTextEdit.EnterMoveNextControl = true;
            this.salarioTextEdit.Location = new System.Drawing.Point(103, 135);
            this.salarioTextEdit.Name = "salarioTextEdit";
            this.salarioTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.salarioTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.salarioTextEdit.Properties.Mask.EditMask = "c2";
            this.salarioTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.salarioTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.salarioTextEdit.Size = new System.Drawing.Size(100, 20);
            this.salarioTextEdit.TabIndex = 8;
            this.salarioTextEdit.ToolTip = "Valor do salário";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(30, 112);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(33, 13);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "Cargo:";
            // 
            // funcaoLookUpEdit
            // 
            this.funcaoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FuncSalarioDTOBindingSource, "Funcao.Id", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.funcaoLookUpEdit.EnterMoveNextControl = true;
            this.funcaoLookUpEdit.Location = new System.Drawing.Point(103, 109);
            this.funcaoLookUpEdit.Name = "funcaoLookUpEdit";
            this.funcaoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.funcaoLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nome", "Descrição")});
            this.funcaoLookUpEdit.Properties.DataSource = this.FuncaoDTOBindingSource;
            this.funcaoLookUpEdit.Properties.DisplayMember = "Nome";
            this.funcaoLookUpEdit.Properties.NullText = "";
            this.funcaoLookUpEdit.Properties.ValueMember = "Id";
            this.funcaoLookUpEdit.Size = new System.Drawing.Size(387, 20);
            this.funcaoLookUpEdit.TabIndex = 7;
            this.funcaoLookUpEdit.EditValueChanged += new System.EventHandler(this.funcaoLookUpEdit_EditValueChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(351, 71);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(33, 13);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Seção:";
            this.labelControl5.Visible = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(209, 71);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(30, 13);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "Setor:";
            this.labelControl4.Visible = false;
            // 
            // codigosecaoButtonEdit
            // 
            this.codigosecaoButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FuncSalarioDTOBindingSource, "Secao.Codigo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.codigosecaoButtonEdit.EnterMoveNextControl = true;
            this.codigosecaoButtonEdit.Location = new System.Drawing.Point(390, 67);
            this.codigosecaoButtonEdit.Name = "codigosecaoButtonEdit";
            this.codigosecaoButtonEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.codigosecaoButtonEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.codigosecaoButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("codigosecaoButtonEdit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.codigosecaoButtonEdit.Properties.Mask.EditMask = "d";
            this.codigosecaoButtonEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.codigosecaoButtonEdit.Size = new System.Drawing.Size(100, 22);
            this.codigosecaoButtonEdit.TabIndex = 6;
            this.codigosecaoButtonEdit.Visible = false;
            this.codigosecaoButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.codigosecaoButtonEdit_ButtonClick);
            this.codigosecaoButtonEdit.Validated += new System.EventHandler(this.codigosecaoButtonEdit_Validated);
            // 
            // codigosetorButtonEdit
            // 
            this.codigosetorButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FuncSalarioDTOBindingSource, "Setor.Codigo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.codigosetorButtonEdit.EnterMoveNextControl = true;
            this.codigosetorButtonEdit.Location = new System.Drawing.Point(245, 67);
            this.codigosetorButtonEdit.Name = "codigosetorButtonEdit";
            this.codigosetorButtonEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.codigosetorButtonEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.codigosetorButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("codigosetorButtonEdit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.codigosetorButtonEdit.Properties.Mask.EditMask = "d";
            this.codigosetorButtonEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.codigosetorButtonEdit.Size = new System.Drawing.Size(100, 22);
            this.codigosetorButtonEdit.TabIndex = 5;
            this.codigosetorButtonEdit.Visible = false;
            this.codigosetorButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.codigosetorButtonEdit_ButtonClick);
            this.codigosetorButtonEdit.Validated += new System.EventHandler(this.codigosetorButtonEdit_Validated);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(30, 71);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(73, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Departamento:";
            // 
            // codigodeptoButtonEdit
            // 
            this.codigodeptoButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FuncSalarioDTOBindingSource, "Departamento.Codigo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.codigodeptoButtonEdit.EnterMoveNextControl = true;
            this.codigodeptoButtonEdit.Location = new System.Drawing.Point(103, 67);
            this.codigodeptoButtonEdit.Name = "codigodeptoButtonEdit";
            this.codigodeptoButtonEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.codigodeptoButtonEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.codigodeptoButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("codigodeptoButtonEdit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.codigodeptoButtonEdit.Properties.Mask.EditMask = "d";
            this.codigodeptoButtonEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.codigodeptoButtonEdit.Size = new System.Drawing.Size(100, 22);
            this.codigodeptoButtonEdit.TabIndex = 4;
            this.codigodeptoButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.codigodeptoButtonEdit_ButtonClick);
            this.codigodeptoButtonEdit.Validated += new System.EventHandler(this.codigodeptoButtonEdit_Validated);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(30, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(67, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Alteração em:";
            // 
            // dataDateEdit
            // 
            this.dataDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.FuncSalarioDTOBindingSource, "Data", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataDateEdit.EditValue = null;
            this.dataDateEdit.EnterMoveNextControl = true;
            this.dataDateEdit.Location = new System.Drawing.Point(103, 6);
            this.dataDateEdit.Name = "dataDateEdit";
            this.dataDateEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.dataDateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.dataDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dataDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dataDateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dataDateEdit.Size = new System.Drawing.Size(100, 20);
            this.dataDateEdit.TabIndex = 1;
            this.dataDateEdit.ToolTip = "Data da alteração";
            // 
            // frmUpdateSalario
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 188);
            this.Controls.Add(this.grpPrincipal);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmUpdateSalario";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUpdateSalario_FormClosed);
            this.Load += new System.EventHandler(this.frmUpdateSalario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FuncaoDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuncSalarioDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPrincipal)).EndInit();
            this.grpPrincipal.ResumeLayout(false);
            this.grpPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DissidioDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DissidioDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.motivoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salarioTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcaoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigosecaoButtonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigosetorButtonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigodeptoButtonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDateEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource FuncaoDTOBindingSource;
        private System.Windows.Forms.BindingSource FuncSalarioDTOBindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.GroupControl grpPrincipal;
        private DevExpress.XtraEditors.DateEdit DissidioDateEdit;
        private DevExpress.XtraEditors.LabelControl lblDissidio;
        private DevExpress.XtraEditors.TextEdit motivoTextEdit;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnSalvar;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblSecao;
        private DevExpress.XtraEditors.LabelControl lblSetor;
        private DevExpress.XtraEditors.LabelControl lblDepto;
        private DevExpress.XtraEditors.LabelControl lblSiglaSalario;
        private DevExpress.XtraEditors.LabelControl lblSalario;
        private DevExpress.XtraEditors.TextEdit salarioTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LookUpEdit funcaoLookUpEdit;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ButtonEdit codigosecaoButtonEdit;
        private DevExpress.XtraEditors.ButtonEdit codigosetorButtonEdit;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ButtonEdit codigodeptoButtonEdit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dataDateEdit;
    }
}