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
    public class AtivacaoBO
    {
        AtivacaoDAO regradados = new AtivacaoDAO();

        public void Insert(int codigo,string razao)
        {
            try
            {
                regradados.InserirClienteLocal(razao);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }   
    }
}
