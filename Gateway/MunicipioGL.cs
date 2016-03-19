using System.Collections.Generic;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
using MechTech.Interfaces;
#endregion

namespace MechTech.Gateway
{
    public class MunicipioGL : IDados<MunicipioDTO>
    {
        MunicipioBO regrasnegocio = new MunicipioBO();

        /// <summary>
        /// Instância básica para MunicipioGL.
        /// </summary>
        public MunicipioGL()
        { }

        /// <summary>
        /// Retorna o ID gerado para o objeto especificado.
        /// </summary>
        public int Insert(MunicipioDTO Municipio)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Insert(Municipio);
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
        public bool Update(MunicipioDTO Municipio)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Update(Municipio);
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
        /// Retorna um objeto MunicipioDTO para a instrução do conteúdo especificado.
        /// </summary>
        public MunicipioDTO GetMunicipio(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetMunicipio(id);
                else
                    return new MunicipioDTO();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos MunicipioDTO para a instrução do conteúdo especificado.
        /// </summary>
        public List<MunicipioDTO> GetGridMunicipio(string Campo, string ValorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridMunicipio(Campo, ValorPesquisa);
                else
                    return new List<MunicipioDTO>();
            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// Retorna um objeto MunicipioDTO para a instrução do conteúdo especificado.
        /// </summary>
        public MunicipioDTO GetMunicipioIBGE(int codigoibge)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetMunicipioIBGE(codigoibge);
                else
                    return new MunicipioDTO();
            }
            catch
            {
                throw;
            }
        }
    }
}