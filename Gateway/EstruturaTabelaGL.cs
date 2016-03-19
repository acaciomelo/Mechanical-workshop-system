using System.Collections.Generic;

#region MECHTECH
using MechTech.Business;
using MechTech.Entities;
#endregion

namespace MechTech.Gateway
{
    public class EstruturaTabelaGL
    {
        EstruturaTabelaBO regrasnegocio = new EstruturaTabelaBO();

        /// <summary>
        /// Instância básica para EstruturaTabelaGL.
        /// </summary>
        public EstruturaTabelaGL()
        { }

        /// <summary>
        /// Retorna uma lista de objetos EstruturaTabelaDTO.
        /// </summary>
        public List<EstruturaTabelaDTO> GetListAll()
        {
            try
            {
                return regrasnegocio.GetListAll();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Cria todas as tabelas/objetos para o Banco de dados.
        /// </summary>
        public void Create()
        {
            try
            {
                regrasnegocio.Create();
            }
            catch
            {
                throw;
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
                regrasnegocio.Create(tables);
            }
            catch
            {
                throw;
            }
        }
    }
}