﻿using System;

namespace MechTech.Entities
{
    [Serializable]
    public class UFDTO : IEquatable<UFDTO>
    {
        public UFDTO()
        { }

        /// <summary>
        /// Gerenciador de versão do objeto.
        /// </summary>
        public UFDTO(UFDTO obj)
        {
            this.Id = obj.Id;
            this.Descricao = obj.Descricao;
            this.Codigo = obj.Codigo;
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

        private string codigo = string.Empty;
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        #region IEquatable<UFDTO> Members
        public bool Equals(UFDTO obj)
        {
            if (this.Id != obj.Id) return false;
            else if (this.Descricao != obj.Descricao) return false;
            else if (this.Codigo != obj.Codigo) return false;

            return true;
        }
        #endregion
    }
}