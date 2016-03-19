using System;
using System.Collections.Generic;

namespace MechTech.Entities
{
    [Serializable]
    public class HorarioDTO : IEquatable<HorarioDTO>
    {
        public HorarioDTO()
        { }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public HorarioDTO(HorarioDTO obj)
        {
            this.Id = obj.Id;
            this.Descricao = obj.Descricao;

            //LISTAS GENÉRICAS
            foreach (HorarioSemanaDTO umhorariosemana in obj.Horariosemana)
            {
                this.Horariosemana.Add(new HorarioSemanaDTO(umhorariosemana));
            }
        }

        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string descricao = string.Empty;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        private List<HorarioSemanaDTO> horariosemana = new List<HorarioSemanaDTO>();
        public List<HorarioSemanaDTO> Horariosemana
        {
            get { return horariosemana; }
            set { horariosemana = value; }
        }

        #region IEquatable<HorarioDTO> Members
        public bool Equals(HorarioDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Descricao != obj.Descricao) return false;

            //LISTAS GENÉRICAS
            //if (this.Horariosemana.Count != obj.Horariosemana.Count)
            //    return false;
            //else
            //{
            //    foreach (HorarioSemanaDTO umhorariosemana in this.Horariosemana)
            //    {
            //        try
            //        {
            //            if (!umhorariosemana.Equals(obj.Horariosemana.Find(delegate(HorarioSemanaDTO item) { return item.Id == umhorariosemana.Id; })))
            //                return false;
            //        }
            //        catch { return false; }
            //    }
            //}
            //

            return true;
        }
        #endregion
    }
}