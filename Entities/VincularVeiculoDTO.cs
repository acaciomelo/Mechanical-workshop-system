using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechTech.Entities
{
    public class VincularVeiculoDTO : IEquatable<VincularVeiculoDTO>
    {
        public VincularVeiculoDTO()
        {

        }

        public VincularVeiculoDTO(VincularVeiculoDTO obj)
        {
            this.Id = obj.Id;
            this.Id_Veiculo = obj.Id_Veiculo;
            this.Id_Cliente = obj.Id_Cliente;
            this.Placa = obj.Placa;
            this.Km = obj.Km;
            this.Cor = obj.Cor;
            this.Ano = obj.Ano;
            this.Num_chassi = obj.Num_chassi;
            this.Obs = obj.Obs;
            this.Foto = obj.Foto;
            this.Modelo = obj.Modelo;

        }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int id_cliente = 0;
        public int Id_Cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }

        private string cliente = string.Empty;

        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
       
        private int id_veiculo = 0;
        public int Id_Veiculo
        {
            get { return id_veiculo; }
            set { id_veiculo = value; }
        }

        private string veiculo = string.Empty;

        public string Veiculo
        {
            get { return veiculo; }
            set { veiculo = value; }
        }
        

        private string placa = string.Empty;

        public string Placa
        {
            get { return placa; }
            set { placa = value; }
        }

        private string cor = string.Empty;
        public string Cor
        {
            get { return cor; }
            set { cor = value; }
        }

        private string num_chassi = string.Empty;
        public string Num_chassi
        {
            get { return num_chassi; }
            set { num_chassi = value; }
        }

        private string ano = string.Empty;
        public string Ano
        {
            get { return ano; }
            set { ano = value; }
        }

        private string modelo = string.Empty;
        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        private  int  km = 0;
        public int Km
        {
            get { return km; }
            set { km = value; }
        }

        private string obs = string.Empty;
        public string Obs
        {
            get { return obs; }
            set { obs = value; }
        }

        private byte[] foto = null;
        public byte[] Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        public bool Equals(VincularVeiculoDTO obj)
        {
            bool lretorno = true;
            if (this.Id != obj.Id) lretorno = false;
            if (this.Id_Veiculo!= obj.Id_Veiculo) lretorno = false;
            if (this.Id_Cliente != obj.Id_Cliente) lretorno = false;
            if (this.Placa != obj.Placa) lretorno = false;
            if (this.Km != obj.Km) lretorno = false;
            if (this.Modelo != obj.Modelo) lretorno = false;
            if (this.Num_chassi != obj.Num_chassi) lretorno = false;
            if (this.Cor != obj.Cor) lretorno = false;
            if (this.Ano != obj.Ano) lretorno = false;
            if (this.Obs != obj.Obs) lretorno = false;
            if (this.Foto != obj.Foto) lretorno = false;
            return lretorno;

        }
    }
}
