using System.Collections.Generic;

#region MECHTECH
using MechTech.Util;
using MechTech.Business;
using MechTech.Entities;
using MechTech.Interfaces;
#endregion

namespace MechTech.Gateway
{
    public class CBOGL : IDados<CBODTO>
    {
        CBOBO regrasnegocio = new CBOBO();
        MechTech.Util.Proxy proxy;

        /// <summary>
        /// Instância básica para CBOGL.
        /// </summary>
        public CBOGL()
        {
            if (Global.TpConexao == Enumeradores.TipoConexao.WS)
                proxy = new MechTech.Util.Proxy("CBOBO");
        }

        /// <summary>
        /// Retorna o ID gerado pelo Banco de dados caso a instrução seja bem sucedida.
        /// </summary>
        public int Insert(CBODTO CBO)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Insert(CBO);
                else
                {
                    using (CBOBOClient regrasnegocioclient = new CBOBOClient(proxy.Binding, proxy.EndPoint))
                        return regrasnegocioclient.Insert(CBO);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Update(CBODTO CBO)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Update(CBO);
                else
                {
                    using (CBOBOClient regrasnegocioclient = new CBOBOClient(proxy.Binding, proxy.EndPoint))
                        return regrasnegocioclient.Update(CBO);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um tipo VERDADEIRO caso a instrução seja bem sucedida.
        /// </summary>
        public bool Delete(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Delete(id);
                else
                {
                    using (CBOBOClient regrasnegocioclient = new CBOBOClient(proxy.Binding, proxy.EndPoint))
                        return regrasnegocioclient.Delete(id);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna um objeto CBODTO caso a instrução seja bem sucedida.
        /// </summary>
        public CBODTO GetCBO(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetCBO(id);
                else
                {
                    using (CBOBOClient regrasnegocioclient = new CBOBOClient(proxy.Binding, proxy.EndPoint))
                        return regrasnegocioclient.GetCBO(id);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna uma lista de objetos CBODTO caso a instrução seja bem sucedida.
        /// </summary>
        public List<CBODTO> GetGridCBO(string Campo, string ValorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridCBO(Campo, ValorPesquisa);
                else
                {
                    using (CBOBOClient regrasnegocioclient = new CBOBOClient(proxy.Binding, proxy.EndPoint))
                        return regrasnegocioclient.GetGridCBO(Campo, ValorPesquisa);
                }
            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// Retorna um objeto CBODTO caso a instrução seja bem sucedida.
        /// </summary>
        public CBODTO GetCBOCodigo(string codigo)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetCBOCodigo(codigo);
                else
                {
                    using (CBOBOClient regrasnegocioclient = new CBOBOClient(proxy.Binding, proxy.EndPoint))
                        return regrasnegocioclient.GetCBOCodigo(codigo);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}