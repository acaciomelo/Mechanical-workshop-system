using System;

namespace MechTech.Entities
{
    [Serializable]
    public class HorarioSemanaDTO : IEquatable<HorarioSemanaDTO>
    {
        public HorarioSemanaDTO()
        { }

        public HorarioSemanaDTO(int dia)
        {
            this.Diadasemana = dia;
        }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public HorarioSemanaDTO(HorarioSemanaDTO obj)
        {
            this.Id = obj.Id;
            this.Id_horario = obj.Id_horario;
            this.Diadasemana = obj.Diadasemana;
            this.Entradapp = obj.Entradapp;
            this.Saidapp = obj.Saidapp;
            this.Entradasp = obj.Entradasp;
            this.Saidasp = obj.Saidasp;
        }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int id_horario = 0;
        public int Id_horario
        {
            get { return id_horario; }
            set { id_horario = value; }
        }

        private int diadasemana = 0;
        public int Diadasemana
        {
            get { return diadasemana; }
            set { diadasemana = value; }
        }

        private DateTime entradapp = Convert.ToDateTime("01/01/1900");
        public DateTime Entradapp
        {
            get { return entradapp; }
            set { entradapp = value; }
        }

        private DateTime saidapp = Convert.ToDateTime("01/01/1900");
        public DateTime Saidapp
        {
            get { return saidapp; }
            set { saidapp = value; }
        }

        private DateTime entradasp = Convert.ToDateTime("01/01/1900");
        public DateTime Entradasp
        {
            get { return entradasp; }
            set { entradasp = value; }
        }

        private DateTime saidasp = Convert.ToDateTime("01/01/1900");
        public DateTime Saidasp
        {
            get { return saidasp; }
            set { saidasp = value; }
        }

        #region IEquatable<HorarioSemanaDTO> Members
        public bool Equals(HorarioSemanaDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Id_horario != obj.Id_horario) return false;
            else if (this.Diadasemana != obj.Diadasemana) return false;
            else if (this.Entradapp != obj.Entradapp) return false;
            else if (this.Saidapp != obj.Saidapp) return false;
            else if (this.Entradasp != obj.Entradasp) return false;
            else if (this.Saidasp != obj.Saidasp) return false;

            return true;
        }
        #endregion
    }
}