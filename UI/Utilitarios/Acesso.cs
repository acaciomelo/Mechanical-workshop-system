using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

#region DEVEXPRESS
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Columns;
#endregion

namespace MechTech.Util
{
    public class Acesso
    {
        List<Acesso> acessos = new List<Acesso>();
        int rotina = 0;
        BarSubItem barsubitem = new BarSubItem();
        BarButtonItem barbuttonitem = new BarButtonItem();
        SimpleButton simplebutton = new SimpleButton();
        ToolStripMenuItem toolstripmenuitem = new ToolStripMenuItem();
        GridControl gridcontrol = new GridControl();
        GridColumn gridcolumn = new GridColumn();
        Enumeradores.TipoAcao acao = Enumeradores.TipoAcao.Desabilitar;

        public Acesso()
        { }

        /// <summary>
        /// Controles.
        /// </summary>
        public void Add(int rotina, BarButtonItem controle, Enumeradores.TipoAcao acao)
        {
            if (!Ignore())
                acessos.Add(new Acesso() { rotina = rotina, barbuttonitem = controle, acao = acao });
        }

        /// <summary>
        /// Controles.
        /// </summary>
        public void Add(int rotina, BarSubItem controle, Enumeradores.TipoAcao acao)
        {
            if (!Ignore())
                acessos.Add(new Acesso() { rotina = rotina, barsubitem = controle, acao = acao });
        }

        /// <summary>
        /// Controles.
        /// </summary>
        public void Add(int rotina, SimpleButton controle, Enumeradores.TipoAcao acao)
        {
            if (!Ignore())
                acessos.Add(new Acesso() { rotina = rotina, simplebutton = controle, acao = acao });
        }

        /// <summary>
        /// Controles.
        /// </summary>
        public void Add(int rotina, ToolStripMenuItem controle, Enumeradores.TipoAcao acao)
        {
            if (!Ignore())
                acessos.Add(new Acesso() { rotina = rotina, toolstripmenuitem = controle, acao = acao });
        }

        /// <summary>
        /// Controles.
        /// </summary>
        public void Add(int rotina, GridControl controle, Enumeradores.TipoAcao acao)
        {
            if (!Ignore())
                acessos.Add(new Acesso() { rotina = rotina, gridcontrol = controle, acao = acao });
        }

        /// <summary>
        /// Controles.
        /// </summary>
        public void Add(int rotina, GridColumn controle, Enumeradores.TipoAcao acao)
        {
            if (!Ignore())
                acessos.Add(new Acesso() { rotina = rotina, gridcolumn = controle, acao = acao });
        }

        private bool Ignore()
        {
            if (Global.UsuarioAtivo.ToUpper() == "MECHTECH" ||
                Global.Supervisor)
                return true;
            return false;
        }

        /// <summary>
        /// Controles.
        /// </summary>
        public void Validate()
        {
            foreach (Acesso umacesso in acessos)
            {
                var acesso = from a in Global.Acessos
                             where a == umacesso.rotina
                             select a;
                if (acesso.Count() <= 0)
                {
                    if (umacesso.acao == Enumeradores.TipoAcao.Desabilitar)
                    {
                        umacesso.barbuttonitem.Enabled = false;
                        umacesso.barsubitem.Enabled = false;
                        umacesso.simplebutton.Enabled = false;
                        umacesso.toolstripmenuitem.Enabled = false;
                        umacesso.gridcontrol.Enabled = false;
                    }
                    else
                    {
                        umacesso.barbuttonitem.Visibility = BarItemVisibility.Never;
                        umacesso.barsubitem.Visibility = BarItemVisibility.Never;
                        umacesso.simplebutton.Visible = false;
                        umacesso.toolstripmenuitem.Visible = false;
                        umacesso.gridcontrol.Visible = false;
                        umacesso.gridcolumn.Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// Formulário.
        /// </summary>
        public void Validate(XtraForm form)
        {
            Validate(form.Controls);
        }

        /// <summary>
        /// Formulário (Barra de botões).
        /// </summary>
        public void Validate(BarManager bar)
        {
            foreach (BarItem item in bar.Items)
            {
                if (item.Caption.Trim().ToUpper() == "&CANCELAR")
                    continue;
                item.Enabled = false;
            }
        }

        /// <summary>
        /// Formulário (Menus de contexto).
        /// </summary>
        public void Validate(ContextMenuStrip contextmenu)
        {
            foreach (ToolStripItem item in contextmenu.Items)
            {
                item.Enabled = false;
            }
        }

        private void Validate(Control.ControlCollection controls)
        {
            foreach (Control item in controls)
            {
                if (item.Controls.Count > 0)
                    Validate(item.Controls);

                if (item.GetType() == typeof(SimpleButton))
                    ((SimpleButton)item).Enabled = false;
                else if (item.GetType() == typeof(TextEdit))
                    ((TextEdit)item).Properties.ReadOnly = true;
                else if (item.GetType() == typeof(ComboBoxEdit))
                    ((ComboBoxEdit)item).Properties.ReadOnly = true;
                else if (item.GetType() == typeof(LookUpEdit))
                    ((LookUpEdit)item).Properties.ReadOnly = true;
                else if (item.GetType() == typeof(SpinEdit))
                    ((SpinEdit)item).Properties.ReadOnly = true;
                else if (item.GetType() == typeof(PopupContainerEdit))
                    ((PopupContainerEdit)item).Properties.ReadOnly = true;
                else if (item.GetType() == typeof(RadioGroup))
                    ((RadioGroup)item).Properties.ReadOnly = true;
                else if (item.GetType() == typeof(DateEdit))
                    ((DateEdit)item).Properties.ReadOnly = true;
                else if (item.GetType() == typeof(MemoEdit))
                    ((MemoEdit)item).Properties.ReadOnly = true;
                else if (item.GetType() == typeof(CheckEdit))
                    ((CheckEdit)item).Properties.ReadOnly = true;
                else if (item.GetType() == typeof(PictureEdit))
                    ((PictureEdit)item).Enabled = false;
                else if (item.GetType() == typeof(ButtonEdit))
                {
                    ((ButtonEdit)item).Properties.ReadOnly = true;
                    ((ButtonEdit)item).Properties.Buttons[0].Enabled = false;
                }
                else if (item.GetType() == typeof(GridControl))
                {
                    try
                    {
                        ((GridView)((GridControl)item).Views[0]).OptionsBehavior.Editable = false;
                    }
                    catch { }
                    try
                    {
                        ((BandedGridView)((GridControl)item).Views[0]).OptionsBehavior.Editable = false;
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// Validar acesso em Menus/Botões de atalho.
        /// </summary>
        /// <returns>true=acesso permitido, false=acesso negado</returns>
        public static bool Validate(int id_rotina)
        {
            if (Global.UsuarioAtivo.ToUpper() != "MECHTECH" &&
                !Global.Supervisor)
            {
                var acesso = from a in Global.Acessos
                             where a == id_rotina
                             select a;
                if (acesso.Count() <= 0)
                {
                    MessageBox.Show("Acesso negado.\n\nCaso necessite, solicite liberação ao administrador do Sistema.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Validar acesso em rotinas executadas pelo sistema
        /// </summary>
        /// <returns>true=acesso permitido, false=acesso negado</returns>
        public static bool ValidateRotina(int id_rotina)
        {
            if (Global.UsuarioAtivo.ToUpper() != "MECHTECH" &&
                !Global.Supervisor)
            {
                var acesso = from a in Global.Acessos
                             where a == id_rotina
                             select a;
                if (acesso.Count() <= 0)
                    return false;
            }
            return true;
        }
    }
}