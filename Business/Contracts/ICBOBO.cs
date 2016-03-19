using System.ServiceModel;
using System.Collections.Generic;
using MechTech.Entities;

namespace MechTech.Business.Contracts
{
    [ServiceContract]
    interface ICBOBO
    {
        [OperationContract]
        bool Delete(int id);

        [OperationContract]
        CBODTO GetCBO(int id);

        [OperationContract]
        CBODTO GetCBOCodigo(string codigo);

        [OperationContract]
        List<CBODTO> GetGridCBO(string Campo, string ValorPesquisa);

        [OperationContract]
        int Insert(CBODTO CBO);

        [OperationContract]
        bool Update(CBODTO CBO);
    }
}
