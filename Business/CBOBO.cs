using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MECHTECH
using MechTech.Interfaces;
using MechTech.Entities;
using MechTech.Data;
using MechTech.Business.Contracts;
#endregion

namespace MechTech.Business
{
    public class CBOBO : IDados<CBODTO>, ICBOBO
    {
        CBODAO regrasdados = new CBODAO();

        /// <summary>
        /// Instância básica para CBOBO.
        /// </summary>
        public CBOBO()
        { }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(CBODTO CBO)
        {
            try
            {
                ConverterGrupo(CBO, true);
                return regrasdados.Insert(CBO);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Update(CBODTO CBO)
        {
            try
            {
                ConverterGrupo(CBO, true);
                return regrasdados.Update(CBO);
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
        /// Retorna um objeto CBODTO caso a instrução seja bem sucedida.
        /// </summary>
        public CBODTO GetCBO(int id)
        {
            try
            {
                CBODTO cbo = regrasdados.GetCBO(id);
                ConverterGrupo(cbo, false);
                return cbo;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos CBODTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<CBODTO> GetGridCBO(string Campo, string ValorPesquisa)
        {
            try
            {
                List<CBODTO> lstCBO = regrasdados.GetGridCBO(Campo, ValorPesquisa);
                foreach (CBODTO var in lstCBO)
                {
                    ConverterGrupo(var, false);
                }
                return lstCBO;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }



        /// <summary>
        /// Retorna um objeto CBODTO caso a instrução seja bem sucedida.
        /// </summary>
        public CBODTO GetCBOCodigo(string codigo)
        {
            try
            {
                CBODTO cbo = regrasdados.GetCBOCodigo(codigo);
                ConverterGrupo(cbo, false);
                return cbo;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Método responsável por fazer a conversão do campo "Grupo" entre as camadas.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isLarge"></param>
        private void ConverterGrupo(CBODTO item, bool isLarge)
        {
            if (isLarge)
            {
                switch (item.Grupo.ToUpper())
                {
                    case "OCUPAÇÃO":
                        item.Grupo = "O";
                        break;
                    case "SINÔNIMO":
                        item.Grupo = "S";
                        break;
                    default:
                        item.Grupo = string.Empty;
                        break;
                }
            }
            else
            {
                switch (item.Grupo.ToUpper())
                {
                    case "O":
                        item.Grupo = "Ocupação";
                        break;
                    case "S":
                        item.Grupo = "Sinônimo";
                        break;
                    default:
                        item.Grupo = string.Empty;
                        break;
                }
            }
        }
    }
}