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
    public  class VeiculoGL : IDados<VeiculoDTO>
    {
        VeiculoBO regrasnegocio = new VeiculoBO();
        public VeiculoGL()
        {
        }

        public int Insert(VeiculoDTO veiculo)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Insert(veiculo);
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }

        public bool Update(VeiculoDTO veiculo)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.Update(veiculo);
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

        public VeiculoDTO GetVeiculo(int id)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetVeiculo(id);
                else
                    return new VeiculoDTO();
            }
            catch
            {
                throw;
            }
        }

        public List<VeiculoDTO> GetGridVeiculo(string campo, string valorPesquisa)
        {
            try
            {
                if (Global.TpConexao == Enumeradores.TipoConexao.LAN)
                    return regrasnegocio.GetGridVeiculo(campo, valorPesquisa);
                else
                    return new List<VeiculoDTO>();
            }
            catch
            {
                throw;
            }
        }
    }
}
