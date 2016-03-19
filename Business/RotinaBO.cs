using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MECHTECH
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    public class RotinaBO
    {
        RotinaDAO regrasdados = new RotinaDAO();

        /// <summary>
        /// Instância básica para RotinaBO.
        /// </summary>
        public RotinaBO()
        { }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(RotinaDTO rotina)
        {
            try
            {
                return regrasdados.Insert(rotina);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Update(RotinaDTO rotina)
        {
            try
            {
                return regrasdados.Update(rotina);
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
        /// Retorna um objeto RotinaDTO caso a instrução seja bem sucedida.
        /// </summary>
        public RotinaDTO GetRotina(int id)
        {
            try
            {
                return regrasdados.GetRotina(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos RotinaDTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<RotinaDTO> GetGridRotina(string valorpesquisa, bool verificalog)
        {
            try
            {
                List<RotinaDTO> lista = new List<RotinaDTO>();
                foreach (RotinaDTO umregistro in regrasdados.GetGridRotina(valorpesquisa))
                {
                    if (verificalog)
                    {
                        if (!umregistro.Log)
                            continue;
                    }

                    if (umregistro.Descricao == "" && umregistro.Acao != "")
                        umregistro.Descricao = umregistro.Acao;

                    if (umregistro.Nivel.Length > 2)
                        umregistro.ParentNivel = umregistro.Nivel.Substring(0, umregistro.Nivel.Length - 2);
                    else
                        umregistro.ParentNivel = umregistro.Nivel;

                    lista.Add(umregistro);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public List<RotinaDTO> GetRotinaModulo(string modulo)
        {
            try
            {
                return regrasdados.GetRotinaModulo(modulo);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

    }
}
