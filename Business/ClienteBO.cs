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
    public class ClienteBO : IDados<ClienteDTO>
    {
        ClienteDAO regrasdados = new ClienteDAO();

        public ClienteBO()
        {
        }

        public int Insert(ClienteDTO cliente)
        {
            try
            {
                return regrasdados.Insert(cliente);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool Update(ClienteDTO cliente)
        {
            try
            {
                return regrasdados.Update(cliente);
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

        public ClienteDTO GetCliente(int id)
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

        public List<ClienteDTO> GetGridCliente(string campo, string valorPesquisa)
        {
            try
            {
                return regrasdados.GetGridCliente(campo, valorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool ExistsCPF(int id_cliente, string cpf)
        {
            try
            {
                return new ClienteDAO().ExistsCPF(id_cliente, cpf);
            }
            catch
            {
                return false;
            }
        }
    }
}

