using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MECHTECH
using MechTech.Interfaces;
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    public class HorarioBO : IDados<HorarioDTO>
    {
        HorarioDAO regrasdados = new HorarioDAO();

        /// <summary>
        /// Instância básica para HorarioBO.
        /// </summary>
        public HorarioBO()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(HorarioDTO Horario)
        {
            try
            {
                return regrasdados.Insert(Horario);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do objeto especificado, caso contrário FALSO.
        /// </summary>
        public bool Update(HorarioDTO Horario)
        {
            try
            {
                return regrasdados.Update(Horario);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do conteúdo especificado, caso contrário FALSO.
        /// </summary>
        public bool Delete(int id)
        {
            try
            {
                return regrasdados.Delete(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um objeto HorarioDTO para a instrução do conteúdo especificado.
        /// </summary>
        public HorarioDTO GetHorario(int id)
        {
            try
            {
                return regrasdados.GetHorario(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos HorarioDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<HorarioDTO> GetGridHorario(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetGridHorario(campo, valorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }



        /// <summary>
        /// Retorna uma string com o resumo do horário do funcionário selecionado.
        /// </summary>
        public string HorarioResumido(int funcionario, bool parenteses, string separador, bool quebra, string sep_hora, string sep_periodo)
        {
            string dados = string.Empty;
            try
            {
                HorarioSemanaDAO horarios = new HorarioSemanaDAO();
                List<HorarioSemanaDTO> horariofuncionario = horarios.GetHorarioSemanaFuncionario(funcionario);
                List<HorarioSemanaDTO> horarioetiqueta = new List<HorarioSemanaDTO>();

                foreach (HorarioSemanaDTO umhorario in horariofuncionario)
                {
                    if (umhorario.Entradapp == Convert.ToDateTime("01/01/1900") &&
                        umhorario.Entradasp == Convert.ToDateTime("01/01/1900") &&
                        umhorario.Saidapp == Convert.ToDateTime("01/01/1900") &&
                        umhorario.Saidasp == Convert.ToDateTime("01/01/1900"))
                    {
                        continue;
                    }
                    HorarioSemanaDTO umhorarioprocessado = horarioetiqueta.Find(delegate(HorarioSemanaDTO item) { return item.Entradapp == umhorario.Entradapp && item.Entradasp == umhorario.Entradasp && item.Saidapp == umhorario.Saidapp && item.Saidasp == umhorario.Saidasp; });
                    if (umhorarioprocessado == null)
                    {
                        horarioetiqueta.Add(umhorario);
                    }
                    else
                    {
                        int dia = umhorarioprocessado.Diadasemana;
                        horarioetiqueta.Remove(umhorarioprocessado);
                        umhorarioprocessado.Diadasemana = int.Parse(dia.ToString() + umhorario.Diadasemana.ToString());
                        horarioetiqueta.Add(umhorarioprocessado);
                    }
                }

                foreach (HorarioSemanaDTO umhorario in horarioetiqueta)
                {
                    if (umhorario.Entradapp != Convert.ToDateTime("01/01/1900 00:00:00") ||
                        umhorario.Saidapp != Convert.ToDateTime("01/01/1900 00:00:00"))
                        dados = dados + umhorario.Entradapp.ToShortTimeString() + sep_hora + umhorario.Saidapp.ToShortTimeString();

                    if ((umhorario.Entradapp != Convert.ToDateTime("01/01/1900 00:00:00") &&
                        umhorario.Entradasp != Convert.ToDateTime("01/01/1900 00:00:00")) &&
                        (umhorario.Saidapp != Convert.ToDateTime("01/01/1900 00:00:00") &&
                        umhorario.Saidasp != Convert.ToDateTime("01/01/1900 00:00:00")))
                        dados = dados + sep_periodo;

                    if (umhorario.Entradasp != Convert.ToDateTime("01/01/1900 00:00:00") ||
                        umhorario.Saidasp != Convert.ToDateTime("01/01/1900 00:00:00"))
                        dados = dados + umhorario.Entradasp.ToShortTimeString() + sep_hora + umhorario.Saidasp.ToShortTimeString();

                    dados = dados + "  ";

                    if (parenteses)
                        dados = dados + "(";

                    for (int i = 0; i < umhorario.Diadasemana.ToString().Length; i++)
                    {
                        switch (umhorario.Diadasemana.ToString().Substring(i, 1))
                        {
                            case "1":
                                dados = dados + "Dom" + separador;
                                break;
                            case "2":
                                dados = dados + "Seg" + separador;
                                break;
                            case "3":
                                dados = dados + "Ter" + separador;
                                break;
                            case "4":
                                dados = dados + "Qua" + separador;
                                break;
                            case "5":
                                dados = dados + "Qui" + separador;
                                break;
                            case "6":
                                dados = dados + "Sex" + separador;
                                break;
                            case "7":
                                dados = dados + "Sab" + separador;
                                break;
                        }
                    }
                    dados = dados.Substring(0, dados.Length - 1);
                    if (parenteses)
                        dados = dados + ")";

                    if (quebra)
                        dados = dados + "\n";
                    else
                        dados = dados + ", ";
                }
                dados = dados.Substring(0, dados.Length - 2);  //37712
            }
            catch
            {
                dados = string.Empty;
            }
            return dados;
        }
    }
}