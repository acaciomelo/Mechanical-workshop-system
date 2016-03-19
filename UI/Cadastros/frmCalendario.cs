using System;
using System.Collections.Generic;
using System.Windows.Forms;

#region DEVEXPRESS
using DevExpress.XtraScheduler;
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
    public partial class frmCalendario : frmBase
    {
        bool desabilitaEventoInsert = true;
        DateTime periodoInicial = DateTime.Today;
        DateTime periodoFinal = DateTime.Today;
        EmpresaGL empresa = new EmpresaGL();
        public frmCalendario()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void repositoryItemMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int mes = ((DevExpress.XtraScheduler.UI.MonthEdit)sender).Month;
            int ano = Convert.ToInt32(barEditItemAno.EditValue);
            this.ConfiguraMesAtual(mes, ano);
        }

        private void repositoryItemSpinEditAno_EditValueChanged(object sender, EventArgs e)
        {
            int mes = Convert.ToInt32(barEditItemMes.EditValue);
            int ano = Convert.ToInt32(((DevExpress.XtraEditors.SpinEdit)sender).EditValue);
            this.ConfiguraMesAtual(mes, ano);
        }

        /// <summary>
        /// Identificação da quantidade de dias úteis, domingos e feriados para o mês/ano selecionado.
        /// </summary>
        private void DiscriminacaoDiasMes()
        {
            int diasuteis = DateTime.DaysInMonth(periodoInicial.Year, periodoInicial.Month);
            int feriados = 0;

            EmpresaDTO config = null;
            try
            {
                config = empresa.GetEmpresa(Convert.ToInt32(Global.EmpresaAtiva.Replace("emp", string.Empty)));
            }
            catch { }

            foreach (FeriadoDTO umferiado in new FeriadoGL().GetFeriadoPeriodo(periodoInicial,
                        new DateTime(periodoFinal.Year, periodoFinal.Month, 1).AddMonths(1).AddDays(-1), 0, 0))
            {
                if (umferiado.Data.Value.DayOfWeek != DayOfWeek.Sunday)
                    feriados++;
            }

            //DIAS
            barEditItemDomingosFeriados.EditValue = Global.ObterDomingos(periodoInicial.Month, periodoInicial.Year) + feriados;
            barEditItemDiasuteis.EditValue = diasuteis - (int)barEditItemDomingosFeriados.EditValue;
            //HORAS
            barEditItemDomingosFeriadosHR.EditValue = Convert.ToString(Math.Round(Convert.ToInt32(barEditItemDomingosFeriados.EditValue.ToString()) * 7.3333, 2)) + " hr.";
            barEditItemDiasuteisHR.EditValue = Convert.ToString(Math.Round(Convert.ToInt32(barEditItemDiasuteis.EditValue.ToString()) * 7.3333, 2)) + " hr.";
        }

        private void frmCalendario_Load(object sender, EventArgs e)
        {
            // selecione o mês e ano atual na caixa de mês.
            barEditItemMes.EditValue = Global.MesanoAtivo.Month;
            barEditItemAno.EditValue = Global.MesanoAtivo.Year;
            this.ConfiguraMesAtual(Convert.ToInt32(barEditItemMes.EditValue),
                                   Convert.ToInt32(barEditItemAno.EditValue));
        }

        private void ConfiguraMesAtual(int mes, int ano)
        {
            DateTime diaInicial = new DateTime(ano, mes, 1);
            DateTime diaFinal = new DateTime(ano, mes, 1).AddMonths(1).AddDays(-1);
            periodoInicial = diaInicial;
            periodoFinal = diaFinal;

            schedulerControl.LimitInterval.Start = diaInicial;
            schedulerControl.LimitInterval.End = diaFinal;
            schedulerStorage.Appointments.Items.Clear();
            this.AdicionaFeriadoCadastrado(new DateTime(ano, 1, 1), new DateTime(ano, 12, 31));
            DiscriminacaoDiasMes();
        }

        private void schedulerControl_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            Enumeradores.TipoOperacao tpo;

            FeriadoDTO feriadoDTO;
            if (e.Appointment.Subject == "")
            {
                feriadoDTO = new FeriadoDTO();
                feriadoDTO.Data = schedulerControl.SelectedInterval.Start;
                feriadoDTO.Especie = "Fixo";
                feriadoDTO.Tipo = "Federal";

                tpo = Enumeradores.TipoOperacao.Insert;
            }
            else
            {
                feriadoDTO = (FeriadoDTO)e.Appointment.CustomFields["Feriado"];
                if (feriadoDTO.Especie.Equals("F"))
                    feriadoDTO.Especie = "Fixo";
                else if (feriadoDTO.Especie.Equals("M"))
                    feriadoDTO.Especie = "Móvel";

                switch (feriadoDTO.Tipo)
                {
                    case "M":
                        feriadoDTO.Tipo = "Municipal";
                        break;
                    case "E":
                        feriadoDTO.Tipo = "Estadual";
                        break;
                    case "F":
                        feriadoDTO.Tipo = "Federal";
                        break;
                    default:
                        break;
                }
                tpo = Enumeradores.TipoOperacao.Update;
            }


            Cursor = Cursors.WaitCursor;
            frmUpdateCalendario frm = new frmUpdateCalendario(feriadoDTO, tpo);
            frm.ShowDialog();
            Cursor = Cursors.Default;
            if (frm.DialogResult == DialogResult.OK)
            {
                Appointment apontamento = e.Appointment;
                apontamento.AllDay = true;
                apontamento.Start = (DateTime)feriadoDTO.Data;
                apontamento.End = (DateTime)feriadoDTO.Data;
                apontamento.Subject = feriadoDTO.Descricao;
                apontamento.LabelId = 1;
                apontamento.CustomFields["Feriado"] = feriadoDTO;
                schedulerStorage.Appointments.Add(apontamento);
            }

            e.DialogResult = frm.DialogResult;
            e.Handled = true;
        }

        private void schedulerStorage_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e)
        {
            if (MessageBox.Show("Deseja excluir os feriados lançados repetidamente?\n(Este evento e os eventos seguintes serão deletados)", "Excluir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                int mes = Convert.ToInt32(barEditItemMes.EditValue);
                int ano = Convert.ToInt32(barEditItemAno.EditValue);
                ConfiguraMesAtual(mes, ano);
                return;
            }
            FeriadoGL feriadoGL = new FeriadoGL();
            Appointment apt;
            FeriadoDTO feriado;
            Cursor = Cursors.WaitCursor;
            try
            {
                for (int i = 0; i < e.Objects.Count; i++)
                {
                    apt = (Appointment)e.Objects[i];
                    feriado = (FeriadoDTO)apt.CustomFields["Feriado"];

                    if (feriado.Repete == true)
                        feriadoGL.Delete(feriado);
                    else
                        feriadoGL.Delete(feriado.Id);

                    //new LOGGL().GravaLOG(1020, "Deletado dia " + feriado.Data.ToString() + " - " + feriado.Descricao);
                }

                DiscriminacaoDiasMes();
            }
            catch
            {
                Cursor = Cursors.Default;
                throw;
            }
            Cursor = Cursors.Default;
        }

        private void schedulerStorage_AppointmentsInserted(object sender, PersistentObjectsEventArgs e)
        {
            if (desabilitaEventoInsert == false)
            {
                FeriadoGL feriadoGL = new FeriadoGL();
                Appointment apt;
                Cursor = Cursors.WaitCursor;
                try
                {
                    for (int i = 0; i < e.Objects.Count; i++)
                    {
                        apt = (Appointment)e.Objects[i];
                        int ID = feriadoGL.Insert((FeriadoDTO)apt.CustomFields["Feriado"]);
                        ((FeriadoDTO)apt.CustomFields["Feriado"]).Id = ID;
                    }

                    DiscriminacaoDiasMes();
                }
                catch
                {
                    Cursor = Cursors.Default;
                    throw;
                }
                Cursor = Cursors.Default;
            }
        }
        private void AdicionaFeriadoCadastrado(DateTime periodoInicial, DateTime periodoFinal)
        {
            FeriadoGL feriadoGL = new FeriadoGL();
            List<FeriadoDTO> lstFeriado = new List<FeriadoDTO>();
            Appointment apontamento;

            schedulerStorage.BeginUpdate();
            desabilitaEventoInsert = true;
            try
            {
                lstFeriado = feriadoGL.GetFeriadoPeriodo(periodoInicial, periodoFinal, 0, 0);

                foreach (FeriadoDTO feriadoDTO in lstFeriado)
                {
                    apontamento = new Appointment(AppointmentType.Normal);
                    apontamento.AllDay = true;
                    apontamento.Start = (DateTime)feriadoDTO.Data;
                    apontamento.End = (DateTime)feriadoDTO.Data;
                    apontamento.Subject = feriadoDTO.Descricao;
                    apontamento.LabelId = 1;
                    int apt = schedulerStorage.Appointments.Add(apontamento);
                    schedulerStorage.Appointments[apt].CustomFields["Feriado"] = feriadoDTO;
                }
            }
            catch
            {
                schedulerStorage.EndUpdate();
                desabilitaEventoInsert = false;
                throw;
            }
            schedulerStorage.EndUpdate();
            desabilitaEventoInsert = false;
            return;
        }

        private void schedulerStorage_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            if (desabilitaEventoInsert == false)
            {
                FeriadoGL feriadoGL = new FeriadoGL();
                Appointment apt;
                Cursor = Cursors.WaitCursor;
                try
                {
                    for (int i = 0; i < e.Objects.Count; i++)
                    {
                        apt = (Appointment)e.Objects[i];
                        FeriadoDTO feriado = (FeriadoDTO)apt.CustomFields["Feriado"];
                        feriado.Data = apt.Start; // troca para o caso do usuário ter arrastado o feriado.
                        feriadoGL.Update(feriado);
                    }

                    DiscriminacaoDiasMes();
                }
                catch
                {
                    Cursor = Cursors.Default;
                    throw;
                }
                Cursor = Cursors.Default;
            }
        }

        private void schedulerControl_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            SchedulerMenuItem item;
            item = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAppointment, false);
            if (item != null)
                item.Caption = "&Inserir Feriado";

            item = e.Menu.GetMenuItemById(SchedulerMenuItemId.OpenAppointment, false);
            if (item != null)
                item.Caption = "&Alterar Feriado";

            item = e.Menu.GetMenuItemById(SchedulerMenuItemId.DeleteAppointment, false);
            if (item != null)
                item.Caption = "&Excluir Feriado";

            // oculta os demais menus desnecessários.
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.SwitchViewMenu);
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAllDayEvent);
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringAppointment);
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringEvent);
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.GotoDate);
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.GotoToday);
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.LabelSubMenu);
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.LabelSubMenu);
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.StatusSubMenu);
        }
    }
}