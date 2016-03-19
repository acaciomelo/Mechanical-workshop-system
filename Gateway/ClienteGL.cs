using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region MechTech
using MechTech.Util;
using MechTech.Entities;
using MechTech.Interfaces;
using MechTech.Business;
#endregion

namespace MechTech.Gateway
{
    public class ClienteGL : IDados<ClienteDTO>
    {
        ClienteBO regrasnegocio = new ClienteBO();
        public ClienteGL()
        {
        }

        public int Insert(ClienteDTO cliente)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Insert(cliente);
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }

        public bool Update(ClienteDTO cliente)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Update(cliente);
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }


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

        public ClienteDTO GetCliente(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetCliente(id);
                else
                    return new ClienteDTO();
            }
            catch
            {
                throw;
            }
        }

        public List<ClienteDTO> GetGridCliente(string campo, string valorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridCliente(campo, valorPesquisa);
                else
                    return new List<ClienteDTO>();
            }
            catch
            {
                throw;
            }
        }

        public bool ExistsCPF(int id_cliente, string cpf)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.ExistsCPF(id_cliente, cpf);
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
