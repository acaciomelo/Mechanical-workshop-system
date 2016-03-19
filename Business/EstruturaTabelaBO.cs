using System;
using System.Collections.Generic;
using System.ServiceModel;

#region MECHTECH
using MechTech.Entities;
using MechTech.Data;
#endregion

namespace MechTech.Business
{
    public class EstruturaTabelaBO
    {
        EstruturaTabelaDAO regrasdados = new EstruturaTabelaDAO();

        /// <summary>
        /// Instância básica para EstruturaTabelaBO.
        /// </summary>
        public EstruturaTabelaBO()
        { }

        /// <summary>
        /// Retorna uma lista de objetos EstruturaTabelaDTO.
        /// </summary>
        public List<EstruturaTabelaDTO> GetListAll()
        {
            try
            {
                return regrasdados.GetListAll();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Cria todas as tabelas/objetos para o Banco de dados.
        /// </summary>
        public void Create()
        {
            try
            {
                regrasdados.Create();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// Cria tabelas/objetos de acordo com a instrução especificada.
        /// </summary>
        /// <param name="tables">Tabela(s) a ser(em) criada(s)</param>
        public void Create(List<EstruturaTabelaDTO> tables)
        {
            try
            {
                regrasdados.Create(tables);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}
