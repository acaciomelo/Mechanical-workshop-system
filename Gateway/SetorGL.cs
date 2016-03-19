using System.Collections.Generic;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
using MechTech.Interfaces;
#endregion

namespace MechTech.Gateway
{
    public class SetorGL : IDados<SetorDTO>
    {
        SetorBO regrasnegocio = new SetorBO();

        /// <summary>
        /// Instância básica para SetorGL.
        /// </summary>
        public SetorGL()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(SetorDTO Setor)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Insert(Setor);
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
        public bool Update(SetorDTO Setor)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Update(Setor);
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
        /// Retorna um objeto SetorDTO para a instrução do conteúdo especificado.
        /// </summary>
        public SetorDTO GetSetor(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetSetor(id);
                else
                    return new SetorDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos SetorDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<SetorDTO> GetGridSetor(string campo, string valorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridSetor(campo, valorPesquisa);
                else
                    return new List<SetorDTO>();
            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// Retorna um objeto SetorDTO para a instrução do conteúdo especificado.
        /// </summary>
        public SetorDTO GetSetorCodigo(int codigo)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetSetorCodigo(codigo);
                else
                    return new SetorDTO();
            }
            catch
            {
                throw;
            }
        }
    }
}