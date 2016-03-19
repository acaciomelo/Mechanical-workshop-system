using System;
using System.Windows.Forms;

#region DEVEXPRESS
using DevExpress.XtraEditors;
#endregion

#region MECHTECH
using MechTech.Util;
using MechTech.Util.Templates;
using MechTech.Entities;
using MechTech.Gateway;
#endregion

namespace MechTech.UI.Cadastros
{
    public partial class frmUpdateMunicipio : frmBase
    {
        Form frmGrid { get; set; }
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        MunicipioDTO municipioDTO { get; set; }
        BindingSource bndMunicipioGrid = new BindingSource();
        MunicipioGL municipioGL = new MunicipioGL();
        private BindingSource MunicipioDTOBindingSource;
        private System.ComponentModel.IContainer components;
        private BindingSource UFDTOBindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private GroupControl groupControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private TextEdit codigosrfbTextEdit;
        private LabelControl labelControl4;
        private TextEdit codigoibgeTextEdit;
        private LookUpEdit ufLookUpEdit;
        private TextEdit nomeTextEdit;
        private LabelControl labelControl3;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnSalvar;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
        Acesso acesso = new Acesso();
        UFGL ufGL = new UFGL();

        public frmUpdateMunicipio()
        {
            InitializeComponent();
        }

        public frmUpdateMunicipio(Form frm, Enumeradores.TipoOperacao tpo, BindingSource bnd)
        {
            InitializeComponent();

            try
            {
                frmGrid = frm;
                tpOperacao = tpo;
                bndMunicipioGrid = bnd;

                MdiParent = frmGrid.MdiParent;

                if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
                {
                    MunicipioDTOBindingSource.AddNew();
                }
                else
                {
                    municipioDTO = (MunicipioDTO)bndMunicipioGrid.Current;
                    MunicipioDTOBindingSource.DataSource = municipioGL.GetMunicipio(municipioDTO.Id);
                }

                municipioDTO = (MunicipioDTO)MunicipioDTOBindingSource.Current;

                UFDTOBindingSource.DataSource = ufGL.GetGridUF("codigo", "%");
            }
            catch
            {
                throw;
            }
        }

        private void frmUpdateMunicipio_Load(object sender, EventArgs e)
        {
            frmGrid.Enabled = false;

            switch (tpOperacao)
            {
                case Enumeradores.TipoOperacao.Insert:
                    this.Text = "Inserir Município";
                    break;
                case Enumeradores.TipoOperacao.Update:
                    this.Text = "Atualizar Município";
                    break;
                case Enumeradores.TipoOperacao.Viewer:
                    this.Text = "Vizualizar Município";
                    break;
                default:
                    break;
            }
        }

        private void frmUpdateMunicipio_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGrid.Enabled = true;
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        /// <summary>
        /// Provedor de validações de objeto input.
        /// </summary>
        /// <returns>Retorna um tipo VERDADEIRO caso erros sejam detectados, caso contrário FALSO.</returns>
        private bool ValidaCampos()
        {
            dxErrorProvider.ClearErrors();

            if (municipioDTO.Codigoibge == 0)
                dxErrorProvider.SetError(codigoibgeTextEdit, "Cód. IBGE inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (municipioDTO.Codigosrfb == 0)
                dxErrorProvider.SetError(codigosrfbTextEdit, "Cód. Rec. Federal inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (municipioDTO.Nome.Trim().Equals(string.Empty))
                dxErrorProvider.SetError(nomeTextEdit, "Nome inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            return dxErrorProvider.HasErrors;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateMunicipio));
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.MunicipioDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UFDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnSalvar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.codigosrfbTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.codigoibgeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ufLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.nomeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MunicipioDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UFDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codigosrfbTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoibgeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ufLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomeTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // MunicipioDTOBindingSource
            // 
            this.MunicipioDTOBindingSource.DataSource = typeof(MechTech.Entities.MunicipioDTO);
            // 
            // UFDTOBindingSource
            // 
            this.UFDTOBindingSource.DataSource = typeof(MechTech.Entities.UFDTO);
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
            this.btnSalvar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalvar_ItemClick_1);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Caption = "&Cancelar";
            this.btnCancelar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Glyph")));
            this.btnCancelar.Id = 1;
            this.btnCancelar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCancelar.LargeGlyph")));
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancelar_ItemClick_1);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(655, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 437);
            this.barDockControlBottom.Size = new System.Drawing.Size(655, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(655, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 413);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl1.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.groupControl1.Controls.Add(this.xtraTabControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 24);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(655, 413);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Municípios";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(21, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(632, 409);
            this.xtraTabControl1.TabIndex = 19;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.codigosrfbTextEdit);
            this.xtraTabPage1.Controls.Add(this.labelControl4);
            this.xtraTabPage1.Controls.Add(this.codigoibgeTextEdit);
            this.xtraTabPage1.Controls.Add(this.ufLookUpEdit);
            this.xtraTabPage1.Controls.Add(this.nomeTextEdit);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(626, 381);
            this.xtraTabPage1.Text = "Dados";
            // 
            // codigosrfbTextEdit
            // 
            this.codigosrfbTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MunicipioDTOBindingSource, "Codigosrfb", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.codigosrfbTextEdit.EnterMoveNextControl = true;
            this.codigosrfbTextEdit.Location = new System.Drawing.Point(110, 36);
            this.codigosrfbTextEdit.Name = "codigosrfbTextEdit";
            this.codigosrfbTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.codigosrfbTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.codigosrfbTextEdit.Properties.Mask.EditMask = "d";
            this.codigosrfbTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.codigosrfbTextEdit.Size = new System.Drawing.Size(100, 20);
            this.codigosrfbTextEdit.TabIndex = 2;
            this.codigosrfbTextEdit.ToolTip = "Código da Secretaria da Receita Federal";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 91);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(61, 13);
            this.labelControl4.TabIndex = 18;
            this.labelControl4.Text = "Estado (UF):";
            // 
            // codigoibgeTextEdit
            // 
            this.codigoibgeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MunicipioDTOBindingSource, "Codigoibge", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.codigoibgeTextEdit.EnterMoveNextControl = true;
            this.codigoibgeTextEdit.Location = new System.Drawing.Point(110, 10);
            this.codigoibgeTextEdit.Name = "codigoibgeTextEdit";
            this.codigoibgeTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.codigoibgeTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.codigoibgeTextEdit.Properties.Mask.EditMask = "d";
            this.codigoibgeTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.codigoibgeTextEdit.Size = new System.Drawing.Size(100, 20);
            this.codigoibgeTextEdit.TabIndex = 1;
            this.codigoibgeTextEdit.ToolTip = "Código do IBGE";
            // 
            // ufLookUpEdit
            // 
            this.ufLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MunicipioDTOBindingSource, "UF.Id", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ufLookUpEdit.EnterMoveNextControl = true;
            this.ufLookUpEdit.Location = new System.Drawing.Point(110, 88);
            this.ufLookUpEdit.Name = "ufLookUpEdit";
            this.ufLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ufLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Codigo", "Sigla", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descricao", "Descrição", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.ufLookUpEdit.Properties.DataSource = this.UFDTOBindingSource;
            this.ufLookUpEdit.Properties.DisplayMember = "Codigo";
            this.ufLookUpEdit.Properties.NullText = "";
            this.ufLookUpEdit.Properties.ValueMember = "Id";
            this.ufLookUpEdit.Size = new System.Drawing.Size(289, 20);
            this.ufLookUpEdit.TabIndex = 4;
            // 
            // nomeTextEdit
            // 
            this.nomeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MunicipioDTOBindingSource, "Nome", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nomeTextEdit.EnterMoveNextControl = true;
            this.nomeTextEdit.Location = new System.Drawing.Point(110, 62);
            this.nomeTextEdit.Name = "nomeTextEdit";
            this.nomeTextEdit.Properties.MaxLength = 50;
            this.nomeTextEdit.Size = new System.Drawing.Size(289, 20);
            this.nomeTextEdit.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 65);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(31, 13);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "Nome:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 13);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Cód. IBGE:";
            this.labelControl1.ToolTip = "Código IBGE";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 39);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(91, 13);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "Cód. Rec. Federal:";
            this.labelControl2.ToolTip = "Código da Receita Federal";
            // 
            // frmUpdateMunicipio
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(655, 437);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmUpdateMunicipio";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUpdateMunicipio_FormClosed_1);
            this.Load += new System.EventHandler(this.frmUpdateMunicipio_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MunicipioDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UFDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codigosrfbTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoibgeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ufLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomeTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void btnSalvar_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (ValidaCampos())
                    return;

                Cursor = Cursors.WaitCursor;
                switch (tpOperacao)
                {
                    case Enumeradores.TipoOperacao.Insert:
                        municipioDTO.Id = municipioGL.Insert((MunicipioDTO)MunicipioDTOBindingSource.Current);
                        bndMunicipioGrid.Add(MunicipioDTOBindingSource.Current);
                        break;
                    case Enumeradores.TipoOperacao.Update:
                        municipioGL.Update((MunicipioDTO)MunicipioDTOBindingSource.Current);
                        bndMunicipioGrid.List[bndMunicipioGrid.Position] = MunicipioDTOBindingSource.Current;
                        break;
                    default:
                        break;
                }
                this.Close();
            }
            catch
            {
                Cursor = Cursors.Default;
                throw;
            }
            Cursor = Cursors.Default;
        }

        private void btnCancelar_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmUpdateMunicipio_Load_1(object sender, EventArgs e)
        {
             frmGrid.Enabled = false;

             switch (tpOperacao)
             {
                 case Enumeradores.TipoOperacao.Insert:
                     this.Text = "Inserir Município";
                     break;
                 case Enumeradores.TipoOperacao.Update:
                     this.Text = "Atualizar Município";
                     break;
                 case Enumeradores.TipoOperacao.Viewer:
                     this.Text = "Vizualizar Município";
                     break;
                 default:
                     break;
             }

             if (tpOperacao == Enumeradores.TipoOperacao.Viewer)
             {
                 acesso.Validate(this);
                 acesso.Validate(barManager);
             }
        }

        private void frmUpdateMunicipio_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            frmGrid.Enabled = true;
        }
    }
}