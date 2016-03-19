using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

using MechTech.Entities;


namespace MechTech.Business.Calculos
{
    public class Orcamento : CalculoBase<OrcamentoDTO>, IDisposable
    {
        public override OrcamentoDTO Calcula(OrcamentoDTO obj)
        {
            try
            {
                obj.ValorLiquido = 0;
                foreach (LancamentoProdutoServicoDTO contem in obj.Produtoservico)
                {
                    obj.ValorLiquido += contem.ValorLiquido;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
            return obj;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
