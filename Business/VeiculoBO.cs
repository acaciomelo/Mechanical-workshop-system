using MechTech.Data;
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
   public  class VeiculoBO :IDados<VeiculoDTO>
    {
       VeiculoDAO regrasdados = new VeiculoDAO();

       public VeiculoBO()
       {
       }
       public int Insert(VeiculoDTO Veiculo)
       {
           try
           {
               return regrasdados.Insert(Veiculo);
           }
           catch (Exception ex)
           {
               throw new FaultException(ex.Message);
           }
       }

       public bool Update(VeiculoDTO Veiculo)
       {
           try
           {
               return regrasdados.Update(Veiculo);
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

       public VeiculoDTO GetVeiculo(int id)
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

       public List<VeiculoDTO> GetGridVeiculo(string campo, string valorPesquisa)
       {
           try
           {
               return regrasdados.GetGridVeiculo(campo, valorPesquisa);
           }
           catch (Exception ex)
           {
               throw new FaultException(ex.Message);
           }
       }
    }
}
