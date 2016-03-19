using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region MECHTECH
using MechTech.Interfaces;
using MechTech.Entities;
using MechTech.Business.Contracts;
using MechTech.Data;
using System.ServiceModel;
#endregion

namespace MechTech.Business
{
    public class VincularVeiculoBO : IDados<VincularVeiculoDTO>
    {
        VincularVeiculoDAO regrasdados = new VincularVeiculoDAO();

        public VincularVeiculoBO()
        {
        }

        public List<VincularVeiculoDTO> GetPlacasCliente(int id)
        {
            try
            {
                return regrasdados.GetPlacasCliente(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public int Insert(VincularVeiculoDTO Vinc)
        {
            try
            {
                return regrasdados.Insert(Vinc);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool Update(VincularVeiculoDTO Vinc)
        {
            try
            {
                return regrasdados.Update(Vinc);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

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

        public VincularVeiculoDTO GetVeiculoVinc(int id)
        {
            try
            {
                return regrasdados.GetVeiculoVinc(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public int GetIdVeiculo(string veiculo)
        {
            try
            {
                return regrasdados.GetIdVeiculo(veiculo);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public string GetVeiculo(int id)
        {
            try
            {
                return regrasdados.GetVeiculo(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public string GetCliente(int id)
        {
            try
            {
                return regrasdados.GetCliente(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public List<VincularVeiculoDTO> GetGridVeiculoVinc(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetGridVeiculoVinc(campo, valorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public VincularVeiculoDTO GetVincularVeiculo(int id)
        {
            try
            {
                return regrasdados.GetVincularVeiculo(id);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}
