using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MechTech.Entities
{

    public class VeiculoDTO : IEquatable<VeiculoDTO>
    {
        public VeiculoDTO()
        {
        }

        public VeiculoDTO(VeiculoDTO obj)
        {
            this.Id = obj.Id;
            this.Veiculo = obj.Veiculo;
            this.Id_Marca = obj.Id_Marca;
            this.Tipo = obj.Tipo;        
        }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string veiculo = string.Empty;
        public string Veiculo
        {
            get { return veiculo; }
            set { veiculo = value; }
        }
   
        private int id_marca = 0;

        public int Id_Marca
        {
            get { return id_marca; }
            set { id_marca = value; }
        }

        private int tipo = 0;

        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private string descr_tipo = string.Empty;

        public string Descr_tipo
        {
            get { return descr_tipo; }
            set { descr_tipo = value; }
        }

        private string desc_marca = string.Empty;

        public string Desc_marca
        {
            get { return desc_marca; }
            set { desc_marca = value; }

           
        }


    
        public bool Equals(VeiculoDTO obj)
        {

            bool lretorno = true;
            if (this.Id != obj.Id) lretorno = false;
            if (this.Veiculo != obj.Veiculo) lretorno = false;
            if (this.Id_Marca != obj.Id_Marca) lretorno = false;
            if (this.Tipo != obj.Tipo) lretorno = false;
         

            return lretorno;

        }
    }


}
