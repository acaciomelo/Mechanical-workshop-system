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
    public partial class frmUpdateCalendario : frmBase
    {
        private FeriadoDTO feriadoDTO { get; set; }
        private FeriadoDTO feriadoDTOOriginal { get; set; } 
        MunicipioGL municipioGL = new MunicipioGL();
        UFGL ufGL = new UFGL();
        Enumeradores.TipoOperacao Operacao;

        public frmUpdateCalendario(FeriadoDTO feriado, Enumeradores.TipoOperacao tpo)
        {
            InitializeComponent();
            try
            {
                Operacao = tpo;
                feriadoDTO = feriado;
                FeriadoDTOBindingSource.DataSource = feriado;
                UFDTOBindingSource.DataSource = ufGL.GetGridUF("codigo", "%");
                feriadoDTOOriginal = new FeriadoDTO(feriadoDTO); 

                if ((Operacao == Enumeradores.TipoOperacao.Insert) || feriadoDTO.Repete == false) 
                {
                    this.TrataControle();
                    TrataRepetirFeriado();
                }
                else
                {
                    RepetircheckEdit.Enabled = false;
                    TerminaradioGroup.Enabled = false;
                    TerminaAnospinEdit.Enabled = false;
                    tipoComboBoxEdit.Enabled = false;
                    especieComboBoxEdit.Enabled = false;
                }
            }
            catch
            {
                throw;
            }
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ((feriadoDTOOriginal.Repete) && (Operacao == Enumeradores.TipoOperacao.Update)) 
                if (MessageBox.Show("Deseja alterar os feriados lançados repetidamente?\n(Este evento e os eventos seguintes serão alterados)", "Alterar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;


            if ((feriadoDTO.Data.Value.Year < DateTime.Now.Year) && (feriadoDTO.Data.Value.Month < DateTime.Now.Month))
                MessageBox.Show("Você está cadastrando um feriado com data retroativa, o reprocessamento \nindevido de cálculos em meses anteriores, irá acarretar  divergências de valores pagos e recolhidos.", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Validate();
            if (this.ValidaCampos() == true) return;
            feriadoDTO = (FeriadoDTO)FeriadoDTOBindingSource.Current;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SetMunicipio(object municipio)
        {
            codigoIBGEButtonEdit.Text = ((MunicipioDTO)municipio).Codigoibge.ToString();
            municipioTextEdit.Text = ((MunicipioDTO)municipio).Nome;
            feriadoDTO.Municipio = (MunicipioDTO)municipio;
        }

        private void codigoIBGEButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmGridMunicipio frmGrid = new frmGridMunicipio(this, new Global.SystemDelegate(SetMunicipio));
            frmGrid.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void tipoComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TrataControle();
        }

        private void TrataRepetirFeriado()
        {
            switch (feriadoDTO.Especie)
            {
                case "Fixo":
                    RepetircheckEdit.Enabled = true;

                    if (RepetircheckEdit.Checked)
                    {
                        TerminaradioGroup.Enabled = true;
                        if (feriadoDTO.Termina)
                            TerminaAnospinEdit.Enabled = false;
                        else
                            TerminaAnospinEdit.Enabled = true;
                    }
                    else
                    {
                        TerminaradioGroup.Enabled = false;
                        TerminaAnospinEdit.Enabled = false;
                    }

                    break;
                case "Móvel":
                    RepetircheckEdit.Enabled = false;
                    RepetircheckEdit.EditValue = false;
                    TerminaradioGroup.Enabled = false;
                    TerminaradioGroup.EditValue = false;
                    TerminaAnospinEdit.Enabled = false;
                    TerminaAnospinEdit.EditValue = int.Parse(DateTime.Now.ToString("yyyy"));
                    break;
            }
        }

        private void TrataControle()
        {
            switch (feriadoDTO.Tipo)
            {
                case "Federal":
                    codigoIBGEButtonEdit.Enabled = false;
                    labelMunicipio.Enabled = false;
                    municipioTextEdit.Text = string.Empty;
                    codigoIBGEButtonEdit.EditValue = 0;
                    uFLookUpEdit.Enabled = false;
                    labelEstado.Enabled = false;
                    uFLookUpEdit.EditValue = null;
                    break;
                case "Estadual":
                    uFLookUpEdit.Enabled = true;
                    labelEstado.Enabled = true;
                    codigoIBGEButtonEdit.Enabled = false;
                    labelMunicipio.Enabled = false;
                    municipioTextEdit.Text = string.Empty;
                    codigoIBGEButtonEdit.EditValue = 0;
                    break;
                case "Municipal":
                    codigoIBGEButtonEdit.Enabled = true;
                    labelMunicipio.Enabled = true;
                    uFLookUpEdit.Enabled = false;
                    labelEstado.Enabled = false;
                    uFLookUpEdit.EditValue = null;
                    break;
            }
        }

        private void codigoIBGEButtonEdit_Validated(object sender, EventArgs e)
        {
            if (codigoIBGEButtonEdit.IsModified)
            {
                if ((Int32)codigoIBGEButtonEdit.EditValue != 0)// && this.Enabled == true
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        feriadoDTO.Municipio = municipioGL.GetMunicipioIBGE(Convert.ToInt32(codigoIBGEButtonEdit.EditValue));
                        municipioTextEdit.Text = feriadoDTO.Municipio.Nome;
                    }
                    catch
                    {
                        Cursor = Cursors.WaitCursor;
                        frmGridMunicipio frm = new frmGridMunicipio(this, new Global.SystemDelegate(SetMunicipio));
                        frm.ShowDialog();
                        Cursor = Cursors.Default;
                    }
                    Cursor = Cursors.Default;
                }
                else
                {
                    municipioTextEdit.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// Faz todas as validações necessárias dos campos da janela
        /// </summary>
        /// <returns>Retorna true se existir inconsistências na janela</returns>
        private bool ValidaCampos()
        {
            dxErrorProvider.ClearErrors(); // Elimina todo os erros da janela

            if (feriadoDTO.Descricao == string.Empty)
                dxErrorProvider.SetError(textEditFeriado, "Informe o nome do feriado", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (feriadoDTO.Tipo == "Estadual" && feriadoDTO.UF.Id == 0)
                dxErrorProvider.SetError(uFLookUpEdit, "Selecione o estado do feriado estadual", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            if (feriadoDTO.Tipo == "Municipal" && feriadoDTO.Municipio.Id == 0)
                dxErrorProvider.SetError(codigoIBGEButtonEdit, "Selecione o município do feriado municipal", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);



            int ano = feriadoDTO.Data.Value.Year;

            if ((feriadoDTO.Termina == false) && (feriadoDTO.Repete == false) && (feriadoDTO.TerminaAno < ano))
                dxErrorProvider.SetError(TerminaAnospinEdit, "Ano de termino da repetição de feriado menor que ano do feriado a cadastrar.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);

            return dxErrorProvider.HasErrors;
        }

        private void RepetircheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            if ((Operacao == Enumeradores.TipoOperacao.Insert) || feriadoDTOOriginal.Repete == false)
                if (RepetircheckEdit.Checked)
                {
                    TerminaradioGroup.Enabled = true;
                    TerminaradioGroup.EditValue = true;
                    TerminaAnospinEdit.Enabled = false;
                }
                else
                {
                    TerminaradioGroup.Enabled = false;
                    TerminaradioGroup.EditValue = false;
                    TerminaAnospinEdit.Enabled = false;
                    TerminaAnospinEdit.EditValue = int.Parse(DateTime.Now.ToString("yyyy"));
                }
        }

        private void TerminaradioGroup_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if ((Operacao == Enumeradores.TipoOperacao.Insert) || feriadoDTOOriginal.Repete == false)
                if (feriadoDTO.Termina)
                {
                    TerminaAnospinEdit.Enabled = true;
                }
                else
                {
                    TerminaAnospinEdit.Enabled = false;
                }
        }

        private void especieComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Operacao == Enumeradores.TipoOperacao.Insert) || feriadoDTOOriginal.Repete == false)
                TrataRepetirFeriado();
        }
    }
}