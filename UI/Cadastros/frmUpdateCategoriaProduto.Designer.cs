﻿namespace MechTech.UI.Cadastros
{
    partial class frmUpdateCategoriaProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateCategoriaProduto));
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnSalvar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.CategoriaProdutoDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpPrincipal = new DevExpress.XtraEditors.GroupControl();
            this.DescricaoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.nomeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.codigoTextEdit = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoriaProdutoDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPrincipal)).BeginInit();
            this.grpPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DescricaoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
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
            // CategoriaProdutoDTOBindingSource
            // 
            this.CategoriaProdutoDTOBindingSource.DataSource = typeof(MechTech.Entities.CategoriaProdutoDTO);
            // 
            // grpPrincipal
            // 
            this.grpPrincipal.AppearanceCaption.Options.UseTextOptions = true;
            this.grpPrincipal.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grpPrincipal.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.grpPrincipal.Controls.Add(this.DescricaoTextEdit);
            this.grpPrincipal.Controls.Add(this.labelControl7);
            this.grpPrincipal.Controls.Add(this.labelControl2);
            this.grpPrincipal.Controls.Add(this.nomeTextEdit);
            this.grpPrincipal.Controls.Add(this.labelControl1);
            this.grpPrincipal.Controls.Add(this.codigoTextEdit);
            this.grpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPrincipal.Location = new System.Drawing.Point(0, 24);
            this.grpPrincipal.Name = "grpPrincipal";
            this.grpPrincipal.Size = new System.Drawing.Size(820, 413);
            this.grpPrincipal.TabIndex = 5;
            this.grpPrincipal.Text = "Categoria de Produtos e Serviços";
            // 
            // DescricaoTextEdit
            // 
            this.DescricaoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CategoriaProdutoDTOBindingSource, "Descricao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DescricaoTextEdit.EnterMoveNextControl = true;
            this.DescricaoTextEdit.Location = new System.Drawing.Point(105, 58);
            this.DescricaoTextEdit.Name = "DescricaoTextEdit";
            this.DescricaoTextEdit.Properties.MaxLength = 40;
            this.DescricaoTextEdit.Size = new System.Drawing.Size(580, 20);
            this.DescricaoTextEdit.TabIndex = 3;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(30, 60);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(50, 13);
            this.labelControl7.TabIndex = 16;
            this.labelControl7.Text = "Descrição:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(30, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(31, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Nome:";
            // 
            // nomeTextEdit
            // 
            this.nomeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CategoriaProdutoDTOBindingSource, "Nome", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.codigoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CategoriaProdutoDTOBindingSource, "Codigo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.codigoTextEdit.EnterMoveNextControl = true;
            this.codigoTextEdit.Location = new System.Drawing.Point(105, 6);
            this.codigoTextEdit.Name = "codigoTextEdit";
            this.codigoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.codigoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.codigoTextEdit.Properties.Mask.EditMask = "d";
            this.codigoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.codigoTextEdit.Properties.MaxLength = 10;
            this.codigoTextEdit.Size = new System.Drawing.Size(100, 20);
            this.codigoTextEdit.TabIndex = 1;
            // 
            // frmUpdateCategoriaProduto
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
            this.Name = "frmUpdateCategoriaProduto";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUpdateCategoriaProduto_FormClosed);
            this.Load += new System.EventHandler(this.frmUpdateCategoriaProduto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoriaProdutoDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPrincipal)).EndInit();
            this.grpPrincipal.ResumeLayout(false);
            this.grpPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DescricaoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnSalvar;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
        private System.Windows.Forms.BindingSource CategoriaProdutoDTOBindingSource;
        private DevExpress.XtraEditors.GroupControl grpPrincipal;
        private DevExpress.XtraEditors.TextEdit DescricaoTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit nomeTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit codigoTextEdit;
    }
}