using System.Collections.Generic;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
using MechTech.Interfaces;
#endregion

namespace MechTech.Gateway
{
    public class RotinaGL : IDados<RotinaDTO>
    {
        RotinaBO regrasnegocio = new RotinaBO();

        /// <summary>
        /// Instância básica para RotinaGL.
        /// </summary>
        public RotinaGL()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(RotinaDTO Rotina)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Insert(Rotina);
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do objeto especificado, caso contrário FALSO.
        /// </summary>
        public bool Update(RotinaDTO Rotina)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Update(Rotina);
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO para a instrução do conteúdo especificado, caso contrário FALSO.
        /// </summary>
        public bool Delete(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Delete(id);
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto RotinaDTO para a instrução do conteúdo especificado.
        /// </summary>
        public RotinaDTO GetRotina(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetRotina(id);
                else
                    return new RotinaDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos RotinaDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<RotinaDTO> GetGridRotina(string Campo, bool ValorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridRotina(Campo, ValorPesquisa);
                else
                    return new List<RotinaDTO>();
            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// Retorna somente as rotinas especificas de menu, na ordem do menu
        /// </summary>
        /// <param name="modulo">Código do módulo com 2 caracteres, se branco, retorna todos</param>
        /// <returns></returns>
        public List<RotinaDTO> GetRotinaModulo(string modulo)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetRotinaModulo(modulo);
                else
                    return new List<RotinaDTO>();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna somente as rotinas disponíveis para acesso do usuário ativo.
        /// </summary>
        /// <returns></returns>
        public List<int> GetAcessos()
        {
            //try
            //{
            //    if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
            //        return regrasnegocio.GetAcessos();
            //    else
            //        return new List<int>();
            //}
            //catch
            //{
            //    throw;
            //}
            return new List<int>(); 
        }
    }
}