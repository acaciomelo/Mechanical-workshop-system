using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

#region MechTech
using MechTech.Util.Templates;
using MechTech.Util;
using MechTech.Entities;
using MechTech.Gateway;
using System.IO;
#endregion

namespace MechTech.UI.Cadastros
{
    public partial class frmVincularVeiculo : DevExpress.XtraEditors.XtraForm
    {
        Form frmGrid { get; set; }
        Enumeradores.TipoOperacao tpOperacao { get; set; }
        VincularVeiculoDTO vincularveiculoDTO { get; set; }
        VincularVeiculoDTO vincularveiculoDTOVersaoOriginal { get; set; }
        BindingSource bndVeiculoGrid = new BindingSource();
        VincularVeiculoGL vincularveiculoGL = new VincularVeiculoGL();
        Acesso acesso = new Acesso();

        public frmVincularVeiculo()
        {
            InitializeComponent();
        }

        public frmVincularVeiculo(Form frm, Enumeradores.TipoOperacao tpo, BindingSource bnd)
        {
            InitializeComponent();

            try
            {
                frmGrid = frm;
                tpOperacao = tpo;
                bndVeiculoGrid = bnd;
                MdiParent = frmGrid.MdiParent;

                if (tpOperacao.Equals(Enumeradores.TipoOperacao.Insert))
                {
                    VincularVeiculoDTObindingSource.AddNew();
                    txtVeiculo.DataBindings.Clear();
                    txtCliente.DataBindings.Clear();
                }
                else
                {
                    int id_veiculo;
                    vincularveiculoDTO = (VincularVeiculoDTO)bndVeiculoGrid.Current;

                    id_veiculo = Convert.ToInt32(vincularveiculoGL.GetIdVeiculo(vincularveiculoDTO.Veiculo));
                    VincularVeiculoDTObindingSource.DataSource = vincularveiculoGL.GetVincularVeiculo(id_veiculo);

                }

                vincularveiculoDTO = (VincularVeiculoDTO)VincularVeiculoDTObindingSource.Current;
                vincularveiculoDTOVersaoOriginal = new VincularVeiculoDTO(vincularveiculoDTO);
                GetFoto();
            }
            catch
            {
                throw;
            }
        }

        private void SetVeiculo(object veiculo)
        {
            btnVeiculo.Text = ((VeiculoDTO)veiculo).Id.ToString();
            txtVeiculo.Text = ((VeiculoDTO)veiculo).Veiculo.ToString();

        }

        private void SetCliente(object cliente)
        {
            btnCliente.Text = ((ClienteDTO)cliente).Id.ToString();
            txtCliente.EditValue = ((ClienteDTO)cliente).Nome.ToString();
        }

        private bool Salvar()
        {
            try
            {
                if (ValidaCampos())
                    return false;

                Cursor = Cursors.WaitCursor;
                switch (tpOperacao)
                {
                    case Enumeradores.TipoOperacao.Insert:
                        vincularveiculoDTO.Id = vincularveiculoGL.Insert((VincularVeiculoDTO)VincularVeiculoDTObindingSource.Current);
                        vincularveiculoDTO.Cliente = vincularveiculoGL.GetCliente(vincularveiculoDTO.Id_Cliente);
                        vincularveiculoDTO.Veiculo = vincularveiculoGL.GetVeiculo(vincularveiculoDTO.Id_Veiculo);
                        bndVeiculoGrid.Add(VincularVeiculoDTObindingSource.Current);

                        break;
                    case Enumeradores.TipoOperacao.Update:
                        vincularveiculoGL.Update((VincularVeiculoDTO)VincularVeiculoDTObindingSource.Current);
                        bndVeiculoGrid.List[bndVeiculoGrid.Position] = VincularVeiculoDTObindingSource.Current;
                        break;
                    default:
                        break;
                }

            }
            catch
            {
                Cursor = Cursors.Default;
                throw;
            }
            Cursor = Cursors.Default;
            return true;
        }

        private bool VerificarDados()
        {
            bool alterou = false;
            //Verificação de alterações precisaram ser feitas uma a uma, pois o vincularveiculoDTO
            //sempre estaria diferente da versão original após receber a descrição do veículo e do cliente.

            if (tpOperacao == Enumeradores.TipoOperacao.Update)
            {
                if (!(vincularveiculoDTO.Ano).Equals(vincularveiculoDTOVersaoOriginal.Ano))
                {
                    alterou = true;
                }
                if (!(vincularveiculoDTO.Id_Cliente).Equals(vincularveiculoDTOVersaoOriginal.Id_Cliente))
                {
                    alterou = true;
                }
                if (!(vincularveiculoDTO.Id_Veiculo).Equals(vincularveiculoDTOVersaoOriginal.Id_Veiculo))
                {
                    alterou = true;
                }
                if (!(vincularveiculoDTO.Km).Equals(vincularveiculoDTOVersaoOriginal.Km))
                {
                    alterou = true;
                }
                if (!(vincularveiculoDTO.Modelo).Equals(vincularveiculoDTOVersaoOriginal.Modelo))
                {
                    alterou = true;
                }
                if (!(vincularveiculoDTO.Num_chassi).Equals(vincularveiculoDTOVersaoOriginal.Num_chassi))
                {
                    alterou = true;
                }
                if (!(vincularveiculoDTO.Obs).Equals(vincularveiculoDTOVersaoOriginal.Obs))
                {
                    alterou = true;
                }
                if (!(vincularveiculoDTO.Placa).Equals(vincularveiculoDTOVersaoOriginal.Placa))
                {
                    alterou = true;
                }
                if (MechTech.Util.Global.LerImagemBinaria(vincularveiculoDTO.Foto) != null)
                {
                    if (!(MechTech.Util.Global.LerImagemBinaria(vincularveiculoDTO.Foto).Size).Equals(MechTech.Util.Global.LerImagemBinaria(vincularveiculoDTOVersaoOriginal.Foto).Size))
                    {
                        alterou = true;
                    }
                }
                if (!(vincularveiculoDTO.Cor).Equals(vincularveiculoDTOVersaoOriginal.Cor))
                {
                    alterou = true;
                }

                if (alterou)
                {
                    if (MessageBox.Show("O Sistema identificou dados alterados não salvos. Deseja salvá-los antes de prosseguir?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        return Salvar();
                    else
                        dxErrorProvider.ClearErrors();
                }
            }

            return true;
        }

        private void Navegar()
        {
            Cursor = Cursors.WaitCursor;
            int id_veiculo;
            vincularveiculoDTO = (VincularVeiculoDTO)bndVeiculoGrid.Current;
            id_veiculo = Convert.ToInt32(vincularveiculoGL.GetIdVeiculo(vincularveiculoDTO.Veiculo));
            VincularVeiculoDTObindingSource.DataSource = vincularveiculoGL.GetVincularVeiculo(id_veiculo);
            vincularveiculoDTO = (VincularVeiculoDTO)VincularVeiculoDTObindingSource.Current;
            vincularveiculoDTOVersaoOriginal = new VincularVeiculoDTO(vincularveiculoDTO);
            GetFoto();
            Cursor = Cursors.Default;
        }

        private void HabilitaDesabilitaBotoesNavegacao(bool enabled)
        {
            btnPrimeiro.Enabled = enabled;
            btnAnterior.Enabled = enabled;
            btnProximo.Enabled = enabled;
            btnUltimo.Enabled = enabled;
        }

        private void btnVeiculo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmGridVeiculo frmGrid = new frmGridVeiculo(this, new MechTech.Util.Global.SystemDelegate(SetVeiculo));
            frmGrid.Show();
            Cursor = Cursors.Default;
        }

        private void btnCliente_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmGridCliente frmgrid = new frmGridCliente(this, new MechTech.Util.Global.SystemDelegate(SetCliente));
            frmgrid.Show();
            Cursor = Cursors.Default;
        }

        private void btnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Salvar())
                Close();
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnPrimeiro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndVeiculoGrid.MoveFirst();
            Navegar();
        }

        private void btnUltimo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndVeiculoGrid.MoveLast();
            Navegar();
        }

        private void btnProximo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndVeiculoGrid.MoveNext();
            Navegar();
        }

        private void btnAnterior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!VerificarDados()) return;
            bndVeiculoGrid.MovePrevious();
            Navegar();
        }

        private void fotopictureEdit_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.RestoreDirectory = true;
            file.Filter = "Arquivos de Imagem(*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png";
            if (file.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileinfo = new FileInfo(file.FileName);
                decimal filelength = fileinfo.Length / 1024;
                if (filelength > 200)
                {
                    MessageBox.Show("Foto inválida. O tamanho da imagem não deve ser superior a 200KB.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    fotopictureEdit.Image = null;
                    vincularveiculoDTO.Foto = null;

                }
                else
                {
                    fotopictureEdit.Image = Image.FromFile(file.FileName);
                    vincularveiculoDTO.Foto = MechTech.Util.Global.LerImagem(file.FileName);
                }
            }
            else
            {
                fotopictureEdit.Image = null;
                vincularveiculoDTO.Foto = null;
            }
        }

        private bool ValidaCampos()
        {
            dxErrorProvider.ClearErrors();

            if (vincularveiculoDTO.Placa.Equals(string.Empty))
            {
                dxErrorProvider.SetError(txtPlaca, "Placa inválida. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }

            if (vincularveiculoDTO.Id_Cliente == 0)
            {
                dxErrorProvider.SetError(btnCliente, "Cliente inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }

            if (vincularveiculoDTO.Id_Veiculo == 0)
            {
                dxErrorProvider.SetError(btnVeiculo, "Veículo inválido. Preenchimento obrigatório.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }

            if (dxErrorProvider.HasErrors)
                MessageBox.Show("O Sistema identificou campos obrigatórios não preenchidos ou preenchidos incorretamente. Impossível prosseguir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return dxErrorProvider.HasErrors;
        }

        private void frmVincularVeiculo_Load(object sender, EventArgs e)
        {
            frmGrid.Enabled = false;
            switch (tpOperacao)
            {
                case Enumeradores.TipoOperacao.Insert:
                    HabilitaDesabilitaBotoesNavegacao(false);
                    break;
                case Enumeradores.TipoOperacao.Update:
                    HabilitaDesabilitaBotoesNavegacao(true);
                    break;
                case Enumeradores.TipoOperacao.Viewer:
                    HabilitaDesabilitaBotoesNavegacao(true);
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

        private void txtKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                 && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void frmVincularVeiculo_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGrid.Enabled = true;
        }

        private void GetFoto()
        {
            fotopictureEdit.Image = MechTech.Util.Global.LerImagemBinaria(vincularveiculoDTO.Foto);
        }

        private void btnVeiculo_Leave(object sender, EventArgs e)
        {
            if (int.Parse(btnVeiculo.Text) != 0)
            {
                try
                {
                    txtVeiculo.EditValue = vincularveiculoGL.GetVeiculo(Convert.ToInt32(btnVeiculo.Text));
                }
                catch
                {
                    MessageBox.Show("Veículo não cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtVeiculo.Text = "";
                    btnVeiculo.Focus();
                }
            }
        }

        private void btnCliente_Leave(object sender, EventArgs e)
        {
            if (int.Parse(btnCliente.Text) != 0)
            {
                try
                {
                    txtCliente.EditValue = vincularveiculoGL.GetCliente(Convert.ToInt32(btnCliente.Text));
                }
                catch
                {
                    MessageBox.Show("Cliente não cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCliente.Text = "";
                    btnCliente.Focus();
                }
            }
        }

        private void btnVeiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                 && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                 && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}