namespace MechTech.UI.Cadastros
{
    partial class frmUpdateCBO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateCBO));
            this.CBODTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.grupoLabel = new DevExpress.XtraEditors.LabelControl();
            this.descricaoLabel = new DevExpress.XtraEditors.LabelControl();
            this.codigoLabel = new DevExpress.XtraEditors.LabelControl();
            this.cboGrupo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.txtDescricao = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.CBODTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPrincipal)).BeginInit();
            this.grpPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGrupo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescricao.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // CBODTOBindingSource
            // 
            this.CBODTOBindingSource.DataSource = typeof(MechTech.Entities.CBODTO);
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
            this.barDockControlTop.Size = new System.Drawing.Size(794, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 568);
            this.barDockControlBottom.Size = new System.Drawing.Size(794, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 544);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(794, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 544);
            // 
            // grpPrincipal
            // 
            this.grpPrincipal.AppearanceCaption.Options.UseTextOptions = true;
            this.grpPrincipal.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grpPrincipal.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.grpPrincipal.Controls.Add(this.grupoLabel);
            this.grpPrincipal.Controls.Add(this.descricaoLabel);
            this.grpPrincipal.Controls.Add(this.codigoLabel);
            this.grpPrincipal.Controls.Add(this.cboGrupo);
            this.grpPrincipal.Controls.Add(this.txtCodigo);
            this.grpPrincipal.Controls.Add(this.txtDescricao);
            this.grpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPrincipal.Location = new System.Drawing.Point(0, 24);
            this.grpPrincipal.Name = "grpPrincipal";
            this.grpPrincipal.Size = new System.Drawing.Size(794, 544);
            this.grpPrincipal.TabIndex = 6;
            this.grpPrincipal.Text = "CBO";
            // 
            // grupoLabel
            // 
            this.grupoLabel.Location = new System.Drawing.Point(34, 72);
            this.grupoLabel.Name = "grupoLabel";
            this.grupoLabel.Size = new System.Drawing.Size(33, 13);
            this.grupoLabel.TabIndex = 9;
            this.grupoLabel.Text = "Grupo:";
            // 
            // descricaoLabel
            // 
            this.descricaoLabel.Location = new System.Drawing.Point(34, 42);
            this.descricaoLabel.Name = "descricaoLabel";
            this.descricaoLabel.Size = new System.Drawing.Size(50, 13);
            this.descricaoLabel.TabIndex = 8;
            this.descricaoLabel.Text = "Descrição:";
            // 
            // codigoLabel
            // 
            this.codigoLabel.Location = new System.Drawing.Point(34, 13);
            this.codigoLabel.Name = "codigoLabel";
            this.codigoLabel.Size = new System.Drawing.Size(37, 13);
            this.codigoLabel.TabIndex = 7;
            this.codigoLabel.Text = "Código:";
            // 
            // cboGrupo
            // 
            this.cboGrupo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CBODTOBindingSource, "Grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboGrupo.EditValue = "Ocupação";
            this.cboGrupo.EnterMoveNextControl = true;
            this.cboGrupo.Location = new System.Drawing.Point(94, 69);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboGrupo.Properties.Items.AddRange(new object[] {
            "Ocupação",
            "Sinônimo"});
            this.cboGrupo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboGrupo.Size = new System.Drawing.Size(299, 20);
            this.cboGrupo.TabIndex = 6;
            this.cboGrupo.ToolTip = "Grupo do CBO conforme o ministério do trabalho";
            // 
            // txtCodigo
            // 
            this.txtCodigo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CBODTOBindingSource, "Codigo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCodigo.EnterMoveNextControl = true;
            this.txtCodigo.Location = new System.Drawing.Point(94, 10);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.MaxLength = 6;
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.ToolTip = "Código do CBO conforme o ministério do trabalho";
            // 
            // txtDescricao
            // 
            this.txtDescricao.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CBODTOBindingSource, "Descricao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDescricao.EnterMoveNextControl = true;
            this.txtDescricao.Location = new System.Drawing.Point(94, 39);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Properties.MaxLength = 150;
            this.txtDescricao.Size = new System.Drawing.Size(299, 20);
            this.txtDescricao.TabIndex = 3;
            this.txtDescricao.ToolTip = "Ocupação do funcionário";
            // 
            // frmUpdateCBO
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 568);
            this.Controls.Add(this.grpPrincipal);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmUpdateCBO";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUpdateCBO_FormClosed);
            this.Load += new System.EventHandler(this.frmUpdateCBO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CBODTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPrincipal)).EndInit();
            this.grpPrincipal.ResumeLayout(false);
            this.grpPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGrupo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescricao.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource CBODTOBindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.GroupControl grpPrincipal;
        private DevExpress.XtraEditors.LabelControl grupoLabel;
        private DevExpress.XtraEditors.LabelControl descricaoLabel;
        private DevExpress.XtraEditors.LabelControl codigoLabel;
        private DevExpress.XtraEditors.ComboBoxEdit cboGrupo;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.TextEdit txtDescricao;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnSalvar;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
    }
}