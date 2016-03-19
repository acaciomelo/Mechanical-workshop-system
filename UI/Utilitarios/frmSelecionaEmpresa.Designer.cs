namespace MechTech.UI.Utilitarios
{
    partial class frmSelecionaEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelecionaEmpresa));
            this.MesesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EmpresaDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnSelecionar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControlEmpresa = new DevExpress.XtraEditors.GroupControl();
            this.empresaLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.anospinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.meslookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MesesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpresaDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlEmpresa)).BeginInit();
            this.groupControlEmpresa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empresaLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anospinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meslookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // MesesBindingSource
            // 
            this.MesesBindingSource.DataSource = typeof(MechTech.Util.Meses);
            // 
            // EmpresaDTOBindingSource
            // 
            this.EmpresaDTOBindingSource.DataSource = typeof(MechTech.Entities.EmpresaDTO);
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
            this.btnSelecionar,
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSelecionar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCancelar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menu principal";
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Caption = "&Selecionar";
            this.btnSelecionar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSelecionar.Glyph")));
            this.btnSelecionar.Id = 0;
            this.btnSelecionar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSelecionar.LargeGlyph")));
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelecionar_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(494, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 137);
            this.barDockControlBottom.Size = new System.Drawing.Size(494, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 113);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(494, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 113);
            // 
            // groupControlEmpresa
            // 
            this.groupControlEmpresa.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControlEmpresa.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControlEmpresa.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.groupControlEmpresa.Controls.Add(this.empresaLookUpEdit);
            this.groupControlEmpresa.Controls.Add(this.labelControl3);
            this.groupControlEmpresa.Controls.Add(this.anospinEdit);
            this.groupControlEmpresa.Controls.Add(this.meslookUpEdit);
            this.groupControlEmpresa.Controls.Add(this.labelControl2);
            this.groupControlEmpresa.Controls.Add(this.labelControl1);
            this.groupControlEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlEmpresa.Location = new System.Drawing.Point(0, 24);
            this.groupControlEmpresa.Name = "groupControlEmpresa";
            this.groupControlEmpresa.Size = new System.Drawing.Size(494, 113);
            this.groupControlEmpresa.TabIndex = 4;
            this.groupControlEmpresa.Text = "Empresa";
            // 
            // empresaLookUpEdit
            // 
            this.empresaLookUpEdit.EnterMoveNextControl = true;
            this.empresaLookUpEdit.Location = new System.Drawing.Point(24, 25);
            this.empresaLookUpEdit.Name = "empresaLookUpEdit";
            this.empresaLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.empresaLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Código", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nomefantasia", 70, "Fantasia")});
            this.empresaLookUpEdit.Properties.DataSource = this.EmpresaDTOBindingSource;
            this.empresaLookUpEdit.Properties.DisplayMember = "Nomefantasia";
            this.empresaLookUpEdit.Properties.NullText = "";
            this.empresaLookUpEdit.Properties.ValueMember = "Id";
            this.empresaLookUpEdit.Size = new System.Drawing.Size(451, 20);
            this.empresaLookUpEdit.TabIndex = 28;
            this.empresaLookUpEdit.EditValueChanged += new System.EventHandler(this.empresaLookUpEdit_EditValueChanged);
            this.empresaLookUpEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.empresaLookUpEdit_KeyDown);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(130, 58);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(19, 13);
            this.labelControl3.TabIndex = 33;
            this.labelControl3.Text = "Ano";
            // 
            // anospinEdit
            // 
            this.anospinEdit.EditValue = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.anospinEdit.Location = new System.Drawing.Point(130, 77);
            this.anospinEdit.Name = "anospinEdit";
            this.anospinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.anospinEdit.Properties.Mask.EditMask = "d";
            this.anospinEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.anospinEdit.Properties.MaxValue = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.anospinEdit.Properties.MinValue = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.anospinEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.anospinEdit.Size = new System.Drawing.Size(50, 20);
            this.anospinEdit.TabIndex = 30;
            this.anospinEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.anospinEdit_KeyDown);
            // 
            // meslookUpEdit
            // 
            this.meslookUpEdit.EnterMoveNextControl = true;
            this.meslookUpEdit.Location = new System.Drawing.Point(24, 77);
            this.meslookUpEdit.Name = "meslookUpEdit";
            this.meslookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.meslookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descricao", "Meses")});
            this.meslookUpEdit.Properties.DataSource = this.MesesBindingSource;
            this.meslookUpEdit.Properties.DisplayMember = "Descricao";
            this.meslookUpEdit.Properties.NullText = "";
            this.meslookUpEdit.Properties.ValueMember = "Mes";
            this.meslookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.meslookUpEdit.TabIndex = 29;
            this.meslookUpEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.meslookUpEdit_KeyDown);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(24, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(19, 13);
            this.labelControl2.TabIndex = 32;
            this.labelControl2.Text = "Mês";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 13);
            this.labelControl1.TabIndex = 31;
            this.labelControl1.Text = "Empresa";
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // frmSelecionaEmpresa
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 137);
            this.Controls.Add(this.groupControlEmpresa);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmSelecionaEmpresa";
            this.Text = "Selecionar Empresa";
            this.Load += new System.EventHandler(this.frmSelecionaEmpresa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MesesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpresaDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlEmpresa)).EndInit();
            this.groupControlEmpresa.ResumeLayout(false);
            this.groupControlEmpresa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empresaLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anospinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meslookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource MesesBindingSource;
        private System.Windows.Forms.BindingSource EmpresaDTOBindingSource;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnSelecionar;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl groupControlEmpresa;
        private DevExpress.XtraEditors.LookUpEdit empresaLookUpEdit;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit anospinEdit;
        private DevExpress.XtraEditors.LookUpEdit meslookUpEdit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
    }
}