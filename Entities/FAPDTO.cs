using System;

#region MechTech
using MechTech.Util;
#endregion

namespace MechTech.Entities
{
    [Serializable]
    public class FAPDTO : IEquatable<FAPDTO>
    {
        public FAPDTO()
        { }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public FAPDTO(FAPDTO obj)
        {
            this.ID = obj.ID;
            this.ID_Empresa = obj.ID_Empresa;
            this.MesAno = obj.MesAno;
            this.PercentualRAT = obj.PercentualRAT;
            this.PercentualFAP = obj.PercentualFAP;
            this.Aliquota = obj.Aliquota;
        }

        private int id = 0;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int id_empresa = 0;
        public int ID_Empresa
        {
            get { return id_empresa; }
            set { id_empresa = value; }
        }

        private DateTime mesano = Global.MesanoAtivo;
        public DateTime MesAno
        {
            get { return mesano; }
            set { mesano = value; }
        }

        private decimal percentualrat = 0;
        public decimal PercentualRAT
        {
            get { return percentualrat; }
            set { percentualrat = value; }
        }

        private decimal percentualfap = 0;
        public decimal PercentualFAP
        {
            get { return percentualfap; }
            set { percentualfap = value; }
        }

        private decimal aliquota = 0;
        public decimal Aliquota
        {
            get { return aliquota; }
            set { aliquota = value; }
        }

        #region IEquatable<FAPDTO> Members
        public bool Equals(FAPDTO obj)
        {
            if (this.ID != obj.ID) return false;
            else if (this.ID_Empresa != obj.ID_Empresa) return false;
            else if (this.MesAno != obj.MesAno) return false;
            else if (this.PercentualRAT != obj.PercentualRAT) return false;
            else if (this.PercentualFAP != obj.PercentualFAP) return false;
            else if (this.Aliquota != obj.Aliquota) return false;

            return true;
        }
        #endregion
    }
}