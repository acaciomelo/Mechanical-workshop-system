using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;

#region MECHTECH
using MechTech.Util;
using MechTech.Interfaces;
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    public class FuncionarioBO : IDados<FuncionarioDTO>
    {
        FuncionarioDAO regrasdados = new FuncionarioDAO();

        /// <summary>
        /// Instância básica para FuncionarioBO.
        /// </summary>
        public FuncionarioBO()
        { }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(FuncionarioDTO funcionario)
        {
            try
            {
                ConverterSexo(funcionario, true);
                ConverterTipoConta(funcionario, true);
                ConverterTipoAdto(funcionario, true);
                ConverterTipoExame(funcionario, true);
                return regrasdados.Insert(funcionario);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Update(FuncionarioDTO funcionario)
        {
            try
            {
                ConverterSexo(funcionario, true);
                ConverterTipoConta(funcionario, true);
                ConverterTipoAdto(funcionario, true);
                ConverterTipoExame(funcionario, true);
                return regrasdados.Update(funcionario);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
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
        /// Retorna um objeto FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public FuncionarioDTO GetFuncionario(int id)
        {
            try
            {
                FuncionarioDTO funcionario = regrasdados.GetFuncionario(id);
                ConverterSexo(funcionario, false);
                ConverterTipoConta(funcionario, false);
                //ConverterTipoAdto(funcionario, false);
                //ConverterTipoExame(funcionario, false);
                //CompletaRRAMeses(funcionario);
                //CompletaConvenios(funcionario);

                return funcionario;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }



        /// <summary>
        /// Responsável por verificar a existência de CPF´s duplicados.
        /// </summary>
        /// <param name="id_funcionario">ID do funcionário ignorado na pesquisa</param>
        /// <param name="cpf">Número de um CPF válido</param>
        /// <returns>true=CPF encontrado, false=CPF não encontrado</returns>
        public bool ExistsCPF(int id_funcionario, string cpf)
        {
            try
            {
                return new FuncDocumentoDAO().ExistsCPF(id_funcionario, cpf);
            }
            catch
            {
                return false;
            }
        }

        public int GetTotalFuncionarios()
        {
            try
            {
                return regrasdados.GetTotalFuncionarios();
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Retorna uma lista de funcionários selecionados.
        /// </summary>
        /// <param name="ids">Informar um ou mais códigos de funcionário separados por ponto-e-vírgula. Ex.: 3 ou 1;3;5;12;4</param>
        public List<FuncionarioDTO> GetFuncionarios(string ids)
        {
            try
            {
                return regrasdados.GetFuncionarios(ids, MechTech.Util.Global.MesanoAtivo, Enumeradores.Modulo.Funcionario);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de funcionários selecionados.
        /// Protótipo com seleção
        /// </summary>
        /// <param name="ids">Informar um ou mais códigos de funcionário separados por ponto-e-vírgula. Ex.: 3 ou 1;3;5;12;4</param>
        public List<FuncionarioDTO> GetFuncionarios(string ids, FuncPesquisaDTO opcoes)
        {
            try
            {
                return regrasdados.GetFuncionarios(ids, MechTech.Util.Global.MesanoAtivo, Enumeradores.Modulo.Funcionario, opcoes);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public string GetNomeCompleto(int id)
        {
            try
            {
                return regrasdados.GetNomeCompleto(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um objeto FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public FuncionarioDTO GetFuncionarioDigitacao(int id)
        {
            try
            {
                return regrasdados.GetFuncionarioDigitacao(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FuncionarioDTO> GetGridFuncionario(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetGridFuncionario(campo, valorPesquisa, MechTech.Util.Global.MesanoAtivo);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FichaFinanceiraGridDTO caso a instrução seja bem sucedida.
        /// </summary>
        //public List<FichaFinanceiraGridDTO> GetGridFuncionarioFichaFinan(FichaFinanceiraGridDTO obj, bool apresentardemitidos)
        //{
        //    try
        //    {
        //        return regrasdados.GetGridFuncionarioFichaFinan(obj, apresentardemitidos);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new FaultException(ex.Message);
        //    }
        //}

        /// <summary>
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FuncionarioDTO> GetListFuncionario(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetListFuncionario(campo, valorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


        /// <summary>
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FuncionarioDTO> GetGridFuncionario(string campo, string valorPesquisa, Enumeradores.Modulo modulo)
        {
            try
            {
                List<FuncionarioDTO> lstFuncionario = regrasdados.GetGridFuncionario(campo, valorPesquisa, modulo);
                foreach (FuncionarioDTO var in lstFuncionario)
                {
                    ConverterSexo(var, false);
                    ConverterTipoConta(var, false);
                    ConverterTipoAdto(var, false);
                    ConverterTipoExame(var, false);
                }
                return lstFuncionario;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<FuncionarioSEDTO> GetGridFuncionarioSE(string campo, string valorPesquisa, Enumeradores.Modulo modulo, bool apresentardemitidos)
        {
            try
            {
                return regrasdados.GetGridFuncionarioSE(campo, valorPesquisa, modulo, apresentardemitidos);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Extension
        /// </summary>
        //public List<FuncionarioSEexDTO> GetGridFuncionarioSEex(string campo, string valorPesquisa, Enumeradores.Modulo modulo)
        //{
        //    try
        //    {
        //        return regrasdados.GetGridFuncionarioSEex(campo, valorPesquisa, modulo);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new FaultException(ex.Message);
        //    }
        //}

        /// <summary>
        /// Retorna uma lista de objetos FuncionarioDTO caso a instrução seja bem sucedida.
        /// </summary>
        /// <param name="campo">O valor especificado será a chave de indexação da pesquisa</param>
        public List<FuncionarioDTO> GetListDadosLayout(string campo, string valorpesquisa)
        {
            try
            {
                return regrasdados.GetListDadosLayout(campo, valorpesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Método responsável por fazer a conversão do campo "Sexo" entre as camadas.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isLarge"></param>
        public void ConverterSexo(FuncionarioDTO item, bool isLarge)
        {
            if (isLarge)
            {
                switch (item.Sexo.ToUpper())
                {
                    case "MASCULINO":
                        item.Sexo = "M";
                        break;
                    case "FEMININO":
                        item.Sexo = "F";
                        break;
                    default:
                        item.Sexo = string.Empty;
                        break;
                }
            }
            else
            {
                switch (item.Sexo.ToUpper())
                {
                    case "M":
                        item.Sexo = "Masculino";
                        break;
                    case "F":
                        item.Sexo = "Feminino";
                        break;
                    default:
                        item.Sexo = string.Empty;
                        break;
                }
            }
        }

        /// <summary>
        /// Método responsável por fazer a conversão do campo "Salcontatp" entre as camadas.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isLarge"></param>
        public void ConverterTipoConta(FuncionarioDTO item, bool isLarge)
        {
            if (isLarge)
            {
                switch (item.Salcontatp.ToUpper())
                {
                    case "CORRENTE":
                        item.Salcontatp = "C";
                        break;
                    case "SALÁRIO":
                        item.Salcontatp = "S";
                        break;
                    case "POUPANÇA":
                        item.Salcontatp = "P";
                        break;
                    default:
                        item.Salcontatp = string.Empty;
                        break;
                }
            }
            else
            {
                switch (item.Salcontatp.ToUpper())
                {
                    case "C":
                        item.Salcontatp = "Corrente";
                        break;
                    case "S":
                        item.Salcontatp = "Salário";
                        break;
                    case "P":
                        item.Salcontatp = "Poupança";
                        break;
                    default:
                        item.Salcontatp = string.Empty;
                        break;
                }
            }
        }

        /// <summary>
        /// Método responsável por fazer a conversão do campo "Tipo de adiantamento" entre as camadas.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isLarge"></param>
        public void ConverterTipoAdto(FuncionarioDTO item, bool isLarge)
        {
            if (isLarge)
            {
                switch (item.Contrato.Tipo_adto.ToUpper())
                {
                    case "PERCENTUAL":
                        item.Contrato.Tipo_adto = "P";
                        break;
                    case "VALOR":
                        item.Contrato.Tipo_adto = "V";
                        break;
                    default:
                        item.Contrato.Tipo_adto = string.Empty;
                        break;
                }
            }
            else
            {
                switch (item.Contrato.Tipo_adto.ToUpper())
                {
                    case "P":
                        item.Contrato.Tipo_adto = "Percentual";
                        break;
                    case "V":
                        item.Contrato.Tipo_adto = "Valor";
                        break;
                    default:
                        item.Contrato.Tipo_adto = string.Empty;
                        break;
                }
            }
        }

        /// <summary>
        /// Método responsável por fazer a conversão do campo "Tipo de Exame" entre as camadas.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isLarge"></param>
        public void ConverterTipoExame(FuncionarioDTO item, bool isLarge)
        {
        }


        /// <summary>
        /// Método responsável por completar a tabela de meses do RRAMeses entre as camadas.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isLarge"></param>
        //public void CompletaRRAMeses(FuncionarioDTO item)
        //{
        //    foreach (FuncRRADTO umrra in item.Funcrra)
        //    {

        //        for (int i = 1; i < 13; i++)
        //        {
        //            var mes = from m in umrra.FuncRRAmeses
        //                      where m.Mes == i
        //                      select m;

        //            if (mes.Count() > 0)
        //            {
        //                List<FuncRRAmesesDTO> mesexistente = mes.ToList();
        //                switch (mesexistente[0].Mes)
        //                {
        //                    case 1:
        //                        mesexistente[0].DescMes = "Janeiro";
        //                        break;
        //                    case 2:
        //                        mesexistente[0].DescMes = "Fevereiro";
        //                        break;
        //                    case 3:
        //                        mesexistente[0].DescMes = "Março";
        //                        break;
        //                    case 4:
        //                        mesexistente[0].DescMes = "Abril";
        //                        break;
        //                    case 5:
        //                        mesexistente[0].DescMes = "Maio";
        //                        break;
        //                    case 6:
        //                        mesexistente[0].DescMes = "Junho";
        //                        break;
        //                    case 7:
        //                        mesexistente[0].DescMes = "Julho";
        //                        break;
        //                    case 8:
        //                        mesexistente[0].DescMes = "Agosto";
        //                        break;
        //                    case 9:
        //                        mesexistente[0].DescMes = "Setembro";
        //                        break;
        //                    case 10:
        //                        mesexistente[0].DescMes = "Outubro";
        //                        break;
        //                    case 11:
        //                        mesexistente[0].DescMes = "Novembro";
        //                        break;
        //                    case 12:
        //                        mesexistente[0].DescMes = "Dezembro";
        //                        break;
        //                }
        //            }
        //            else
        //            {
        //                FuncRRAmesesDTO tab = new FuncRRAmesesDTO();
        //                tab.Mes = i;
        //                switch (i)
        //                {
        //                    case 1:
        //                        tab.DescMes = "Janeiro";
        //                        break;
        //                    case 2:
        //                        tab.DescMes = "Fevereiro";
        //                        break;
        //                    case 3:
        //                        tab.DescMes = "Março";
        //                        break;
        //                    case 4:
        //                        tab.DescMes = "Abril";
        //                        break;
        //                    case 5:
        //                        tab.DescMes = "Maio";
        //                        break;
        //                    case 6:
        //                        tab.DescMes = "Junho";
        //                        break;
        //                    case 7:
        //                        tab.DescMes = "Julho";
        //                        break;
        //                    case 8:
        //                        tab.DescMes = "Agosto";
        //                        break;
        //                    case 9:
        //                        tab.DescMes = "Setembro";
        //                        break;
        //                    case 10:
        //                        tab.DescMes = "Outubro";
        //                        break;
        //                    case 11:
        //                        tab.DescMes = "Novembro";
        //                        break;
        //                    case 12:
        //                        tab.DescMes = "Dezembro";
        //                        break;
        //                }
        //                umrra.FuncRRAmeses.Add(tab);
        //            }
        //        }

        //        umrra.Rendimento = umrra.FuncRRAmeses.Sum(r => r.Rendimento);
        //        umrra.Previdencia = umrra.FuncRRAmeses.Sum(r => r.Previdencia);
        //        umrra.Pensao = umrra.FuncRRAmeses.Sum(r => r.Pensao);
        //        umrra.Imposto = umrra.FuncRRAmeses.Sum(r => r.Imposto);
        //        umrra.Despesas = umrra.FuncRRAmeses.Sum(r => r.Despesas);
        //        umrra.Qtdemeses = umrra.FuncRRAmeses.Sum(r => r.Qtdemeses);

        //        var rraordenado = from r in umrra.FuncRRAmeses
        //                          orderby r.Mes
        //                          select r;
        //        umrra.FuncRRAmeses = (List<FuncRRAmesesDTO>)rraordenado.ToList();

        //    }
        //}

        /// <summary>
        /// Método responsável por completar a tabela de convenios entre as camadas.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isLarge"></param>
        //public void CompletaConvenios(FuncionarioDTO item)
        //{
        //    foreach (FuncFornDTO umitem in item.FuncFornecedor)
        //    {
        //        if (umitem.Dependente.Id == 0)
        //            continue;

        //        umitem.Dependente = (FuncParentescoDTO)(from d in item.Parentesco
        //                                                where d.Id == umitem.Dependente.Id
        //                                                select d).First();

        //        umitem.Funcionario.Documento = item.Documento;
        //    }

        //}
    }
}