using System;
using System.Windows.Forms;
using System.Collections.Generic;

#region DEVEXPRESS
using DevExpress.XtraEditors;
#endregion

#region MECHTECH
using MechTech.Util;
using MechTech.Entities;
using MechTech.Gateway;
using MechTech.Util.Templates;
#endregion

namespace MechTech.UI.Cadastros
{
    public partial class frmBuscaCEP : frmBase
    {
        MunicipioDTO Municipio = new MunicipioDTO();
        UFDTO uf = new UFDTO();

        Form frmGrid { get; set; }
        Global.SystemDelegate GetCEP;
        public frmBuscaCEP()
        {
            InitializeComponent();
        }

        public frmBuscaCEP(Form frm, Global.SystemDelegate target)
        {
            InitializeComponent();

            MunicipiobindingSource.DataSource = new MunicipioGL().GetGridMunicipio("id", "");
            UFbindingSource.DataSource = new UFGL().GetGridUF("id", "");

            frmGrid = frm;
            MdiParent = frmGrid.MdiParent;

            GetCEP = target;

            MunicipiobindingSource.AddNew(); // Linha em branco
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnPesquisar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisar()
        {
            if (!ValidaCampos())
            {
                BuscaCEPGL cep = new BuscaCEPGL();
                List<BuscaCEPDTO> dados = new List<BuscaCEPDTO>();


                Municipio = (MunicipioDTO)MunicipiobindingSource.Current;
                uf = (UFDTO)UFbindingSource.Current;

                dados = cep.GetEndereco(uf.Codigo,
                                        Municipio.Nome,
                                        EnderecotextEdit.Text.Trim(),
                                        "");
                BuscaCEPbindingSource.DataSource = dados;
            }
        }

        private void btnSelecionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Selecionar();
        }

        private void Selecionar()
        {
            try
            {
                GetCEP((BuscaCEPDTO)BuscaCEPbindingSource.Current);
            }
            catch
            { }

            Close();
        }

        private bool ValidaCampos()
        {
            Municipio = (MunicipioDTO)MunicipiobindingSource.Current;
            dxErrorProvider.ClearErrors();

            if (Municipio.Nome == "")
                dxErrorProvider.SetError(MunicipiolookUpEdit, "Município inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (EnderecotextEdit.Text.Trim() == "")
                dxErrorProvider.SetError(EnderecotextEdit, "Endereço inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);


            return dxErrorProvider.HasErrors;
        }

        private void frmBuscaCEP_Load(object sender, EventArgs e)
        {

        }

        private void HabilitaDesabilitaBotoes()
        {
            if (dgdTabela.FocusedView.DataRowCount == 0)
            {
                btnSelecionar.Enabled = false;
            }
            else
            {
                btnSelecionar.Enabled = true;           
            }
        }

        private void gridView_RowCountChanged(object sender, EventArgs e)
        {
            HabilitaDesabilitaBotoes();
        }
    }


}