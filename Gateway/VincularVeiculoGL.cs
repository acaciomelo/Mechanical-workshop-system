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
    public class VincularVeiculoGL : IDados< VincularVeiculoDTO>
    {
        VincularVeiculoBO regrasnegocio = new VincularVeiculoBO();
        public VincularVeiculoGL()
        {
        }
        public List<VincularVeiculoDTO> GetPlacasCliente(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetPlacasCliente(id);
                else
                    return new List<VincularVeiculoDTO>();
            }
            catch
            {
                throw;
            }
        }
        public int Insert(VincularVeiculoDTO VincularVeiculo)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Insert(VincularVeiculo);
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }

        public bool Update(VincularVeiculoDTO VincularVeiculo)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Update(VincularVeiculo);
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

        public int GetIdVeiculo(string veiculo)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetIdVeiculo(veiculo);
                else
                    return new int();
            }
            catch
            {
                throw;
            }
        }

        public string GetVeiculo(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetVeiculo(id);
                else
                    return string.Empty;
            }
            catch
            {
                throw;
            }
        }

        public string GetCliente(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetCliente(id);
                else
                    return string.Empty;
            }
            catch
            {
                throw;
            }
        }

        public VincularVeiculoDTO GetVincularVeiculo(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetVincularVeiculo(id);
                else
                    return new VincularVeiculoDTO();
            }
            catch
            {
                throw;
            }
        }

        public VincularVeiculoDTO GetVeiculoVinc(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetVeiculoVinc(id);
                else
                    return new VincularVeiculoDTO();
            }
            catch
            {
                throw;
            }
        }


        public List<VincularVeiculoDTO> GetGridVincularVeiculo(string campo, string valorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridVeiculoVinc(campo, valorPesquisa);
                else
                    return new List<VincularVeiculoDTO>();
            }
            catch
            {
                throw;
            }
        }
    }
}
